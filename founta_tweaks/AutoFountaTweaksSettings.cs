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

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

using System.Xml;

using HarmonyLib;

namespace FountaTweaks
{
  public abstract class AutoFountaTweaksSettings<T> : AttributeGlobalSettings<T> where T : AutoFountaTweaksSettings<T>, new()
  {
    private float _oh_Deflect_p = 20.000000f;
    private float _oh_Deflect_s = 30.000000f;
    private float _oh_Basher_p = 50.000000f;
    private float _oh_Basher_s = -4.000000f;
    private float _oh_ToBeBlunt_p = 5.000000f;
    private float _oh_ToBeBlunt_s = 0.500000f;
    private float _oh_SwiftStrike_p = 0.020000f;
    private float _oh_SwiftStrike_s = 0.500000f;
    private float _oh_Cavalry_p = 5.000000f;
    private float _oh_Cavalry_s = 5.000000f;
    private float _oh_ShieldBearer_p = 0.000000f;
    private float _oh_ShieldBearer_s = 3.000000f;
    private float _oh_Trainer_p = 2.000000f;
    private float _oh_Trainer_s = 5.000000f;
    private float _oh_Duelist_p = 20.000000f;
    private float _oh_Duelist_s = 1.000000f;
    private float _oh_ShieldWall_p = -20.000000f;
    private float _oh_ShieldWall_s = 0.010000f;
    private float _oh_ArrowCatcher_p = 0.010000f;
    private float _oh_ArrowCatcher_s = 0.010000f;
    private float _oh_MilitaryTradition_p = 2.000000f;
    private float _oh_MilitaryTradition_s = -5.000000f;
    private float _oh_CorpsACorps_p = 10.000000f;
    private float _oh_CorpsACorps_s = 30.000000f;
    private float _oh_StandUnited_p = 8.000000f;
    private float _oh_StandUnited_s = 30.000000f;
    private float _oh_LeadByExample_p = 5.000000f;
    private float _oh_LeadByExample_s = 5.000000f;
    private float _oh_SteelCoreShields_p = -10.000000f;
    private float _oh_SteelCoreShields_s = -10.000000f;
    private float _oh_FleetOfFoot_p = 5.000000f;
    private float _oh_FleetOfFoot_s = 4.000000f;
    private float _oh_DeadlyPurpose_p = 5.000000f;
    private float _oh_DeadlyPurpose_s = 10.000000f;
    private float _oh_UnwaveringDefense_p = 5.000000f;
    private float _oh_UnwaveringDefense_s = 10.000000f;
    private float _oh_Prestige_p = 50.000000f;
    private float _oh_Prestige_s = 15.000000f;
    private float _oh_ChinkInTheArmor_p = -10.000000f;
    private float _oh_ChinkInTheArmor_s = -20.000000f;
    private float _oh_WayOfTheSword_p = 0.200000f;
    private float _oh_WayOfTheSword_s = 0.500000f;
    private float _twh_StrongGrip_p = 0.100000f;
    private float _twh_StrongGrip_s = 30.000000f;
    private float _twh_WoodChopper_p = 30.000000f;
    private float _twh_WoodChopper_s = 15.000000f;
    private float _twh_OnTheEdge_p = 3.000000f;
    private float _twh_OnTheEdge_s = 2.000000f;
    private float _twh_HeadBasher_p = 10.000000f;
    private float _twh_HeadBasher_s = 2.000000f;
    private float _twh_ShowOfStrength_p = 30.000000f;
    private float _twh_ShowOfStrength_s = -20.000000f;
    private float _twh_BaptisedInBlood_p = 5.000000f;
    private float _twh_BaptisedInBlood_s = 5.000000f;
    private float _twh_BeastSlayer_p = 50.000000f;
    private float _twh_BeastSlayer_s = 10.000000f;
    private float _twh_ShieldBreaker_p = 40.000000f;
    private float _twh_ShieldBreaker_s = 10.000000f;
    private float _twh_Berserker_p = 20.000000f;
    private float _twh_Berserker_s = -10.000000f;
    private float _twh_Confidence_p = 15.000000f;
    private float _twh_ArrowDeflection_p = 0.000000f;
    private float _twh_ArrowDeflection_s = 10.000000f;
    private float _twh_Terror_p = 20.000000f;
    private float _twh_Terror_s = 10.000000f;
    private float _twh_Hope_p = 30.000000f;
    private float _twh_Hope_s = 5.000000f;
    private float _twh_RecklessCharge_p = 20.000000f;
    private float _twh_RecklessCharge_s = 2.000000f;
    private float _twh_ThickHides_p = 5.000000f;
    private float _twh_ThickHides_s = 5.000000f;
    private float _twh_BladeMaster_p = 10.000000f;
    private float _twh_BladeMaster_s = 2.000000f;
    private float _twh_Vandal_p = -25.000000f;
    private float _twh_Vandal_s = 20.000000f;
    private float _twh_WayOfTheGreatAxe_p = 0.200000f;
    private float _twh_WayOfTheGreatAxe_s = 0.500000f;
    private float _plm_Pikeman_p = 2.000000f;
    private float _plm_Pikeman_s = 2.000000f;
    private float _plm_Cavalry_p = 2.000000f;
    private float _plm_Cavalry_s = 2.000000f;
    private float _plm_Braced_p = 25.000000f;
    private float _plm_Braced_s = 10.000000f;
    private float _plm_KeepAtBay_p = 30.000000f;
    private float _plm_KeepAtBay_s = 0.500000f;
    private float _plm_SwiftSwing_p = 5.000000f;
    private float _plm_SwiftSwing_s = 2.000000f;
    private float _plm_CleanThrust_p = 10.000000f;
    private float _plm_CleanThrust_s = 30.000000f;
    private float _plm_Footwork_p = 2.000000f;
    private float _plm_Footwork_s = 2.000000f;
    private float _plm_HardKnock_p = 25.000000f;
    private float _plm_HardKnock_s = 3.000000f;
    private float _plm_SteedKiller_p = 70.000000f;
    private float _plm_SteedKiller_s = 30.000000f;
    private float _plm_Lancer_p = 20.000000f;
    private float _plm_Lancer_s = 20.000000f;
    private float _plm_Skewer_p = 0.250000f;
    private float _plm_Skewer_s = 1.000000f;
    private float _plm_Guards_p = 50.000000f;
    private float _plm_Guards_s = 20.000000f;
    private float _plm_StandardBearer_p = -20.000000f;
    private float _plm_StandardBearer_s = -20.000000f;
    private float _plm_Phalanx_p = 30.000000f;
    private float _plm_Phalanx_s = 3.000000f;
    private float _plm_GenerousRations_p = 5.000000f;
    private float _plm_GenerousRations_s = -20.000000f;
    private float _plm_Drills_p = 0.500000f;
    private float _plm_Drills_s = 1.000000f;
    private float _plm_SureFooted_p = -50.000000f;
    private float _plm_SureFooted_s = -30.000000f;
    private float _plm_UnstoppableForce_p = 2.000000f;
    private float _plm_UnstoppableForce_s = 30.000000f;
    private float _plm_CounterWeight_p = 15.000000f;
    private float _plm_CounterWeight_s = 20.000000f;
    private float _plm_SharpenTheTip_p = 5.000000f;
    private float _plm_SharpenTheTip_s = 5.000000f;
    private float _plm_WayOfTheSpear_p = 0.200000f;
    private float _plm_WayOfTheSpear_s = 0.500000f;
    private float _bow_BowControl_p = -30.000000f;
    private float _bow_BowControl_s = 5.000000f;
    private float _bow_DeadAim_p = 30.000000f;
    private float _bow_DeadAim_s = 20.000000f;
    private float _bow_Bodkin_p = -10.000000f;
    private float _bow_Bodkin_s = -5.000000f;
    private float _bow_RangersSwiftness_p = -50.000000f;
    private float _bow_RangersSwiftness_s = 3.000000f;
    private float _bow_RapidFire_p = 25.000000f;
    private float _bow_RapidFire_s = 5.000000f;
    private float _bow_QuickAdjustments_p = -50.000000f;
    private float _bow_QuickAdjustments_s = -5.000000f;
    private float _bow_MerryMen_p = 5.000000f;
    private float _bow_MerryMen_s = 0.500000f;
    private float _bow_MountedArchery_p = -30.000000f;
    private float _bow_MountedArchery_s = 0.200000f;
    private float _bow_Trainer_p = 6.000000f;
    private float _bow_Trainer_s = 3.000000f;
    private float _bow_StrongBows_p = 8.000000f;
    private float _bow_StrongBows_s = 5.000000f;
    private float _bow_Discipline_p = 50.000000f;
    private float _bow_Discipline_s = 1.000000f;
    private float _bow_HunterClan_p = 30.000000f;
    private float _bow_HunterClan_s = -15.000000f;
    private float _bow_SkirmishPhaseMaster_p = -10.000000f;
    private float _bow_SkirmishPhaseMaster_s = -5.000000f;
    private float _bow_EagleEye_p = 50.000000f;
    private float _bow_EagleEye_s = 10.000000f;
    private float _bow_BullsEye_p = 0.100000f;
    private float _bow_BullsEye_s = 2.000000f;
    private float _bow_RenownedArcher_p = 10.000000f;
    private float _bow_RenownedArcher_s = -30.000000f;
    private float _bow_HorseMaster_p = 0.000000f;
    private float _bow_HorseMaster_s = 30.000000f;
    private float _bow_DeepQuivers_p = 3.000000f;
    private float _bow_DeepQuivers_s = 1.000000f;
    private float _bow_QuickDraw_p = 25.000000f;
    private float _bow_QuickDraw_s = 5.000000f;
    private float _bow_Salvo_p = 0.000000f;
    private float _bow_Salvo_s = 0.200000f;
    private float _bow_Deadshot_p = 0.200000f;
    private float _bow_Deadshot_s = 0.500000f;
    private float _xbw_Piercer_p = 20.000000f;
    private float _xbw_Piercer_s = -20.000000f;
    private float _xbw_Marksmen_p = 25.000000f;
    private float _xbw_Marksmen_s = 10.000000f;
    private float _xbw_Unhorser_p = 40.000000f;
    private float _xbw_Unhorser_s = 20.000000f;
    private float _xbw_WindWinder_p = 25.000000f;
    private float _xbw_WindWinder_s = 5.000000f;
    private float _xbw_DonkeysSwiftness_p = -30.000000f;
    private float _xbw_DonkeysSwiftness_s = 30.000000f;
    private float _xbw_Sheriff_p = 50.000000f;
    private float _xbw_Sheriff_s = 10.000000f;
    private float _xbw_PeasantLeader_p = 10.000000f;
    private float _xbw_PeasantLeader_s = -20.000000f;
    private float _xbw_RenownMarksmen_p = 2.000000f;
    private float _xbw_RenownMarksmen_s = 0.300000f;
    private float _xbw_Fletcher_p = 4.000000f;
    private float _xbw_Fletcher_s = 2.000000f;
    private float _xbw_Puncture_p = -10.000000f;
    private float _xbw_Puncture_s = -5.000000f;
    private float _xbw_LooseAndMove_p = 0.000000f;
    private float _xbw_LooseAndMove_s = 5.000000f;
    private float _xbw_DeftHands_p = 100.000000f;
    private float _xbw_DeftHands_s = 100.000000f;
    private float _xbw_MountedCrossbowman_p = 0.000000f;
    private float _xbw_MountedCrossbowman_s = 5.000000f;
    private float _xbw_Steady_p = -50.000000f;
    private float _xbw_Steady_s = 5.000000f;
    private float _xbw_Sniper_p = 100.000000f;
    private float _xbw_Sniper_s = 1.000000f;
    private float _xbw_HammerBolts_p = 100.000000f;
    private float _xbw_HammerBolts_s = 10.000000f;
    private float _xbw_Pavise_p = 75.000000f;
    private float _xbw_Pavise_s = 30.000000f;
    private float _xbw_Terror_p = 1.000000f;
    private float _xbw_Terror_s = 25.000000f;
    private float _xbw_PickedShots_p = -0.500000f;
    private float _xbw_PickedShots_s = 5.000000f;
    private float _xbw_MightyPull_p = 0.200000f;
    private float _xbw_MightyPull_s = 0.500000f;
    private float _thr_QuickDraw_p = 20.000000f;
    private float _thr_QuickDraw_s = 10.000000f;
    private float _thr_ShieldBreaker_p = 40.000000f;
    private float _thr_ShieldBreaker_s = 8.000000f;
    private float _thr_Hunter_p = 40.000000f;
    private float _thr_Hunter_s = 8.000000f;
    private float _thr_FlexibleFighter_p = 10.000000f;
    private float _thr_MountedSkirmisher_p = -20.000000f;
    private float _thr_MountedSkirmisher_s = 10.000000f;
    private float _thr_PerfectTechnique_p = 25.000000f;
    private float _thr_PerfectTechnique_s = 10.000000f;
    private float _thr_RunningThrow_p = 0.250000f;
    private float _thr_RunningThrow_s = 30.000000f;
    private float _thr_KnockOff_p = 50.000000f;
    private float _thr_KnockOff_s = 5.000000f;
    private float _thr_WellPrepared_p = 1.000000f;
    private float _thr_WellPrepared_s = 1.000000f;
    private float _thr_Focus_p = 25.000000f;
    private float _thr_Focus_s = 1.000000f;
    private float _thr_LastHit_p = 50.000000f;
    private float _thr_LastHit_s = 5.000000f;
    private float _thr_HeadHunter_p = 50.000000f;
    private float _thr_HeadHunter_s = -20.000000f;
    private float _thr_ThrowingCompetitions_p = -20.000000f;
    private float _thr_ThrowingCompetitions_s = 0.500000f;
    private float _thr_Splinters_p = 200.000000f;
    private float _thr_Splinters_s = 50.000000f;
    private float _thr_Resourceful_p = 2.000000f;
    private float _thr_Resourceful_s = 10.000000f;
    private float _thr_LongReach_p = 0.000000f;
    private float _thr_LongReach_s = 20.000000f;
    private float _thr_WeakSpot_p = -30.000000f;
    private float _thr_WeakSpot_s = -10.000000f;
    private float _thr_Impale_p = 0.000000f;
    private float _thr_Impale_s = 10.000000f;
    private float _thr_UnstoppableForce_p = 0.200000f;
    private float _thr_UnstoppableForce_s = 0.500000f;
    private float _rid_FullSpeed_p = 20.000000f;
    private float _rid_FullSpeed_s = 10.000000f;
    private float _rid_NimbleSteed_p = 10.000000f;
    private float _rid_NimbleSteed_s = 30.000000f;
    private float _rid_WellStraped_p = 20.000000f;
    private float _rid_WellStraped_s = 10.000000f;
    private float _rid_Veterinary_p = 0.500000f;
    private float _rid_Veterinary_s = 0.500000f;
    private float _rid_NomadicTraditions_p = 30.000000f;
    private float _rid_NomadicTraditions_s = 10.000000f;
    private float _rid_FilledToBrim_p = 0.200000f;
    private float _rid_FilledToBrim_s = -10.000000f;
    private float _rid_Sagittarius_p = -15.000000f;
    private float _rid_Sagittarius_s = -15.000000f;
    private float _rid_SweepingWind_p = 5.000000f;
    private float _rid_SweepingWind_s = 2.000000f;
    private float _rid_MountedWarrior_p = 5.000000f;
    private float _rid_MountedWarrior_s = 5.000000f;
    private float _rid_HorseArcher_p = 10.000000f;
    private float _rid_HorseArcher_s = 5.000000f;
    private float _rid_Horde_p = 50.000000f;
    private float _rid_Horde_s = 15.000000f;
    private float _rid_Breeder_p = 0.010000f;
    private float _rid_Breeder_s = 5.000000f;
    private float _rid_ThunderousCharge_p = 20.000000f;
    private float _rid_ThunderousCharge_s = 10.000000f;
    private float _rid_AnnoyingBuzz_p = 20.000000f;
    private float _rid_AnnoyingBuzz_s = 5.000000f;
    private float _rid_MountedPatrols_p = -50.000000f;
    private float _rid_MountedPatrols_s = -50.000000f;
    private float _rid_CavalryTactics_p = 30.000000f;
    private float _rid_CavalryTactics_s = -50.000000f;
    private float _rid_DauntlessSteed_p = 50.000000f;
    private float _rid_DauntlessSteed_s = 5.000000f;
    private float _rid_ToughSteed_p = 20.000000f;
    private float _rid_ToughSteed_s = 10.000000f;
    private float _rid_TheWayOfTheSaddle_p = 200.000000f;
    private float _rid_TheWayOfTheSaddle_s = 1.000000f;
    private float _ath_MorningExercise_p = 3.000000f;
    private float _ath_MorningExercise_s = 5.000000f;
    private float _ath_WellBuilt_p = 5.000000f;
    private float _ath_WellBuilt_s = 5.000000f;
    private float _ath_FormFittingArmor_p = -15.000000f;
    private float _ath_FormFittingArmor_s = 4.000000f;
    private float _ath_HavingGoing_p = 0.300000f;
    private float _ath_HavingGoing_s = 5.000000f;
    private float _ath_Stamina_p = 0.500000f;
    private float _ath_Stamina_s = 5.000000f;
    private float _ath_Powerful_p = 4.000000f;
    private float _ath_Powerful_s = 2.000000f;
    private float _ath_SurgingBlow_p = 30.000000f;
    private float _ath_SurgingBlow_s = 30.000000f;
    private float _ath_Braced_p = -50.000000f;
    private float _ath_Braced_s = -50.000000f;
    private float _ath_WalkItOff_p = 10.000000f;
    private float _ath_WalkItOff_s = 3.000000f;
    private float _ath_AGoodDaysRest_p = 10.000000f;
    private float _ath_AGoodDaysRest_s = 10.000000f;
    private float _ath_HealthyCitizens_p = 1.000000f;
    private float _ath_HealthyCitizens_s = 1.000000f;
    private float _ath_Energetic_p = -20.000000f;
    private float _ath_Energetic_s = 20.000000f;
    private float _ath_Steady_p = 1.000000f;
    private float _ath_Strong_p = 1.000000f;
    private float _ath_Strong_s = 5.000000f;
    private float _ath_StrongArms_p = 1.000000f;
    private float _ath_StrongArms_s = 20.000000f;
    private float _ath_Spartan_p = 50.000000f;
    private float _ath_Spartan_s = -20.000000f;
    private float _ath_IgnorePain_p = 10.000000f;
    private float _ath_IgnorePain_s = 5.000000f;
    private float _ath_MightyBlow_p = 0.050000f;
    private float _ath_MightyBlow_s = 250.000000f;
    private float _cft_SharpenedEdge_p = 2.000000f;
    private float _cft_SharpenedTip_p = 2.000000f;
    private float _tct_TightFormations_p = 10.000000f;
    private float _tct_LooseFormations_p = -10.000000f;
    private float _tct_AsymmetricalWarfare_p = 10.000000f;
    private float _tct_AsymmetricalWarfare_s = 2.000000f;
    private float _tct_SmallUnitTactics_p = 1.000000f;
    private float _tct_SmallUnitTactics_s = 5.000000f;
    private float _tct_HordeLeader_p = 10.000000f;
    private float _tct_HordeLeader_s = -5.000000f;
    private float _tct_LawKeeper_p = 10.000000f;
    private float _tct_LawKeeper_s = 4.000000f;
    private float _tct_Coaching_p = 3.000000f;
    private float _tct_Coaching_s = 1.000000f;
    private float _tct_SwiftRegroup_p = -0.150000f;
    private float _tct_SwiftRegroup_s = -50.000000f;
    private float _tct_OnTheMarch_p = -20.000000f;
    private float _tct_OnTheMarch_s = 20.000000f;
    private float _tct_CallToArms_p = 0.100000f;
    private float _tct_CallToArms_s = -0.150000f;
    private float _tct_PickThemOfTheWalls_p = 0.250000f;
    private float _tct_PickThemOfTheWalls_s = 0.250000f;
    private float _tct_MakeThemPay_p = 0.250000f;
    private float _tct_MakeThemPay_s = 0.200000f;
    private float _tct_EliteReserves_p = -20.000000f;
    private float _tct_EliteReserves_s = -5.000000f;
    private float _tct_Encirclement_p = 5.000000f;
    private float _tct_Encirclement_s = -0.100000f;
    private float _tct_PreBattleManeuvers_p = 25.000000f;
    private float _tct_Besieged_p = 10.000000f;
    private float _tct_Besieged_s = 50.000000f;
    private float _tct_Counteroffensive_p = 10.000000f;
    private float _tct_Counteroffensive_s = 10.000000f;
    private float _tct_Gensdarmes_p = 2.000000f;
    private float _tct_Gensdarmes_s = 1.000000f;
    private float _tct_TacticalMastery_p = 1.000000f;
    private float _sct_DayTraveler_p = 0.020000f;
    private float _sct_DayTraveler_s = 10.000000f;
    private float _sct_NightRunner_p = 0.050000f;
    private float _sct_NightRunner_s = 30.000000f;
    private float _sct_Pathfinder_p = 0.020000f;
    private float _sct_WaterDiviner_p = 10.000000f;
    private float _sct_ForestKin_p = 50.000000f;
    private float _sct_ForestKin_s = 10.000000f;
    private float _sct_DesertBorn_p = 0.050000f;
    private float _sct_DesertBorn_s = 2.500000f;
    private float _sct_ForcedMarch_p = 0.025000f;
    private float _sct_ForcedMarch_s = 2.000000f;
    private float _sct_Unburdened_p = -20.000000f;
    private float _sct_Unburdened_s = 2.000000f;
    private float _sct_Tracker_p = 20.000000f;
    private float _sct_Tracker_s = 0.020000f;
    private float _sct_Ranger_p = 20.000000f;
    private float _sct_Ranger_s = 10.000000f;
    private float _sct_Patrols_p = 5.000000f;
    private float _sct_Patrols_s = 10.000000f;
    private float _sct_Foragers_p = -10.000000f;
    private float _sct_Foragers_s = -0.150000f;
    private float _sct_BeastWhisperer_p = 5.000000f;
    private float _sct_BeastWhisperer_s = 0.100000f;
    private float _sct_VillageNetwork_p = -10.000000f;
    private float _sct_VillageNetwork_s = 10.000000f;
    private float _sct_RumourNetwork_p = -5.000000f;
    private float _sct_RumourNetwork_s = 30.000000f;
    private float _sct_VantagePoint_p = 25.000000f;
    private float _sct_VantagePoint_s = 10.000000f;
    private float _sct_KeenSight_p = -0.500000f;
    private float _sct_KeenSight_s = -50.000000f;
    private float _sct_Rearguard_p = 20.000000f;
    private float _sct_Rearguard_s = 10.000000f;
    private float _sct_UncannyInsight_p = 0.100000f;
    private float _sct_UncannyInsight_s = 0.000000f;
    private float _rog_NoRestForTheWicked_p = 20.000000f;
    private float _rog_NoRestForTheWicked_s = 0.050000f;
    private float _rog_SweetTalker_p = -0.200000f;
    private float _rog_SweetTalker_s = -20.000000f;
    private float _rog_TwoFaced_p = 50.000000f;
    private float _rog_TwoFaced_s = 0.000000f;
    private float _rog_DeepPockets_p = 2.000000f;
    private float _rog_DeepPockets_s = -20.000000f;
    private float _rog_InBestLight_p = 1.000000f;
    private float _rog_InBestLight_s = 0.200000f;
    private float _rog_KnowHow_p = 0.050000f;
    private float _rog_KnowHow_s = 1.000000f;
    private float _rog_Promises_p = -50.000000f;
    private float _rog_Promises_s = 0.300000f;
    private float _rog_SlaveTrader_p = 0.200000f;
    private float _rog_SlaveTrader_s = 20.000000f;
    private float _rog_WhiteLies_p = 20.000000f;
    private float _rog_WhiteLies_s = 1.000000f;
    private float _rog_SmugglerConnections_p = 10.000000f;
    private float _rog_SmugglerConnections_s = -50.000000f;
    private float _rog_PartnersInCrime_p = -100.000000f;
    private float _rog_PartnersInCrime_s = 2.000000f;
    private float _rog_OneOfTheFamily_p = 10.000000f;
    private float _rog_OneOfTheFamily_s = 1.000000f;
    private float _rog_Carver_p = 10.000000f;
    private float _rog_Carver_s = 2.000000f;
    private float _rog_RansomBroker_p = 0.250000f;
    private float _rog_RansomBroker_s = -30.000000f;
    private float _rog_ArmsDealer_p = -20.000000f;
    private float _rog_ArmsDealer_s = 2.000000f;
    private float _rog_DirtyFighting_p = 50.000000f;
    private float _rog_DirtyFighting_s = 2.000000f;
    private float _rog_DashAndSlash_p = 50.000000f;
    private float _rog_DashAndSlash_s = 2.000000f;
    private float _rog_FleetFooted_p = 10.000000f;
    private float _rog_FleetFooted_s = 30.000000f;
    private float _rog_RogueExtraordinaire_p = 1.000000f;
    private float _rog_RogueExtraordinaire_s = 0.000000f;
    private float _ldr_CombatTips_p = 2.000000f;
    private float _ldr_CombatTips_s = 1.000000f;
    private float _ldr_RaiseTheMeek_p = 4.000000f;
    private float _ldr_RaiseTheMeek_s = 3.000000f;
    private float _ldr_FerventAttacker_p = 4.000000f;
    private float _ldr_FerventAttacker_s = 50.000000f;
    private float _ldr_StoutDefender_p = 8.000000f;
    private float _ldr_StoutDefender_s = 50.000000f;
    private float _ldr_Authority_p = 0.200000f;
    private float _ldr_Authority_s = 5.000000f;
    private float _ldr_HeroicLeader_p = 1.000000f;
    private float _ldr_HeroicLeader_s = 10.000000f;
    private float _ldr_LoyaltyAndHonor_p = 3.000000f;
    private float _ldr_LoyaltyAndHonor_s = 30.000000f;
    private float _ldr_FamousCommander_p = 50.000000f;
    private float _ldr_FamousCommander_s = 200.000000f;
    private float _ldr_Presence_p = 5.000000f;
    private float _ldr_Presence_s = 0.000000f;
    private float _ldr_LeaderOfMasses_p = 5.000000f;
    private float _ldr_LeaderOfMasses_s = 0.000000f;
    private float _ldr_VeteransRespect_p = 20.000000f;
    private float _ldr_VeteransRespect_s = 1.000000f;
    private float _ldr_CitizenMilitia_p = 20.000000f;
    private float _ldr_CitizenMilitia_s = 20.000000f;
    private float _ldr_InspiringLeader_p = -0.200000f;
    private float _ldr_InspiringLeader_s = 5.000000f;
    private float _ldr_UpliftingSpirit_p = 10.000000f;
    private float _ldr_UpliftingSpirit_s = 10.000000f;
    private float _ldr_MakeADifference_p = 100.000000f;
    private float _ldr_MakeADifference_s = 10.000000f;
    private float _ldr_LeadByExample_p = 50.000000f;
    private float _ldr_LeadByExample_s = 10.000000f;
    private float _ldr_TrustedCommander_p = 50.000000f;
    private float _ldr_TrustedCommander_s = 20.000000f;
    private float _ldr_WePledgeOurSwords_p = 1.000000f;
    private float _ldr_TalentMagnet_p = 3.000000f;
    private float _ldr_TalentMagnet_s = 1.000000f;
    private float _ldr_UltimateLeader_p = 1.000000f;
    private float _ldr_UltimateLeader_s = 0.000000f;
    private float _chm_Virile_p = 0.300000f;
    private float _chm_Virile_s = 1.000000f;
    private float _chm_SelfPromoter_p = 5.000000f;
    private float _chm_SelfPromoter_s = 1.000000f;
    private float _chm_Oratory_p = 1.000000f;
    private float _chm_Oratory_s = 1.000000f;
    private float _chm_Warlord_p = 0.300000f;
    private float _chm_Warlord_s = 1.000000f;
    private float _chm_ForgivableGrievances_p = 0.200000f;
    private float _chm_ForgivableGrievances_s = 1.000000f;
    private float _chm_MeaningfulFavors_p = 0.100000f;
    private float _chm_MeaningfulFavors_s = 1.000000f;
    private float _chm_InBloom_p = 0.200000f;
    private float _chm_InBloom_s = 1.000000f;
    private float _chm_YoungAndRespectful_p = 0.200000f;
    private float _chm_YoungAndRespectful_s = 1.000000f;
    private float _chm_Firebrand_p = -0.500000f;
    private float _chm_Firebrand_s = 1.000000f;
    private float _chm_FlexibleEthics_p = -0.300000f;
    private float _chm_FlexibleEthics_s = 1.000000f;
    private float _chm_SlickNegotiator_p = -0.200000f;
    private float _chm_SlickNegotiator_s = -0.100000f;
    private float _chm_Tribute_p = 0.200000f;
    private float _chm_Tribute_s = 1.000000f;
    private float _chm_MoralLeader_p = -1.000000f;
    private float _chm_MoralLeader_s = 1.000000f;
    private float _chm_NaturalLeader_p = -1.000000f;
    private float _chm_NaturalLeader_s = -0.100000f;
    private float _chm_PublicSpeaker_p = 0.300000f;
    private float _chm_Camaraderie_p = 1.000000f;
    private float _chm_Camaraderie_s = 1.000000f;
    private float _trd_Appraiser_p = -15.000000f;
    private float _trd_Appraiser_s = 0.000000f;
    private float _trd_WholeSeller_p = -15.000000f;
    private float _trd_WholeSeller_s = 0.000000f;
    private float _trd_CaravanMaster_p = 0.300000f;
    private float _trd_CaravanMaster_s = 0.000000f;
    private float _trd_MarketDealer_p = -0.200000f;
    private float _trd_MarketDealer_s = 0.000000f;
    private float _trd_TravelingRumors_p = 0.000000f;
    private float _trd_TravelingRumors_s = -15.000000f;
    private float _trd_LocalConnection_p = 0.000000f;
    private float _trd_LocalConnection_s = -15.000000f;
    private float _trd_DistributedGoods_p = 2.000000f;
    private float _trd_DistributedGoods_s = 30.000000f;
    private float _trd_Tollgates_p = 2.000000f;
    private float _trd_Tollgates_s = 20.000000f;
    private float _trd_ArtisanCommunity_p = 1.000000f;
    private float _trd_ArtisanCommunity_s = 1.000000f;
    private float _trd_GreatInvestor_p = 1.000000f;
    private float _trd_GreatInvestor_s = -30.000000f;
    private float _trd_MercenaryConnections_p = 25.000000f;
    private float _trd_MercenaryConnections_s = -0.250000f;
    private float _trd_ContentTrades_p = 10.000000f;
    private float _trd_ContentTrades_s = -0.500000f;
    private float _trd_InsurancePlans_p = 5000.000000f;
    private float _trd_InsurancePlans_s = -25.000000f;
    private float _trd_RapidDevelopment_p = 5000.000000f;
    private float _trd_RapidDevelopment_s = -25.000000f;
    private float _trd_GranaryAccountant_p = -20.000000f;
    private float _trd_GranaryAccountant_s = 20.000000f;
    private float _trd_SwordForBarter_p = -0.200000f;
    private float _trd_SwordForBarter_s = -0.150000f;
    private float _trd_SelfMadeMan_p = -0.500000f;
    private float _trd_SilverTongue_p = -0.500000f;
    private float _trd_SilverTongue_s = -0.150000f;
    private float _trd_ManOfMeans_p = -0.200000f;
    private float _trd_ManOfMeans_s = -0.300000f;
    private float _trd_TrickleDown_p = 1.000000f;
    private float _trd_TrickleDown_s = 1.000000f;
    private float _st_Spartan_p = -10.000000f;
    private float _st_Spartan_s = 0.000000f;
    private float _st_Frugal_p = -5.000000f;
    private float _st_Frugal_s = -15.000000f;
    private float _st_SevenVeterans_p = 4.000000f;
    private float _st_SevenVeterans_s = 1.000000f;
    private float _st_DrillSergant_p = 2.000000f;
    private float _st_DrillSergant_s = -5.000000f;
    private float _st_Sweatshops_p = 20.000000f;
    private float _st_Sweatshops_s = 0.200000f;
    private float _st_StiffUpperLip_p = -10.000000f;
    private float _st_StiffUpperLip_s = -20.000000f;
    private float _st_PaidInPromise_p = -25.000000f;
    private float _st_PaidInPromise_s = 1.500000f;
    private float _st_EfficientCampaigner_p = 1.000000f;
    private float _st_EfficientCampaigner_s = -25.000000f;
    private float _st_GivingHands_p = 1.500000f;
    private float _st_GivingHands_s = 10.000000f;
    private float _st_Logistician_p = 4.000000f;
    private float _st_Logistician_s = 10.000000f;
    private float _st_Relocation_p = 25.000000f;
    private float _st_Relocation_s = 20.000000f;
    private float _st_AidCorps_p = 0.000000f;
    private float _st_AidCorps_s = 20.000000f;
    private float _st_Gourmet_p = 2.000000f;
    private float _st_Gourmet_s = -0.100000f;
    private float _st_SoundReserves_p = -10.000000f;
    private float _st_SoundReserves_s = -10.000000f;
    private float _st_ForcedLabor_p = 0.000000f;
    private float _st_ForcedLabor_s = 10.000000f;
    private float _st_Contractors_p = -0.250000f;
    private float _st_Contractors_s = 10.000000f;
    private float _st_ArenicosMules_p = 0.200000f;
    private float _st_ArenicosMules_s = -20.000000f;
    private float _st_ArenicosHorses_p = 0.100000f;
    private float _st_ArenicosHorses_s = -20.000000f;
    private float _st_MasterOfPlanning_p = -0.400000f;
    private float _st_MasterOfPlanning_s = 0.200000f;
    private float _st_MasterOfWarcraft_p = -25.000000f;
    private float _st_MasterOfWarcraft_s = -0.050000f;
    private float _med_SelfMedication_p = 30.000000f;
    private float _med_SelfMedication_s = 2.000000f;
    private float _med_PreventiveMedicine_p = 5.000000f;
    private float _med_PreventiveMedicine_s = 30.000000f;
    private float _med_TriageTent_p = 30.000000f;
    private float _med_TriageTent_s = -0.050000f;
    private float _med_WalkItOff_p = 15.000000f;
    private float _med_WalkItOff_s = 10.000000f;
    private float _med_Sledges_p = -50.000000f;
    private float _med_Sledges_s = 15.000000f;
    private float _med_DoctorsOath_p = 0.000000f;
    private float _med_DoctorsOath_s = 5.000000f;
    private float _med_BestMedicine_p = 15.000000f;
    private float _med_BestMedicine_s = 1.000000f;
    private float _med_GoodLogdings_p = 20.000000f;
    private float _med_GoodLogdings_s = 1.000000f;
    private float _med_SiegeMedic_p = 50.000000f;
    private float _med_SiegeMedic_s = -0.300000f;
    private float _med_Veterinarian_p = 30.000000f;
    private float _med_Veterinarian_s = 50.000000f;
    private float _med_PristineStreets_p = 1.000000f;
    private float _med_PristineStreets_s = 20.000000f;
    private float _med_BushDoctor_p = 20.000000f;
    private float _med_BushDoctor_s = 20.000000f;
    private float _med_PerfectHealth_p = 5.000000f;
    private float _med_PerfectHealth_s = 10.000000f;
    private float _med_HealthAdvise_p = 0.000000f;
    private float _med_HealthAdvise_s = 0.000000f;
    private float _med_PhysicianOfPeople_p = 1.000000f;
    private float _med_PhysicianOfPeople_s = 30.000000f;
    private float _med_CleanInfrastructure_p = 1.000000f;
    private float _med_CleanInfrastructure_s = 0.300000f;
    private float _med_CheatDeath_p = 1.000000f;
    private float _med_CheatDeath_s = -0.500000f;
    private float _med_FortitudeTonic_p = 10.000000f;
    private float _med_FortitudeTonic_s = 5.000000f;
    private float _med_HelpingHands_p = 2.000000f;
    private float _med_HelpingHands_s = -50.000000f;
    private float _med_BattleHardened_p = 25.000000f;
    private float _med_BattleHardened_s = -0.250000f;
    private float _eng_Scaffolds_p = 0.100000f;
    private float _eng_Scaffolds_s = 30.000000f;
    private float _eng_TorsionEngines_p = 0.100000f;
    private float _eng_TorsionEngines_s = 3.000000f;
    private float _eng_SiegeWorks_p = 0.100000f;
    private float _eng_SiegeWorks_s = 1.000000f;
    private float _eng_PrisonArchitect_p = -0.250000f;
    private float _eng_PrisonArchitect_s = -0.250000f;
    private float _eng_Carpenters_p = 0.330000f;
    private float _eng_Carpenters_s = 0.120000f;
    private float _eng_MilitaryPlanner_p = 50.000000f;
    private float _eng_MilitaryPlanner_s = 0.250000f;
    private float _eng_WallBreaker_p = 0.250000f;
    private float _eng_WallBreaker_s = 10.000000f;
    private float _eng_DreadfulSieger_p = 0.100000f;
    private float _eng_DreadfulSieger_s = 5.000000f;
    private float _eng_Salvager_p = 0.200000f;
    private float _eng_Foreman_p = 0.100000f;
    private float _eng_Foreman_s = 100.000000f;
    private float _eng_SiegeEngineer_p = 0.300000f;
    private float _eng_SiegeEngineer_s = 100.000000f;
    private float _eng_Battlements_p = 1.000000f;
    private float _eng_Battlements_s = 100.000000f;
    private float _eng_EngineeringGuilds_p = 1.000000f;
    private float _eng_EngineeringGuilds_s = 0.250000f;
    private float _eng_Metallurgy_p = 0.200000f;
    private float _eng_Metallurgy_s = 5.000000f;
    private float _eng_ImprovedTools_p = 0.200000f;
    private float _eng_ImprovedTools_s = 5.000000f;
    private float _eng_Clockwork_p = -0.250000f;
    private float _eng_Clockwork_s = 0.200000f;
    private float _eng_ArchitecturalCommisions_p = -0.250000f;
    private float _eng_ArchitecturalCommisions_s = 20.000000f;
    [SettingPropertyBool("Enable Engineering perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Engineering", IsMainToggle=true)]
    public bool EngineeringPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Medicine perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Medicine", IsMainToggle=true)]
    public bool MedicinePerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Steward perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Steward", IsMainToggle=true)]
    public bool StewardPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Trade perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Trade", IsMainToggle=true)]
    public bool TradePerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Charm perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Charm", IsMainToggle=true)]
    public bool CharmPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Leadership perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Leadership", IsMainToggle=true)]
    public bool LeadershipPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Roguery perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Roguery", IsMainToggle=true)]
    public bool RogueryPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Scouting perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Scouting", IsMainToggle=true)]
    public bool ScoutingPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Tactics perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Tactics", IsMainToggle=true)]
    public bool TacticsPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Crafting perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Crafting", IsMainToggle=true)]
    public bool CraftingPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Athletics perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Athletics", IsMainToggle=true)]
    public bool AthleticsPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Riding perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Riding", IsMainToggle=true)]
    public bool RidingPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Throwing perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Throwing", IsMainToggle=true)]
    public bool ThrowingPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Crossbow perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Crossbow", IsMainToggle=true)]
    public bool CrossbowPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Bow perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Bow", IsMainToggle=true)]
    public bool BowPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable Polearm perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/Polearm", IsMainToggle=true)]
    public bool PolearmPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable TwoHanded perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/TwoHanded", IsMainToggle=true)]
    public bool TwoHandedPerkModificationEnabled {get; set;} = false;
    [SettingPropertyBool("Enable OneHanded perk modifications", RequireRestart=false, HintText = "")]
    [SettingPropertyGroup("Perks/OneHanded", IsMainToggle=true)]
    public bool OneHandedPerkModificationEnabled {get; set;} = false;
    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=JKqsYaBj}One handed weapons you wield have their handling increased by 20%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=fLaRz2SM}Deflect")]
    public float oh_Deflect_p {
      get => _oh_Deflect_p;
      set {
        if (_oh_Deflect_p != value) {
          _oh_Deflect_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.Deflect, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=rHcPtNKI}Troops in the formation you are leading have their one handed combat effectiveness as if they were one tier higher.")]
    [SettingPropertyGroup("Perks/OneHanded/{=fLaRz2SM}Deflect")]
    public float oh_Deflect_s {
      get => _oh_Deflect_s;
      set {
        if (_oh_Deflect_s != value) {
          _oh_Deflect_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.Deflect, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xMpCWjg0}Shield bashes now deal 50% more damage and stun your enemies for longer.")]
    [SettingPropertyGroup("Perks/OneHanded/{=6yEeYNRu}Basher")]
    public float oh_Basher_p {
      get => _oh_Basher_p;
      set {
        if (_oh_Basher_p != value) {
          _oh_Basher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.Basher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=qDJmqZrJ}Infantry troops take 4% less melee damage while in shield wall formation.")]
    [SettingPropertyGroup("Perks/OneHanded/{=6yEeYNRu}Basher")]
    public float oh_Basher_s {
      get => _oh_Basher_s;
      set {
        if (_oh_Basher_s != value) {
          _oh_Basher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.Basher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=TDDswrfW}Increases your damage with axes and maces by 5%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=SJ69EYuI}To Be Blunt")]
    public float oh_ToBeBlunt_p {
      get => _oh_ToBeBlunt_p;
      set {
        if (_oh_ToBeBlunt_p != value) {
          _oh_ToBeBlunt_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.ToBeBlunt, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=oxqZJ0s9}Governed settlements gain 0.5 security per day.")]
    [SettingPropertyGroup("Perks/OneHanded/{=SJ69EYuI}To Be Blunt")]
    public float oh_ToBeBlunt_s {
      get => _oh_ToBeBlunt_s;
      set {
        if (_oh_ToBeBlunt_s != value) {
          _oh_ToBeBlunt_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.ToBeBlunt, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=4hvV3GF1}+2% swing speed with one handed weapons.")]
    [SettingPropertyGroup("Perks/OneHanded/{=ciELES5v}Swift Strike")]
    public float oh_SwiftStrike_p {
      get => _oh_SwiftStrike_p;
      set {
        if (_oh_SwiftStrike_p != value) {
          _oh_SwiftStrike_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.SwiftStrike, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=oYJz4V0s}Governed settlements have increased militia recruitment by 0.5 per day.")]
    [SettingPropertyGroup("Perks/OneHanded/{=ciELES5v}Swift Strike")]
    public float oh_SwiftStrike_s {
      get => _oh_SwiftStrike_s;
      set {
        if (_oh_SwiftStrike_s != value) {
          _oh_SwiftStrike_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.SwiftStrike, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=BkFausb8}Your one handed weapon damage is increased by 5% while mounted.")]
    [SettingPropertyGroup("Perks/OneHanded/{=YVGtcLHF}Cavalry")]
    public float oh_Cavalry_p {
      get => _oh_Cavalry_p;
      set {
        if (_oh_Cavalry_p != value) {
          _oh_Cavalry_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.Cavalry, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=P0Zm6daz}Cavalry troops in the formation you are leading have their melee damage increased by 5%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=YVGtcLHF}Cavalry")]
    public float oh_Cavalry_s {
      get => _oh_Cavalry_s;
      set {
        if (_oh_Cavalry_s != value) {
          _oh_Cavalry_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.Cavalry, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=gCol2epF}Reduces the effect of wielding a shield on your combat movement speed.")]
    [SettingPropertyGroup("Perks/OneHanded/{=vnG1q18y}Shield Bearer")]
    public float oh_ShieldBearer_p {
      get => _oh_ShieldBearer_p;
      set {
        if (_oh_ShieldBearer_p != value) {
          _oh_ShieldBearer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.ShieldBearer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=FCZc2zev}Infantry troops in the formation you are leading have their movement speed increased by 3%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=vnG1q18y}Shield Bearer")]
    public float oh_ShieldBearer_s {
      get => _oh_ShieldBearer_s;
      set {
        if (_oh_ShieldBearer_s != value) {
          _oh_ShieldBearer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.ShieldBearer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=daJkC7ZG}Increases your hit points by 2.")]
    [SettingPropertyGroup("Perks/OneHanded/{=3xuwVbfs}Trainer")]
    public float oh_Trainer_p {
      get => _oh_Trainer_p;
      set {
        if (_oh_Trainer_p != value) {
          _oh_Trainer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.Trainer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=cvk5Wb7e}Melee troops gain 5% more experience after every battle.")]
    [SettingPropertyGroup("Perks/OneHanded/{=3xuwVbfs}Trainer")]
    public float oh_Trainer_s {
      get => _oh_Trainer_s;
      set {
        if (_oh_Trainer_s != value) {
          _oh_Trainer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.Trainer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ow06ZHwa}20% more damage while wielding a one-handed weapon without a shield.")]
    [SettingPropertyGroup("Perks/OneHanded/{=XphY9cNV}Duelist")]
    public float oh_Duelist_p {
      get => _oh_Duelist_p;
      set {
        if (_oh_Duelist_p != value) {
          _oh_Duelist_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.Duelist, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=pdLfrowl}You get double renown from tournaments.")]
    [SettingPropertyGroup("Perks/OneHanded/{=XphY9cNV}Duelist")]
    public float oh_Duelist_s {
      get => _oh_Duelist_s;
      set {
        if (_oh_Duelist_s != value) {
          _oh_Duelist_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.Duelist, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=cZ2eQZdZ}Your shield takes 20% less damage while blocking the wrong direction.")]
    [SettingPropertyGroup("Perks/OneHanded/{=nSwkI97I}Shieldwall")]
    public float oh_ShieldWall_p {
      get => _oh_ShieldWall_p;
      set {
        if (_oh_ShieldWall_p != value) {
          _oh_ShieldWall_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.ShieldWall, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=SzoXR4Iy}Troops in the formation you are leading have medium bonus to their shield size against projectiles while they are in shield wall formation.")]
    [SettingPropertyGroup("Perks/OneHanded/{=nSwkI97I}Shieldwall")]
    public float oh_ShieldWall_s {
      get => _oh_ShieldWall_s;
      set {
        if (_oh_ShieldWall_s != value) {
          _oh_ShieldWall_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.ShieldWall, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=7b3HrKwv}Larger shield protection area against projectiles.")]
    [SettingPropertyGroup("Perks/OneHanded/{=a94mkNNk}Arrow Catcher")]
    public float oh_ArrowCatcher_p {
      get => _oh_ArrowCatcher_p;
      set {
        if (_oh_ArrowCatcher_p != value) {
          _oh_ArrowCatcher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.ArrowCatcher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=ijanbumZ}Led formation has a small bonus to their shield protection area against projectiles.")]
    [SettingPropertyGroup("Perks/OneHanded/{=a94mkNNk}Arrow Catcher")]
    public float oh_ArrowCatcher_s {
      get => _oh_ArrowCatcher_s;
      set {
        if (_oh_ArrowCatcher_s != value) {
          _oh_ArrowCatcher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.ArrowCatcher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bXrpRfcT}Infantry troops gain +2 xp daily.")]
    [SettingPropertyGroup("Perks/OneHanded/{=Fc7OsyZ8}Military Tradition")]
    public float oh_MilitaryTradition_p {
      get => _oh_MilitaryTradition_p;
      set {
        if (_oh_MilitaryTradition_p != value) {
          _oh_MilitaryTradition_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.MilitaryTradition, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=sSTCcoiT}Garrison wages in the governed settlements are reduced by 5%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=Fc7OsyZ8}Military Tradition")]
    public float oh_MilitaryTradition_s {
      get => _oh_MilitaryTradition_s;
      set {
        if (_oh_MilitaryTradition_s != value) {
          _oh_MilitaryTradition_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.MilitaryTradition, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=O4fIFDAx}Infantry in your party gain an additional 10% of the total xp earned after battles.")]
    [SettingPropertyGroup("Perks/OneHanded/{=M3aNEkBJ}Corps-a-corps")]
    public float oh_CorpsACorps_p {
      get => _oh_CorpsACorps_p;
      set {
        if (_oh_CorpsACorps_p != value) {
          _oh_CorpsACorps_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.CorpsACorps, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=MNuEtdvb}Increases garrison limit in the governed settlements by 30.")]
    [SettingPropertyGroup("Perks/OneHanded/{=M3aNEkBJ}Corps-a-corps")]
    public float oh_CorpsACorps_s {
      get => _oh_CorpsACorps_s;
      set {
        if (_oh_CorpsACorps_s != value) {
          _oh_CorpsACorps_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.CorpsACorps, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=rQEPseAj}Troops in your party start with +8 battle morale if you are outnumbered.")]
    [SettingPropertyGroup("Perks/OneHanded/{=d8qjwKza}Stand United")]
    public float oh_StandUnited_p {
      get => _oh_StandUnited_p;
      set {
        if (_oh_StandUnited_p != value) {
          _oh_StandUnited_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.StandUnited, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6TbPgeQE}Garrison troops in governed settlements are 30% more effective in restoring town security.")]
    [SettingPropertyGroup("Perks/OneHanded/{=d8qjwKza}Stand United")]
    public float oh_StandUnited_s {
      get => _oh_StandUnited_s;
      set {
        if (_oh_StandUnited_s != value) {
          _oh_StandUnited_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.StandUnited, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Oz8Aj6uB}Troops in your party gain 5% more experience after each battle.")]
    [SettingPropertyGroup("Perks/OneHanded/{=bOhbWapX}Lead by example")]
    public float oh_LeadByExample_p {
      get => _oh_LeadByExample_p;
      set {
        if (_oh_LeadByExample_p != value) {
          _oh_LeadByExample_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.LeadByExample, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xLbfPMKR}Troops in your party start battles with +5 battle morale.")]
    [SettingPropertyGroup("Perks/OneHanded/{=bOhbWapX}Lead by example")]
    public float oh_LeadByExample_s {
      get => _oh_LeadByExample_s;
      set {
        if (_oh_LeadByExample_s != value) {
          _oh_LeadByExample_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.LeadByExample, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=rx2bN30s}Your shields take 10% less damage.")]
    [SettingPropertyGroup("Perks/OneHanded/{=rSATpMpq}Steel Core Shields")]
    public float oh_SteelCoreShields_p {
      get => _oh_SteelCoreShields_p;
      set {
        if (_oh_SteelCoreShields_p != value) {
          _oh_SteelCoreShields_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.SteelCoreShields, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=V1ZKAdcK}Infantry troops in the formation you are leading take 10% less damage to their shields.")]
    [SettingPropertyGroup("Perks/OneHanded/{=rSATpMpq}Steel Core Shields")]
    public float oh_SteelCoreShields_s {
      get => _oh_SteelCoreShields_s;
      set {
        if (_oh_SteelCoreShields_s != value) {
          _oh_SteelCoreShields_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.SteelCoreShields, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=9jDRGKDs}Increases your combat movement speed by 5%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=OtdkOGur}Fleet of Foot")]
    public float oh_FleetOfFoot_p {
      get => _oh_FleetOfFoot_p;
      set {
        if (_oh_FleetOfFoot_p != value) {
          _oh_FleetOfFoot_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.FleetOfFoot, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=1bNb2bZz}Infantry troops in the formation you are leading have their movement speed increased by 4%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=OtdkOGur}Fleet of Foot")]
    public float oh_FleetOfFoot_s {
      get => _oh_FleetOfFoot_s;
      set {
        if (_oh_FleetOfFoot_s != value) {
          _oh_FleetOfFoot_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.FleetOfFoot, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=M8yrANf5}Increases damage with one handed weapons by 5%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=xpGoduJq}Deadly Purpose")]
    public float oh_DeadlyPurpose_p {
      get => _oh_DeadlyPurpose_p;
      set {
        if (_oh_DeadlyPurpose_p != value) {
          _oh_DeadlyPurpose_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.DeadlyPurpose, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=XAwb1Yhg}Infantry troops in the formation you are leading have their melee weapon damage increased by 10%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=xpGoduJq}Deadly Purpose")]
    public float oh_DeadlyPurpose_s {
      get => _oh_DeadlyPurpose_s;
      set {
        if (_oh_DeadlyPurpose_s != value) {
          _oh_DeadlyPurpose_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.DeadlyPurpose, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=SlrvOUWa}You gain +5 hit points.")]
    [SettingPropertyGroup("Perks/OneHanded/{=yFbEDUyb}Unwavering Defense")]
    public float oh_UnwaveringDefense_p {
      get => _oh_UnwaveringDefense_p;
      set {
        if (_oh_UnwaveringDefense_p != value) {
          _oh_UnwaveringDefense_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.UnwaveringDefense, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=GzNVqogG}Infantry troops in the the party you are leading have their hit points increased by 10.")]
    [SettingPropertyGroup("Perks/OneHanded/{=yFbEDUyb}Unwavering Defense")]
    public float oh_UnwaveringDefense_s {
      get => _oh_UnwaveringDefense_s;
      set {
        if (_oh_UnwaveringDefense_s != value) {
          _oh_UnwaveringDefense_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.UnwaveringDefense, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4FI0EqbH}You deal 50% more damage with one handed weapons against shields.")]
    [SettingPropertyGroup("Perks/OneHanded/{=DSKtsYPi}Prestige")]
    public float oh_Prestige_p {
      get => _oh_Prestige_p;
      set {
        if (_oh_Prestige_p != value) {
          _oh_Prestige_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.Prestige, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4oxnmb5B}Increases your party limit by 15.")]
    [SettingPropertyGroup("Perks/OneHanded/{=DSKtsYPi}Prestige")]
    public float oh_Prestige_s {
      get => _oh_Prestige_s;
      set {
        if (_oh_Prestige_s != value) {
          _oh_Prestige_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.Prestige, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=qDcqDybV}Your one handed melee attacks ignore 10% of enemy's armor.")]
    [SettingPropertyGroup("Perks/OneHanded/{=bBa0LB1D}Chink in the Armor")]
    public float oh_ChinkInTheArmor_p {
      get => _oh_ChinkInTheArmor_p;
      set {
        if (_oh_ChinkInTheArmor_p != value) {
          _oh_ChinkInTheArmor_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.ChinkInTheArmor, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=joBeQXGd}Reduces recruitment cost of infantry troops by 20%.")]
    [SettingPropertyGroup("Perks/OneHanded/{=bBa0LB1D}Chink in the Armor")]
    public float oh_ChinkInTheArmor_s {
      get => _oh_ChinkInTheArmor_s;
      set {
        if (_oh_ChinkInTheArmor_s != value) {
          _oh_ChinkInTheArmor_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.ChinkInTheArmor, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=gQK2IfoH}Each skill point above 250 grants you 0.2% attack speed increase with one handed weapons.")]
    [SettingPropertyGroup("Perks/OneHanded/{=nThmB3yB}Way of the Sword")]
    public float oh_WayOfTheSword_p {
      get => _oh_WayOfTheSword_p;
      set {
        if (_oh_WayOfTheSword_p != value) {
          _oh_WayOfTheSword_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.OneHanded.WayOfTheSword, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bOSE6Mhq}Each skill point above 250 grants you 0.5% damage increase with one handed weapons.")]
    [SettingPropertyGroup("Perks/OneHanded/{=nThmB3yB}Way of the Sword")]
    public float oh_WayOfTheSword_s {
      get => _oh_WayOfTheSword_s;
      set {
        if (_oh_WayOfTheSword_s != value) {
          _oh_WayOfTheSword_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.OneHanded.WayOfTheSword, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=KuZiQJhV}Two handed weapons you wield have 10% better handling.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=xDQTgPf0}Strong Grip")]
    public float twh_StrongGrip_p {
      get => _twh_StrongGrip_p;
      set {
        if (_twh_StrongGrip_p != value) {
          _twh_StrongGrip_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.StrongGrip, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6mWaEzgs}Infantry troops in the formation you are leading have their two handed skill increased by 30.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=xDQTgPf0}Strong Grip")]
    public float twh_StrongGrip_s {
      get => _twh_StrongGrip_s;
      set {
        if (_twh_StrongGrip_s != value) {
          _twh_StrongGrip_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.StrongGrip, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=pjjnackd}Increases your damage with two handed weapons by 30% against shields.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=J7oh7Vin}Wood Chopper")]
    public float twh_WoodChopper_p {
      get => _twh_WoodChopper_p;
      set {
        if (_twh_WoodChopper_p != value) {
          _twh_WoodChopper_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.WoodChopper, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=QcECvqaN}Infantry troops in the formation you are leading have their damage increased by 15% against shields.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=J7oh7Vin}Wood Chopper")]
    public float twh_WoodChopper_s {
      get => _twh_WoodChopper_s;
      set {
        if (_twh_WoodChopper_s != value) {
          _twh_WoodChopper_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.WoodChopper, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Eqwrqotp}Increases your swing speed with two handed swords by 3%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=rkuAgPSA}On the Edge")]
    public float twh_OnTheEdge_p {
      get => _twh_OnTheEdge_p;
      set {
        if (_twh_OnTheEdge_p != value) {
          _twh_OnTheEdge_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.OnTheEdge, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=1eEPRKKO}Infantry troops in the formation you are leading have their swing speed increased by 2%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=rkuAgPSA}On the Edge")]
    public float twh_OnTheEdge_s {
      get => _twh_OnTheEdge_s;
      set {
        if (_twh_OnTheEdge_s != value) {
          _twh_OnTheEdge_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.OnTheEdge, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=czTKtBIk}Increases your damage by 10% with two handed axes and two handed maces.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=E5bgLJcs}Head Basher")]
    public float twh_HeadBasher_p {
      get => _twh_HeadBasher_p;
      set {
        if (_twh_HeadBasher_p != value) {
          _twh_HeadBasher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.HeadBasher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=cRwfJ7aU}Infantry troops in the formation you are leading have their damage increased by 2%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=E5bgLJcs}Head Basher")]
    public float twh_HeadBasher_s {
      get => _twh_HeadBasher_s;
      set {
        if (_twh_HeadBasher_s != value) {
          _twh_HeadBasher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.HeadBasher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WAbqnair}Two handed weapon attacks that deal damage over 25% of your opponent's hit points have 30% chance to knock them down.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=RlMqzqbS}Show of Strength")]
    public float twh_ShowOfStrength_p {
      get => _twh_ShowOfStrength_p;
      set {
        if (_twh_ShowOfStrength_p != value) {
          _twh_ShowOfStrength_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.ShowOfStrength, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=x0cNi9lk}Infantry troops are 20% cheaper to recruit.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=RlMqzqbS}Show of Strength")]
    public float twh_ShowOfStrength_s {
      get => _twh_ShowOfStrength_s;
      set {
        if (_twh_ShowOfStrength_s != value) {
          _twh_ShowOfStrength_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.ShowOfStrength, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=JmrERaq4}Infantry in your party gain +5 experience for each enemy you kill with a 2-handed weapon.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=miMZavW3}Baptised in Blood")]
    public float twh_BaptisedInBlood_p {
      get => _twh_BaptisedInBlood_p;
      set {
        if (_twh_BaptisedInBlood_p != value) {
          _twh_BaptisedInBlood_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.BaptisedInBlood, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ytvDsThh}All melee infantry troops in your party gain 5% more xp in battles.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=miMZavW3}Baptised in Blood")]
    public float twh_BaptisedInBlood_s {
      get => _twh_BaptisedInBlood_s;
      set {
        if (_twh_BaptisedInBlood_s != value) {
          _twh_BaptisedInBlood_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.BaptisedInBlood, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Wa0Rp59Q}Increases your damage with two handed weapons by 50% against mounts.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=NDtlE6PY}Beast Slayer")]
    public float twh_BeastSlayer_p {
      get => _twh_BeastSlayer_p;
      set {
        if (_twh_BeastSlayer_p != value) {
          _twh_BeastSlayer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.BeastSlayer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=e9bk6QBv}Infantry troops in the formation you are leading have their damage increased by 10% against mounts.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=NDtlE6PY}Beast Slayer")]
    public float twh_BeastSlayer_s {
      get => _twh_BeastSlayer_s;
      set {
        if (_twh_BeastSlayer_s != value) {
          _twh_BeastSlayer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.BeastSlayer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Ge9RMuRi}40% more damage to shields with 2 handed weapons.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=bM9VX881}Shield breaker")]
    public float twh_ShieldBreaker_p {
      get => _twh_ShieldBreaker_p;
      set {
        if (_twh_ShieldBreaker_p != value) {
          _twh_ShieldBreaker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.ShieldBreaker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=2tw8Ha2b}Infantry troops in the formation you are leading have their damage increased by 10% against shields.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=bM9VX881}Shield breaker")]
    public float twh_ShieldBreaker_s {
      get => _twh_ShieldBreaker_s;
      set {
        if (_twh_ShieldBreaker_s != value) {
          _twh_ShieldBreaker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.ShieldBreaker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WyXs70nc}Increases your damage with two handed weapons by 20% when you have less than half hit points.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=RssJTUpL}Berserker")]
    public float twh_Berserker_p {
      get => _twh_Berserker_p;
      set {
        if (_twh_Berserker_p != value) {
          _twh_Berserker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.Berserker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=t9bDPzab}Garrison wages are reduced by 10% in governed town.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=RssJTUpL}Berserker")]
    public float twh_Berserker_s {
      get => _twh_Berserker_s;
      set {
        if (_twh_Berserker_s != value) {
          _twh_Berserker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.Berserker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=BibRbG6U}Increases your damage with two handed weapons by 15% when your hit points are above 90%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=2jnsxsv5}Confidence")]
    public float twh_Confidence_p {
      get => _twh_Confidence_p;
      set {
        if (_twh_Confidence_p != value) {
          _twh_Confidence_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.Confidence, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=6aiNd5W0}You can deflect arrows with two handed swords by blocking.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=MbRZSiuq}Arrow Deflection")]
    public float twh_ArrowDeflection_p {
      get => _twh_ArrowDeflection_p;
      set {
        if (_twh_ArrowDeflection_p != value) {
          _twh_ArrowDeflection_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.ArrowDeflection, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4nqaSQyO}The garrison in governed settlement gain 10% more experience from battles.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=MbRZSiuq}Arrow Deflection")]
    public float twh_ArrowDeflection_s {
      get => _twh_ArrowDeflection_s;
      set {
        if (_twh_ArrowDeflection_s != value) {
          _twh_ArrowDeflection_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.ArrowDeflection, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=J53hpSzc}Your kills with two handed weapons have 20% higher effect on enemy troops' battle morale.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=nAlCj2m0}Terror")]
    public float twh_Terror_p {
      get => _twh_Terror_p;
      set {
        if (_twh_Terror_p != value) {
          _twh_Terror_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.Terror, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=PMSSAVgi}Increases your prisoner limit by 10.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=nAlCj2m0}Terror")]
    public float twh_Terror_s {
      get => _twh_Terror_s;
      set {
        if (_twh_Terror_s != value) {
          _twh_Terror_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.Terror, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=GgHn8qUr}Your kills with two handed weapons have 30% higher effect on friendly troops' battle morale.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=lPuk6bao}Hope")]
    public float twh_Hope_p {
      get => _twh_Hope_p;
      set {
        if (_twh_Hope_p != value) {
          _twh_Hope_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.Hope, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=2Ott7Iq1}Your party limit is increased by 5.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=lPuk6bao}Hope")]
    public float twh_Hope_s {
      get => _twh_Hope_s;
      set {
        if (_twh_Hope_s != value) {
          _twh_Hope_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.Hope, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Tpvthjf1}Increases your speed damage bonus with two handed weapons by 20% while on foot.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=ZGovl01w}Reckless Charge")]
    public float twh_RecklessCharge_p {
      get => _twh_RecklessCharge_p;
      set {
        if (_twh_RecklessCharge_p != value) {
          _twh_RecklessCharge_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.RecklessCharge, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=EbFK5HXY}Infantry troops in the formation you are leading have their damage increased by 2% and movement speed increased by 2%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=ZGovl01w}Reckless Charge")]
    public float twh_RecklessCharge_s {
      get => _twh_RecklessCharge_s;
      set {
        if (_twh_RecklessCharge_s != value) {
          _twh_RecklessCharge_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.RecklessCharge, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=kKSSJD84}You gain 5 hit points.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=j9OIuxxY}Thick Hides")]
    public float twh_ThickHides_p {
      get => _twh_ThickHides_p;
      set {
        if (_twh_ThickHides_p != value) {
          _twh_ThickHides_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.ThickHides, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=w7UwHsE0}Troops in your party have their hit points increased by +5.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=j9OIuxxY}Thick Hides")]
    public float twh_ThickHides_s {
      get => _twh_ThickHides_s;
      set {
        if (_twh_ThickHides_s != value) {
          _twh_ThickHides_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.ThickHides, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=lOaVRxdR}Increases your two handed weapon damage by 10%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=TtwAoHfw}Blade Master")]
    public float twh_BladeMaster_p {
      get => _twh_BladeMaster_p;
      set {
        if (_twh_BladeMaster_p != value) {
          _twh_BladeMaster_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.BladeMaster, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=aR3M3YfX}Infantry troops in the formation you are leading have their attack speed increased by 2%.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=TtwAoHfw}Blade Master")]
    public float twh_BladeMaster_s {
      get => _twh_BladeMaster_s;
      set {
        if (_twh_BladeMaster_s != value) {
          _twh_BladeMaster_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.BladeMaster, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=GYNbGbwd}Your attacks ignore 25% of enemy's armor.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=czCRxHZy}Vandal")]
    public float twh_Vandal_p {
      get => _twh_Vandal_p;
      set {
        if (_twh_Vandal_p != value) {
          _twh_Vandal_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.Vandal, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gYonPSUM}Infantry troops in the formation you are leading have their damage increased by 20% against destructible objects.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=czCRxHZy}Vandal")]
    public float twh_Vandal_s {
      get => _twh_Vandal_s;
      set {
        if (_twh_Vandal_s != value) {
          _twh_Vandal_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.Vandal, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=brmnjfP3}Each skill point above 250 grants you 0.2% speed increase with two handed weapons.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=dbEb7iak}Way Of The Great Axe")]
    public float twh_WayOfTheGreatAxe_p {
      get => _twh_WayOfTheGreatAxe_p;
      set {
        if (_twh_WayOfTheGreatAxe_p != value) {
          _twh_WayOfTheGreatAxe_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.TwoHanded.WayOfTheGreatAxe, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=fANacbya}Each skill point above 250 grants you 0.5% damage increase with two handed weapons.")]
    [SettingPropertyGroup("Perks/TwoHanded/{=dbEb7iak}Way Of The Great Axe")]
    public float twh_WayOfTheGreatAxe_s {
      get => _twh_WayOfTheGreatAxe_s;
      set {
        if (_twh_WayOfTheGreatAxe_s != value) {
          _twh_WayOfTheGreatAxe_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.TwoHanded.WayOfTheGreatAxe, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=UdAlVmmF}Increases your damage with polearms by 2%.")]
    [SettingPropertyGroup("Perks/Polearm/{=IFqtwpb0}Pikeman")]
    public float plm_Pikeman_p {
      get => _plm_Pikeman_p;
      set {
        if (_plm_Pikeman_p != value) {
          _plm_Pikeman_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Pikeman, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ZYEPyNfF}Infantry troops in the formation you are leading have their damage increased by 2%.")]
    [SettingPropertyGroup("Perks/Polearm/{=IFqtwpb0}Pikeman")]
    public float plm_Pikeman_s {
      get => _plm_Pikeman_s;
      set {
        if (_plm_Pikeman_s != value) {
          _plm_Pikeman_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Pikeman, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vpGuPeAH}Increases your damage by 2% with polearms while mounted.")]
    [SettingPropertyGroup("Perks/Polearm/{=YVGtcLHF}Cavalry")]
    public float plm_Cavalry_p {
      get => _plm_Cavalry_p;
      set {
        if (_plm_Cavalry_p != value) {
          _plm_Cavalry_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Cavalry, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=850DaOJR}Cavalry troops in the formation you are leading have their damage increased by 2%.")]
    [SettingPropertyGroup("Perks/Polearm/{=YVGtcLHF}Cavalry")]
    public float plm_Cavalry_s {
      get => _plm_Cavalry_s;
      set {
        if (_plm_Cavalry_s != value) {
          _plm_Cavalry_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Cavalry, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=taTbOAte}Polearm attacks that deal damage over 25% of enemy cavalry's hit points has 25% chance to dismount them.")]
    [SettingPropertyGroup("Perks/Polearm/{=dU7haWkI}Braced")]
    public float plm_Braced_p {
      get => _plm_Braced_p;
      set {
        if (_plm_Braced_p != value) {
          _plm_Braced_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Braced, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=jZJV8W7A}Infantry troops in the formation you are leading have their damage increased by 10% against enemy cavalry.")]
    [SettingPropertyGroup("Perks/Polearm/{=dU7haWkI}Braced")]
    public float plm_Braced_s {
      get => _plm_Braced_s;
      set {
        if (_plm_Braced_s != value) {
          _plm_Braced_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Braced, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gW4Qmn73}Thrust attacks with polearms have 30% more chance to knock opponents back.")]
    [SettingPropertyGroup("Perks/Polearm/{=TaucWWCB}Keep at Bay")]
    public float plm_KeepAtBay_p {
      get => _plm_KeepAtBay_p;
      set {
        if (_plm_KeepAtBay_p != value) {
          _plm_KeepAtBay_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.KeepAtBay, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WXDcmG0f}Increases militia recruitment in governed settlements by 0.5.")]
    [SettingPropertyGroup("Perks/Polearm/{=TaucWWCB}Keep at Bay")]
    public float plm_KeepAtBay_s {
      get => _plm_KeepAtBay_s;
      set {
        if (_plm_KeepAtBay_s != value) {
          _plm_KeepAtBay_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.KeepAtBay, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=2OId6uC6}Increases your swing speed with polearms by 5%.")]
    [SettingPropertyGroup("Perks/Polearm/{=xM5aawCj}Swift Swing")]
    public float plm_SwiftSwing_p {
      get => _plm_SwiftSwing_p;
      set {
        if (_plm_SwiftSwing_p != value) {
          _plm_SwiftSwing_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.SwiftSwing, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=1eEPRKKO}Infantry troops in the formation you are leading have their swing speed increased by 2%.")]
    [SettingPropertyGroup("Perks/Polearm/{=xM5aawCj}Swift Swing")]
    public float plm_SwiftSwing_s {
      get => _plm_SwiftSwing_s;
      set {
        if (_plm_SwiftSwing_s != value) {
          _plm_SwiftSwing_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.SwiftSwing, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=A9mtiIx2}Increases your thrust damage with polearms by 10%.")]
    [SettingPropertyGroup("Perks/Polearm/{=PeaiNrSu}Clean Thrust")]
    public float plm_CleanThrust_p {
      get => _plm_CleanThrust_p;
      set {
        if (_plm_CleanThrust_p != value) {
          _plm_CleanThrust_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.CleanThrust, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=jgtQbyyU}Infantry troops in the formation you are leading have +30 to their polearms skills.")]
    [SettingPropertyGroup("Perks/Polearm/{=PeaiNrSu}Clean Thrust")]
    public float plm_CleanThrust_s {
      get => _plm_CleanThrust_s;
      set {
        if (_plm_CleanThrust_s != value) {
          _plm_CleanThrust_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.CleanThrust, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6zSTQZXK}Increases your combat movement speed with polearms by 2%.")]
    [SettingPropertyGroup("Perks/Polearm/{=Yvk8a2tb}Footwork")]
    public float plm_Footwork_p {
      get => _plm_Footwork_p;
      set {
        if (_plm_Footwork_p != value) {
          _plm_Footwork_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Footwork, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=jdQuO7Qf}Infantry troops in the formation you are leading have their movement speed increased by 2%.")]
    [SettingPropertyGroup("Perks/Polearm/{=Yvk8a2tb}Footwork")]
    public float plm_Footwork_s {
      get => _plm_Footwork_s;
      set {
        if (_plm_Footwork_s != value) {
          _plm_Footwork_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Footwork, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ft6k4Fav}Polearm attacks that deal damage over 25% of your opponent's hit points have 25% chance to knock them down.")]
    [SettingPropertyGroup("Perks/Polearm/{=8DTKXbKw}Hard Knock")]
    public float plm_HardKnock_p {
      get => _plm_HardKnock_p;
      set {
        if (_plm_HardKnock_p != value) {
          _plm_HardKnock_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.HardKnock, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gTuRHrjO}Infantry troops in the party you are leading gain 3 hit points.")]
    [SettingPropertyGroup("Perks/Polearm/{=8DTKXbKw}Hard Knock")]
    public float plm_HardKnock_s {
      get => _plm_HardKnock_s;
      set {
        if (_plm_HardKnock_s != value) {
          _plm_HardKnock_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.HardKnock, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=GcycaG5L}Increases your damage with polearms by 70% against mounts.")]
    [SettingPropertyGroup("Perks/Polearm/{=8POWjrr6}Steed Killer")]
    public float plm_SteedKiller_p {
      get => _plm_SteedKiller_p;
      set {
        if (_plm_SteedKiller_p != value) {
          _plm_SteedKiller_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.SteedKiller, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=FLxu1bc0}Infantry troops in the formation you are leading increase have their damage increased with polearms by 30% against mounts.")]
    [SettingPropertyGroup("Perks/Polearm/{=8POWjrr6}Steed Killer")]
    public float plm_SteedKiller_s {
      get => _plm_SteedKiller_s;
      set {
        if (_plm_SteedKiller_s != value) {
          _plm_SteedKiller_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.SteedKiller, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=eL9RlPbj}Increases your speed damage bonus with polearms by 20% while mounted.")]
    [SettingPropertyGroup("Perks/Polearm/{=hchDYAKL}Lancer")]
    public float plm_Lancer_p {
      get => _plm_Lancer_p;
      set {
        if (_plm_Lancer_p != value) {
          _plm_Lancer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Lancer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=tm52b6ji}Troops in the formation you are leading have their damage speed bonus with polearms increased by 20%.")]
    [SettingPropertyGroup("Perks/Polearm/{=hchDYAKL}Lancer")]
    public float plm_Lancer_s {
      get => _plm_Lancer_s;
      set {
        if (_plm_Lancer_s != value) {
          _plm_Lancer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Lancer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=jD7aFORo}Your couch lance now has a 30% chance to stay couched after it kills someone.")]
    [SettingPropertyGroup("Perks/Polearm/{=o57z0zB9}Skewer")]
    public float plm_Skewer_p {
      get => _plm_Skewer_p;
      set {
        if (_plm_Skewer_p != value) {
          _plm_Skewer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Skewer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=lB12FYqb}Governed settlements gain 1 security per day.")]
    [SettingPropertyGroup("Perks/Polearm/{=o57z0zB9}Skewer")]
    public float plm_Skewer_s {
      get => _plm_Skewer_s;
      set {
        if (_plm_Skewer_s != value) {
          _plm_Skewer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Skewer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=LUTwOksA}When you hit an enemy in the head with a polearm you deal 50% more damage.")]
    [SettingPropertyGroup("Perks/Polearm/{=vquApOWo}Guards")]
    public float plm_Guards_p {
      get => _plm_Guards_p;
      set {
        if (_plm_Guards_p != value) {
          _plm_Guards_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Guards, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=s4BKLQc1}Experience gain of garrisoned cavalry in governed settlements is increased by 20%.")]
    [SettingPropertyGroup("Perks/Polearm/{=vquApOWo}Guards")]
    public float plm_Guards_s {
      get => _plm_Guards_s;
      set {
        if (_plm_Guards_s != value) {
          _plm_Guards_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Guards, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=o6J5b0M2}Troops in your formation have 20% less morale loss.")]
    [SettingPropertyGroup("Perks/Polearm/{=Vv81gkWN}Standard Bearer")]
    public float plm_StandardBearer_p {
      get => _plm_StandardBearer_p;
      set {
        if (_plm_StandardBearer_p != value) {
          _plm_StandardBearer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.StandardBearer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=IyRHO2Ez}Garrisoned infantry in governed settlements have their wages reduced by 20%.")]
    [SettingPropertyGroup("Perks/Polearm/{=Vv81gkWN}Standard Bearer")]
    public float plm_StandardBearer_s {
      get => _plm_StandardBearer_s;
      set {
        if (_plm_StandardBearer_s != value) {
          _plm_StandardBearer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.StandardBearer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xWbSbNqy}Infantry in your party have their melee weapon skills increased by 30 while in shield wall formation.")]
    [SettingPropertyGroup("Perks/Polearm/{=5vs3qlQ8}Phalanx")]
    public float plm_Phalanx_p {
      get => _plm_Phalanx_p;
      set {
        if (_plm_Phalanx_p != value) {
          _plm_Phalanx_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Phalanx, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=EtRkxd6x}Troops in the formation you are leading have their damage with polearms increased by 3%.")]
    [SettingPropertyGroup("Perks/Polearm/{=5vs3qlQ8}Phalanx")]
    public float plm_Phalanx_s {
      get => _plm_Phalanx_s;
      set {
        if (_plm_Phalanx_s != value) {
          _plm_Phalanx_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Phalanx, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=g7a7vk3S}Troops in your party gain 5 hit points.")]
    [SettingPropertyGroup("Perks/Polearm/{=yBa95LU3}Generous Rations")]
    public float plm_GenerousRations_p {
      get => _plm_GenerousRations_p;
      set {
        if (_plm_GenerousRations_p != value) {
          _plm_GenerousRations_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.GenerousRations, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=nKn6m1LH}Reduces recruitment cost of infantry troops by 20%.")]
    [SettingPropertyGroup("Perks/Polearm/{=yBa95LU3}Generous Rations")]
    public float plm_GenerousRations_s {
      get => _plm_GenerousRations_s;
      set {
        if (_plm_GenerousRations_s != value) {
          _plm_GenerousRations_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.GenerousRations, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=IYyuc1fz}Governed settlements gain 0.5 militia per day.")]
    [SettingPropertyGroup("Perks/Polearm/{=JpiQagYa}Drills")]
    public float plm_Drills_p {
      get => _plm_Drills_p;
      set {
        if (_plm_Drills_p != value) {
          _plm_Drills_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.Drills, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=BC1vxpPb}All troops in your party gain additional 1 xp per day.")]
    [SettingPropertyGroup("Perks/Polearm/{=JpiQagYa}Drills")]
    public float plm_Drills_s {
      get => _plm_Drills_s;
      set {
        if (_plm_Drills_s != value) {
          _plm_Drills_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.Drills, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=KT9rp0v9}Increases your defence against mount charge damage by 50%.")]
    [SettingPropertyGroup("Perks/Polearm/{=bdzt4TcN}Sure Footed")]
    public float plm_SureFooted_p {
      get => _plm_SureFooted_p;
      set {
        if (_plm_SureFooted_p != value) {
          _plm_SureFooted_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.SureFooted, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=ckTWlCtf}Infantry troops in the formation you are leading have their defence against mount charge damage increased by 30%.")]
    [SettingPropertyGroup("Perks/Polearm/{=bdzt4TcN}Sure Footed")]
    public float plm_SureFooted_s {
      get => _plm_SureFooted_s;
      set {
        if (_plm_SureFooted_s != value) {
          _plm_SureFooted_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.SureFooted, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WXPGv7Si}Your couch lance attacks deal triple damage against shields.")]
    [SettingPropertyGroup("Perks/Polearm/{=Jat5GFDi}Unstoppable Force")]
    public float plm_UnstoppableForce_p {
      get => _plm_UnstoppableForce_p;
      set {
        if (_plm_UnstoppableForce_p != value) {
          _plm_UnstoppableForce_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.UnstoppableForce, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=3Kb5QJrN}Cavalry troops in the formation you are leading have their speed damage bonus with polearms increased by 30%.")]
    [SettingPropertyGroup("Perks/Polearm/{=Jat5GFDi}Unstoppable Force")]
    public float plm_UnstoppableForce_s {
      get => _plm_UnstoppableForce_s;
      set {
        if (_plm_UnstoppableForce_s != value) {
          _plm_UnstoppableForce_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.UnstoppableForce, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ufciD08A}Increase your handling of swingable polearms by 15%.")]
    [SettingPropertyGroup("Perks/Polearm/{=BazrgEOj}Counterweight")]
    public float plm_CounterWeight_p {
      get => _plm_CounterWeight_p;
      set {
        if (_plm_CounterWeight_p != value) {
          _plm_CounterWeight_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.CounterWeight, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=0mivh2E1}Infantry troops in the formation you are leading have their polearm skill increased by 20.")]
    [SettingPropertyGroup("Perks/Polearm/{=BazrgEOj}Counterweight")]
    public float plm_CounterWeight_s {
      get => _plm_CounterWeight_s;
      set {
        if (_plm_CounterWeight_s != value) {
          _plm_CounterWeight_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.CounterWeight, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=DzFvoy8r}Thrust attacks with polearms have 5% increased damage.")]
    [SettingPropertyGroup("Perks/Polearm/{=ljduhdzj}Sharpen the Tip")]
    public float plm_SharpenTheTip_p {
      get => _plm_SharpenTheTip_p;
      set {
        if (_plm_SharpenTheTip_p != value) {
          _plm_SharpenTheTip_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.SharpenTheTip, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xDuAJ7rA}Infantry troops in the formation you are leading have their thrust damage increased by 5%.")]
    [SettingPropertyGroup("Perks/Polearm/{=ljduhdzj}Sharpen the Tip")]
    public float plm_SharpenTheTip_s {
      get => _plm_SharpenTheTip_s;
      set {
        if (_plm_SharpenTheTip_s != value) {
          _plm_SharpenTheTip_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.SharpenTheTip, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=UDpWoSuA}Each skill point above 250 grants you 0.2% speed increase with polearms.")]
    [SettingPropertyGroup("Perks/Polearm/{=YnimoRlg}Way of the Spear")]
    public float plm_WayOfTheSpear_p {
      get => _plm_WayOfTheSpear_p;
      set {
        if (_plm_WayOfTheSpear_p != value) {
          _plm_WayOfTheSpear_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Polearm.WayOfTheSpear, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=nb0l067B}Each skill point above 250 grants you 0.5% damage increase with polearms.")]
    [SettingPropertyGroup("Perks/Polearm/{=YnimoRlg}Way of the Spear")]
    public float plm_WayOfTheSpear_s {
      get => _plm_WayOfTheSpear_s;
      set {
        if (_plm_WayOfTheSpear_s != value) {
          _plm_WayOfTheSpear_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Polearm.WayOfTheSpear, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=G0VizlNf}Decreases your bow accuracy loss due to movement by 30%.")]
    [SettingPropertyGroup("Perks/Bow/{=1zteHA7R}Bow Control")]
    public float bow_BowControl_p {
      get => _bow_BowControl_p;
      set {
        if (_bow_BowControl_p != value) {
          _bow_BowControl_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.BowControl, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=3pBnLqIM}Bow equipped troops in your formation gain 5% damage with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=1zteHA7R}Bow Control")]
    public float bow_BowControl_s {
      get => _bow_BowControl_s;
      set {
        if (_bow_BowControl_s != value) {
          _bow_BowControl_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.BowControl, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=lgV3IXwY}Increases your headshot damage bonus by 30% with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=FVLymWqW}Dead Aim")]
    public float bow_DeadAim_p {
      get => _bow_DeadAim_p;
      set {
        if (_bow_DeadAim_p != value) {
          _bow_DeadAim_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.DeadAim, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=luguToag}Bow equipped troops in your formation gain +20 Archery skill.")]
    [SettingPropertyGroup("Perks/Bow/{=FVLymWqW}Dead Aim")]
    public float bow_DeadAim_s {
      get => _bow_DeadAim_s;
      set {
        if (_bow_DeadAim_s != value) {
          _bow_DeadAim_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.DeadAim, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=xTUSAw9v}Your attacks with bows ignore 10% of enemy's armor.")]
    [SettingPropertyGroup("Perks/Bow/{=PDM8MzCA}Bodkin")]
    public float bow_Bodkin_p {
      get => _bow_Bodkin_p;
      set {
        if (_bow_Bodkin_p != value) {
          _bow_Bodkin_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.Bodkin, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=6nUa0FIl}Bow equipped troops in your formation ignores 5% of enemy's armor.")]
    [SettingPropertyGroup("Perks/Bow/{=PDM8MzCA}Bodkin")]
    public float bow_Bodkin_s {
      get => _bow_Bodkin_s;
      set {
        if (_bow_Bodkin_s != value) {
          _bow_Bodkin_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.Bodkin, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=cbwRp51K}Decreases the penalty to movement speed for reloading by 50%.")]
    [SettingPropertyGroup("Perks/Bow/{=p12tSfCC}Ranger's Swiftness")]
    public float bow_RangersSwiftness_p {
      get => _bow_RangersSwiftness_p;
      set {
        if (_bow_RangersSwiftness_p != value) {
          _bow_RangersSwiftness_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.RangersSwiftness, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ghbKql0E}Bow equipped troops in your formation gain 3% to their on foot movement speed.")]
    [SettingPropertyGroup("Perks/Bow/{=p12tSfCC}Ranger's Swiftness")]
    public float bow_RangersSwiftness_s {
      get => _bow_RangersSwiftness_s;
      set {
        if (_bow_RangersSwiftness_s != value) {
          _bow_RangersSwiftness_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.RangersSwiftness, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=03db314S}Increases your bow reload speed by 25%.")]
    [SettingPropertyGroup("Perks/Bow/{=Kc9oatmM}Rapid Fire")]
    public float bow_RapidFire_p {
      get => _bow_RapidFire_p;
      set {
        if (_bow_RapidFire_p != value) {
          _bow_RapidFire_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.RapidFire, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=eyIspJfB}Troops in your formation have their bow reload speed increased by 5%.")]
    [SettingPropertyGroup("Perks/Bow/{=Kc9oatmM}Rapid Fire")]
    public float bow_RapidFire_s {
      get => _bow_RapidFire_s;
      set {
        if (_bow_RapidFire_s != value) {
          _bow_RapidFire_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.RapidFire, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=Y2a6yycL}Decreases your bow accuracy loss due to rotating by 50%.")]
    [SettingPropertyGroup("Perks/Bow/{=nOZerIfl}Quick Adjustments")]
    public float bow_QuickAdjustments_p {
      get => _bow_QuickAdjustments_p;
      set {
        if (_bow_QuickAdjustments_p != value) {
          _bow_QuickAdjustments_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.QuickAdjustments, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=RDKNUawJ}Troops in your formation gain 5% accuracy with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=nOZerIfl}Quick Adjustments")]
    public float bow_QuickAdjustments_s {
      get => _bow_QuickAdjustments_s;
      set {
        if (_bow_QuickAdjustments_s != value) {
          _bow_QuickAdjustments_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.QuickAdjustments, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=920FKjJk}Increases your party size by 5.")]
    [SettingPropertyGroup("Perks/Bow/{=ssljPTUr}Merry Men")]
    public float bow_MerryMen_p {
      get => _bow_MerryMen_p;
      set {
        if (_bow_MerryMen_p != value) {
          _bow_MerryMen_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.MerryMen, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=b4BX9Fr5}Governed settlement gains 0.5 militia per day.")]
    [SettingPropertyGroup("Perks/Bow/{=ssljPTUr}Merry Men")]
    public float bow_MerryMen_s {
      get => _bow_MerryMen_s;
      set {
        if (_bow_MerryMen_s != value) {
          _bow_MerryMen_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.MerryMen, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=kK8Kom0h}Decreases mounted accuracy penalties by 30% while using a bow.")]
    [SettingPropertyGroup("Perks/Bow/{=WEUSMkCp}Mounted Archery")]
    public float bow_MountedArchery_p {
      get => _bow_MountedArchery_p;
      set {
        if (_bow_MountedArchery_p != value) {
          _bow_MountedArchery_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.MountedArchery, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=AsjB3siS}Range troops in governed settlement's garrison provide 20% more security.")]
    [SettingPropertyGroup("Perks/Bow/{=WEUSMkCp}Mounted Archery")]
    public float bow_MountedArchery_s {
      get => _bow_MountedArchery_s;
      set {
        if (_bow_MountedArchery_s != value) {
          _bow_MountedArchery_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.MountedArchery, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=fFk5dSXc}Everyday the party member with lowest bow skill gains experience in bow.")]
    [SettingPropertyGroup("Perks/Bow/{=UE2X5rAy}Trainer")]
    public float bow_Trainer_p {
      get => _bow_Trainer_p;
      set {
        if (_bow_Trainer_p != value) {
          _bow_Trainer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.Trainer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=H2zjWQLk}Bow equipped troops in your party gain +3 xp everyday.")]
    [SettingPropertyGroup("Perks/Bow/{=UE2X5rAy}Trainer")]
    public float bow_Trainer_s {
      get => _bow_Trainer_s;
      set {
        if (_bow_Trainer_s != value) {
          _bow_Trainer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.Trainer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=XzbpZji3}Increases your damage with bows by 8%.")]
    [SettingPropertyGroup("Perks/Bow/{=dqbbT5DK}Strong bows")]
    public float bow_StrongBows_p {
      get => _bow_StrongBows_p;
      set {
        if (_bow_StrongBows_p != value) {
          _bow_StrongBows_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.StrongBows, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gpPlaaey}Tier 3+ troops in your formation gain 5% damage with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=dqbbT5DK}Strong bows")]
    public float bow_StrongBows_s {
      get => _bow_StrongBows_s;
      set {
        if (_bow_StrongBows_s != value) {
          _bow_StrongBows_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.StrongBows, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=lWAmQK5a}You can hold your aim 50% longer without losing accuracy.")]
    [SettingPropertyGroup("Perks/Bow/{=D867vF71}Discipline")]
    public float bow_Discipline_p {
      get => _bow_Discipline_p;
      set {
        if (_bow_Discipline_p != value) {
          _bow_Discipline_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.Discipline, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=sbRKNK8h}+1 loyalty per day for governed settlement.")]
    [SettingPropertyGroup("Perks/Bow/{=D867vF71}Discipline")]
    public float bow_Discipline_s {
      get => _bow_Discipline_s;
      set {
        if (_bow_Discipline_s != value) {
          _bow_Discipline_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.Discipline, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bMPZi9OZ}Increases your damage against mounts with bows by 30%.")]
    [SettingPropertyGroup("Perks/Bow/{=AAy1oX7z}Hunter Clan")]
    public float bow_HunterClan_p {
      get => _bow_HunterClan_p;
      set {
        if (_bow_HunterClan_p != value) {
          _bow_HunterClan_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.HunterClan, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=UXaVb1Jt}Garrison maintenance costs are decreased by 15%.")]
    [SettingPropertyGroup("Perks/Bow/{=AAy1oX7z}Hunter Clan")]
    public float bow_HunterClan_s {
      get => _bow_HunterClan_s;
      set {
        if (_bow_HunterClan_s != value) {
          _bow_HunterClan_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.HunterClan, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=x6AYjN9a}You take 10% less damage from projectiles.")]
    [SettingPropertyGroup("Perks/Bow/{=oVdoauUE}Skirmish Phase Master")]
    public float bow_SkirmishPhaseMaster_p {
      get => _bow_SkirmishPhaseMaster_p;
      set {
        if (_bow_SkirmishPhaseMaster_p != value) {
          _bow_SkirmishPhaseMaster_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.SkirmishPhaseMaster, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=vPc4hyYy}Bow equipped troops in your formation take 5% less damage from projectiles.")]
    [SettingPropertyGroup("Perks/Bow/{=oVdoauUE}Skirmish Phase Master")]
    public float bow_SkirmishPhaseMaster_s {
      get => _bow_SkirmishPhaseMaster_s;
      set {
        if (_bow_SkirmishPhaseMaster_s != value) {
          _bow_SkirmishPhaseMaster_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.SkirmishPhaseMaster, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=pJcsJaW2}You can zoom in 50% more with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=lq67KjSY}Eagle Eye")]
    public float bow_EagleEye_p {
      get => _bow_EagleEye_p;
      set {
        if (_bow_EagleEye_p != value) {
          _bow_EagleEye_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.EagleEye, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=h7zHLPX5}Increases your visual range in campaign map by 10%.")]
    [SettingPropertyGroup("Perks/Bow/{=lq67KjSY}Eagle Eye")]
    public float bow_EagleEye_s {
      get => _bow_EagleEye_s;
      set {
        if (_bow_EagleEye_s != value) {
          _bow_EagleEye_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.EagleEye, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=6ncPxxfa}Ranged troops in your party gain an additional 10% of the total xp earned after battles.")]
    [SettingPropertyGroup("Perks/Bow/{=QH77Weyq}Bulls Eye")]
    public float bow_BullsEye_p {
      get => _bow_BullsEye_p;
      set {
        if (_bow_BullsEye_p != value) {
          _bow_BullsEye_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.BullsEye, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bcONdncG}+2 xp daily to all troops in garrison to governed settlement.")]
    [SettingPropertyGroup("Perks/Bow/{=QH77Weyq}Bulls Eye")]
    public float bow_BullsEye_s {
      get => _bow_BullsEye_s;
      set {
        if (_bow_BullsEye_s != value) {
          _bow_BullsEye_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.BullsEye, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WYPotR6p}Increases morale of range troops in your party at the beginning of battle by 10%.")]
    [SettingPropertyGroup("Perks/Bow/{=aIKVpGvE}Renowned Archer")]
    public float bow_RenownedArcher_p {
      get => _bow_RenownedArcher_p;
      set {
        if (_bow_RenownedArcher_p != value) {
          _bow_RenownedArcher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.RenownedArcher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=u0j3Nfmc}Ranged troops are 30% cheaper to recruit and to upgrade.")]
    [SettingPropertyGroup("Perks/Bow/{=aIKVpGvE}Renowned Archer")]
    public float bow_RenownedArcher_s {
      get => _bow_RenownedArcher_s;
      set {
        if (_bow_RenownedArcher_s != value) {
          _bow_RenownedArcher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.RenownedArcher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=LiaRnWJZ}You can now use all bows on horseback.")]
    [SettingPropertyGroup("Perks/Bow/{=dbUybDTG}Horse Master")]
    public float bow_HorseMaster_p {
      get => _bow_HorseMaster_p;
      set {
        if (_bow_HorseMaster_p != value) {
          _bow_HorseMaster_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.HorseMaster, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=EHBkdRfV}Mounted archers in your formation gain +30 bow skill.")]
    [SettingPropertyGroup("Perks/Bow/{=dbUybDTG}Horse Master")]
    public float bow_HorseMaster_s {
      get => _bow_HorseMaster_s;
      set {
        if (_bow_HorseMaster_s != value) {
          _bow_HorseMaster_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.HorseMaster, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ll4s461C}You get 3 extra arrows per quiver.")]
    [SettingPropertyGroup("Perks/Bow/{=h83ZU95t}Deep Quivers")]
    public float bow_DeepQuivers_p {
      get => _bow_DeepQuivers_p;
      set {
        if (_bow_DeepQuivers_p != value) {
          _bow_DeepQuivers_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.DeepQuivers, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=KOyGEcbQ}Bow equipped troops in your party gain 1 extra arrow per quiver.")]
    [SettingPropertyGroup("Perks/Bow/{=h83ZU95t}Deep Quivers")]
    public float bow_DeepQuivers_s {
      get => _bow_DeepQuivers_s;
      set {
        if (_bow_DeepQuivers_s != value) {
          _bow_DeepQuivers_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.DeepQuivers, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=MOITVVNu}Aiming with your bow is 25% faster.")]
    [SettingPropertyGroup("Perks/Bow/{=vnJndBgT}Quick Draw")]
    public float bow_QuickDraw_p {
      get => _bow_QuickDraw_p;
      set {
        if (_bow_QuickDraw_p != value) {
          _bow_QuickDraw_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.QuickDraw, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=9D6Xv3e8}Increases tax gain in governed settlement by 5%.")]
    [SettingPropertyGroup("Perks/Bow/{=vnJndBgT}Quick Draw")]
    public float bow_QuickDraw_s {
      get => _bow_QuickDraw_s;
      set {
        if (_bow_QuickDraw_s != value) {
          _bow_QuickDraw_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.QuickDraw, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=RQd005zy}Equipped bows do not slow you down.")]
    [SettingPropertyGroup("Perks/Bow/{=ZDNI6n9s}Salvo")]
    public float bow_Salvo_p {
      get => _bow_Salvo_p;
      set {
        if (_bow_Salvo_p != value) {
          _bow_Salvo_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.Salvo, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=AsjB3siS}Range troops in governed settlement's garrison provide 20% more security.")]
    [SettingPropertyGroup("Perks/Bow/{=ZDNI6n9s}Salvo")]
    public float bow_Salvo_s {
      get => _bow_Salvo_s;
      set {
        if (_bow_Salvo_s != value) {
          _bow_Salvo_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.Salvo, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=kgJ4hfd2}Each skill point above 200 grants you 0.2% speed increase with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=rsKhbZpJ}Deadshot")]
    public float bow_Deadshot_p {
      get => _bow_Deadshot_p;
      set {
        if (_bow_Deadshot_p != value) {
          _bow_Deadshot_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Bow.Deadshot, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=mXDS8YR0}Each skill point above 200 grants you 0.5% damage increase with bows.")]
    [SettingPropertyGroup("Perks/Bow/{=rsKhbZpJ}Deadshot")]
    public float bow_Deadshot_s {
      get => _bow_Deadshot_s;
      set {
        if (_bow_Deadshot_s != value) {
          _bow_Deadshot_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Bow.Deadshot, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=DyLbvdUw}Your crossbow attacks ignore armors below 20.")]
    [SettingPropertyGroup("Perks/Crossbow/{=v8RwzwqD}Piercer")]
    public float xbw_Piercer_p {
      get => _xbw_Piercer_p;
      set {
        if (_xbw_Piercer_p != value) {
          _xbw_Piercer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Piercer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=R71hUTU2}Ranged troops are 20% cheaper to recruit.")]
    [SettingPropertyGroup("Perks/Crossbow/{=v8RwzwqD}Piercer")]
    public float xbw_Piercer_s {
      get => _xbw_Piercer_s;
      set {
        if (_xbw_Piercer_s != value) {
          _xbw_Piercer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Piercer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=jojBRn0D}Aiming with your crossbow is 25% faster.")]
    [SettingPropertyGroup("Perks/Crossbow/{=IUGVdu64}Marksmen")]
    public float xbw_Marksmen_p {
      get => _xbw_Marksmen_p;
      set {
        if (_xbw_Marksmen_p != value) {
          _xbw_Marksmen_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Marksmen, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=U32R2S5O}Increases the morale of ranged troops at the start of the battle by 10%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=IUGVdu64}Marksmen")]
    public float xbw_Marksmen_s {
      get => _xbw_Marksmen_s;
      set {
        if (_xbw_Marksmen_s != value) {
          _xbw_Marksmen_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Marksmen, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=mTjktBP6}Increases crossbow damage against mounts by 40%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=75vJc53f}Unhorser")]
    public float xbw_Unhorser_p {
      get => _xbw_Unhorser_p;
      set {
        if (_xbw_Unhorser_p != value) {
          _xbw_Unhorser_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Unhorser, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=rYHlksFs}Crossbow equipped troops in your formation deal 20% more damage against mounts.")]
    [SettingPropertyGroup("Perks/Crossbow/{=75vJc53f}Unhorser")]
    public float xbw_Unhorser_s {
      get => _xbw_Unhorser_s;
      set {
        if (_xbw_Unhorser_s != value) {
          _xbw_Unhorser_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Unhorser, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=VtTMWJja}Reduces your crossbow reload time by 25%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=1bw2uw8H}Wind Winder")]
    public float xbw_WindWinder_p {
      get => _xbw_WindWinder_p;
      set {
        if (_xbw_WindWinder_p != value) {
          _xbw_WindWinder_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.WindWinder, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6Rh07aSi}Ranged troops' crossbow reload speed is increased by 5%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=1bw2uw8H}Wind Winder")]
    public float xbw_WindWinder_s {
      get => _xbw_WindWinder_s;
      set {
        if (_xbw_WindWinder_s != value) {
          _xbw_WindWinder_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.WindWinder, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=aq4NI3Ao}Decreases your crossbow accuracy loss due to movement by 30%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=uANbQUxg}Donkeys Swiftness")]
    public float xbw_DonkeysSwiftness_p {
      get => _xbw_DonkeysSwiftness_p;
      set {
        if (_xbw_DonkeysSwiftness_p != value) {
          _xbw_DonkeysSwiftness_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.DonkeysSwiftness, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6nm9biYR}Crossbow equipped troops in your formation have +30 crossbow skill.")]
    [SettingPropertyGroup("Perks/Crossbow/{=uANbQUxg}Donkeys Swiftness")]
    public float xbw_DonkeysSwiftness_s {
      get => _xbw_DonkeysSwiftness_s;
      set {
        if (_xbw_DonkeysSwiftness_s != value) {
          _xbw_DonkeysSwiftness_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.DonkeysSwiftness, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=1ndbOvdQ}Increases your head shot damage with crossbows by 50%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=leaowE4D}Sheriff")]
    public float xbw_Sheriff_p {
      get => _xbw_Sheriff_p;
      set {
        if (_xbw_Sheriff_p != value) {
          _xbw_Sheriff_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Sheriff, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=AD30RcU9}Troops in your formation deal 10% more damage against foot soldiers with crossbows.")]
    [SettingPropertyGroup("Perks/Crossbow/{=leaowE4D}Sheriff")]
    public float xbw_Sheriff_s {
      get => _xbw_Sheriff_s;
      set {
        if (_xbw_Sheriff_s != value) {
          _xbw_Sheriff_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Sheriff, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Arwl4bAi}Increases the morale of each Tier 1 to 3 troops by 10%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=2rPMYl7Y}Peasant Leader")]
    public float xbw_PeasantLeader_p {
      get => _xbw_PeasantLeader_p;
      set {
        if (_xbw_PeasantLeader_p != value) {
          _xbw_PeasantLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.PeasantLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=byX4TWWM}Reduces upkeep of ranged troops in the governed settlement's garrison by 20%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=2rPMYl7Y}Peasant Leader")]
    public float xbw_PeasantLeader_s {
      get => _xbw_PeasantLeader_s;
      set {
        if (_xbw_PeasantLeader_s != value) {
          _xbw_PeasantLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.PeasantLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HM60zpIf}Your ranged troops gain 2 xp everyday.")]
    [SettingPropertyGroup("Perks/Crossbow/{=ICkvftaM}Renown Marksmen")]
    public float xbw_RenownMarksmen_p {
      get => _xbw_RenownMarksmen_p;
      set {
        if (_xbw_RenownMarksmen_p != value) {
          _xbw_RenownMarksmen_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.RenownMarksmen, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=BaYbaMU2}Ranged troops in governed settlement's garrison provide 30% more security.")]
    [SettingPropertyGroup("Perks/Crossbow/{=ICkvftaM}Renown Marksmen")]
    public float xbw_RenownMarksmen_s {
      get => _xbw_RenownMarksmen_s;
      set {
        if (_xbw_RenownMarksmen_s != value) {
          _xbw_RenownMarksmen_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.RenownMarksmen, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=CiSkFsfa}Increases stack size for quivers by 4.")]
    [SettingPropertyGroup("Perks/Crossbow/{=FA5QlTvm}Fletcher")]
    public float xbw_Fletcher_p {
      get => _xbw_Fletcher_p;
      set {
        if (_xbw_Fletcher_p != value) {
          _xbw_Fletcher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Fletcher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=lslBxgaw}Crossbow equipped troops in your party gain 2 extra bolts per quiver.")]
    [SettingPropertyGroup("Perks/Crossbow/{=FA5QlTvm}Fletcher")]
    public float xbw_Fletcher_s {
      get => _xbw_Fletcher_s;
      set {
        if (_xbw_Fletcher_s != value) {
          _xbw_Fletcher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Fletcher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=retWZcQ0}Your attacks with crossbows ignore 10% of enemy's armor.")]
    [SettingPropertyGroup("Perks/Crossbow/{=jjkJyKoy}Puncture")]
    public float xbw_Puncture_p {
      get => _xbw_Puncture_p;
      set {
        if (_xbw_Puncture_p != value) {
          _xbw_Puncture_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Puncture, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=xORKx4wb}Crossbow equipped troops in your formation ignore 5% of enemy's armor.")]
    [SettingPropertyGroup("Perks/Crossbow/{=jjkJyKoy}Puncture")]
    public float xbw_Puncture_s {
      get => _xbw_Puncture_s;
      set {
        if (_xbw_Puncture_s != value) {
          _xbw_Puncture_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Puncture, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=BbaidhT4}Equipped crossbows do not slow you down.")]
    [SettingPropertyGroup("Perks/Crossbow/{=SKUPHeAw}Loose and Move")]
    public float xbw_LooseAndMove_p {
      get => _xbw_LooseAndMove_p;
      set {
        if (_xbw_LooseAndMove_p != value) {
          _xbw_LooseAndMove_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.LooseAndMove, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Lj6SwJYF}Ranged troops under your command have their their movement speed increased by 5%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=SKUPHeAw}Loose and Move")]
    public float xbw_LooseAndMove_s {
      get => _xbw_LooseAndMove_s;
      set {
        if (_xbw_LooseAndMove_s != value) {
          _xbw_LooseAndMove_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.LooseAndMove, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=nOjfjiUc}Doubles the interrupt threshold while you are reloading your crossbow.")]
    [SettingPropertyGroup("Perks/Crossbow/{=NYHeygaj}Deft Hands")]
    public float xbw_DeftHands_p {
      get => _xbw_DeftHands_p;
      set {
        if (_xbw_DeftHands_p != value) {
          _xbw_DeftHands_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.DeftHands, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=tVhDLrGY}Troops under your command have their interrupt threshold doubled while reloading their crossbows.")]
    [SettingPropertyGroup("Perks/Crossbow/{=NYHeygaj}Deft Hands")]
    public float xbw_DeftHands_s {
      get => _xbw_DeftHands_s;
      set {
        if (_xbw_DeftHands_s != value) {
          _xbw_DeftHands_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.DeftHands, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=NhQrsc1A}You can reload any crossbow on horseback.")]
    [SettingPropertyGroup("Perks/Crossbow/{=UZHvbYTr}Mounted Crossbowman")]
    public float xbw_MountedCrossbowman_p {
      get => _xbw_MountedCrossbowman_p;
      set {
        if (_xbw_MountedCrossbowman_p != value) {
          _xbw_MountedCrossbowman_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.MountedCrossbowman, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=pS7bgCl0}Ranged troops gain 5% more xp after battles.")]
    [SettingPropertyGroup("Perks/Crossbow/{=UZHvbYTr}Mounted Crossbowman")]
    public float xbw_MountedCrossbowman_s {
      get => _xbw_MountedCrossbowman_s;
      set {
        if (_xbw_MountedCrossbowman_s != value) {
          _xbw_MountedCrossbowman_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.MountedCrossbowman, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=TlA4utZV}The accuracy penalty while shooting crossbows from horseback is halved.")]
    [SettingPropertyGroup("Perks/Crossbow/{=Ye9lbBr3}Steady")]
    public float xbw_Steady_p {
      get => _xbw_Steady_p;
      set {
        if (_xbw_Steady_p != value) {
          _xbw_Steady_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Steady, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Wifppt09}Increases settlement tariff gain by 5%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=Ye9lbBr3}Steady")]
    public float xbw_Steady_s {
      get => _xbw_Steady_s;
      set {
        if (_xbw_Steady_s != value) {
          _xbw_Steady_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Steady, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=VWPbNJrY}You can zoom in 100% more with crossbows.")]
    [SettingPropertyGroup("Perks/Crossbow/{=aT0uYDuo}Sniper")]
    public float xbw_Sniper_p {
      get => _xbw_Sniper_p;
      set {
        if (_xbw_Sniper_p != value) {
          _xbw_Sniper_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Sniper, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=UIuKnT2h}Governed settlement gains +1 militia per day.")]
    [SettingPropertyGroup("Perks/Crossbow/{=aT0uYDuo}Sniper")]
    public float xbw_Sniper_s {
      get => _xbw_Sniper_s;
      set {
        if (_xbw_Sniper_s != value) {
          _xbw_Sniper_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Sniper, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=3hcbkk2i}Crossbow hits dismount enemy cavalry when they deal damage over 25% of their hit points.")]
    [SettingPropertyGroup("Perks/Crossbow/{=FjMS9Mbz}Hammer Bolts")]
    public float xbw_HammerBolts_p {
      get => _xbw_HammerBolts_p;
      set {
        if (_xbw_HammerBolts_p != value) {
          _xbw_HammerBolts_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.HammerBolts, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=JFvZAuKl}Crossbow equipped troops in your formation gain 10% damage with crossbows.")]
    [SettingPropertyGroup("Perks/Crossbow/{=FjMS9Mbz}Hammer Bolts")]
    public float xbw_HammerBolts_s {
      get => _xbw_HammerBolts_s;
      set {
        if (_xbw_HammerBolts_s != value) {
          _xbw_HammerBolts_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.HammerBolts, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=yL192BsB}Shield on your back has a 75% chance of blocking projectile damage from behind.")]
    [SettingPropertyGroup("Perks/Crossbow/{=2667CwaK}Pavise")]
    public float xbw_Pavise_p {
      get => _xbw_Pavise_p;
      set {
        if (_xbw_Pavise_p != value) {
          _xbw_Pavise_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Pavise, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=3nla4sSL}Governed settlement's ballistae gain 30% bonus accuracy in siege bombardment phase.")]
    [SettingPropertyGroup("Perks/Crossbow/{=2667CwaK}Pavise")]
    public float xbw_Pavise_s {
      get => _xbw_Pavise_s;
      set {
        if (_xbw_Pavise_s != value) {
          _xbw_Pavise_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Pavise, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=1nRyaC98}You have a 20% chance to increase bombardment casualties by 1 unit.")]
    [SettingPropertyGroup("Perks/Crossbow/{=nAlCj2m0}Terror")]
    public float xbw_Terror_p {
      get => _xbw_Terror_p;
      set {
        if (_xbw_Terror_p != value) {
          _xbw_Terror_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.Terror, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ddcEaGrG}Your troops' crossbow kills inflict 25% more morale loss to enemy.")]
    [SettingPropertyGroup("Perks/Crossbow/{=nAlCj2m0}Terror")]
    public float xbw_Terror_s {
      get => _xbw_Terror_s;
      set {
        if (_xbw_Terror_s != value) {
          _xbw_Terror_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.Terror, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=wGoEB4ba}Upkeep of tier 4+ ranged troops are reduced by 50%.")]
    [SettingPropertyGroup("Perks/Crossbow/{=nGWmyZCs}Picked Shots")]
    public float xbw_PickedShots_p {
      get => _xbw_PickedShots_p;
      set {
        if (_xbw_PickedShots_p != value) {
          _xbw_PickedShots_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.PickedShots, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dQyiRllV}Your ranged troops have +5 hit points.")]
    [SettingPropertyGroup("Perks/Crossbow/{=nGWmyZCs}Picked Shots")]
    public float xbw_PickedShots_s {
      get => _xbw_PickedShots_s;
      set {
        if (_xbw_PickedShots_s != value) {
          _xbw_PickedShots_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.PickedShots, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=isepwTYW}Each skill point above 200 grants you 0.2% speed increase with crossbows.")]
    [SettingPropertyGroup("Perks/Crossbow/{=ZFtyxzT5}Mighty Pull")]
    public float xbw_MightyPull_p {
      get => _xbw_MightyPull_p;
      set {
        if (_xbw_MightyPull_p != value) {
          _xbw_MightyPull_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crossbow.MightyPull, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ujSlI1fl}Each skill point above 200 grants you 0.5% damage increase with crossbows.")]
    [SettingPropertyGroup("Perks/Crossbow/{=ZFtyxzT5}Mighty Pull")]
    public float xbw_MightyPull_s {
      get => _xbw_MightyPull_s;
      set {
        if (_xbw_MightyPull_s != value) {
          _xbw_MightyPull_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Crossbow.MightyPull, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Og8QMFeC}Increases your drawing speed with throwing weapons by 20%.")]
    [SettingPropertyGroup("Perks/Throwing/{=vnJndBgT}Quick Draw")]
    public float thr_QuickDraw_p {
      get => _thr_QuickDraw_p;
      set {
        if (_thr_QuickDraw_p != value) {
          _thr_QuickDraw_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.QuickDraw, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=kQtrLwVD}Increases your troops' drawing speed of throwing weapons by 10%.")]
    [SettingPropertyGroup("Perks/Throwing/{=vnJndBgT}Quick Draw")]
    public float thr_QuickDraw_s {
      get => _thr_QuickDraw_s;
      set {
        if (_thr_QuickDraw_s != value) {
          _thr_QuickDraw_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.QuickDraw, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=JfLCWjqI}You deal 40% more damage with throwing weapons against shields.")]
    [SettingPropertyGroup("Perks/Throwing/{=DeWp2GjP}Shield Breaker")]
    public float thr_ShieldBreaker_p {
      get => _thr_ShieldBreaker_p;
      set {
        if (_thr_ShieldBreaker_p != value) {
          _thr_ShieldBreaker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.ShieldBreaker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=SP5n2GOz}Troops in your formation deal 8% more damage with throwing weapons against shields.")]
    [SettingPropertyGroup("Perks/Throwing/{=DeWp2GjP}Shield Breaker")]
    public float thr_ShieldBreaker_s {
      get => _thr_ShieldBreaker_s;
      set {
        if (_thr_ShieldBreaker_s != value) {
          _thr_ShieldBreaker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.ShieldBreaker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bqjL4vxF}Deal 40% more damage with throwing weapons against horses.")]
    [SettingPropertyGroup("Perks/Throwing/{=xnDWqYKW}Hunter")]
    public float thr_Hunter_p {
      get => _thr_Hunter_p;
      set {
        if (_thr_Hunter_p != value) {
          _thr_Hunter_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.Hunter, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=IqcdcG9j}Troops in your formation deal 8% more damage with throwing weapons against mounts.")]
    [SettingPropertyGroup("Perks/Throwing/{=xnDWqYKW}Hunter")]
    public float thr_Hunter_s {
      get => _thr_Hunter_s;
      set {
        if (_thr_Hunter_s != value) {
          _thr_Hunter_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.Hunter, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6GldhQg8}Melee usage of thrown weapons deals 10% more damage.")]
    [SettingPropertyGroup("Perks/Throwing/{=mPPWRjCZ}Flexible Fighter")]
    public float thr_FlexibleFighter_p {
      get => _thr_FlexibleFighter_p;
      set {
        if (_thr_FlexibleFighter_p != value) {
          _thr_FlexibleFighter_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.FlexibleFighter, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=N8UfRVVH}Decreases mounted accuracy penalties by 20% while using a throwing weapon.")]
    [SettingPropertyGroup("Perks/Throwing/{=l1I748Fn}Mounted Skirmisher")]
    public float thr_MountedSkirmisher_p {
      get => _thr_MountedSkirmisher_p;
      set {
        if (_thr_MountedSkirmisher_p != value) {
          _thr_MountedSkirmisher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.MountedSkirmisher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=VLIlhrRx}Mounted troops under your command deal 10% more damage with thrown weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=l1I748Fn}Mounted Skirmisher")]
    public float thr_MountedSkirmisher_s {
      get => _thr_MountedSkirmisher_s;
      set {
        if (_thr_MountedSkirmisher_s != value) {
          _thr_MountedSkirmisher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.MountedSkirmisher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bRdjTD7Q}Projectile speed of your throwing weapons is increased by 25%.")]
    [SettingPropertyGroup("Perks/Throwing/{=BCoQgZvG}Perfect Technique")]
    public float thr_PerfectTechnique_p {
      get => _thr_PerfectTechnique_p;
      set {
        if (_thr_PerfectTechnique_p != value) {
          _thr_PerfectTechnique_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.PerfectTechnique, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xPt71fIC}Troops under your command have their projectile speed increased by 10%.")]
    [SettingPropertyGroup("Perks/Throwing/{=BCoQgZvG}Perfect Technique")]
    public float thr_PerfectTechnique_s {
      get => _thr_PerfectTechnique_s;
      set {
        if (_thr_PerfectTechnique_s != value) {
          _thr_PerfectTechnique_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.PerfectTechnique, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=6fMGZbXD}Your throwing weapons gain 25% additional speed from your movement.")]
    [SettingPropertyGroup("Perks/Throwing/{=OcaW12fJ}Running Throw")]
    public float thr_RunningThrow_p {
      get => _thr_RunningThrow_p;
      set {
        if (_thr_RunningThrow_p != value) {
          _thr_RunningThrow_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.RunningThrow, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=h1juSIZx}Troops under your command have +30 throwing skill.")]
    [SettingPropertyGroup("Perks/Throwing/{=OcaW12fJ}Running Throw")]
    public float thr_RunningThrow_s {
      get => _thr_RunningThrow_s;
      set {
        if (_thr_RunningThrow_s != value) {
          _thr_RunningThrow_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.RunningThrow, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dEItpQvn}Thrown weapon hits that deal damage over 25% of enemy cavalry's hit points have 50% chance to dismount them.")]
    [SettingPropertyGroup("Perks/Throwing/{=Gn3KBN8L}Knock Off")]
    public float thr_KnockOff_p {
      get => _thr_KnockOff_p;
      set {
        if (_thr_KnockOff_p != value) {
          _thr_KnockOff_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.KnockOff, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=DjYcaHTw}Troops in the formation you control deal 5% more throwing weapon damage against enemy cavalry.")]
    [SettingPropertyGroup("Perks/Throwing/{=Gn3KBN8L}Knock Off")]
    public float thr_KnockOff_s {
      get => _thr_KnockOff_s;
      set {
        if (_thr_KnockOff_s != value) {
          _thr_KnockOff_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.KnockOff, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=5zkewF8C}You have +1 ammunition for throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=bloxcikL}Well Prepared")]
    public float thr_WellPrepared_p {
      get => _thr_WellPrepared_p;
      set {
        if (_thr_WellPrepared_p != value) {
          _thr_WellPrepared_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.WellPrepared, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WiJZC36N}Ranged troops in your party have 25% chance of having +1 ammunition for throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=bloxcikL}Well Prepared")]
    public float thr_WellPrepared_s {
      get => _thr_WellPrepared_s;
      set {
        if (_thr_WellPrepared_s != value) {
          _thr_WellPrepared_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.WellPrepared, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=BSLbbQ7j}You can zoom in 25% more with throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=throwingskillfocus}Focus")]
    public float thr_Focus_p {
      get => _thr_Focus_p;
      set {
        if (_thr_Focus_p != value) {
          _thr_Focus_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.Focus, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=8coU5Ff5}Increases security of governed settlement by 1.")]
    [SettingPropertyGroup("Perks/Throwing/{=throwingskillfocus}Focus")]
    public float thr_Focus_s {
      get => _thr_Focus_s;
      set {
        if (_thr_Focus_s != value) {
          _thr_Focus_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.Focus, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=csKot5g4}Your throwing weapons deal 50% more damage to enemies with less than 50% hit points left.")]
    [SettingPropertyGroup("Perks/Throwing/{=IsHyjvSq}Last Hit")]
    public float thr_LastHit_p {
      get => _thr_LastHit_p;
      set {
        if (_thr_LastHit_p != value) {
          _thr_LastHit_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.LastHit, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ZMYTashc}Increases the morale of your party at the start of the battle by 5.")]
    [SettingPropertyGroup("Perks/Throwing/{=IsHyjvSq}Last Hit")]
    public float thr_LastHit_s {
      get => _thr_LastHit_s;
      set {
        if (_thr_LastHit_s != value) {
          _thr_LastHit_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.LastHit, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=aDbvfb8z}+50% damage to headshots with thrown weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=iARYMyuq}Head Hunter")]
    public float thr_HeadHunter_p {
      get => _thr_HeadHunter_p;
      set {
        if (_thr_HeadHunter_p != value) {
          _thr_HeadHunter_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.HeadHunter, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=MoHbMLEa}Tier 2+ troops are 20% cheaper to recruit.")]
    [SettingPropertyGroup("Perks/Throwing/{=iARYMyuq}Head Hunter")]
    public float thr_HeadHunter_s {
      get => _thr_HeadHunter_s;
      set {
        if (_thr_HeadHunter_s != value) {
          _thr_HeadHunter_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.HeadHunter, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=32MHeh5r}Infantry upgrades are 20% cheaper.")]
    [SettingPropertyGroup("Perks/Throwing/{=cC8iTtg5}Throwing Competitions")]
    public float thr_ThrowingCompetitions_p {
      get => _thr_ThrowingCompetitions_p;
      set {
        if (_thr_ThrowingCompetitions_p != value) {
          _thr_ThrowingCompetitions_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.ThrowingCompetitions, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=b4BX9Fr5}Governed settlement gains 0.5 militia per day.")]
    [SettingPropertyGroup("Perks/Throwing/{=cC8iTtg5}Throwing Competitions")]
    public float thr_ThrowingCompetitions_s {
      get => _thr_ThrowingCompetitions_s;
      set {
        if (_thr_ThrowingCompetitions_s != value) {
          _thr_ThrowingCompetitions_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.ThrowingCompetitions, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=mQYqKCIK}Your throwing axes deal triple damage to shields.")]
    [SettingPropertyGroup("Perks/Throwing/{=b6W74uyR}Splinters")]
    public float thr_Splinters_p {
      get => _thr_Splinters_p;
      set {
        if (_thr_Splinters_p != value) {
          _thr_Splinters_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.Splinters, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=qCCLpjAa}Troops under your command deal 50% more damage to shields with throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=b6W74uyR}Splinters")]
    public float thr_Splinters_s {
      get => _thr_Splinters_s;
      set {
        if (_thr_Splinters_s != value) {
          _thr_Splinters_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.Splinters, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=FaJa4YD5}You have +2 ammunition for throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=w53LSPJ1}Resourceful")]
    public float thr_Resourceful_p {
      get => _thr_Resourceful_p;
      set {
        if (_thr_Resourceful_p != value) {
          _thr_Resourceful_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.Resourceful, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=IiMfnxMC}Throwing weapon equipped troops gain 10% more xp after battles.")]
    [SettingPropertyGroup("Perks/Throwing/{=w53LSPJ1}Resourceful")]
    public float thr_Resourceful_s {
      get => _thr_Resourceful_s;
      set {
        if (_thr_Resourceful_s != value) {
          _thr_Resourceful_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.Resourceful, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=leKleLYK}You can pick up spears or weapons from the ground while mounted.")]
    [SettingPropertyGroup("Perks/Throwing/{=9iLyu1kp}Long Reach")]
    public float thr_LongReach_p {
      get => _thr_LongReach_p;
      set {
        if (_thr_LongReach_p != value) {
          _thr_LongReach_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.LongReach, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=kVSO17rc}Winning battles give 20% more morale and renown.")]
    [SettingPropertyGroup("Perks/Throwing/{=9iLyu1kp}Long Reach")]
    public float thr_LongReach_s {
      get => _thr_LongReach_s;
      set {
        if (_thr_LongReach_s != value) {
          _thr_LongReach_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.LongReach, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=sFoPPLaX}Throwing weapons ignore 30% of enemy's armor.")]
    [SettingPropertyGroup("Perks/Throwing/{=cPPLAz8l}Weak Spot")]
    public float thr_WeakSpot_p {
      get => _thr_WeakSpot_p;
      set {
        if (_thr_WeakSpot_p != value) {
          _thr_WeakSpot_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.WeakSpot, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=2QWg8lOr}Troops in your formation ignore 10% of enemy's armor when attacking with thrown weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=cPPLAz8l}Weak Spot")]
    public float thr_WeakSpot_s {
      get => _thr_WeakSpot_s;
      set {
        if (_thr_WeakSpot_s != value) {
          _thr_WeakSpot_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.WeakSpot, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=6VtZJPSb}Javelins you throw penetrate shields like ballista bolts.")]
    [SettingPropertyGroup("Perks/Throwing/{=tYAYIRjr}Impale")]
    public float thr_Impale_p {
      get => _thr_Impale_p;
      set {
        if (_thr_Impale_p != value) {
          _thr_Impale_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.Impale, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=PzqAt7W5}Infantry troops in your formation deal 10% more damage with their throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=tYAYIRjr}Impale")]
    public float thr_Impale_s {
      get => _thr_Impale_s;
      set {
        if (_thr_Impale_s != value) {
          _thr_Impale_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.Impale, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=DIEjNmNa}Each skill point above 200 grants you 0.2% projectile speed increase with throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=Jat5GFDi}Unstoppable Force")]
    public float thr_UnstoppableForce_p {
      get => _thr_UnstoppableForce_p;
      set {
        if (_thr_UnstoppableForce_p != value) {
          _thr_UnstoppableForce_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Throwing.UnstoppableForce, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Abj4P4Hg}Each skill point above 200 grants you 0.5% damage increase with throwing weapons.")]
    [SettingPropertyGroup("Perks/Throwing/{=Jat5GFDi}Unstoppable Force")]
    public float thr_UnstoppableForce_s {
      get => _thr_UnstoppableForce_s;
      set {
        if (_thr_UnstoppableForce_s != value) {
          _thr_UnstoppableForce_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Throwing.UnstoppableForce, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NCJCEVkp}Increases your charge damage by 20%.")]
    [SettingPropertyGroup("Perks/Riding/{=kzy9Iduz}Full Speed")]
    public float rid_FullSpeed_p {
      get => _rid_FullSpeed_p;
      set {
        if (_rid_FullSpeed_p != value) {
          _rid_FullSpeed_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.FullSpeed, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=LU3lcIwl}Mounted troops in your formation gain +10% charge damage.")]
    [SettingPropertyGroup("Perks/Riding/{=kzy9Iduz}Full Speed")]
    public float rid_FullSpeed_s {
      get => _rid_FullSpeed_s;
      set {
        if (_rid_FullSpeed_s != value) {
          _rid_FullSpeed_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.FullSpeed, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=t2dcmd1L}Increases your maneuvering by 10%.")]
    [SettingPropertyGroup("Perks/Riding/{=cXlnH1Jp}Nimble Steed")]
    public float rid_NimbleSteed_p {
      get => _rid_NimbleSteed_p;
      set {
        if (_rid_NimbleSteed_p != value) {
          _rid_NimbleSteed_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.NimbleSteed, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=E42pGCZg}Mounted troops in your formation gain +30 riding skill.")]
    [SettingPropertyGroup("Perks/Riding/{=cXlnH1Jp}Nimble Steed")]
    public float rid_NimbleSteed_s {
      get => _rid_NimbleSteed_s;
      set {
        if (_rid_NimbleSteed_s != value) {
          _rid_NimbleSteed_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.NimbleSteed, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=nQ0uWQsv}Increases your mount's hit points by 20%.")]
    [SettingPropertyGroup("Perks/Riding/{=3lfS4iCZ}Well Strapped")]
    public float rid_WellStraped_p {
      get => _rid_WellStraped_p;
      set {
        if (_rid_WellStraped_p != value) {
          _rid_WellStraped_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.WellStraped, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=jCBbUvHx}Mounts of your commanded troops have 10% more hit points.")]
    [SettingPropertyGroup("Perks/Riding/{=3lfS4iCZ}Well Strapped")]
    public float rid_WellStraped_s {
      get => _rid_WellStraped_s;
      set {
        if (_rid_WellStraped_s != value) {
          _rid_WellStraped_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.WellStraped, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=g2qYB345}Halves the chance of your mount becoming lame or dead after it falls in battle.")]
    [SettingPropertyGroup("Perks/Riding/{=ZaSmz64G}Veterinary")]
    public float rid_Veterinary_p {
      get => _rid_Veterinary_p;
      set {
        if (_rid_Veterinary_p != value) {
          _rid_Veterinary_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.Veterinary, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=PTYKFbqf}Governed settlement gains +0.5 prosperity per day.")]
    [SettingPropertyGroup("Perks/Riding/{=ZaSmz64G}Veterinary")]
    public float rid_Veterinary_s {
      get => _rid_Veterinary_s;
      set {
        if (_rid_Veterinary_s != value) {
          _rid_Veterinary_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.Veterinary, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=EbSw2vj0}Mounted infantry increase your party speed by 30%.")]
    [SettingPropertyGroup("Perks/Riding/{=PB5iowxh}Nomadic Traditions")]
    public float rid_NomadicTraditions_p {
      get => _rid_NomadicTraditions_p;
      set {
        if (_rid_NomadicTraditions_p != value) {
          _rid_NomadicTraditions_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.NomadicTraditions, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=iIzShvKQ}Melee cavalry in your formation gain 10% speed damage bonus.")]
    [SettingPropertyGroup("Perks/Riding/{=PB5iowxh}Nomadic Traditions")]
    public float rid_NomadicTraditions_s {
      get => _rid_NomadicTraditions_s;
      set {
        if (_rid_NomadicTraditions_s != value) {
          _rid_NomadicTraditions_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.NomadicTraditions, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=ulgd9Veb}Increases carry capacity of pack animals by 20%.")]
    [SettingPropertyGroup("Perks/Riding/{=frQX6OZv}Filled To Brim")]
    public float rid_FilledToBrim_p {
      get => _rid_FilledToBrim_p;
      set {
        if (_rid_FilledToBrim_p != value) {
          _rid_FilledToBrim_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.FilledToBrim, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=1JDFcOwV}Better deal for buying and selling mounts.")]
    [SettingPropertyGroup("Perks/Riding/{=frQX6OZv}Filled To Brim")]
    public float rid_FilledToBrim_s {
      get => _rid_FilledToBrim_s;
      set {
        if (_rid_FilledToBrim_s != value) {
          _rid_FilledToBrim_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.FilledToBrim, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=dAau8qyS}Decreases accuracy penalty by 15% while you are mounted.")]
    [SettingPropertyGroup("Perks/Riding/{=jbPZTSP4}Sagittarius")]
    public float rid_Sagittarius_p {
      get => _rid_Sagittarius_p;
      set {
        if (_rid_Sagittarius_p != value) {
          _rid_Sagittarius_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.Sagittarius, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=LjMR6OuD}Decreases accuracy penalty by 15% for mounted ranged troops in your formation.")]
    [SettingPropertyGroup("Perks/Riding/{=jbPZTSP4}Sagittarius")]
    public float rid_Sagittarius_s {
      get => _rid_Sagittarius_s;
      set {
        if (_rid_Sagittarius_s != value) {
          _rid_Sagittarius_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.Sagittarius, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=hOyX7rSy}Increases your mount's top speed by 5%.")]
    [SettingPropertyGroup("Perks/Riding/{=gL7Ltjpc}Sweeping Wind")]
    public float rid_SweepingWind_p {
      get => _rid_SweepingWind_p;
      set {
        if (_rid_SweepingWind_p != value) {
          _rid_SweepingWind_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.SweepingWind, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=rl4fgGfh}Increases your party speed by 2%.")]
    [SettingPropertyGroup("Perks/Riding/{=gL7Ltjpc}Sweeping Wind")]
    public float rid_SweepingWind_s {
      get => _rid_SweepingWind_s;
      set {
        if (_rid_SweepingWind_s != value) {
          _rid_SweepingWind_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.SweepingWind, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=sgpEjTkv}Increases your mounted melee damage by 5%.")]
    [SettingPropertyGroup("Perks/Riding/{=ixqTFMVA}Mounted Warrior")]
    public float rid_MountedWarrior_p {
      get => _rid_MountedWarrior_p;
      set {
        if (_rid_MountedWarrior_p != value) {
          _rid_MountedWarrior_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.MountedWarrior, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=cFN6JaT2}Melee cavalry in your formation deals 5% more melee damage.")]
    [SettingPropertyGroup("Perks/Riding/{=ixqTFMVA}Mounted Warrior")]
    public float rid_MountedWarrior_s {
      get => _rid_MountedWarrior_s;
      set {
        if (_rid_MountedWarrior_s != value) {
          _rid_MountedWarrior_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.MountedWarrior, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=0iF5sNNZ}Increases your ranged damage by 10% while mounted.")]
    [SettingPropertyGroup("Perks/Riding/{=ugJfuabA}Horse Archer")]
    public float rid_HorseArcher_p {
      get => _rid_HorseArcher_p;
      set {
        if (_rid_HorseArcher_p != value) {
          _rid_HorseArcher_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.HorseArcher, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Ioyk7QVU}Mounted archers in your formation deal 5% more ranged damage.")]
    [SettingPropertyGroup("Perks/Riding/{=ugJfuabA}Horse Archer")]
    public float rid_HorseArcher_s {
      get => _rid_HorseArcher_s;
      set {
        if (_rid_HorseArcher_s != value) {
          _rid_HorseArcher_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.HorseArcher, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gIL4YKp3}Halves the party speed penalty for herding.")]
    [SettingPropertyGroup("Perks/Riding/{=BdQMQW8t}Riding Horde")]
    public float rid_Horde_p {
      get => _rid_Horde_p;
      set {
        if (_rid_Horde_p != value) {
          _rid_Horde_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.Horde, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ZHPpzEdM}Governed settlement's bound villages have better chance to produce Tier 2 horses.")]
    [SettingPropertyGroup("Perks/Riding/{=BdQMQW8t}Riding Horde")]
    public float rid_Horde_s {
      get => _rid_Horde_s;
      set {
        if (_rid_Horde_s != value) {
          _rid_Horde_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.Horde, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=5NwaDzcs}Animals in your inventory have a very low chance to reproduce.")]
    [SettingPropertyGroup("Perks/Riding/{=4Pbfs4rV}Breeder")]
    public float rid_Breeder_p {
      get => _rid_Breeder_p;
      set {
        if (_rid_Breeder_p != value) {
          _rid_Breeder_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.Breeder, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Hl33qopv}Governed settlement's bound villages have 5% more production rate.")]
    [SettingPropertyGroup("Perks/Riding/{=4Pbfs4rV}Breeder")]
    public float rid_Breeder_s {
      get => _rid_Breeder_s;
      set {
        if (_rid_Breeder_s != value) {
          _rid_Breeder_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.Breeder, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=qW2Vo7Gm}You cause 20% more battle morale penalty with melee kills while mounted.")]
    [SettingPropertyGroup("Perks/Riding/{=3MLtqFPt}Thunderous Charge")]
    public float rid_ThunderousCharge_p {
      get => _rid_ThunderousCharge_p;
      set {
        if (_rid_ThunderousCharge_p != value) {
          _rid_ThunderousCharge_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.ThunderousCharge, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dBRKCTao}Mounted troops in your formation cause 10% more battle morale penalty when they kill enemies in melee.")]
    [SettingPropertyGroup("Perks/Riding/{=3MLtqFPt}Thunderous Charge")]
    public float rid_ThunderousCharge_s {
      get => _rid_ThunderousCharge_s;
      set {
        if (_rid_ThunderousCharge_s != value) {
          _rid_ThunderousCharge_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.ThunderousCharge, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=S8Z1lYcq}You cause 20% more battle morale penalty with ranged kills while mounted.")]
    [SettingPropertyGroup("Perks/Riding/{=Okibjv5n}Annoying Buzz")]
    public float rid_AnnoyingBuzz_p {
      get => _rid_AnnoyingBuzz_p;
      set {
        if (_rid_AnnoyingBuzz_p != value) {
          _rid_AnnoyingBuzz_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.AnnoyingBuzz, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HM2XzVr7}Mounted troops in your formation cause 5% more battle morale penalty when they kill enemies on range.")]
    [SettingPropertyGroup("Perks/Riding/{=Okibjv5n}Annoying Buzz")]
    public float rid_AnnoyingBuzz_s {
      get => _rid_AnnoyingBuzz_s;
      set {
        if (_rid_AnnoyingBuzz_s != value) {
          _rid_AnnoyingBuzz_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.AnnoyingBuzz, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=cYvpUGq9}Prisoners in your party are 50% less likely to escape.")]
    [SettingPropertyGroup("Perks/Riding/{=1z3oRPQu}Mounted Patrols")]
    public float rid_MountedPatrols_p {
      get => _rid_MountedPatrols_p;
      set {
        if (_rid_MountedPatrols_p != value) {
          _rid_MountedPatrols_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.MountedPatrols, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=LrDbwars}Prisoners in governed town are 50% less likely to escape.")]
    [SettingPropertyGroup("Perks/Riding/{=1z3oRPQu}Mounted Patrols")]
    public float rid_MountedPatrols_s {
      get => _rid_MountedPatrols_s;
      set {
        if (_rid_MountedPatrols_s != value) {
          _rid_MountedPatrols_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.MountedPatrols, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=nZK2r5Gn}Cavalry troop volunteering rate is increased by 30% in the towns your clan govern.")]
    [SettingPropertyGroup("Perks/Riding/{=ZMxAGDKU}Cavalry Tactics")]
    public float rid_CavalryTactics_p {
      get => _rid_CavalryTactics_p;
      set {
        if (_rid_CavalryTactics_p != value) {
          _rid_CavalryTactics_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.CavalryTactics, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=6U6s0EuM}Mounted troops have 50% reduced wages in governed settlement's garrison.")]
    [SettingPropertyGroup("Perks/Riding/{=ZMxAGDKU}Cavalry Tactics")]
    public float rid_CavalryTactics_s {
      get => _rid_CavalryTactics_s;
      set {
        if (_rid_CavalryTactics_s != value) {
          _rid_CavalryTactics_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.CavalryTactics, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WczAmdQL}Increases your stagger damage threshold by 50% while mounted.")]
    [SettingPropertyGroup("Perks/Riding/{=eYzTvFEH}Dauntless Steed")]
    public float rid_DauntlessSteed_p {
      get => _rid_DauntlessSteed_p;
      set {
        if (_rid_DauntlessSteed_p != value) {
          _rid_DauntlessSteed_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.DauntlessSteed, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xvOUF9Kg}Mounted troops in your formation gain +5 armor.")]
    [SettingPropertyGroup("Perks/Riding/{=eYzTvFEH}Dauntless Steed")]
    public float rid_DauntlessSteed_s {
      get => _rid_DauntlessSteed_s;
      set {
        if (_rid_DauntlessSteed_s != value) {
          _rid_DauntlessSteed_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.DauntlessSteed, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=mxpRb5pd}Increases your mount's armor by 20%.")]
    [SettingPropertyGroup("Perks/Riding/{=vDNbHDfq}Tough Steed")]
    public float rid_ToughSteed_p {
      get => _rid_ToughSteed_p;
      set {
        if (_rid_ToughSteed_p != value) {
          _rid_ToughSteed_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.ToughSteed, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HZW39Tj2}Mounted troops in your formation gain +10 mount armor.")]
    [SettingPropertyGroup("Perks/Riding/{=vDNbHDfq}Tough Steed")]
    public float rid_ToughSteed_s {
      get => _rid_ToughSteed_s;
      set {
        if (_rid_ToughSteed_s != value) {
          _rid_ToughSteed_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.ToughSteed, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=IsuynJ2f}Increases your charge damage and maneuver by 1 for each 10 riding skill above 200.")]
    [SettingPropertyGroup("Perks/Riding/{=HvYgMtXO}The Way Of The Saddle")]
    public float rid_TheWayOfTheSaddle_p {
      get => _rid_TheWayOfTheSaddle_p;
      set {
        if (_rid_TheWayOfTheSaddle_p != value) {
          _rid_TheWayOfTheSaddle_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Riding.TheWayOfTheSaddle, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="Unknown")]
    [SettingPropertyGroup("Perks/Riding/{=HvYgMtXO}The Way Of The Saddle")]
    public float rid_TheWayOfTheSaddle_s {
      get => _rid_TheWayOfTheSaddle_s;
      set {
        if (_rid_TheWayOfTheSaddle_s != value) {
          _rid_TheWayOfTheSaddle_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Riding.TheWayOfTheSaddle, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=m4KacGv9}Increases your movement speed by 3%.")]
    [SettingPropertyGroup("Perks/Athletics/{=ipwU1JT3}Morning Exercise")]
    public float ath_MorningExercise_p {
      get => _ath_MorningExercise_p;
      set {
        if (_ath_MorningExercise_p != value) {
          _ath_MorningExercise_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.MorningExercise, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dyaagsuj}Foot troops in your formation gain 5% movement speed.")]
    [SettingPropertyGroup("Perks/Athletics/{=ipwU1JT3}Morning Exercise")]
    public float ath_MorningExercise_s {
      get => _ath_MorningExercise_s;
      set {
        if (_ath_MorningExercise_s != value) {
          _ath_MorningExercise_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.MorningExercise, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vixwTVbE}Increases your maximum hit points by 5.")]
    [SettingPropertyGroup("Perks/Athletics/{=bigS7KHi}Well Built")]
    public float ath_WellBuilt_p {
      get => _ath_WellBuilt_p;
      set {
        if (_ath_WellBuilt_p != value) {
          _ath_WellBuilt_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.WellBuilt, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HKNtU2NI}Foot troops in your party gain 5 hit points.")]
    [SettingPropertyGroup("Perks/Athletics/{=bigS7KHi}Well Built")]
    public float ath_WellBuilt_s {
      get => _ath_WellBuilt_s;
      set {
        if (_ath_WellBuilt_s != value) {
          _ath_WellBuilt_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.WellBuilt, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=D49gf45A}Decreases your armor weight by 15%.")]
    [SettingPropertyGroup("Perks/Athletics/{=tp3p7R8E}Form Fitting Armor")]
    public float ath_FormFittingArmor_p {
      get => _ath_FormFittingArmor_p;
      set {
        if (_ath_FormFittingArmor_p != value) {
          _ath_FormFittingArmor_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.FormFittingArmor, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=b7FbnGn6}Tier 3+ foot troops in your formation gain 4% movement speed.")]
    [SettingPropertyGroup("Perks/Athletics/{=tp3p7R8E}Form Fitting Armor")]
    public float ath_FormFittingArmor_s {
      get => _ath_FormFittingArmor_s;
      set {
        if (_ath_FormFittingArmor_s != value) {
          _ath_FormFittingArmor_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.FormFittingArmor, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=zEIe1ROP}Slightly increases your persuasion chance.")]
    [SettingPropertyGroup("Perks/Athletics/{=HqxV96aL}Having Going")]
    public float ath_HavingGoing_p {
      get => _ath_HavingGoing_p;
      set {
        if (_ath_HavingGoing_p != value) {
          _ath_HavingGoing_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.HavingGoing, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=920FKjJk}Increases your party size by 5.")]
    [SettingPropertyGroup("Perks/Athletics/{=HqxV96aL}Having Going")]
    public float ath_HavingGoing_s {
      get => _ath_HavingGoing_s;
      set {
        if (_ath_HavingGoing_s != value) {
          _ath_HavingGoing_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.HavingGoing, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=T3UdjMXf}Increases crafting stamina recovery rate by 50%.")]
    [SettingPropertyGroup("Perks/Athletics/{=2lCLp5eo}Stamina")]
    public float ath_Stamina_p {
      get => _ath_Stamina_p;
      set {
        if (_ath_Stamina_p != value) {
          _ath_Stamina_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Stamina, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6fFFbQS6}Increases your prisoner size limit by 5 and decreases prisoner escape chance by 10%.")]
    [SettingPropertyGroup("Perks/Athletics/{=2lCLp5eo}Stamina")]
    public float ath_Stamina_s {
      get => _ath_Stamina_s;
      set {
        if (_ath_Stamina_s != value) {
          _ath_Stamina_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.Stamina, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=jXepJAhO}Increases your damage by 4% with all melee weapons.")]
    [SettingPropertyGroup("Perks/Athletics/{=UCpyo9hw}Powerful")]
    public float ath_Powerful_p {
      get => _ath_Powerful_p;
      set {
        if (_ath_Powerful_p != value) {
          _ath_Powerful_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Powerful, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=G14cbf5j}Troops in your formation deal 2% more melee damage.")]
    [SettingPropertyGroup("Perks/Athletics/{=UCpyo9hw}Powerful")]
    public float ath_Powerful_s {
      get => _ath_Powerful_s;
      set {
        if (_ath_Powerful_s != value) {
          _ath_Powerful_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.Powerful, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=7Kz2tQbK}Increases your speed damage bonus by 30% while on foot.")]
    [SettingPropertyGroup("Perks/Athletics/{=zrYFYDfj}Surging Blow")]
    public float ath_SurgingBlow_p {
      get => _ath_SurgingBlow_p;
      set {
        if (_ath_SurgingBlow_p != value) {
          _ath_SurgingBlow_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.SurgingBlow, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=LVwh7Eba}Foot troops in your formation gain 30% speed damage bonus.")]
    [SettingPropertyGroup("Perks/Athletics/{=zrYFYDfj}Surging Blow")]
    public float ath_SurgingBlow_s {
      get => _ath_SurgingBlow_s;
      set {
        if (_ath_SurgingBlow_s != value) {
          _ath_SurgingBlow_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.SurgingBlow, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=MkbmHsAH}Decreases your charge damage taken by 50%.")]
    [SettingPropertyGroup("Perks/Athletics/{=dU7haWkI}Braced")]
    public float ath_Braced_p {
      get => _ath_Braced_p;
      set {
        if (_ath_Braced_p != value) {
          _ath_Braced_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Braced, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=xjtibL4J}Foot troops in your formation take 50% less charge damage.")]
    [SettingPropertyGroup("Perks/Athletics/{=dU7haWkI}Braced")]
    public float ath_Braced_s {
      get => _ath_Braced_s;
      set {
        if (_ath_Braced_s != value) {
          _ath_Braced_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.Braced, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=I0OtUEDb}Increases your hit point regeneration by 10% while traveling.")]
    [SettingPropertyGroup("Perks/Athletics/{=0pyLfrGZ}Walk It Off")]
    public float ath_WalkItOff_p {
      get => _ath_WalkItOff_p;
      set {
        if (_ath_WalkItOff_p != value) {
          _ath_WalkItOff_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.WalkItOff, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=aMHPsSe4}Foot troops in your party gain 3 xp everyday while traveling.")]
    [SettingPropertyGroup("Perks/Athletics/{=0pyLfrGZ}Walk It Off")]
    public float ath_WalkItOff_s {
      get => _ath_WalkItOff_s;
      set {
        if (_ath_WalkItOff_s != value) {
          _ath_WalkItOff_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.WalkItOff, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=QR80Vhdk}Increases your hit point regeneration by 10% while waiting in settlements.")]
    [SettingPropertyGroup("Perks/Athletics/{=B7HwvV6L}A Good Days Rest")]
    public float ath_AGoodDaysRest_p {
      get => _ath_AGoodDaysRest_p;
      set {
        if (_ath_AGoodDaysRest_p != value) {
          _ath_AGoodDaysRest_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.AGoodDaysRest, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=b38NeEp2}Foot troops in your party gain 10 xp everyday while waiting in settlements.")]
    [SettingPropertyGroup("Perks/Athletics/{=B7HwvV6L}A Good Days Rest")]
    public float ath_AGoodDaysRest_s {
      get => _ath_AGoodDaysRest_s;
      set {
        if (_ath_AGoodDaysRest_s != value) {
          _ath_AGoodDaysRest_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.AGoodDaysRest, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=7kZ7BucN}Increases your Endurance Attribute by 1.")]
    [SettingPropertyGroup("Perks/Athletics/{=LVeZLsbg}Healthy Citizens")]
    public float ath_HealthyCitizens_p {
      get => _ath_HealthyCitizens_p;
      set {
        if (_ath_HealthyCitizens_p != value) {
          _ath_HealthyCitizens_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.HealthyCitizens, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=AlY8Edde}Governed settlement gains 1 loyalty per day.")]
    [SettingPropertyGroup("Perks/Athletics/{=LVeZLsbg}Healthy Citizens")]
    public float ath_HealthyCitizens_s {
      get => _ath_HealthyCitizens_s;
      set {
        if (_ath_HealthyCitizens_s != value) {
          _ath_HealthyCitizens_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.HealthyCitizens, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=bMBqJx4h}Your party suffers 20% less from speed penalty for being overburdened.")]
    [SettingPropertyGroup("Perks/Athletics/{=1YxFYg3s}Energetic")]
    public float ath_Energetic_p {
      get => _ath_Energetic_p;
      set {
        if (_ath_Energetic_p != value) {
          _ath_Energetic_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Energetic, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=myM5wdFI}20% hearth increase in the villages you govern.")]
    [SettingPropertyGroup("Perks/Athletics/{=1YxFYg3s}Energetic")]
    public float ath_Energetic_s {
      get => _ath_Energetic_s;
      set {
        if (_ath_Energetic_s != value) {
          _ath_Energetic_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.Energetic, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4anAdME9}Increases your Control Attribute by 1.")]
    [SettingPropertyGroup("Perks/Athletics/{=Ye9lbBr3}Steady")]
    public float ath_Steady_p {
      get => _ath_Steady_p;
      set {
        if (_ath_Steady_p != value) {
          _ath_Steady_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Steady, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xbal9bvg}Increases your Vigor Attribute by 1.")]
    [SettingPropertyGroup("Perks/Athletics/{=d5aK6Sv0}Strong")]
    public float ath_Strong_p {
      get => _ath_Strong_p;
      set {
        if (_ath_Strong_p != value) {
          _ath_Strong_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Strong, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=9gaXSO0T}Foot troops in your party give +5% party speed.")]
    [SettingPropertyGroup("Perks/Athletics/{=d5aK6Sv0}Strong")]
    public float ath_Strong_s {
      get => _ath_Strong_s;
      set {
        if (_ath_Strong_s != value) {
          _ath_Strong_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.Strong, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=CRXQ3Fmn}Gives 1 focus point to throwing.")]
    [SettingPropertyGroup("Perks/Athletics/{=qBKmIyYx}Strong Arms")]
    public float ath_StrongArms_p {
      get => _ath_StrongArms_p;
      set {
        if (_ath_StrongArms_p != value) {
          _ath_StrongArms_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.StrongArms, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=XNsTQlgr}Troops in your formation has +20 throwing skill.")]
    [SettingPropertyGroup("Perks/Athletics/{=qBKmIyYx}Strong Arms")]
    public float ath_StrongArms_s {
      get => _ath_StrongArms_s;
      set {
        if (_ath_StrongArms_s != value) {
          _ath_StrongArms_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.StrongArms, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=E5XGVJGE}Increases your stagger damage threshold by 50% while on foot.")]
    [SettingPropertyGroup("Perks/Athletics/{=PX0Xufmr}Spartan")]
    public float ath_Spartan_p {
      get => _ath_Spartan_p;
      set {
        if (_ath_Spartan_p != value) {
          _ath_Spartan_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.Spartan, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=1TX57OIu}Decreases your party's food consumption by 20%.")]
    [SettingPropertyGroup("Perks/Athletics/{=PX0Xufmr}Spartan")]
    public float ath_Spartan_s {
      get => _ath_Spartan_s;
      set {
        if (_ath_Spartan_s != value) {
          _ath_Spartan_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.Spartan, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=EeHDUxf8}Increases your armor by 10% while on foot.")]
    [SettingPropertyGroup("Perks/Athletics/{=AHtFRv5T}Ignore Pain")]
    public float ath_IgnorePain_p {
      get => _ath_IgnorePain_p;
      set {
        if (_ath_IgnorePain_p != value) {
          _ath_IgnorePain_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.IgnorePain, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=kbs0D9wc}Foot troops in your formation gain 5 armor.")]
    [SettingPropertyGroup("Perks/Athletics/{=AHtFRv5T}Ignore Pain")]
    public float ath_IgnorePain_s {
      get => _ath_IgnorePain_s;
      set {
        if (_ath_IgnorePain_s != value) {
          _ath_IgnorePain_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.IgnorePain, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=DqOBr2BF}You stun your enemies longer after they block your attack.")]
    [SettingPropertyGroup("Perks/Athletics/{=lbGa4ihC}Mighty Blow ")]
    public float ath_MightyBlow_p {
      get => _ath_MightyBlow_p;
      set {
        if (_ath_MightyBlow_p != value) {
          _ath_MightyBlow_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Athletics.MightyBlow, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=NPoClaRb}Each skill point above 250 grants you +1 hit point.")]
    [SettingPropertyGroup("Perks/Athletics/{=lbGa4ihC}Mighty Blow ")]
    public float ath_MightyBlow_s {
      get => _ath_MightyBlow_s;
      set {
        if (_ath_MightyBlow_s != value) {
          _ath_MightyBlow_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Athletics.MightyBlow, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=UNVAkOY4}Swing damage of crafted weapons is increased by 2%.")]
    [SettingPropertyGroup("Perks/Crafting/{=knWgaYdk}Sharpened Edge")]
    public float cft_SharpenedEdge_p {
      get => _cft_SharpenedEdge_p;
      set {
        if (_cft_SharpenedEdge_p != value) {
          _cft_SharpenedEdge_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crafting.SharpenedEdge, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Pml3haCM}Thrust damage of crafted weapons is increased by 2%.")]
    [SettingPropertyGroup("Perks/Crafting/{=aO2JSbSq}Sharpened Tip")]
    public float cft_SharpenedTip_p {
      get => _cft_SharpenedTip_p;
      set {
        if (_cft_SharpenedTip_p != value) {
          _cft_SharpenedTip_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Crafting.SharpenedTip, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6YeKVvCE}Your infantrymen deal 10% more damage to cavalry in simulations.")]
    [SettingPropertyGroup("Perks/Tactics/{=EX5cZDLH}Tight Formations")]
    public float tct_TightFormations_p {
      get => _tct_TightFormations_p;
      set {
        if (_tct_TightFormations_p != value) {
          _tct_TightFormations_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.TightFormations, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=BuPOdw0f}Your infantrymen suffer 10% less damage by ranged troops in simulations.")]
    [SettingPropertyGroup("Perks/Tactics/{=9y3X0MQg}Loose Formations")]
    public float tct_LooseFormations_p {
      get => _tct_LooseFormations_p;
      set {
        if (_tct_LooseFormations_p != value) {
          _tct_LooseFormations_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.LooseFormations, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Eazyj0P8}Troops deal 10% more damage in simulations in snow and forest terrain.")]
    [SettingPropertyGroup("Perks/Tactics/{=YkjPau1o}Asymmetrical Warfare")]
    public float tct_AsymmetricalWarfare_p {
      get => _tct_AsymmetricalWarfare_p;
      set {
        if (_tct_AsymmetricalWarfare_p != value) {
          _tct_AsymmetricalWarfare_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.AsymmetricalWarfare, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ULVc7QuF}Troops in your formation gain 2% increased movement speed in snowy and forest terrain battlefields.")]
    [SettingPropertyGroup("Perks/Tactics/{=YkjPau1o}Asymmetrical Warfare")]
    public float tct_AsymmetricalWarfare_s {
      get => _tct_AsymmetricalWarfare_s;
      set {
        if (_tct_AsymmetricalWarfare_s != value) {
          _tct_AsymmetricalWarfare_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.AsymmetricalWarfare, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=5PDACkqX}+1 troop joins you when fighting in hideouts.")]
    [SettingPropertyGroup("Perks/Tactics/{=30hNRt3x}Small Unit Tactics")]
    public float tct_SmallUnitTactics_p {
      get => _tct_SmallUnitTactics_p;
      set {
        if (_tct_SmallUnitTactics_p != value) {
          _tct_SmallUnitTactics_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.SmallUnitTactics, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=zbHcS5Qc}Troops in your formation gain 5% movement speed bonus when they are less than 15 soldiers.")]
    [SettingPropertyGroup("Perks/Tactics/{=30hNRt3x}Small Unit Tactics")]
    public float tct_SmallUnitTactics_s {
      get => _tct_SmallUnitTactics_s;
      set {
        if (_tct_SmallUnitTactics_s != value) {
          _tct_SmallUnitTactics_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.SmallUnitTactics, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=9bsSw7b9}+10 to party size.")]
    [SettingPropertyGroup("Perks/Tactics/{=Vp8Pwou8}Horde Leader")]
    public float tct_HordeLeader_p {
      get => _tct_HordeLeader_p;
      set {
        if (_tct_HordeLeader_p != value) {
          _tct_HordeLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.HordeLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=r5jtBp1C}Your army loses cohesion 5% slower.")]
    [SettingPropertyGroup("Perks/Tactics/{=Vp8Pwou8}Horde Leader")]
    public float tct_HordeLeader_s {
      get => _tct_HordeLeader_s;
      set {
        if (_tct_HordeLeader_s != value) {
          _tct_HordeLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.HordeLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bcpYibrF}10% more damage bonus in simulations against bandit parties.")]
    [SettingPropertyGroup("Perks/Tactics/{=zUK9JOlb}Law Keeper")]
    public float tct_LawKeeper_p {
      get => _tct_LawKeeper_p;
      set {
        if (_tct_LawKeeper_p != value) {
          _tct_LawKeeper_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.LawKeeper, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=z7eyVsPQ}Troops in your formation gain 4% damage against bandit troops.")]
    [SettingPropertyGroup("Perks/Tactics/{=zUK9JOlb}Law Keeper")]
    public float tct_LawKeeper_s {
      get => _tct_LawKeeper_s;
      set {
        if (_tct_LawKeeper_s != value) {
          _tct_LawKeeper_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.LawKeeper, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=y6DWG9xQ}3% more damage bonus in all battle simulations.")]
    [SettingPropertyGroup("Perks/Tactics/{=afaCdojS}Coaching")]
    public float tct_Coaching_p {
      get => _tct_Coaching_p;
      set {
        if (_tct_Coaching_p != value) {
          _tct_Coaching_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.Coaching, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=b47HTdFK}Troops in your formation gain 1% damage against any troop.")]
    [SettingPropertyGroup("Perks/Tactics/{=afaCdojS}Coaching")]
    public float tct_Coaching_s {
      get => _tct_Coaching_s;
      set {
        if (_tct_Coaching_s != value) {
          _tct_Coaching_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.Coaching, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=83YInCvB}Decreases the duration of the disorganized state after breaking sieges and raids by 15%.")]
    [SettingPropertyGroup("Perks/Tactics/{=nmJe4wN1}Swift Regroup")]
    public float tct_SwiftRegroup_p {
      get => _tct_SwiftRegroup_p;
      set {
        if (_tct_SwiftRegroup_p != value) {
          _tct_SwiftRegroup_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.SwiftRegroup, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=lSZKnnay}You can escape from battles by leaving 50% less soldiers behind.")]
    [SettingPropertyGroup("Perks/Tactics/{=nmJe4wN1}Swift Regroup")]
    public float tct_SwiftRegroup_s {
      get => _tct_SwiftRegroup_s;
      set {
        if (_tct_SwiftRegroup_s != value) {
          _tct_SwiftRegroup_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.SwiftRegroup, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=XawWg9aY}Reduce fortification bonus in simulations by 20%.")]
    [SettingPropertyGroup("Perks/Tactics/{=kolBffjD}On The March")]
    public float tct_OnTheMarch_p {
      get => _tct_OnTheMarch_p;
      set {
        if (_tct_OnTheMarch_p != value) {
          _tct_OnTheMarch_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.OnTheMarch, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=n9zbvTCq}Increase fortification bonus in simulations by 20%.")]
    [SettingPropertyGroup("Perks/Tactics/{=kolBffjD}On The March")]
    public float tct_OnTheMarch_s {
      get => _tct_OnTheMarch_s;
      set {
        if (_tct_OnTheMarch_s != value) {
          _tct_OnTheMarch_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.OnTheMarch, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=XxLfbCxp}Parties that you have called to your army moves 10% faster while moving to the army.")]
    [SettingPropertyGroup("Perks/Tactics/{=mUubYb7v}Call To Arms")]
    public float tct_CallToArms_p {
      get => _tct_CallToArms_p;
      set {
        if (_tct_CallToArms_p != value) {
          _tct_CallToArms_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.CallToArms, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=V6dV2K1r}15% less influence required per party to call to your army.")]
    [SettingPropertyGroup("Perks/Tactics/{=mUubYb7v}Call To Arms")]
    public float tct_CallToArms_s {
      get => _tct_CallToArms_s;
      set {
        if (_tct_CallToArms_s != value) {
          _tct_CallToArms_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.CallToArms, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=YNK17aGp}Double damage to siege defender personnel with %25 chance.")]
    [SettingPropertyGroup("Perks/Tactics/{=XQkY7jkL}Pick Them Of The Walls")]
    public float tct_PickThemOfTheWalls_p {
      get => _tct_PickThemOfTheWalls_p;
      set {
        if (_tct_PickThemOfTheWalls_p != value) {
          _tct_PickThemOfTheWalls_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.PickThemOfTheWalls, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=0LTL5qGP}Double damage to besieging personnel with %25 chance.")]
    [SettingPropertyGroup("Perks/Tactics/{=XQkY7jkL}Pick Them Of The Walls")]
    public float tct_PickThemOfTheWalls_s {
      get => _tct_PickThemOfTheWalls_s;
      set {
        if (_tct_PickThemOfTheWalls_s != value) {
          _tct_PickThemOfTheWalls_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.PickThemOfTheWalls, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=IhktcM29}25% more damage to defender siege engines.")]
    [SettingPropertyGroup("Perks/Tactics/{=8xxeNK0o}Make Them Pay")]
    public float tct_MakeThemPay_p {
      get => _tct_MakeThemPay_p;
      set {
        if (_tct_MakeThemPay_p != value) {
          _tct_MakeThemPay_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.MakeThemPay, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=vMT92Xzz}20% more damage to besieger siege engines.")]
    [SettingPropertyGroup("Perks/Tactics/{=8xxeNK0o}Make Them Pay")]
    public float tct_MakeThemPay_s {
      get => _tct_MakeThemPay_s;
      set {
        if (_tct_MakeThemPay_s != value) {
          _tct_MakeThemPay_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.MakeThemPay, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=lFTMxU98}Tier 3+ units suffer 20% less damage in simulations.")]
    [SettingPropertyGroup("Perks/Tactics/{=luDtfSN7}Elite Reserves")]
    public float tct_EliteReserves_p {
      get => _tct_EliteReserves_p;
      set {
        if (_tct_EliteReserves_p != value) {
          _tct_EliteReserves_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.EliteReserves, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=QvorOOSZ}The troops in the formation you control has 5% damage reduction.")]
    [SettingPropertyGroup("Perks/Tactics/{=luDtfSN7}Elite Reserves")]
    public float tct_EliteReserves_s {
      get => _tct_EliteReserves_s;
      set {
        if (_tct_EliteReserves_s != value) {
          _tct_EliteReserves_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.EliteReserves, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=8ZrQJeUJ}5% more damage in simulations while outnumbering the enemy.")]
    [SettingPropertyGroup("Perks/Tactics/{=EhaMPtRX}Encirclement")]
    public float tct_Encirclement_p {
      get => _tct_Encirclement_p;
      set {
        if (_tct_Encirclement_p != value) {
          _tct_Encirclement_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.Encirclement, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=S0LSg98G}10% less influence needed to boost army cohesion.")]
    [SettingPropertyGroup("Perks/Tactics/{=EhaMPtRX}Encirclement")]
    public float tct_Encirclement_s {
      get => _tct_Encirclement_s;
      set {
        if (_tct_Encirclement_s != value) {
          _tct_Encirclement_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.Encirclement, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vlZu6uaR}25% more influence gain from winning field engagements.")]
    [SettingPropertyGroup("Perks/Tactics/{=cHgLxbbc}Pre Battle Maneuvers")]
    public float tct_PreBattleManeuvers_p {
      get => _tct_PreBattleManeuvers_p;
      set {
        if (_tct_PreBattleManeuvers_p != value) {
          _tct_PreBattleManeuvers_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.PreBattleManeuvers, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WrAFPs4H}When you are besieged 10% more damage in simulations.")]
    [SettingPropertyGroup("Perks/Tactics/{=ALC3Kzv9}Besieged")]
    public float tct_Besieged_p {
      get => _tct_Besieged_p;
      set {
        if (_tct_Besieged_p != value) {
          _tct_Besieged_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.Besieged, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=c5aMtlA7}50% more influence gain from winning sieges.")]
    [SettingPropertyGroup("Perks/Tactics/{=ALC3Kzv9}Besieged")]
    public float tct_Besieged_s {
      get => _tct_Besieged_s;
      set {
        if (_tct_Besieged_s != value) {
          _tct_Besieged_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.Besieged, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=D9F4IA2W}When you are attacked in a field battle 10% more damage in simulations.")]
    [SettingPropertyGroup("Perks/Tactics/{=mn5tQhyp}Counter Offensive")]
    public float tct_Counteroffensive_p {
      get => _tct_Counteroffensive_p;
      set {
        if (_tct_Counteroffensive_p != value) {
          _tct_Counteroffensive_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.Counteroffensive, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=SngfSCqh}10% more damage in simulations when outnumbered.")]
    [SettingPropertyGroup("Perks/Tactics/{=mn5tQhyp}Counter Offensive")]
    public float tct_Counteroffensive_s {
      get => _tct_Counteroffensive_s;
      set {
        if (_tct_Counteroffensive_s != value) {
          _tct_Counteroffensive_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.Counteroffensive, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Dt1VM9WR}Cavalry troops in your formation deals 2% more damage to enemy infantry units.")]
    [SettingPropertyGroup("Perks/Tactics/{=CTEuBfU0}Gens d'armes")]
    public float tct_Gensdarmes_p {
      get => _tct_Gensdarmes_p;
      set {
        if (_tct_Gensdarmes_p != value) {
          _tct_Gensdarmes_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.Gensdarmes, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=qLaeEndX}Increase governed town security by +1 per day.")]
    [SettingPropertyGroup("Perks/Tactics/{=CTEuBfU0}Gens d'armes")]
    public float tct_Gensdarmes_s {
      get => _tct_Gensdarmes_s;
      set {
        if (_tct_Gensdarmes_s != value) {
          _tct_Gensdarmes_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Tactics.Gensdarmes, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=uLmNh3RQ}Increase simulation damage by 1% for every skill level over 200.")]
    [SettingPropertyGroup("Perks/Tactics/{=8rvpcb4k}Tactical Mastery")]
    public float tct_TacticalMastery_p {
      get => _tct_TacticalMastery_p;
      set {
        if (_tct_TacticalMastery_p != value) {
          _tct_TacticalMastery_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Tactics.TacticalMastery, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=tqDlfh7p}2% movement speed bonus during day time.")]
    [SettingPropertyGroup("Perks/Scouting/{=6PSgX2BP}Day Traveler")]
    public float sct_DayTraveler_p {
      get => _sct_DayTraveler_p;
      set {
        if (_sct_DayTraveler_p != value) {
          _sct_DayTraveler_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.DayTraveler, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=m3JX1IFv}You have 10% increased sight range during day time.")]
    [SettingPropertyGroup("Perks/Scouting/{=6PSgX2BP}Day Traveler")]
    public float sct_DayTraveler_s {
      get => _sct_DayTraveler_s;
      set {
        if (_sct_DayTraveler_s != value) {
          _sct_DayTraveler_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.DayTraveler, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=moQchgM4}5% movement speed bonus during night time.")]
    [SettingPropertyGroup("Perks/Scouting/{=B8Gq2ylh}Night Runner")]
    public float sct_NightRunner_p {
      get => _sct_NightRunner_p;
      set {
        if (_sct_NightRunner_p != value) {
          _sct_NightRunner_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.NightRunner, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NJa55XTF}You have 30% increased sight range during night time.")]
    [SettingPropertyGroup("Perks/Scouting/{=B8Gq2ylh}Night Runner")]
    public float sct_NightRunner_s {
      get => _sct_NightRunner_s;
      set {
        if (_sct_NightRunner_s != value) {
          _sct_NightRunner_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.NightRunner, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=p3Aa9Fr9}2% movement speed bonus on steppes and plains.")]
    [SettingPropertyGroup("Perks/Scouting/{=d2qGHXyx}Pathfinder")]
    public float sct_Pathfinder_p {
      get => _sct_Pathfinder_p;
      set {
        if (_sct_Pathfinder_p != value) {
          _sct_Pathfinder_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Pathfinder, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=z7b7s4cN}10% sight range bonus while on steppes and plains.")]
    [SettingPropertyGroup("Perks/Scouting/{=gsz9DMNq}Water Diviner")]
    public float sct_WaterDiviner_p {
      get => _sct_WaterDiviner_p;
      set {
        if (_sct_WaterDiviner_p != value) {
          _sct_WaterDiviner_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.WaterDiviner, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=U1APiMVL}If your party is more than 75% infantry you receive 50% less speed penalty in forests.")]
    [SettingPropertyGroup("Perks/Scouting/{=0XuFh3cX}Forest Kin")]
    public float sct_ForestKin_p {
      get => _sct_ForestKin_p;
      set {
        if (_sct_ForestKin_p != value) {
          _sct_ForestKin_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.ForestKin, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=FIBSi2VF}Villages you govern give 10% more tax.")]
    [SettingPropertyGroup("Perks/Scouting/{=0XuFh3cX}Forest Kin")]
    public float sct_ForestKin_s {
      get => _sct_ForestKin_s;
      set {
        if (_sct_ForestKin_s != value) {
          _sct_ForestKin_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.ForestKin, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=AcYxyuDL}5% movement speed bonus on deserts and dunes.")]
    [SettingPropertyGroup("Perks/Scouting/{=TbBmjK8M}Desert Born")]
    public float sct_DesertBorn_p {
      get => _sct_DesertBorn_p;
      set {
        if (_sct_DesertBorn_p != value) {
          _sct_DesertBorn_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.DesertBorn, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=yTUfzVaR}Towns you govern give 2.5% more tax.")]
    [SettingPropertyGroup("Perks/Scouting/{=TbBmjK8M}Desert Born")]
    public float sct_DesertBorn_s {
      get => _sct_DesertBorn_s;
      set {
        if (_sct_DesertBorn_s != value) {
          _sct_DesertBorn_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.DesertBorn, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=yC8X2qwQ}2.5% movement speed bonus when party morale is higher than 75.")]
    [SettingPropertyGroup("Perks/Scouting/{=jhZe9Mfo}Forced March")]
    public float sct_ForcedMarch_p {
      get => _sct_ForcedMarch_p;
      set {
        if (_sct_ForcedMarch_p != value) {
          _sct_ForcedMarch_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.ForcedMarch, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=886Q6KjF}Moving while party morale is higher than 75 gives +2 passive xp to all troops daily.")]
    [SettingPropertyGroup("Perks/Scouting/{=jhZe9Mfo}Forced March")]
    public float sct_ForcedMarch_s {
      get => _sct_ForcedMarch_s;
      set {
        if (_sct_ForcedMarch_s != value) {
          _sct_ForcedMarch_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.ForcedMarch, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=CJIsjKn0}20% less penalty from overburden.")]
    [SettingPropertyGroup("Perks/Scouting/{=sA2OrT6l}Unburdened")]
    public float sct_Unburdened_p {
      get => _sct_Unburdened_p;
      set {
        if (_sct_Unburdened_p != value) {
          _sct_Unburdened_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Unburdened, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=mhUmO65C}Moving while overburdened gives +2 xp to all troops daily.")]
    [SettingPropertyGroup("Perks/Scouting/{=sA2OrT6l}Unburdened")]
    public float sct_Unburdened_s {
      get => _sct_Unburdened_s;
      set {
        if (_sct_Unburdened_s != value) {
          _sct_Unburdened_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.Unburdened, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=5NRai8K5}Increase maximum track life by 20%.")]
    [SettingPropertyGroup("Perks/Scouting/{=AoaabumE}Tracker")]
    public float sct_Tracker_p {
      get => _sct_Tracker_p;
      set {
        if (_sct_Tracker_p != value) {
          _sct_Tracker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Tracker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=HAdaEaQD}When following a hostile party on the campaign map you gain 2% speed bonus.")]
    [SettingPropertyGroup("Perks/Scouting/{=AoaabumE}Tracker")]
    public float sct_Tracker_s {
      get => _sct_Tracker_s;
      set {
        if (_sct_Tracker_s != value) {
          _sct_Tracker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.Tracker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=MISEi5Bh}Increase maximum track spotting distance by 20%.")]
    [SettingPropertyGroup("Perks/Scouting/{=09gOOa0h}Ranger")]
    public float sct_Ranger_p {
      get => _sct_Ranger_p;
      set {
        if (_sct_Ranger_p != value) {
          _sct_Ranger_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Ranger, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=KL3h23kB}Increase track detection chance by 10%.")]
    [SettingPropertyGroup("Perks/Scouting/{=09gOOa0h}Ranger")]
    public float sct_Ranger_s {
      get => _sct_Ranger_s;
      set {
        if (_sct_Ranger_s != value) {
          _sct_Ranger_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.Ranger, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bVmHW3wg}When fighting against bandit parties you have +5 battle morale.")]
    [SettingPropertyGroup("Perks/Scouting/{=uKc4le8Q}Patrols")]
    public float sct_Patrols_p {
      get => _sct_Patrols_p;
      set {
        if (_sct_Patrols_p != value) {
          _sct_Patrols_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Patrols, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xFhaMGmY}Your party has 10% advantage in simulated battles against bandits.")]
    [SettingPropertyGroup("Perks/Scouting/{=uKc4le8Q}Patrols")]
    public float sct_Patrols_s {
      get => _sct_Patrols_s;
      set {
        if (_sct_Patrols_s != value) {
          _sct_Patrols_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.Patrols, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=VlM9gt97}When moving through steppes or forests reduce food consumption by 10%.")]
    [SettingPropertyGroup("Perks/Scouting/{=LPxEDIk7}Foragers")]
    public float sct_Foragers_p {
      get => _sct_Foragers_p;
      set {
        if (_sct_Foragers_p != value) {
          _sct_Foragers_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Foragers, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=KVDysdv2}15% reduction in disorganized state recovery duration.")]
    [SettingPropertyGroup("Perks/Scouting/{=LPxEDIk7}Foragers")]
    public float sct_Foragers_s {
      get => _sct_Foragers_s;
      set {
        if (_sct_Foragers_s != value) {
          _sct_Foragers_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.Foragers, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=28zNieSg}When moving through steppes or plains you have a 5% chance of finding mount daily.")]
    [SettingPropertyGroup("Perks/Scouting/{=mrtDAhtL}Beast Whisperer")]
    public float sct_BeastWhisperer_p {
      get => _sct_BeastWhisperer_p;
      set {
        if (_sct_BeastWhisperer_p != value) {
          _sct_BeastWhisperer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.BeastWhisperer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=avZSXLfw}Increase carry capacity from pack animals by 10%.")]
    [SettingPropertyGroup("Perks/Scouting/{=mrtDAhtL}Beast Whisperer")]
    public float sct_BeastWhisperer_s {
      get => _sct_BeastWhisperer_s;
      set {
        if (_sct_BeastWhisperer_s != value) {
          _sct_BeastWhisperer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.BeastWhisperer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=Znft0z5W}Trade penalty within villages of your faction is decreased by 10%.")]
    [SettingPropertyGroup("Perks/Scouting/{=lYQAuYaH}Village Network")]
    public float sct_VillageNetwork_p {
      get => _sct_VillageNetwork_p;
      set {
        if (_sct_VillageNetwork_p != value) {
          _sct_VillageNetwork_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.VillageNetwork, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NRiJ615C}Villagers parties are 10% larger.")]
    [SettingPropertyGroup("Perks/Scouting/{=lYQAuYaH}Village Network")]
    public float sct_VillageNetwork_s {
      get => _sct_VillageNetwork_s;
      set {
        if (_sct_VillageNetwork_s != value) {
          _sct_VillageNetwork_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.VillageNetwork, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=bcYgBWkn}Trade penalty within cities of your faction is decreased by 5%.")]
    [SettingPropertyGroup("Perks/Scouting/{=LwWyc6ou}Rumour Network")]
    public float sct_RumourNetwork_p {
      get => _sct_RumourNetwork_p;
      set {
        if (_sct_RumourNetwork_p != value) {
          _sct_RumourNetwork_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.RumourNetwork, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=RaaQFsC7}Hideout detection range is increased by 30%.")]
    [SettingPropertyGroup("Perks/Scouting/{=LwWyc6ou}Rumour Network")]
    public float sct_RumourNetwork_s {
      get => _sct_RumourNetwork_s;
      set {
        if (_sct_RumourNetwork_s != value) {
          _sct_RumourNetwork_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.RumourNetwork, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=p1eNH4BK}When stationary for a while (1 hour) increase sight range by 25%.")]
    [SettingPropertyGroup("Perks/Scouting/{=EC2n5DBl}Vantage Point")]
    public float sct_VantagePoint_p {
      get => _sct_VantagePoint_p;
      set {
        if (_sct_VantagePoint_p != value) {
          _sct_VantagePoint_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.VantagePoint, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=8CUvpLtP}Increase the prisoner size limit by +10.")]
    [SettingPropertyGroup("Perks/Scouting/{=EC2n5DBl}Vantage Point")]
    public float sct_VantagePoint_s {
      get => _sct_VantagePoint_s;
      set {
        if (_sct_VantagePoint_s != value) {
          _sct_VantagePoint_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.VantagePoint, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=*}Reduce sight difficulty penalty of parties in forests by 50%.")]
    [SettingPropertyGroup("Perks/Scouting/{=3yVPrhXt}Keen Sight")]
    public float sct_KeenSight_p {
      get => _sct_KeenSight_p;
      set {
        if (_sct_KeenSight_p != value) {
          _sct_KeenSight_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.KeenSight, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=wOa7dcbO}Prisoner lords are 50% less likely desert from your party.")]
    [SettingPropertyGroup("Perks/Scouting/{=3yVPrhXt}Keen Sight")]
    public float sct_KeenSight_s {
      get => _sct_KeenSight_s;
      set {
        if (_sct_KeenSight_s != value) {
          _sct_KeenSight_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.KeenSight, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=XjbPBIct}Increase troop wounded recovery ratio by 20% while in an army.")]
    [SettingPropertyGroup("Perks/Scouting/{=e4QAc5A6}Rearguard")]
    public float sct_Rearguard_p {
      get => _sct_Rearguard_p;
      set {
        if (_sct_Rearguard_p != value) {
          _sct_Rearguard_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.Rearguard, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=D7DZxiSt}10% more damage in simulated battles defending the siege camp.")]
    [SettingPropertyGroup("Perks/Scouting/{=e4QAc5A6}Rearguard")]
    public float sct_Rearguard_s {
      get => _sct_Rearguard_s;
      set {
        if (_sct_Rearguard_s != value) {
          _sct_Rearguard_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.Rearguard, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=6XxRQ38k}Increase Party Speed by 0.1% for every skill level over 200.")]
    [SettingPropertyGroup("Perks/Scouting/{=M9vC9mio}Uncanny Insight")]
    public float sct_UncannyInsight_p {
      get => _sct_UncannyInsight_p;
      set {
        if (_sct_UncannyInsight_p != value) {
          _sct_UncannyInsight_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Scouting.UncannyInsight, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="")]
    [SettingPropertyGroup("Perks/Scouting/{=M9vC9mio}Uncanny Insight")]
    public float sct_UncannyInsight_s {
      get => _sct_UncannyInsight_s;
      set {
        if (_sct_UncannyInsight_s != value) {
          _sct_UncannyInsight_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Scouting.UncannyInsight, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=aIo3xj0y}Bandit units in your party gain xp 20% faster.")]
    [SettingPropertyGroup("Perks/Roguery/{=RyfFWmDs}No Rest for the Wicked")]
    public float rog_NoRestForTheWicked_p {
      get => _rog_NoRestForTheWicked_p;
      set {
        if (_rog_NoRestForTheWicked_p != value) {
          _rog_NoRestForTheWicked_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.NoRestForTheWicked, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=F6dEZOVl}Faster raiding 5%.")]
    [SettingPropertyGroup("Perks/Roguery/{=RyfFWmDs}No Rest for the Wicked")]
    public float rog_NoRestForTheWicked_s {
      get => _rog_NoRestForTheWicked_s;
      set {
        if (_rog_NoRestForTheWicked_s != value) {
          _rog_NoRestForTheWicked_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.NoRestForTheWicked, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=T70o6ItZ}Bandits are 20% easier to convince to leave in peace while bartering.")]
    [SettingPropertyGroup("Perks/Roguery/{=570wiYEe}Sweet Talker")]
    public float rog_SweetTalker_p {
      get => _rog_SweetTalker_p;
      set {
        if (_rog_SweetTalker_p != value) {
          _rog_SweetTalker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.SweetTalker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=M4Q32HvX}Prisoners are 20% less likely to escape from towns.")]
    [SettingPropertyGroup("Perks/Roguery/{=570wiYEe}Sweet Talker")]
    public float rog_SweetTalker_s {
      get => _rog_SweetTalker_s;
      set {
        if (_rog_SweetTalker_s != value) {
          _rog_SweetTalker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.SweetTalker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vPbx5vJQ}50% Better chance of success with disguise missions.")]
    [SettingPropertyGroup("Perks/Roguery/{=kg4Mx9j4}Two Faced")]
    public float rog_TwoFaced_p {
      get => _rog_TwoFaced_p;
      set {
        if (_rog_TwoFaced_p != value) {
          _rog_TwoFaced_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.TwoFaced, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=hIi6w8J1}Convert bandit prisoners without suffering morale penalty.")]
    [SettingPropertyGroup("Perks/Roguery/{=kg4Mx9j4}Two Faced")]
    public float rog_TwoFaced_s {
      get => _rog_TwoFaced_s;
      set {
        if (_rog_TwoFaced_s != value) {
          _rog_TwoFaced_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.TwoFaced, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ilKDq9f5}Double the amount of betting you can use in tournaments.")]
    [SettingPropertyGroup("Perks/Roguery/{=by1b61pn}Deep Pockets")]
    public float rog_DeepPockets_p {
      get => _rog_DeepPockets_p;
      set {
        if (_rog_DeepPockets_p != value) {
          _rog_DeepPockets_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.DeepPockets, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=TbkoiaEg}Bandit units in your party require 20% cheaper wage.")]
    [SettingPropertyGroup("Perks/Roguery/{=by1b61pn}Deep Pockets")]
    public float rog_DeepPockets_s {
      get => _rog_DeepPockets_s;
      set {
        if (_rog_DeepPockets_s != value) {
          _rog_DeepPockets_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.DeepPockets, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=*}Notables of villages give +1 extra troop when successfuly forced for volunteers.")]
    [SettingPropertyGroup("Perks/Roguery/{=xoARIHde}In Best Light")]
    public float rog_InBestLight_p {
      get => _rog_InBestLight_p;
      set {
        if (_rog_InBestLight_p != value) {
          _rog_InBestLight_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.InBestLight, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=bE4ihnBv}Villages of your clan recover 20% faster.")]
    [SettingPropertyGroup("Perks/Roguery/{=xoARIHde}In Best Light")]
    public float rog_InBestLight_s {
      get => _rog_InBestLight_s;
      set {
        if (_rog_InBestLight_s != value) {
          _rog_InBestLight_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.InBestLight, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=60PPnopy}Defeated villagers and caravans give 5% more access to their inventory.")]
    [SettingPropertyGroup("Perks/Roguery/{=tvoN5ynt}Know-How")]
    public float rog_KnowHow_p {
      get => _rog_KnowHow_p;
      set {
        if (_rog_KnowHow_p != value) {
          _rog_KnowHow_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.KnowHow, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=7ePa5JnG}Increase security of the settlement you govern by +1 per day.")]
    [SettingPropertyGroup("Perks/Roguery/{=tvoN5ynt}Know-How")]
    public float rog_KnowHow_s {
      get => _rog_KnowHow_s;
      set {
        if (_rog_KnowHow_s != value) {
          _rog_KnowHow_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.KnowHow, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=ljKoJX9P}Bandit units in your party consume 50% less food.")]
    [SettingPropertyGroup("Perks/Roguery/{=XZOtTuxA}Promises")]
    public float rog_Promises_p {
      get => _rog_Promises_p;
      set {
        if (_rog_Promises_p != value) {
          _rog_Promises_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.Promises, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=XpIxj8Nb}Bandit prisoners can be recruited to party 30% faster.")]
    [SettingPropertyGroup("Perks/Roguery/{=XZOtTuxA}Promises")]
    public float rog_Promises_s {
      get => _rog_Promises_s;
      set {
        if (_rog_Promises_s != value) {
          _rog_Promises_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.Promises, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=bO40QzdH}20% better deals with ransom broker for regular troops.")]
    [SettingPropertyGroup("Perks/Roguery/{=jNbTBxEW}Slave Trader")]
    public float rog_SlaveTrader_p {
      get => _rog_SlaveTrader_p;
      set {
        if (_rog_SlaveTrader_p != value) {
          _rog_SlaveTrader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.SlaveTrader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=d7dUtRgd}Increase prisoner limit by 20%.")]
    [SettingPropertyGroup("Perks/Roguery/{=jNbTBxEW}Slave Trader")]
    public float rog_SlaveTrader_s {
      get => _rog_SlaveTrader_s;
      set {
        if (_rog_SlaveTrader_s != value) {
          _rog_SlaveTrader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.SlaveTrader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dfmrof9R}Your crime rating decreases 20% faster.")]
    [SettingPropertyGroup("Perks/Roguery/{=F51HfzZj}White Lies")]
    public float rog_WhiteLies_p {
      get => _rog_WhiteLies_p;
      set {
        if (_rog_WhiteLies_p != value) {
          _rog_WhiteLies_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.WhiteLies, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vzYyJpmu}2% daily chance to improve relations by 1 with random notable in the settlement you govern.")]
    [SettingPropertyGroup("Perks/Roguery/{=F51HfzZj}White Lies")]
    public float rog_WhiteLies_s {
      get => _rog_WhiteLies_s;
      set {
        if (_rog_WhiteLies_s != value) {
          _rog_WhiteLies_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.WhiteLies, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=TAlERbfz}Increase the armor provided by civillian body armors by 10.")]
    [SettingPropertyGroup("Perks/Roguery/{=E8a2joMO}Smuggler Connections")]
    public float rog_SmugglerConnections_p {
      get => _rog_SmugglerConnections_p;
      set {
        if (_rog_SmugglerConnections_p != value) {
          _rog_SmugglerConnections_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.SmugglerConnections, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=enZbJasV}When you have any amount of criminal rating you suffer 50% less trade penalty.")]
    [SettingPropertyGroup("Perks/Roguery/{=E8a2joMO}Smuggler Connections")]
    public float rog_SmugglerConnections_s {
      get => _rog_SmugglerConnections_s;
      set {
        if (_rog_SmugglerConnections_s != value) {
          _rog_SmugglerConnections_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.SmugglerConnections, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=*}Bandit parties always offer to join you.")]
    [SettingPropertyGroup("Perks/Roguery/{=2PVm7NON}Partners in Crime")]
    public float rog_PartnersInCrime_p {
      get => _rog_PartnersInCrime_p;
      set {
        if (_rog_PartnersInCrime_p != value) {
          _rog_PartnersInCrime_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.PartnersInCrime, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=glL3Dj4R}Bandit units in the formation you control deals 2% more damage.")]
    [SettingPropertyGroup("Perks/Roguery/{=2PVm7NON}Partners in Crime")]
    public float rog_PartnersInCrime_s {
      get => _rog_PartnersInCrime_s;
      set {
        if (_rog_PartnersInCrime_s != value) {
          _rog_PartnersInCrime_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.PartnersInCrime, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NsBKUeQG}Bandit units in your party has +10 bonus to Vigor and Control skills.")]
    [SettingPropertyGroup("Perks/Roguery/{=oumTabhS}One of the Family")]
    public float rog_OneOfTheFamily_p {
      get => _rog_OneOfTheFamily_p;
      set {
        if (_rog_OneOfTheFamily_p != value) {
          _rog_OneOfTheFamily_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.OneOfTheFamily, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=f0abqIAz}Gang leaders in your settlement offer you 1 more recruitment slot.")]
    [SettingPropertyGroup("Perks/Roguery/{=oumTabhS}One of the Family")]
    public float rog_OneOfTheFamily_s {
      get => _rog_OneOfTheFamily_s;
      set {
        if (_rog_OneOfTheFamily_s != value) {
          _rog_OneOfTheFamily_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.OneOfTheFamily, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=90r4jzsS}10% increased damage with \"civilian\" weapons.")]
    [SettingPropertyGroup("Perks/Roguery/{=7gZo2SY4}Carver")]
    public float rog_Carver_p {
      get => _rog_Carver_p;
      set {
        if (_rog_Carver_p != value) {
          _rog_Carver_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.Carver, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=fDRbGy7y}Troops under your command deal 2% more damage with one handed swords.")]
    [SettingPropertyGroup("Perks/Roguery/{=7gZo2SY4}Carver")]
    public float rog_Carver_s {
      get => _rog_Carver_s;
      set {
        if (_rog_Carver_s != value) {
          _rog_Carver_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.Carver, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=HabvheWJ}Hero prisoners gain a 25% better deal from ransom broker.")]
    [SettingPropertyGroup("Perks/Roguery/{=W2WXkiAh}Ransom Broker")]
    public float rog_RansomBroker_p {
      get => _rog_RansomBroker_p;
      set {
        if (_rog_RansomBroker_p != value) {
          _rog_RansomBroker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.RansomBroker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=WU0HmqY2}Hero Prisoners are 30% less likely to escape.")]
    [SettingPropertyGroup("Perks/Roguery/{=W2WXkiAh}Ransom Broker")]
    public float rog_RansomBroker_s {
      get => _rog_RansomBroker_s;
      set {
        if (_rog_RansomBroker_s != value) {
          _rog_RansomBroker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.RansomBroker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=ZbabC8XE}20% decrease in sell price penalty for weapons.")]
    [SettingPropertyGroup("Perks/Roguery/{=5bmlZ26b}Arms Dealer")]
    public float rog_ArmsDealer_p {
      get => _rog_ArmsDealer_p;
      set {
        if (_rog_ArmsDealer_p != value) {
          _rog_ArmsDealer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.ArmsDealer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Hdd7n8Ux}Increase daily militia by +2 per day while under siege.")]
    [SettingPropertyGroup("Perks/Roguery/{=5bmlZ26b}Arms Dealer")]
    public float rog_ArmsDealer_s {
      get => _rog_ArmsDealer_s;
      set {
        if (_rog_ArmsDealer_s != value) {
          _rog_ArmsDealer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.ArmsDealer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Ggs8sYEe}Your kicks stun your opponents for 50% longer.")]
    [SettingPropertyGroup("Perks/Roguery/{=bb1hS9I4}Dirty Fighting")]
    public float rog_DirtyFighting_p {
      get => _rog_DirtyFighting_p;
      set {
        if (_rog_DirtyFighting_p != value) {
          _rog_DirtyFighting_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.DirtyFighting, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=fjpuRPFe}Town can smuggle in a 2 random food item per day while undersiege.")]
    [SettingPropertyGroup("Perks/Roguery/{=bb1hS9I4}Dirty Fighting")]
    public float rog_DirtyFighting_s {
      get => _rog_DirtyFighting_s;
      set {
        if (_rog_DirtyFighting_s != value) {
          _rog_DirtyFighting_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.DirtyFighting, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=zZvU1ANu}Increase speed bonus effect to damage by 50% while on foot.")]
    [SettingPropertyGroup("Perks/Roguery/{=w1B71sNj}Dash and Slash")]
    public float rog_DashAndSlash_p {
      get => _rog_DashAndSlash_p;
      set {
        if (_rog_DashAndSlash_p != value) {
          _rog_DashAndSlash_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.DashAndSlash, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bl7zYCaL}Troops under your command deal 2% more damage with two handed weapons.")]
    [SettingPropertyGroup("Perks/Roguery/{=w1B71sNj}Dash and Slash")]
    public float rog_DashAndSlash_s {
      get => _rog_DashAndSlash_s;
      set {
        if (_rog_DashAndSlash_s != value) {
          _rog_DashAndSlash_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.DashAndSlash, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=VfTfCFc8}Increase your movement speed by 10% while no weapons or shields are equipped.")]
    [SettingPropertyGroup("Perks/Roguery/{=yY5iDvAb}Fleet Footed")]
    public float rog_FleetFooted_p {
      get => _rog_FleetFooted_p;
      set {
        if (_rog_FleetFooted_p != value) {
          _rog_FleetFooted_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.FleetFooted, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ZyeIno52}Increase escape chance by 30% from mobile parties.")]
    [SettingPropertyGroup("Perks/Roguery/{=yY5iDvAb}Fleet Footed")]
    public float rog_FleetFooted_s {
      get => _rog_FleetFooted_s;
      set {
        if (_rog_FleetFooted_s != value) {
          _rog_FleetFooted_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.FleetFooted, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=OZk856at}Increase loot amount by 1% for every skill point over 200.")]
    [SettingPropertyGroup("Perks/Roguery/{=U3cgqyUE}Rogue Extraordinaire")]
    public float rog_RogueExtraordinaire_p {
      get => _rog_RogueExtraordinaire_p;
      set {
        if (_rog_RogueExtraordinaire_p != value) {
          _rog_RogueExtraordinaire_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Roguery.RogueExtraordinaire, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="")]
    [SettingPropertyGroup("Perks/Roguery/{=U3cgqyUE}Rogue Extraordinaire")]
    public float rog_RogueExtraordinaire_s {
      get => _rog_RogueExtraordinaire_s;
      set {
        if (_rog_RogueExtraordinaire_s != value) {
          _rog_RogueExtraordinaire_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Roguery.RogueExtraordinaire, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=QGX317PD}+2 xp per day to all troops in party.")]
    [SettingPropertyGroup("Perks/Leadership/{=Cb5s9HlD}Combat Tips")]
    public float ldr_CombatTips_p {
      get => _ldr_CombatTips_p;
      set {
        if (_ldr_CombatTips_p != value) {
          _ldr_CombatTips_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.CombatTips, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=bkPCaa0D}Increase recruit level of units of the same culture with you from npcs.")]
    [SettingPropertyGroup("Perks/Leadership/{=Cb5s9HlD}Combat Tips")]
    public float ldr_CombatTips_s {
      get => _ldr_CombatTips_s;
      set {
        if (_ldr_CombatTips_s != value) {
          _ldr_CombatTips_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.CombatTips, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=emH1yQAs}+4 xp per day to tier 1-2 troops.")]
    [SettingPropertyGroup("Perks/Leadership/{=JGCtv8om}Raise The Meek")]
    public float ldr_RaiseTheMeek_p {
      get => _ldr_RaiseTheMeek_p;
      set {
        if (_ldr_RaiseTheMeek_p != value) {
          _ldr_RaiseTheMeek_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.RaiseTheMeek, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=zzOxYsv1}Each troop in the garrison gains +3 xp per day.")]
    [SettingPropertyGroup("Perks/Leadership/{=JGCtv8om}Raise The Meek")]
    public float ldr_RaiseTheMeek_s {
      get => _ldr_RaiseTheMeek_s;
      set {
        if (_ldr_RaiseTheMeek_s != value) {
          _ldr_RaiseTheMeek_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.RaiseTheMeek, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ODpmvGFf}Additional 4 morale at the beginning of the battle when you are attacking.")]
    [SettingPropertyGroup("Perks/Leadership/{=MhRF64eR}Fervent Attacker")]
    public float ldr_FerventAttacker_p {
      get => _ldr_FerventAttacker_p;
      set {
        if (_ldr_FerventAttacker_p != value) {
          _ldr_FerventAttacker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.FerventAttacker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=G6256l4w}Increase the rate of recruiting Tier 1-2-3 prisoners by %50.")]
    [SettingPropertyGroup("Perks/Leadership/{=MhRF64eR}Fervent Attacker")]
    public float ldr_FerventAttacker_s {
      get => _ldr_FerventAttacker_s;
      set {
        if (_ldr_FerventAttacker_s != value) {
          _ldr_FerventAttacker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.FerventAttacker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WsvrvuLE}Additional 8 morale at the beginning of the battle when you are defending.")]
    [SettingPropertyGroup("Perks/Leadership/{=YogcurDJ}Stout Defender")]
    public float ldr_StoutDefender_p {
      get => _ldr_StoutDefender_p;
      set {
        if (_ldr_StoutDefender_p != value) {
          _ldr_StoutDefender_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.StoutDefender, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=27CWu3Zq}Increase the rate of recruiting Tier 4-5-6 prisoners by %50.")]
    [SettingPropertyGroup("Perks/Leadership/{=YogcurDJ}Stout Defender")]
    public float ldr_StoutDefender_s {
      get => _ldr_StoutDefender_s;
      set {
        if (_ldr_StoutDefender_s != value) {
          _ldr_StoutDefender_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.StoutDefender, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=6mhVzBKL}Town garrison is 20% more effective (for security).")]
    [SettingPropertyGroup("Perks/Leadership/{=CeCAMvkX}Authority")]
    public float ldr_Authority_p {
      get => _ldr_Authority_p;
      set {
        if (_ldr_Authority_p != value) {
          _ldr_Authority_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.Authority, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dgVuAcjn}Increase the party size limit by +5.")]
    [SettingPropertyGroup("Perks/Leadership/{=CeCAMvkX}Authority")]
    public float ldr_Authority_s {
      get => _ldr_Authority_s;
      set {
        if (_ldr_Authority_s != value) {
          _ldr_Authority_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.Authority, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=1ZEsHKgI}+1 town loyalty per day.")]
    [SettingPropertyGroup("Perks/Leadership/{=7aX2eh5x}Heroic Leader")]
    public float ldr_HeroicLeader_p {
      get => _ldr_HeroicLeader_p;
      set {
        if (_ldr_HeroicLeader_p != value) {
          _ldr_HeroicLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.HeroicLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=OY0Jwctd}Troops in your formation cause 10% more morale penalty when they kill an enemy.")]
    [SettingPropertyGroup("Perks/Leadership/{=7aX2eh5x}Heroic Leader")]
    public float ldr_HeroicLeader_s {
      get => _ldr_HeroicLeader_s;
      set {
        if (_ldr_HeroicLeader_s != value) {
          _ldr_HeroicLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.HeroicLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vI8qJ85a}Tier 3+ Troops under your command ignore retreat due to low morale.")]
    [SettingPropertyGroup("Perks/Leadership/{=UJYaonYM}Loyalty and Honor")]
    public float ldr_LoyaltyAndHonor_p {
      get => _ldr_LoyaltyAndHonor_p;
      set {
        if (_ldr_LoyaltyAndHonor_p != value) {
          _ldr_LoyaltyAndHonor_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.LoyaltyAndHonor, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ClrrVHcM}Convert non-bandit prisoners 30% faster.")]
    [SettingPropertyGroup("Perks/Leadership/{=UJYaonYM}Loyalty and Honor")]
    public float ldr_LoyaltyAndHonor_s {
      get => _ldr_LoyaltyAndHonor_s;
      set {
        if (_ldr_LoyaltyAndHonor_s != value) {
          _ldr_LoyaltyAndHonor_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.LoyaltyAndHonor, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gV9oppoq}Increase renown gain from battles by 50%.")]
    [SettingPropertyGroup("Perks/Leadership/{=FQkHkMhw}Famous Commander")]
    public float ldr_FamousCommander_p {
      get => _ldr_FamousCommander_p;
      set {
        if (_ldr_FamousCommander_p != value) {
          _ldr_FamousCommander_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.FamousCommander, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=sqC0sWl4}Recruited troops start with bonus experience of 200 xp.")]
    [SettingPropertyGroup("Perks/Leadership/{=FQkHkMhw}Famous Commander")]
    public float ldr_FamousCommander_s {
      get => _ldr_FamousCommander_s;
      set {
        if (_ldr_FamousCommander_s != value) {
          _ldr_FamousCommander_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.FamousCommander, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4BeLW46B}Increase +5 security in a town per day while waiting.")]
    [SettingPropertyGroup("Perks/Leadership/{=6RckjM4S}Presence")]
    public float ldr_Presence_p {
      get => _ldr_Presence_p;
      set {
        if (_ldr_Presence_p != value) {
          _ldr_Presence_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.Presence, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=rCzzYL7U}Remove morale penalty for recruiting prisoners of your faction.")]
    [SettingPropertyGroup("Perks/Leadership/{=6RckjM4S}Presence")]
    public float ldr_Presence_s {
      get => _ldr_Presence_s;
      set {
        if (_ldr_Presence_s != value) {
          _ldr_Presence_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.Presence, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=AuohHCJZ}Increase party size by +5 for each town you control.")]
    [SettingPropertyGroup("Perks/Leadership/{=T5rM9XgO}Leader of the Masses")]
    public float ldr_LeaderOfMasses_p {
      get => _ldr_LeaderOfMasses_p;
      set {
        if (_ldr_LeaderOfMasses_p != value) {
          _ldr_LeaderOfMasses_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.LeaderOfMasses, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=nW8psnGg}Heroes generate shared experience.")]
    [SettingPropertyGroup("Perks/Leadership/{=T5rM9XgO}Leader of the Masses")]
    public float ldr_LeaderOfMasses_s {
      get => _ldr_LeaderOfMasses_s;
      set {
        if (_ldr_LeaderOfMasses_s != value) {
          _ldr_LeaderOfMasses_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.LeaderOfMasses, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6x1EcNvO}Increase garrison size by 20.")]
    [SettingPropertyGroup("Perks/Leadership/{=vWGQNcu5}Veteran's Respect")]
    public float ldr_VeteransRespect_p {
      get => _ldr_VeteransRespect_p;
      set {
        if (_ldr_VeteransRespect_p != value) {
          _ldr_VeteransRespect_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.VeteransRespect, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=tkz13PjS}You are able to convert bandits into regular troops.")]
    [SettingPropertyGroup("Perks/Leadership/{=vWGQNcu5}Veteran's Respect")]
    public float ldr_VeteransRespect_s {
      get => _ldr_VeteransRespect_s;
      set {
        if (_ldr_VeteransRespect_s != value) {
          _ldr_VeteransRespect_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.VeteransRespect, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=R8dqZlqB}Militia has 20% chance to spawn with more experienced troops.")]
    [SettingPropertyGroup("Perks/Leadership/{=vZtLm43v}Citizen Militia")]
    public float ldr_CitizenMilitia_p {
      get => _ldr_CitizenMilitia_p;
      set {
        if (_ldr_CitizenMilitia_p != value) {
          _ldr_CitizenMilitia_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.CitizenMilitia, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=LrXRhmoS}Increased morale gain from victories by 20%.")]
    [SettingPropertyGroup("Perks/Leadership/{=vZtLm43v}Citizen Militia")]
    public float ldr_CitizenMilitia_s {
      get => _ldr_CitizenMilitia_s;
      set {
        if (_ldr_CitizenMilitia_s != value) {
          _ldr_CitizenMilitia_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.CitizenMilitia, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=kaeRYRJN}20% less influence needed to call parties to army.")]
    [SettingPropertyGroup("Perks/Leadership/{=kaEzJUTW}Inspiring Leader")]
    public float ldr_InspiringLeader_p {
      get => _ldr_InspiringLeader_p;
      set {
        if (_ldr_InspiringLeader_p != value) {
          _ldr_InspiringLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.InspiringLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=zalLawWA}Troops in your formation gain 5% more experience from battles.")]
    [SettingPropertyGroup("Perks/Leadership/{=kaEzJUTW}Inspiring Leader")]
    public float ldr_InspiringLeader_s {
      get => _ldr_InspiringLeader_s;
      set {
        if (_ldr_InspiringLeader_s != value) {
          _ldr_InspiringLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.InspiringLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=t4kOTpwY}Increase battle morale by 10 during siege assaults and defense.")]
    [SettingPropertyGroup("Perks/Leadership/{=EbROfVJJ}Uplifting Spirit")]
    public float ldr_UpliftingSpirit_p {
      get => _ldr_UpliftingSpirit_p;
      set {
        if (_ldr_UpliftingSpirit_p != value) {
          _ldr_UpliftingSpirit_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.UpliftingSpirit, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HLoivET9}Party size limit increased by 10.")]
    [SettingPropertyGroup("Perks/Leadership/{=EbROfVJJ}Uplifting Spirit")]
    public float ldr_UpliftingSpirit_s {
      get => _ldr_UpliftingSpirit_s;
      set {
        if (_ldr_UpliftingSpirit_s != value) {
          _ldr_UpliftingSpirit_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.UpliftingSpirit, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=FajKnyPb}Your kills have 100% higher effect on friendly troops' battle morale.")]
    [SettingPropertyGroup("Perks/Leadership/{=5uW9zKTN}Make a Difference")]
    public float ldr_MakeADifference_p {
      get => _ldr_MakeADifference_p;
      set {
        if (_ldr_MakeADifference_p != value) {
          _ldr_MakeADifference_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.MakeADifference, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=KKajZg3a}Archer troops generate 10% more shared experience.")]
    [SettingPropertyGroup("Perks/Leadership/{=5uW9zKTN}Make a Difference")]
    public float ldr_MakeADifference_s {
      get => _ldr_MakeADifference_s;
      set {
        if (_ldr_MakeADifference_s != value) {
          _ldr_MakeADifference_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.MakeADifference, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=DuaVp7UH}Increase the rate of recruiting melee prisoners by %50.")]
    [SettingPropertyGroup("Perks/Leadership/{=WFFlp3Qi}Lead by Example")]
    public float ldr_LeadByExample_p {
      get => _ldr_LeadByExample_p;
      set {
        if (_ldr_LeadByExample_p != value) {
          _ldr_LeadByExample_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.LeadByExample, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=0Yhuvx3C}Cavalry troops generate 10% more shared experience.")]
    [SettingPropertyGroup("Perks/Leadership/{=WFFlp3Qi}Lead by Example")]
    public float ldr_LeadByExample_s {
      get => _ldr_LeadByExample_s;
      set {
        if (_ldr_LeadByExample_s != value) {
          _ldr_LeadByExample_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.LeadByExample, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WZxUAn6V}Increase the rate of recruiting ranged prisoners by %50.")]
    [SettingPropertyGroup("Perks/Leadership/{=6ETg3maz}Trusted Commander")]
    public float ldr_TrustedCommander_p {
      get => _ldr_TrustedCommander_p;
      set {
        if (_ldr_TrustedCommander_p != value) {
          _ldr_TrustedCommander_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.TrustedCommander, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=oHwFpTEw}Troop experience gain while fighting in simulated battles are increased by 20%.")]
    [SettingPropertyGroup("Perks/Leadership/{=6ETg3maz}Trusted Commander")]
    public float ldr_TrustedCommander_s {
      get => _ldr_TrustedCommander_s;
      set {
        if (_ldr_TrustedCommander_s != value) {
          _ldr_TrustedCommander_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.TrustedCommander, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NNalp5mr}+1 companion.")]
    [SettingPropertyGroup("Perks/Leadership/{=3GHIb7YX}We Pledge our Swords")]
    public float ldr_WePledgeOurSwords_p {
      get => _ldr_WePledgeOurSwords_p;
      set {
        if (_ldr_WePledgeOurSwords_p != value) {
          _ldr_WePledgeOurSwords_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.WePledgeOurSwords, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Dl4PUYNO}Add 3 focus points to 3 random clan members when you get this perk.")]
    [SettingPropertyGroup("Perks/Leadership/{=pFfqWRnf}Talent Magnet")]
    public float ldr_TalentMagnet_p {
      get => _ldr_TalentMagnet_p;
      set {
        if (_ldr_TalentMagnet_p != value) {
          _ldr_TalentMagnet_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.TalentMagnet, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=swggGckO}+1 party.")]
    [SettingPropertyGroup("Perks/Leadership/{=pFfqWRnf}Talent Magnet")]
    public float ldr_TalentMagnet_s {
      get => _ldr_TalentMagnet_s;
      set {
        if (_ldr_TalentMagnet_s != value) {
          _ldr_TalentMagnet_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.TalentMagnet, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4BLBgJ1U}Every skill increase after 250 gives you +1 party size.")]
    [SettingPropertyGroup("Perks/Leadership/{=FK3W0SKk}Ultimate Leader")]
    public float ldr_UltimateLeader_p {
      get => _ldr_UltimateLeader_p;
      set {
        if (_ldr_UltimateLeader_p != value) {
          _ldr_UltimateLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Leadership.UltimateLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="Unknown")]
    [SettingPropertyGroup("Perks/Leadership/{=FK3W0SKk}Ultimate Leader")]
    public float ldr_UltimateLeader_s {
      get => _ldr_UltimateLeader_s;
      set {
        if (_ldr_UltimateLeader_s != value) {
          _ldr_UltimateLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Leadership.UltimateLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=bbkVpX2U}30% more likely to have children.")]
    [SettingPropertyGroup("Perks/Charm/{=mbqoZ4WH}Virile")]
    public float chm_Virile_p {
      get => _chm_Virile_p;
      set {
        if (_chm_Virile_p != value) {
          _chm_Virile_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.Virile, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=8F1JaR4I}10% chance to get 1 relation with a random notable in governed settlement per day while continuous projects are active.")]
    [SettingPropertyGroup("Perks/Charm/{=mbqoZ4WH}Virile")]
    public float chm_Virile_s {
      get => _chm_Virile_s;
      set {
        if (_chm_Virile_s != value) {
          _chm_Virile_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.Virile, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=TbIub0u8}Gain 5 influence by winning a tournament.")]
    [SettingPropertyGroup("Perks/Charm/{=hkG9ATZy}Self Promoter")]
    public float chm_SelfPromoter_p {
      get => _chm_SelfPromoter_p;
      set {
        if (_chm_SelfPromoter_p != value) {
          _chm_SelfPromoter_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.SelfPromoter, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=ikNAXaNx}Gain 1 morale while in a besieged settlement.")]
    [SettingPropertyGroup("Perks/Charm/{=hkG9ATZy}Self Promoter")]
    public float chm_SelfPromoter_s {
      get => _chm_SelfPromoter_s;
      set {
        if (_chm_SelfPromoter_s != value) {
          _chm_SelfPromoter_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.SelfPromoter, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=JBLwQVNT}You gain 1 renown and influence for each issue resolved.")]
    [SettingPropertyGroup("Perks/Charm/{=OZXEMb2C}Oratory")]
    public float chm_Oratory_p {
      get => _chm_Oratory_p;
      set {
        if (_chm_Oratory_p != value) {
          _chm_Oratory_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.Oratory, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=IYYv49rg}Everytime you defeat an enemy lord party you gain 1 relationship with a random notable of your faction.")]
    [SettingPropertyGroup("Perks/Charm/{=OZXEMb2C}Oratory")]
    public float chm_Oratory_s {
      get => _chm_Oratory_s;
      set {
        if (_chm_Oratory_s != value) {
          _chm_Oratory_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.Oratory, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=1CqmyOu7}Increase influence gain from battles by 30%.")]
    [SettingPropertyGroup("Perks/Charm/{=jiWr5Rlz}Warlord")]
    public float chm_Warlord_p {
      get => _chm_Warlord_p;
      set {
        if (_chm_Warlord_p != value) {
          _chm_Warlord_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.Warlord, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dwTnvjXW}Everytime you defeat an enemy lord party you gain +1 relationship with a random lord of your faction.")]
    [SettingPropertyGroup("Perks/Charm/{=jiWr5Rlz}Warlord")]
    public float chm_Warlord_s {
      get => _chm_Warlord_s;
      set {
        if (_chm_Warlord_s != value) {
          _chm_Warlord_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.Warlord, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=Pt2n5Cez}20% chance to avoid persuasion critical failure.")]
    [SettingPropertyGroup("Perks/Charm/{=l863hIyN}Forgivable Grievances")]
    public float chm_ForgivableGrievances_p {
      get => _chm_ForgivableGrievances_p;
      set {
        if (_chm_ForgivableGrievances_p != value) {
          _chm_ForgivableGrievances_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.ForgivableGrievances, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=hbrMyK5N}5% chance per day to increase relations with a random NPC of negative relations with you within the settlement.")]
    [SettingPropertyGroup("Perks/Charm/{=l863hIyN}Forgivable Grievances")]
    public float chm_ForgivableGrievances_s {
      get => _chm_ForgivableGrievances_s;
      set {
        if (_chm_ForgivableGrievances_s != value) {
          _chm_ForgivableGrievances_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.ForgivableGrievances, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=bGX2Iojc}10% better chance for double persuasion success.")]
    [SettingPropertyGroup("Perks/Charm/{=4hUEryJ6}Meaningful Favors")]
    public float chm_MeaningfulFavors_p {
      get => _chm_MeaningfulFavors_p;
      set {
        if (_chm_MeaningfulFavors_p != value) {
          _chm_MeaningfulFavors_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.MeaningfulFavors, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=OFai6MA4}Relations with powerful settlement NPCs improve overtime.")]
    [SettingPropertyGroup("Perks/Charm/{=4hUEryJ6}Meaningful Favors")]
    public float chm_MeaningfulFavors_s {
      get => _chm_MeaningfulFavors_s;
      set {
        if (_chm_MeaningfulFavors_s != value) {
          _chm_MeaningfulFavors_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.MeaningfulFavors, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=3cQs44Et}Increase any relationship gain with opposite gender by 20%.")]
    [SettingPropertyGroup("Perks/Charm/{=ZlXSlx0p}In Bloom")]
    public float chm_InBloom_p {
      get => _chm_InBloom_p;
      set {
        if (_chm_InBloom_p != value) {
          _chm_InBloom_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.InBloom, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dFXay84g}2% chance per day to increase relations with a random notable of opposed sex within the settlement.")]
    [SettingPropertyGroup("Perks/Charm/{=ZlXSlx0p}In Bloom")]
    public float chm_InBloom_s {
      get => _chm_InBloom_s;
      set {
        if (_chm_InBloom_s != value) {
          _chm_InBloom_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.InBloom, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=I4JZRzuH}Increase any relationship gain with same gender by 20%.")]
    [SettingPropertyGroup("Perks/Charm/{=TpzZgFsA}Young And Respectful")]
    public float chm_YoungAndRespectful_p {
      get => _chm_YoungAndRespectful_p;
      set {
        if (_chm_YoungAndRespectful_p != value) {
          _chm_YoungAndRespectful_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.YoungAndRespectful, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=nrvNbenk}2% chance per day to increase relations with a random notable of same sex within the settlement.")]
    [SettingPropertyGroup("Perks/Charm/{=TpzZgFsA}Young And Respectful")]
    public float chm_YoungAndRespectful_s {
      get => _chm_YoungAndRespectful_s;
      set {
        if (_chm_YoungAndRespectful_s != value) {
          _chm_YoungAndRespectful_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.YoungAndRespectful, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=sIWEhq1p}50% less influence cost to initiate kingdom decisions.")]
    [SettingPropertyGroup("Perks/Charm/{=EbKP7Xx5}Firebrand")]
    public float chm_Firebrand_p {
      get => _chm_Firebrand_p;
      set {
        if (_chm_Firebrand_p != value) {
          _chm_Firebrand_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.Firebrand, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=0yGa0Iwb}Increase recruitment level from rural notables by +1.")]
    [SettingPropertyGroup("Perks/Charm/{=EbKP7Xx5}Firebrand")]
    public float chm_Firebrand_s {
      get => _chm_Firebrand_s;
      set {
        if (_chm_Firebrand_s != value) {
          _chm_Firebrand_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.Firebrand, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=7xNrHsWx}30% less influence cost when voting for proposals made by other people.")]
    [SettingPropertyGroup("Perks/Charm/{=58Imsasy}Flexible Ethics")]
    public float chm_FlexibleEthics_p {
      get => _chm_FlexibleEthics_p;
      set {
        if (_chm_FlexibleEthics_p != value) {
          _chm_FlexibleEthics_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.FlexibleEthics, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=MfTx4gyp}Increase recruitment level from urban notables by +1.")]
    [SettingPropertyGroup("Perks/Charm/{=58Imsasy}Flexible Ethics")]
    public float chm_FlexibleEthics_s {
      get => _chm_FlexibleEthics_s;
      set {
        if (_chm_FlexibleEthics_s != value) {
          _chm_FlexibleEthics_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.FlexibleEthics, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=UbBnKVaI}Hiring mercenaries is 20% cheaper.")]
    [SettingPropertyGroup("Perks/Charm/{=WOqxWM67}Slick Negotiator")]
    public float chm_SlickNegotiator_p {
      get => _chm_SlickNegotiator_p;
      set {
        if (_chm_SlickNegotiator_p != value) {
          _chm_SlickNegotiator_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.SlickNegotiator, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=DdoGlKmU}Reduce item barter penalty with the lords of the different culture with you 10%.")]
    [SettingPropertyGroup("Perks/Charm/{=WOqxWM67}Slick Negotiator")]
    public float chm_SlickNegotiator_s {
      get => _chm_SlickNegotiator_s;
      set {
        if (_chm_SlickNegotiator_s != value) {
          _chm_SlickNegotiator_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.SlickNegotiator, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=joDbjfWd}Increase relationship bonus by 20% chance when paying more than enough in barters.")]
    [SettingPropertyGroup("Perks/Charm/{=dSBbSHkM}Tribute")]
    public float chm_Tribute_p {
      get => _chm_Tribute_p;
      set {
        if (_chm_Tribute_p != value) {
          _chm_Tribute_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.Tribute, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=2i4EmlLi}Gain additional relation when you increase relationship with cruel lords.")]
    [SettingPropertyGroup("Perks/Charm/{=dSBbSHkM}Tribute")]
    public float chm_Tribute_s {
      get => _chm_Tribute_s;
      set {
        if (_chm_Tribute_s != value) {
          _chm_Tribute_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.Tribute, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=aj2yAdM9}Characters in your own faction requires -1 persusion success.")]
    [SettingPropertyGroup("Perks/Charm/{=zUXUrGWa}Morale Leader")]
    public float chm_MoralLeader_p {
      get => _chm_MoralLeader_p;
      set {
        if (_chm_MoralLeader_p != value) {
          _chm_MoralLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.MoralLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=CGOG31aq}For every project completed increase notable relations with the owner by 1.")]
    [SettingPropertyGroup("Perks/Charm/{=zUXUrGWa}Morale Leader")]
    public float chm_MoralLeader_s {
      get => _chm_MoralLeader_s;
      set {
        if (_chm_MoralLeader_s != value) {
          _chm_MoralLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.MoralLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=PgWBBJbP}Characters in other factions requires -1 persusion success.")]
    [SettingPropertyGroup("Perks/Charm/{=qaZDUknZ}Natural Leader")]
    public float chm_NaturalLeader_p {
      get => _chm_NaturalLeader_p;
      set {
        if (_chm_NaturalLeader_p != value) {
          _chm_NaturalLeader_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.NaturalLeader, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=aZIEZktN}Your companions gain 20% more experience.")]
    [SettingPropertyGroup("Perks/Charm/{=qaZDUknZ}Natural Leader")]
    public float chm_NaturalLeader_s {
      get => _chm_NaturalLeader_s;
      set {
        if (_chm_NaturalLeader_s != value) {
          _chm_NaturalLeader_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.NaturalLeader, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=56XKyOib}Renown gain from battles are increased by 30%.")]
    [SettingPropertyGroup("Perks/Charm/{=16fxd9fN}Public Speaker")]
    public float chm_PublicSpeaker_p {
      get => _chm_PublicSpeaker_p;
      set {
        if (_chm_PublicSpeaker_p != value) {
          _chm_PublicSpeaker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.PublicSpeaker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=IF7tcOY6}You gain double relations with a lord when you aid them in battle.")]
    [SettingPropertyGroup("Perks/Charm/{=p2zZGkZw}Camaraderie")]
    public float chm_Camaraderie_p {
      get => _chm_Camaraderie_p;
      set {
        if (_chm_Camaraderie_p != value) {
          _chm_Camaraderie_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Charm.Camaraderie, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Tqfqgub5}Increase companion limit by +1.")]
    [SettingPropertyGroup("Perks/Charm/{=p2zZGkZw}Camaraderie")]
    public float chm_Camaraderie_s {
      get => _chm_Camaraderie_s;
      set {
        if (_chm_Camaraderie_s != value) {
          _chm_Camaraderie_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Charm.Camaraderie, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=HokNfd1i}15% decrease in sell price penalty for equipments.")]
    [SettingPropertyGroup("Perks/Trade/{=b3PsxeiB}Appraiser")]
    public float trd_Appraiser_p {
      get => _trd_Appraiser_p;
      set {
        if (_trd_Appraiser_p != value) {
          _trd_Appraiser_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.Appraiser, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=gHUQfWlg}Your profits are marked.")]
    [SettingPropertyGroup("Perks/Trade/{=b3PsxeiB}Appraiser")]
    public float trd_Appraiser_s {
      get => _trd_Appraiser_s;
      set {
        if (_trd_Appraiser_s != value) {
          _trd_Appraiser_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.Appraiser, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=Dqjq02Sd}15% decrease in sell price penalty for trade goods.")]
    [SettingPropertyGroup("Perks/Trade/{=lTNpxGoh}Whole Seller")]
    public float trd_WholeSeller_p {
      get => _trd_WholeSeller_p;
      set {
        if (_trd_WholeSeller_p != value) {
          _trd_WholeSeller_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.WholeSeller, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=gHUQfWlg}Your profits are marked.")]
    [SettingPropertyGroup("Perks/Trade/{=lTNpxGoh}Whole Seller")]
    public float trd_WholeSeller_s {
      get => _trd_WholeSeller_s;
      set {
        if (_trd_WholeSeller_s != value) {
          _trd_WholeSeller_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.WholeSeller, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=6bVZbvFJ}Party can carry 30% more weight.")]
    [SettingPropertyGroup("Perks/Trade/{=5acLha5Q}Caravan Master")]
    public float trd_CaravanMaster_p {
      get => _trd_CaravanMaster_p;
      set {
        if (_trd_CaravanMaster_p != value) {
          _trd_CaravanMaster_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.CaravanMaster, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=awog3kRm}Mark item prices relative to average price.")]
    [SettingPropertyGroup("Perks/Trade/{=5acLha5Q}Caravan Master")]
    public float trd_CaravanMaster_s {
      get => _trd_CaravanMaster_s;
      set {
        if (_trd_CaravanMaster_s != value) {
          _trd_CaravanMaster_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.CaravanMaster, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=eWa2Rcla}Your workshops have 20% less upkeep.")]
    [SettingPropertyGroup("Perks/Trade/{=InLGoUbB}Market Dealer")]
    public float trd_MarketDealer_p {
      get => _trd_MarketDealer_p;
      set {
        if (_trd_MarketDealer_p != value) {
          _trd_MarketDealer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.MarketDealer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=awog3kRm}Mark item prices relative to average price.")]
    [SettingPropertyGroup("Perks/Trade/{=InLGoUbB}Market Dealer")]
    public float trd_MarketDealer_s {
      get => _trd_MarketDealer_s;
      set {
        if (_trd_MarketDealer_s != value) {
          _trd_MarketDealer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.MarketDealer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=DV2kW53e}Your caravans gather trade rumors.")]
    [SettingPropertyGroup("Perks/Trade/{=3j6Ec63l}Traveling Rumors")]
    public float trd_TravelingRumors_p {
      get => _trd_TravelingRumors_p;
      set {
        if (_trd_TravelingRumors_p != value) {
          _trd_TravelingRumors_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.TravelingRumors, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=WeQla2wI}15% decrease in buy price penalty from villages.")]
    [SettingPropertyGroup("Perks/Trade/{=3j6Ec63l}Traveling Rumors")]
    public float trd_TravelingRumors_s {
      get => _trd_TravelingRumors_s;
      set {
        if (_trd_TravelingRumors_s != value) {
          _trd_TravelingRumors_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.TravelingRumors, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=SOHgkGKy}Your workshops gather trade rumors.")]
    [SettingPropertyGroup("Perks/Trade/{=mznjEwjC}Local Connection")]
    public float trd_LocalConnection_p {
      get => _trd_LocalConnection_p;
      set {
        if (_trd_LocalConnection_p != value) {
          _trd_LocalConnection_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.LocalConnection, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=TbXWCRa0}15% decrease in sell price penalty for Animals.")]
    [SettingPropertyGroup("Perks/Trade/{=mznjEwjC}Local Connection")]
    public float trd_LocalConnection_s {
      get => _trd_LocalConnection_s;
      set {
        if (_trd_LocalConnection_s != value) {
          _trd_LocalConnection_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.LocalConnection, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=cepOilBX}Double relationship gain by resolved issues with artisans.")]
    [SettingPropertyGroup("Perks/Trade/{=nxkNY4YG}Distributed Goods")]
    public float trd_DistributedGoods_p {
      get => _trd_DistributedGoods_p;
      set {
        if (_trd_DistributedGoods_p != value) {
          _trd_DistributedGoods_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.DistributedGoods, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4ScutTtz}Every villager party entering your town generates 30 gold income")]
    [SettingPropertyGroup("Perks/Trade/{=nxkNY4YG}Distributed Goods")]
    public float trd_DistributedGoods_s {
      get => _trd_DistributedGoods_s;
      set {
        if (_trd_DistributedGoods_s != value) {
          _trd_DistributedGoods_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.DistributedGoods, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=qgIMB69a}Double relationship gain by resolved issues with merchants.")]
    [SettingPropertyGroup("Perks/Trade/{=JnSh4Fmz}Toll Gates")]
    public float trd_Tollgates_p {
      get => _trd_Tollgates_p;
      set {
        if (_trd_Tollgates_p != value) {
          _trd_Tollgates_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.Tollgates, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=fFqT4eJ2}Every caravan entering your town generates 20 gold income.")]
    [SettingPropertyGroup("Perks/Trade/{=JnSh4Fmz}Toll Gates")]
    public float trd_Tollgates_s {
      get => _trd_Tollgates_s;
      set {
        if (_trd_Tollgates_s != value) {
          _trd_Tollgates_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.Tollgates, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=81qgJ7fW}Every profitable workshop you own gives you 1 renown per day.")]
    [SettingPropertyGroup("Perks/Trade/{=8f8UGq46}Artisan Community")]
    public float trd_ArtisanCommunity_p {
      get => _trd_ArtisanCommunity_p;
      set {
        if (_trd_ArtisanCommunity_p != value) {
          _trd_ArtisanCommunity_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.ArtisanCommunity, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=tJqWNH2H}Increase recruitment slot by 1 when recruiting from merchant notables.")]
    [SettingPropertyGroup("Perks/Trade/{=8f8UGq46}Artisan Community")]
    public float trd_ArtisanCommunity_s {
      get => _trd_ArtisanCommunity_s;
      set {
        if (_trd_ArtisanCommunity_s != value) {
          _trd_ArtisanCommunity_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.ArtisanCommunity, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NVnuAwuU}Every profitable caravan you own gives you 1 renown per day.")]
    [SettingPropertyGroup("Perks/Trade/{=g9qLrEb4}Great Investor")]
    public float trd_GreatInvestor_p {
      get => _trd_GreatInvestor_p;
      set {
        if (_trd_GreatInvestor_p != value) {
          _trd_GreatInvestor_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.GreatInvestor, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=axdYx3zY}Hiring companions is 30% cheaper.")]
    [SettingPropertyGroup("Perks/Trade/{=g9qLrEb4}Great Investor")]
    public float trd_GreatInvestor_s {
      get => _trd_GreatInvestor_s;
      set {
        if (_trd_GreatInvestor_s != value) {
          _trd_GreatInvestor_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.GreatInvestor, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=B1meG5eO}Your workshop productions are increased by 25%.")]
    [SettingPropertyGroup("Perks/Trade/{=*}Mercenary Connections")]
    public float trd_MercenaryConnections_p {
      get => _trd_MercenaryConnections_p;
      set {
        if (_trd_MercenaryConnections_p != value) {
          _trd_MercenaryConnections_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.MercenaryConnections, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=*}Mercenary troops' wages are decreased by 25%.")]
    [SettingPropertyGroup("Perks/Trade/{=*}Mercenary Connections")]
    public float trd_MercenaryConnections_s {
      get => _trd_MercenaryConnections_s;
      set {
        if (_trd_MercenaryConnections_s != value) {
          _trd_MercenaryConnections_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.MercenaryConnections, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=BRbEODrQ}Increased tariff income by 10%.")]
    [SettingPropertyGroup("Perks/Trade/{=FV4SWLQx}Content Trades")]
    public float trd_ContentTrades_p {
      get => _trd_ContentTrades_p;
      set {
        if (_trd_ContentTrades_p != value) {
          _trd_ContentTrades_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.ContentTrades, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=rbYHF03o}Party wage is decreased by 50% while waiting in settlements.")]
    [SettingPropertyGroup("Perks/Trade/{=FV4SWLQx}Content Trades")]
    public float trd_ContentTrades_s {
      get => _trd_ContentTrades_s;
      set {
        if (_trd_ContentTrades_s != value) {
          _trd_ContentTrades_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.ContentTrades, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=TXnHX2Ed}Your caravans return 5000 gold when destroyed.")]
    [SettingPropertyGroup("Perks/Trade/{=aYQybo4E}Insurance Plans")]
    public float trd_InsurancePlans_p {
      get => _trd_InsurancePlans_p;
      set {
        if (_trd_InsurancePlans_p != value) {
          _trd_InsurancePlans_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.InsurancePlans, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=oQxJYJsq}25% decrease in buy price penalty food items.")]
    [SettingPropertyGroup("Perks/Trade/{=aYQybo4E}Insurance Plans")]
    public float trd_InsurancePlans_s {
      get => _trd_InsurancePlans_s;
      set {
        if (_trd_InsurancePlans_s != value) {
          _trd_InsurancePlans_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.InsurancePlans, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=jPcULnsk}Your workshops return 5000 gold when town is captured by enemy.")]
    [SettingPropertyGroup("Perks/Trade/{=u9oONz9o}Rapid Development")]
    public float trd_RapidDevelopment_p {
      get => _trd_RapidDevelopment_p;
      set {
        if (_trd_RapidDevelopment_p != value) {
          _trd_RapidDevelopment_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.RapidDevelopment, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=QorXGtie}25% decrease in buy price penalty clay / iron / cotton / silver.")]
    [SettingPropertyGroup("Perks/Trade/{=u9oONz9o}Rapid Development")]
    public float trd_RapidDevelopment_s {
      get => _trd_RapidDevelopment_s;
      set {
        if (_trd_RapidDevelopment_s != value) {
          _trd_RapidDevelopment_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.RapidDevelopment, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=ZqRMPC7F}20% decrease in sell price penalty for food trade goods.")]
    [SettingPropertyGroup("Perks/Trade/{=TFy2VYtM}Granary Accountant")]
    public float trd_GranaryAccountant_p {
      get => _trd_GranaryAccountant_p;
      set {
        if (_trd_GranaryAccountant_p != value) {
          _trd_GranaryAccountant_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.GranaryAccountant, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vWxioznX}Your towns' bound villages' grain / olives / fish / date production is increased by 20%")]
    [SettingPropertyGroup("Perks/Trade/{=TFy2VYtM}Granary Accountant")]
    public float trd_GranaryAccountant_s {
      get => _trd_GranaryAccountant_s;
      set {
        if (_trd_GranaryAccountant_s != value) {
          _trd_GranaryAccountant_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.GranaryAccountant, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=UbBnKVaI}Hiring mercenaries is 20% cheaper.")]
    [SettingPropertyGroup("Perks/Trade/{=AIsDxCeG}Sword For Barter")]
    public float trd_SwordForBarter_p {
      get => _trd_SwordForBarter_p;
      set {
        if (_trd_SwordForBarter_p != value) {
          _trd_SwordForBarter_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.SwordForBarter, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=xZtdcNmM}15% lower wage for caravan guards troops.")]
    [SettingPropertyGroup("Perks/Trade/{=AIsDxCeG}Sword For Barter")]
    public float trd_SwordForBarter_s {
      get => _trd_SwordForBarter_s;
      set {
        if (_trd_SwordForBarter_s != value) {
          _trd_SwordForBarter_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.SwordForBarter, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=*}Decrease barter penalty for items by 50%.")]
    [SettingPropertyGroup("Perks/Trade/{=uHJltZ5D}Self-made Man")]
    public float trd_SelfMadeMan_p {
      get => _trd_SelfMadeMan_p;
      set {
        if (_trd_SelfMadeMan_p != value) {
          _trd_SelfMadeMan_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.SelfMadeMan, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=0g4R557I}Negotiation for safe passage barter is 50% cheaper.")]
    [SettingPropertyGroup("Perks/Trade/{=5rDdJpJo}Silver Tongue")]
    public float trd_SilverTongue_p {
      get => _trd_SilverTongue_p;
      set {
        if (_trd_SilverTongue_p != value) {
          _trd_SilverTongue_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.SilverTongue, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=3DF72oIo}Caravans and villagers offer 15% better trade deals.")]
    [SettingPropertyGroup("Perks/Trade/{=5rDdJpJo}Silver Tongue")]
    public float trd_SilverTongue_s {
      get => _trd_SilverTongue_s;
      set {
        if (_trd_SilverTongue_s != value) {
          _trd_SilverTongue_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.SilverTongue, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=CLPj9WZe}Recruitment of minor factions into your clan is 20% cheaper.")]
    [SettingPropertyGroup("Perks/Trade/{=Jy2ap8L1}Man of Means")]
    public float trd_ManOfMeans_p {
      get => _trd_ManOfMeans_p;
      set {
        if (_trd_ManOfMeans_p != value) {
          _trd_ManOfMeans_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.ManOfMeans, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=PQ3zjab7}You will get 30% reduced ransom offer.")]
    [SettingPropertyGroup("Perks/Trade/{=Jy2ap8L1}Man of Means")]
    public float trd_ManOfMeans_s {
      get => _trd_ManOfMeans_s;
      set {
        if (_trd_ManOfMeans_s != value) {
          _trd_ManOfMeans_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.ManOfMeans, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=gT9QF6ML}Gain relationship 1 with merchant notables if you buy more than 10000 gold worth of trade goods in a town.")]
    [SettingPropertyGroup("Perks/Trade/{=L4fz3Jdr}Trickle Down")]
    public float trd_TrickleDown_p {
      get => _trd_TrickleDown_p;
      set {
        if (_trd_TrickleDown_p != value) {
          _trd_TrickleDown_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Trade.TrickleDown, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=aVZcVuIu}Governed town gains 1 prosperity per day as long as it is building a project.")]
    [SettingPropertyGroup("Perks/Trade/{=L4fz3Jdr}Trickle Down")]
    public float trd_TrickleDown_s {
      get => _trd_TrickleDown_s;
      set {
        if (_trd_TrickleDown_s != value) {
          _trd_TrickleDown_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Trade.TrickleDown, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=TWaxzej6}Party consumes 10% less food.")]
    [SettingPropertyGroup("Perks/Steward/{=PX0Xufmr}Spartan")]
    public float st_Spartan_p {
      get => _st_Spartan_p;
      set {
        if (_st_Spartan_p != value) {
          _st_Spartan_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Spartan, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=mSvfxXVW}No morale penalty from having single type of food.")]
    [SettingPropertyGroup("Perks/Steward/{=PX0Xufmr}Spartan")]
    public float st_Spartan_s {
      get => _st_Spartan_s;
      set {
        if (_st_Spartan_s != value) {
          _st_Spartan_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Spartan, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=6d755ZJ5}Party wages are 5% less.")]
    [SettingPropertyGroup("Perks/Steward/{=eJIbMa8P}Frugal")]
    public float st_Frugal_p {
      get => _st_Frugal_p;
      set {
        if (_st_Frugal_p != value) {
          _st_Frugal_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Frugal, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=xgIDGakc}Recruitment costs are reduced by 15%.")]
    [SettingPropertyGroup("Perks/Steward/{=eJIbMa8P}Frugal")]
    public float st_Frugal_s {
      get => _st_Frugal_s;
      set {
        if (_st_Frugal_s != value) {
          _st_Frugal_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Frugal, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=z4lWVbHy}Tier 4+ troops gain +4 daily xp.")]
    [SettingPropertyGroup("Perks/Steward/{=2ryLuN2i}Seven Veterans")]
    public float st_SevenVeterans_p {
      get => _st_SevenVeterans_p;
      set {
        if (_st_SevenVeterans_p != value) {
          _st_SevenVeterans_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.SevenVeterans, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=tZumf1sD}+1 militia per day.")]
    [SettingPropertyGroup("Perks/Steward/{=2ryLuN2i}Seven Veterans")]
    public float st_SevenVeterans_s {
      get => _st_SevenVeterans_s;
      set {
        if (_st_SevenVeterans_s != value) {
          _st_SevenVeterans_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.SevenVeterans, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=vvb8UG8i}All troops gain +2 daily xp.")]
    [SettingPropertyGroup("Perks/Steward/{=L9k4bovO}Drill Sergeant")]
    public float st_DrillSergant_p {
      get => _st_DrillSergant_p;
      set {
        if (_st_DrillSergant_p != value) {
          _st_DrillSergant_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.DrillSergant, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=KstesAiE}Garrison wages are 5% less.")]
    [SettingPropertyGroup("Perks/Steward/{=L9k4bovO}Drill Sergeant")]
    public float st_DrillSergant_s {
      get => _st_DrillSergant_s;
      set {
        if (_st_DrillSergant_s != value) {
          _st_DrillSergant_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.DrillSergant, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Hapal2OX}Workshops owned by you have 20% increased production.")]
    [SettingPropertyGroup("Perks/Steward/{=jbAtOsIy}Sweatshops")]
    public float st_Sweatshops_p {
      get => _st_Sweatshops_p;
      set {
        if (_st_Sweatshops_p != value) {
          _st_Sweatshops_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Sweatshops, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=NUiIPZRm}Siege engines are built 20% faster.")]
    [SettingPropertyGroup("Perks/Steward/{=jbAtOsIy}Sweatshops")]
    public float st_Sweatshops_s {
      get => _st_Sweatshops_s;
      set {
        if (_st_Sweatshops_s != value) {
          _st_Sweatshops_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Sweatshops, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=GpKJ7N4d}Reduce food consumption while in an army by 10%.")]
    [SettingPropertyGroup("Perks/Steward/{=QUeJ4gc3}Stiff Upper Lip")]
    public float st_StiffUpperLip_p {
      get => _st_StiffUpperLip_p;
      set {
        if (_st_StiffUpperLip_p != value) {
          _st_StiffUpperLip_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.StiffUpperLip, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=EDWcOdGI}Garrison wages are decreased by 20% for castles.")]
    [SettingPropertyGroup("Perks/Steward/{=QUeJ4gc3}Stiff Upper Lip")]
    public float st_StiffUpperLip_s {
      get => _st_StiffUpperLip_s;
      set {
        if (_st_StiffUpperLip_s != value) {
          _st_StiffUpperLip_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.StiffUpperLip, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=9pOPaFXb}Companion wages and recruitment fees are reduced by 25%.")]
    [SettingPropertyGroup("Perks/Steward/{=CPxbG7Zp}Paid in Promise")]
    public float st_PaidInPromise_p {
      get => _st_PaidInPromise_p;
      set {
        if (_st_PaidInPromise_p != value) {
          _st_PaidInPromise_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.PaidInPromise, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=JSHVCviV}Discarded armors can be donated to troops for increased experience.")]
    [SettingPropertyGroup("Perks/Steward/{=CPxbG7Zp}Paid in Promise")]
    public float st_PaidInPromise_s {
      get => _st_PaidInPromise_s;
      set {
        if (_st_PaidInPromise_s != value) {
          _st_PaidInPromise_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.PaidInPromise, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=*}During village raids you gain an additional food item for each one you loot.")]
    [SettingPropertyGroup("Perks/Steward/{=sC53NYcA}Efficient Campaigner")]
    public float st_EfficientCampaigner_p {
      get => _st_EfficientCampaigner_p;
      set {
        if (_st_EfficientCampaigner_p != value) {
          _st_EfficientCampaigner_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.EfficientCampaigner, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=TCtGVTTk}Troop wages are decreased by 25% while in an army.")]
    [SettingPropertyGroup("Perks/Steward/{=sC53NYcA}Efficient Campaigner")]
    public float st_EfficientCampaigner_s {
      get => _st_EfficientCampaigner_s;
      set {
        if (_st_EfficientCampaigner_s != value) {
          _st_EfficientCampaigner_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.EfficientCampaigner, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=NM1lcYQI}Discarded weapons can be donated to troops for increased experience.")]
    [SettingPropertyGroup("Perks/Steward/{=VsqyzWYY}Giving Hands")]
    public float st_GivingHands_p {
      get => _st_GivingHands_p;
      set {
        if (_st_GivingHands_p != value) {
          _st_GivingHands_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.GivingHands, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=pmsItOBR}Tariff income is 10% higher.")]
    [SettingPropertyGroup("Perks/Steward/{=VsqyzWYY}Giving Hands")]
    public float st_GivingHands_s {
      get => _st_GivingHands_s;
      set {
        if (_st_GivingHands_s != value) {
          _st_GivingHands_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.GivingHands, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=mchBqAXt}Increase party morale by 4 if number of mounts is greater than non-cavalry troops.")]
    [SettingPropertyGroup("Perks/Steward/{=U2buPiec}Logistician")]
    public float st_Logistician_p {
      get => _st_Logistician_p;
      set {
        if (_st_Logistician_p != value) {
          _st_Logistician_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Logistician, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=iMPNkxTB}Tax income is 10% higher.")]
    [SettingPropertyGroup("Perks/Steward/{=U2buPiec}Logistician")]
    public float st_Logistician_s {
      get => _st_Logistician_s;
      set {
        if (_st_Logistician_s != value) {
          _st_Logistician_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Logistician, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=YrywEzSc}Influence gain from donating troops are increased by 25%.")]
    [SettingPropertyGroup("Perks/Steward/{=R6dnhblo}Relocation")]
    public float st_Relocation_p {
      get => _st_Relocation_p;
      set {
        if (_st_Relocation_p != value) {
          _st_Relocation_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Relocation, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=mIfHAazB}Project boosting is more 20% effective.")]
    [SettingPropertyGroup("Perks/Steward/{=R6dnhblo}Relocation")]
    public float st_Relocation_s {
      get => _st_Relocation_s;
      set {
        if (_st_Relocation_s != value) {
          _st_Relocation_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Relocation, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=RKHb4xse}Do not pay wages for wounded soldiers.")]
    [SettingPropertyGroup("Perks/Steward/{=4FdtVyj1}Aid Corps")]
    public float st_AidCorps_p {
      get => _st_AidCorps_p;
      set {
        if (_st_AidCorps_p != value) {
          _st_AidCorps_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.AidCorps, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=QWDAY3OJ}Increase village hearth growth rate by 20%.")]
    [SettingPropertyGroup("Perks/Steward/{=4FdtVyj1}Aid Corps")]
    public float st_AidCorps_s {
      get => _st_AidCorps_s;
      set {
        if (_st_AidCorps_s != value) {
          _st_AidCorps_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.AidCorps, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=c9aKz2A6}Morale bonus from having diverse food is doubled.")]
    [SettingPropertyGroup("Perks/Steward/{=63lHFDSG}Gourmet")]
    public float st_Gourmet_p {
      get => _st_Gourmet_p;
      set {
        if (_st_Gourmet_p != value) {
          _st_Gourmet_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Gourmet, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=d52z03aH}Reduce food consumption of garrisons during siege by 10%.")]
    [SettingPropertyGroup("Perks/Steward/{=63lHFDSG}Gourmet")]
    public float st_Gourmet_s {
      get => _st_Gourmet_s;
      set {
        if (_st_Gourmet_s != value) {
          _st_Gourmet_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Gourmet, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=dlLibmSM}Cost of upgrading units are decreased by 10%.")]
    [SettingPropertyGroup("Perks/Steward/{=O5dgeoss}Sound Reserves")]
    public float st_SoundReserves_p {
      get => _st_SoundReserves_p;
      set {
        if (_st_SoundReserves_p != value) {
          _st_SoundReserves_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.SoundReserves, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=AhyaNGD9}Reduce food consumption of parties during siege by 10%.")]
    [SettingPropertyGroup("Perks/Steward/{=O5dgeoss}Sound Reserves")]
    public float st_SoundReserves_s {
      get => _st_SoundReserves_s;
      set {
        if (_st_SoundReserves_s != value) {
          _st_SoundReserves_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.SoundReserves, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=SzvHCF7s}Prisoners in your party provide carry capacity as if they are a normal troop.")]
    [SettingPropertyGroup("Perks/Steward/{=cWyqiNrf}Forced Labor")]
    public float st_ForcedLabor_p {
      get => _st_ForcedLabor_p;
      set {
        if (_st_ForcedLabor_p != value) {
          _st_ForcedLabor_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.ForcedLabor, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=znaDexg2}Construction speed is increased by 10%.")]
    [SettingPropertyGroup("Perks/Steward/{=cWyqiNrf}Forced Labor")]
    public float st_ForcedLabor_s {
      get => _st_ForcedLabor_s;
      set {
        if (_st_ForcedLabor_s != value) {
          _st_ForcedLabor_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.ForcedLabor, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=XzFSWBMG}Mercenary troops' wages and upgrade costs are decreased by 25%.")]
    [SettingPropertyGroup("Perks/Steward/{=Pg5enC8c}Contractors")]
    public float st_Contractors_p {
      get => _st_Contractors_p;
      set {
        if (_st_Contractors_p != value) {
          _st_Contractors_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.Contractors, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=C3rAwf7p}Town projects are 10% more effective.")]
    [SettingPropertyGroup("Perks/Steward/{=Pg5enC8c}Contractors")]
    public float st_Contractors_s {
      get => _st_Contractors_s;
      set {
        if (_st_Contractors_s != value) {
          _st_Contractors_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.Contractors, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=54Nszjhl}20% increased carrying capacity for pack animals.")]
    [SettingPropertyGroup("Perks/Steward/{=qBx8UbUt}Arenicos' Mules")]
    public float st_ArenicosMules_p {
      get => _st_ArenicosMules_p;
      set {
        if (_st_ArenicosMules_p != value) {
          _st_ArenicosMules_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.ArenicosMules, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=dj7YQaTS}Trade penalty for pack animals are reduced by 20%.")]
    [SettingPropertyGroup("Perks/Steward/{=qBx8UbUt}Arenicos' Mules")]
    public float st_ArenicosMules_s {
      get => _st_ArenicosMules_s;
      set {
        if (_st_ArenicosMules_s != value) {
          _st_ArenicosMules_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.ArenicosMules, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=a7iyhqNR}10% increased carrying capacity for troops.")]
    [SettingPropertyGroup("Perks/Steward/{=tbQ5bUzD}Arenicos' Horses")]
    public float st_ArenicosHorses_p {
      get => _st_ArenicosHorses_p;
      set {
        if (_st_ArenicosHorses_p != value) {
          _st_ArenicosHorses_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.ArenicosHorses, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=akX6AdrL}Trade penalty for mounts are reduced by 20%.")]
    [SettingPropertyGroup("Perks/Steward/{=tbQ5bUzD}Arenicos' Horses")]
    public float st_ArenicosHorses_s {
      get => _st_ArenicosHorses_s;
      set {
        if (_st_ArenicosHorses_s != value) {
          _st_ArenicosHorses_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.ArenicosHorses, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=*}Reduce food consumption by 40% while in a siege camp.")]
    [SettingPropertyGroup("Perks/Steward/{=*}Master of Planning")]
    public float st_MasterOfPlanning_p {
      get => _st_MasterOfPlanning_p;
      set {
        if (_st_MasterOfPlanning_p != value) {
          _st_MasterOfPlanning_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.MasterOfPlanning, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=iS7GqDcg}Continuous projects for settlements are 20% more effective.")]
    [SettingPropertyGroup("Perks/Steward/{=*}Master of Planning")]
    public float st_MasterOfPlanning_s {
      get => _st_MasterOfPlanning_s;
      set {
        if (_st_MasterOfPlanning_s != value) {
          _st_MasterOfPlanning_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.MasterOfPlanning, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=noXFy09m}Troops wages are decreased by 25% while in a siege camp.")]
    [SettingPropertyGroup("Perks/Steward/{=MM0ARhGh}Master of Warcraft")]
    public float st_MasterOfWarcraft_p {
      get => _st_MasterOfWarcraft_p;
      set {
        if (_st_MasterOfWarcraft_p != value) {
          _st_MasterOfWarcraft_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Steward.MasterOfWarcraft, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=AajL4Oza}Town population consumes 5% less food.")]
    [SettingPropertyGroup("Perks/Steward/{=MM0ARhGh}Master of Warcraft")]
    public float st_MasterOfWarcraft_s {
      get => _st_MasterOfWarcraft_s;
      set {
        if (_st_MasterOfWarcraft_s != value) {
          _st_MasterOfWarcraft_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Steward.MasterOfWarcraft, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=t5UiDoaW}Increase character's healing rate by 30%.")]
    [SettingPropertyGroup("Perks/Medicine/{=TLGvIdJB}Self Medication")]
    public float med_SelfMedication_p {
      get => _med_SelfMedication_p;
      set {
        if (_med_SelfMedication_p != value) {
          _med_SelfMedication_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.SelfMedication, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=MmWzufrk}Increase character's movement speed by 2%.")]
    [SettingPropertyGroup("Perks/Medicine/{=TLGvIdJB}Self Medication")]
    public float med_SelfMedication_s {
      get => _med_SelfMedication_s;
      set {
        if (_med_SelfMedication_s != value) {
          _med_SelfMedication_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.SelfMedication, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HIVRbq8l}Increase character's hit points by 5.")]
    [SettingPropertyGroup("Perks/Medicine/{=wI393cla}Preventive Medicine")]
    public float med_PreventiveMedicine_p {
      get => _med_PreventiveMedicine_p;
      set {
        if (_med_PreventiveMedicine_p != value) {
          _med_PreventiveMedicine_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.PreventiveMedicine, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=qD6qbbvH}Character heals 30% of lost health points after each battle.")]
    [SettingPropertyGroup("Perks/Medicine/{=wI393cla}Preventive Medicine")]
    public float med_PreventiveMedicine_s {
      get => _med_PreventiveMedicine_s;
      set {
        if (_med_PreventiveMedicine_s != value) {
          _med_PreventiveMedicine_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.PreventiveMedicine, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=hbqab1rY}Increase heal rate by 30% when stationary in the world map.")]
    [SettingPropertyGroup("Perks/Medicine/{=EU4JjLqV}Triage Tent")]
    public float med_TriageTent_p {
      get => _med_TriageTent_p;
      set {
        if (_med_TriageTent_p != value) {
          _med_TriageTent_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.TriageTent, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=98giYyES}During sieges reduce settlement food consumption by 5%.")]
    [SettingPropertyGroup("Perks/Medicine/{=EU4JjLqV}Triage Tent")]
    public float med_TriageTent_s {
      get => _med_TriageTent_s;
      set {
        if (_med_TriageTent_s != value) {
          _med_TriageTent_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.TriageTent, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=BAGQhsQA}Increase heal rate by 15% when mobile in the world map.")]
    [SettingPropertyGroup("Perks/Medicine/{=0pyLfrGZ}Walk It Off")]
    public float med_WalkItOff_p {
      get => _med_WalkItOff_p;
      set {
        if (_med_WalkItOff_p != value) {
          _med_WalkItOff_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.WalkItOff, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=rfkrddb9}Recover 10 hp lost after each offensive battle.")]
    [SettingPropertyGroup("Perks/Medicine/{=0pyLfrGZ}Walk It Off")]
    public float med_WalkItOff_s {
      get => _med_WalkItOff_s;
      set {
        if (_med_WalkItOff_s != value) {
          _med_WalkItOff_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.WalkItOff, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=9jB3KdQC}Decrease wounded party speed penalty by 50%.")]
    [SettingPropertyGroup("Perks/Medicine/{=TyB6y5bh}Sledges")]
    public float med_Sledges_p {
      get => _med_Sledges_p;
      set {
        if (_med_Sledges_p != value) {
          _med_Sledges_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.Sledges, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=FMbQeBfN}Increase the health of every mount in your party by 15.")]
    [SettingPropertyGroup("Perks/Medicine/{=TyB6y5bh}Sledges")]
    public float med_Sledges_s {
      get => _med_Sledges_s;
      set {
        if (_med_Sledges_s != value) {
          _med_Sledges_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.Sledges, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=tzbXy8Nb}Medicine recovery chance applies to enemies too.")]
    [SettingPropertyGroup("Perks/Medicine/{=PAwDV08b}Doctors Oath")]
    public float med_DoctorsOath_p {
      get => _med_DoctorsOath_p;
      set {
        if (_med_DoctorsOath_p != value) {
          _med_DoctorsOath_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.DoctorsOath, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4pCODkNn}Increase your max health by 5.")]
    [SettingPropertyGroup("Perks/Medicine/{=PAwDV08b}Doctors Oath")]
    public float med_DoctorsOath_s {
      get => _med_DoctorsOath_s;
      set {
        if (_med_DoctorsOath_s != value) {
          _med_DoctorsOath_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.DoctorsOath, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Di2Qbaae}High morale increases the healing rate by 15%.")]
    [SettingPropertyGroup("Perks/Medicine/{=ei1JSeco}Best Medicine")]
    public float med_BestMedicine_p {
      get => _med_BestMedicine_p;
      set {
        if (_med_BestMedicine_p != value) {
          _med_BestMedicine_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.BestMedicine, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=336rXArq}Increase relationship by 1 with a random notable over age 50 while in a town.")]
    [SettingPropertyGroup("Perks/Medicine/{=ei1JSeco}Best Medicine")]
    public float med_BestMedicine_s {
      get => _med_BestMedicine_s;
      set {
        if (_med_BestMedicine_s != value) {
          _med_BestMedicine_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.BestMedicine, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=nkmoAaI7}Resting in settlements increase heal rate by 20%.")]
    [SettingPropertyGroup("Perks/Medicine/{=RXo3edjn}Good Lodging")]
    public float med_GoodLogdings_p {
      get => _med_GoodLogdings_p;
      set {
        if (_med_GoodLogdings_p != value) {
          _med_GoodLogdings_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.GoodLogdings, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=aoKJbxi8}Increase relationship by 1 with a random noble over age 50 while in a town.")]
    [SettingPropertyGroup("Perks/Medicine/{=RXo3edjn}Good Lodging")]
    public float med_GoodLogdings_s {
      get => _med_GoodLogdings_s;
      set {
        if (_med_GoodLogdings_s != value) {
          _med_GoodLogdings_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.GoodLogdings, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=REFJzAAt}Losses to siege bombardment has a 50% chance of getting wounded instead of getting killed.")]
    [SettingPropertyGroup("Perks/Medicine/{=ObwbbEqE}Siege Medic")]
    public float med_SiegeMedic_p {
      get => _med_SiegeMedic_p;
      set {
        if (_med_SiegeMedic_p != value) {
          _med_SiegeMedic_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.SiegeMedic, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=BZIKo5Qd}30% increased chance to recover lethal wounds in siege assaults.")]
    [SettingPropertyGroup("Perks/Medicine/{=ObwbbEqE}Siege Medic")]
    public float med_SiegeMedic_s {
      get => _med_SiegeMedic_s;
      set {
        if (_med_SiegeMedic_s != value) {
          _med_SiegeMedic_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.SiegeMedic, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=TPMrjd5m}30% chance per day to recover a lame horse.")]
    [SettingPropertyGroup("Perks/Medicine/{=DNPbZZPQ}Veterinarian")]
    public float med_Veterinarian_p {
      get => _med_Veterinarian_p;
      set {
        if (_med_Veterinarian_p != value) {
          _med_Veterinarian_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.Veterinarian, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=p71X2Z5d}50% chance to recover a mount from lost cavalry after battles.")]
    [SettingPropertyGroup("Perks/Medicine/{=DNPbZZPQ}Veterinarian")]
    public float med_Veterinarian_s {
      get => _med_Veterinarian_s;
      set {
        if (_med_Veterinarian_s != value) {
          _med_Veterinarian_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.Veterinarian, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dhbkT2Il}Increase settlement prosperity by +1 everyday.")]
    [SettingPropertyGroup("Perks/Medicine/{=72tbUfrz}Pristine Streets")]
    public float med_PristineStreets_p {
      get => _med_PristineStreets_p;
      set {
        if (_med_PristineStreets_p != value) {
          _med_PristineStreets_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.PristineStreets, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=eNUtOIr5}Get 20% healing bonus in towns.")]
    [SettingPropertyGroup("Perks/Medicine/{=72tbUfrz}Pristine Streets")]
    public float med_PristineStreets_s {
      get => _med_PristineStreets_s;
      set {
        if (_med_PristineStreets_s != value) {
          _med_PristineStreets_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.PristineStreets, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=QWDAY3OJ}Increase village hearth growth rate by 20%.")]
    [SettingPropertyGroup("Perks/Medicine/{=HGrsb7k2}Bush Doctor")]
    public float med_BushDoctor_p {
      get => _med_BushDoctor_p;
      set {
        if (_med_BushDoctor_p != value) {
          _med_BushDoctor_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.BushDoctor, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=L53ABEua}Get 20% healing bonus in villages.")]
    [SettingPropertyGroup("Perks/Medicine/{=HGrsb7k2}Bush Doctor")]
    public float med_BushDoctor_s {
      get => _med_BushDoctor_s;
      set {
        if (_med_BushDoctor_s != value) {
          _med_BushDoctor_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.BushDoctor, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=onhUqzD6}Food variety increase recovery rate by 5% for each point.")]
    [SettingPropertyGroup("Perks/Medicine/{=cGuPMx4p}Perfect Health")]
    public float med_PerfectHealth_p {
      get => _med_PerfectHealth_p;
      set {
        if (_med_PerfectHealth_p != value) {
          _med_PerfectHealth_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.PerfectHealth, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=DsbtHShA}Increase animal production in governed villages by 10%.")]
    [SettingPropertyGroup("Perks/Medicine/{=cGuPMx4p}Perfect Health")]
    public float med_PerfectHealth_s {
      get => _med_PerfectHealth_s;
      set {
        if (_med_PerfectHealth_s != value) {
          _med_PerfectHealth_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.PerfectHealth, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=B8iqnA9N}Small increase to clan life expentancy.")]
    [SettingPropertyGroup("Perks/Medicine/{=NxcvQlAk}Health Advice")]
    public float med_HealthAdvise_p {
      get => _med_HealthAdvise_p;
      set {
        if (_med_HealthAdvise_p != value) {
          _med_HealthAdvise_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.HealthAdvise, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 99999.000000f, RequireRestart=false, HintText="{=ioYR1Grc}Wounded troops do not decrease morale in battles.")]
    [SettingPropertyGroup("Perks/Medicine/{=NxcvQlAk}Health Advice")]
    public float med_HealthAdvise_s {
      get => _med_HealthAdvise_s;
      set {
        if (_med_HealthAdvise_s != value) {
          _med_HealthAdvise_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.HealthAdvise, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=xpRKA34Q}Increases loyalty of settlement by 1 per day.")]
    [SettingPropertyGroup("Perks/Medicine/{=5o6pSbCx}Physician of People")]
    public float med_PhysicianOfPeople_p {
      get => _med_PhysicianOfPeople_p;
      set {
        if (_med_PhysicianOfPeople_p != value) {
          _med_PhysicianOfPeople_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.PhysicianOfPeople, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=D5JUgcyl}Tier 1 and tier 2 troops have 30% higher chance to recover from fatal wounds.")]
    [SettingPropertyGroup("Perks/Medicine/{=5o6pSbCx}Physician of People")]
    public float med_PhysicianOfPeople_s {
      get => _med_PhysicianOfPeople_s;
      set {
        if (_med_PhysicianOfPeople_s != value) {
          _med_PhysicianOfPeople_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.PhysicianOfPeople, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=V4bgbS26}Town projects that is related with sanitation and health(e.g aquaduct/market place/granary) also give bonus prosperity increase.")]
    [SettingPropertyGroup("Perks/Medicine/{=CZ4y5NAf}Clean Infrastructure")]
    public float med_CleanInfrastructure_p {
      get => _med_CleanInfrastructure_p;
      set {
        if (_med_CleanInfrastructure_p != value) {
          _med_CleanInfrastructure_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.CleanInfrastructure, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=EZR23u6f}Recover governed villages 30% faster.")]
    [SettingPropertyGroup("Perks/Medicine/{=CZ4y5NAf}Clean Infrastructure")]
    public float med_CleanInfrastructure_s {
      get => _med_CleanInfrastructure_s;
      set {
        if (_med_CleanInfrastructure_s != value) {
          _med_CleanInfrastructure_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.CleanInfrastructure, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=HVHEhXbO}Ignore the first negative outcome for the terminally ill roll.")]
    [SettingPropertyGroup("Perks/Medicine/{=cpg0oHZJ}Cheat Death")]
    public float med_CheatDeath_p {
      get => _med_CheatDeath_p;
      set {
        if (_med_CheatDeath_p != value) {
          _med_CheatDeath_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.CheatDeath, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=Wrqb3iXP}Hero death chance in battle is 50% less.")]
    [SettingPropertyGroup("Perks/Medicine/{=cpg0oHZJ}Cheat Death")]
    public float med_CheatDeath_s {
      get => _med_CheatDeath_s;
      set {
        if (_med_CheatDeath_s != value) {
          _med_CheatDeath_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.CheatDeath, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=Sb6BW3GF}Increase max health of other heroes in your party by +10.")]
    [SettingPropertyGroup("Perks/Medicine/{=ib2SMG9b}Fortitude Tonic")]
    public float med_FortitudeTonic_p {
      get => _med_FortitudeTonic_p;
      set {
        if (_med_FortitudeTonic_p != value) {
          _med_FortitudeTonic_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.FortitudeTonic, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=4pCODkNn}Increase your max health by 5.")]
    [SettingPropertyGroup("Perks/Medicine/{=ib2SMG9b}Fortitude Tonic")]
    public float med_FortitudeTonic_s {
      get => _med_FortitudeTonic_s;
      set {
        if (_med_FortitudeTonic_s != value) {
          _med_FortitudeTonic_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.FortitudeTonic, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=EJyQ186a}Every 10 troop in your party increase troop recovery rate by 2%.")]
    [SettingPropertyGroup("Perks/Medicine/{=KavZKNaa}Helping Hands")]
    public float med_HelpingHands_p {
      get => _med_HelpingHands_p;
      set {
        if (_med_HelpingHands_p != value) {
          _med_HelpingHands_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.HelpingHands, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -100.000000f, 0.000000f, RequireRestart=false, HintText="{=PQOElTav}50% less prosperity loss from starvation.")]
    [SettingPropertyGroup("Perks/Medicine/{=KavZKNaa}Helping Hands")]
    public float med_HelpingHands_s {
      get => _med_HelpingHands_s;
      set {
        if (_med_HelpingHands_s != value) {
          _med_HelpingHands_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.HelpingHands, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=GUr0jxSv}Wounded units gain +25 xp at the end of the battle.")]
    [SettingPropertyGroup("Perks/Medicine/{=oSbRD72H}Battle Hardened")]
    public float med_BattleHardened_p {
      get => _med_BattleHardened_p;
      set {
        if (_med_BattleHardened_p != value) {
          _med_BattleHardened_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Medicine.BattleHardened, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=*}Siege attrition loss chance is reduced by 25%.")]
    [SettingPropertyGroup("Perks/Medicine/{=oSbRD72H}Battle Hardened")]
    public float med_BattleHardened_s {
      get => _med_BattleHardened_s;
      set {
        if (_med_BattleHardened_s != value) {
          _med_BattleHardened_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Medicine.BattleHardened, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=xIDEjHyf}Non-ranged siege engine build speed increased by 10%.")]
    [SettingPropertyGroup("Perks/Engineering/{=ekavTnTp}Scaffolds")]
    public float eng_Scaffolds_p {
      get => _eng_Scaffolds_p;
      set {
        if (_eng_Scaffolds_p != value) {
          _eng_Scaffolds_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Scaffolds, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=7vZcwCqA}Increase equipped shield hitpoints by 30%.")]
    [SettingPropertyGroup("Perks/Engineering/{=ekavTnTp}Scaffolds")]
    public float eng_Scaffolds_s {
      get => _eng_Scaffolds_s;
      set {
        if (_eng_Scaffolds_s != value) {
          _eng_Scaffolds_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.Scaffolds, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=4V3sK20q}Ranged siege engine build speed increased by 10%.")]
    [SettingPropertyGroup("Perks/Engineering/{=57TDG2Ta}Torsion Engines")]
    public float eng_TorsionEngines_p {
      get => _eng_TorsionEngines_p;
      set {
        if (_eng_TorsionEngines_p != value) {
          _eng_TorsionEngines_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.TorsionEngines, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=tw5y78XY}Increase equipped crossbow damage by 3.")]
    [SettingPropertyGroup("Perks/Engineering/{=57TDG2Ta}Torsion Engines")]
    public float eng_TorsionEngines_s {
      get => _eng_TorsionEngines_s;
      set {
        if (_eng_TorsionEngines_s != value) {
          _eng_TorsionEngines_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.TorsionEngines, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=hC47p0t2}Ranged siege engines have 10% more hit points (In mission as well).")]
    [SettingPropertyGroup("Perks/Engineering/{=Nr1GPYSr}Siegeworks")]
    public float eng_SiegeWorks_p {
      get => _eng_SiegeWorks_p;
      set {
        if (_eng_SiegeWorks_p != value) {
          _eng_SiegeWorks_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.SiegeWorks, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=9arDDOOK}Settlement provides +1 extra catapult at the beginning of the siege.")]
    [SettingPropertyGroup("Perks/Engineering/{=Nr1GPYSr}Siegeworks")]
    public float eng_SiegeWorks_s {
      get => _eng_SiegeWorks_s;
      set {
        if (_eng_SiegeWorks_s != value) {
          _eng_SiegeWorks_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.SiegeWorks, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=F58CwbzF}Ranged siege engines are 25% less likely to be hit while bombarding settlements.")]
    [SettingPropertyGroup("Perks/Engineering/{=aPbpBJq5}Prison Architect")]
    public float eng_PrisonArchitect_p {
      get => _eng_PrisonArchitect_p;
      set {
        if (_eng_PrisonArchitect_p != value) {
          _eng_PrisonArchitect_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.PrisonArchitect, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=gkAHdFul}Prisoner escape chance from dungeons are decreased by 25%.")]
    [SettingPropertyGroup("Perks/Engineering/{=aPbpBJq5}Prison Architect")]
    public float eng_PrisonArchitect_s {
      get => _eng_PrisonArchitect_s;
      set {
        if (_eng_PrisonArchitect_s != value) {
          _eng_PrisonArchitect_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.PrisonArchitect, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=A16GZubg}Rams and siege-towers have 33% more hitpoints.")]
    [SettingPropertyGroup("Perks/Engineering/{=YwhAlz5n}Carpenters")]
    public float eng_Carpenters_p {
      get => _eng_Carpenters_p;
      set {
        if (_eng_Carpenters_p != value) {
          _eng_Carpenters_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Carpenters, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=FbzyR6hL}12% increased build speed for town projects.")]
    [SettingPropertyGroup("Perks/Engineering/{=YwhAlz5n}Carpenters")]
    public float eng_Carpenters_s {
      get => _eng_Carpenters_s;
      set {
        if (_eng_Carpenters_s != value) {
          _eng_Carpenters_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.Carpenters, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=r4uMbbKN}Ranged troops have 50% more ammunition when besieging.")]
    [SettingPropertyGroup("Perks/Engineering/{=mzDsT7lV}Military Planner")]
    public float eng_MilitaryPlanner_p {
      get => _eng_MilitaryPlanner_p;
      set {
        if (_eng_MilitaryPlanner_p != value) {
          _eng_MilitaryPlanner_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.MilitaryPlanner, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=IJof7vUp}25% increased build speed for castle projects.")]
    [SettingPropertyGroup("Perks/Engineering/{=mzDsT7lV}Military Planner")]
    public float eng_MilitaryPlanner_s {
      get => _eng_MilitaryPlanner_s;
      set {
        if (_eng_MilitaryPlanner_s != value) {
          _eng_MilitaryPlanner_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.MilitaryPlanner, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=bUNitf5F}Damage to walls increased by 25% during siege.")]
    [SettingPropertyGroup("Perks/Engineering/{=0wlWgIeL}Wall Breaker")]
    public float eng_WallBreaker_p {
      get => _eng_WallBreaker_p;
      set {
        if (_eng_WallBreaker_p != value) {
          _eng_WallBreaker_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.WallBreaker, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=dFLbbXDm}Your troops deal 10% more damage to shields.")]
    [SettingPropertyGroup("Perks/Engineering/{=0wlWgIeL}Wall Breaker")]
    public float eng_WallBreaker_s {
      get => _eng_WallBreaker_s;
      set {
        if (_eng_WallBreaker_s != value) {
          _eng_WallBreaker_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.WallBreaker, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=13GCPNo5}Increased hit chance to siege engines by 10% during campaign siege.")]
    [SettingPropertyGroup("Perks/Engineering/{=bIS4kqmf}Dreadful Besieger")]
    public float eng_DreadfulSieger_p {
      get => _eng_DreadfulSieger_p;
      set {
        if (_eng_DreadfulSieger_p != value) {
          _eng_DreadfulSieger_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.DreadfulSieger, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=uM4i676z}Your troops deal 5% increased damage with crossbows.")]
    [SettingPropertyGroup("Perks/Engineering/{=bIS4kqmf}Dreadful Besieger")]
    public float eng_DreadfulSieger_s {
      get => _eng_DreadfulSieger_s;
      set {
        if (_eng_DreadfulSieger_s != value) {
          _eng_DreadfulSieger_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.DreadfulSieger, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=BWdrwU59}Increase campaign map ballista accuracy by 20%.")]
    [SettingPropertyGroup("Perks/Engineering/{=AgJAfEEZ}Salvager")]
    public float eng_Salvager_p {
      get => _eng_Salvager_p;
      set {
        if (_eng_Salvager_p != value) {
          _eng_Salvager_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Salvager, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=lLaIzlr4}Increase campaign map mangonel and trebuchet accuracy by 10%.")]
    [SettingPropertyGroup("Perks/Engineering/{=3ML4EkWY}Foreman")]
    public float eng_Foreman_p {
      get => _eng_Foreman_p;
      set {
        if (_eng_Foreman_p != value) {
          _eng_Foreman_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Foreman, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=W6ajyrga}Everytime a project is finished increase prosperity by 100.")]
    [SettingPropertyGroup("Perks/Engineering/{=3ML4EkWY}Foreman")]
    public float eng_Foreman_s {
      get => _eng_Foreman_s;
      set {
        if (_eng_Foreman_s != value) {
          _eng_Foreman_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.Foreman, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=eCkC7Grp}Defensive siege engines have 30% more hit points.")]
    [SettingPropertyGroup("Perks/Engineering/{=pFGhJxyN}Siege Engineer")]
    public float eng_SiegeEngineer_p {
      get => _eng_SiegeEngineer_p;
      set {
        if (_eng_SiegeEngineer_p != value) {
          _eng_SiegeEngineer_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.SiegeEngineer, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=sTCBMmGl}Can craft Fire versions of siege engines.")]
    [SettingPropertyGroup("Perks/Engineering/{=pFGhJxyN}Siege Engineer")]
    public float eng_SiegeEngineer_s {
      get => _eng_SiegeEngineer_s;
      set {
        if (_eng_SiegeEngineer_s != value) {
          _eng_SiegeEngineer_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.SiegeEngineer, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=*}Start siege camps with +1 pre-built ballista.")]
    [SettingPropertyGroup("Perks/Engineering/{=hHHEW1HN}Battlements")]
    public float eng_Battlements_p {
      get => _eng_Battlements_p;
      set {
        if (_eng_Battlements_p != value) {
          _eng_Battlements_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Battlements, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=WBCt4M0J}Increase max granary food storage capacity by 100.")]
    [SettingPropertyGroup("Perks/Engineering/{=hHHEW1HN}Battlements")]
    public float eng_Battlements_s {
      get => _eng_Battlements_s;
      set {
        if (_eng_Battlements_s != value) {
          _eng_Battlements_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.Battlements, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=YkAV0SgY}Increase recuitment slot by 1 when recuiting from artisan notables.")]
    [SettingPropertyGroup("Perks/Engineering/{=elKQc0O6}Engineering Guilds")]
    public float eng_EngineeringGuilds_p {
      get => _eng_EngineeringGuilds_p;
      set {
        if (_eng_EngineeringGuilds_p != value) {
          _eng_EngineeringGuilds_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.EngineeringGuilds, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=rkKMB9qK}Wall hit points are increased by 25%.")]
    [SettingPropertyGroup("Perks/Engineering/{=elKQc0O6}Engineering Guilds")]
    public float eng_EngineeringGuilds_s {
      get => _eng_EngineeringGuilds_s;
      set {
        if (_eng_EngineeringGuilds_s != value) {
          _eng_EngineeringGuilds_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.EngineeringGuilds, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=*}Looted items are very unlikely to get negative modifiers.")]
    [SettingPropertyGroup("Perks/Engineering/{=qjvDsu8u}Metallurgy")]
    public float eng_Metallurgy_p {
      get => _eng_Metallurgy_p;
      set {
        if (_eng_Metallurgy_p != value) {
          _eng_Metallurgy_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Metallurgy, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=eSNa0skd}Troops under the formation you control have their armor values increased by 5.")]
    [SettingPropertyGroup("Perks/Engineering/{=qjvDsu8u}Metallurgy")]
    public float eng_Metallurgy_s {
      get => _eng_Metallurgy_s;
      set {
        if (_eng_Metallurgy_s != value) {
          _eng_Metallurgy_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.Metallurgy, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=ta2z0bEv}Camp preparation is 20% faster.")]
    [SettingPropertyGroup("Perks/Engineering/{=XixNAaD5}Improved Tools")]
    public float eng_ImprovedTools_p {
      get => _eng_ImprovedTools_p;
      set {
        if (_eng_ImprovedTools_p != value) {
          _eng_ImprovedTools_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.ImprovedTools, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=N9lA0KwA}Troops under the formation you control deal 5% more melee damage.")]
    [SettingPropertyGroup("Perks/Engineering/{=XixNAaD5}Improved Tools")]
    public float eng_ImprovedTools_s {
      get => _eng_ImprovedTools_s;
      set {
        if (_eng_ImprovedTools_s != value) {
          _eng_ImprovedTools_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.ImprovedTools, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=2eBBY7nG}Ballista in siege bombardment reload 25% faster.")]
    [SettingPropertyGroup("Perks/Engineering/{=Z9Rey6LC}Clockwork")]
    public float eng_Clockwork_p {
      get => _eng_Clockwork_p;
      set {
        if (_eng_Clockwork_p != value) {
          _eng_Clockwork_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.Clockwork, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 1.000000f, RequireRestart=false, HintText="{=Q51nMDju}Gold boosts for town projects are 20% more effective.")]
    [SettingPropertyGroup("Perks/Engineering/{=Z9Rey6LC}Clockwork")]
    public float eng_Clockwork_s {
      get => _eng_Clockwork_s;
      set {
        if (_eng_Clockwork_s != value) {
          _eng_Clockwork_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.Clockwork, value);
        }
      }
    }


    [SettingPropertyFloatingInteger("Primary Bonus", -1.000000f, 0.000000f, RequireRestart=false, HintText="{=cOS8cdib}Mangonels and trebuchets in siege bombardment reload 25% faster.")]
    [SettingPropertyGroup("Perks/Engineering/{=KODafKT7}Architectural Commissions")]
    public float eng_ArchitecturalCommisions_p {
      get => _eng_ArchitecturalCommisions_p;
      set {
        if (_eng_ArchitecturalCommisions_p != value) {
          _eng_ArchitecturalCommisions_p = value;
          if (Game.Current != null)
            ExposeInternals.SetPrimaryBonus(DefaultPerks.Engineering.ArchitecturalCommisions, value);
        }
      }
    }
    [SettingPropertyFloatingInteger("Secondary Bonus", 0.000000f, 100.000000f, RequireRestart=false, HintText="{=6nSusCkE}Continuous projects provides 20 gold per day.")]
    [SettingPropertyGroup("Perks/Engineering/{=KODafKT7}Architectural Commissions")]
    public float eng_ArchitecturalCommisions_s {
      get => _eng_ArchitecturalCommisions_s;
      set {
        if (_eng_ArchitecturalCommisions_s != value) {
          _eng_ArchitecturalCommisions_s = value;
          if (Game.Current != null)
            ExposeInternals.SetSecondaryBonus(DefaultPerks.Engineering.ArchitecturalCommisions, value);
        }
      }
    }

    public void SetAll(ref DefaultPerks perk) {
      ref PerkObject _oneHandedDeflect = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedDeflect");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedDeflect,_oh_Deflect_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedDeflect,_oh_Deflect_s);
      ref PerkObject _oneHandedBasher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedBasher");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedBasher,_oh_Basher_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedBasher,_oh_Basher_s);
      ref PerkObject _oneHandedToBeBlunt = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedToBeBlunt");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedToBeBlunt,_oh_ToBeBlunt_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedToBeBlunt,_oh_ToBeBlunt_s);
      ref PerkObject _oneHandedSwiftStrike = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedSwiftStrike");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedSwiftStrike,_oh_SwiftStrike_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedSwiftStrike,_oh_SwiftStrike_s);
      ref PerkObject _oneHandedCavalry = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedCavalry");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedCavalry,_oh_Cavalry_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedCavalry,_oh_Cavalry_s);
      ref PerkObject _oneHandedShieldBearer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedShieldBearer");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedShieldBearer,_oh_ShieldBearer_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedShieldBearer,_oh_ShieldBearer_s);
      ref PerkObject _oneHandedTrainer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedTrainer");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedTrainer,_oh_Trainer_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedTrainer,_oh_Trainer_s);
      ref PerkObject _oneHandedDuelist = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedDuelist");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedDuelist,_oh_Duelist_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedDuelist,_oh_Duelist_s);
      ref PerkObject _oneHandedShieldWall = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedShieldWall");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedShieldWall,_oh_ShieldWall_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedShieldWall,_oh_ShieldWall_s);
      ref PerkObject _oneHandedArrowCatcher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedArrowCatcher");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedArrowCatcher,_oh_ArrowCatcher_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedArrowCatcher,_oh_ArrowCatcher_s);
      ref PerkObject _oneHandedMilitaryTradition = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedMilitaryTradition");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedMilitaryTradition,_oh_MilitaryTradition_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedMilitaryTradition,_oh_MilitaryTradition_s);
      ref PerkObject _oneHandedCorpsACorps = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedCorpsACorps");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedCorpsACorps,_oh_CorpsACorps_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedCorpsACorps,_oh_CorpsACorps_s);
      ref PerkObject _oneHandedStandUnited = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedStandUnited");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedStandUnited,_oh_StandUnited_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedStandUnited,_oh_StandUnited_s);
      ref PerkObject _oneHandedLeadByExample = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedLeadByExample");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedLeadByExample,_oh_LeadByExample_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedLeadByExample,_oh_LeadByExample_s);
      ref PerkObject _oneHandedSteelCoreShields = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedSteelCoreShields");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedSteelCoreShields,_oh_SteelCoreShields_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedSteelCoreShields,_oh_SteelCoreShields_s);
      ref PerkObject _oneHandedFleetOfFoot = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedFleetOfFoot");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedFleetOfFoot,_oh_FleetOfFoot_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedFleetOfFoot,_oh_FleetOfFoot_s);
      ref PerkObject _oneHandedDeadlyPurpose = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedDeadlyPurpose");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedDeadlyPurpose,_oh_DeadlyPurpose_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedDeadlyPurpose,_oh_DeadlyPurpose_s);
      ref PerkObject _oneHandedUnwaveringDefense = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedUnwaveringDefense");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedUnwaveringDefense,_oh_UnwaveringDefense_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedUnwaveringDefense,_oh_UnwaveringDefense_s);
      ref PerkObject _oneHandedPrestige = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedPrestige");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedPrestige,_oh_Prestige_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedPrestige,_oh_Prestige_s);
      ref PerkObject _oneHandedChinkInTheArmor = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedChinkInTheArmor");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedChinkInTheArmor,_oh_ChinkInTheArmor_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedChinkInTheArmor,_oh_ChinkInTheArmor_s);
      ref PerkObject _oneHandedWayOfTheSword = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_oneHandedWayOfTheSword");
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_oneHandedWayOfTheSword,_oh_WayOfTheSword_p);
      if (OneHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_oneHandedWayOfTheSword,_oh_WayOfTheSword_s);
      ref PerkObject _twoHandedStrongGrip = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedStrongGrip");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedStrongGrip,_twh_StrongGrip_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedStrongGrip,_twh_StrongGrip_s);
      ref PerkObject _twoHandedWoodChopper = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedWoodChopper");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedWoodChopper,_twh_WoodChopper_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedWoodChopper,_twh_WoodChopper_s);
      ref PerkObject _twoHandedOnTheEdge = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedOnTheEdge");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedOnTheEdge,_twh_OnTheEdge_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedOnTheEdge,_twh_OnTheEdge_s);
      ref PerkObject _twoHandedHeadBasher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedHeadBasher");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedHeadBasher,_twh_HeadBasher_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedHeadBasher,_twh_HeadBasher_s);
      ref PerkObject _twoHandedShowOfStrength = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedShowOfStrength");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedShowOfStrength,_twh_ShowOfStrength_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedShowOfStrength,_twh_ShowOfStrength_s);
      ref PerkObject _twoHandedBaptisedInBlood = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedBaptisedInBlood");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedBaptisedInBlood,_twh_BaptisedInBlood_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedBaptisedInBlood,_twh_BaptisedInBlood_s);
      ref PerkObject _twoHandedBeastSlayer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedBeastSlayer");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedBeastSlayer,_twh_BeastSlayer_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedBeastSlayer,_twh_BeastSlayer_s);
      ref PerkObject _twoHandedShieldBreaker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedShieldBreaker");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedShieldBreaker,_twh_ShieldBreaker_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedShieldBreaker,_twh_ShieldBreaker_s);
      ref PerkObject _twoHandedBerserker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedBerserker");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedBerserker,_twh_Berserker_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedBerserker,_twh_Berserker_s);
      ref PerkObject _twoHandedConfidence = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedConfidence");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedConfidence,_twh_Confidence_p);
      ref PerkObject _twoHandedArrowDeflection = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedArrowDeflection");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedArrowDeflection,_twh_ArrowDeflection_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedArrowDeflection,_twh_ArrowDeflection_s);
      ref PerkObject _twoHandedTerror = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedTerror");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedTerror,_twh_Terror_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedTerror,_twh_Terror_s);
      ref PerkObject _twoHandedHope = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedHope");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedHope,_twh_Hope_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedHope,_twh_Hope_s);
      ref PerkObject _twoHandedRecklessCharge = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedRecklessCharge");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedRecklessCharge,_twh_RecklessCharge_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedRecklessCharge,_twh_RecklessCharge_s);
      ref PerkObject _twoHandedThickHides = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedThickHides");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedThickHides,_twh_ThickHides_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedThickHides,_twh_ThickHides_s);
      ref PerkObject _twoHandedBladeMaster = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedBladeMaster");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedBladeMaster,_twh_BladeMaster_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedBladeMaster,_twh_BladeMaster_s);
      ref PerkObject _twoHandedVandal = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedVandal");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedVandal,_twh_Vandal_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedVandal,_twh_Vandal_s);
      ref PerkObject _twoHandedWayOfTheGreatAxe = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_twoHandedWayOfTheGreatAxe");
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_twoHandedWayOfTheGreatAxe,_twh_WayOfTheGreatAxe_p);
      if (TwoHandedPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_twoHandedWayOfTheGreatAxe,_twh_WayOfTheGreatAxe_s);
      ref PerkObject _polearmPikeman = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmPikeman");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmPikeman,_plm_Pikeman_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmPikeman,_plm_Pikeman_s);
      ref PerkObject _polearmCavalry = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmCavalry");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmCavalry,_plm_Cavalry_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmCavalry,_plm_Cavalry_s);
      ref PerkObject _polearmBraced = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmBraced");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmBraced,_plm_Braced_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmBraced,_plm_Braced_s);
      ref PerkObject _polearmKeepAtBay = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmKeepAtBay");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmKeepAtBay,_plm_KeepAtBay_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmKeepAtBay,_plm_KeepAtBay_s);
      ref PerkObject _polearmSwiftSwing = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmSwiftSwing");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmSwiftSwing,_plm_SwiftSwing_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmSwiftSwing,_plm_SwiftSwing_s);
      ref PerkObject _polearmCleanThrust = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmCleanThrust");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmCleanThrust,_plm_CleanThrust_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmCleanThrust,_plm_CleanThrust_s);
      ref PerkObject _polearmFootwork = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmFootwork");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmFootwork,_plm_Footwork_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmFootwork,_plm_Footwork_s);
      ref PerkObject _polearmHardKnock = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmHardKnock");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmHardKnock,_plm_HardKnock_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmHardKnock,_plm_HardKnock_s);
      ref PerkObject _polearmSteedKiller = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmSteedKiller");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmSteedKiller,_plm_SteedKiller_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmSteedKiller,_plm_SteedKiller_s);
      ref PerkObject _polearmLancer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmLancer");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmLancer,_plm_Lancer_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmLancer,_plm_Lancer_s);
      ref PerkObject _polearmSkewer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmSkewer");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmSkewer,_plm_Skewer_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmSkewer,_plm_Skewer_s);
      ref PerkObject _polearmGuards = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmGuards");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmGuards,_plm_Guards_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmGuards,_plm_Guards_s);
      ref PerkObject _polearmStandardBearer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmStandardBearer");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmStandardBearer,_plm_StandardBearer_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmStandardBearer,_plm_StandardBearer_s);
      ref PerkObject _polearmPhalanx = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmPhalanx");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmPhalanx,_plm_Phalanx_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmPhalanx,_plm_Phalanx_s);
      ref PerkObject _polearmGenerousRations = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmGenerousRations");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmGenerousRations,_plm_GenerousRations_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmGenerousRations,_plm_GenerousRations_s);
      ref PerkObject _polearmDrills = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmDrills");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmDrills,_plm_Drills_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmDrills,_plm_Drills_s);
      ref PerkObject _polearmSureFooted = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmSureFooted");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmSureFooted,_plm_SureFooted_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmSureFooted,_plm_SureFooted_s);
      ref PerkObject _polearmUnstoppableForce = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmUnstoppableForce");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmUnstoppableForce,_plm_UnstoppableForce_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmUnstoppableForce,_plm_UnstoppableForce_s);
      ref PerkObject _polearmCounterweight = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmCounterweight");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmCounterweight,_plm_CounterWeight_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmCounterweight,_plm_CounterWeight_s);
      ref PerkObject _polearmSharpenTheTip = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmSharpenTheTip");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmSharpenTheTip,_plm_SharpenTheTip_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmSharpenTheTip,_plm_SharpenTheTip_s);
      ref PerkObject _polearmWayOfTheSpear = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_polearmWayOfTheSpear");
      if (PolearmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_polearmWayOfTheSpear,_plm_WayOfTheSpear_p);
      if (PolearmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_polearmWayOfTheSpear,_plm_WayOfTheSpear_s);
      ref PerkObject _bowBowControl = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowBowControl");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowBowControl,_bow_BowControl_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowBowControl,_bow_BowControl_s);
      ref PerkObject _bowDeadAim = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowDeadAim");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowDeadAim,_bow_DeadAim_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowDeadAim,_bow_DeadAim_s);
      ref PerkObject _bowBodkin = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowBodkin");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowBodkin,_bow_Bodkin_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowBodkin,_bow_Bodkin_s);
      ref PerkObject _bowRangersSwiftness = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowRangersSwiftness");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowRangersSwiftness,_bow_RangersSwiftness_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowRangersSwiftness,_bow_RangersSwiftness_s);
      ref PerkObject _bowRapidFire = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowRapidFire");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowRapidFire,_bow_RapidFire_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowRapidFire,_bow_RapidFire_s);
      ref PerkObject _bowQuickAdjustments = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowQuickAdjustments");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowQuickAdjustments,_bow_QuickAdjustments_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowQuickAdjustments,_bow_QuickAdjustments_s);
      ref PerkObject _bowMerryMen = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowMerryMen");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowMerryMen,_bow_MerryMen_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowMerryMen,_bow_MerryMen_s);
      ref PerkObject _bowMountedArchery = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowMountedArchery");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowMountedArchery,_bow_MountedArchery_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowMountedArchery,_bow_MountedArchery_s);
      ref PerkObject _bowTrainer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowTrainer");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowTrainer,_bow_Trainer_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowTrainer,_bow_Trainer_s);
      ref PerkObject _bowStrongBows = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowStrongBows");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowStrongBows,_bow_StrongBows_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowStrongBows,_bow_StrongBows_s);
      ref PerkObject _bowDiscipline = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowDiscipline");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowDiscipline,_bow_Discipline_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowDiscipline,_bow_Discipline_s);
      ref PerkObject _bowHunterClan = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowHunterClan");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowHunterClan,_bow_HunterClan_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowHunterClan,_bow_HunterClan_s);
      ref PerkObject _bowSkirmishPhaseMaster = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowSkirmishPhaseMaster");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowSkirmishPhaseMaster,_bow_SkirmishPhaseMaster_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowSkirmishPhaseMaster,_bow_SkirmishPhaseMaster_s);
      ref PerkObject _bowEagleEye = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowEagleEye");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowEagleEye,_bow_EagleEye_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowEagleEye,_bow_EagleEye_s);
      ref PerkObject _bowBullsEye = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowBullsEye");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowBullsEye,_bow_BullsEye_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowBullsEye,_bow_BullsEye_s);
      ref PerkObject _bowRenownedArcher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowRenownedArcher");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowRenownedArcher,_bow_RenownedArcher_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowRenownedArcher,_bow_RenownedArcher_s);
      ref PerkObject _bowHorseMaster = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowHorseMaster");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowHorseMaster,_bow_HorseMaster_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowHorseMaster,_bow_HorseMaster_s);
      ref PerkObject _bowDeepQuivers = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowDeepQuivers");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowDeepQuivers,_bow_DeepQuivers_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowDeepQuivers,_bow_DeepQuivers_s);
      ref PerkObject _bowQuickDraw = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowQuickDraw");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowQuickDraw,_bow_QuickDraw_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowQuickDraw,_bow_QuickDraw_s);
      ref PerkObject _bowSalvo = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowSalvo");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowSalvo,_bow_Salvo_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowSalvo,_bow_Salvo_s);
      ref PerkObject _bowDeadshot = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_bowDeadshot");
      if (BowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_bowDeadshot,_bow_Deadshot_p);
      if (BowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_bowDeadshot,_bow_Deadshot_s);
      ref PerkObject _crossbowPiercer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowPiercer");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowPiercer,_xbw_Piercer_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowPiercer,_xbw_Piercer_s);
      ref PerkObject _crossbowMarksmen = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowMarksmen");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowMarksmen,_xbw_Marksmen_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowMarksmen,_xbw_Marksmen_s);
      ref PerkObject _crossbowUnhorser = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowUnhorser");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowUnhorser,_xbw_Unhorser_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowUnhorser,_xbw_Unhorser_s);
      ref PerkObject _crossbowWindWinder = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowWindWinder");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowWindWinder,_xbw_WindWinder_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowWindWinder,_xbw_WindWinder_s);
      ref PerkObject _crossbowDonkeysSwiftness = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowDonkeysSwiftness");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowDonkeysSwiftness,_xbw_DonkeysSwiftness_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowDonkeysSwiftness,_xbw_DonkeysSwiftness_s);
      ref PerkObject _crossbowSheriff = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowSheriff");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowSheriff,_xbw_Sheriff_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowSheriff,_xbw_Sheriff_s);
      ref PerkObject _crossbowPeasantLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowPeasantLeader");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowPeasantLeader,_xbw_PeasantLeader_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowPeasantLeader,_xbw_PeasantLeader_s);
      ref PerkObject _crossbowRenownMarksmen = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowRenownMarksmen");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowRenownMarksmen,_xbw_RenownMarksmen_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowRenownMarksmen,_xbw_RenownMarksmen_s);
      ref PerkObject _crossbowFletcher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowFletcher");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowFletcher,_xbw_Fletcher_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowFletcher,_xbw_Fletcher_s);
      ref PerkObject _crossbowPuncture = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowPuncture");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowPuncture,_xbw_Puncture_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowPuncture,_xbw_Puncture_s);
      ref PerkObject _crossbowLooseAndMove = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowLooseAndMove");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowLooseAndMove,_xbw_LooseAndMove_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowLooseAndMove,_xbw_LooseAndMove_s);
      ref PerkObject _crossbowDeftHands = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowDeftHands");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowDeftHands,_xbw_DeftHands_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowDeftHands,_xbw_DeftHands_s);
      ref PerkObject _crossbowMountedCrossbowman = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowMountedCrossbowman");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowMountedCrossbowman,_xbw_MountedCrossbowman_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowMountedCrossbowman,_xbw_MountedCrossbowman_s);
      ref PerkObject _crossbowSteady = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowSteady");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowSteady,_xbw_Steady_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowSteady,_xbw_Steady_s);
      ref PerkObject _crossbowSniper = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowSniper");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowSniper,_xbw_Sniper_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowSniper,_xbw_Sniper_s);
      ref PerkObject _crossbowHammerBolts = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowHammerBolts");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowHammerBolts,_xbw_HammerBolts_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowHammerBolts,_xbw_HammerBolts_s);
      ref PerkObject _crossbowPavise = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowPavise");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowPavise,_xbw_Pavise_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowPavise,_xbw_Pavise_s);
      ref PerkObject _crossbowTerror = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowTerror");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowTerror,_xbw_Terror_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowTerror,_xbw_Terror_s);
      ref PerkObject _crossbowPickedShots = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowPickedShots");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowPickedShots,_xbw_PickedShots_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowPickedShots,_xbw_PickedShots_s);
      ref PerkObject _crossbowMightyPull = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_crossbowMightyPull");
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_crossbowMightyPull,_xbw_MightyPull_p);
      if (CrossbowPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_crossbowMightyPull,_xbw_MightyPull_s);
      ref PerkObject _throwingQuickDraw = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingQuickDraw");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingQuickDraw,_thr_QuickDraw_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingQuickDraw,_thr_QuickDraw_s);
      ref PerkObject _throwingShieldBreaker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingShieldBreaker");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingShieldBreaker,_thr_ShieldBreaker_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingShieldBreaker,_thr_ShieldBreaker_s);
      ref PerkObject _throwingHunter = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingHunter");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingHunter,_thr_Hunter_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingHunter,_thr_Hunter_s);
      ref PerkObject _throwingFlexibleFighter = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingFlexibleFighter");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingFlexibleFighter,_thr_FlexibleFighter_p);
      ref PerkObject _throwingMountedSkirmisher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingMountedSkirmisher");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingMountedSkirmisher,_thr_MountedSkirmisher_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingMountedSkirmisher,_thr_MountedSkirmisher_s);
      ref PerkObject _throwingPerfectTechnique = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingPerfectTechnique");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingPerfectTechnique,_thr_PerfectTechnique_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingPerfectTechnique,_thr_PerfectTechnique_s);
      ref PerkObject _throwingRunningThrow = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingRunningThrow");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingRunningThrow,_thr_RunningThrow_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingRunningThrow,_thr_RunningThrow_s);
      ref PerkObject _throwingKnockOff = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingKnockOff");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingKnockOff,_thr_KnockOff_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingKnockOff,_thr_KnockOff_s);
      ref PerkObject _throwingWellPrepared = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingWellPrepared");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingWellPrepared,_thr_WellPrepared_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingWellPrepared,_thr_WellPrepared_s);
      ref PerkObject _throwingFocus = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingFocus");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingFocus,_thr_Focus_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingFocus,_thr_Focus_s);
      ref PerkObject _throwingLastHit = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingLastHit");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingLastHit,_thr_LastHit_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingLastHit,_thr_LastHit_s);
      ref PerkObject _throwingHeadHunter = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingHeadHunter");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingHeadHunter,_thr_HeadHunter_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingHeadHunter,_thr_HeadHunter_s);
      ref PerkObject _throwingThrowingCompetitions = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingThrowingCompetitions");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingThrowingCompetitions,_thr_ThrowingCompetitions_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingThrowingCompetitions,_thr_ThrowingCompetitions_s);
      ref PerkObject _throwingSplinters = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingSplinters");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingSplinters,_thr_Splinters_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingSplinters,_thr_Splinters_s);
      ref PerkObject _throwingResourceful = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingResourceful");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingResourceful,_thr_Resourceful_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingResourceful,_thr_Resourceful_s);
      ref PerkObject _throwingLongReach = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingLongReach");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingLongReach,_thr_LongReach_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingLongReach,_thr_LongReach_s);
      ref PerkObject _throwingWeakSpot = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingWeakSpot");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingWeakSpot,_thr_WeakSpot_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingWeakSpot,_thr_WeakSpot_s);
      ref PerkObject _throwingImpale = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingImpale");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingImpale,_thr_Impale_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingImpale,_thr_Impale_s);
      ref PerkObject _throwingUnstoppableForce = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_throwingUnstoppableForce");
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_throwingUnstoppableForce,_thr_UnstoppableForce_p);
      if (ThrowingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_throwingUnstoppableForce,_thr_UnstoppableForce_s);
      ref PerkObject _ridingFullSpeed = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingFullSpeed");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingFullSpeed,_rid_FullSpeed_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingFullSpeed,_rid_FullSpeed_s);
      ref PerkObject _ridingNimbleSteed = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingNimbleSteed");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingNimbleSteed,_rid_NimbleSteed_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingNimbleSteed,_rid_NimbleSteed_s);
      ref PerkObject _ridingWellStraped = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingWellStraped");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingWellStraped,_rid_WellStraped_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingWellStraped,_rid_WellStraped_s);
      ref PerkObject _ridingVeterinary = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingVeterinary");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingVeterinary,_rid_Veterinary_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingVeterinary,_rid_Veterinary_s);
      ref PerkObject _ridingNomadicTraditions = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingNomadicTraditions");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingNomadicTraditions,_rid_NomadicTraditions_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingNomadicTraditions,_rid_NomadicTraditions_s);
      ref PerkObject _ridingFilledToBrim = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingFilledToBrim");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingFilledToBrim,_rid_FilledToBrim_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingFilledToBrim,_rid_FilledToBrim_s);
      ref PerkObject _ridingSagittarius = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingSagittarius");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingSagittarius,_rid_Sagittarius_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingSagittarius,_rid_Sagittarius_s);
      ref PerkObject _ridingSweepingWind = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingSweepingWind");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingSweepingWind,_rid_SweepingWind_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingSweepingWind,_rid_SweepingWind_s);
      ref PerkObject _ridingMountedWarrior = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingMountedWarrior");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingMountedWarrior,_rid_MountedWarrior_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingMountedWarrior,_rid_MountedWarrior_s);
      ref PerkObject _ridingHorseArcher = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingHorseArcher");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingHorseArcher,_rid_HorseArcher_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingHorseArcher,_rid_HorseArcher_s);
      ref PerkObject _ridingHorde = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingHorde");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingHorde,_rid_Horde_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingHorde,_rid_Horde_s);
      ref PerkObject _ridingBreeder = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingBreeder");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingBreeder,_rid_Breeder_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingBreeder,_rid_Breeder_s);
      ref PerkObject _ridingThunderousCharge = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingThunderousCharge");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingThunderousCharge,_rid_ThunderousCharge_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingThunderousCharge,_rid_ThunderousCharge_s);
      ref PerkObject _ridingAnnoyingBuzz = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingAnnoyingBuzz");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingAnnoyingBuzz,_rid_AnnoyingBuzz_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingAnnoyingBuzz,_rid_AnnoyingBuzz_s);
      ref PerkObject _ridingMountedPatrols = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingMountedPatrols");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingMountedPatrols,_rid_MountedPatrols_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingMountedPatrols,_rid_MountedPatrols_s);
      ref PerkObject _ridingCavalryTactics = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingCavalryTactics");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingCavalryTactics,_rid_CavalryTactics_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingCavalryTactics,_rid_CavalryTactics_s);
      ref PerkObject _ridingDauntlessSteed = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingDauntlessSteed");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingDauntlessSteed,_rid_DauntlessSteed_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingDauntlessSteed,_rid_DauntlessSteed_s);
      ref PerkObject _ridingToughSteed = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingToughSteed");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingToughSteed,_rid_ToughSteed_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingToughSteed,_rid_ToughSteed_s);
      ref PerkObject _ridingTheWayOfTheSaddle = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_ridingTheWayOfTheSaddle");
      if (RidingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_ridingTheWayOfTheSaddle,_rid_TheWayOfTheSaddle_p);
      if (RidingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_ridingTheWayOfTheSaddle,_rid_TheWayOfTheSaddle_s);
      ref PerkObject _athleticsMorningExercise = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsMorningExercise");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsMorningExercise,_ath_MorningExercise_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsMorningExercise,_ath_MorningExercise_s);
      ref PerkObject _athleticsWellBuilt = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsWellBuilt");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsWellBuilt,_ath_WellBuilt_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsWellBuilt,_ath_WellBuilt_s);
      ref PerkObject _athleticsFormFittingArmor = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsFormFittingArmor");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsFormFittingArmor,_ath_FormFittingArmor_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsFormFittingArmor,_ath_FormFittingArmor_s);
      ref PerkObject _athleticsHavingGoing = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsHavingGoing");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsHavingGoing,_ath_HavingGoing_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsHavingGoing,_ath_HavingGoing_s);
      ref PerkObject _athleticsStamina = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsStamina");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsStamina,_ath_Stamina_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsStamina,_ath_Stamina_s);
      ref PerkObject _athleticsPowerful = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsPowerful");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsPowerful,_ath_Powerful_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsPowerful,_ath_Powerful_s);
      ref PerkObject _athleticsSurgingBlow = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsSurgingBlow");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsSurgingBlow,_ath_SurgingBlow_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsSurgingBlow,_ath_SurgingBlow_s);
      ref PerkObject _athleticsBraced = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsBraced");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsBraced,_ath_Braced_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsBraced,_ath_Braced_s);
      ref PerkObject _athleticsWalkItOff = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsWalkItOff");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsWalkItOff,_ath_WalkItOff_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsWalkItOff,_ath_WalkItOff_s);
      ref PerkObject _athleticsAGoodDaysRest = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsAGoodDaysRest");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsAGoodDaysRest,_ath_AGoodDaysRest_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsAGoodDaysRest,_ath_AGoodDaysRest_s);
      ref PerkObject _athleticsHealthyCitizens = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsHealthyCitizens");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsHealthyCitizens,_ath_HealthyCitizens_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsHealthyCitizens,_ath_HealthyCitizens_s);
      ref PerkObject _athleticsEnergetic = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsEnergetic");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsEnergetic,_ath_Energetic_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsEnergetic,_ath_Energetic_s);
      ref PerkObject _athleticsSteady = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsSteady");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsSteady,_ath_Steady_p);
      ref PerkObject _athleticsStrong = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsStrong");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsStrong,_ath_Strong_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsStrong,_ath_Strong_s);
      ref PerkObject _athleticsStrongArms = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsStrongArms");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsStrongArms,_ath_StrongArms_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsStrongArms,_ath_StrongArms_s);
      ref PerkObject _athleticsSpartan = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsSpartan");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsSpartan,_ath_Spartan_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsSpartan,_ath_Spartan_s);
      ref PerkObject _athleticsIgnorePain = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsIgnorePain");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsIgnorePain,_ath_IgnorePain_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsIgnorePain,_ath_IgnorePain_s);
      ref PerkObject _athleticsMightyBlow = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_athleticsMightyBlow");
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_athleticsMightyBlow,_ath_MightyBlow_p);
      if (AthleticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_athleticsMightyBlow,_ath_MightyBlow_s);
      ref PerkObject _craftingSharpenedEdge = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_craftingSharpenedEdge");
      if (CraftingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_craftingSharpenedEdge,_cft_SharpenedEdge_p);
      ref PerkObject _craftingSharpenedTip = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_craftingSharpenedTip");
      if (CraftingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_craftingSharpenedTip,_cft_SharpenedTip_p);
      ref PerkObject _tacticsTightFormations = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsTightFormations");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsTightFormations,_tct_TightFormations_p);
      ref PerkObject _tacticsLooseFormations = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsLooseFormations");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsLooseFormations,_tct_LooseFormations_p);
      ref PerkObject _tacticsAsymmetricalWarfare = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsAsymmetricalWarfare");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsAsymmetricalWarfare,_tct_AsymmetricalWarfare_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsAsymmetricalWarfare,_tct_AsymmetricalWarfare_s);
      ref PerkObject _tacticsSmallUnitTactics = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsSmallUnitTactics");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsSmallUnitTactics,_tct_SmallUnitTactics_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsSmallUnitTactics,_tct_SmallUnitTactics_s);
      ref PerkObject _tacticsHordeLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsHordeLeader");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsHordeLeader,_tct_HordeLeader_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsHordeLeader,_tct_HordeLeader_s);
      ref PerkObject _tacticsLawKeeper = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsLawKeeper");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsLawKeeper,_tct_LawKeeper_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsLawKeeper,_tct_LawKeeper_s);
      ref PerkObject _tacticsCoaching = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsCoaching");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsCoaching,_tct_Coaching_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsCoaching,_tct_Coaching_s);
      ref PerkObject _tacticsSwiftRegroup = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsSwiftRegroup");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsSwiftRegroup,_tct_SwiftRegroup_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsSwiftRegroup,_tct_SwiftRegroup_s);
      ref PerkObject _tacticsOnTheMarch = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsOnTheMarch");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsOnTheMarch,_tct_OnTheMarch_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsOnTheMarch,_tct_OnTheMarch_s);
      ref PerkObject _tacticsCallToArms = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsCallToArms");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsCallToArms,_tct_CallToArms_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsCallToArms,_tct_CallToArms_s);
      ref PerkObject _tacticsPickThemOfTheWalls = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsPickThemOfTheWalls");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsPickThemOfTheWalls,_tct_PickThemOfTheWalls_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsPickThemOfTheWalls,_tct_PickThemOfTheWalls_s);
      ref PerkObject _tacticsMakeThemPay = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsMakeThemPay");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsMakeThemPay,_tct_MakeThemPay_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsMakeThemPay,_tct_MakeThemPay_s);
      ref PerkObject _tacticsEliteReserves = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsEliteReserves");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsEliteReserves,_tct_EliteReserves_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsEliteReserves,_tct_EliteReserves_s);
      ref PerkObject _tacticsEncirclement = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsEncirclement");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsEncirclement,_tct_Encirclement_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsEncirclement,_tct_Encirclement_s);
      ref PerkObject _tacticsPreBattleManeuvers = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsPreBattleManeuvers");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsPreBattleManeuvers,_tct_PreBattleManeuvers_p);
      ref PerkObject _tacticsBesieged = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsBesieged");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsBesieged,_tct_Besieged_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsBesieged,_tct_Besieged_s);
      ref PerkObject _tacticsCounteroffensive = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsCounteroffensive");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsCounteroffensive,_tct_Counteroffensive_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsCounteroffensive,_tct_Counteroffensive_s);
      ref PerkObject _tacticsGensdarmes = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsGensdarmes");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsGensdarmes,_tct_Gensdarmes_p);
      if (TacticsPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tacticsGensdarmes,_tct_Gensdarmes_s);
      ref PerkObject _tacticsTacticalMastery = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tacticsTacticalMastery");
      if (TacticsPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tacticsTacticalMastery,_tct_TacticalMastery_p);
      ref PerkObject _scoutingDayTraveler = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingDayTraveler");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingDayTraveler,_sct_DayTraveler_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingDayTraveler,_sct_DayTraveler_s);
      ref PerkObject _scoutingNightRunner = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingNightRunner");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingNightRunner,_sct_NightRunner_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingNightRunner,_sct_NightRunner_s);
      ref PerkObject _scoutingPathfinder = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingPathfinder");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingPathfinder,_sct_Pathfinder_p);
      ref PerkObject _scoutingWaterDiviner = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingWaterDiviner");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingWaterDiviner,_sct_WaterDiviner_p);
      ref PerkObject _scoutingForestKin = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingForestKin");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingForestKin,_sct_ForestKin_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingForestKin,_sct_ForestKin_s);
      ref PerkObject _scoutingDesertBorn = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingDesertBorn");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingDesertBorn,_sct_DesertBorn_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingDesertBorn,_sct_DesertBorn_s);
      ref PerkObject _scoutingForcedMarch = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingForcedMarch");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingForcedMarch,_sct_ForcedMarch_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingForcedMarch,_sct_ForcedMarch_s);
      ref PerkObject _scoutingUnburdened = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingUnburdened");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingUnburdened,_sct_Unburdened_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingUnburdened,_sct_Unburdened_s);
      ref PerkObject _scoutingTracker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingTracker");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingTracker,_sct_Tracker_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingTracker,_sct_Tracker_s);
      ref PerkObject _scoutingRanger = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingRanger");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingRanger,_sct_Ranger_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingRanger,_sct_Ranger_s);
      ref PerkObject _scoutingPatrols = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingPatrols");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingPatrols,_sct_Patrols_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingPatrols,_sct_Patrols_s);
      ref PerkObject _scoutingForagers = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingForagers");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingForagers,_sct_Foragers_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingForagers,_sct_Foragers_s);
      ref PerkObject _scoutingBeastWhisperer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingBeastWhisperer");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingBeastWhisperer,_sct_BeastWhisperer_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingBeastWhisperer,_sct_BeastWhisperer_s);
      ref PerkObject _scoutingVillageNetwork = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingVillageNetwork");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingVillageNetwork,_sct_VillageNetwork_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingVillageNetwork,_sct_VillageNetwork_s);
      ref PerkObject _scoutingRumourNetwork = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingRumourNetwork");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingRumourNetwork,_sct_RumourNetwork_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingRumourNetwork,_sct_RumourNetwork_s);
      ref PerkObject _scoutingVantagePoint = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingVantagePoint");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingVantagePoint,_sct_VantagePoint_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingVantagePoint,_sct_VantagePoint_s);
      ref PerkObject _scoutingKeenSight = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingKeenSight");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingKeenSight,_sct_KeenSight_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingKeenSight,_sct_KeenSight_s);
      ref PerkObject _scoutingRearguard = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingRearguard");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingRearguard,_sct_Rearguard_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingRearguard,_sct_Rearguard_s);
      ref PerkObject _scoutingUncannyInsight = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_scoutingUncannyInsight");
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_scoutingUncannyInsight,_sct_UncannyInsight_p);
      if (ScoutingPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_scoutingUncannyInsight,_sct_UncannyInsight_s);
      ref PerkObject _rogueryNoRestForTheWicked = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryNoRestForTheWicked");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryNoRestForTheWicked,_rog_NoRestForTheWicked_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryNoRestForTheWicked,_rog_NoRestForTheWicked_s);
      ref PerkObject _roguerySweetTalker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_roguerySweetTalker");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_roguerySweetTalker,_rog_SweetTalker_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_roguerySweetTalker,_rog_SweetTalker_s);
      ref PerkObject _rogueryTwoFaced = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryTwoFaced");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryTwoFaced,_rog_TwoFaced_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryTwoFaced,_rog_TwoFaced_s);
      ref PerkObject _rogueryDeepPockets = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryDeepPockets");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryDeepPockets,_rog_DeepPockets_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryDeepPockets,_rog_DeepPockets_s);
      ref PerkObject _rogueryInBestLight = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryInBestLight");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryInBestLight,_rog_InBestLight_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryInBestLight,_rog_InBestLight_s);
      ref PerkObject _rogueryKnowHow = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryKnowHow");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryKnowHow,_rog_KnowHow_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryKnowHow,_rog_KnowHow_s);
      ref PerkObject _rogueryPromises = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryPromises");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryPromises,_rog_Promises_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryPromises,_rog_Promises_s);
      ref PerkObject _roguerySlaveTrader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_roguerySlaveTrader");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_roguerySlaveTrader,_rog_SlaveTrader_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_roguerySlaveTrader,_rog_SlaveTrader_s);
      ref PerkObject _rogueryWhiteLies = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryWhiteLies");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryWhiteLies,_rog_WhiteLies_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryWhiteLies,_rog_WhiteLies_s);
      ref PerkObject _roguerySmugglerConnections = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_roguerySmugglerConnections");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_roguerySmugglerConnections,_rog_SmugglerConnections_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_roguerySmugglerConnections,_rog_SmugglerConnections_s);
      ref PerkObject _rogueryPartnersInCrime = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryPartnersInCrime");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryPartnersInCrime,_rog_PartnersInCrime_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryPartnersInCrime,_rog_PartnersInCrime_s);
      ref PerkObject _rogueryOneOfTheFamily = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryOneOfTheFamily");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryOneOfTheFamily,_rog_OneOfTheFamily_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryOneOfTheFamily,_rog_OneOfTheFamily_s);
      ref PerkObject _rogueryCarver = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryCarver");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryCarver,_rog_Carver_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryCarver,_rog_Carver_s);
      ref PerkObject _rogueryRansomBroker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryRansomBroker");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryRansomBroker,_rog_RansomBroker_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryRansomBroker,_rog_RansomBroker_s);
      ref PerkObject _rogueryArmsDealer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryArmsDealer");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryArmsDealer,_rog_ArmsDealer_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryArmsDealer,_rog_ArmsDealer_s);
      ref PerkObject _rogueryDirtyFighting = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryDirtyFighting");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryDirtyFighting,_rog_DirtyFighting_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryDirtyFighting,_rog_DirtyFighting_s);
      ref PerkObject _rogueryDashAndSlash = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryDashAndSlash");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryDashAndSlash,_rog_DashAndSlash_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryDashAndSlash,_rog_DashAndSlash_s);
      ref PerkObject _rogueryFleetFooted = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryFleetFooted");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryFleetFooted,_rog_FleetFooted_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryFleetFooted,_rog_FleetFooted_s);
      ref PerkObject _rogueryRogueExtraordinaire = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_rogueryRogueExtraordinaire");
      if (RogueryPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_rogueryRogueExtraordinaire,_rog_RogueExtraordinaire_p);
      if (RogueryPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_rogueryRogueExtraordinaire,_rog_RogueExtraordinaire_s);
      ref PerkObject _leadershipCombatTips = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipCombatTips");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipCombatTips,_ldr_CombatTips_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipCombatTips,_ldr_CombatTips_s);
      ref PerkObject _leadershipRaiseTheMeek = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipRaiseTheMeek");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipRaiseTheMeek,_ldr_RaiseTheMeek_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipRaiseTheMeek,_ldr_RaiseTheMeek_s);
      ref PerkObject _leadershipFerventAttacker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipFerventAttacker");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipFerventAttacker,_ldr_FerventAttacker_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipFerventAttacker,_ldr_FerventAttacker_s);
      ref PerkObject _leadershipStoutDefender = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipStoutDefender");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipStoutDefender,_ldr_StoutDefender_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipStoutDefender,_ldr_StoutDefender_s);
      ref PerkObject _leadershipAuthority = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipAuthority");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipAuthority,_ldr_Authority_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipAuthority,_ldr_Authority_s);
      ref PerkObject _leadershipHeroicLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipHeroicLeader");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipHeroicLeader,_ldr_HeroicLeader_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipHeroicLeader,_ldr_HeroicLeader_s);
      ref PerkObject _leadershipLoyaltyAndHonor = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipLoyaltyAndHonor");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipLoyaltyAndHonor,_ldr_LoyaltyAndHonor_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipLoyaltyAndHonor,_ldr_LoyaltyAndHonor_s);
      ref PerkObject _leadershipFamousCommander = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipFamousCommander");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipFamousCommander,_ldr_FamousCommander_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipFamousCommander,_ldr_FamousCommander_s);
      ref PerkObject _leadershipPresence = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipPresence");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipPresence,_ldr_Presence_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipPresence,_ldr_Presence_s);
      ref PerkObject _leadershipLeaderOfTheMasses = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipLeaderOfTheMasses");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipLeaderOfTheMasses,_ldr_LeaderOfMasses_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipLeaderOfTheMasses,_ldr_LeaderOfMasses_s);
      ref PerkObject _leadershipVeteransRespect = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipVeteransRespect");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipVeteransRespect,_ldr_VeteransRespect_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipVeteransRespect,_ldr_VeteransRespect_s);
      ref PerkObject _leadershipCitizenMilitia = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipCitizenMilitia");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipCitizenMilitia,_ldr_CitizenMilitia_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipCitizenMilitia,_ldr_CitizenMilitia_s);
      ref PerkObject _leadershipInspiringLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipInspiringLeader");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipInspiringLeader,_ldr_InspiringLeader_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipInspiringLeader,_ldr_InspiringLeader_s);
      ref PerkObject _leadershipUpliftingSpirit = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipUpliftingSpirit");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipUpliftingSpirit,_ldr_UpliftingSpirit_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipUpliftingSpirit,_ldr_UpliftingSpirit_s);
      ref PerkObject _leadershipMakeADifference = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipMakeADifference");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipMakeADifference,_ldr_MakeADifference_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipMakeADifference,_ldr_MakeADifference_s);
      ref PerkObject _leadershipLeadByExample = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipLeadByExample");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipLeadByExample,_ldr_LeadByExample_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipLeadByExample,_ldr_LeadByExample_s);
      ref PerkObject _leadershipTrustedCommander = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipTrustedCommander");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipTrustedCommander,_ldr_TrustedCommander_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipTrustedCommander,_ldr_TrustedCommander_s);
      ref PerkObject _leadershipWePledgeOurSwords = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipWePledgeOurSwords");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipWePledgeOurSwords,_ldr_WePledgeOurSwords_p);
      ref PerkObject _leadershipTalentMagnet = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipTalentMagnet");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipTalentMagnet,_ldr_TalentMagnet_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipTalentMagnet,_ldr_TalentMagnet_s);
      ref PerkObject _leadershipUltimateLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_leadershipUltimateLeader");
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_leadershipUltimateLeader,_ldr_UltimateLeader_p);
      if (LeadershipPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_leadershipUltimateLeader,_ldr_UltimateLeader_s);
      ref PerkObject _charmVirile = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmVirile");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmVirile,_chm_Virile_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmVirile,_chm_Virile_s);
      ref PerkObject _charmSelfPromoter = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmSelfPromoter");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmSelfPromoter,_chm_SelfPromoter_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmSelfPromoter,_chm_SelfPromoter_s);
      ref PerkObject _charmOratory = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmOratory");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmOratory,_chm_Oratory_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmOratory,_chm_Oratory_s);
      ref PerkObject _charmWarlord = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmWarlord");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmWarlord,_chm_Warlord_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmWarlord,_chm_Warlord_s);
      ref PerkObject _charmForgivableGrievances = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmForgivableGrievances");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmForgivableGrievances,_chm_ForgivableGrievances_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmForgivableGrievances,_chm_ForgivableGrievances_s);
      ref PerkObject _charmMeaningfulFavors = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmMeaningfulFavors");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmMeaningfulFavors,_chm_MeaningfulFavors_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmMeaningfulFavors,_chm_MeaningfulFavors_s);
      ref PerkObject _charmInBloom = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmInBloom");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmInBloom,_chm_InBloom_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmInBloom,_chm_InBloom_s);
      ref PerkObject _charmYoungAndRespectful = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmYoungAndRespectful");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmYoungAndRespectful,_chm_YoungAndRespectful_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmYoungAndRespectful,_chm_YoungAndRespectful_s);
      ref PerkObject _charmFirebrand = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmFirebrand");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmFirebrand,_chm_Firebrand_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmFirebrand,_chm_Firebrand_s);
      ref PerkObject _charmFlexibleEthics = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmFlexibleEthics");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmFlexibleEthics,_chm_FlexibleEthics_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmFlexibleEthics,_chm_FlexibleEthics_s);
      ref PerkObject _charmSlickNegotiator = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmSlickNegotiator");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmSlickNegotiator,_chm_SlickNegotiator_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmSlickNegotiator,_chm_SlickNegotiator_s);
      ref PerkObject _charmTribute = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmTribute");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmTribute,_chm_Tribute_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmTribute,_chm_Tribute_s);
      ref PerkObject _charmMoralLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmMoralLeader");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmMoralLeader,_chm_MoralLeader_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmMoralLeader,_chm_MoralLeader_s);
      ref PerkObject _charmNaturalLeader = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmNaturalLeader");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmNaturalLeader,_chm_NaturalLeader_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmNaturalLeader,_chm_NaturalLeader_s);
      ref PerkObject _charmPublicSpeaker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmPublicSpeaker");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmPublicSpeaker,_chm_PublicSpeaker_p);
      ref PerkObject _charmCamaraderie = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_charmCamaraderie");
      if (CharmPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_charmCamaraderie,_chm_Camaraderie_p);
      if (CharmPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_charmCamaraderie,_chm_Camaraderie_s);
      ref PerkObject _tradeAppraiser = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeAppraiser");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeAppraiser,_trd_Appraiser_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeAppraiser,_trd_Appraiser_s);
      ref PerkObject _tradeWholeSeller = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeWholeSeller");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeWholeSeller,_trd_WholeSeller_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeWholeSeller,_trd_WholeSeller_s);
      ref PerkObject _tradeCaravanMaster = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeCaravanMaster");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeCaravanMaster,_trd_CaravanMaster_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeCaravanMaster,_trd_CaravanMaster_s);
      ref PerkObject _tradeMarketDealer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeMarketDealer");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeMarketDealer,_trd_MarketDealer_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeMarketDealer,_trd_MarketDealer_s);
      ref PerkObject _tradeTravelingRumors = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeTravelingRumors");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeTravelingRumors,_trd_TravelingRumors_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeTravelingRumors,_trd_TravelingRumors_s);
      ref PerkObject _tradeLocalConnection = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeLocalConnection");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeLocalConnection,_trd_LocalConnection_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeLocalConnection,_trd_LocalConnection_s);
      ref PerkObject _tradeDistributedGoods = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeDistributedGoods");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeDistributedGoods,_trd_DistributedGoods_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeDistributedGoods,_trd_DistributedGoods_s);
      ref PerkObject _tradeTollgates = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeTollgates");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeTollgates,_trd_Tollgates_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeTollgates,_trd_Tollgates_s);
      ref PerkObject _tradeArtisanCommunity = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeArtisanCommunity");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeArtisanCommunity,_trd_ArtisanCommunity_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeArtisanCommunity,_trd_ArtisanCommunity_s);
      ref PerkObject _tradeGreatInvestor = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeGreatInvestor");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeGreatInvestor,_trd_GreatInvestor_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeGreatInvestor,_trd_GreatInvestor_s);
      ref PerkObject _tradeMercenaryConnections = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeMercenaryConnections");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeMercenaryConnections,_trd_MercenaryConnections_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeMercenaryConnections,_trd_MercenaryConnections_s);
      ref PerkObject _tradeContentTrades = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeContentTrades");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeContentTrades,_trd_ContentTrades_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeContentTrades,_trd_ContentTrades_s);
      ref PerkObject _tradeInsurancePlans = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeInsurancePlans");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeInsurancePlans,_trd_InsurancePlans_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeInsurancePlans,_trd_InsurancePlans_s);
      ref PerkObject _tradeRapidDevelopment = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeRapidDevelopment");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeRapidDevelopment,_trd_RapidDevelopment_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeRapidDevelopment,_trd_RapidDevelopment_s);
      ref PerkObject _tradeGranaryAccountant = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeGranaryAccountant");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeGranaryAccountant,_trd_GranaryAccountant_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeGranaryAccountant,_trd_GranaryAccountant_s);
      ref PerkObject _tradeSwordForBarter = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeSwordForBarter");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeSwordForBarter,_trd_SwordForBarter_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeSwordForBarter,_trd_SwordForBarter_s);
      ref PerkObject _tradeSelfMadeMan = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeSelfMadeMan");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeSelfMadeMan,_trd_SelfMadeMan_p);
      ref PerkObject _tradeSilverTongue = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeSilverTongue");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeSilverTongue,_trd_SilverTongue_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeSilverTongue,_trd_SilverTongue_s);
      ref PerkObject _tradeManOfMeans = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeManOfMeans");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeManOfMeans,_trd_ManOfMeans_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeManOfMeans,_trd_ManOfMeans_s);
      ref PerkObject _tradeTrickleDown = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_tradeTrickleDown");
      if (TradePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_tradeTrickleDown,_trd_TrickleDown_p);
      if (TradePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_tradeTrickleDown,_trd_TrickleDown_s);
      ref PerkObject _stewardSpartan = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardSpartan");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardSpartan,_st_Spartan_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardSpartan,_st_Spartan_s);
      ref PerkObject _stewardFrugal = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardFrugal");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardFrugal,_st_Frugal_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardFrugal,_st_Frugal_s);
      ref PerkObject _stewardSevenVeterans = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardSevenVeterans");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardSevenVeterans,_st_SevenVeterans_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardSevenVeterans,_st_SevenVeterans_s);
      ref PerkObject _stewardDrillSergant = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardDrillSergant");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardDrillSergant,_st_DrillSergant_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardDrillSergant,_st_DrillSergant_s);
      ref PerkObject _stewardSweatshops = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardSweatshops");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardSweatshops,_st_Sweatshops_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardSweatshops,_st_Sweatshops_s);
      ref PerkObject _stewardStiffUpperLip = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardStiffUpperLip");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardStiffUpperLip,_st_StiffUpperLip_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardStiffUpperLip,_st_StiffUpperLip_s);
      ref PerkObject _stewardPaidInPromise = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardPaidInPromise");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardPaidInPromise,_st_PaidInPromise_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardPaidInPromise,_st_PaidInPromise_s);
      ref PerkObject _stewardEfficientCampaigner = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardEfficientCampaigner");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardEfficientCampaigner,_st_EfficientCampaigner_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardEfficientCampaigner,_st_EfficientCampaigner_s);
      ref PerkObject _stewardGivingHands = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardGivingHands");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardGivingHands,_st_GivingHands_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardGivingHands,_st_GivingHands_s);
      ref PerkObject _stewardLogistician = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardLogistician");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardLogistician,_st_Logistician_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardLogistician,_st_Logistician_s);
      ref PerkObject _stewardRelocation = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardRelocation");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardRelocation,_st_Relocation_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardRelocation,_st_Relocation_s);
      ref PerkObject _stewardAidCorps = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardAidCorps");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardAidCorps,_st_AidCorps_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardAidCorps,_st_AidCorps_s);
      ref PerkObject _stewardGourmet = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardGourmet");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardGourmet,_st_Gourmet_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardGourmet,_st_Gourmet_s);
      ref PerkObject _stewardSoundReserves = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardSoundReserves");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardSoundReserves,_st_SoundReserves_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardSoundReserves,_st_SoundReserves_s);
      ref PerkObject _stewardForcedLabor = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardForcedLabor");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardForcedLabor,_st_ForcedLabor_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardForcedLabor,_st_ForcedLabor_s);
      ref PerkObject _stewardContractors = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardContractors");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardContractors,_st_Contractors_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardContractors,_st_Contractors_s);
      ref PerkObject _stewardArenicosMules = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardArenicosMules");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardArenicosMules,_st_ArenicosMules_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardArenicosMules,_st_ArenicosMules_s);
      ref PerkObject _stewardArenicosHorses = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardArenicosHorses");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardArenicosHorses,_st_ArenicosHorses_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardArenicosHorses,_st_ArenicosHorses_s);
      ref PerkObject _stewardMasterOfPlanning = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardMasterOfPlanning");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardMasterOfPlanning,_st_MasterOfPlanning_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardMasterOfPlanning,_st_MasterOfPlanning_s);
      ref PerkObject _stewardMasterOfWarcraft = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_stewardMasterOfWarcraft");
      if (StewardPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_stewardMasterOfWarcraft,_st_MasterOfWarcraft_p);
      if (StewardPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_stewardMasterOfWarcraft,_st_MasterOfWarcraft_s);
      ref PerkObject _medicineSelfMedication = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineSelfMedication");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineSelfMedication,_med_SelfMedication_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineSelfMedication,_med_SelfMedication_s);
      ref PerkObject _medicinePreventiveMedicine = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicinePreventiveMedicine");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicinePreventiveMedicine,_med_PreventiveMedicine_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicinePreventiveMedicine,_med_PreventiveMedicine_s);
      ref PerkObject _medicineTriageTent = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineTriageTent");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineTriageTent,_med_TriageTent_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineTriageTent,_med_TriageTent_s);
      ref PerkObject _medicineWalkItOff = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineWalkItOff");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineWalkItOff,_med_WalkItOff_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineWalkItOff,_med_WalkItOff_s);
      ref PerkObject _medicineSledges = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineSledges");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineSledges,_med_Sledges_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineSledges,_med_Sledges_s);
      ref PerkObject _medicineDoctorsOath = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineDoctorsOath");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineDoctorsOath,_med_DoctorsOath_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineDoctorsOath,_med_DoctorsOath_s);
      ref PerkObject _medicineBestMedicine = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineBestMedicine");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineBestMedicine,_med_BestMedicine_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineBestMedicine,_med_BestMedicine_s);
      ref PerkObject _medicineGoodLodging = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineGoodLodging");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineGoodLodging,_med_GoodLogdings_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineGoodLodging,_med_GoodLogdings_s);
      ref PerkObject _medicineSiegeMedic = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineSiegeMedic");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineSiegeMedic,_med_SiegeMedic_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineSiegeMedic,_med_SiegeMedic_s);
      ref PerkObject _medicineVeterinarian = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineVeterinarian");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineVeterinarian,_med_Veterinarian_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineVeterinarian,_med_Veterinarian_s);
      ref PerkObject _medicinePristineStreets = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicinePristineStreets");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicinePristineStreets,_med_PristineStreets_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicinePristineStreets,_med_PristineStreets_s);
      ref PerkObject _medicineBushDoctor = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineBushDoctor");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineBushDoctor,_med_BushDoctor_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineBushDoctor,_med_BushDoctor_s);
      ref PerkObject _medicinePerfectHealth = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicinePerfectHealth");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicinePerfectHealth,_med_PerfectHealth_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicinePerfectHealth,_med_PerfectHealth_s);
      ref PerkObject _medicineHealthAdvise = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineHealthAdvise");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineHealthAdvise,_med_HealthAdvise_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineHealthAdvise,_med_HealthAdvise_s);
      ref PerkObject _medicinePhysicianOfPeople = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicinePhysicianOfPeople");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicinePhysicianOfPeople,_med_PhysicianOfPeople_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicinePhysicianOfPeople,_med_PhysicianOfPeople_s);
      ref PerkObject _medicineCleanInfrastructure = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineCleanInfrastructure");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineCleanInfrastructure,_med_CleanInfrastructure_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineCleanInfrastructure,_med_CleanInfrastructure_s);
      ref PerkObject _medicineCheatDeath = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineCheatDeath");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineCheatDeath,_med_CheatDeath_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineCheatDeath,_med_CheatDeath_s);
      ref PerkObject _medicineFortitudeTonic = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineFortitudeTonic");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineFortitudeTonic,_med_FortitudeTonic_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineFortitudeTonic,_med_FortitudeTonic_s);
      ref PerkObject _medicineHelpingHands = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineHelpingHands");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineHelpingHands,_med_HelpingHands_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineHelpingHands,_med_HelpingHands_s);
      ref PerkObject _medicineBattleHardened = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_medicineBattleHardened");
      if (MedicinePerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_medicineBattleHardened,_med_BattleHardened_p);
      if (MedicinePerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_medicineBattleHardened,_med_BattleHardened_s);
      ref PerkObject _engineeringScaffolds = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringScaffolds");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringScaffolds,_eng_Scaffolds_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringScaffolds,_eng_Scaffolds_s);
      ref PerkObject _engineeringTorsionEngines = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringTorsionEngines");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringTorsionEngines,_eng_TorsionEngines_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringTorsionEngines,_eng_TorsionEngines_s);
      ref PerkObject _engineeringSiegeWorks = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringSiegeWorks");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringSiegeWorks,_eng_SiegeWorks_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringSiegeWorks,_eng_SiegeWorks_s);
      ref PerkObject _engineeringPrisonArchitect = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringPrisonArchitect");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringPrisonArchitect,_eng_PrisonArchitect_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringPrisonArchitect,_eng_PrisonArchitect_s);
      ref PerkObject _engineeringCarpenters = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringCarpenters");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringCarpenters,_eng_Carpenters_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringCarpenters,_eng_Carpenters_s);
      ref PerkObject _engineeringMilitaryPlanner = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringMilitaryPlanner");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringMilitaryPlanner,_eng_MilitaryPlanner_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringMilitaryPlanner,_eng_MilitaryPlanner_s);
      ref PerkObject _engineeringWallBreaker = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringWallBreaker");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringWallBreaker,_eng_WallBreaker_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringWallBreaker,_eng_WallBreaker_s);
      ref PerkObject _engineeringDreadfulSieger = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringDreadfulSieger");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringDreadfulSieger,_eng_DreadfulSieger_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringDreadfulSieger,_eng_DreadfulSieger_s);
      ref PerkObject _engineeringSalvager = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringSalvager");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringSalvager,_eng_Salvager_p);
      ref PerkObject _engineeringForeman = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringForeman");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringForeman,_eng_Foreman_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringForeman,_eng_Foreman_s);
      ref PerkObject _engineeringSiegeEngineer = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringSiegeEngineer");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringSiegeEngineer,_eng_SiegeEngineer_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringSiegeEngineer,_eng_SiegeEngineer_s);
      ref PerkObject _engineeringBattlements = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringBattlements");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringBattlements,_eng_Battlements_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringBattlements,_eng_Battlements_s);
      ref PerkObject _engineeringEngineeringGuilds = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringEngineeringGuilds");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringEngineeringGuilds,_eng_EngineeringGuilds_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringEngineeringGuilds,_eng_EngineeringGuilds_s);
      ref PerkObject _engineeringMetallurgy = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringMetallurgy");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringMetallurgy,_eng_Metallurgy_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringMetallurgy,_eng_Metallurgy_s);
      ref PerkObject _engineeringImprovedTools = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringImprovedTools");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringImprovedTools,_eng_ImprovedTools_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringImprovedTools,_eng_ImprovedTools_s);
      ref PerkObject _engineeringClockwork = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringClockwork");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringClockwork,_eng_Clockwork_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringClockwork,_eng_Clockwork_s);
      ref PerkObject _engineeringArchitecturalCommisions = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, "_engineeringArchitecturalCommisions");
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetPrimaryBonus(_engineeringArchitecturalCommisions,_eng_ArchitecturalCommisions_p);
      if (EngineeringPerkModificationEnabled) ExposeInternals.SetSecondaryBonus(_engineeringArchitecturalCommisions,_eng_ArchitecturalCommisions_s);
    }
  }
}