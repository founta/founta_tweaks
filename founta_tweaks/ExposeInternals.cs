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
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.AiBehaviors;
using SandBox.View.Map;

using HarmonyLib;

namespace FountaTweaks
{
  [HarmonyPatch]
  public class ExposeInternals
  {
    [HarmonyReversePatch]
    [HarmonyPatch(typeof(PerkObject), "PrimaryBonus")]
    [HarmonyPatch(MethodType.Setter)]
    public static void SetPrimaryBonus(PerkObject instance, float value)
    {
      return;
    }

    [HarmonyReversePatch]
    [HarmonyPatch(typeof(PerkObject), "SecondaryBonus")]
    [HarmonyPatch(MethodType.Setter)]
    public static void SetSecondaryBonus(PerkObject instance, float value)
    {
      return;
    }
  }


}
