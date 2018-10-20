:: ========= Variables =========

SET mod_name=LocksDoorsExpanded
SET github_release=https://github.com/Aviuz/Locks-DoorsExpanded-/releases
SET steam_changelog=https://steamcommunity.com/sharedfiles/filedetails/changelog/1346609640
SET steam_description=https://steamcommunity.com/sharedfiles/itemedittext/?id=1346609640

SET target_directory=D:\Program Files\Steam\steamapps\common\RimWorld\Mods\%mod_name%
SET zip_directory=C:\Users\avius\Desktop\Locks.DoorsExpanded.zip


:: ========= Zip archive ==========
 
"D:\Program Files\WinRAR\Rar.exe" a -ep1 -r "%zip_directory%" "%target_directory%\*"


:: ========= Run ==========

start %github_release%
start %steam_changelog%
start %steam_description%
start steam://rungameid/294100