using MessagePack;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server.Handlers
{
    internal class EnterWorldChatReq
    {
        [PacketHandler("EnterWorldChatRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            session.Send("EnterWorldChatResponse", MessagePackSerializer.ConvertFromJson("{\"Code\":0,\"ChannelId\":0}"), packet.Seq);
        }
    }
}
