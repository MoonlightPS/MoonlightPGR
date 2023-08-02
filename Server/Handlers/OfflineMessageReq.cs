using MessagePack;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server.Handlers
{
    internal class OfflineMessageReq
    {
        [PacketHandler("OfflineMessageRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            session.Send("OfflineMessageResponse", MessagePackSerializer.ConvertFromJson("{\"Code\":0,\"Messages\":null}"), packet.Seq);
        }
    }
}
