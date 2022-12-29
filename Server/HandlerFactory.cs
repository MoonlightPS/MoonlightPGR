using MoonlightPGR.Server.PacketUtils;

namespace MoonlightPGR.Server
{
    internal class HandlerFactory
    {
        private static readonly Dictionary<string, Action<Session, IPacket>> _handlers = new();

        public static void RegisterHandler(string packetName, Action<Session, IPacket> handler)
        {
            _handlers.Add(packetName, handler);
        }

        public static Action<Session, IPacket>? GetHandler(string packetName)
        {
            return (_handlers.TryGetValue(packetName, out var handler)) ? handler : null;
        }
    }

    internal class PacketHandlerAttribute : Attribute
    {
        public string PacketName { get; }

        public PacketHandlerAttribute(string packetName)
        {
            PacketName = packetName;
        }
    }
}
