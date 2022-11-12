using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using SandBox.Source.Missions;

using TaleWorlds.ObjectSystem;

using HarmonyLib;

using System.Xml;

namespace FountaTweaks
{
  [HarmonyPatch]
  public class ExposeInternals
  {
    [HarmonyReversePatch]
    [HarmonyPatch(typeof(StandingPoint), "IsDisabledForAgent")]
    public static bool BaseIsDisabledForAgent(StandingPoint instance, Agent agent)
    {
      return true;
    }

    [HarmonyReversePatch]
    [HarmonyPatch(typeof(PerkObject), "PrimaryBonus", MethodType.Setter)]
    public static void SetPrimaryBonus(PerkObject instance, float value)
    {
      return;
    }

    [HarmonyReversePatch]
    [HarmonyPatch(typeof(PerkObject), "SecondaryBonus", MethodType.Setter)]
    public static void SetSecondaryBonus(PerkObject instance, float value)
    {
      return;
    }

    [HarmonyReversePatch]
    [HarmonyPatch(typeof(CraftingCampaignBehavior), "OpenPart")]
    public static void OpenPart(CraftingCampaignBehavior instance, CraftingPiece selectedPiece, CraftingTemplate craftingTemplate, bool showNotification)
    {
      return;
    }
  }


}
