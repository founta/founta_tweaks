﻿using System;
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

using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using SandBox.TournamentMissions.Missions;

using SandBox;

using HarmonyLib;

namespace FountaTweaks
{
  //let the user use the arrow barrel if they have a throwing weapon
  [HarmonyPatch(typeof(StandingPointWithWeaponRequirement), "IsDisabledForAgent")]
  public class WeaponStandingPointThrowingPatch
  {
    static void Postfix(StandingPointWithWeaponRequirement __instance, Agent agent,
      ref bool __result)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;
      //skip this if disabled
      if (!s.RangedTweaksEnabled)
        return;
      if (!s.ArrowBarrelRefillThrowing)
        return;

      ref WeaponClass _requiredWeaponClass1 = ref AccessTools.FieldRefAccess<StandingPointWithWeaponRequirement, WeaponClass>(__instance, "_requiredWeaponClass1");
      if (__result == true && _requiredWeaponClass1 == WeaponClass.Arrow) //then it is an arrow barrel and it has been disabled for use
      {
        List<WeaponClass> allowed_types = new List<WeaponClass> { WeaponClass.Javelin, WeaponClass.ThrowingAxe, WeaponClass.ThrowingKnife };
        for (EquipmentIndex idx = EquipmentIndex.WeaponItemBeginSlot; idx < EquipmentIndex.NumAllWeaponSlots; ++idx)
        {
          if (!agent.Equipment[idx].IsEmpty && allowed_types.Contains(agent.Equipment[idx].CurrentUsageItem.WeaponClass)) //then it is a throwing weapon
          {
            __result =  ExposeInternals.BaseIsDisabledForAgent(__instance, agent);
            return;
          }
        }
      }

    }
  }

  //replenish the user's throwing ammo on using the arrow barrel
  [HarmonyPatch(typeof(ArrowBarrel), "OnTick")]
  public class ArrowBarrelThrowingRefillPatch
  {
    static bool isUsingArrowBarrel;
    static Agent agent;

    //check if the user is using an arrow barrel
    static void Prefix(ArrowBarrel __instance, float dt)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;
      //skip this if disabled
      if (!s.RangedTweaksEnabled)
        return;
      if (!s.ArrowBarrelRefillThrowing)
        return;

      ref ActionIndexCache act_pickup_down_begin = ref AccessTools.StaticFieldRefAccess<ArrowBarrel, ActionIndexCache>("act_pickup_down_begin");
      ref ActionIndexCache act_pickup_down_begin_left_stance = ref AccessTools.StaticFieldRefAccess<ArrowBarrel, ActionIndexCache>("act_pickup_down_begin_left_stance");
      ref ActionIndexCache act_pickup_down_end = ref AccessTools.StaticFieldRefAccess<ArrowBarrel, ActionIndexCache>("act_pickup_down_end");
      ref ActionIndexCache act_pickup_down_end_left_stance = ref AccessTools.StaticFieldRefAccess<ArrowBarrel, ActionIndexCache>("act_pickup_down_end_left_stance");

      isUsingArrowBarrel = false;
      foreach (StandingPoint standingPoint in __instance.StandingPoints)
      {
        if (standingPoint.HasUser)
        {
          Agent userAgent = standingPoint.UserAgent;
          ActionIndexCache currentAction1 = userAgent.GetCurrentAction(0);
          ActionIndexCache currentAction2 = userAgent.GetCurrentAction(1);
          if (!(currentAction2 == ActionIndexCache.act_none) || !(currentAction1 == act_pickup_down_begin) && !(currentAction1 == act_pickup_down_begin_left_stance))
          {
            if (currentAction2 == ActionIndexCache.act_none && (currentAction1 == act_pickup_down_end || currentAction1 == act_pickup_down_end_left_stance))
            {
              isUsingArrowBarrel = true;
              agent = userAgent;
              break;
            }
          }
        }
      }
    }//end prefix

    //refill the user's throwing ammo if using an arrow barrel
    static void Postfix(ArrowBarrel __instance, float dt)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;
      //skip this if disabled
      if (!s.RangedTweaksEnabled)
        return;
      if (!s.ArrowBarrelRefillThrowing)
        return;

      if (!isUsingArrowBarrel)
        return;

      List<WeaponClass> allowed_types = new List<WeaponClass> { WeaponClass.Javelin, WeaponClass.ThrowingAxe, WeaponClass.ThrowingKnife };
      
      for (EquipmentIndex index = EquipmentIndex.WeaponItemBeginSlot; index < EquipmentIndex.NumAllWeaponSlots; ++index)
      {
        MissionWeapon missionWeapon = agent.Equipment[index];
        if (!missionWeapon.IsEmpty && allowed_types.Contains(missionWeapon.CurrentUsageItem.WeaponClass))
        {
          if (missionWeapon.Amount < missionWeapon.ModifiedMaxAmount)
            agent.SetWeaponAmountInSlot(index, missionWeapon.ModifiedMaxAmount, false);
        }
      }
    }//end postfix
  }

  //add extra item stack counts
  [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), "InitializeMissionEquipment")]
  public class ExtraStackCountPatch
  {
    static void Postfix(SandboxAgentStatCalculateModel __instance, Agent agent)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;
      //skip this if disabled
      if (!s.RangedTweaksEnabled)
        return;
      if (!s.StackCountTweaksEnabled)
        return;

      if (!agent.IsHuman || !(agent.Character is CharacterObject character))
        return;
      MissionEquipment equipment = agent.Equipment;
      for (int i = 0; i < 5; ++i)
      {
        int extra_stack_count = 0;

        EquipmentIndex equipmentIndex = (EquipmentIndex)i;
        MissionWeapon missionWeapon = equipment[equipmentIndex];
        if (!missionWeapon.IsEmpty)
        {
          WeaponComponentData currentUsageItem = missionWeapon.CurrentUsageItem;
          if (currentUsageItem != null)
          {
            switch(currentUsageItem.WeaponClass)
            {
              case WeaponClass.Arrow:
                extra_stack_count = s.ExtraArrowStackCount;
                break;
              case WeaponClass.Bolt:
                extra_stack_count = s.ExtraBoltStackCount;
                break;
              case WeaponClass.ThrowingAxe:
                extra_stack_count = s.ExtraThrowingAxeStackCount;
                break;
              case WeaponClass.ThrowingKnife:
                extra_stack_count = s.ExtraThrowingKnifeStackCount;
                break;
              case WeaponClass.Javelin:
                extra_stack_count = s.ExtraJavelinStackCount;
                break;
              default:
                break;
            }
          }
          if (extra_stack_count != 0)
          {
            equipment.SetAmountOfSlot(equipmentIndex, (short)(missionWeapon.Amount + extra_stack_count), true);
          }
        }
      }

    }
  }

}