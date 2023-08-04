using MessagePack;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server.Handlers
{
    internal class HeartbeatReq
    {
        [PacketHandler("HeartbeatRequest")]
        public static void HandleHeartbeat(Session session, RequestPacket packet)
        {
            HeartbeatResponse rsp = new()
            {
                UtcServerTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            };

            session.Send("HeartbeatResponse", rsp, packet.Seq);
        }

        [PacketHandler("Ping")]
        public static void HandlePing(Session session, RequestPacket packet)
        {
            Ping body = MessagePackSerializer.Deserialize<Ping>(packet.Body);

            Pong rsp = new()
            {
                UtcTime = body.UtcTime,
            };

            session.Send("Pong", rsp, packet.Seq);
        }

        [PacketHandler("DoClientTaskEventRequest")]
        public static void HandleEventTask(Session session, RequestPacket packet)
        {
            session.Send("DoClientTaskEventResponse", MessagePackSerializer.ConvertFromJson("{\"Code\": 0}"), packet.Seq);
        }

        [PacketHandler("SetReviewSlapFaceStateRequest")]
        public static void HandleSetReviewSlapFaceStateRequest(Session session, RequestPacket packet)
        {
            session.Send("SetReviewSlapFaceStateResponse", MessagePackSerializer.ConvertFromJson("{\"Code\": 0}"), packet.Seq);
        }
    }
}
