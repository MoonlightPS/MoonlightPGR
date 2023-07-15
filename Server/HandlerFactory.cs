using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server
{
    internal class HandlerFactory
    {
        private static readonly Dictionary<string, Action<Session, RequestPacket>> _handlers = new();

        public static void RegisterHandler(string packetName, Action<Session, RequestPacket> handler)
        {
            _handlers.Add(packetName, handler);
        }

        public static Action<Session, RequestPacket>? GetHandler(string packetName)
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
