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
        private readonly List<string> blacklistedPackets = new() 
        {
            "HeartbeatRequest",
            "HeartbeatResponse",
            "Ping",
            "Pong"
        };

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
            byte[] lengthBuffer = new byte[4];
            byte[] buffer = new byte[1 << 16];
            int bytesRead = 0;
            int totalLength = 0;
            List<byte> messageBuffer = new List<byte>();

            while (client.Connected)
            {
                if (bytesRead < 4)
                {
                    int remainingLengthBytes = 4 - bytesRead;
                    int lengthBytesRead = ns.Read(lengthBuffer, bytesRead, remainingLengthBytes);
                    if (lengthBytesRead > 0)
                    {
                        bytesRead += lengthBytesRead;
                        if (bytesRead == 4)
                        {
                            totalLength = BitConverter.ToInt32(lengthBuffer, 0);
                            messageBuffer = new List<byte>(totalLength);
                        }
                    }
                }

                if (bytesRead >= 4 && ns.DataAvailable)
                {
                    int messageBytesRead = ns.Read(buffer, 0, Math.Min(totalLength, buffer.Length));
                    if (messageBytesRead > 0)
                    {
                        bytesRead += messageBytesRead;
                        messageBuffer.AddRange(buffer.Take(messageBytesRead));

                        if (bytesRead - 4 == totalLength)
                        {
                            onMessage(messageBuffer.ToArray());
                            bytesRead = 0;
                            totalLength = 0;
                            messageBuffer.Clear();
                        }
                    }
                }
            }
        }





        private void onMessage(byte[] message)
        {
            PGRCrypto.Decrypt(message);
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
                            return;
                        }
                        if (!blacklistedPackets.Contains(Req.PacketName))
                        {
                            //c.Log($"Recv : {packet.Type}[ {Req.PacketName} ({packet.Seq} | {Req.Seq}) ] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(Req.Body))}");
                            c.Log($"Recv : {Req.PacketName}");
                        }
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
            if (!blacklistedPackets.Contains(PacketName))
            {
                //c.Log($"Sent : {packet.Type}[ {PacketName} ({packet.Seq}) ] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(data))}");
                c.Log($"Sent : {PacketName}");
            }
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
