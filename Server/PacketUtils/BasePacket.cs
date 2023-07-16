using System;
using MessagePack;

namespace MoonlightPGR.Server.PacketUtils
{
    [MessagePackObject(false)]
    public class BasePacket
    {
        [Key(0)]
        public int Seq;

        [Key(1)]
        public PacketContentType Type;

        [Key(2)]
        public byte[] Data;

        public enum PacketContentType
        {
            RequestPacket,
            ResponsePacket,
            PushPacket,
            Exception
        }
    }
}
