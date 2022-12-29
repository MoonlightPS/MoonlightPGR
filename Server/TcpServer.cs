using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Util;
using System.Net;
using System;
using System.Net.Sockets;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

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
            //Task.Run(Loop);
            Thread runner = new Thread(Loop);
            runner.Priority = ThreadPriority.Highest;
            runner.Start();
        }

        public void Loop()
        {
            _server.Start();
            Logger.c.Log($"Running on port {_port}");

            foreach (var type in typeof(HandlerFactory).Assembly.GetTypes())
            {
                foreach (var method in type.GetMethods())
                {
                    var attributes = method.GetCustomAttributes(typeof(PacketHandlerAttribute), false);
                    if (attributes.Length > 0)
                    {
                        var attribute = (PacketHandlerAttribute)attributes[0];
                        Console.WriteLine($"{attribute}");
                        var handler = (Action<Session, IPacket>)Delegate.CreateDelegate(typeof(Action<Session, IPacket>), method);
                        HandlerFactory.RegisterHandler((string)attribute.PacketName, handler);
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
