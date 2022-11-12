using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;

using SandBox.Tournaments.MissionLogics;

using HarmonyLib;

namespace FountaTweaks
{
  //change the maxumum tournament bet you can place
  [HarmonyPatch(typeof(TournamentBehavior), "GetMaximumBet")]
  public class TournamentBetAmountPatch
  {
    static bool Prefix(TournamentBehavior __instance,
      ref int __result)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;

      //skip this and do the default if disabled
      if (!s.TournamentTweaksEnabled)
        return true;

      //pretty much the same as the original function but replaced with the custom max bet amount
      int max_bet_amount = s.TournamentMaxBet;
      if (Hero.MainHero.GetPerkValue(DefaultPerks.Roguery.DeepPockets))
        max_bet_amount *= (int)DefaultPerks.Roguery.DeepPockets.PrimaryBonus;
      __result = max_bet_amount;

      return false; //don't run the original method
    }
  }

  //change the combat xp gain in tournaments and in the practice arena
  [HarmonyPatch(typeof(DefaultCombatXpModel), "GetXpFromHit")]
  public class DefaultArenaTournamentHitExpPatch
  {
    static void Postfix(TournamentBehavior __instance,
      CharacterObject attackerTroop,
      CharacterObject captain,
      CharacterObject attackedTroop,
      PartyBase party,
      int damage,
      bool isFatal,
      CombatXpModel.MissionTypeEnum missionType,
      ref int xpAmount)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;

      //skip this if disabled
      if (!s.TournamentTweaksEnabled && !s.ArenaTweaksEnabled)
        return;

      bool do_modification = false;
      float multiplier = 1;

      float default_tourn_multiplier = 0.33f;
      float default_arena_multiplier = 1.0f / 16.0f;

      if (missionType == CombatXpModel.MissionTypeEnum.Tournament && s.TournamentTweaksEnabled)
      {
        do_modification = true;

        //first we want to undo the default tournament multiplier
        multiplier *= 1 / default_tourn_multiplier;

        //now apply the new tournament multiplier
        multiplier *= s.TournamentXpMultiplier;
      }
      else if (missionType == CombatXpModel.MissionTypeEnum.PracticeFight && s.ArenaTweaksEnabled)
      {
        do_modification = true;

        //first we want to undo the default arena multiplier
        multiplier *= 1 / default_arena_multiplier;

        //now apply the new arena multiplier
        multiplier *= s.ArenaXpMultiplier;
      }

      if (do_modification)
      {
        xpAmount = (int)(xpAmount*multiplier);
      }
    }
  }

}