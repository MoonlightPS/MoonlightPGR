using MessagePack;

namespace MoonlightPGR.Server.PacketUtils.Interfaces
{
    [MessagePackObject(true)]
    public class LoginRequest
    {
        public string ServerBean { get; set; }
        public int LoginType { get; set; }
        public int LoginPlatform { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string ClientVersion { get; set; }
        public string Token { get; set; }
    }

    [MessagePackObject(true)]
    public class LoginResponse
    {
        public uint Code { get; set; }
        public uint UtcOffset { get; set; }
        public long UtcServerTime { get; set; }
        public string ReconnectToken { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyDailyLotteryData
    {
        public List<object> Lotteries { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyPayInfo
    {
        public double TotalPayMoney { get; set; }
        public bool IsGetFirstPayReward { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyEquipChipGroupList
    {
        public List<object> ChipGroupDataList { get; set; }
    }

    [MessagePackObject(true)]
    public class ChipRecycleSite
    {
        public List<uint> RecycleStar { get; set; }
        public int Days { get; set; }
        public int SetRecycleTime { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyEquipChipAutoRecycleSite
    {
        public ChipRecycleSite ChipRecycleSite { get; set; }
    }

    [MessagePackObject(true)]
    public class Equip
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Breakthrough { get; set; }
        public int ResonanceCount { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyArchiveLoginData
    {
        public List<object> Monsters { get; set; }
        public List<Equip> Equips { get; set; }
        public List<object> MonsterUnlockIds { get; set; }
        public List<object> WeaponUnlockIds { get; set; }
        public List<object> AwarenessUnlockIds { get; set; }
        public List<object> MonsterSettings { get; set; }
        public List<object> WeaponSettings { get; set; }
        public List<object> AwarenessSettings { get; set; }
        public List<object> MonsterInfos { get; set; }
        public List<object> MonsterSkills { get; set; }
        public List<int> UnlockCgs { get; set; }
        public List<object> UnlockStoryDetails { get; set; }
        public List<object> PartnerUnlockIds { get; set; }
        public List<object> PartnerSettings { get; set; }
        public List<object> UnlockPvDetails { get; set; }
        public List<object> UnlockMails { get; set; }
    }

    [MessagePackObject(true)]
    public class UnlockEmoji
    {
        public int Id { get; set; }
        public int EndTime { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyChatLoginData
    {
        public int RefreshTime { get; set; }
        public List<UnlockEmoji> UnlockEmojis { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifySocialData
    {
        public List<object> FriendData { get; set; }
        public List<object> ApplyData { get; set; }
        public List<object> Remarks { get; set; }
        public List<object> BlockData { get; set; }
    }

    [MessagePackObject(true)]
    public class Teacher
    {
        public int PlayerId { get; set; }
        public object PlayerName { get; set; }
        public int Level { get; set; }
        public int HeadPortraitId { get; set; }
        public int HeadFrameId { get; set; }
        public bool IsGraduate { get; set; }
        public object Tag { get; set; }
        public object OnlineTag { get; set; }
        public object Announcement { get; set; }
        public int StudentCount { get; set; }
        public object StudentTask { get; set; }
        public bool IsOnline { get; set; }
        public object SystemTask { get; set; }
        public object WeeklyTask { get; set; }
        public int KizunaAmount { get; set; }
        public int JoinTime { get; set; }
        public int ReachTime { get; set; }
        public int LastLoginTime { get; set; }
        public int SendGiftCount { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyMentorData
    {
        public int PlayerType { get; set; }
        public Teacher Teacher { get; set; }
        public List<object> Students { get; set; }
        public List<object> ApplyList { get; set; }
        public int GraduateStudentCount { get; set; }
        public List<object> StageReward { get; set; }
        public List<object> WeeklyTaskReward { get; set; }
        public int WeeklyTaskCompleteCount { get; set; }
        public List<object> Tag { get; set; }
        public List<object> OnlineTag { get; set; }
        public object Announcement { get; set; }
        public int DailyChangeTaskCount { get; set; }
        public int WeeklyLevel { get; set; }
        public int MonthlyStudentCount { get; set; }
        public object Message { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyMentorChat
    {
        public List<object> ChatMessages { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyTask
    {
        public Task Tasks { get; set; }
        public object TaskLimitIdActiveInfos { get; set; }
    }

    [MessagePackObject(true)]
    public class Schedule
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }

    [MessagePackObject(true)]
    public class Task
    {
        public int Id { get; set; }
        public List<Schedule> Schedule { get; set; }
        public int State { get; set; }
        public int RecordTime { get; set; }
        public int ActivityId { get; set; }
        public List<Task> Tasks { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyActivenessStatus
    {
        public int DailyActivenessRewardStatus { get; set; }
        public int WeeklyActivenessRewardStatus { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyNewPlayerTaskStatus
    {
        public int NewPlayerTaskActiveDay { get; set; }
    }

    [MessagePackObject(true)]
    public class ActivityData
    {
        public int Id { get; set; }
        public int BeginTime { get; set; }
        public int State { get; set; }
    }

    [MessagePackObject(true)]
    public class Regression2Data
    {
        public ActivityData ActivityData { get; set; }
        public object SignInData { get; set; }
        public InviteData InviteData { get; set; }
        public List<object> GachaDatas { get; set; }
    }

    [MessagePackObject(true)]
    public class InviteData
    {
        public int Id { get; set; }
        public int State { get; set; }
        public int TotalPoint { get; set; }
        public int LastDayTotalPoint { get; set; }
        public int DailyPoint { get; set; }
        public int DailyConsumeCount { get; set; }
        public List<object> BindedPlayers { get; set; }
        public List<object> Rewards { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyRegression2Data
    {
        public Regression2Data Data { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyAllRedEnvelope
    {
        public List<object> Envelopes { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyScoreTitleData
    {
        public List<object> TitleInfos { get; set; }
        public List<object> HideTypes { get; set; }
        public bool IsHideCollection { get; set; }
        public List<WallInfo> WallInfos { get; set; }
        public List<int> UnlockedDecorationIds { get; set; }
    }

    [MessagePackObject(true)]
    public class WallInfo
    {
        public int Id { get; set; }
        public int PedestalId { get; set; }
        public int BackgroundId { get; set; }
        public bool IsShow { get; set; }
        public List<object> CollectionSetInfos { get; set; }
    }

    [MessagePackObject(true)]
    public class BfrtData
    {
        public List<object> BfrtGroupRecords { get; set; }
        public List<object> BfrtTeamInfos { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyBfrtData
    {
        public BfrtData BfrtData { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyGuildEvent
    {
        public int Type { get; set; }
        public int Value { get; set; }
        public int Value2 { get; set; }
        public object Str1 { get; set; }
    }

    [MessagePackObject(true)]
    public class AssistData
    {
        public int AssistCharacterId { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyAssistData
    {
        public AssistData AssistData { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyWorkNextRefreshTime
    {
        public long NextRefreshTime { get; set; }
    }

    [MessagePackObject(true)]
    public class DormCharacterList
    {
        public int CharacterId { get; set; }
        public int DormitoryId { get; set; }
        public int Mood { get; set; }
        public int Vitality { get; set; }
        public int MoodSpeed { get; set; }
        public int VitalitySpeed { get; set; }
        public long LastFondleRecoveryTime { get; set; }
        public int LeftFondleCount { get; set; }
        public List<object> EventList { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyDormitoryData
    {
        public List<object> FurnitureCreateList { get; set; }
        public List<object> WorkList { get; set; }
        public List<object> FurnitureUnlockList { get; set; }
        public int SnapshotTimes { get; set; }
        public List<object> DormitoryList { get; set; }
        public List<object> VisitorList { get; set; }
        public List<object> FurnitureList { get; set; }
        public List<DormCharacterList> CharacterList { get; set; }
        public List<object> Layouts { get; set; }
        public List<object> BindRelations { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyNameplateLoginData
    {
        public int CurrentWearNameplate { get; set; }
        public List<object> UnlockNameplates { get; set; }
    }

    [MessagePackObject(true)]
    public class Match
    {
        public int MatchId { get; set; }
        public List<Player> Players { get; set; }
        public List<object> Pairs { get; set; }
        public int VoteVersion { get; set; }
    }

    [MessagePackObject(true)]
    public class Player
    {
        public int PlayerId { get; set; }
        public int GroupId { get; set; }
        public int Vote { get; set; }
        public int VoteShow { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyMoeWarActivityData
    {
        public int ActivityNo { get; set; }
        public int CurMatchId { get; set; }
        public List<Match> Matches { get; set; }
        public List<object> MyVoteRecord { get; set; }
        public int VoteDaily { get; set; }
        public List<object> MyVoteItemDailyRecord { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyFiveTwentyRecord
    {
        public List<object> CharacterIds { get; set; }
        public List<object> GroupRecord { get; set; }
        public int ActivityNo { get; set; }
    }

    [MessagePackObject(true)]
    public class PurchaseConfigItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AssetPath { get; set; }
        public List<object> PurchasePackageIds { get; set; }
        public string StartTimeStr { get; set; }
        public string EndTimeStr { get; set; }
        public int Period { get; set; }
        public bool IsRare { get; set; }
        public bool IsLockShow { get; set; }
        public int UiType { get; set; }
    }

    [MessagePackObject(true)]
    public class PurchaseConfigData
    {
        public Dictionary<string, PurchaseConfigItem> AddOrModifyConfigs { get; set; }
        public object RemoveIds { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyPurchaseRecommendConfig
    {
        public PurchaseConfigData Data { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyBackgroundLoginData
    {
        public List<int> HaveBackgroundIds { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyMedalData
    {
        public List<object> MedalInfos { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyExploreData
    {
        public List<object> ChapterDatas { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyGatherRewardList
    {
        public List<int> GatherRewards { get; set; }
    }

    [MessagePackObject(true)]
    public class FreeRewardInfoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [MessagePackObject(true)]
    public class PurchaseDailyNotify
    {
        public List<object> ExpireInfoList { get; set; }
        public List<object> DailyRewardInfoList { get; set; }
        public List<FreeRewardInfoList> FreeRewardInfoList { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyAccumulatedPayData
    {
        public int PayId { get; set; }
        public double PayMoney { get; set; }
        public List<object> PayRewardIds { get; set; }
    }

    [MessagePackObject(true)]
    public class FubenPrequelData
    {
        public List<object> RewardedStages { get; set; }
        public List<object> UnlockChallengeStages { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyFubenPrequelData
    {
        public FubenPrequelData FubenPrequelData { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyPrequelChallengeRefreshTime
    {
        public long NextRefreshTime { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyMainLineActivity
    {
        public List<int> Chapters { get; set; }
        public int BfrtChapter { get; set; }
        public int EndTime { get; set; }
        public int HideChapterBeginTime { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyDailyFubenLoginData
    {
        public int RefreshTime { get; set; }
        public List<object> Records { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyBirthdayPlot
    {
        public int NextActiveYear { get; set; }
        public int IsChange { get; set; }
        public List<object> UnLockCg { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyBriefStoryData
    {
        public List<object> FinishedIds { get; set; }
    }

    [MessagePackObject(true)]
    public class MapBossList
    {
        public int Id { get; set; }
        public int InitHp { get; set; }
        public int SubBossMaxHp { get; set; }
        public int BossStepMin { get; set; }
        public int BossStepMax { get; set; }
        public double BattleHurtRate { get; set; }
        public int BattleHurtMax { get; set; }
        public int SelfHpRate { get; set; }
        public int SelfHpMax { get; set; }
        public int ConvertHurtRate { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyChessPursuitGroupInfo
    {
        public List<object> MapDBList { get; set; }
        public List<MapBossList> MapBossList { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyClickClearData
    {
        public List<object> Activities { get; set; }
    }

    [MessagePackObject(true)]
    public class NotifyActivityDrawGroupCount
    {
        public int Count { get; set; }
    }

    [MessagePackObject(true)]
    public partial class NotifyLogin
    {
        public PlayerData PlayerData { get; set; }
        public TimeLimitCtrlConfigList[] TimeLimitCtrlConfigList { get; set; }
        public SharePlatformConfigList[] SharePlatformConfigList { get; set; }
        public ItemList[] ItemList { get; set; }
        public Dictionary<string, ItemRecycleData> ItemRecycleDict { get; set; }
        public LoginCharacterList[] CharacterList { get; set; }
        public EquipList[] EquipList { get; set; }
        public FashionList[] FashionList { get; set; }
        public HeadPortraitList[] HeadPortraitList { get; set; }
        public BaseEquipLoginData BaseEquipLoginData { get; set; }
        public FubenData FubenData { get; set; }
        public FubenMainLineData FubenMainLineData { get; set; }
        public FubenLoginData FubenChapterExtraLoginData { get; set; }
        public FubenUrgentEventData FubenUrgentEventData { get; set; }
        public object[] AutoFightRecords { get; set; }
        public Dictionary<string, TeamGroupDatum> TeamGroupData { get; set; }
        public object TeamPrefabData { get; set; }
        public SignInfo[] SignInfos { get; set; }
        public object[] AssignChapterRecord { get; set; }
        public object[] WeaponFashionList { get; set; }
        public object[] PartnerList { get; set; }
        public object[] ShieldedProtocolList { get; set; }
        public object LimitedLoginData { get; set; }
        public long UseBackgroundId { get; set; }
        public FubenLoginData FubenShortStoryLoginData { get; set; }
    }

    [MessagePackObject(true)]
    public partial class BaseEquipLoginData
    {
        public object[] BaseEquipList { get; set; }
        public object[] DressedList { get; set; }
    }

    [MessagePackObject(true)]
    public partial class LoginCharacterList
    {
        public long Id { get; set; }
        public long Level { get; set; }
        public long Exp { get; set; }
        public long Quality { get; set; }
        public long InitQuality { get; set; }
        public long Star { get; set; }
        public long Grade { get; set; }
        public SkillList[] SkillList { get; set; }
        public object[] EnhanceSkillList { get; set; }
        public long FashionId { get; set; }
        public long CreateTime { get; set; }
        public long TrustLv { get; set; }
        public long TrustExp { get; set; }
        public long Ability { get; set; }
        public long LiberateLv { get; set; }
        public CharacterHeadInfo CharacterHeadInfo { get; set; }
    }

    [MessagePackObject(true)]
    public partial class CharacterHeadInfo
    {
        public long HeadFashionId { get; set; }
        public long HeadFashionType { get; set; }
    }

    [MessagePackObject(true)]
    public partial class SkillList
    {
        public long Id { get; set; }
        public long Level { get; set; }
    }

    [MessagePackObject(true)]
    public partial class EquipList
    {
        public long Id { get; set; }
        public long TemplateId { get; set; }
        public long CharacterId { get; set; }
        public long Level { get; set; }
        public long Exp { get; set; }
        public long Breakthrough { get; set; }
        public ResonanceInfo[] ResonanceInfo { get; set; }
        public object[] UnconfirmedResonanceInfo { get; set; }
        public object[] AwakeSlotList { get; set; }
        public bool IsLock { get; set; }
        public long CreateTime { get; set; }
        public bool IsRecycle { get; set; }
    }

    [MessagePackObject(true)]
    public partial class ResonanceInfo
    {
        public long Slot { get; set; }
        public long Type { get; set; }
        public long CharacterId { get; set; }
        public long TemplateId { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FashionList
    {
        public long Id { get; set; }
        public bool IsLock { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FubenLoginData
    {
        public object[] TreasureData { get; set; }
        public object[] LastPassStage { get; set; }
        public object[] ChapterEventInfos { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FubenData
    {
        public Dictionary<string, StageDatum> StageData { get; set; }
        public FubenBaseData FubenBaseData { get; set; }
        public object[] UnlockHideStages { get; set; }
        public object[] StageDifficulties { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FubenBaseData
    {
        public long RefreshTime { get; set; }
        public long SelectedCharId { get; set; }
        public long UrgentAlarmCount { get; set; }
        public long WeeklyUrgentCount { get; set; }
        public object DayUrgentCount { get; set; }
    }

    [MessagePackObject(true)]
    public partial class ItemRecycleData
    {
        public int Id { get; set; }
        public long RecycleTime { get; set; }
        public int RecycleCount { get; set; }
    }

    [MessagePackObject(true)]
    public partial class StageDatum
    {
        public long StageId { get; set; }
        public long StarsMark { get; set; }
        public bool Passed { get; set; }
        public long PassTimesToday { get; set; }
        public long PassTimesTotal { get; set; }
        public long BuyCount { get; set; }
        public long Score { get; set; }
        public long LastPassTime { get; set; }
        public long RefreshTime { get; set; }
        public long CreateTime { get; set; }
        public long BestRecordTime { get; set; }
        public long LastRecordTime { get; set; }
        public long[] BestCardIds { get; set; }
        public long[] LastCardIds { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FubenMainLineData
    {
        public long[] TreasureData { get; set; }
        public Dictionary<string, long> LastPassStage { get; set; }
        public object[] MainChapterEventInfos { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FubenUrgentEventData
    {
        public object UrgentEventData { get; set; }
    }

    [MessagePackObject(true)]
    public partial class HeadPortraitList
    {
        public long Id { get; set; }
        public long LeftCount { get; set; }
        public long BeginTime { get; set; }
    }

    [MessagePackObject(true)]
    public partial class ItemList
    {
        public long Id { get; set; }
        public long Count { get; set; }
        public long BuyTimes { get; set; }
        public long TotalBuyTimes { get; set; }
        public long LastBuyTime { get; set; }
        public long RefreshTime { get; set; }
        public long CreateTime { get; set; }
    }

    [MessagePackObject(true)]
    public partial class PlayerData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Level { get; set; }
        public string Sign { get; set; }
        public long DisplayCharId { get; set; }
        public Birthday Birthday { get; set; }
        public long HonorLevel { get; set; }
        public string ServerId { get; set; }
        public long Likes { get; set; }
        public long CurrTeamId { get; set; }
        public long ChallengeEventId { get; set; }
        public long CurrHeadPortraitId { get; set; }
        public long CurrHeadFrameId { get; set; }
        public long CurrMedalId { get; set; }
        public long AppearanceShowType { get; set; }
        public long DailyReceiveGiftCount { get; set; }
        public long DailyActivenessRewardStatus { get; set; }
        public long WeeklyActivenessRewardStatus { get; set; }
        public long[] Marks { get; set; }
        public long[] GuideData { get; set; }
        public long[] Communications { get; set; }
        public long[] ShowCharacters { get; set; }
        public object[] ShieldFuncList { get; set; }
        public AppearanceSettingInfo AppearanceSettingInfo { get; set; }
        public long CreateTime { get; set; }
        public long LastLoginTime { get; set; }
        public long ReportTime { get; set; }
        public long ChangeNameTime { get; set; }
        public long Flags { get; set; }
    }

    [MessagePackObject(true)]
    public partial class AppearanceSettingInfo
    {
        public long TitleType { get; set; }
        public long CharacterType { get; set; }
        public long FashionType { get; set; }
        public long WeaponFashionType { get; set; }
        public long DormitoryType { get; set; }
        public long DormitoryId { get; set; }
    }

    [MessagePackObject(true)]
    public partial class Birthday
    {
        public long Mon { get; set; }
        public long Day { get; set; }
    }

    [MessagePackObject(true)]
    public partial class SharePlatformConfigList
    {
        public long Id { get; set; }
        public long[] SdkId { get; set; }
    }

    [MessagePackObject(true)]
    public partial class SignInfo
    {
        public long Id { get; set; }
        public long Round { get; set; }
        public long Day { get; set; }
        public bool Got { get; set; }
        public long FinishDay { get; set; }
    }

    [MessagePackObject(true)]
    public partial class TeamGroupDatum
    {
        public long TeamType { get; set; }
        public long TeamId { get; set; }
        public long CaptainPos { get; set; }
        public long FirstFightPos { get; set; }
        public Dictionary<string, long> TeamData { get; set; }
        public object TeamName { get; set; }
    }

    [MessagePackObject(true)]
    public partial class TimeLimitCtrlConfigList
    {
        public long Id { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }

}
