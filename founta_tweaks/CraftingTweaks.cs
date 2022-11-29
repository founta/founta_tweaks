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
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.CampaignSystem.GameComponents;

using TaleWorlds.ObjectSystem;

using HarmonyLib;

using System.Xml;


namespace FountaTweaks
{
  //lower the amount of crafting stamina used if enabled
  [HarmonyPatch(typeof(CraftingCampaignBehavior), "SetHeroCraftingStamina")]
  public class CraftingStaminaReductionPatch
  {
    static void Prefix(CraftingCampaignBehavior __instance,
      Hero hero, ref int value)
    {
      //InformationManager.DisplayMessage(new InformationMessage($"set stam patch"));

      if (!FountaTweaksSettings.Instance.CraftingTweaksEnabled)
        return;
      float multiplier = FountaTweaksSettings.Instance.CraftingStaminaUsageMultiplier;
      int original_crafting_stamina = __instance.GetHeroCraftingStamina(hero);

      int stam_loss = original_crafting_stamina - value;
      if (stam_loss < 0) //then we are gaining stamina, early exit
        return;

      value = original_crafting_stamina - (int)(stam_loss * multiplier);
      //InformationManager.DisplayMessage(new InformationMessage($"multiplier {multiplier} before {original_crafting_stamina} after {value}"));
    }
  }

  //lower the amount of crafting stamina used if enabled
  [HarmonyPatch(typeof(CraftingPiece), "IsHiddenOnDesigner")]
  [HarmonyPatch(MethodType.Getter)]
  public class CraftingPartDisplayPatch
  {
    static void Postfix(CraftingPiece __instance,
      ref bool __result)
    {
      //InformationManager.DisplayMessage(new InformationMessage($"set stam patch"));

      if (!FountaTweaksSettings.Instance.CraftingTweaksEnabled)
        return;
      if (!FountaTweaksSettings.Instance.ShowAllCraftingPieces)
        return;

      __result = false;
    }
  }

  //unlock all of the crafting parts in a weapon when smelting it, if enabled.
  [HarmonyPatch(typeof(CraftingCampaignBehavior), "DoSmelting")]
  public class SmeltingUnlocksPartsPatch
  {
    static void Postfix(CraftingCampaignBehavior __instance,
      Hero hero, EquipmentElement equipmentElement)
    {
      //InformationManager.DisplayMessage(new InformationMessage($"do smelt patch"));

      if (!FountaTweaksSettings.Instance.CraftingTweaksEnabled)
        return;
      if (!FountaTweaksSettings.Instance.SmeltingUnlocksWeaponParts)
        return;

      ref Dictionary<CraftingTemplate, List<CraftingPiece>> _openedParts = ref AccessTools.FieldRefAccess<CraftingCampaignBehavior, Dictionary<CraftingTemplate,List<CraftingPiece>>>(__instance, "_openedPartsDictionary");
      ref Dictionary<CraftingTemplate, float> _openedPartXp = ref AccessTools.FieldRefAccess<CraftingCampaignBehavior, Dictionary<CraftingTemplate, float>>(__instance, "_openNewPartXpDictionary");

      //InformationManager.DisplayMessage(new InformationMessage($"has weapon comp {equipmentElement.Item.HasWeaponComponent}"));
      if (equipmentElement.Item.HasWeaponComponent)
      {
        CraftingTemplate template = equipmentElement.Item.WeaponDesign.Template;
        if (!_openedParts.ContainsKey(template))
        {
          _openedParts.Add(template, new List<CraftingPiece>());
          _openedPartXp.Add(template, 0.0f);
        }

        //InformationManager.DisplayMessage(new InformationMessage($"{equipmentElement.Item.WeaponDesign.UsedPieces.Length} weapon comps"));
        foreach (WeaponDesignElement elem in equipmentElement.Item.WeaponDesign.UsedPieces)
        {
          CraftingPiece p = elem.CraftingPiece;

          if (!_openedParts[template].Contains(p))
          {
            //InformationManager.DisplayMessage(new InformationMessage($"opened part!"));
            ExposeInternals.OpenPart(__instance, p, template, true);
          }
        }
      }
    }//end postfix
  }

  //allow changing the number of modifier points added for fine, legendary or masterwork weapons if enabled
  [HarmonyPatch(typeof(DefaultSmithingModel), "GetPointsToModify")]
  public class WeaponTierPointPatch
  {
    static void Postfix(DefaultSmithingModel __instance, int modifierTier, ref int __result)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;
      if (s.WeaponTierTweaksEnabled)
      {
        switch(modifierTier)
        {
          case 1:
            __result += s.FineWeaponBonusPoints;
            break;
          case 2:
            __result += s.MasterworkWeaponBonusPoints;
            break;
          case 3:
            __result += s.LegendaryWeaponBonusPoints;
            break;
        }
      }
    }
  }


}