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

            NotifyLogin login = JsonConvert.DeserializeObject<NotifyLogin>(@"{
    ""PlayerData"": {
        ""Id"": 17462089,
        ""Name"": ""yarik0chka"",
        ""Level"": 50,
        ""Sign"": """",
        ""DisplayCharId"": 1021001,
        ""Birthday"": {
            ""Mon"": 4,
            ""Day"": 25
        },
        ""HonorLevel"": 1,
        ""ServerId"": ""5001"",
        ""Likes"": 13,
        ""CurrTeamId"": 1,
        ""ChallengeEventId"": 0,
        ""CurrHeadPortraitId"": 9000002,
        ""CurrHeadFrameId"": 0,
        ""CurrMedalId"": 0,
        ""AppearanceShowType"": 0,
        ""DailyReceiveGiftCount"": 0,
        ""DailyActivenessRewardStatus"": 0,
        ""WeeklyActivenessRewardStatus"": 0,
        ""Marks"": [
            5,
            10401,
            10305,
            1501,
            1400,
            1401,
            1402,
            1403,
            1404,
            1,
            102,
            503,
            505,
            204,
            401,
            10402,
            10406,
            1001,
            1002,
            1800,
            10404,
            10411,
            10410,
            10403,
            10409,
            10408,
            1601,
            10102,
            10407,
            105,
            801,
            802,
            602,
            109201,
            2001,
            1701,
            1301,
            109202,
            902,
            10204,
            10301,
            10302,
            109401,
            109501,
            109101,
            109301,
            10203,
            1201,
            109001,
            109402,
            109502,
            109102,
            109302,
            2100,
            2101,
            109002,
            109103,
            10304,
            10303,
            10306,
            4000,
            403,
            1901,
            1904,
            10413,
            1302,
            10308,
            10309,
            10313,
            10316,
            10317,
            10318,
            10319,
            10323,
            10324,
            10326,
            10327,
            1307,
            1308,
            10329,
            10330,
            10331,
            10338,
            10333,
            10334,
            10335,
            10336,
            10337,
            10339,
            10343,
            10342,
            10347,
            10348,
            2102,
            2200,
            10320,
            10321,
            1303,
            1305,
            1306,
            1309,
            10345,
            10346,
            6000,
            206,
            1003,
            10351,
            10352,
            10325,
            10353,
            10424,
            10420,
            10421,
            10423,
            10414,
            10415,
            10416,
            10417,
            10418,
            10419,
            10426,
            10428,
            10427
        ],
        ""GuideData"": [
            100001,
            100002,
            100003,
            50000,
            50101,
            50102,
            50103,
            50201,
            50202,
            50203,
            50301,
            50401,
            50501,
            50602,
            50603,
            50701,
            50800,
            50801,
            50803,
            50901,
            50931,
            200001,
            51001,
            51101,
            51201,
            51301,
            51401,
            51501,
            51701,
            51901,
            52001,
            52031,
            52101,
            52301,
            52401,
            52501,
            52601,
            52701,
            52931,
            51601,
            52801,
            52901,
            53005,
            52731,
            52602
        ],
        ""Communications"": [
            101,
            102,
            103,
            104,
            1,
            105,
            2,
            3,
            111,
            106,
            4,
            5,
            107,
            108,
            6,
            7,
            8,
            9,
            109,
            10,
            11,
            112,
            12,
            110,
            14,
            15,
            16,
            18,
            19,
            20,
            22,
            13,
            25
        ],
        ""ShowCharacters"": [
            1021001
        ],
        ""ShieldFuncList"": [],
        ""AppearanceSettingInfo"": {
            ""TitleType"": 1,
            ""CharacterType"": 1,
            ""FashionType"": 1,
            ""WeaponFashionType"": 1,
            ""DormitoryType"": 1,
            ""DormitoryId"": 21001
        },
        ""CreateTime"": 1626538573,
        ""LastLoginTime"": 1690814741,
        ""ReportTime"": 0,
        ""ChangeNameTime"": 1626547796,
        ""Flags"": 0
    },
    ""TimeLimitCtrlConfigList"": [
        {
            ""Id"": 23,
            ""StartTime"": 1556532000,
            ""EndTime"": 1632995940
        },
        {
            ""Id"": 26,
            ""StartTime"": 1674111600,
            ""EndTime"": 1916992740
        },
        {
            ""Id"": 27,
            ""StartTime"": 1668420000,
            ""EndTime"": 1669611600
        },
        {
            ""Id"": 24,
            ""StartTime"": 1565222400,
            ""EndTime"": 1889308800
        },
        {
            ""Id"": 25,
            ""StartTime"": 1612432800,
            ""EndTime"": 1889308800
        },
        {
            ""Id"": 73,
            ""StartTime"": 1604293200,
            ""EndTime"": 0
        },
        {
            ""Id"": 77,
            ""StartTime"": 1608613200,
            ""EndTime"": 1613970000
        },
        {
            ""Id"": 99,
            ""StartTime"": 1606366800,
            ""EndTime"": 0
        },
        {
            ""Id"": 123,
            ""StartTime"": 1610341200,
            ""EndTime"": 0
        },
        {
            ""Id"": 135,
            ""StartTime"": 1614574800,
            ""EndTime"": 0
        },
        {
            ""Id"": 136,
            ""StartTime"": 1614661200,
            ""EndTime"": 0
        },
        {
            ""Id"": 137,
            ""StartTime"": 1615784400,
            ""EndTime"": 0
        },
        {
            ""Id"": 138,
            ""StartTime"": 1617877800,
            ""EndTime"": 0
        },
        {
            ""Id"": 139,
            ""StartTime"": 1632997800,
            ""EndTime"": 0
        },
        {
            ""Id"": 140,
            ""StartTime"": 1637231400,
            ""EndTime"": 0
        },
        {
            ""Id"": 141,
            ""StartTime"": 1640860200,
            ""EndTime"": 0
        },
        {
            ""Id"": 201,
            ""StartTime"": 1628398800,
            ""EndTime"": 0
        },
        {
            ""Id"": 202,
            ""StartTime"": 1628398800,
            ""EndTime"": 0
        },
        {
            ""Id"": 203,
            ""StartTime"": 1628398800,
            ""EndTime"": 0
        },
        {
            ""Id"": 204,
            ""StartTime"": 1628398800,
            ""EndTime"": 0
        },
        {
            ""Id"": 205,
            ""StartTime"": 1628398800,
            ""EndTime"": 0
        },
        {
            ""Id"": 206,
            ""StartTime"": 1628398800,
            ""EndTime"": 0
        },
        {
            ""Id"": 301,
            ""StartTime"": 1636606800,
            ""EndTime"": 0
        },
        {
            ""Id"": 500,
            ""StartTime"": 1597017600,
            ""EndTime"": 1693180740
        },
        {
            ""Id"": 501,
            ""StartTime"": 1597017600,
            ""EndTime"": 1625443140
        },
        {
            ""Id"": 502,
            ""StartTime"": 1664150400,
            ""EndTime"": 1664755140
        },
        {
            ""Id"": 503,
            ""StartTime"": 1662940800,
            ""EndTime"": 1663545540
        },
        {
            ""Id"": 888,
            ""StartTime"": 1596258000,
            ""EndTime"": 1610971200
        },
        {
            ""Id"": 510,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 511,
            ""StartTime"": 1677636000,
            ""EndTime"": 1709258400
        },
        {
            ""Id"": 600,
            ""StartTime"": 1689231600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 700,
            ""StartTime"": 1636914600,
            ""EndTime"": 0
        },
        {
            ""Id"": 801,
            ""StartTime"": 1637231400,
            ""EndTime"": 0
        },
        {
            ""Id"": 802,
            ""StartTime"": 1637834400,
            ""EndTime"": 0
        },
        {
            ""Id"": 803,
            ""StartTime"": 1637231400,
            ""EndTime"": 0
        },
        {
            ""Id"": 804,
            ""StartTime"": 1637834400,
            ""EndTime"": 0
        },
        {
            ""Id"": 805,
            ""StartTime"": 1638439200,
            ""EndTime"": 0
        },
        {
            ""Id"": 10315,
            ""StartTime"": 1607076000,
            ""EndTime"": 1611550740
        },
        {
            ""Id"": 8001,
            ""StartTime"": 1646992800,
            ""EndTime"": 1649412000
        },
        {
            ""Id"": 8002,
            ""StartTime"": 1688626800,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8003,
            ""StartTime"": 1686902400,
            ""EndTime"": 1689148740
        },
        {
            ""Id"": 8004,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8005,
            ""StartTime"": 1676368800,
            ""EndTime"": 1678338000
        },
        {
            ""Id"": 8105,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8106,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8107,
            ""StartTime"": 1687417200,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8108,
            ""StartTime"": 1688022000,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8109,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8110,
            ""StartTime"": 1687417200,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8111,
            ""StartTime"": 1688022000,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8112,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8113,
            ""StartTime"": 1687417200,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8114,
            ""StartTime"": 1688022000,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8201,
            ""StartTime"": 1686794400,
            ""EndTime"": 1687589940
        },
        {
            ""Id"": 8202,
            ""StartTime"": 1687590000,
            ""EndTime"": 1688367540
        },
        {
            ""Id"": 8203,
            ""StartTime"": 1688367600,
            ""EndTime"": 1689145140
        },
        {
            ""Id"": 8204,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689145140
        },
        {
            ""Id"": 8301,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8401,
            ""StartTime"": 1686794400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8402,
            ""StartTime"": 1686794400,
            ""EndTime"": 0
        },
        {
            ""Id"": 8403,
            ""StartTime"": 0,
            ""EndTime"": 1689145140
        },
        {
            ""Id"": 8404,
            ""StartTime"": 1686794400,
            ""EndTime"": 1687244400
        },
        {
            ""Id"": 8405,
            ""StartTime"": 1687244400,
            ""EndTime"": 1687676400
        },
        {
            ""Id"": 8406,
            ""StartTime"": 1687676400,
            ""EndTime"": 1688108400
        },
        {
            ""Id"": 8407,
            ""StartTime"": 1688108400,
            ""EndTime"": 1688626800
        },
        {
            ""Id"": 8408,
            ""StartTime"": 1688626800,
            ""EndTime"": 1689145140
        },
        {
            ""Id"": 8409,
            ""StartTime"": 1686794400,
            ""EndTime"": 1688021940
        },
        {
            ""Id"": 8410,
            ""StartTime"": 1686794400,
            ""EndTime"": 1687417140
        },
        {
            ""Id"": 8501,
            ""StartTime"": 1687244400,
            ""EndTime"": 1688799540
        },
        {
            ""Id"": 8502,
            ""StartTime"": 1687417200,
            ""EndTime"": 1688799540
        },
        {
            ""Id"": 8503,
            ""StartTime"": 1687590000,
            ""EndTime"": 1688799540
        },
        {
            ""Id"": 8504,
            ""StartTime"": 1687762800,
            ""EndTime"": 1688799540
        },
        {
            ""Id"": 8505,
            ""StartTime"": 1687935600,
            ""EndTime"": 1688799540
        },
        {
            ""Id"": 8510,
            ""StartTime"": 1686812400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8511,
            ""StartTime"": 1686812400,
            ""EndTime"": 1687158000
        },
        {
            ""Id"": 8512,
            ""StartTime"": 1687158000,
            ""EndTime"": 1687762800
        },
        {
            ""Id"": 8513,
            ""StartTime"": 1687762800,
            ""EndTime"": 1688367600
        },
        {
            ""Id"": 8514,
            ""StartTime"": 1688367600,
            ""EndTime"": 1688972400
        },
        {
            ""Id"": 8515,
            ""StartTime"": 1688972400,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 8516,
            ""StartTime"": 1649653200,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8517,
            ""StartTime"": 1650258000,
            ""EndTime"": 1650517140
        },
        {
            ""Id"": 8601,
            ""StartTime"": 1686902400,
            ""EndTime"": 1689148740
        },
        {
            ""Id"": 8602,
            ""StartTime"": 1686902400,
            ""EndTime"": 1689148740
        },
        {
            ""Id"": 8603,
            ""StartTime"": 1676368800,
            ""EndTime"": 1678338000
        },
        {
            ""Id"": 8701,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8702,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8703,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8704,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8705,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8706,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 8707,
            ""StartTime"": 1646110800,
            ""EndTime"": 1650258000
        },
        {
            ""Id"": 9001,
            ""StartTime"": 1676368800,
            ""EndTime"": 1677232800
        },
        {
            ""Id"": 9002,
            ""StartTime"": 1692082740,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 9003,
            ""StartTime"": 1689321600,
            ""EndTime"": 1691740740
        },
        {
            ""Id"": 9004,
            ""StartTime"": 1689836400,
            ""EndTime"": 1691391540
        },
        {
            ""Id"": 9005,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 9006,
            ""StartTime"": 1689213600,
            ""EndTime"": 1689836340
        },
        {
            ""Id"": 9101,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692601140
        },
        {
            ""Id"": 9102,
            ""StartTime"": 1689213600,
            ""EndTime"": 1689710700
        },
        {
            ""Id"": 9103,
            ""StartTime"": 1689710700,
            ""EndTime"": 1689836400
        },
        {
            ""Id"": 9104,
            ""StartTime"": 1689836400,
            ""EndTime"": 1690315500
        },
        {
            ""Id"": 9105,
            ""StartTime"": 1690315500,
            ""EndTime"": 1690441200
        },
        {
            ""Id"": 9106,
            ""StartTime"": 1690441200,
            ""EndTime"": 1690661100
        },
        {
            ""Id"": 9118,
            ""StartTime"": 1690661100,
            ""EndTime"": 1690700400
        },
        {
            ""Id"": 9107,
            ""StartTime"": 1690700400,
            ""EndTime"": 1690920300
        },
        {
            ""Id"": 9108,
            ""StartTime"": 1690920300,
            ""EndTime"": 1691046000
        },
        {
            ""Id"": 9109,
            ""StartTime"": 1691046000,
            ""EndTime"": 1691525100
        },
        {
            ""Id"": 9110,
            ""StartTime"": 1691525100,
            ""EndTime"": 1691650800
        },
        {
            ""Id"": 9111,
            ""StartTime"": 1691650800,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9112,
            ""StartTime"": 1692129900,
            ""EndTime"": 1692601140
        },
        {
            ""Id"": 9113,
            ""StartTime"": 1689213600,
            ""EndTime"": 1689836400
        },
        {
            ""Id"": 9114,
            ""StartTime"": 1689836400,
            ""EndTime"": 1690441200
        },
        {
            ""Id"": 9115,
            ""StartTime"": 1690441200,
            ""EndTime"": 1691046000
        },
        {
            ""Id"": 9116,
            ""StartTime"": 1691046000,
            ""EndTime"": 1691650800
        },
        {
            ""Id"": 9117,
            ""StartTime"": 1691650800,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9120,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9150,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9151,
            ""StartTime"": 1689836400,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9152,
            ""StartTime"": 1690441200,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9153,
            ""StartTime"": 1691046000,
            ""EndTime"": 1692129900
        },
        {
            ""Id"": 9201,
            ""StartTime"": 1690441200,
            ""EndTime"": 1691996340
        },
        {
            ""Id"": 9202,
            ""StartTime"": 1691046000,
            ""EndTime"": 1691996340
        },
        {
            ""Id"": 9301,
            ""StartTime"": 1689213600,
            ""EndTime"": 1690786740
        },
        {
            ""Id"": 9401,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 9402,
            ""StartTime"": 1689213600,
            ""EndTime"": 0
        },
        {
            ""Id"": 9403,
            ""StartTime"": 0,
            ""EndTime"": 1692601140
        },
        {
            ""Id"": 9404,
            ""StartTime"": 1689213600,
            ""EndTime"": 1689836400
        },
        {
            ""Id"": 9405,
            ""StartTime"": 1689836400,
            ""EndTime"": 1690527600
        },
        {
            ""Id"": 9406,
            ""StartTime"": 1690527600,
            ""EndTime"": 1691218800
        },
        {
            ""Id"": 9407,
            ""StartTime"": 1691218800,
            ""EndTime"": 1691910000
        },
        {
            ""Id"": 9408,
            ""StartTime"": 1691910000,
            ""EndTime"": 1692601140
        },
        {
            ""Id"": 9501,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 9601,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 100004,
            ""StartTime"": 1651917600,
            ""EndTime"": 1654336740
        },
        {
            ""Id"": 9701,
            ""StartTime"": 1689213600,
            ""EndTime"": 1690441140
        },
        {
            ""Id"": 9702,
            ""StartTime"": 1651381200,
            ""EndTime"": 1651813200
        },
        {
            ""Id"": 9703,
            ""StartTime"": 1689321600,
            ""EndTime"": 1691740740
        },
        {
            ""Id"": 9704,
            ""StartTime"": 1689321600,
            ""EndTime"": 1691740740
        },
        {
            ""Id"": 9705,
            ""StartTime"": 1689321600,
            ""EndTime"": 1692604740
        },
        {
            ""Id"": 9706,
            ""StartTime"": 1689321600,
            ""EndTime"": 1691740740
        },
        {
            ""Id"": 9801,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692601140
        },
        {
            ""Id"": 9802,
            ""StartTime"": 1689213600,
            ""EndTime"": 1689836340
        },
        {
            ""Id"": 9901,
            ""StartTime"": 1689231600,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 9902,
            ""StartTime"": 1689231600,
            ""EndTime"": 1689577200
        },
        {
            ""Id"": 9903,
            ""StartTime"": 1689577200,
            ""EndTime"": 1690182000
        },
        {
            ""Id"": 9904,
            ""StartTime"": 1690182000,
            ""EndTime"": 1690786800
        },
        {
            ""Id"": 9905,
            ""StartTime"": 1690786800,
            ""EndTime"": 1691391600
        },
        {
            ""Id"": 9906,
            ""StartTime"": 1691391600,
            ""EndTime"": 1691996400
        },
        {
            ""Id"": 9907,
            ""StartTime"": 1691996400,
            ""EndTime"": 1692601200
        },
        {
            ""Id"": 9908,
            ""StartTime"": 1692601200,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 10102,
            ""StartTime"": 1692082740,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 100001,
            ""StartTime"": 1642240800,
            ""EndTime"": 1644659940
        },
        {
            ""Id"": 100002,
            ""StartTime"": 1645869600,
            ""EndTime"": 1647079140
        },
        {
            ""Id"": 100003,
            ""StartTime"": 1648288800,
            ""EndTime"": 1650707940
        },
        {
            ""Id"": 100005,
            ""StartTime"": 1655546400,
            ""EndTime"": 1657965540
        },
        {
            ""Id"": 100006,
            ""StartTime"": 1659175200,
            ""EndTime"": 1661594340
        },
        {
            ""Id"": 100007,
            ""StartTime"": 1662804000,
            ""EndTime"": 1665223140
        },
        {
            ""Id"": 100008,
            ""StartTime"": 1666432800,
            ""EndTime"": 1667642340
        },
        {
            ""Id"": 100009,
            ""StartTime"": 1668852000,
            ""EndTime"": 1671271140
        },
        {
            ""Id"": 100010,
            ""StartTime"": 1672480800,
            ""EndTime"": 1674899940
        },
        {
            ""Id"": 100011,
            ""StartTime"": 1676109600,
            ""EndTime"": 1677319140
        },
        {
            ""Id"": 1400007,
            ""StartTime"": 1651172400,
            ""EndTime"": 1651708740
        },
        {
            ""Id"": 1400008,
            ""StartTime"": 1651140000,
            ""EndTime"": 1651752000
        },
        {
            ""Id"": 1400009,
            ""StartTime"": 1651172400,
            ""EndTime"": 1652313540
        },
        {
            ""Id"": 1400010,
            ""StartTime"": 1637949600,
            ""EndTime"": 1638572340
        },
        {
            ""Id"": 1400011,
            ""StartTime"": 1637949600,
            ""EndTime"": 1640386740
        },
        {
            ""Id"": 1400012,
            ""StartTime"": 1651122000,
            ""EndTime"": 1655182740
        },
        {
            ""Id"": 1400001,
            ""StartTime"": 1637902800,
            ""EndTime"": 1641963600
        },
        {
            ""Id"": 1400002,
            ""StartTime"": 1638007200,
            ""EndTime"": 1642031940
        },
        {
            ""Id"": 1400003,
            ""StartTime"": 1637902800,
            ""EndTime"": 1641963600
        },
        {
            ""Id"": 1400004,
            ""StartTime"": 1645246800,
            ""EndTime"": 1647838800
        },
        {
            ""Id"": 1400005,
            ""StartTime"": 1649239200,
            ""EndTime"": 1651122000
        },
        {
            ""Id"": 1400006,
            ""StartTime"": 1649239200,
            ""EndTime"": 1651122000
        },
        {
            ""Id"": 1400013,
            ""StartTime"": 1657429200,
            ""EndTime"": 1658033940
        },
        {
            ""Id"": 1400014,
            ""StartTime"": 1671782400,
            ""EndTime"": 1674086340
        },
        {
            ""Id"": 1400015,
            ""StartTime"": 1662026400,
            ""EndTime"": 1665291540
        },
        {
            ""Id"": 1400016,
            ""StartTime"": 1658318400,
            ""EndTime"": 1658858400
        },
        {
            ""Id"": 1400017,
            ""StartTime"": 1664704800,
            ""EndTime"": 1665291540
        },
        {
            ""Id"": 1400018,
            ""StartTime"": 1666000800,
            ""EndTime"": 1668315600
        },
        {
            ""Id"": 1400019,
            ""StartTime"": 1670155200,
            ""EndTime"": 1671426000
        },
        {
            ""Id"": 1400020,
            ""StartTime"": 1669939200,
            ""EndTime"": 1670543940
        },
        {
            ""Id"": 1400021,
            ""StartTime"": 1669939200,
            ""EndTime"": 1671148740
        },
        {
            ""Id"": 1400022,
            ""StartTime"": 1683878400,
            ""EndTime"": 1686729540
        },
        {
            ""Id"": 2121000,
            ""StartTime"": 1672480800,
            ""EndTime"": 1674968400
        },
        {
            ""Id"": 2121001,
            ""StartTime"": 1672203600,
            ""EndTime"": 1675054800
        },
        {
            ""Id"": 2121002,
            ""StartTime"": 1672203600,
            ""EndTime"": 1674968400
        },
        {
            ""Id"": 2121003,
            ""StartTime"": 1672358400,
            ""EndTime"": 1693440000
        },
        {
            ""Id"": 2121004,
            ""StartTime"": 1674986400,
            ""EndTime"": 1678355940
        },
        {
            ""Id"": 2121005,
            ""StartTime"": 1674986400,
            ""EndTime"": 1678355940
        },
        {
            ""Id"": 7001,
            ""StartTime"": 1686207600,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7004,
            ""StartTime"": 1683878400,
            ""EndTime"": 1686297540
        },
        {
            ""Id"": 7005,
            ""StartTime"": 1683770400,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7009,
            ""StartTime"": 1683878400,
            ""EndTime"": 1686297540
        },
        {
            ""Id"": 7201,
            ""StartTime"": 1685170800,
            ""EndTime"": 1686725940
        },
        {
            ""Id"": 7301,
            ""StartTime"": 1684134000,
            ""EndTime"": 1685775540
        },
        {
            ""Id"": 7302,
            ""StartTime"": 1684134000,
            ""EndTime"": 1685689140
        },
        {
            ""Id"": 7303,
            ""StartTime"": 1684738800,
            ""EndTime"": 1685775540
        },
        {
            ""Id"": 7304,
            ""StartTime"": 1684738800,
            ""EndTime"": 1685689140
        },
        {
            ""Id"": 7401,
            ""StartTime"": 1683770400,
            ""EndTime"": 1685343540
        },
        {
            ""Id"": 7402,
            ""StartTime"": 1684029600,
            ""EndTime"": 1685343540
        },
        {
            ""Id"": 7403,
            ""StartTime"": 1684288800,
            ""EndTime"": 1685343540
        },
        {
            ""Id"": 7510,
            ""StartTime"": 1683874800,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7511,
            ""StartTime"": 1683874800,
            ""EndTime"": 1684134000
        },
        {
            ""Id"": 7512,
            ""StartTime"": 1684134000,
            ""EndTime"": 1684738800
        },
        {
            ""Id"": 7513,
            ""StartTime"": 1684738800,
            ""EndTime"": 1685343600
        },
        {
            ""Id"": 7514,
            ""StartTime"": 1685343600,
            ""EndTime"": 1685948400
        },
        {
            ""Id"": 7515,
            ""StartTime"": 1685948400,
            ""EndTime"": 1686553200
        },
        {
            ""Id"": 7516,
            ""StartTime"": 1686553200,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7520,
            ""StartTime"": 1683770400,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7521,
            ""StartTime"": 1683770400,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7522,
            ""StartTime"": 1684393200,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7523,
            ""StartTime"": 1684998000,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7524,
            ""StartTime"": 1685602800,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7525,
            ""StartTime"": 1686207600,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 7527,
            ""StartTime"": 1683921600,
            ""EndTime"": 1684699140
        },
        {
            ""Id"": 7528,
            ""StartTime"": 1684872000,
            ""EndTime"": 1685649540
        },
        {
            ""Id"": 7529,
            ""StartTime"": 1685822400,
            ""EndTime"": 1686599940
        },
        {
            ""Id"": 7602,
            ""StartTime"": 1683878400,
            ""EndTime"": 1686729540
        },
        {
            ""Id"": 7801,
            ""StartTime"": 1684479600,
            ""EndTime"": 1686034740
        },
        {
            ""Id"": 7802,
            ""StartTime"": 1684566000,
            ""EndTime"": 1686034740
        },
        {
            ""Id"": 7803,
            ""StartTime"": 1684652400,
            ""EndTime"": 1686034740
        },
        {
            ""Id"": 7804,
            ""StartTime"": 1684738800,
            ""EndTime"": 1686034740
        },
        {
            ""Id"": 7805,
            ""StartTime"": 1684825200,
            ""EndTime"": 1686034740
        },
        {
            ""Id"": 7806,
            ""StartTime"": 1684998000,
            ""EndTime"": 1686034740
        },
        {
            ""Id"": 7903,
            ""StartTime"": 1683770400,
            ""EndTime"": 1684997940
        },
        {
            ""Id"": 6005,
            ""StartTime"": 1680940800,
            ""EndTime"": 1683359940
        },
        {
            ""Id"": 6101,
            ""StartTime"": 1681110000,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6102,
            ""StartTime"": 1682406000,
            ""EndTime"": 1683701940
        },
        {
            ""Id"": 6201,
            ""StartTime"": 1680832800,
            ""EndTime"": 1683770340
        },
        {
            ""Id"": 6302,
            ""StartTime"": 1680832800,
            ""EndTime"": 0
        },
        {
            ""Id"": 6303,
            ""StartTime"": 0,
            ""EndTime"": 1683701940
        },
        {
            ""Id"": 6307,
            ""StartTime"": 1682406000,
            ""EndTime"": 1683010800
        },
        {
            ""Id"": 6308,
            ""StartTime"": 1683010800,
            ""EndTime"": 1683701940
        },
        {
            ""Id"": 6401,
            ""StartTime"": 1681974000,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6402,
            ""StartTime"": 1682060400,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6403,
            ""StartTime"": 1682233200,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6404,
            ""StartTime"": 1682406000,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6405,
            ""StartTime"": 1682578800,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6406,
            ""StartTime"": 1682751600,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6407,
            ""StartTime"": 1682924400,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6408,
            ""StartTime"": 1683097200,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6409,
            ""StartTime"": 1682146800,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6410,
            ""StartTime"": 1682406000,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6411,
            ""StartTime"": 1682665200,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6412,
            ""StartTime"": 1682924400,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6413,
            ""StartTime"": 1683183600,
            ""EndTime"": 1683529140
        },
        {
            ""Id"": 6510,
            ""StartTime"": 1680937200,
            ""EndTime"": 1683770340
        },
        {
            ""Id"": 6511,
            ""StartTime"": 1680937200,
            ""EndTime"": 1681110000
        },
        {
            ""Id"": 6512,
            ""StartTime"": 1681110000,
            ""EndTime"": 1681714800
        },
        {
            ""Id"": 6513,
            ""StartTime"": 1681714800,
            ""EndTime"": 1682319600
        },
        {
            ""Id"": 6514,
            ""StartTime"": 1682319600,
            ""EndTime"": 1682924400
        },
        {
            ""Id"": 6515,
            ""StartTime"": 1682924400,
            ""EndTime"": 1683529200
        },
        {
            ""Id"": 6516,
            ""StartTime"": 1683529200,
            ""EndTime"": 1683770340
        },
        {
            ""Id"": 6601,
            ""StartTime"": 1680832800,
            ""EndTime"": 1681455540
        },
        {
            ""Id"": 6602,
            ""StartTime"": 1680940800,
            ""EndTime"": 1683705540
        },
        {
            ""Id"": 6603,
            ""StartTime"": 1680832800,
            ""EndTime"": 1682060340
        },
        {
            ""Id"": 6606,
            ""StartTime"": 1680940800,
            ""EndTime"": 1683705540
        },
        {
            ""Id"": 6607,
            ""StartTime"": 1680940800,
            ""EndTime"": 1683359940
        },
        {
            ""Id"": 6608,
            ""StartTime"": 1681282800,
            ""EndTime"": 1683701940
        },
        {
            ""Id"": 6701,
            ""StartTime"": 1680832800,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6702,
            ""StartTime"": 1680832800,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6703,
            ""StartTime"": 1680919200,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6704,
            ""StartTime"": 1681005600,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6705,
            ""StartTime"": 1681092000,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6706,
            ""StartTime"": 1681264800,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6707,
            ""StartTime"": 1681351200,
            ""EndTime"": 1682405940
        },
        {
            ""Id"": 6801,
            ""StartTime"": 1683770400,
            ""EndTime"": 1684479540
        },
        {
            ""Id"": 4018,
            ""StartTime"": 1677636000,
            ""EndTime"": 1678863540
        },
        {
            ""Id"": 3601,
            ""StartTime"": 1675580400,
            ""EndTime"": 1676185140
        },
        {
            ""Id"": 3602,
            ""StartTime"": 1675666800,
            ""EndTime"": 1676185140
        },
        {
            ""Id"": 3603,
            ""StartTime"": 1675753200,
            ""EndTime"": 1676185140
        },
        {
            ""Id"": 3604,
            ""StartTime"": 1675839600,
            ""EndTime"": 1676185140
        },
        {
            ""Id"": 3605,
            ""StartTime"": 1675926000,
            ""EndTime"": 1676185140
        },
        {
            ""Id"": 4017,
            ""StartTime"": 1673870400,
            ""EndTime"": 1674716340
        },
        {
            ""Id"": 2017,
            ""StartTime"": 1671778800,
            ""EndTime"": 1672988340
        },
        {
            ""Id"": 10030,
            ""StartTime"": 1664089200,
            ""EndTime"": 1665817140
        },
        {
            ""Id"": 104,
            ""StartTime"": 1611550800,
            ""EndTime"": 1611982800
        },
        {
            ""Id"": 105,
            ""StartTime"": 1577836800,
            ""EndTime"": 1578355200
        },
        {
            ""Id"": 106,
            ""StartTime"": 1612155600,
            ""EndTime"": 1612587600
        },
        {
            ""Id"": 107,
            ""StartTime"": 1611982800,
            ""EndTime"": 1612155600
        },
        {
            ""Id"": 108,
            ""StartTime"": 1612760400,
            ""EndTime"": 1613192400
        },
        {
            ""Id"": 109,
            ""StartTime"": 1613192400,
            ""EndTime"": 1613365200
        },
        {
            ""Id"": 110,
            ""StartTime"": 1613365200,
            ""EndTime"": 1613797200
        },
        {
            ""Id"": 111,
            ""StartTime"": 1577836800,
            ""EndTime"": 1578355200
        },
        {
            ""Id"": 118,
            ""StartTime"": 1577836800,
            ""EndTime"": 1578355200
        },
        {
            ""Id"": 119,
            ""StartTime"": 1577836800,
            ""EndTime"": 1578355200
        },
        {
            ""Id"": 37,
            ""StartTime"": 1577854800,
            ""EndTime"": 1602738000
        },
        {
            ""Id"": 38,
            ""StartTime"": 1599195600,
            ""EndTime"": 1601614800
        },
        {
            ""Id"": 47,
            ""StartTime"": 1600923600,
            ""EndTime"": 1606366800
        },
        {
            ""Id"": 66,
            ""StartTime"": 1657868400,
            ""EndTime"": 1660546740
        },
        {
            ""Id"": 67,
            ""StartTime"": 1656986400,
            ""EndTime"": 1659423540
        },
        {
            ""Id"": 68,
            ""StartTime"": 1657609200,
            ""EndTime"": 1659423540
        },
        {
            ""Id"": 69,
            ""StartTime"": 1658214000,
            ""EndTime"": 1659423540
        },
        {
            ""Id"": 70,
            ""StartTime"": 1658818800,
            ""EndTime"": 1659423540
        },
        {
            ""Id"": 100,
            ""StartTime"": 1657782000,
            ""EndTime"": 1659596340
        },
        {
            ""Id"": 101,
            ""StartTime"": 1611205380,
            ""EndTime"": 1611828000
        },
        {
            ""Id"": 102,
            ""StartTime"": 1656986400,
            ""EndTime"": 1659423540
        },
        {
            ""Id"": 112,
            ""StartTime"": 1656986400,
            ""EndTime"": 1660546740
        },
        {
            ""Id"": 113,
            ""StartTime"": 1656986400,
            ""EndTime"": 0
        },
        {
            ""Id"": 114,
            ""StartTime"": 0,
            ""EndTime"": 1660546740
        },
        {
            ""Id"": 115,
            ""StartTime"": 1656986400,
            ""EndTime"": 1660615140
        },
        {
            ""Id"": 120,
            ""StartTime"": 1657782000,
            ""EndTime"": 1659596340
        },
        {
            ""Id"": 121,
            ""StartTime"": 1612432800,
            ""EndTime"": 1614247140
        },
        {
            ""Id"": 125,
            ""StartTime"": 1613019600,
            ""EndTime"": 1613624400
        },
        {
            ""Id"": 126,
            ""StartTime"": 1657094400,
            ""EndTime"": 1660546740
        },
        {
            ""Id"": 127,
            ""StartTime"": 1640926800,
            ""EndTime"": 1641531600
        },
        {
            ""Id"": 128,
            ""StartTime"": 1612432800,
            ""EndTime"": 1614247140
        },
        {
            ""Id"": 129,
            ""StartTime"": 1612432800,
            ""EndTime"": 1613642340
        },
        {
            ""Id"": 130,
            ""StartTime"": 1640667600,
            ""EndTime"": 1641877200
        },
        {
            ""Id"": 134,
            ""StartTime"": 1640667600,
            ""EndTime"": 1641877200
        },
        {
            ""Id"": 215,
            ""StartTime"": 1612432800,
            ""EndTime"": 1614160740
        },
        {
            ""Id"": 10,
            ""StartTime"": 1545649200,
            ""EndTime"": 1580792400
        },
        {
            ""Id"": 11,
            ""StartTime"": 0,
            ""EndTime"": 1580619600
        },
        {
            ""Id"": 12,
            ""StartTime"": 1577854800,
            ""EndTime"": 0
        },
        {
            ""Id"": 13,
            ""StartTime"": 1580792400,
            ""EndTime"": 1584334800
        },
        {
            ""Id"": 14,
            ""StartTime"": 0,
            ""EndTime"": 1583989200
        },
        {
            ""Id"": 15,
            ""StartTime"": 1580965200,
            ""EndTime"": 0
        },
        {
            ""Id"": 16,
            ""StartTime"": 1601528400,
            ""EndTime"": 1602392400
        },
        {
            ""Id"": 17,
            ""StartTime"": 0,
            ""EndTime"": 1602133200
        },
        {
            ""Id"": 18,
            ""StartTime"": 1594530000,
            ""EndTime"": 1602997200
        },
        {
            ""Id"": 19,
            ""StartTime"": 1596258000,
            ""EndTime"": 1602997200
        },
        {
            ""Id"": 20,
            ""StartTime"": 1581897540,
            ""EndTime"": 1594943940
        },
        {
            ""Id"": 21,
            ""StartTime"": 1596690000,
            ""EndTime"": 1598504400
        },
        {
            ""Id"": 22,
            ""StartTime"": 1595242800,
            ""EndTime"": 1597899600
        },
        {
            ""Id"": 28,
            ""StartTime"": 1592888400,
            ""EndTime"": 1598850000
        },
        {
            ""Id"": 29,
            ""StartTime"": 1596430800,
            ""EndTime"": 1603083600
        },
        {
            ""Id"": 30,
            ""StartTime"": 1596603600,
            ""EndTime"": 1602824400
        },
        {
            ""Id"": 31,
            ""StartTime"": 1596603600,
            ""EndTime"": 0
        },
        {
            ""Id"": 32,
            ""StartTime"": 0,
            ""EndTime"": 1602738000
        },
        {
            ""Id"": 33,
            ""StartTime"": 1597035600,
            ""EndTime"": 1598331600
        },
        {
            ""Id"": 34,
            ""StartTime"": 1597035600,
            ""EndTime"": 1598245200
        },
        {
            ""Id"": 35,
            ""StartTime"": 1650870000,
            ""EndTime"": 1652079540
        },
        {
            ""Id"": 36,
            ""StartTime"": 0,
            ""EndTime"": 1652079540
        },
        {
            ""Id"": 39,
            ""StartTime"": 1650870000,
            ""EndTime"": 1652079540
        },
        {
            ""Id"": 40,
            ""StartTime"": 1650870000,
            ""EndTime"": 1652079540
        },
        {
            ""Id"": 41,
            ""StartTime"": 1599454800,
            ""EndTime"": 1602133200
        },
        {
            ""Id"": 42,
            ""StartTime"": 0,
            ""EndTime"": 1602133200
        },
        {
            ""Id"": 43,
            ""StartTime"": 1601528400,
            ""EndTime"": 1602738000
        },
        {
            ""Id"": 49,
            ""StartTime"": 1649815200,
            ""EndTime"": 1651042740
        },
        {
            ""Id"": 50,
            ""StartTime"": 1650006000,
            ""EndTime"": 1650265200
        },
        {
            ""Id"": 51,
            ""StartTime"": 1650610800,
            ""EndTime"": 1650870000
        },
        {
            ""Id"": 52,
            ""StartTime"": 1651215600,
            ""EndTime"": 1651474800
        },
        {
            ""Id"": 53,
            ""StartTime"": 1651820400,
            ""EndTime"": 1652079600
        },
        {
            ""Id"": 54,
            ""StartTime"": 1652425200,
            ""EndTime"": 1652684400
        },
        {
            ""Id"": 55,
            ""StartTime"": 1649815200,
            ""EndTime"": 1652770740
        },
        {
            ""Id"": 56,
            ""StartTime"": 1649815200,
            ""EndTime"": 0
        },
        {
            ""Id"": 57,
            ""StartTime"": 0,
            ""EndTime"": 1652770740
        },
        {
            ""Id"": 58,
            ""StartTime"": 1649815200,
            ""EndTime"": 1652770740
        },
        {
            ""Id"": 59,
            ""StartTime"": 1650870000,
            ""EndTime"": 1652770740
        },
        {
            ""Id"": 60,
            ""StartTime"": 1652079600,
            ""EndTime"": 1652684340
        },
        {
            ""Id"": 61,
            ""StartTime"": 0,
            ""EndTime"": 1652684340
        },
        {
            ""Id"": 62,
            ""StartTime"": 1652252400,
            ""EndTime"": 1652839140
        },
        {
            ""Id"": 85,
            ""StartTime"": 1652839200,
            ""EndTime"": 1654066740
        },
        {
            ""Id"": 2150000,
            ""StartTime"": 1651215600,
            ""EndTime"": 1651993140
        },
        {
            ""Id"": 2160000,
            ""StartTime"": 1650092400,
            ""EndTime"": 1650697140
        },
        {
            ""Id"": 2160001,
            ""StartTime"": 1655708400,
            ""EndTime"": 1656917940
        },
        {
            ""Id"": 2160010,
            ""StartTime"": 1659423600,
            ""EndTime"": 1659941940
        },
        {
            ""Id"": 2160011,
            ""StartTime"": 1659942000,
            ""EndTime"": 1660546740
        },
        {
            ""Id"": 2160012,
            ""StartTime"": 1657868400,
            ""EndTime"": 1660546740
        },
        {
            ""Id"": 2160013,
            ""StartTime"": 1653264000,
            ""EndTime"": 1660118340
        },
        {
            ""Id"": 2160014,
            ""StartTime"": 1653264000,
            ""EndTime"": 1659423540
        },
        {
            ""Id"": 2160015,
            ""StartTime"": 1657868400,
            ""EndTime"": 1659077940
        },
        {
            ""Id"": 2160016,
            ""StartTime"": 1657872000,
            ""EndTime"": 1659686400
        },
        {
            ""Id"": 2160017,
            ""StartTime"": 1657868400,
            ""EndTime"": 1659077940
        },
        {
            ""Id"": 2160018,
            ""StartTime"": 1653264000,
            ""EndTime"": 1659686400
        },
        {
            ""Id"": 2160020,
            ""StartTime"": 1660719600,
            ""EndTime"": 1663138740
        },
        {
            ""Id"": 2160030,
            ""StartTime"": 1662706800,
            ""EndTime"": 1663225140
        },
        {
            ""Id"": 2160031,
            ""StartTime"": 1658966400,
            ""EndTime"": 1663225140
        },
        {
            ""Id"": 2160032,
            ""StartTime"": 1658966400,
            ""EndTime"": 1663142340
        },
        {
            ""Id"": 2160040,
            ""StartTime"": 1664348400,
            ""EndTime"": 1665557940
        },
        {
            ""Id"": 2160041,
            ""StartTime"": 1660608000,
            ""EndTime"": 1665989940
        },
        {
            ""Id"": 2160042,
            ""StartTime"": 1660608000,
            ""EndTime"": 1665993540
        },
        {
            ""Id"": 2160050,
            ""StartTime"": 1666767600,
            ""EndTime"": 1667977140
        },
        {
            ""Id"": 2160051,
            ""StartTime"": 1666166400,
            ""EndTime"": 1668581940
        },
        {
            ""Id"": 2160052,
            ""StartTime"": 1663718400,
            ""EndTime"": 1668581940
        },
        {
            ""Id"": 2160053,
            ""StartTime"": 1663718400,
            ""EndTime"": 1668585540
        },
        {
            ""Id"": 2160060,
            ""StartTime"": 1657850400,
            ""EndTime"": 2207037600
        },
        {
            ""Id"": 2160061,
            ""StartTime"": 1657850400,
            ""EndTime"": 2207037600
        },
        {
            ""Id"": 2160070,
            ""StartTime"": 1669186800,
            ""EndTime"": 1671605940
        },
        {
            ""Id"": 2160071,
            ""StartTime"": 1666080000,
            ""EndTime"": 1671674340
        },
        {
            ""Id"": 2160072,
            ""StartTime"": 1666080000,
            ""EndTime"": 1671177540
        },
        {
            ""Id"": 2160080,
            ""StartTime"": 1672815600,
            ""EndTime"": 1674025140
        },
        {
            ""Id"": 2160081,
            ""StartTime"": 1671782400,
            ""EndTime"": 1674093540
        },
        {
            ""Id"": 2160082,
            ""StartTime"": 1672556400,
            ""EndTime"": 1673161140
        },
        {
            ""Id"": 2160083,
            ""StartTime"": 1671674400,
            ""EndTime"": 1672901940
        },
        {
            ""Id"": 2160084,
            ""StartTime"": 1672470000,
            ""EndTime"": 1673074740
        },
        {
            ""Id"": 2160085,
            ""StartTime"": 1671951600,
            ""EndTime"": 1672901940
        },
        {
            ""Id"": 2160086,
            ""StartTime"": 1671674400,
            ""EndTime"": 1672901940
        },
        {
            ""Id"": 2160087,
            ""StartTime"": 1669190400,
            ""EndTime"": 1674093540
        },
        {
            ""Id"": 2160088,
            ""StartTime"": 1669190400,
            ""EndTime"": 1674086340
        },
        {
            ""Id"": 2160089,
            ""StartTime"": 1669190400,
            ""EndTime"": 1674086340
        },
        {
            ""Id"": 2160090,
            ""StartTime"": 1669190400,
            ""EndTime"": 1674086340
        },
        {
            ""Id"": 2160091,
            ""StartTime"": 1671782400,
            ""EndTime"": 1674086340
        },
        {
            ""Id"": 2160092,
            ""StartTime"": 1675234800,
            ""EndTime"": 1677653940
        },
        {
            ""Id"": 2160093,
            ""StartTime"": 1674201600,
            ""EndTime"": 1675411140
        },
        {
            ""Id"": 2160094,
            ""StartTime"": 1675580400,
            ""EndTime"": 1676444340
        },
        {
            ""Id"": 2160095,
            ""StartTime"": 1674284400,
            ""EndTime"": 1675493940
        },
        {
            ""Id"": 2160096,
            ""StartTime"": 1674284400,
            ""EndTime"": 1675493940
        },
        {
            ""Id"": 2160097,
            ""StartTime"": 1674284400,
            ""EndTime"": 1674889140
        },
        {
            ""Id"": 2160098,
            ""StartTime"": 1672214400,
            ""EndTime"": 1677635940
        },
        {
            ""Id"": 2160099,
            ""StartTime"": 1672214400,
            ""EndTime"": 1676620740
        },
        {
            ""Id"": 2160100,
            ""StartTime"": 1674201600,
            ""EndTime"": 1677571140
        },
        {
            ""Id"": 2160101,
            ""StartTime"": 1643353200,
            ""EndTime"": 1645340340
        },
        {
            ""Id"": 2160110,
            ""StartTime"": 1678863600,
            ""EndTime"": 1680073140
        },
        {
            ""Id"": 2160111,
            ""StartTime"": 1678604400,
            ""EndTime"": 1679209140
        },
        {
            ""Id"": 2160112,
            ""StartTime"": 1680332400,
            ""EndTime"": 1680832740
        },
        {
            ""Id"": 2160113,
            ""StartTime"": 1679641200,
            ""EndTime"": 1680245940
        },
        {
            ""Id"": 2160114,
            ""StartTime"": 1678608000,
            ""EndTime"": 1679817540
        },
        {
            ""Id"": 2160120,
            ""StartTime"": 1648105200,
            ""EndTime"": 1648709940
        },
        {
            ""Id"": 2160130,
            ""StartTime"": 1678780800,
            ""EndTime"": 1683770340
        },
        {
            ""Id"": 2160131,
            ""StartTime"": 1678780800,
            ""EndTime"": 1683359940
        },
        {
            ""Id"": 2160132,
            ""StartTime"": 1680937200,
            ""EndTime"": 1681541940
        },
        {
            ""Id"": 2160133,
            ""StartTime"": 1681282800,
            ""EndTime"": 1683701940
        },
        {
            ""Id"": 2160134,
            ""StartTime"": 1901865600,
            ""EndTime"": 1903679940
        },
        {
            ""Id"": 2160140,
            ""StartTime"": 1684911600,
            ""EndTime"": 1692169140
        },
        {
            ""Id"": 2160141,
            ""StartTime"": 1680508800,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 2160142,
            ""StartTime"": 1680508800,
            ""EndTime"": 1686297540
        },
        {
            ""Id"": 2160143,
            ""StartTime"": 1683878400,
            ""EndTime"": 1686729540
        },
        {
            ""Id"": 2160144,
            ""StartTime"": 1684911600,
            ""EndTime"": 1686794340
        },
        {
            ""Id"": 2160145,
            ""StartTime"": 1686902400,
            ""EndTime"": 1689148740
        },
        {
            ""Id"": 2160150,
            ""StartTime"": 1684483200,
            ""EndTime"": 1689213540
        },
        {
            ""Id"": 2160151,
            ""StartTime"": 1684483200,
            ""EndTime"": 1689148740
        },
        {
            ""Id"": 2160160,
            ""StartTime"": 1689408000,
            ""EndTime"": 1692604740
        },
        {
            ""Id"": 2160161,
            ""StartTime"": 1689404400,
            ""EndTime"": 1691218740
        },
        {
            ""Id"": 2160162,
            ""StartTime"": 1689408000,
            ""EndTime"": 1691827140
        },
        {
            ""Id"": 2160163,
            ""StartTime"": 1689404400,
            ""EndTime"": 1691218740
        },
        {
            ""Id"": 2160164,
            ""StartTime"": 1686816000,
            ""EndTime"": 1692669540
        },
        {
            ""Id"": 2160165,
            ""StartTime"": 1686816000,
            ""EndTime"": 1691740740
        },
        {
            ""Id"": 2160166,
            ""StartTime"": 1686816000,
            ""EndTime"": 1692601140
        },
        {
            ""Id"": 2160167,
            ""StartTime"": 1689213600,
            ""EndTime"": 1692169140
        }
    ],
    ""SharePlatformConfigList"": [
        {
            ""Id"": 0,
            ""SdkId"": [
                1,
                2,
                3,
                4,
                5
            ]
        },
        {
            ""Id"": 35,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 20,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 23,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 1,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 2,
            ""SdkId"": []
        },
        {
            ""Id"": 11,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 14,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 16,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 15,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 24,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 70,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 46,
            ""SdkId"": []
        },
        {
            ""Id"": 94,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 69,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 13,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 18,
            ""SdkId"": [
                1,
                2,
                3,
                4
            ]
        },
        {
            ""Id"": 136,
            ""SdkId"": [
                1,
                2
            ]
        },
        {
            ""Id"": 56,
            ""SdkId"": [
                1,
                2,
                3,
                4
            ]
        }
    ],
    ""ItemList"": [
        {
            ""Id"": 1,
            ""Count"": 118348,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626538573,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 2,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626538573,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 3,
            ""Count"": 720,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626538573,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 4,
            ""Count"": 383,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1690814890,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 12,
            ""Count"": 137,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626538573,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 17,
            ""Count"": 21,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1630083581,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 21,
            ""Count"": 99,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1630083581,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 22,
            ""Count"": 21,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1630083581,
            ""CreateTime"": 1626538573
        },
        {
            ""Id"": 7,
            ""Count"": 94,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626538911,
            ""CreateTime"": 1626538911
        },
        {
            ""Id"": 30011,
            ""Count"": 17,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626538911,
            ""CreateTime"": 1626538911
        },
        {
            ""Id"": 30012,
            ""Count"": 41,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626546271,
            ""CreateTime"": 1626546271
        },
        {
            ""Id"": 40110,
            ""Count"": 9,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626546271,
            ""CreateTime"": 1626546271
        },
        {
            ""Id"": 94008,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626546271,
            ""CreateTime"": 1626546271
        },
        {
            ""Id"": 13,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627670744,
            ""CreateTime"": 1626546271
        },
        {
            ""Id"": 50000,
            ""Count"": 100,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626546271,
            ""CreateTime"": 1626546271
        },
        {
            ""Id"": 20,
            ""Count"": 175,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626546855,
            ""CreateTime"": 1626546855
        },
        {
            ""Id"": 50005,
            ""Count"": 3250,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626549632,
            ""CreateTime"": 1626549632
        },
        {
            ""Id"": 90014,
            ""Count"": 3,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626549649,
            ""CreateTime"": 1626549649
        },
        {
            ""Id"": 502,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626633773,
            ""CreateTime"": 1626633773
        },
        {
            ""Id"": 40114,
            ""Count"": 19,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626633852,
            ""CreateTime"": 1626633852
        },
        {
            ""Id"": 30013,
            ""Count"": 4,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626634362,
            ""CreateTime"": 1626634362
        },
        {
            ""Id"": 508,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626634403,
            ""CreateTime"": 1626634403
        },
        {
            ""Id"": 94000,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626634834,
            ""CreateTime"": 1626634834
        },
        {
            ""Id"": 32,
            ""Count"": 10,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626635009,
            ""CreateTime"": 1626635009
        },
        {
            ""Id"": 40103,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626635931,
            ""CreateTime"": 1626635931
        },
        {
            ""Id"": 40104,
            ""Count"": 24,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626635931,
            ""CreateTime"": 1626635931
        },
        {
            ""Id"": 515,
            ""Count"": 2,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626636601,
            ""CreateTime"": 1626636601
        },
        {
            ""Id"": 28,
            ""Count"": 400,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626638540,
            ""CreateTime"": 1626638540
        },
        {
            ""Id"": 40100,
            ""Count"": 15,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626640516,
            ""CreateTime"": 1626640516
        },
        {
            ""Id"": 40113,
            ""Count"": 11,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626657248,
            ""CreateTime"": 1626657248
        },
        {
            ""Id"": 31,
            ""Count"": 1065,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626657841,
            ""CreateTime"": 1626657841
        },
        {
            ""Id"": 30,
            ""Count"": 7,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626657842,
            ""CreateTime"": 1626657842
        },
        {
            ""Id"": 503,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626698683,
            ""CreateTime"": 1626698683
        },
        {
            ""Id"": 507,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626701722,
            ""CreateTime"": 1626701722
        },
        {
            ""Id"": 505,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626788272,
            ""CreateTime"": 1626788272
        },
        {
            ""Id"": 504,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626791180,
            ""CreateTime"": 1626791180
        },
        {
            ""Id"": 90015,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626791180,
            ""CreateTime"": 1626791180
        },
        {
            ""Id"": 513,
            ""Count"": 4,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626791180,
            ""CreateTime"": 1626791180
        },
        {
            ""Id"": 24,
            ""Count"": 150,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626803618,
            ""CreateTime"": 1626803618
        },
        {
            ""Id"": 91000,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626804165,
            ""CreateTime"": 1626804165
        },
        {
            ""Id"": 50003,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626804274,
            ""CreateTime"": 1626804274
        },
        {
            ""Id"": 2041,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626805423,
            ""CreateTime"": 1626805423
        },
        {
            ""Id"": 36,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626805452,
            ""CreateTime"": 1626805452
        },
        {
            ""Id"": 40693,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626805458,
            ""CreateTime"": 1626805458
        },
        {
            ""Id"": 40691,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626805458,
            ""CreateTime"": 1626805458
        },
        {
            ""Id"": 40602,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626806688,
            ""CreateTime"": 1626806688
        },
        {
            ""Id"": 40681,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626806696,
            ""CreateTime"": 1626806696
        },
        {
            ""Id"": 23,
            ""Count"": 90,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626903618,
            ""CreateTime"": 1626903618
        },
        {
            ""Id"": 90001,
            ""Count"": 2,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626903637,
            ""CreateTime"": 1626903637
        },
        {
            ""Id"": 512,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626904061,
            ""CreateTime"": 1626904061
        },
        {
            ""Id"": 40604,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626905534,
            ""CreateTime"": 1626905534
        },
        {
            ""Id"": 40608,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626905540,
            ""CreateTime"": 1626905540
        },
        {
            ""Id"": 40682,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626905547,
            ""CreateTime"": 1626905547
        },
        {
            ""Id"": 50001,
            ""Count"": 80,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626973887,
            ""CreateTime"": 1626973887
        },
        {
            ""Id"": 501,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1626973918,
            ""CreateTime"": 1626973918
        },
        {
            ""Id"": 33,
            ""Count"": 20,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627031829,
            ""CreateTime"": 1627031829
        },
        {
            ""Id"": 30014,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627212375,
            ""CreateTime"": 1627212375
        },
        {
            ""Id"": 40607,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627327702,
            ""CreateTime"": 1627327702
        },
        {
            ""Id"": 40605,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627327702,
            ""CreateTime"": 1627327702
        },
        {
            ""Id"": 40692,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627381411,
            ""CreateTime"": 1627381411
        },
        {
            ""Id"": 40683,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627382264,
            ""CreateTime"": 1627382264
        },
        {
            ""Id"": 40603,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627555290,
            ""CreateTime"": 1627555290
        },
        {
            ""Id"": 40601,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627555290,
            ""CreateTime"": 1627555290
        },
        {
            ""Id"": 90030,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627986231,
            ""CreateTime"": 1627986231
        },
        {
            ""Id"": 200,
            ""Count"": 12,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1627986414,
            ""CreateTime"": 1627986414
        },
        {
            ""Id"": 60001,
            ""Count"": 5,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1628084896,
            ""CreateTime"": 1628084896
        },
        {
            ""Id"": 516,
            ""Count"": 2,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1628085315,
            ""CreateTime"": 1628085315
        },
        {
            ""Id"": 62012,
            ""Count"": 15,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672341328,
            ""CreateTime"": 1672341328
        },
        {
            ""Id"": 60,
            ""Count"": 100,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672413746,
            ""CreateTime"": 1672413746
        },
        {
            ""Id"": 31204,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672414006,
            ""CreateTime"": 1672414006
        },
        {
            ""Id"": 90032,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672414260,
            ""CreateTime"": 1672414260
        },
        {
            ""Id"": 91006,
            ""Count"": 1,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672414261,
            ""CreateTime"": 1672414261
        },
        {
            ""Id"": 90033,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672414262,
            ""CreateTime"": 1672414262
        },
        {
            ""Id"": 41,
            ""Count"": 5,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1672414264,
            ""CreateTime"": 1672414264
        },
        {
            ""Id"": 96003,
            ""Count"": 0,
            ""BuyTimes"": 0,
            ""TotalBuyTimes"": 0,
            ""LastBuyTime"": 0,
            ""RefreshTime"": 1689436670,
            ""CreateTime"": 1689436670
        }
    ],
    ""ItemRecycleDict"": {},
    ""CharacterList"": [
        {
            ""Id"": 1021001,
            ""Level"": 50,
            ""Exp"": 531,
            ""Quality"": 2,
            ""InitQuality"": 1,
            ""Star"": 4,
            ""Grade"": 8,
            ""SkillList"": [
                {
                    ""Id"": 102101,
                    ""Level"": 12
                },
                {
                    ""Id"": 102106,
                    ""Level"": 11
                },
                {
                    ""Id"": 102111,
                    ""Level"": 11
                },
                {
                    ""Id"": 102116,
                    ""Level"": 12
                },
                {
                    ""Id"": 102117,
                    ""Level"": 11
                },
                {
                    ""Id"": 102118,
                    ""Level"": 10
                },
                {
                    ""Id"": 102121,
                    ""Level"": 10
                },
                {
                    ""Id"": 102123,
                    ""Level"": 1
                },
                {
                    ""Id"": 102122,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6210101,
            ""CreateTime"": 1626538573,
            ""TrustLv"": 2,
            ""TrustExp"": 80,
            ""Ability"": 3387,
            ""LiberateLv"": 2,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1031003,
            ""Level"": 45,
            ""Exp"": 3020,
            ""Quality"": 3,
            ""InitQuality"": 3,
            ""Star"": 0,
            ""Grade"": 7,
            ""SkillList"": [
                {
                    ""Id"": 103301,
                    ""Level"": 1
                },
                {
                    ""Id"": 103306,
                    ""Level"": 1
                },
                {
                    ""Id"": 103311,
                    ""Level"": 1
                },
                {
                    ""Id"": 103316,
                    ""Level"": 1
                },
                {
                    ""Id"": 103317,
                    ""Level"": 2
                },
                {
                    ""Id"": 103318,
                    ""Level"": 9
                },
                {
                    ""Id"": 103321,
                    ""Level"": 8
                },
                {
                    ""Id"": 103323,
                    ""Level"": 9
                },
                {
                    ""Id"": 103322,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6310301,
            ""CreateTime"": 1626546293,
            ""TrustLv"": 1,
            ""TrustExp"": 0,
            ""Ability"": 1532,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1031001,
            ""Level"": 15,
            ""Exp"": 257,
            ""Quality"": 2,
            ""InitQuality"": 1,
            ""Star"": 6,
            ""Grade"": 3,
            ""SkillList"": [
                {
                    ""Id"": 103101,
                    ""Level"": 1
                },
                {
                    ""Id"": 103106,
                    ""Level"": 1
                },
                {
                    ""Id"": 103111,
                    ""Level"": 1
                },
                {
                    ""Id"": 103116,
                    ""Level"": 1
                },
                {
                    ""Id"": 103117,
                    ""Level"": 1
                },
                {
                    ""Id"": 103118,
                    ""Level"": 1
                },
                {
                    ""Id"": 103121,
                    ""Level"": 1
                },
                {
                    ""Id"": 103123,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6310101,
            ""CreateTime"": 1626546522,
            ""TrustLv"": 2,
            ""TrustExp"": 80,
            ""Ability"": 457,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1051001,
            ""Level"": 45,
            ""Exp"": 2530,
            ""Quality"": 2,
            ""InitQuality"": 1,
            ""Star"": 0,
            ""Grade"": 7,
            ""SkillList"": [
                {
                    ""Id"": 105101,
                    ""Level"": 10
                },
                {
                    ""Id"": 105106,
                    ""Level"": 1
                },
                {
                    ""Id"": 105111,
                    ""Level"": 1
                },
                {
                    ""Id"": 105116,
                    ""Level"": 10
                },
                {
                    ""Id"": 105117,
                    ""Level"": 5
                },
                {
                    ""Id"": 105118,
                    ""Level"": 1
                },
                {
                    ""Id"": 105121,
                    ""Level"": 9
                },
                {
                    ""Id"": 105123,
                    ""Level"": 1
                },
                {
                    ""Id"": 105122,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6510104,
            ""CreateTime"": 1626549519,
            ""TrustLv"": 2,
            ""TrustExp"": 140,
            ""Ability"": 1770,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1081002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Quality"": 3,
            ""InitQuality"": 2,
            ""Star"": 7,
            ""Grade"": 1,
            ""SkillList"": [
                {
                    ""Id"": 108201,
                    ""Level"": 1
                },
                {
                    ""Id"": 108206,
                    ""Level"": 1
                },
                {
                    ""Id"": 108211,
                    ""Level"": 1
                },
                {
                    ""Id"": 108216,
                    ""Level"": 1
                },
                {
                    ""Id"": 108217,
                    ""Level"": 1
                },
                {
                    ""Id"": 108218,
                    ""Level"": 1
                },
                {
                    ""Id"": 108221,
                    ""Level"": 1
                },
                {
                    ""Id"": 108223,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6810101,
            ""CreateTime"": 1626634362,
            ""TrustLv"": 2,
            ""TrustExp"": 0,
            ""Ability"": 371,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1021002,
            ""Level"": 40,
            ""Exp"": 600,
            ""Quality"": 2,
            ""InitQuality"": 2,
            ""Star"": 1,
            ""Grade"": 6,
            ""SkillList"": [
                {
                    ""Id"": 102201,
                    ""Level"": 1
                },
                {
                    ""Id"": 102206,
                    ""Level"": 1
                },
                {
                    ""Id"": 102211,
                    ""Level"": 1
                },
                {
                    ""Id"": 102216,
                    ""Level"": 1
                },
                {
                    ""Id"": 102217,
                    ""Level"": 1
                },
                {
                    ""Id"": 102218,
                    ""Level"": 1
                },
                {
                    ""Id"": 102221,
                    ""Level"": 1
                },
                {
                    ""Id"": 102223,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6210201,
            ""CreateTime"": 1626634407,
            ""TrustLv"": 1,
            ""TrustExp"": 0,
            ""Ability"": 775,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1041002,
            ""Level"": 45,
            ""Exp"": 1590,
            ""Quality"": 3,
            ""InitQuality"": 2,
            ""Star"": 6,
            ""Grade"": 7,
            ""SkillList"": [
                {
                    ""Id"": 104201,
                    ""Level"": 10
                },
                {
                    ""Id"": 104206,
                    ""Level"": 10
                },
                {
                    ""Id"": 104211,
                    ""Level"": 9
                },
                {
                    ""Id"": 104216,
                    ""Level"": 10
                },
                {
                    ""Id"": 104217,
                    ""Level"": 10
                },
                {
                    ""Id"": 104218,
                    ""Level"": 9
                },
                {
                    ""Id"": 104221,
                    ""Level"": 9
                },
                {
                    ""Id"": 104223,
                    ""Level"": 9
                },
                {
                    ""Id"": 104222,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6410101,
            ""CreateTime"": 1626638777,
            ""TrustLv"": 2,
            ""TrustExp"": 20,
            ""Ability"": 1496,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1051003,
            ""Level"": 46,
            ""Exp"": 780,
            ""Quality"": 4,
            ""InitQuality"": 3,
            ""Star"": 0,
            ""Grade"": 7,
            ""SkillList"": [
                {
                    ""Id"": 105301,
                    ""Level"": 1
                },
                {
                    ""Id"": 105306,
                    ""Level"": 1
                },
                {
                    ""Id"": 105311,
                    ""Level"": 1
                },
                {
                    ""Id"": 105316,
                    ""Level"": 11
                },
                {
                    ""Id"": 105317,
                    ""Level"": 1
                },
                {
                    ""Id"": 105318,
                    ""Level"": 1
                },
                {
                    ""Id"": 105321,
                    ""Level"": 1
                },
                {
                    ""Id"": 105323,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6510301,
            ""CreateTime"": 1626791180,
            ""TrustLv"": 1,
            ""TrustExp"": 0,
            ""Ability"": 1267,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1011002,
            ""Level"": 42,
            ""Exp"": 1601,
            ""Quality"": 2,
            ""InitQuality"": 2,
            ""Star"": 1,
            ""Grade"": 6,
            ""SkillList"": [
                {
                    ""Id"": 101201,
                    ""Level"": 10
                },
                {
                    ""Id"": 101206,
                    ""Level"": 9
                },
                {
                    ""Id"": 101211,
                    ""Level"": 9
                },
                {
                    ""Id"": 101216,
                    ""Level"": 10
                },
                {
                    ""Id"": 101217,
                    ""Level"": 9
                },
                {
                    ""Id"": 101218,
                    ""Level"": 8
                },
                {
                    ""Id"": 101221,
                    ""Level"": 9
                },
                {
                    ""Id"": 101223,
                    ""Level"": 1
                },
                {
                    ""Id"": 101222,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6110101,
            ""CreateTime"": 1626791180,
            ""TrustLv"": 2,
            ""TrustExp"": 20,
            ""Ability"": 1290,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        },
        {
            ""Id"": 1071002,
            ""Level"": 2,
            ""Exp"": 30,
            ""Quality"": 2,
            ""InitQuality"": 2,
            ""Star"": 2,
            ""Grade"": 2,
            ""SkillList"": [
                {
                    ""Id"": 107201,
                    ""Level"": 1
                },
                {
                    ""Id"": 107206,
                    ""Level"": 1
                },
                {
                    ""Id"": 107211,
                    ""Level"": 1
                },
                {
                    ""Id"": 107216,
                    ""Level"": 1
                },
                {
                    ""Id"": 107217,
                    ""Level"": 1
                },
                {
                    ""Id"": 107218,
                    ""Level"": 1
                },
                {
                    ""Id"": 107221,
                    ""Level"": 1
                },
                {
                    ""Id"": 107223,
                    ""Level"": 1
                }
            ],
            ""EnhanceSkillList"": [],
            ""FashionId"": 6710101,
            ""CreateTime"": 1627488155,
            ""TrustLv"": 2,
            ""TrustExp"": 0,
            ""Ability"": 320,
            ""LiberateLv"": 1,
            ""CharacterHeadInfo"": {
                ""HeadFashionId"": 0,
                ""HeadFashionType"": 0
            }
        }
    ],
    ""EquipList"": [
        {
            ""Id"": 13,
            ""TemplateId"": 3014005,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": true,
            ""CreateTime"": 1626546271,
            ""IsRecycle"": false
        },
        {
            ""Id"": 14,
            ""TemplateId"": 3044005,
            ""CharacterId"": 0,
            ""Level"": 16,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": true,
            ""CreateTime"": 1626546271,
            ""IsRecycle"": false
        },
        {
            ""Id"": 15,
            ""TemplateId"": 2033001,
            ""CharacterId"": 1031001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626546293,
            ""IsRecycle"": false
        },
        {
            ""Id"": 66,
            ""TemplateId"": 2035001,
            ""CharacterId"": 1031003,
            ""Level"": 30,
            ""Exp"": 240,
            ""Breakthrough"": 1,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626631761,
            ""IsRecycle"": false
        },
        {
            ""Id"": 70,
            ""TemplateId"": 3035002,
            ""CharacterId"": 1021001,
            ""Level"": 45,
            ""Exp"": 60,
            ""Breakthrough"": 4,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626632133,
            ""IsRecycle"": false
        },
        {
            ""Id"": 71,
            ""TemplateId"": 3065002,
            ""CharacterId"": 1021001,
            ""Level"": 40,
            ""Exp"": 220,
            ""Breakthrough"": 3,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626632133,
            ""IsRecycle"": false
        },
        {
            ""Id"": 78,
            ""TemplateId"": 2054001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 1,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626632365,
            ""IsRecycle"": false
        },
        {
            ""Id"": 88,
            ""TemplateId"": 3015003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626633773,
            ""IsRecycle"": false
        },
        {
            ""Id"": 100,
            ""TemplateId"": 2083001,
            ""CharacterId"": 1081002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626634362,
            ""IsRecycle"": false
        },
        {
            ""Id"": 103,
            ""TemplateId"": 2023001,
            ""CharacterId"": 1021002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626634407,
            ""IsRecycle"": false
        },
        {
            ""Id"": 112,
            ""TemplateId"": 2025001,
            ""CharacterId"": 1021001,
            ""Level"": 45,
            ""Exp"": 160,
            ""Breakthrough"": 4,
            ""ResonanceInfo"": [
                {
                    ""Slot"": 1,
                    ""Type"": 1,
                    ""CharacterId"": 0,
                    ""TemplateId"": 20
                }
            ],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626634841,
            ""IsRecycle"": false
        },
        {
            ""Id"": 141,
            ""TemplateId"": 3035004,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626635972,
            ""IsRecycle"": false
        },
        {
            ""Id"": 153,
            ""TemplateId"": 3025002,
            ""CharacterId"": 1021001,
            ""Level"": 45,
            ""Exp"": 10,
            ""Breakthrough"": 4,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626637516,
            ""IsRecycle"": false
        },
        {
            ""Id"": 154,
            ""TemplateId"": 3055002,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 3,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626637516,
            ""IsRecycle"": false
        },
        {
            ""Id"": 169,
            ""TemplateId"": 3035007,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626637998,
            ""IsRecycle"": false
        },
        {
            ""Id"": 181,
            ""TemplateId"": 3015001,
            ""CharacterId"": 1021001,
            ""Level"": 45,
            ""Exp"": 260,
            ""Breakthrough"": 4,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626638512,
            ""IsRecycle"": false
        },
        {
            ""Id"": 182,
            ""TemplateId"": 3045001,
            ""CharacterId"": 1021001,
            ""Level"": 45,
            ""Exp"": 10,
            ""Breakthrough"": 4,
            ""ResonanceInfo"": [
                {
                    ""Slot"": 1,
                    ""Type"": 1,
                    ""CharacterId"": 0,
                    ""TemplateId"": 27
                },
                {
                    ""Slot"": 2,
                    ""Type"": 1,
                    ""CharacterId"": 0,
                    ""TemplateId"": 26
                }
            ],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626638512,
            ""IsRecycle"": false
        },
        {
            ""Id"": 266,
            ""TemplateId"": 3065004,
            ""CharacterId"": 1051001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626643888,
            ""IsRecycle"": false
        },
        {
            ""Id"": 295,
            ""TemplateId"": 3025007,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626656616,
            ""IsRecycle"": false
        },
        {
            ""Id"": 296,
            ""TemplateId"": 3055007,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626656616,
            ""IsRecycle"": false
        },
        {
            ""Id"": 302,
            ""TemplateId"": 3016005,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626657556,
            ""IsRecycle"": false
        },
        {
            ""Id"": 308,
            ""TemplateId"": 3015004,
            ""CharacterId"": 1051001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 1,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626698816,
            ""IsRecycle"": false
        },
        {
            ""Id"": 345,
            ""TemplateId"": 3035005,
            ""CharacterId"": 1051001,
            ""Level"": 30,
            ""Exp"": 40,
            ""Breakthrough"": 1,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626700852,
            ""IsRecycle"": false
        },
        {
            ""Id"": 351,
            ""TemplateId"": 3035008,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626700941,
            ""IsRecycle"": false
        },
        {
            ""Id"": 392,
            ""TemplateId"": 3035001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626707249,
            ""IsRecycle"": false
        },
        {
            ""Id"": 422,
            ""TemplateId"": 3016008,
            ""CharacterId"": 0,
            ""Level"": 3,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626735122,
            ""IsRecycle"": false
        },
        {
            ""Id"": 427,
            ""TemplateId"": 3015007,
            ""CharacterId"": 1031003,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626735160,
            ""IsRecycle"": false
        },
        {
            ""Id"": 428,
            ""TemplateId"": 3045007,
            ""CharacterId"": 1031003,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626735160,
            ""IsRecycle"": false
        },
        {
            ""Id"": 496,
            ""TemplateId"": 3025004,
            ""CharacterId"": 1051001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 2,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626789827,
            ""IsRecycle"": false
        },
        {
            ""Id"": 497,
            ""TemplateId"": 3055004,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626789827,
            ""IsRecycle"": false
        },
        {
            ""Id"": 519,
            ""TemplateId"": 2053001,
            ""CharacterId"": 1051003,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626791180,
            ""IsRecycle"": false
        },
        {
            ""Id"": 520,
            ""TemplateId"": 2013001,
            ""CharacterId"": 1011002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626791180,
            ""IsRecycle"": false
        },
        {
            ""Id"": 521,
            ""TemplateId"": 3055002,
            ""CharacterId"": 1021001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 4,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626792402,
            ""IsRecycle"": false
        },
        {
            ""Id"": 541,
            ""TemplateId"": 3025003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626803698,
            ""IsRecycle"": false
        },
        {
            ""Id"": 542,
            ""TemplateId"": 3035003,
            ""CharacterId"": 1011002,
            ""Level"": 6,
            ""Exp"": 0,
            ""Breakthrough"": 2,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626803777,
            ""IsRecycle"": false
        },
        {
            ""Id"": 543,
            ""TemplateId"": 3045003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626803851,
            ""IsRecycle"": false
        },
        {
            ""Id"": 544,
            ""TemplateId"": 3055003,
            ""CharacterId"": 1011002,
            ""Level"": 9,
            ""Exp"": 30,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626803906,
            ""IsRecycle"": false
        },
        {
            ""Id"": 545,
            ""TemplateId"": 3065003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626804019,
            ""IsRecycle"": false
        },
        {
            ""Id"": 546,
            ""TemplateId"": 3045004,
            ""CharacterId"": 1051001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626804038,
            ""IsRecycle"": false
        },
        {
            ""Id"": 547,
            ""TemplateId"": 3015008,
            ""CharacterId"": 1011002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626804165,
            ""IsRecycle"": false
        },
        {
            ""Id"": 554,
            ""TemplateId"": 3045008,
            ""CharacterId"": 1011002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626804443,
            ""IsRecycle"": false
        },
        {
            ""Id"": 564,
            ""TemplateId"": 2044001,
            ""CharacterId"": 1041002,
            ""Level"": 25,
            ""Exp"": 160,
            ""Breakthrough"": 1,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626805194,
            ""IsRecycle"": false
        },
        {
            ""Id"": 583,
            ""TemplateId"": 3015003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626805979,
            ""IsRecycle"": false
        },
        {
            ""Id"": 601,
            ""TemplateId"": 3035008,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626903627,
            ""IsRecycle"": false
        },
        {
            ""Id"": 602,
            ""TemplateId"": 3025008,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626903670,
            ""IsRecycle"": false
        },
        {
            ""Id"": 604,
            ""TemplateId"": 2075001,
            ""CharacterId"": 1071002,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626903688,
            ""IsRecycle"": false
        },
        {
            ""Id"": 607,
            ""TemplateId"": 3065008,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626973837,
            ""IsRecycle"": false
        },
        {
            ""Id"": 621,
            ""TemplateId"": 3025005,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626974365,
            ""IsRecycle"": false
        },
        {
            ""Id"": 622,
            ""TemplateId"": 3055005,
            ""CharacterId"": 1051001,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 1,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1626974365,
            ""IsRecycle"": false
        },
        {
            ""Id"": 690,
            ""TemplateId"": 3055008,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627031495,
            ""IsRecycle"": false
        },
        {
            ""Id"": 710,
            ""TemplateId"": 3015002,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627175903,
            ""IsRecycle"": false
        },
        {
            ""Id"": 711,
            ""TemplateId"": 3045002,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627211995,
            ""IsRecycle"": false
        },
        {
            ""Id"": 768,
            ""TemplateId"": 3025006,
            ""CharacterId"": 1031003,
            ""Level"": 25,
            ""Exp"": 270,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627379949,
            ""IsRecycle"": false
        },
        {
            ""Id"": 785,
            ""TemplateId"": 2055001,
            ""CharacterId"": 1051001,
            ""Level"": 40,
            ""Exp"": 220,
            ""Breakthrough"": 3,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627381750,
            ""IsRecycle"": false
        },
        {
            ""Id"": 786,
            ""TemplateId"": 3035006,
            ""CharacterId"": 1031003,
            ""Level"": 25,
            ""Exp"": 20,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627381866,
            ""IsRecycle"": false
        },
        {
            ""Id"": 787,
            ""TemplateId"": 3065006,
            ""CharacterId"": 1031003,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627381927,
            ""IsRecycle"": false
        },
        {
            ""Id"": 802,
            ""TemplateId"": 3025003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627415942,
            ""IsRecycle"": false
        },
        {
            ""Id"": 803,
            ""TemplateId"": 3016004,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627415945,
            ""IsRecycle"": false
        },
        {
            ""Id"": 804,
            ""TemplateId"": 3055003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627416051,
            ""IsRecycle"": false
        },
        {
            ""Id"": 807,
            ""TemplateId"": 3055006,
            ""CharacterId"": 1031003,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627482367,
            ""IsRecycle"": false
        },
        {
            ""Id"": 839,
            ""TemplateId"": 3026007,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627486966,
            ""IsRecycle"": false
        },
        {
            ""Id"": 861,
            ""TemplateId"": 3035003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627487283,
            ""IsRecycle"": false
        },
        {
            ""Id"": 862,
            ""TemplateId"": 3065003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627487283,
            ""IsRecycle"": false
        },
        {
            ""Id"": 917,
            ""TemplateId"": 3035007,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627490127,
            ""IsRecycle"": false
        },
        {
            ""Id"": 966,
            ""TemplateId"": 3045001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627673302,
            ""IsRecycle"": false
        },
        {
            ""Id"": 967,
            ""TemplateId"": 3066003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1627673302,
            ""IsRecycle"": false
        },
        {
            ""Id"": 990,
            ""TemplateId"": 2993001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628085287,
            ""IsRecycle"": false
        },
        {
            ""Id"": 994,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548850,
            ""IsRecycle"": false
        },
        {
            ""Id"": 995,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548850,
            ""IsRecycle"": false
        },
        {
            ""Id"": 996,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548850,
            ""IsRecycle"": false
        },
        {
            ""Id"": 997,
            ""TemplateId"": 3014003,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548872,
            ""IsRecycle"": false
        },
        {
            ""Id"": 998,
            ""TemplateId"": 2994001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548892,
            ""IsRecycle"": false
        },
        {
            ""Id"": 999,
            ""TemplateId"": 3944001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548892,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1000,
            ""TemplateId"": 3015005,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548934,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1001,
            ""TemplateId"": 3045005,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548934,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1002,
            ""TemplateId"": 3034002,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548935,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1003,
            ""TemplateId"": 3064002,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1628548936,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1004,
            ""TemplateId"": 2994001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1630083588,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1005,
            ""TemplateId"": 2994001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1630083704,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1006,
            ""TemplateId"": 3944001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1630083704,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1007,
            ""TemplateId"": 3034001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1630083876,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1008,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1630083901,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1009,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1630083901,
            ""IsRecycle"": false
        },
        {
            ""Id"": 1010,
            ""TemplateId"": 3034002,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1672414193,
            ""IsRecycle"": true
        },
        {
            ""Id"": 1011,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1672414222,
            ""IsRecycle"": true
        },
        {
            ""Id"": 1012,
            ""TemplateId"": 3914001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1672414222,
            ""IsRecycle"": true
        },
        {
            ""Id"": 1013,
            ""TemplateId"": 2994001,
            ""CharacterId"": 0,
            ""Level"": 1,
            ""Exp"": 0,
            ""Breakthrough"": 0,
            ""ResonanceInfo"": [],
            ""UnconfirmedResonanceInfo"": [],
            ""AwakeSlotList"": [],
            ""IsLock"": false,
            ""CreateTime"": 1672414264,
            ""IsRecycle"": false
        }
    ],
    ""FashionList"": [
        {
            ""Id"": 6210101,
            ""IsLock"": false
        },
        {
            ""Id"": 6210104,
            ""IsLock"": false
        },
        {
            ""Id"": 6310301,
            ""IsLock"": false
        },
        {
            ""Id"": 6310101,
            ""IsLock"": false
        },
        {
            ""Id"": 6510101,
            ""IsLock"": false
        },
        {
            ""Id"": 6810101,
            ""IsLock"": false
        },
        {
            ""Id"": 6210201,
            ""IsLock"": false
        },
        {
            ""Id"": 6210106,
            ""IsLock"": false
        },
        {
            ""Id"": 6410101,
            ""IsLock"": false
        },
        {
            ""Id"": 6510301,
            ""IsLock"": false
        },
        {
            ""Id"": 6110101,
            ""IsLock"": false
        },
        {
            ""Id"": 6710101,
            ""IsLock"": false
        },
        {
            ""Id"": 6510104,
            ""IsLock"": false
        },
        {
            ""Id"": 6410105,
            ""IsLock"": true
        },
        {
            ""Id"": 6210102,
            ""IsLock"": true
        }
    ],
    ""HeadPortraitList"": [
        {
            ""Id"": 9000001,
            ""LeftCount"": 1,
            ""BeginTime"": 1672341323
        },
        {
            ""Id"": 9000002,
            ""LeftCount"": 1,
            ""BeginTime"": 1672341323
        },
        {
            ""Id"": 9000003,
            ""LeftCount"": 1,
            ""BeginTime"": 1672341323
        },
        {
            ""Id"": 9090001,
            ""LeftCount"": 1,
            ""BeginTime"": 1672341323
        }
    ],
    ""BaseEquipLoginData"": {
        ""BaseEquipList"": [],
        ""DressedList"": []
    },
    ""FubenData"": {
        ""StageData"": {
            ""10010101"": {
                ""StageId"": 10010101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626538846,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626538911,
                ""BestRecordTime"": 46,
                ""LastRecordTime"": 46,
                ""BestCardIds"": [
                    1021001,
                    0,
                    0
                ],
                ""LastCardIds"": [
                    1021001,
                    0,
                    0
                ]
            },
            ""10010102"": {
                ""StageId"": 10010102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626546318,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626546366,
                ""BestRecordTime"": 28,
                ""LastRecordTime"": 28,
                ""BestCardIds"": [
                    1021001,
                    0,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    0,
                    1031003
                ]
            },
            ""10010103"": {
                ""StageId"": 10010103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626792876,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626546500,
                ""BestRecordTime"": 32,
                ""LastRecordTime"": 32,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10010104"": {
                ""StageId"": 10010104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626546543,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626546618,
                ""BestRecordTime"": 62,
                ""LastRecordTime"": 62,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010201"": {
                ""StageId"": 10010201,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626546675,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626546747,
                ""BestRecordTime"": 53,
                ""LastRecordTime"": 53,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010202"": {
                ""StageId"": 10010202,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626546769,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626546834,
                ""BestRecordTime"": 48,
                ""LastRecordTime"": 48,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010203"": {
                ""StageId"": 10010203,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626546917,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626546990,
                ""BestRecordTime"": 60,
                ""LastRecordTime"": 60,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10010204"": {
                ""StageId"": 10010204,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626547239,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626547310,
                ""BestRecordTime"": 51,
                ""LastRecordTime"": 51,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010301"": {
                ""StageId"": 10010301,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626547412,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626547479,
                ""BestRecordTime"": 50,
                ""LastRecordTime"": 50,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010302"": {
                ""StageId"": 10010302,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626547600,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626547698,
                ""BestRecordTime"": 61,
                ""LastRecordTime"": 61,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010303"": {
                ""StageId"": 10010303,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626547900,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626547970,
                ""BestRecordTime"": 51,
                ""LastRecordTime"": 51,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10010304"": {
                ""StageId"": 10010304,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626549387,
                ""RefreshTime"": 1626631757,
                ""CreateTime"": 1626549465,
                ""BestRecordTime"": 43,
                ""LastRecordTime"": 43,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1031003
                ]
            },
            ""10020101"": {
                ""StageId"": 10020101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626631933,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626632014,
                ""BestRecordTime"": 61,
                ""LastRecordTime"": 61,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1051001
                ]
            },
            ""10020102"": {
                ""StageId"": 10020102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626632171,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626632244,
                ""BestRecordTime"": 55,
                ""LastRecordTime"": 55,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1051001
                ]
            },
            ""30010301"": {
                ""StageId"": 30010301,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626632273,
                ""RefreshTime"": 1626632273,
                ""CreateTime"": 1626632336,
                ""BestRecordTime"": 50,
                ""LastRecordTime"": 50,
                ""BestCardIds"": [
                    1021001,
                    1031001,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031001,
                    1051001
                ]
            },
            ""10020103"": {
                ""StageId"": 10020103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 3,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626643727,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626632561,
                ""BestRecordTime"": 48,
                ""LastRecordTime"": 48,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020104"": {
                ""StageId"": 10020104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627487796,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1626633682,
                ""BestRecordTime"": 30,
                ""LastRecordTime"": 30,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020201"": {
                ""StageId"": 10020201,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626633887,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626634010,
                ""BestRecordTime"": 93,
                ""LastRecordTime"": 93,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30050201"": {
                ""StageId"": 30050201,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626634040,
                ""RefreshTime"": 1626634040,
                ""CreateTime"": 1626634080,
                ""BestRecordTime"": 26,
                ""LastRecordTime"": 26,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020202"": {
                ""StageId"": 10020202,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626643276,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626634579,
                ""BestRecordTime"": 48,
                ""LastRecordTime"": 48,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30050101"": {
                ""StageId"": 30050101,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626634601,
                ""RefreshTime"": 1626634601,
                ""CreateTime"": 1626634641,
                ""BestRecordTime"": 25,
                ""LastRecordTime"": 25,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020203"": {
                ""StageId"": 10020203,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626635261,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626635411,
                ""BestRecordTime"": 117,
                ""LastRecordTime"": 117,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020204"": {
                ""StageId"": 10020204,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626635467,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626635570,
                ""BestRecordTime"": 70,
                ""LastRecordTime"": 70,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010701"": {
                ""StageId"": 30010701,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 4,
                ""PassTimesTotal"": 4,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626700678,
                ""RefreshTime"": 1626700678,
                ""CreateTime"": 1626635643,
                ""BestRecordTime"": 16,
                ""LastRecordTime"": 19,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020301"": {
                ""StageId"": 10020301,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626635763,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626635863,
                ""BestRecordTime"": 73,
                ""LastRecordTime"": 73,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010801"": {
                ""StageId"": 30010801,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 9,
                ""PassTimesTotal"": 9,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626637439,
                ""RefreshTime"": 1626637439,
                ""CreateTime"": 1626635931,
                ""BestRecordTime"": 18,
                ""LastRecordTime"": 28,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020302"": {
                ""StageId"": 10020302,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626635984,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626636062,
                ""BestRecordTime"": 54,
                ""LastRecordTime"": 54,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020303"": {
                ""StageId"": 10020303,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626636094,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626636169,
                ""BestRecordTime"": 53,
                ""LastRecordTime"": 53,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10020304"": {
                ""StageId"": 10020304,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626636221,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626636284,
                ""BestRecordTime"": 35,
                ""LastRecordTime"": 35,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11010101"": {
                ""StageId"": 11010101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626636410,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626636576,
                ""BestRecordTime"": 142,
                ""LastRecordTime"": 142,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11010102"": {
                ""StageId"": 11010102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626636774,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626636836,
                ""BestRecordTime"": 42,
                ""LastRecordTime"": 42,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11010103"": {
                ""StageId"": 11010103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626637552,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626637674,
                ""BestRecordTime"": 100,
                ""LastRecordTime"": 100,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11010104"": {
                ""StageId"": 11010104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626637698,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626637770,
                ""BestRecordTime"": 58,
                ""LastRecordTime"": 58,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11010105"": {
                ""StageId"": 11010105,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626637783,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626637927,
                ""BestRecordTime"": 122,
                ""LastRecordTime"": 122,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010401"": {
                ""StageId"": 30010401,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 10,
                ""PassTimesTotal"": 10,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626707316,
                ""RefreshTime"": 1626707316,
                ""CreateTime"": 1626637998,
                ""BestRecordTime"": 15,
                ""LastRecordTime"": 25,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11010106"": {
                ""StageId"": 11010106,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626638049,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626638119,
                ""BestRecordTime"": 51,
                ""LastRecordTime"": 51,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10030101"": {
                ""StageId"": 10030101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626638562,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626638740,
                ""BestRecordTime"": 153,
                ""LastRecordTime"": 153,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10030102"": {
                ""StageId"": 10030102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626639398,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626639504,
                ""BestRecordTime"": 82,
                ""LastRecordTime"": 82,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030103"": {
                ""StageId"": 10030103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626640561,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626640654,
                ""BestRecordTime"": 66,
                ""LastRecordTime"": 66,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030104"": {
                ""StageId"": 10030104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626640704,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626640851,
                ""BestRecordTime"": 118,
                ""LastRecordTime"": 118,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030201"": {
                ""StageId"": 10030201,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626640869,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626641012,
                ""BestRecordTime"": 121,
                ""LastRecordTime"": 121,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030202"": {
                ""StageId"": 10030202,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626641070,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626641165,
                ""BestRecordTime"": 74,
                ""LastRecordTime"": 74,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010802"": {
                ""StageId"": 30010802,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 3,
                ""PassTimesTotal"": 3,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626641447,
                ""RefreshTime"": 1626641447,
                ""CreateTime"": 1626641320,
                ""BestRecordTime"": 40,
                ""LastRecordTime"": 40,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030203"": {
                ""StageId"": 10030203,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626643526,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626641817,
                ""BestRecordTime"": 62,
                ""LastRecordTime"": 62,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030204"": {
                ""StageId"": 10030204,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626641856,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626641985,
                ""BestRecordTime"": 104,
                ""LastRecordTime"": 104,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""13010111"": {
                ""StageId"": 13010111,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626642010,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010112"": {
                ""StageId"": 13010112,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626642014,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010113"": {
                ""StageId"": 13010113,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626642019,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010114"": {
                ""StageId"": 13010114,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626642022,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010115"": {
                ""StageId"": 13010115,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626642026,
                ""RefreshTime"": 1626642026,
                ""CreateTime"": 1626642082,
                ""BestRecordTime"": 34,
                ""LastRecordTime"": 34,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010116"": {
                ""StageId"": 13010116,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626642097,
                ""RefreshTime"": 1626642097,
                ""CreateTime"": 1626642132,
                ""BestRecordTime"": 20,
                ""LastRecordTime"": 20,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10030301"": {
                ""StageId"": 10030301,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626642204,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626642308,
                ""BestRecordTime"": 84,
                ""LastRecordTime"": 84,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10030302"": {
                ""StageId"": 10030302,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626642429,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626642560,
                ""BestRecordTime"": 94,
                ""LastRecordTime"": 94,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030303"": {
                ""StageId"": 10030303,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626642870,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626642931,
                ""BestRecordTime"": 36,
                ""LastRecordTime"": 36,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10030304"": {
                ""StageId"": 10030304,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627489495,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1626643007,
                ""BestRecordTime"": 33,
                ""LastRecordTime"": 37,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ]
            },
            ""11020101"": {
                ""StageId"": 11020101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626643106,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626643229,
                ""BestRecordTime"": 94,
                ""LastRecordTime"": 94,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30060802"": {
                ""StageId"": 30060802,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 2,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627487851,
                ""RefreshTime"": 1627487851,
                ""CreateTime"": 1626643399,
                ""BestRecordTime"": 27,
                ""LastRecordTime"": 55,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30060503"": {
                ""StageId"": 30060503,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626643625,
                ""RefreshTime"": 1626643625,
                ""CreateTime"": 1626643689,
                ""BestRecordTime"": 50,
                ""LastRecordTime"": 50,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30061301"": {
                ""StageId"": 30061301,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626643805,
                ""RefreshTime"": 1626643805,
                ""CreateTime"": 1626643854,
                ""BestRecordTime"": 33,
                ""LastRecordTime"": 33,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11020102"": {
                ""StageId"": 11020102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626656076,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626656149,
                ""BestRecordTime"": 55,
                ""LastRecordTime"": 55,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11020103"": {
                ""StageId"": 11020103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626656162,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626656252,
                ""BestRecordTime"": 71,
                ""LastRecordTime"": 71,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11020104"": {
                ""StageId"": 11020104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626656311,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626656395,
                ""BestRecordTime"": 74,
                ""LastRecordTime"": 74,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11020105"": {
                ""StageId"": 11020105,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626656405,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626656460,
                ""BestRecordTime"": 47,
                ""LastRecordTime"": 47,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11020106"": {
                ""StageId"": 11020106,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626656470,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626656557,
                ""BestRecordTime"": 66,
                ""LastRecordTime"": 66,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040101"": {
                ""StageId"": 10040101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626656871,
                ""RefreshTime"": 1626698679,
                ""CreateTime"": 1626656976,
                ""BestRecordTime"": 85,
                ""LastRecordTime"": 85,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010803"": {
                ""StageId"": 30010803,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 47,
                ""PassTimesTotal"": 47,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627672278,
                ""RefreshTime"": 1627672278,
                ""CreateTime"": 1626657248,
                ""BestRecordTime"": 17,
                ""LastRecordTime"": 33,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ],
                ""LastCardIds"": [
                    1051001,
                    1031003,
                    1041002
                ]
            },
            ""10040102"": {
                ""StageId"": 10040102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627489581,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1626657780,
                ""BestRecordTime"": 72,
                ""LastRecordTime"": 72,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ]
            },
            ""10040103"": {
                ""StageId"": 10040103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626699302,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626699420,
                ""BestRecordTime"": 82,
                ""LastRecordTime"": 82,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040104"": {
                ""StageId"": 10040104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626699435,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626699553,
                ""BestRecordTime"": 97,
                ""LastRecordTime"": 97,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040201"": {
                ""StageId"": 10040201,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626699572,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626699930,
                ""BestRecordTime"": 126,
                ""LastRecordTime"": 126,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040202"": {
                ""StageId"": 10040202,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626700178,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626700246,
                ""BestRecordTime"": 52,
                ""LastRecordTime"": 52,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040203"": {
                ""StageId"": 10040203,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626701083,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626701127,
                ""BestRecordTime"": 25,
                ""LastRecordTime"": 25,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040204"": {
                ""StageId"": 10040204,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626701146,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626701248,
                ""BestRecordTime"": 80,
                ""LastRecordTime"": 80,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040301"": {
                ""StageId"": 10040301,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626705801,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626705918,
                ""BestRecordTime"": 92,
                ""LastRecordTime"": 92,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040302"": {
                ""StageId"": 10040302,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626706846,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626706924,
                ""BestRecordTime"": 51,
                ""LastRecordTime"": 51,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040303"": {
                ""StageId"": 10040303,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626706942,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626707020,
                ""BestRecordTime"": 48,
                ""LastRecordTime"": 48,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10040304"": {
                ""StageId"": 10040304,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627384916,
                ""RefreshTime"": 1627482356,
                ""CreateTime"": 1626707141,
                ""BestRecordTime"": 38,
                ""LastRecordTime"": 38,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ]
            },
            ""11030101"": {
                ""StageId"": 11030101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626733258,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626733379,
                ""BestRecordTime"": 103,
                ""LastRecordTime"": 103,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11030102"": {
                ""StageId"": 11030102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626733389,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626733486,
                ""BestRecordTime"": 87,
                ""LastRecordTime"": 87,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11030103"": {
                ""StageId"": 11030103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626733566,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626733658,
                ""BestRecordTime"": 77,
                ""LastRecordTime"": 77,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11030104"": {
                ""StageId"": 11030104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626733708,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626733887,
                ""BestRecordTime"": 60,
                ""LastRecordTime"": 60,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11030105"": {
                ""StageId"": 11030105,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626734685,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626734811,
                ""BestRecordTime"": 111,
                ""LastRecordTime"": 111,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11030106"": {
                ""StageId"": 11030106,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626734821,
                ""RefreshTime"": 1626788265,
                ""CreateTime"": 1626734933,
                ""BestRecordTime"": 96,
                ""LastRecordTime"": 96,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010402"": {
                ""StageId"": 30010402,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 5,
                ""PassTimesTotal"": 5,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627031874,
                ""RefreshTime"": 1627031874,
                ""CreateTime"": 1626735029,
                ""BestRecordTime"": 18,
                ""LastRecordTime"": 30,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""30010702"": {
                ""StageId"": 30010702,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 7,
                ""PassTimesTotal"": 7,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626789729,
                ""RefreshTime"": 1626789729,
                ""CreateTime"": 1626789310,
                ""BestRecordTime"": 12,
                ""LastRecordTime"": 12,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10050101"": {
                ""StageId"": 10050101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626790041,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626790122,
                ""BestRecordTime"": 56,
                ""LastRecordTime"": 56,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10050102"": {
                ""StageId"": 10050102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626790135,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626790251,
                ""BestRecordTime"": 90,
                ""LastRecordTime"": 90,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10050103"": {
                ""StageId"": 10050103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626793050,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626790417,
                ""BestRecordTime"": 108,
                ""LastRecordTime"": 130,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10050104"": {
                ""StageId"": 10050104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626790432,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626790550,
                ""BestRecordTime"": 102,
                ""LastRecordTime"": 102,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10050201"": {
                ""StageId"": 10050201,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626790581,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626790667,
                ""BestRecordTime"": 63,
                ""LastRecordTime"": 63,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10050202"": {
                ""StageId"": 10050202,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626790708,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626790831,
                ""BestRecordTime"": 100,
                ""LastRecordTime"": 100,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30060902"": {
                ""StageId"": 30060902,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626792938,
                ""RefreshTime"": 1626792938,
                ""CreateTime"": 1626793018,
                ""BestRecordTime"": 66,
                ""LastRecordTime"": 66,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""30061102"": {
                ""StageId"": 30061102,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626793209,
                ""RefreshTime"": 1626793209,
                ""CreateTime"": 1626793265,
                ""BestRecordTime"": 41,
                ""LastRecordTime"": 41,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10050203"": {
                ""StageId"": 10050203,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626803357,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626803435,
                ""BestRecordTime"": 56,
                ""LastRecordTime"": 56,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""30070101"": {
                ""StageId"": 30070101,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626804111,
                ""RefreshTime"": 1626804111,
                ""CreateTime"": 1626804149,
                ""BestRecordTime"": 24,
                ""LastRecordTime"": 24,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""30070102"": {
                ""StageId"": 30070102,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626804380,
                ""RefreshTime"": 1626804380,
                ""CreateTime"": 1626804428,
                ""BestRecordTime"": 34,
                ""LastRecordTime"": 34,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""13010211"": {
                ""StageId"": 13010211,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626804463,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010212"": {
                ""StageId"": 13010212,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626804466,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010213"": {
                ""StageId"": 13010213,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626804468,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010214"": {
                ""StageId"": 13010214,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626804470,
                ""RefreshTime"": 1626804470,
                ""CreateTime"": 1626804544,
                ""BestRecordTime"": 63,
                ""LastRecordTime"": 63,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010215"": {
                ""StageId"": 13010215,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626804556,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010216"": {
                ""StageId"": 13010216,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626804565,
                ""RefreshTime"": 1626804565,
                ""CreateTime"": 1626804611,
                ""BestRecordTime"": 37,
                ""LastRecordTime"": 37,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""30000101"": {
                ""StageId"": 30000101,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626804757,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""30000102"": {
                ""StageId"": 30000102,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1626804842,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""10050204"": {
                ""StageId"": 10050204,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626805010,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626805074,
                ""BestRecordTime"": 48,
                ""LastRecordTime"": 48,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10050301"": {
                ""StageId"": 10050301,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626805503,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626805538,
                ""BestRecordTime"": 22,
                ""LastRecordTime"": 22,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10050302"": {
                ""StageId"": 10050302,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626805557,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626805672,
                ""BestRecordTime"": 101,
                ""LastRecordTime"": 101,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10050303"": {
                ""StageId"": 10050303,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626805690,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626805743,
                ""BestRecordTime"": 37,
                ""LastRecordTime"": 37,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10050304"": {
                ""StageId"": 10050304,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626805765,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626805872,
                ""BestRecordTime"": 91,
                ""LastRecordTime"": 91,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""30010302"": {
                ""StageId"": 30010302,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626805929,
                ""RefreshTime"": 1626805929,
                ""CreateTime"": 1626805963,
                ""BestRecordTime"": 22,
                ""LastRecordTime"": 22,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""11040101"": {
                ""StageId"": 11040101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626806317,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626806436,
                ""BestRecordTime"": 104,
                ""LastRecordTime"": 104,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""11040102"": {
                ""StageId"": 11040102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626806449,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626806529,
                ""BestRecordTime"": 70,
                ""LastRecordTime"": 70,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11040103"": {
                ""StageId"": 11040103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626806547,
                ""RefreshTime"": 1626903618,
                ""CreateTime"": 1626806645,
                ""BestRecordTime"": 85,
                ""LastRecordTime"": 85,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11040104"": {
                ""StageId"": 11040104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626974002,
                ""RefreshTime"": 1627031354,
                ""CreateTime"": 1626974074,
                ""BestRecordTime"": 54,
                ""LastRecordTime"": 54,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""11040105"": {
                ""StageId"": 11040105,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626974093,
                ""RefreshTime"": 1627031354,
                ""CreateTime"": 1626974248,
                ""BestRecordTime"": 144,
                ""LastRecordTime"": 144,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11040106"": {
                ""StageId"": 11040106,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1626974260,
                ""RefreshTime"": 1627031354,
                ""CreateTime"": 1626974345,
                ""BestRecordTime"": 72,
                ""LastRecordTime"": 72,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""20000101"": {
                ""StageId"": 20000101,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 2,
                ""PassTimesTotal"": 13,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627326863,
                ""RefreshTime"": 1627326863,
                ""CreateTime"": 1626974730,
                ""BestRecordTime"": 34,
                ""LastRecordTime"": 63,
                ""BestCardIds"": [
                    1021001
                ],
                ""LastCardIds"": [
                    1021001,
                    0,
                    0
                ]
            },
            ""10060101"": {
                ""StageId"": 10060101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627031948,
                ""RefreshTime"": 1627175899,
                ""CreateTime"": 1627032040,
                ""BestRecordTime"": 75,
                ""LastRecordTime"": 75,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10060102"": {
                ""StageId"": 10060102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627032054,
                ""RefreshTime"": 1627175899,
                ""CreateTime"": 1627032197,
                ""BestRecordTime"": 127,
                ""LastRecordTime"": 127,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10060103"": {
                ""StageId"": 10060103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627487640,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627212349,
                ""BestRecordTime"": 44,
                ""LastRecordTime"": 44,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10060104"": {
                ""StageId"": 10060104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627489293,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627326994,
                ""BestRecordTime"": 87,
                ""LastRecordTime"": 87,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ]
            },
            ""10060201"": {
                ""StageId"": 10060201,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627380323,
                ""RefreshTime"": 1627482356,
                ""CreateTime"": 1627380432,
                ""BestRecordTime"": 87,
                ""LastRecordTime"": 87,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10060202"": {
                ""StageId"": 10060202,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627380454,
                ""RefreshTime"": 1627482356,
                ""CreateTime"": 1627380499,
                ""BestRecordTime"": 30,
                ""LastRecordTime"": 30,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""10060203"": {
                ""StageId"": 10060203,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627380512,
                ""RefreshTime"": 1627482356,
                ""CreateTime"": 1627380625,
                ""BestRecordTime"": 96,
                ""LastRecordTime"": 96,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1011002
                ]
            },
            ""13010311"": {
                ""StageId"": 13010311,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381431,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010312"": {
                ""StageId"": 13010312,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381434,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010313"": {
                ""StageId"": 13010313,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381436,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010314"": {
                ""StageId"": 13010314,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381439,
                ""RefreshTime"": 1627381439,
                ""CreateTime"": 1627381500,
                ""BestRecordTime"": 51,
                ""LastRecordTime"": 51,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010315"": {
                ""StageId"": 13010315,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381512,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010316"": {
                ""StageId"": 13010316,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381515,
                ""RefreshTime"": 1627381515,
                ""CreateTime"": 1627381548,
                ""BestRecordTime"": 25,
                ""LastRecordTime"": 25,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010911"": {
                ""StageId"": 13010911,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381569,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010912"": {
                ""StageId"": 13010912,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381573,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010913"": {
                ""StageId"": 13010913,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381575,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010914"": {
                ""StageId"": 13010914,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381578,
                ""RefreshTime"": 1627381578,
                ""CreateTime"": 1627381634,
                ""BestRecordTime"": 45,
                ""LastRecordTime"": 45,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010915"": {
                ""StageId"": 13010915,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381645,
                ""RefreshTime"": 1627381645,
                ""CreateTime"": 1627381699,
                ""BestRecordTime"": 45,
                ""LastRecordTime"": 45,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010916"": {
                ""StageId"": 13010916,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627381712,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""30070103"": {
                ""StageId"": 30070103,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381788,
                ""RefreshTime"": 1627381788,
                ""CreateTime"": 1627381849,
                ""BestRecordTime"": 50,
                ""LastRecordTime"": 50,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ]
            },
            ""30070104"": {
                ""StageId"": 30070104,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381874,
                ""RefreshTime"": 1627381874,
                ""CreateTime"": 1627381911,
                ""BestRecordTime"": 22,
                ""LastRecordTime"": 22,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ]
            },
            ""30070105"": {
                ""StageId"": 30070105,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627381936,
                ""RefreshTime"": 1627381936,
                ""CreateTime"": 1627382005,
                ""BestRecordTime"": 59,
                ""LastRecordTime"": 59,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ]
            },
            ""30070106"": {
                ""StageId"": 30070106,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627415961,
                ""RefreshTime"": 1627415961,
                ""CreateTime"": 1627416037,
                ""BestRecordTime"": 60,
                ""LastRecordTime"": 60,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1041002
                ]
            },
            ""30000201"": {
                ""StageId"": 30000201,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627416131,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""30000202"": {
                ""StageId"": 30000202,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627416238,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""30000203"": {
                ""StageId"": 30000203,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627416353,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""10060204"": {
                ""StageId"": 10060204,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627486020,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627486134,
                ""BestRecordTime"": 94,
                ""LastRecordTime"": 94,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10060301"": {
                ""StageId"": 10060301,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627486178,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627486234,
                ""BestRecordTime"": 37,
                ""LastRecordTime"": 37,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10060302"": {
                ""StageId"": 10060302,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627486256,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627486376,
                ""BestRecordTime"": 102,
                ""LastRecordTime"": 102,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10060303"": {
                ""StageId"": 10060303,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627486392,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627486475,
                ""BestRecordTime"": 66,
                ""LastRecordTime"": 66,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10060304"": {
                ""StageId"": 10060304,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627486497,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627486543,
                ""BestRecordTime"": 20,
                ""LastRecordTime"": 20,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30010703"": {
                ""StageId"": 30010703,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 4,
                ""PassTimesTotal"": 4,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627672527,
                ""RefreshTime"": 1627672527,
                ""CreateTime"": 1627486895,
                ""BestRecordTime"": 22,
                ""LastRecordTime"": 25,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1051001,
                    1031003,
                    1041002
                ]
            },
            ""30010403"": {
                ""StageId"": 30010403,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 2,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627486990,
                ""RefreshTime"": 1627486990,
                ""CreateTime"": 1627486966,
                ""BestRecordTime"": 15,
                ""LastRecordTime"": 16,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11050101"": {
                ""StageId"": 11050101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627487378,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627487469,
                ""BestRecordTime"": 70,
                ""LastRecordTime"": 70,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""11050102"": {
                ""StageId"": 11050102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627487483,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627487581,
                ""BestRecordTime"": 85,
                ""LastRecordTime"": 85,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""30061201"": {
                ""StageId"": 30061201,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627487715,
                ""RefreshTime"": 1627487715,
                ""CreateTime"": 1627487761,
                ""BestRecordTime"": 33,
                ""LastRecordTime"": 33,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30050102"": {
                ""StageId"": 30050102,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 2,
                ""PassTimesTotal"": 2,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627488029,
                ""RefreshTime"": 1627488029,
                ""CreateTime"": 1627488015,
                ""BestRecordTime"": 18,
                ""LastRecordTime"": 18,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30000204"": {
                ""StageId"": 30000204,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627488586,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""11050103"": {
                ""StageId"": 11050103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627488666,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627488817,
                ""BestRecordTime"": 129,
                ""LastRecordTime"": 129,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ]
            },
            ""11050104"": {
                ""StageId"": 11050104,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627488834,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627488955,
                ""BestRecordTime"": 109,
                ""LastRecordTime"": 109,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11050105"": {
                ""StageId"": 11050105,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627488977,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627489056,
                ""BestRecordTime"": 67,
                ""LastRecordTime"": 67,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""11050106"": {
                ""StageId"": 11050106,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627489086,
                ""RefreshTime"": 1627554727,
                ""CreateTime"": 1627489201,
                ""BestRecordTime"": 90,
                ""LastRecordTime"": 90,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ]
            },
            ""13010411"": {
                ""StageId"": 13010411,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627489704,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010412"": {
                ""StageId"": 13010412,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627489707,
                ""RefreshTime"": 1627489707,
                ""CreateTime"": 1627489762,
                ""BestRecordTime"": 41,
                ""LastRecordTime"": 41,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010413"": {
                ""StageId"": 13010413,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627489771,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010414"": {
                ""StageId"": 13010414,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627489774,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13010415"": {
                ""StageId"": 13010415,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627489777,
                ""RefreshTime"": 1627489777,
                ""CreateTime"": 1627489919,
                ""BestRecordTime"": 127,
                ""LastRecordTime"": 127,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13010416"": {
                ""StageId"": 13010416,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627489931,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""30070107"": {
                ""StageId"": 30070107,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627490012,
                ""RefreshTime"": 1627490012,
                ""CreateTime"": 1627490111,
                ""BestRecordTime"": 82,
                ""LastRecordTime"": 82,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051003
                ]
            },
            ""30000205"": {
                ""StageId"": 30000205,
                ""StarsMark"": 0,
                ""Passed"": false,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1627491223,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""30010404"": {
                ""StageId"": 30010404,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 5,
                ""PassTimesTotal"": 5,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627673273,
                ""RefreshTime"": 1627673273,
                ""CreateTime"": 1627586757,
                ""BestRecordTime"": 17,
                ""LastRecordTime"": 17,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""30050103"": {
                ""StageId"": 30050103,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1627672381,
                ""RefreshTime"": 1627672381,
                ""CreateTime"": 1627672423,
                ""BestRecordTime"": 30,
                ""LastRecordTime"": 30,
                ""BestCardIds"": [
                    1051001,
                    1031003,
                    1041002
                ],
                ""LastCardIds"": [
                    1051001,
                    1031003,
                    1041002
                ]
            },
            ""13011011"": {
                ""StageId"": 13011011,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1628084959,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13011012"": {
                ""StageId"": 13011012,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1628084962,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13011013"": {
                ""StageId"": 13011013,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1628084965,
                ""RefreshTime"": 1628084965,
                ""CreateTime"": 1628085061,
                ""BestRecordTime"": 85,
                ""LastRecordTime"": 85,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13011014"": {
                ""StageId"": 13011014,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1628085068,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""13011015"": {
                ""StageId"": 13011015,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 1,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1628085076,
                ""RefreshTime"": 1628085076,
                ""CreateTime"": 1628085155,
                ""BestRecordTime"": 70,
                ""LastRecordTime"": 70,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""13011016"": {
                ""StageId"": 13011016,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1628085165,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""10070101"": {
                ""StageId"": 10070101,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1630083719,
                ""RefreshTime"": 1672341323,
                ""CreateTime"": 1630083876,
                ""BestRecordTime"": 121,
                ""LastRecordTime"": 121,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            },
            ""10160101"": {
                ""StageId"": 10160101,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1672413806,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""10160102"": {
                ""StageId"": 10160102,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1672413815,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""10160103"": {
                ""StageId"": 10160103,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1672413890,
                ""RefreshTime"": 1684140278,
                ""CreateTime"": 1672414006,
                ""BestRecordTime"": 98,
                ""LastRecordTime"": 98,
                ""BestCardIds"": [],
                ""LastCardIds"": [
                    0,
                    0,
                    0
                ]
            },
            ""10160104"": {
                ""StageId"": 10160104,
                ""StarsMark"": 0,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 0,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 0,
                ""RefreshTime"": 0,
                ""CreateTime"": 1672414023,
                ""BestRecordTime"": 0,
                ""LastRecordTime"": 0,
                ""BestCardIds"": [],
                ""LastCardIds"": []
            },
            ""10070102"": {
                ""StageId"": 10070102,
                ""StarsMark"": 7,
                ""Passed"": true,
                ""PassTimesToday"": 0,
                ""PassTimesTotal"": 1,
                ""BuyCount"": 0,
                ""Score"": 0,
                ""LastPassTime"": 1672414048,
                ""RefreshTime"": 1684140278,
                ""CreateTime"": 1672414193,
                ""BestRecordTime"": 130,
                ""LastRecordTime"": 130,
                ""BestCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ],
                ""LastCardIds"": [
                    1021001,
                    1031003,
                    1051001
                ]
            }
        },
        ""FubenBaseData"": {
            ""RefreshTime"": 0,
            ""SelectedCharId"": 1021001,
            ""UrgentAlarmCount"": 107,
            ""WeeklyUrgentCount"": 0,
            ""DayUrgentCount"": {}
        },
        ""UnlockHideStages"": [],
        ""StageDifficulties"": []
    },
    ""FubenMainLineData"": {
        ""TreasureData"": [
            1001002,
            1001003,
            1001004,
            1002002,
            1002003,
            1101002,
            1101003,
            1101004,
            1002004,
            1003002,
            1003003,
            1102002,
            1102003,
            1102004,
            1004002,
            1004003,
            1103002,
            1103003,
            1103004,
            1005002,
            1005003,
            1005004,
            1104002,
            1104003,
            1104004,
            1006002,
            1006003,
            1105002,
            1105003,
            1105004,
            1006004,
            1003004,
            1004004
        ],
        ""LastPassStage"": {
            ""1001"": 10010103,
            ""1002"": 10020104,
            ""1101"": 11010106,
            ""1003"": 10030304,
            ""1102"": 11020106,
            ""1004"": 10040102,
            ""1103"": 11030106,
            ""1005"": 10050304,
            ""1104"": 11040106,
            ""1006"": 10060104,
            ""1105"": 11050106,
            ""1007"": 10070102,
            ""1016"": 10160103
        },
        ""MainChapterEventInfos"": []
    },
    ""FubenChapterExtraLoginData"": {
        ""TreasureData"": [],
        ""LastPassStage"": [],
        ""ChapterEventInfos"": []
    },
    ""FubenUrgentEventData"": {
        ""UrgentEventData"": {}
    },
    ""AutoFightRecords"": [],
    ""TeamGroupData"": {
        ""6"": {
            ""TeamType"": 1,
            ""TeamId"": 6,
            ""CaptainPos"": 1,
            ""FirstFightPos"": 1,
            ""TeamData"": {
                ""1"": 1021001,
                ""2"": 1031003,
                ""3"": 1041002
            },
            ""TeamName"": null
        },
        ""1"": {
            ""TeamType"": 1,
            ""TeamId"": 1,
            ""CaptainPos"": 1,
            ""FirstFightPos"": 1,
            ""TeamData"": {
                ""1"": 1021001,
                ""2"": 1031003,
                ""3"": 1051001
            },
            ""TeamName"": null
        }
    },
    ""TeamPrefabData"": {},
    ""SignInfos"": [
        {
            ""Id"": 2,
            ""Round"": 2,
            ""Day"": 7,
            ""Got"": true,
            ""FinishDay"": 17
        },
        {
            ""Id"": 1,
            ""Round"": 1,
            ""Day"": 7,
            ""Got"": true,
            ""FinishDay"": 0
        },
        {
            ""Id"": 1300240,
            ""Round"": 1,
            ""Day"": 1,
            ""Got"": true,
            ""FinishDay"": 0
        }
    ],
    ""AssignChapterRecord"": [],
    ""WeaponFashionList"": [],
    ""PartnerList"": [],
    ""ShieldedProtocolList"": [],
    ""LimitedLoginData"": null,
    ""UseBackgroundId"": 14000001,
    ""FubenShortStoryLoginData"": {
        ""TreasureData"": [],
        ""LastPassStage"": [],
        ""ChapterEventInfos"": []
    }
}");

            session.Send("NotifyLogin", login);

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
