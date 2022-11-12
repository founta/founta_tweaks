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
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using SandBox.Source.Missions;

using TaleWorlds.ObjectSystem;

using HarmonyLib;

using System.Xml;


namespace FountaTweaks
{
  //change the amount of focus/attribute points gained on level up
  [HarmonyPatch(typeof(HeroDeveloper), "OnGainLevel")]
  public class LevelUpOverride
  {
    static bool Prefix(HeroDeveloper __instance,
      bool shouldNotify)
    {
      FountaTweaksSettings s = FountaTweaksSettings.Instance;

      //skip this prefix if override is disabled
      if (!s.AttributeModificationEnabled)
        return true;

      bool player = s.PlayerAttributeModificationEnabled;
      bool playerclan = s.PlayerClanHeroAttributeModificationEnabled;
      bool otherclan = s.OtherClanHeroAttributeModificationEnabled;

      if (!player && !playerclan && !otherclan)
        return true;

      int focus_points = 1, attr_m1 = 0, attr_m2 = 0, attr_m3 = 1;
      int attr = 0;
      Hero h = __instance.Hero;

      //see how many points we need to add
      bool do_modification = false;
      if (h == Hero.MainHero && player) //main hero
      {
        do_modification = true;

        focus_points = s.PlayerFocusPointsPerLevel;
        attr_m1 = s.PlayerAttributePointsPerLevel;
        attr_m2 = s.PlayerAttributePointsPerTwoLevels;
        attr_m3 = s.PlayerAttributePointsPerThreeLevels;
      }
      else if (h.Clan == Clan.PlayerClan && playerclan && h != Hero.MainHero) //main hero clan heros
      {
        do_modification = true;

        focus_points = s.PlayerClanHeroFocusPointsPerLevel;
        attr_m1 = s.PlayerClanHeroAttributePointsPerLevel;
        attr_m2 = s.PlayerClanHeroAttributePointsPerTwoLevels;
        attr_m3 = s.PlayerClanHeroAttributePointsPerThreeLevels;
      }
      else if (otherclan && h.Clan != Clan.PlayerClan && h != Hero.MainHero) //everyone else
      {
        do_modification = true;

        focus_points = s.OtherClanHeroFocusPointsPerLevel;
        attr_m1 = s.OtherClanHeroAttributePointsPerLevel;
        attr_m2 = s.OtherClanHeroAttributePointsPerTwoLevels;
        attr_m3 = s.OtherClanHeroAttributePointsPerThreeLevels;
      }

      //actually do the point adding
      if (do_modification)
      {
        //InformationManager.DisplayMessage(new InformationMessage($"Adding {focus_points} focus"));
        __instance.UnspentFocusPoints += focus_points;

        attr += attr_m1;
        if ((h.Level % 2) == 0)
          attr += attr_m2;
        if ((h.Level % 3) == 0)
          attr += attr_m3;

        //InformationManager.DisplayMessage(new InformationMessage($"Adding {attr} attr"));
        __instance.UnspentAttributePoints += attr;

        CampaignEventDispatcher.Instance.OnHeroLevelledUp(h, shouldNotify);
      }

      return !do_modification; //don't run the original OnGainLevel if we already made the modifications
    }
  }

}