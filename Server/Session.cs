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
        public int uid = 0;
        public bool isSeqSet = false;
        public uint seq = 0;

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
                //c.Log($"Decrypted : {Convert.ToHexString(message)}");
                MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);
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
                            c.Log($"Recv : {packet.Type}[ {Req.PacketName} ({packet.Seq}) ] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(Req.Body, lz4Options))}");
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

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public bool Send(string PacketName, object data, uint seq)
        {
            MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);

            ResponsePacket rsp = new ResponsePacket()
            {
                Seq = seq,
                Body = MessagePackSerializer.Serialize(data, lz4Options),
                PacketName = PacketName,
            };

            BasePacket packet = new BasePacket()
            {
                Type = BasePacket.PacketContentType.ResponsePacket,
                Data = MessagePackSerializer.Serialize(rsp),
                Seq = 0
            };
            c.Log($"Sent : {packet.Type}[ {PacketName} ({packet.Seq}) ] | {JsonConvert.SerializeObject(data)}");
            return Send(MessagePackSerializer.Serialize(packet, lz4Options));
        }

        public bool Send(byte[] data)
        {
            byte[] msg = new byte[4 + data.Length];
            BinaryWriter bw = new BinaryWriter(new MemoryStream(msg));

            bw.Write(new byte[] { 0x3A, 0, 0, 0 }); // Idk what this is
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
                //c.Debug($"SENT {BitConverter.ToString(msg).Replace("-", "")}");
                return true;
            }
            catch (Exception e)
            {
                c.Error(e.Message);
                return false;
            }
        } 
    }
}
