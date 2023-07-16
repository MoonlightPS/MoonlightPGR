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
    public class CharacterList
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
        public List<CharacterList> CharacterList { get; set; }
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

}
