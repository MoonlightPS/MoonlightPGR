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

            session.Send("HeartbeatResponse", rsp, packet.Seq, new byte[] { 0x2F, 0x0, 0x0, 0x0 });
        }

        [PacketHandler("Ping")]
        public static void HandlePing(Session session, RequestPacket packet)
        {
            Ping body = MessagePackSerializer.Deserialize<Ping>(packet.Body);

            Pong rsp = new()
            {
                UtcTime = body.UtcTime,
            };

            session.Send("Pong", rsp, packet.Seq, new byte[] { 0x20, 0x0, 0x0, 0x0 });
        }
    }
}
