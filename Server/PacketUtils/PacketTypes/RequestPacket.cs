using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.PacketTypes
{
    [MessagePackObject(false)]
    public class RequestPacket : IPacket
    {
        [Key(0)]
        public int Seq;

        [Key(1)]
        public string PacketName;

        [Key(2)]
        public byte[] Body;
    }
}
