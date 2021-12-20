using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.AiBehaviors;
using SandBox.View.Map;

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

using HarmonyLib;

namespace FountaTweaks
{
  //apply the user's saved perk settings (if any) right after normal perk initialization
  [HarmonyPatch(typeof(DefaultPerks), "InitializeAll")]
  public class InitializePerksPatch
  {
    static void Postfix(ref DefaultPerks __instance)
    {
      if (FountaTweaksSettings.Instance.PerkModificationEnabled)
        FountaTweaksSettings.Instance.SetAll(ref __instance);
    }
  }

  public class FountaTweaksSettings : AutoFountaTweaksSettings<FountaTweaksSettings>
  {
    public override string Id => "FountaTweaks";
    public override string DisplayName => "Founta's Tweaks";

    private string _version;
    public string version { get => _version; }
    public FountaTweaksSettings()
    {
      //read version from xml
      XmlReader reader = XmlReader.Create("../../Modules/FountaTweaks/SubModule.xml");
      reader.ReadToFollowing("Version");
      reader.MoveToFirstAttribute();

      this._version = reader.Value;
    }


    /// <summary>
    /// /////////////////////////////////////////////////////////// ranged tweak settings
    /// </summary>

    [SettingPropertyBool("Enable ranged tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Ranged", IsMainToggle = true)]
    public bool RangedTweaksEnabled { get; set; } = false;

    [SettingPropertyBool("Arrow barrels fill throwing weapons", RequireRestart = false)]
    [SettingPropertyGroup("Ranged")]
    public bool ArrowBarrelRefillThrowing { get; set; } = false;

    [SettingPropertyBool("Ammunition stack count tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Ranged/Stack count", IsMainToggle = true)]
    public bool StackCountTweaksEnabled { get; set; } = false;

    [SettingPropertyInteger("Additional arrow stack count",0,100, RequireRestart = false)]
    [SettingPropertyGroup("Ranged/Stack count")]
    public int ExtraArrowStackCount { get; set; } = 0;
    [SettingPropertyInteger("Additional bolt stack count", 0, 100, RequireRestart = false)]
    [SettingPropertyGroup("Ranged/Stack count")]
    public int ExtraBoltStackCount { get; set; } = 0;
    [SettingPropertyInteger("Additional javelin stack count", 0, 100, RequireRestart = false)]
    [SettingPropertyGroup("Ranged/Stack count")]
    public int ExtraJavelinStackCount { get; set; } = 0;
    [SettingPropertyInteger("Additional throwing axe stack count", 0, 100, RequireRestart = false)]
    [SettingPropertyGroup("Ranged/Stack count")]
    public int ExtraThrowingAxeStackCount { get; set; } = 0;
    [SettingPropertyInteger("Additional throwing knife stack count", 0, 100, RequireRestart = false)]
    [SettingPropertyGroup("Ranged/Stack count")]
    public int ExtraThrowingKnifeStackCount { get; set; } = 0;

    /// <summary>
    /// /////////////////////////////////////////////////////////// tournament and arena tweak settings
    /// </summary>

    [SettingPropertyBool("Enable tournament tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Tournaments", IsMainToggle = true)]
    public bool TournamentTweaksEnabled { get; set; } = false;

    [SettingPropertyInteger("Tournament max bet amount", 0,99999, valueFormat: "0 Denars", RequireRestart = false)]
    [SettingPropertyGroup("Tournaments", IsMainToggle = false)]
    public int TournamentMaxBet { get; set; } = 150;

    [SettingPropertyFloatingInteger("Tournament combat xp multiplier", 0, 1, RequireRestart = false)]
    [SettingPropertyGroup("Tournaments", IsMainToggle = false)]
    public float TournamentXpMultiplier { get; set; } = 0.33f;

    [SettingPropertyBool("Enable arena tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Practice Arena", IsMainToggle = true)]
    public bool ArenaTweaksEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Practice fight combat xp multiplier", 0, 1, RequireRestart = false)]
    [SettingPropertyGroup("Practice Arena", IsMainToggle = false)]
    public float ArenaXpMultiplier { get; set; } = 1.0f/16.0f;

    /// <summary>
    /// /////////////////////////////////////////////////////////// skill tweak settings
    /// </summary>
    [SettingPropertyBool("Enable skill tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Skills", IsMainToggle = true)]
    public bool SkillTweaksEnabled { get; set; } = false;

    [SettingPropertyBool("Enable Roguery skill tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Skills/Roguery", IsMainToggle = true)]
    public bool RogueryTweaksEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Disguise renown penalty multiplier", 0.0f,1.0f, RequireRestart = false, HintText = "The default penalty (minimum of 15%) will be multiplied by this value before being applied")]
    [SettingPropertyGroup("Skills/Roguery", IsMainToggle = false)]
    public float RogueryRenownDisguisePenaltyMultiplier { get; set; } = 1.0f;

