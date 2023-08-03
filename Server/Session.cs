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
        public uint ServerSeq = 0;

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
            byte[] buffer = new byte[1 << 16]; // 64KB buffer size
            while (client.Connected)
            {
                if (ns.DataAvailable)
                {
                    int bytesRead = ns.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        byte[] message = new byte[bytesRead];
                        Buffer.BlockCopy(buffer, 0, message, 0, bytesRead);
                        onMessage(message);
                    }
                }
            }
        }


        private void onMessage(byte[] message)
        {
            while (message.Length > 0)
            {
                int length = BitConverter.ToInt32(message, 0);
                byte[] payload = message.Skip(4).Take(length).ToArray();
                PGRCrypto.Decrypt(payload);
                message = message.Skip(length + 4).ToArray();
                //c.Log($"Decrypted : {Convert.ToHexString(message)}");
                
                BasePacket packet = MessagePackSerializer.Deserialize<BasePacket>(payload, lz4Options);
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
                                return;
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
        }

        public bool Send(string PacketName, object data, uint clientSeq = 0)
        {
            byte[] serializedData = MessagePackSerializer.Serialize(data);
            return Send(PacketName, serializedData, clientSeq);
        }

        public bool Send(string PacketName, byte[] data, uint clientSeq = 0)
        {
            object rsp;

            if (clientSeq != 0)
            {
                rsp = new ResponsePacket()
                {
                    Seq = clientSeq,
                    Body = data,
                    PacketName = PacketName,
                };
            }
            else
            {
                rsp = new PushPacket()
                {
                    Body = data,
                    PacketName = PacketName,
                };
            }

            BasePacket packet = new BasePacket()
            {
                Type = clientSeq != 0 ? BasePacket.PacketContentType.ResponsePacket : BasePacket.PacketContentType.PushPacket,
                Data = MessagePackSerializer.Serialize(rsp),
                Seq = clientSeq != 0 ? 0 : ++ServerSeq
            };
            c.Log($"Sent : {packet.Type}[ {PacketName} ({packet.Seq}) ] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(data))}");
            return Send(MessagePackSerializer.Serialize(packet, lz4Options));
        }

        public bool Send(byte[] data)
        {
            //Logger.c.Debug($"Sent [{data.Length}] {Convert.ToHexString(BitConverter.GetBytes(data.Length))}{Convert.ToHexString(data)}");

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
    }
}
