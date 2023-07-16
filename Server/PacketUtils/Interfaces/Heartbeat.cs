using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.Interfaces
{
    public class HeartbeatRequest
    {

    }

    [MessagePackObject(true)]
    public class HeartbeatResponse
    {
        public long UtcServerTime { get; set; }
    }

    [MessagePackObject(true)]
    public class Ping
    {
        public long UtcTime { get; set; }
    }

    [MessagePackObject(true)]
    public class Pong
    {
        public long UtcTime { get; set; }
    }
}
