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
  public class HideoutMapFactionPatch
  {
    static void Postfix(ref DefaultPerks __instance)
    {
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
    /// /////////////////////////////////////////////////////////// PLAYER EXP MODIFIERS
    /// </summary>

    [SettingPropertyBool("Enable player exp modification", RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player")]
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

    [SettingPropertyBool("Enable player clan hero exp modification", HintText = "This will impact all heros in the player character's clan except the player character", RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros")]
    public bool PlayerClanExpChangeEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Overall player clan hero exp gain modifier", 0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros")]
    public float GeneralPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero One Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float OneHandedPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Two Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float TwoHandedPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Polearm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float PolearmPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Bow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float BowPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Crossbow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float CrossbowPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Throwing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float ThrowingPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Riding exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float RidingPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Athletics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float AthleticsPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Smithing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float CraftingPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Tactics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float TacticsPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Scouting exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float ScoutingPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Roguery exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float RogueryPlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Leadership exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float LeadershipPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Charm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float CharmPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Trade exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float TradePlayerClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Player clan hero Steward exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float StewardPlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Medicine exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float MedicinePlayerClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Player clan hero Engineering exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Player clan heros/Specific")]
    public float EngineeringPlayerClanExpGainModifier { get; set; } = 1.0f;


    /// <summary>
    /// /////////////////////////////////////////////////////////// OTHER CLAN HERO EXP MODIFIERS
    /// </summary>


    [SettingPropertyBool("Enable hero exp modification for all other heros", HintText = "This will impact all heros other than the main player and the heros in the main player's clan", RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros")]
    public bool OtherClanExpChangeEnabled { get; set; } = false;

    [SettingPropertyFloatingInteger("Overall outside clan hero exp gain modifier",0,10,RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros")]
    public float GeneralOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero One Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float OneHandedOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Two Handed exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float TwoHandedOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Polearm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float PolearmOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Bow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float BowOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Crossbow exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float CrossbowOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Throwing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float ThrowingOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Riding exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float RidingOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Athletics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float AthleticsOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Smithing exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float CraftingOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Tactics exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float TacticsOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Scouting exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float ScoutingOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Roguery exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float RogueryOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Leadership exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float LeadershipOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Charm exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float CharmOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Trade exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float TradeOtherClanExpGainModifier { get; set; } = 1.0f;

    [SettingPropertyFloatingInteger("Outside clan hero Steward exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float StewardOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Medicine exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float MedicineOtherClanExpGainModifier { get; set; } = 1.0f;
    [SettingPropertyFloatingInteger("Outside clan hero Engineering exp gain modifier",0,10, RequireRestart=false)]
    [SettingPropertyGroup("Experience Modifiers/Other heros/Specific")]
    public float EngineeringOtherClanExpGainModifier { get; set; } = 1.0f;
  }


}
