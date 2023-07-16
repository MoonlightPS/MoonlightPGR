using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.Interfaces
{

    [MessagePackObject(true)]
    public class HandshakeRequest
    {
        public string ApplicationVersion { get; set; }
        public string Sha1 { get; set; }
        public string DocumentVersion { get; set; }
    }

    [MessagePackObject(true)]
    public class HandshakeResponse
    {
        public uint? Code { get; set; }
        public uint? UtcOpenTime { get; set; }
        public object? Sha1Table { get; set; }
    }

}
