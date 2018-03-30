using DoorsExpanded;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace LocksDoorsExpanded
{
    public class CompProperties_Lock : CompProperties
    {
        public CompProperties_Lock()
        {
            compClass = typeof(CompLock);
        }
    }

    public class CompLock : ThingComp
    {
        public override string CompInspectStringExtra()
        {
            string text = "Locks_StatePrefix".Translate() + " ";

            if (LockUtility.GetData((Building_DoorExpanded)this.parent).Locked)
                text += "Locks_StateLocked".Translate();
            else
                text += "Locks_StateUnlocked".Translate();
            if (LockUtility.GetData((Building_DoorExpanded)this.parent).NeedChange)
                text += $" ({"Locks_StateChanging".Translate()})";

            return text;
        }
    }
}
