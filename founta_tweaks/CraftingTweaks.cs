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

      ExposeInternals.EnsureParts(__instance);
      ref List<CraftingPiece> _openedParts = ref AccessTools.FieldRefAccess<CraftingCampaignBehavior, List<CraftingPiece>>(__instance, "_openedParts");

      //InformationManager.DisplayMessage(new InformationMessage($"has weapon comp {equipmentElement.Item.HasWeaponComponent}"));
      if (equipmentElement.Item.HasWeaponComponent)
      {
        //InformationManager.DisplayMessage(new InformationMessage($"{equipmentElement.Item.WeaponDesign.UsedPieces.Length} weapon comps"));
        foreach (WeaponDesignElement elem in equipmentElement.Item.WeaponDesign.UsedPieces)
        {
          CraftingPiece p = elem.CraftingPiece;
          if (!_openedParts.Contains(p))
          {
            //InformationManager.DisplayMessage(new InformationMessage($"opened part!"));
            ExposeInternals.OpenPart(__instance, p, true);
          }
        }
      }
    }//end postfix
  }

}