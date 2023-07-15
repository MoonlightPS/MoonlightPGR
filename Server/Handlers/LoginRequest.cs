using MessagePack;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server.Handlers
{
    internal class LoginRequest
    {
        [PacketHandler("LoginRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            ILoginRequest body = MessagePackSerializer.Deserialize<ILoginRequest>(packet.Body);

            LoginResponse rsp = new()
            {
                Code = 0,
                UtcOffset = 0,
                UtcServerTime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                ReconnectToken = "00163efffe00a63d-00261210-00014d9c-0092c1e1275aa708-003a7fb7"
            };

            session.Send("LoginResponse", rsp, packet.Seq);

            NotifyDailyLotteryData lotteryData = new()
            {
                Lotteries = new List<object> { }
            };

            session.Send("NotifyDailyLotteryData", lotteryData, ++packet.Seq);

            NotifyPayInfo payInfo = new()
            {
                TotalPayMoney = 0.0,
                IsGetFirstPayReward = false
            };

            session.Send("NotifyPayInfo", payInfo, packet.Seq);
        }
    }
}
