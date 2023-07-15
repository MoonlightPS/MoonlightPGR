using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.PacketTypes
{
    [MessagePackObject(false)]
    public class ResponsePacket : IPacket
    {
        [Key(0)]
        public uint Seq;

        [Key(1)]
        public string PacketName;

        [Key(2)]
        public byte[] Body;
    }
}