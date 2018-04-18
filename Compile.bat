:: ========= Build ==========

devenv "D:\Git Repository\LocksDoorsExpanded\Source\LocksDoorsExpanded.sln" /build Debug



:: ========= Copy ==========
 
rd "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded" /s /q
mkdir "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded"

:: About
mkdir "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\About"
xcopy "D:\Git Repository\LocksDoorsExpanded\About\*.*" "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\About" /e

:: Assemblies
mkdir "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Assemblies"
xcopy "D:\Git Repository\LocksDoorsExpanded\Assemblies\*.*" "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Assemblies" /e

:: Defs 
mkdir "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Defs"
xcopy "D:\Git Repository\LocksDoorsExpanded\Defs\*.*" "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Defs" /e

:: Languages
mkdir "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Languages"
xcopy "D:\Git Repository\LocksDoorsExpanded\Languages\*.*" "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Languages" /e

:: Textures
mkdir "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Textures"
xcopy "D:\Git Repository\LocksDoorsExpanded\Textures\*.*" "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\Textures" /e

:: changelog.txt
copy "D:\Git Repository\LocksDoorsExpanded\changelog.txt" "D:\Program Files\Steam\steamapps\common\RimWorld\Mods\LocksDoorsExpanded\changelog.txt"