    /// <summary>
    /// /////////////////////////////////////////////////////////// Attribute gain settings
    /// </summary>
    [SettingPropertyBool("Enable focus and attribute point gain modifications", RequireRestart = false)]
    [SettingPropertyGroup("Levelling", IsMainToggle = true)]
    public bool AttributeModificationEnabled { get; set; } = false;
    
    [SettingPropertyBool("Player focus and attribute tweaks enabled", RequireRestart = false)]
    [SettingPropertyGroup("Levelling/Player", IsMainToggle = true)]
    public bool PlayerAttributeModificationEnabled { get; set; } = false;

    [SettingPropertyInteger("Player focus point gain per level", 0, 10, RequireRestart = false)]
    [SettingPropertyGroup("Levelling/Player")]
    public int PlayerFocusPointsPerLevel { get; set; } = 1;
    [SettingPropertyInteger("Player attribute point gain per level", 0, 10, RequireRestart = false, HintText = "How many attribute points to award the player on every level up")]
    [SettingPropertyGroup("Levelling/Player")]
    public int PlayerAttributePointsPerLevel { get; set; } = 0;
    [SettingPropertyInteger("Player attribute point gain per two levels", 0, 10, RequireRestart = false, HintText = "How many attribute points to award the player on levels 0, 2, 4, and so on")]
    [SettingPropertyGroup("Levelling/Player")]
    public int PlayerAttributePointsPerTwoLevels { get; set; } = 0;
    [SettingPropertyInteger("Player attribute point gain per three levels", 0, 10, RequireRestart = false, HintText = "How many attribute points to award the player on levels 0, 3, 6, and so on")]
    [SettingPropertyGroup("Levelling/Player")]
    public int PlayerAttributePointsPerThreeLevels { get; set; } = 1;


    [SettingPropertyBool("Player clan hero focus and attribute tweaks enabled", RequireRestart = false)]
    [SettingPropertyGroup("Levelling/Player clan heroes", IsMainToggle = true)]
    public bool PlayerClanHeroAttributeModificationEnabled { get; set; } = false;

    [SettingPropertyInteger("Player clan hero focus point gain per level", 0, 10, RequireRestart = false)]
    [SettingPropertyGroup("Levelling/Player clan heroes")]
    public int PlayerClanHeroFocusPointsPerLevel { get; set; } = 1;
    [SettingPropertyInteger("Player clan hero attribute point gain per level", 0, 10, RequireRestart = false, HintText = "How many attribute points to award player clan heroes on every level up")]
    [SettingPropertyGroup("Levelling/Player clan heroes")]
    public int PlayerClanHeroAttributePointsPerLevel { get; set; } = 0;
    [SettingPropertyInteger("Player clan hero attribute point gain per two levels", 0, 10, RequireRestart = false, HintText = "How many attribute points to award player clan heroes on levels 0, 2, 4, and so on")]
    [SettingPropertyGroup("Levelling/Player clan heroes")]
    public int PlayerClanHeroAttributePointsPerTwoLevels { get; set; } = 0;
    [SettingPropertyInteger("Player clan hero attribute point gain per three levels", 0, 10, RequireRestart = false, HintText = "How many attribute points to award player clan heroes on levels 0, 3, 6, and so on")]
    [SettingPropertyGroup("Levelling/Player clan heroes")]
    public int PlayerClanHeroAttributePointsPerThreeLevels { get; set; } = 1;


    [SettingPropertyBool("Other clan hero focus and attribute tweaks enabled", RequireRestart = false)]
    [SettingPropertyGroup("Levelling/Other clan heroes", IsMainToggle = true)]
    public bool OtherClanHeroAttributeModificationEnabled { get; set; } = false;

    [SettingPropertyInteger("Other clan hero focus point gain per level", 0, 10, RequireRestart = false)]
    [SettingPropertyGroup("Levelling/Other clan heroes")]
    public int OtherClanHeroFocusPointsPerLevel { get; set; } = 1;
    [SettingPropertyInteger("Other clan hero attribute point gain per level", 0, 10, RequireRestart = false, HintText = "How many attribute points to award other clan heroes on every level up")]
    [SettingPropertyGroup("Levelling/Other clan heroes")]
    public int OtherClanHeroAttributePointsPerLevel { get; set; } = 0;
    [SettingPropertyInteger("Other clan hero attribute point gain per two levels", 0, 10, RequireRestart = false, HintText = "How many attribute points to award other clan heroes on levels 0, 2, 4, and so on")]
    [SettingPropertyGroup("Levelling/Other clan heroes")]
    public int OtherClanHeroAttributePointsPerTwoLevels { get; set; } = 0;
    [SettingPropertyInteger("Other clan hero attribute point gain per three levels", 0, 10, RequireRestart = false, HintText = "How many attribute points to award other clan heroes on levels 0, 3, 6, and so on")]
    [SettingPropertyGroup("Levelling/Other clan heroes")]
    public int OtherClanHeroAttributePointsPerThreeLevels { get; set; } = 1;

