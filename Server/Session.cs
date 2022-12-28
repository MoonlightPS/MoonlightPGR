using System.Net.Sockets;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Util;
using MessagePack;
using System;

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
                        c.Debug(BitConverter.ToString(msg).Replace("-", "").Trim('0'));
                        onMessage(msg);
                    }
                }
                catch(Exception e)
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
                message = StringToByteArray(Convert.ToHexString(message).Trim('0'));
                string packetName = "null"; // have to figure out way to get packet name after deserializing
                PGRCrypto.Decrypt(message);
                c.Log($"Decrypted : {Convert.ToHexString(message)}");
                MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);
                BasePacket packet = MessagePackSerializer.Deserialize<BasePacket>(message, lz4Options);
                Console.WriteLine(packet.Type.ToString());
            } catch (Exception e)
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
