using MessagePack;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;
namespace MoonlightPGR.Server.Handlers
{
    internal class HandshakeRequest
    {
        [PacketHandler("HandshakeRequest")]
        public static void Handle(Session session, IPacket packet)
        {
            object body = MessagePackSerializer.Deserialize<object>((packet as RequestPacket).Body);

            HandshakeResponse rsp = new HandshakeResponse()
            {
                Code = 0,
                UtcOpenTime = 0,
                Sha1Table = null
            };

            session.Send("HandshakeResponse", rsp);
             
        }
    }
}
