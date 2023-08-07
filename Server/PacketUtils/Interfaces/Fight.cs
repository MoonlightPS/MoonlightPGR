using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoonlightPGR.Server.PacketUtils.Interfaces
{
    [MessagePackObject(true)]
    public class Npc
    {
        public LoginCharacterList Character { get; set; }
        public EquipList[] Equips { get; set; }
        public List<int> AttribGroupList { get; set; }
        public object CharacterSkillPlus { get; set; }
        public List<int> EquipSkillPlus { get; set; }
        public int AttribReviseId { get; set; }
        public List<int> EventIds { get; set; }
        public object FightEventsWithLevel { get; set; }
        public int WeaponFashionId { get; set; }
        public object Partner { get; set; }
        public bool IsRobot { get; set; }
        public object AttrRateTable { get; set; }
    }



    [MessagePackObject(true)]
    public class RoleDatum
    {
        public int Id { get; set; }
        public int Camp { get; set; }
        public string Name { get; set; }
        public bool IsRobot { get; set; }
        public int CaptainIndex { get; set; }
        public int FirstFightPos { get; set; }
        public Dictionary<int, Npc> NpcData { get; set; }
        public object CustomNpc { get; set; }
        public object AssistNpcData { get; set; }
    }

    [MessagePackObject(true)]
    public class FightData
    {
        public bool Online { get; set; }
        public int FightId { get; set; }
        public int? RoomId { get; set; }
        public int OnlineMode { get; set; }
        public int Seed { get; set; }
        public int StageId { get; set; }
        public int RebootId { get; set; }
        public int PassTimeLimit { get; set; }
        public int StarsMark { get; set; }
        public int? MonsterLevel { get; set; }
        public List<int> EventIds { get; set; }
        public object FightEventsWithLevel { get; set; }
        public List<int> NormalEventIds { get; set; }
        public List<RoleDatum> RoleData { get; set; }
        public int ReviseId { get; set; }
        public int PlayerLevel { get; set; }
        public object NpcGroupList { get; set; }
        public FightControlData FightControlData { get; set; }
        public bool DisableJoystick { get; set; }
        public bool Restartable { get; set; }
        public bool DisableDeadEffect { get; set; }
        public object CustomData { get; set; }
        public object Records { get; set; }
        public object StStageDropData { get; set; }
    }

    [MessagePackObject(true)]
    public class FightControlData
    {
        public int MaxFight { get; set; }
        public int MaxRecommendFight { get; set; }
        public int MaxShowFight { get; set; }
        public int AvgFight { get; set; }
        public int AvgRecommendFight { get; set; }
        public int AvgShowFight { get; set; }
    }

    [MessagePackObject(true)]
    public class FightDataRoot
    {
        public int Code { get; set; }
        public FightData FightData { get; set; }
    }

    [MessagePackObject(true)]
    public class PreFightData
    {
        public bool IsHasAssist { get; set; }
        public int FirstFightPos { get; set; }
        public int CaptainPos { get; set; }
        public int StageId { get; set; }
        public int ChallengeCount { get; set; }
        public List<int> CardIds { get; set; }
    }

    [MessagePackObject(true)]
    public class PreFightDataRoot
    {
        public PreFightData PreFightData { get; set; }
    }

    [MessagePackObject(true)]
    public class FightSettleRoot
    {
        public FightSettle Result { get; set; }
    }

    [MessagePackObject(true)]
    public class FightSettle
    {
        public bool IsWin { get; set; }
        public bool IsForceExit { get; set; }
        public int StageId { get; set; }
        public int StageLevel { get; set; }
        public int FightId { get; set; }
        public int RebootCount { get; set; }
        public int AddStars { get; set; }
        public int StartFrame { get; set; }
        public int SettleFrame { get; set; }
        public int PauseFrame { get; set; }
        public int ExSkillPauseFrame { get; set; }
        public int SettleCode { get; set; }
        public int DodgeTimes { get; set; }
        public int NormalAttackTimes { get; set; }
        public int ConsumeBallTimes { get; set; }
        public int StuntSkillTimes { get; set; }
        public int PauseTimes { get; set; }
        public int HighestCombo { get; set; }
        public int DamagedTimes { get; set; }
        public int MatrixTimes { get; set; }
        public int HighestDamage { get; set; }
        public int TotalDamage { get; set; }
        public int TotalDamaged { get; set; }
        public int TotalCure { get; set; }
        public List<int> PlayerIds { get; set; }
        public List<object> PlayerData { get; set; }
        public object IntToIntRecord { get; set; }
        public object StringToIntRecord { get; set; }
        public object Operations { get; set; }
        public List<int> Codes { get; set; }
        public int LeftTime { get; set; }
        public Dictionary<int,NpcHp> NpcHpInfo { get; set; }
        public Dictionary<int,NpcDps> NpcDpsTable { get; set; }
        public List<object> EventSet { get; set; }
        public int DeathTotalMyTeam { get; set; }
        public int DeathTotalEnemy { get; set; }
        public object DeathRecord { get; set; }
        public List<object> GroupDropDatas { get; set; }
        public object EpisodeFightResults { get; set; }
        public object CustomData { get; set; }
    }

    [MessagePackObject(true)]
    public class NpcHp
    {
        public int CharacterId { get; set; }
        public int NpcId { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public List<int> BuffIds { get; set; }
        public object AttrTable { get; set; }
    }

    [MessagePackObject(true)]
    public class NpcDps
    {
        public int Value { get; set; }
        public int MaxValue { get; set; }
        public int RoleId { get; set; }
        public int NpcId { get; set; }
        public int CharacterId { get; set; }
        public int DamageTotal { get; set; }
        public int DamageNormal { get; set; }
        public List<int> DamageMagic { get; set; }
        public int BreakEndure { get; set; }
        public int Cure { get; set; }
        public int Hurt { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public List<int> BuffIds { get; set; }
        public object AttrTable { get; set; }
    }
}
