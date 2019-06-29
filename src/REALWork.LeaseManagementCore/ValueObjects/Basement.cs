using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class Basement : ValueObject
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

        private Basement()
        {
        }

        public Basement(ConditionType lightingB, ConditionType lightingE, string lightingCommentB, string lightingCommentE, 
            ConditionType windowsCoveringB, ConditionType windowsCoveringE, ConditionType windowsCoveringCommentB, 
            ConditionType windowsCoveringCommentE, ConditionType electricalOutletsB, ConditionType electricalOutletsE, 
            string electricalOutletsCommentB, string electricalOutletsCommentE, ConditionType stairwellB, ConditionType stairwellE, 
            string stairwellCommentB, string stairwellCommentE, ConditionType wallsAndFloorCarpetB, ConditionType wallsAndFloorCarpetE, 
            string wallsAndFloorCarpetCommentB, string wallsAndFloorCarpetCommentE, ConditionType furnacePlumbingB, ConditionType furnacePlumbingE, 
            string furnacePlumbingCommentB, string furnacePlumbingCommentE)
        {
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
            StairwellB = stairwellB;
            StairwellE = stairwellE;
            StairwellCommentB = stairwellCommentB;
            StairwellCommentE = stairwellCommentE;
            WallsAndFloorCarpetB = wallsAndFloorCarpetB;
            WallsAndFloorCarpetE = wallsAndFloorCarpetE;
            WallsAndFloorCarpetCommentB = wallsAndFloorCarpetCommentB;
            WallsAndFloorCarpetCommentE = wallsAndFloorCarpetCommentE;
            FurnacePlumbingB = furnacePlumbingB;
            FurnacePlumbingE = furnacePlumbingE;
            FurnacePlumbingCommentB = furnacePlumbingCommentB;
            FurnacePlumbingCommentE = furnacePlumbingCommentE;
        }

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

        public ConditionType StairwellB { get; private set; }
        public ConditionType StairwellE { get; private set; }
        public string StairwellCommentB { get; private set; }
        public string StairwellCommentE { get; private set; }

        public ConditionType WallsAndFloorCarpetB { get; private set; }
        public ConditionType WallsAndFloorCarpetE { get; private set; }
        public string WallsAndFloorCarpetCommentB { get; private set; }
        public string WallsAndFloorCarpetCommentE { get; private set; }

        public ConditionType FurnacePlumbingB { get; private set; }
        public ConditionType FurnacePlumbingE { get; private set; }
        public string FurnacePlumbingCommentB { get; private set; }
        public string FurnacePlumbingCommentE { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
