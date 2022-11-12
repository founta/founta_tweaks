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
using SandBox.View.Map;

using HarmonyLib;


namespace FountaTweaks
{

  public class FountaTweaks : MBSubModuleBase
  {
    internal static Harmony harmony = null;
    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
      Harmony.DEBUG = true;
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      base.OnBeforeInitialModuleScreenSetAsRoot();

      //InformationManager.DisplayMessage(new InformationMessage($"Founta's Tweaks {FountaTweaksSettings.Instance.version} for Bannerlord 1.7.0"));

      if (harmony == null)
      {
        harmony = new Harmony("FountaTweaks"); //TODO change this
        harmony.PatchAll();
      }
    }

    protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
    {
      if (!(game.GameType is Campaign))
        return;
    }
  }
}
