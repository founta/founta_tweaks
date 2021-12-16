def get_prop_str(sp, name, low, high, hint, groups):
  lines = [sp+'[SettingPropertyFloatingInteger("%s", %ff, %ff, RequireRestart = false, HintText = %s)]' % (name, low, high, hint),
           sp+'[SettingPropertyGroup("%s")]' % ('/'.join(groups))]
  return lines


default_perk_init_all_code = r""""""

header = """using System;
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
  public class AutoFountaTweaksSettings : AttributeGlobalSettings<AutoFountaTweaksSettings>
  {
    public override string Id => "FountaTweaks";
    public override string DisplayName => "Founta's Tweaks";
    
    private string _version;
    public string version { get => _version; }
    public AutoFountaTweaksSettings() : base()
    {
      //read version from xml
      XmlReader reader = XmlReader.Create("../../Modules/FountaTweaks/SubModule.xml");
      reader.ReadToFollowing("Version");
      reader.MoveToFirstAttribute();

      this._version = reader.Value;
    }
"""
footer = "\n  }\n}"
sp = "  "

class_members = []
class_member_funcs = []
set_all_lines = []

short_desc_map = {
  "_engineering": "eng",
  "_medicine": "med",
  "_steward" : "st",
  "_trade": "trd",
  "_charm": "chm",
  "_leadership": "ldr",
  "_roguery": "rog",
  "_scouting": "sct",
  "_tactics": "tct",
  "_crafting": "cft",
  "_athletics": "ath",
  "_riding": "rid",
  "_throwing": "thr",
  "_crossbow": "xbw",
  "_bow": "bow",
  "_polearm":"plm",
  "_twoHanded":"twh",
  "_oneHanded":"oh"
}

perk_tree_map = {
  "_engineering": "Engineering",
  "_medicine": "Medicine",
  "_steward" : "Steward",
  "_trade": "Trade",
  "_charm": "Charm",
  "_leadership": "Leadership",
  "_roguery": "Roguery",
  "_scouting": "Scouting",
  "_tactics": "Tactics",
  "_crafting": "Crafting",
  "_athletics": "Athletics",
  "_riding": "Riding",
  "_throwing": "Throwing",
  "_crossbow": "Crossbow",
  "_bow": "Bow",
  "_polearm":"Polearm",
  "_twoHanded":"TwoHanded",
  "_oneHanded":"OneHanded"
}

perk_name_replacements = {
  "LeaderOfTheMasses":"LeaderOfMasses",
  "Counterweight":"CounterWeight",
  "GoodLodging": "GoodLogdings"  
}

desc_replacements = {
    "string.Empty": '"Unknown"'
}

dp = "DefaultPerks"

