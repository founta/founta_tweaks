using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.SandBox;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.AiBehaviors;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.BarterBehaviors;
using TaleWorlds.CampaignSystem.Barterables;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core.ViewModelCollection;
using SandBox.ViewModelCollection.MobilePartyTracker;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.Library;
using TaleWorlds.Engine;

using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using SandBox.Source.Missions;

using TaleWorlds.ObjectSystem;

using HarmonyLib;

using System.Xml;


namespace FountaTweaks
{
  //amplify any skill XP gain based on the tweaks settings
  [HarmonyPatch(typeof(HeroDeveloper), "AddSkillXp")]
  public class SkillXpPatch
  {
    static void Prefix(HeroDeveloper __instance,
      SkillObject skill,
      ref float rawXp,
      bool isAffectedByFocusFactor,
      bool shouldNotify)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;
      float multiplier=1, onehanded=1, twohanded=1, polearm=1, bow=1, crossbow=1, throwing=1,
            riding=1, athletics=1, crafting=1, tactics=1, scouting=1, roguery=1,
            leadership=1, charm=1, trade=1, steward=1, medicine=1, engineering=1;
      Hero h = __instance.Hero;
      bool boost_exp = false;
      if (s.PlayerExpChangeEnabled && h == Hero.MainHero)
      {
        boost_exp = true;

        multiplier = s.GeneralPlayerExpGainModifier;
        onehanded = s.OneHandedPlayerExpGainModifier;
        twohanded = s.TwoHandedPlayerExpGainModifier;
        polearm = s.PolearmPlayerExpGainModifier;
        bow = s.BowPlayerExpGainModifier;
        crossbow = s.CrossbowPlayerExpGainModifier;
        throwing = s.ThrowingPlayerExpGainModifier;
        riding = s.RidingPlayerExpGainModifier;
        athletics = s.AthleticsPlayerExpGainModifier;
        crafting = s.CraftingPlayerExpGainModifier;
        tactics = s.TacticsPlayerExpGainModifier;
        scouting = s.ScoutingPlayerExpGainModifier;
        roguery = s.RogueryPlayerExpGainModifier;
        leadership = s.LeadershipPlayerExpGainModifier;
        charm = s.CharmPlayerExpGainModifier;
        trade = s.TradePlayerExpGainModifier;
        steward = s.StewardPlayerExpGainModifier;
        medicine = s.MedicinePlayerExpGainModifier;
        engineering = s.EngineeringPlayerExpGainModifier;
      }
      else if (s.PlayerClanExpChangeEnabled && h.Clan == Clan.PlayerClan && h != Hero.MainHero)
      {
        boost_exp = true;

        multiplier = s.GeneralPlayerClanExpGainModifier;
        onehanded = s.OneHandedPlayerClanExpGainModifier;
        twohanded = s.TwoHandedPlayerClanExpGainModifier;
        polearm = s.PolearmPlayerClanExpGainModifier;
        bow = s.BowPlayerClanExpGainModifier;
        crossbow = s.CrossbowPlayerClanExpGainModifier;
        throwing = s.ThrowingPlayerClanExpGainModifier;
        riding = s.RidingPlayerClanExpGainModifier;
        athletics = s.AthleticsPlayerClanExpGainModifier;
        crafting = s.CraftingPlayerClanExpGainModifier;
        tactics = s.TacticsPlayerClanExpGainModifier;
        scouting = s.ScoutingPlayerClanExpGainModifier;
        roguery = s.RogueryPlayerClanExpGainModifier;
        leadership = s.LeadershipPlayerClanExpGainModifier;
        charm = s.CharmPlayerClanExpGainModifier;
        trade = s.TradePlayerClanExpGainModifier;
        steward = s.StewardPlayerClanExpGainModifier;
        medicine = s.MedicinePlayerClanExpGainModifier;
        engineering = s.EngineeringPlayerClanExpGainModifier;
      }
      else if (s.OtherClanExpChangeEnabled && h != Hero.MainHero && h.Clan != Clan.PlayerClan)
      {
        boost_exp = true;

        multiplier = s.GeneralOtherClanExpGainModifier;
        onehanded = s.OneHandedOtherClanExpGainModifier;
        twohanded = s.TwoHandedOtherClanExpGainModifier;
        polearm = s.PolearmOtherClanExpGainModifier;
        bow = s.BowOtherClanExpGainModifier;
        crossbow = s.CrossbowOtherClanExpGainModifier;
        throwing = s.ThrowingOtherClanExpGainModifier;
        riding = s.RidingOtherClanExpGainModifier;
        athletics = s.AthleticsOtherClanExpGainModifier;
        crafting = s.CraftingOtherClanExpGainModifier;
        tactics = s.TacticsOtherClanExpGainModifier;
        scouting = s.ScoutingOtherClanExpGainModifier;
        roguery = s.RogueryOtherClanExpGainModifier;
        leadership = s.LeadershipOtherClanExpGainModifier;
        charm = s.CharmOtherClanExpGainModifier;
        trade = s.TradeOtherClanExpGainModifier;
        steward = s.StewardOtherClanExpGainModifier;
        medicine = s.MedicineOtherClanExpGainModifier;
        engineering = s.EngineeringOtherClanExpGainModifier;
      }

      if (boost_exp)
      {
        if (skill == DefaultSkills.OneHanded)
          multiplier *= onehanded;
        else if (skill == DefaultSkills.TwoHanded)
          multiplier *= twohanded;
        else if (skill == DefaultSkills.Polearm)
          multiplier *= polearm;
        else if (skill == DefaultSkills.Bow)
          multiplier *= bow;
        else if (skill == DefaultSkills.Crossbow)
          multiplier *= crossbow;
        else if (skill == DefaultSkills.Throwing)
          multiplier *= throwing;
        else if (skill == DefaultSkills.Riding)
          multiplier *= riding;
        else if (skill == DefaultSkills.Athletics)
          multiplier *= athletics;
        else if (skill == DefaultSkills.Crafting)
          multiplier *= crafting;
        else if (skill == DefaultSkills.Tactics)
          multiplier *= tactics;
        else if (skill == DefaultSkills.Scouting)
          multiplier *= scouting;
        else if (skill == DefaultSkills.Roguery)
          multiplier *= roguery;
        else if (skill == DefaultSkills.Leadership)
          multiplier *= leadership;
        else if (skill == DefaultSkills.Charm)
          multiplier *= charm;
        else if (skill == DefaultSkills.Trade)
          multiplier *= trade;
        else if (skill == DefaultSkills.Steward)
          multiplier *= steward;
        else if (skill == DefaultSkills.Medicine)
          multiplier *= medicine;
        else if (skill == DefaultSkills.Engineering)
          multiplier *= engineering;

        rawXp *= multiplier;
      }
    }//end prefix
  }//end harmony patch class


}