using RimWorld;
using System.Collections.Generic;
using Verse;

namespace LocksDoorsExpanded
{
    [StaticConstructorOnStartup]
    public static class Initialization
    {
        static Initialization()
        {
            HarmonyPatches.HPatcher.Init();
            InjectLockTab();
        }

        static void InjectLockTab()
        {
            var door_defs = new List<ThingDef>();
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("PH_DoorDouble"));
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("PH_DoorTriple"));
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("PH_DoorJail"));
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("HeronCurtainTribal"));
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("PH_GateDoubleThick"));
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("PH_DoorBlastDoor"));
            door_defs.Add(DefDatabase<ThingDef>.GetNamed("PH_DoorThickBlastDoor"));
            foreach (var door_def in door_defs)
            {
                if (door_def.inspectorTabs == null)
                    door_def.inspectorTabs = new List<System.Type>();
                door_def.inspectorTabs.Add(typeof(ITab_Lock));

                if (door_def.comps == null)
                    door_def.comps = new List<CompProperties>();
                door_def.comps.Add(new CompProperties_Lock());

                door_def.ResolveReferences();
            }
        }
    }
}
