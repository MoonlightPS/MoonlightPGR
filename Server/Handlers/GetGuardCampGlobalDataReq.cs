using MessagePack;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server.Handlers
{
    internal class GetGuardCampGlobalDataReq
    {
        [PacketHandler("GetGuardCampGlobalDataRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            session.Send("GetGuardCampGlobalDataResponse", MessagePackSerializer.ConvertFromJson("{\"Code\":0,\"GlobalData\":{\"Id\":2,\"WinCampId\":0,\"PondCount\":130897400,\"CampDatas\":[{\"Id\":4,\"JoinNum\":143573,\"SupportNum\":63580},{\"Id\":3,\"JoinNum\":112348,\"SupportNum\":18842}]}}"), packet.Seq);
        }
    }
}
