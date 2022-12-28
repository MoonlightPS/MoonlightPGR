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
            //Task.Run(Loop);
            Thread runner = new Thread(Loop);
            runner.Priority = ThreadPriority.Highest;
            runner.Start();
        }

        public void Loop()
        {
            _server.Start();
            Logger.c.Log($"Running on port {_port}");

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
