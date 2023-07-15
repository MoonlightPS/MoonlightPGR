using MessagePack;
using Newtonsoft.Json;

namespace MoonlightPGR.Server.PacketUtils.Interfaces
{
    [MessagePackObject(true)]
    public class ILoginRequest
    {
        public string ServerBean { get; set; }
        public int LoginType { get; set; }
        public int LoginPlatform { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string ClientVersion { get; set; }
        public string Token { get; set; }
    }

    [MessagePackObject(true)]
    public class LoginResponse
    {
        public int Code { get; set; }
        public int UtcOffset { get; set; }
        public int UtcServerTime { get; set; }
        public string ReconnectToken { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyDailyLotteryData
    {
        public List<object> Lotteries { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyPayInfo
    {
        public double TotalPayMoney { get; set; }
        public bool IsGetFirstPayReward { get; set; }
    }
}
