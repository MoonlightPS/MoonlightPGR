using MessagePack;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;

namespace MoonlightPGR.Server.Handlers
{
    internal class GetWorldChannelInfoReq
    {
        [PacketHandler("GetWorldChannelInfoRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            session.Send("GetWorldChannelInfoResponse", MessagePackSerializer.ConvertFromJson("{\"Code\":0,\"ChannelInfos\":[{\"ChannelId\":0,\"PlayerNum\":0},{\"ChannelId\":1,\"PlayerNum\":0},{\"ChannelId\":2,\"PlayerNum\":0},{\"ChannelId\":3,\"PlayerNum\":0},{\"ChannelId\":4,\"PlayerNum\":0},{\"ChannelId\":5,\"PlayerNum\":0},{\"ChannelId\":6,\"PlayerNum\":0}]}"),packet.Seq);
            session.Send("NotifyItemDataList", MessagePackSerializer.ConvertFromJson("{\"ItemDataList\":[{\"Id\":4,\"Count\":383,\"BuyTimes\":0,\"TotalBuyTimes\":0,\"LastBuyTime\":0,\"RefreshTime\":1690814890,\"CreateTime\":1626538573}],\"ItemRecycleDict\":{}}"));
        }
    }
}
