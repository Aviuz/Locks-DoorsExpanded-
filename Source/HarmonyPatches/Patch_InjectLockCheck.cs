using DoorsExpanded;
using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace LocksDoorsExpanded.HarmonyPatches
{
    [HarmonyPatch(typeof(Building_Door))]
    [HarmonyPatch("PawnCanOpen")]
    public class Patch_InjectLockCheck
    {
        private static IEnumerable<CodeInstruction> Transpiler(ILGenerator gen, IEnumerable<CodeInstruction> instr)
        {
            var label = gen.DefineLabel();

            yield return new CodeInstruction(OpCodes.Ldarg_0);
            yield return new CodeInstruction(OpCodes.Call, typeof(Patch_InjectLockCheck).GetMethod("IsDoorExpanded"));
            yield return new CodeInstruction(OpCodes.Brfalse, label);
            yield return new CodeInstruction(OpCodes.Ldarg_0);
            yield return new CodeInstruction(OpCodes.Ldarg_1);
            yield return new CodeInstruction(OpCodes.Call, typeof(LockUtility).GetMethod("PawnCanOpen"));
            yield return new CodeInstruction(OpCodes.Ret);

            bool first = true;
            foreach(var ci in instr)
            {
                if (first)
                {
                    ci.labels.Add(label);
                    first = false;
                }
                yield return ci;
            }
        }

        public static bool IsDoorExpanded(Building_Door b)
        {
            if (b is Building_DoorRegionHandler)
                return true;
            else
                return false;
        }
    }
}