    /// <summary>
    /// /////////////////////////////////////////////////////////// Global perk modification enable/disable
    /// </summary>
    [SettingPropertyBool("Enable perk modification", RequireRestart = false)]
    [SettingPropertyGroup("Perks", IsMainToggle = true)]
    public bool PerkModificationEnabled { get; set; } = false;

    /// <summary>
    /// /////////////////////////////////////////////////////////// PLAYER EXP MODIFIERS
    /// </summary>

    [SettingPropertyBool("Enable player exp modification", RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player", IsMainToggle = true)]
    public bool PlayerExpChangeEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Overall player exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player")]
    public float GeneralPlayerExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player One Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float OneHandedPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Two Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float TwoHandedPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Polearm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float PolearmPlayerExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player Bow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float BowPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Crossbow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float CrossbowPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Throwing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float ThrowingPlayerExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player Riding exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float RidingPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Athletics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float AthleticsPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Smithing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float CraftingPlayerExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player Tactics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float TacticsPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Scouting exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float ScoutingPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Roguery exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float RogueryPlayerExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player Leadership exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float LeadershipPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Charm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float CharmPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Trade exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float TradePlayerExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player Steward exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float StewardPlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Medicine exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float MedicinePlayerExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player Engineering exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player/Specific")]
    public float EngineeringPlayerExpGainModifier { get; set; } = 1.0f;


    /// <summary>
    /// /////////////////////////////////////////////////////////// PLAYER CLAN HERO EXP MODIFIERS
    /// </summary>

    [SettingPropertyBool("Enable player clan hero exp modification", HintText = "This will impact all heroes in the player character's clan except the player character", RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes", IsMainToggle = true)]
    public bool PlayerClanExpChangeEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Overall player clan hero exp gain modifier", 0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes")]
    public float GeneralPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero One Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float OneHandedPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Two Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float TwoHandedPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Polearm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float PolearmPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Bow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float BowPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Crossbow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float CrossbowPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Throwing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float ThrowingPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Riding exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float RidingPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Athletics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float AthleticsPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Smithing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float CraftingPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Tactics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float TacticsPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Scouting exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float ScoutingPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Roguery exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float RogueryPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Leadership exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float LeadershipPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Charm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float CharmPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Trade exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float TradePlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Steward exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float StewardPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Medicine exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float MedicinePlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Engineering exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heroes/Specific")]
    public float EngineeringPlayerClanExpGainModifier { get; set; } = 1.0f;


    /// <summary>
    /// /////////////////////////////////////////////////////////// OTHER CLAN HERO EXP MODIFIERS
    /// </summary>


    [SettingPropertyBool("Enable hero exp modification for all other heroes", HintText = "This will impact all heroes other than the main player and the heroes in the main player's clan", RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes", IsMainToggle = true)]
    public bool OtherClanExpChangeEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Overall outside clan hero exp gain modifier",0,10,RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes")]
    public float GeneralOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero One Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float OneHandedOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Two Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float TwoHandedOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Polearm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float PolearmOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Bow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float BowOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Crossbow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float CrossbowOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Throwing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float ThrowingOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Riding exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float RidingOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Athletics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float AthleticsOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Smithing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float CraftingOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Tactics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float TacticsOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Scouting exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float ScoutingOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Roguery exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float RogueryOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Leadership exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float LeadershipOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Charm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float CharmOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Trade exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float TradeOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Steward exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float StewardOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Medicine exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float MedicineOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Engineering exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heroes/Specific")]
    public float EngineeringOtherClanExpGainModifier { get; set; } = 1.0f;


    /// <summary>
    /// /////////////////////////////////////////////////////////// Crafting modifications
    /// </summary>

    [SettingPropertyBool("Enable crafting tweaks", RequireRestart = false)]
    [SettingPropertyGroup("Crafting", IsMainToggle = true)]
    public bool CraftingTweaksEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Crafting stamina usage modifier", 0,1, RequireRestart = false)]
    [SettingPropertyGroup("Crafting")]
    public float CraftingStaminaUsageMultiplier { get; set; } = 1.0f;

    [SettingPropertyBool("Smelting unlocks weapon parts", RequireRestart = false, HintText = "Smelting weapons with this enabled will unlock the weapon parts used in the smelted weapon")]
    [SettingPropertyGroup("Crafting")]
    public bool SmeltingUnlocksWeaponParts { get; set; } = false;

    [SettingPropertyBool("Show all crafting pieces", RequireRestart = false, HintText = "Many default crafting pieces are disabled for use in crafting, this enables them")]
    [SettingPropertyGroup("Crafting")]
    public bool ShowAllCraftingPieces { get; set; } = false;

    [SettingPropertyBool("Fix order failure condition", RequireRestart = false, HintText = "Some crafting orders fail if the request doesn't contain a damage type but the crafted weapon does (eg if they want high swing damage polearm and you meet the stats but also have thrust). This fixes that")]
    [SettingPropertyGroup("Crafting")]
    public bool OrderFailureCorrect { get; set; } = false;
  }


}
