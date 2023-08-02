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

            session.Send("LoginResponse", rsp, packet.Seq);


            NotifyDailyLotteryData lotteryData = new()
            {
                Lotteries = new List<object> { }
            };

            session.Send("NotifyDailyLotteryData", lotteryData);

            NotifyPayInfo payInfo = new()
            {
                TotalPayMoney = 0.0,
                IsGetFirstPayReward = false
            };

            session.Send("NotifyPayInfo", payInfo);

            NotifyEquipChipGroupList equipChipGroup = new()
            {
                ChipGroupDataList = new List<object> { }
            };

            session.Send("NotifyEquipChipGroupList", equipChipGroup);

            NotifyEquipChipAutoRecycleSite equipChipAutoRecycle = new()
            {
                ChipRecycleSite = new()
                {
                    RecycleStar = new List<uint>() { 1, 2, 3, 4 },
                    Days = 0,
                    SetRecycleTime =0
                }
            };

            session.Send("NotifyEquipChipAutoRecycleSite", equipChipAutoRecycle);

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

            session.Send("NotifyArchiveLoginData", archiveLoginData);
        }
    }
}
