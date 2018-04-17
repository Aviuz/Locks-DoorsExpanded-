﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using DoorsExpanded;

namespace LocksDoorsExpanded
{
    public class LockData : IExposable, IAssignableBuilding
    {
        private Building_DoorExpanded parent;

        public LockState CurrentState;
        public LockState WantedState;

        public LockData()
        {
            CurrentState = new LockState(LockMode.Allies, true, false, new List<Pawn>());
            WantedState = new LockState(LockMode.Allies, true, false, new List<Pawn>());
        }

        // Utilities
        #region Utilities
        public bool NeedChange
        {
            get
            {
                return CurrentState != WantedState;
            }
        }

        public bool CanChangeLocks(Pawn pawn)
        {
            return WantedState.owners.Count == 0 || WantedState.owners.Contains(pawn);
        }
        #endregion

        // IAssignableBuilding
        #region IAssignableBuilding
        public int MaxAssignedPawnsCount => WantedState.owners.Count + 1;

        public IEnumerable<Pawn> AssignedPawns
        {
            get
            {
                return WantedState.owners;
            }
        }

        public IEnumerable<Pawn> AssigningCandidates
        {
            get
            {
                return parent.Map.mapPawns.FreeColonists;
            }
        }

        public void TryAssignPawn(Pawn pawn)
        {
            WantedState.owners.Add(pawn);
            UpdateOwners();
        }

        public void TryUnassignPawn(Pawn pawn)
        {
            WantedState.owners.Remove(pawn);
            UpdateOwners();
        }

        public void UpdateOwners()
        {
            foreach (Building_DoorExpanded door in Find.Selector.SelectedObjects.Where(o => o is Building_DoorExpanded && o != parent))
            {
                LockUtility.GetData(door).WantedState.owners.Clear();
                LockUtility.GetData(door).WantedState.owners.AddRange(LockUtility.GetData(parent).WantedState.owners);
                LockUtility.UpdateLockDesignation(door);
            }
            LockUtility.UpdateLockDesignation(parent);
        }
        #endregion

        public void ExposeData()
        {
            CurrentState.ExposeData("current");
            WantedState.ExposeData("wanted");
        }

        public void UpdateReference(Building_DoorExpanded door)
        {
            parent = door;
        }
    }
}
