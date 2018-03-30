﻿using DoorsExpanded;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace LocksDoorsExpanded
{
    public static class LockUtility
    {
        private static readonly Dictionary<Building_DoorExpanded, LockData> Map = new Dictionary<Building_DoorExpanded, LockData>();

        private static DesignationDef designationDef;
        private static JobDef jobDef;

        public static DesignationDef DesDef
        {
            get
            {
                if (designationDef == null)
                {
                    designationDef = DefDatabase<DesignationDef>.GetNamed("LocksDoorsExpanded_Flick");
                }

                return designationDef;
            }
        }

        public static JobDef JobDef
        {
            get
            {
                if (jobDef == null)
                {
                    jobDef = DefDatabase<JobDef>.GetNamed("LocksDoorsExpanded_Flick");
                }

                return jobDef;
            }
        }

        public static bool PawnCanOpen(Building_DoorExpanded door, Pawn p)
        {
            Lord lord = p.GetLord();

            bool canOpenAnyDoor = lord != null && lord.LordJob != null && lord.LordJob.CanOpenAnyDoor(p);
            bool noFaction = door.Faction == null;
            if (canOpenAnyDoor || noFaction)
                return true;

            if (GetData(door).CurrentState.locked == false && p.RaceProps != null && p.RaceProps.intelligence >= Intelligence.Humanlike)
                return true;

            if (p.Faction == null || p.Faction.HostileTo(door.Faction))
                return false;

            if (GetData(door).Private && GetData(door).CurrentState.petDoor && p.RaceProps.Animal && p.RaceProps.baseBodySize <= 0.85 && p.Faction == door.Faction)
                return true;

            if (GetData(door).Private && !GetData(door).CurrentState.owners.Contains(p))
                return false;

            if (p.Faction == door.Faction && !p.IsPrisoner)
                return true;

            bool guestCondition = !p.IsPrisoner || p.HostFaction != door.Faction;
            if (GetData(door).CurrentState.mode == LockMode.Allies && guestCondition)
                return true;

            return false;
        }

        public static LockData GetData(Building_DoorExpanded key)
        {
            if (!Map.ContainsKey(key))
                Map[key] = new LockData();
            Map[key].UpdateReference(key);
            return Map[key];
        }

        public static void Remove(Building_DoorExpanded key)
        {
            Map.Remove(key);
        }

        public static void UpdateLockDesignation(Thing t)
        {
            bool flag = false;
            Building_DoorExpanded door = t as Building_DoorExpanded;
            if (door != null)
            {
                flag = GetData(door).NeedChange;
            }
            Designation designation = t.Map.designationManager.DesignationOn(t, DesDef);
            if (flag && designation == null)
            {
                t.Map.designationManager.AddDesignation(new Designation(t, DesDef));
            }
            else if (!flag && designation != null)
            {
                designation.Delete();
            }
        }

    }
}
