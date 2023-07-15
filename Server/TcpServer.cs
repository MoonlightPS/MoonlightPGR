using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Server.PacketUtils.PacketTypes;
using MoonlightPGR.Util;
using System.Net;
using System.Net.Sockets;

namespace MoonlightPGR.Server
{
    public class TcpServer
    {
        TcpListener _server;
        public readonly int _port;
        public Dictionary<string, Session> sessions = new();

        public TcpServer(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            _server = new TcpListener(localAddr, port);
            _port = port;
            Thread runner = new Thread(Loop);
            runner.Priority = ThreadPriority.Highest;
            runner.Start();
        }

        public void Loop()
        {
            _server.Start();
            Logger.c.Log($"Running on port {_port}");
            // Register handlers with reflection
            foreach (var type in typeof(HandlerFactory).Assembly.GetTypes().Where(a => a.FullName.Contains("MoonlightPGR.Server.Handlers")))
            {
                foreach (var method in type.GetMethods())
                {
                    var attributes = method.GetCustomAttributes(typeof(PacketHandlerAttribute), false);
                    if (attributes.Length > 0)
                    {
                        var attribute = (PacketHandlerAttribute)attributes[0];
                        var handler = (Action<Session, RequestPacket>)Delegate.CreateDelegate(typeof(Action<Session, RequestPacket>), method);
                        HandlerFactory.RegisterHandler(attribute.PacketName, handler);
                    }
                }
            }

            while (true)
            {
                TcpClient client = _server.AcceptTcpClient();
                var origin = client.Client.RemoteEndPoint!.ToString()!;
                Logger.c.Log($"New connection from {origin}");

                var session = new Session(client, origin);
                sessions.Add(origin, session);
            }
        }
    }
}