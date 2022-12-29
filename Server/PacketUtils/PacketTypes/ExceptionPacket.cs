using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.PacketTypes
{
    [MessagePackObject(false)]
    public class ExceptionPacket : IPacket
    {
        [Key(0)]
        public int Seq;

        [Key(1)]
        public int ErrorCode;

        [Key(2)]
        public string ErrorMessage;
    }
}
