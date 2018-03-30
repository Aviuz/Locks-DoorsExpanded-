using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoorsExpanded;
using Harmony;
using RimWorld;

namespace LocksDoorsExpanded.HarmonyPatches
{
    [HarmonyPatch(typeof(Building_DoorExpanded))]
    [HarmonyPatch("ExposeData")]
    public class Patch_AddLockDataToSave
    {
        private static void Postfix(Building_DoorExpanded __instance)
        {
            //TODO disable utility
            if (false)
                return;

            LockUtility.GetData(__instance).ExposeData();
        }
    }
}
