using MessagePack;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Server.PacketUtils.PacketTypes;
namespace MoonlightPGR.Server.Handlers
{
    internal class HandshakeRequest
    {
        [PacketHandler("HandshakeRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            // How nice.. they added debugging into REL
            // We don't even need to answer it
            object body = MessagePackSerializer.Deserialize<object>(packet.Body);
            session.c.Log("Received HandshakeRequest");

           // session.Send()
            
        }
    }
}
