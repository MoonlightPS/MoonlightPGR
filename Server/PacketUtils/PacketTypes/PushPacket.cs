using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.PacketTypes
{
    [MessagePackObject(false)]
    public class PushPacket : IPacket
    {
        [Key(0)]
        public string PacketName;

        [Key(1)]
        public byte[] Body;
    }
}
