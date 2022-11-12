using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core.ViewModelCollection;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.Library;
using TaleWorlds.Engine;

using SandBox.Source.Missions;

using TaleWorlds.ObjectSystem;

using HarmonyLib;

using System.Xml;


namespace FountaTweaks
{
  //change the amount of focus/attribute points gained on level up
  [HarmonyPatch(typeof(DefaultDisguiseDetectionModel), "CalculateDisguiseDetectionProbability")]
  public class DisguiseRenownPenaltyPatch
  {
    static void Postfix(DefaultDisguiseDetectionModel __instance,
      Settlement settlement, ref float __result)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;

      //skip this if disabled
      if (!s.SkillTweaksEnabled)
        return;
      if (!s.RogueryTweaksEnabled)
        return;

      float original_penalty = Math.Max(0.15f, 0.00015f * Clan.PlayerClan.Renown);
      float correction = (1.0f - s.RogueryRenownDisguisePenaltyMultiplier) * original_penalty;

      __result = MathF.Clamp(__result + correction, 0, 1);
    }
  }

}