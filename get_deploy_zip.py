from pathlib import Path
from zipfile import ZipFile, ZIP_DEFLATED
from shutil import copyfile

bin_targets = ['FountaTweaks.dll']
base_targets = ['SubModule.xml']

modules_dir_str = "Modules/"
basedir_str = "FountaTweaks/"

partial_bindir_str = "bin/Win64_Shipping_Client/"

modules = Path(modules_dir_str)
basedir = modules / basedir_str

#make directory structure
full_bindir = basedir / partial_bindir_str
full_bindir.mkdir(parents=True, exist_ok=True)

#copy targets into directory structure
bin_source_dir = Path("founta_tweaks/")
base_source_dir = Path("founta_tweaks/")

zip_targets = []

for target in bin_targets:
  destination = full_bindir / target
  copyfile(bin_source_dir / target, destination)
  zip_targets.append(destination)
  

for target in base_targets:
  destination = basedir / target
  copyfile(base_source_dir / target, basedir / target)
  zip_targets.append(destination)

#zip up the directory
z = ZipFile("FountaTweaks.zip", 'w', compression=ZIP_DEFLATED)
for t in zip_targets:
    z.write(t)
z.close()