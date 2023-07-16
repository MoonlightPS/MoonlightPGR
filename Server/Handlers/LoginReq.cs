using MessagePack;
using MoonlightPGR.Server.PacketUtils;
using MoonlightPGR.Server.PacketUtils.Interfaces;
using MoonlightPGR.Server.PacketUtils.PacketTypes;
using Newtonsoft.Json;

namespace MoonlightPGR.Server.Handlers
{
    internal class LoginReq
    {
        [PacketHandler("LoginRequest")]
        public static void Handle(Session session, RequestPacket packet)
        {
            LoginRequest body = MessagePackSerializer.Deserialize<LoginRequest>(packet.Body);

            LoginResponse rsp = new()
            {
                Code = 0,
                UtcOffset = 0,
                UtcServerTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                ReconnectToken = "00163efffe00a63d-00261210-00014d9c-0092c1e1275aa708-003a7fb7"
            };

            session.Send("LoginResponse", rsp, packet.Seq, new byte[] { 0x96, 0x0, 0x0, 0x0 });

            //session.SendRaw(Session.StringToByteArray("96000000ae0ea329884108fbf21682612dedee79c027be947b1f0d5ae59ea6025e297334d05b9f7afff9d0ff765f0a95a17bd50740cdc73b4b51bba4173b84b6a1796f97be47ea2fddb62b4f332395622747d20a0213c8667ddaeb297300033e53e4cd5c66436ad30ae4fc6230740c85419125931a9bc999570fe42145809db7488c9ad4ec2dc938c1593e6d99fc703effae2c089cda0f92146a"));

            NotifyDailyLotteryData lotteryData = new()
            {
                Lotteries = new List<object> { }
            };

            session.Send("NotifyDailyLotteryData", lotteryData, ++packet.Seq, new byte[] { 0x2B, 0x0, 0x0, 0x0 });

            NotifyPayInfo payInfo = new()
            {
                TotalPayMoney = 0.0,
                IsGetFirstPayReward = false
            };

            session.Send("NotifyPayInfo", payInfo, packet.Seq, new byte[] { 0x3F, 0x0, 0x0, 0x0 });

            NotifyEquipChipGroupList equipChipGroup = new()
            {
                ChipGroupDataList = new List<object> { }
            };

            session.Send("NotifyEquipChipGroupList", equipChipGroup, packet.Seq, new byte[] { 0x35, 0x0, 0x0, 0x0 });

            NotifyEquipChipAutoRecycleSite equipChipAutoRecycle = new()
            {
                ChipRecycleSite = new()
                {
                    RecycleStar = new List<uint>() { 1, 2, 3, 4 },
                    Days = 0,
                    SetRecycleTime =0
                }
            };

            session.Send("NotifyEquipChipAutoRecycleSite", equipChipAutoRecycle, packet.Seq, new byte[] { 0x60, 0x0, 0x0, 0x0 });

            NotifyArchiveLoginData archiveLoginData = JsonConvert.DeserializeObject<NotifyArchiveLoginData>(@"{
            ""Monsters"": [],
            ""Equips"": [
                {
                    ""Id"": 2022001,
                    ""Level"": 1,
                    ""Breakthrough"": 0,
                    ""ResonanceCount"": 0
                }
            ],
            ""MonsterUnlockIds"": [],
            ""WeaponUnlockIds"": [],
            ""AwarenessUnlockIds"": [],
            ""MonsterSettings"": [],
            ""WeaponSettings"": [],
            ""AwarenessSettings"": [],
            ""MonsterInfos"": [],
            ""MonsterSkills"": [],
            ""UnlockCgs"": [
                101001,
                101002,
                101003,
                101004,
                101005,
                104001,
                104002,
                104003,
                104004,
                104006,
                104007,
                104008,
                104009,
                104010,
                104011,
                104012,
                104013,
                105001,
                105002,
                105003,
                105004,
                105005,
                105006,
                105007,
                105008,
                105009,
                105010,
                109001,
                109002,
                110000,
                110001,
                110002,
                110003,
                110004,
                110005,
                110006,
                110007,
                110008,
                110009,
                110010,
                110011,
                110012,
                110013,
                110014,
                110015,
                110016,
                110017
            ],
            ""UnlockStoryDetails"": [],
            ""PartnerUnlockIds"": [],
            ""PartnerSettings"": [],
            ""UnlockPvDetails"": [],
            ""UnlockMails"": []
        }");

            session.Send("NotifyArchiveLoginData", archiveLoginData, packet.Seq, new byte[] { 0xC8, 0x01, 0x0, 0x0 });
        }
    }
}
