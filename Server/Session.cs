using System.Net.Sockets;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Util;
using MessagePack;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;
using MoonlightPGR.Server.PacketUtils.PacketTypes;
using Newtonsoft.Json.Linq;
using System.Numerics;

namespace MoonlightPGR.Server
{
    public class Session
    {
        public readonly Logger c;
        private readonly TcpClient _client;
        public readonly string _id;
        public int uid = 0;

        public Session(TcpClient client, string id)
        {
            _client = client;
            _id = id;
            c = new Logger(id, ConsoleColor.Yellow);
            //Task.Run(() => ClientLoop(client));
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
                                return;
                            }
                            c.Log($"Recv : {packet.Type}[ {Req.PacketName} ({packet.Seq})] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(Req.Body))}");
                            ReqHandler.Invoke(this, Req);
                            break;
                        case BasePacket.PacketContentType.PushPacket:
                            var Push = MessagePackSerializer.Deserialize<PushPacket>(packet.Data);
                            var PushHandler = HandlerFactory.GetHandler(Push.PacketName);
                            if (PushHandler == null)
                            {
                                c.Warn($"Unhandled packet {Push.PacketName}");
                                return;
                            }
                            c.Log($"Recv : {packet.Type}[ {Push.PacketName} ({packet.Seq})] | {JsonConvert.SerializeObject(MessagePackSerializer.Deserialize<object>(Push.Body))}");
                            PushHandler.Invoke(this, Push);
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

        public bool Send(string packetName, byte[] data)
        {
            //Packet packet = new Packet(cmd, body.ToByteArray());
            byte[] msg = new byte[data.Length];
            Array.Copy(data, msg, data.Length);
            try
            {
                _client.GetStream().Write(msg, 0, msg.Length);
                c.Debug(BitConverter.ToString(msg).Replace("-", "").Trim('0'));
                //c.Log(Enum.GetName(typeof(CmdID), packet._CmdId) ?? packet._CmdId.ToString());
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
