using System.Net.Sockets;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Util;
using MessagePack;
using Newtonsoft.Json;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server
{
    public class Session
    {
        public readonly Logger c;
        private readonly TcpClient _client;
        public readonly string _id;
        public uint ServerSeq = 1;
        public List<uint> requestIds = new List<uint>();

        private readonly MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);

        public Session(TcpClient client, string id)
        {
            _client = client;
            _id = id;
            c = new Logger(id, ConsoleColor.Yellow);
            Thread task = new Thread(() => ClientLoop(client));
            task.Priority = ThreadPriority.Highest;
            task.Start();
        }

        private void ClientLoop(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] msg = new byte[1 << 16];
            while (client.Connected)  //while the `client is connected, we look for incoming messages
            {
                Array.Clear(msg, 0, msg.Length);

                try
                {
                    var len = ns.Read(msg, 0, msg.Length);
                    if (len > 0)
                    {
                        // Get message
                        //c.Debug(BitConverter.ToString(msg).Replace("-", "").Trim('0'));
                        onMessage(msg);
                    }
                }
                catch (Exception e)
                {
                    c.Error(e.Message);
                    //ignored
                }


            }
        }

        private void onMessage(byte[] message)
        {
            try
            {
                string array = Convert.ToHexString(message).Trim('0');
                array = array.Substring(8, array.Length - 8);
                message = StringToByteArray(array);
                PGRCrypto.Decrypt(message);
                c.Log($"Decrypted : {Convert.ToHexString(message)}");
                
                BasePacket packet = MessagePackSerializer.Deserialize<BasePacket>(message, lz4Options);
                //c.Log($"Base Packet Received : {JsonConvert.SerializeObject(packet)}");

                if (packet.Type != BasePacket.PacketContentType.Exception)
                {
                    switch (packet.Type)
                    {
                        case BasePacket.PacketContentType.RequestPacket:
                            var Req = MessagePackSerializer.Deserialize<RequestPacket>(packet.Data);
                            var ReqHandler = HandlerFactory.GetHandler(Req.PacketName);
                            if (ReqHandler == null)
                            {
                                c.Warn($"Unhandled packet {Req.PacketName}");
                                //return;
                            }
                            c.Log($"Recv : {packet.Type}[ {Req.PacketName} ({packet.Seq} | {Req.Seq}) ] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(Req.Body))}");
                            ReqHandler.Invoke(this, Req);
                            break;
                        case BasePacket.PacketContentType.PushPacket:
                            var Push = MessagePackSerializer.Deserialize<PushPacket>(packet.Data);
                            var PushHandler = HandlerFactory.GetHandler(Push.PacketName);
                            if (PushHandler == null)
                            {
                                c.Warn($"Unhandled packet {Push.PacketName}");
                                //return;
                            }
                            c.Log($"Recv : {packet.Type}[ {Push.PacketName} ({packet.Seq}) ] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(Push.Body))}");
                            //PushHandler.Invoke(this, Push);
                            break;
                        case BasePacket.PacketContentType.Exception:
                            ExceptionPacket ex = MessagePackSerializer.Deserialize<ExceptionPacket>(packet.Data);
                            c.Error($"Error Recv : {packet.Type}({packet.Seq}) | ({ex.ErrorCode}) {ex.ErrorMessage}", false);
                            break;
                    }
                    
                }
            }
            catch (Exception e)
            {
                c.Error(e.ToString());
            }
        }

        public bool Send(string PacketName, object data, uint clientSeq = 0)
        {
            object rsp;

            if (clientSeq != 0)
            {
                rsp = new ResponsePacket()
                {
                    Seq = clientSeq,
                    Body = MessagePackSerializer.Serialize(data),
                    PacketName = PacketName,
                };
                requestIds.Add(clientSeq);
            }
            else
            {
                rsp = new PushPacket()
                {
                    Body = MessagePackSerializer.Serialize(data),
                    PacketName = PacketName,
                };
            }

            BasePacket packet = new BasePacket()
            {
                Type = clientSeq != 0 ? BasePacket.PacketContentType.ResponsePacket : BasePacket.PacketContentType.PushPacket,
                Data = MessagePackSerializer.Serialize(rsp),
                Seq = clientSeq != 0 ? 0 : TryGetNextServerSeq()
            };
            c.Log($"Sent : {packet.Type}[ {PacketName} ({packet.Seq}) ] | {JsonConvert.SerializeObject(data)}");
            return Send(MessagePackSerializer.Serialize(packet, lz4Options));
        }

        public bool Send(byte[] data)
        {
            Logger.c.Debug($"Sent {Convert.ToHexString(BitConverter.GetBytes(data.Length))}{Convert.ToHexString(data)}");

            byte[] msg = new byte[4 + data.Length];
            BinaryWriter bw = new BinaryWriter(new MemoryStream(msg));

            bw.Write(BitConverter.GetBytes(data.Length)); // Packet len :skull:
            PGRCrypto.Encrypt(data);
            bw.Write(data);
            
            bw.Flush();
            bw.Close();

            
            return SendRaw(msg);
        }

        public bool SendRaw(byte[] msg)
        {
            try
            {
                _client.GetStream().Write(msg, 0, msg.Length);
                return true;
            }
            catch (Exception e)
            {
                c.Error(e.Message);
                return false;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public uint TryGetNextServerSeq()
        {
            while (requestIds.Contains(++ServerSeq))
            {
                ServerSeq++;
            }
            return ServerSeq;
        }
    }
}
