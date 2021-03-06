﻿using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class StairWayHallWay : ValueObject
    {
        public enum ConditionType
        {
            NA,
            Good,
            Fair,
            Poor,
            Damaged,
            Scratched,
            Broken,
            Dirty,
            Stained
        }

        private StairWayHallWay()
        {
        }

        public StairWayHallWay(ConditionType wallAndTrimeB, ConditionType wallAndTrimeE, string wallAndTrimsCommentB, 
            string wallAndTrimsCommentE, ConditionType ceilingsB, ConditionType ceilingsE, string ceilingsCommentB, 
            string ceilingsCommentE, ConditionType lightingB, ConditionType lightingE, string lightingCommentB, 
            string lightingCommentE, ConditionType windowsCoveringB, ConditionType windowsCoveringE, ConditionType windowsCoveringCommentB, 
            ConditionType windowsCoveringCommentE, ConditionType electricalOutletsB, ConditionType electricalOutletsE, string electricalOutletsCommentB, 
            string electricalOutletsCommentE, ConditionType closetsB, ConditionType closetsE, string closetsCommentB, string closetsCommentE, 
            ConditionType treadsAndLandingsB, ConditionType treadsAndLandingsE, string treadsAndLandingsCommentB, string treadsAndLandingsCommentE, 
            ConditionType railingB, ConditionType railingE, string railingCommentB, string railingCommentE)
        {
            WallAndTrimeB = wallAndTrimeB;
            WallAndTrimeE = wallAndTrimeE;
            WallAndTrimsCommentB = wallAndTrimsCommentB;
            WallAndTrimsCommentE = wallAndTrimsCommentE;
            CeilingsB = ceilingsB;
            CeilingsE = ceilingsE;
            CeilingsCommentB = ceilingsCommentB;
            CeilingsCommentE = ceilingsCommentE;
            LightingB = lightingB;
            LightingE = lightingE;
            LightingCommentB = lightingCommentB;
            LightingCommentE = lightingCommentE;
            WindowsCoveringB = windowsCoveringB;
            WindowsCoveringE = windowsCoveringE;
            WindowsCoveringCommentB = windowsCoveringCommentB;
            WindowsCoveringCommentE = windowsCoveringCommentE;
            ElectricalOutletsB = electricalOutletsB;
            ElectricalOutletsE = electricalOutletsE;
            ElectricalOutletsCommentB = electricalOutletsCommentB;
            ElectricalOutletsCommentE = electricalOutletsCommentE;
            ClosetsB = closetsB;
            ClosetsE = closetsE;
            ClosetsCommentB = closetsCommentB;
            ClosetsCommentE = closetsCommentE;
            TreadsAndLandingsB = treadsAndLandingsB;
            TreadsAndLandingsE = treadsAndLandingsE;
            TreadsAndLandingsCommentB = treadsAndLandingsCommentB;
            TreadsAndLandingsCommentE = treadsAndLandingsCommentE;
            RailingB = railingB;
            RailingE = railingE;
            RailingCommentB = railingCommentB;
            RailingCommentE = railingCommentE;
        }

        public ConditionType WallAndTrimeB { get; private set; } // Begin Comment
        public ConditionType WallAndTrimeE { get; private set; } // End
        public string WallAndTrimsCommentB { get; private set; }
        public string WallAndTrimsCommentE { get; private set; }

        public ConditionType CeilingsB { get; private set; }
        public ConditionType CeilingsE { get; private set; }
        public string CeilingsCommentB { get; private set; }
        public string CeilingsCommentE { get; private set; }

        public ConditionType LightingB { get; private set; }
        public ConditionType LightingE { get; private set; }
        public string LightingCommentB { get; private set; }
        public string LightingCommentE { get; private set; }

        public ConditionType WindowsCoveringB { get; private set; }
        public ConditionType WindowsCoveringE { get; private set; }
        public ConditionType WindowsCoveringCommentB { get; private set; }
        public ConditionType WindowsCoveringCommentE { get; private set; }

        public ConditionType ElectricalOutletsB { get; private set; }
        public ConditionType ElectricalOutletsE { get; private set; }
        public string ElectricalOutletsCommentB { get; private set; }
        public string ElectricalOutletsCommentE { get; private set; }

        public ConditionType ClosetsB { get; private set; }
        public ConditionType ClosetsE { get; private set; }
        public string ClosetsCommentB { get; private set; }
        public string ClosetsCommentE { get; private set; }


        public ConditionType TreadsAndLandingsB { get; private set; }
        public ConditionType TreadsAndLandingsE { get; private set; }
        public string TreadsAndLandingsCommentB { get; private set; }
        public string TreadsAndLandingsCommentE { get; private set; }


        public ConditionType RailingB { get; private set; }
        public ConditionType RailingE { get; private set; }
        public string RailingCommentB { get; private set; }
        public string RailingCommentE { get; private set; }




        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
