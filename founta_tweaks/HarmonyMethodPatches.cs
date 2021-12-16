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

namespace FountaTweaks
{
  //apply the user's saved perk settings (if any) right after initialization
  [HarmonyPatch(typeof(DefaultPerks), "InitializeAll")]
  public class HideoutMapFactionPatch
  {
    static void Postfix(ref DefaultPerks __instance)
    {
      AutoFountaTweaksSettings.Instance.SetAll(ref __instance);
    }
  }
}