for line in default_perk_init_all_code.splitlines():
  line.replace(");", "")
  
  #look up the perk type
  perk_var_name = line.split(".")[1]
  perk_desc = None
  for key in short_desc_map.keys():
    if key in perk_var_name:
      perk_desc = key
      break
  if perk_desc is None:
    print("Could not find perk name for variable %s" % (perk_var_name))
    continue
  
  perk_name = perk_var_name.replace(perk_desc, "")
  perk_tree = perk_tree_map[perk_desc]
  
  if perk_name in perk_name_replacements:
    perk_name = perk_name_replacements[perk_name]
  
  #try to extract the primary description, secondary description, primary bonus and secondary bonus
  line_split = line.split(",")
  perk_disp_name = line_split[0].split('"')[1]
  primary_desc = None
  secondary_desc = None
  primary_bonus = None
  secondary_bonus = None
  try:
    primary_desc = line_split[4]
    if '"' not in primary_desc and "string.Empty" not in primary_desc:
      primary_desc = line_split[1]
  except:
    pass
  try:
    primary_bonus = float(line_split[6].replace("f",""))
  except:
    pass
  if primary_bonus is None:
    for s in line_split:
      if "primaryBonus:" in s:
        try:
          primary_bonus = float(s.replace("f","").replace("primaryBonus:",""))
        except:
          pass
      
  try:
    secondary_desc = line_split[8]
  except:
    pass
  try:
    secondary_bonus = float(line_split[10].replace("f",""))
  except:
    pass
  
  if primary_bonus is None:
    print("perk %s is abnormal, skipping" % (perk_name))
    continue
  
  do_secondary = True
  if secondary_desc is None or secondary_bonus is None:
    do_secondary = False
  else:
    secondary_desc = secondary_desc.strip()
  
  primary_desc = primary_desc.strip()
  for key in desc_replacements:
    if key == primary_desc:
      primary_desc = desc_replacements[key]
    if key == secondary_desc:
      secondary_desc = desc_replacements[key]

  
  #try to estimate high and low bounds based on the bonus value
  def estimate_low_high(val):
    if val > 0 and val < 0.45:
      low = 0
      high = 1
    elif val < 0 and val > -1:
      low = -1
      high = 0
    elif val < 0:
      low = -100
      high = 0
    elif val >= 0.45 and val <= 100:
      low = 0
      high = 100
    else: #val >100
      low = 0
      high = 99999
    
    return (low,high)
  plow, phigh = estimate_low_high(primary_bonus)
  if do_secondary:
    slow, shigh = estimate_low_high(secondary_bonus)
  
  perk_short_desc = short_desc_map[perk_desc]
  perk_member_name = "_%s_%s_" % (perk_short_desc, perk_name)
  perk_member_p = perk_member_name + "p"
  perk_member_s = perk_member_name + "s"
  
  perk_access = dp+".%s.%s" % (perk_tree, perk_name)
  perk_access_p = perk_access + ".PrimaryBonus"
  perk_access_s = perk_access + ".SecondaryBonus"
  
  func_name_p = perk_short_desc + "_" + perk_name + "_p"
  func_name_s = perk_short_desc + "_" + perk_name + "_s"

  class_members.append(sp*2+"private float %s = %ff;" % (perk_member_p, primary_bonus))
  if do_secondary:
    class_members.append(sp*2+"private float %s = %ff;" % (perk_member_s, secondary_bonus))
  
  def get_setter_getter_str(secondary):
    p = perk_access
    if secondary:
      mem = perk_member_s
      func = "ExposeInternals.SetSecondaryBonus"
    else:
      mem = perk_member_p
      func = "ExposeInternals.SetPrimaryBonus"
    lines = [sp*3+"get => %s;" % (mem),
             sp*3+"set {",
             sp*4+"if (%s != value) {" % (mem),
             sp*5+"%s = value;" % (mem),
             sp*5+"if (Game.Current != null)",
             sp*6+"%s(%s, value);" % (func,p),
             sp*4+"}",
             sp*3+"}"]
    return lines
  
  def get_set_all_str(secondary):
    p = perk_var_name#perk_access
    if secondary:
      mem = perk_member_s
      func = "ExposeInternals.SetSecondaryBonus"
    else:
      mem = perk_member_p
      func = "ExposeInternals.SetPrimaryBonus"
    return [sp*3+"%s(%s,%s);" % (func,p,mem)]
  
  def get_access_str():
    return [sp*3+"ref PerkObject %s = ref AccessTools.FieldRefAccess<DefaultPerks,PerkObject>(perk, \"%s\");" % (perk_var_name,perk_var_name)]
  
  def get_whole_func(func_name, ret_type, func_decorators, func_body):
    lines = func_decorators +\
            [sp*2+"public %s %s {" %(ret_type,func_name)] + func_body + [sp*2+"}"]
    return lines
  
  getter_setter_func = []
  getter_setter_func += get_whole_func(func_name_p, "float",
                                       get_prop_str(sp*2, "Primary Bonus", plow, phigh, primary_desc, ["Perks",perk_tree,perk_disp_name]), 
                                       get_setter_getter_str(False))
  set_all_lines += get_access_str()
  set_all_lines += get_set_all_str(False)
  if do_secondary:
      getter_setter_func += get_whole_func(func_name_s, "float",
                                       get_prop_str(sp*2, "Secondary Bonus", slow, shigh, secondary_desc, ["Perks",perk_tree,perk_disp_name]), 
                                       get_setter_getter_str(True))
      set_all_lines += get_set_all_str(True)

  class_member_funcs += getter_setter_func + ["\n"]

class_contents = header + "\n".join(class_members) + "\n" + "\n".join(class_member_funcs) +\
                 "\n".join(get_whole_func("SetAll(ref DefaultPerks perk)", "void",[], set_all_lines)) + footer
with open("founta_tweaks/AutoFountaTweaksSettings.cs", "w") as f:
  f.write(class_contents)
    
    
    
    
    
    
    
    
    
    
    
    
    
    