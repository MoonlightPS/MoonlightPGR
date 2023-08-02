using MessagePack;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;
namespace MoonlightPGR.Server.Handlers
{
    internal class HandshakeReq
    {
        [PacketHandler("HandshakeRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            HandshakeRequest body = MessagePackSerializer.Deserialize<HandshakeRequest>(packet.Body);

            HandshakeResponse rsp = new()
            {
                Code = 0,
                UtcOpenTime = 0,
                Sha1Table = null
            };

            session.Send("HandshakeResponse", rsp, packet.Seq);

            /*byte[] data = Session.StringToByteArray("930001C4359301B148616E647368616B65526573706F6E7365C41F83A4436F646500AB5574634F70656E54696D6500A9536861315461626C65C0"); // FROM DUMP

            byte[] msg = new byte[4 + data.Length];
            BinaryWriter bw = new BinaryWriter(new MemoryStream(msg));

            bw.Write(new byte[] { 0x3A, 0x0, 0x0, 0x0 }); // Idk what this is
            PGRCrypto.Encrypt(data);
            bw.Write(data);

            bw.Flush();
            bw.Close();

            session.SendRaw(msg);*/
        }
    }
}
