using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.Interfaces
{

    [MessagePackObject(true)]
    public class IHandshakeRequest
    {
        [Key("ApplicationVersion")]
        public string ApplicationVersion { get; set; }

        [Key("Sha1")]
        public string Sha1 { get; set; }

        [Key("DocumentVersion")]
        public string DocumentVersion { get; set; }
    }

    [MessagePackObject(true)]
    public class HandshakeResponse
    {
        [Key("Code")]
        public uint? Code { get; set; }

        [Key("UtcOpenTime")]
        public uint? UtcOpenTime { get; set; }

        [Key("Sha1Table")]
        public object? Sha1Table { get; set; }
    }

}
