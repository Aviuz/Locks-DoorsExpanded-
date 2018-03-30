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
    [HarmonyPatch("DeSpawn")]
    public class Patch_RemoveLockData
    {
        private static void Postfix(Building_DoorExpanded __instance)
        {
            LockUtility.Remove(__instance);
        }
    }
}
