using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class LivingRoom : ValueObject
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

        private LivingRoom()
        {
        }

        public LivingRoom(ConditionType wallAndTrimeB, ConditionType wallAndTrimeE, string wallAndTrimsCommentB, string wallAndTrimsCommentE, 
            ConditionType ceilingsB, ConditionType ceilingsE, string ceilingsCommentB, string ceilingsCommentE, ConditionType closetsB, 
            ConditionType closetsE, string closetsCommentB, string closetsCommentE, ConditionType lightingB, ConditionType lightingE, 
            string lightingCommentB, string lightingCommentE, ConditionType windowsCoveringB, ConditionType windowsCoveringE, 
            ConditionType windowsCoveringCommentB, ConditionType windowsCoveringCommentE, ConditionType electricalOutletsB, 
            ConditionType electricalOutletsE, string electricalOutletsCommentB, string electricalOutletsCommentE, ConditionType floorCarpetB, 
            ConditionType floorCarpetE, string floorCarpetCommentB, string floorCarpetCommentE, ConditionType airConditionerB,
            ConditionType airConditionerE, string airConditionerCommentB, string airConditionerCommentE, ConditionType cableTVB, ConditionType cableTVE, 
            string cableTVCommentB, string cableTVCommentE, ConditionType fireplaceB, ConditionType fireplaceE, string fireplaceCommentB, 
            string fireplaceCommentE, string notes)
        {
            WallAndTrimeB = wallAndTrimeB;
            WallAndTrimeE = wallAndTrimeE;
            WallAndTrimsCommentB = wallAndTrimsCommentB;
            WallAndTrimsCommentE = wallAndTrimsCommentE;
            CeilingsB = ceilingsB;
            CeilingsE = ceilingsE;
            CeilingsCommentB = ceilingsCommentB;
            CeilingsCommentE = ceilingsCommentE;
            ClosetsB = closetsB;
            ClosetsE = closetsE;
            ClosetsCommentB = closetsCommentB;
            ClosetsCommentE = closetsCommentE;
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
            FloorCarpetB = floorCarpetB;
            FloorCarpetE = floorCarpetE;
            FloorCarpetCommentB = floorCarpetCommentB;
            FloorCarpetCommentE = floorCarpetCommentE;
            AirConditionerB = airConditionerB;
            AirConditionerE = airConditionerE;
            AirConditionerCommentB = airConditionerCommentB;
            AirConditionerCommentE = airConditionerCommentE;
            CableTVB = cableTVB;
            CableTVE = cableTVE;
            CableTVCommentB = cableTVCommentB;
            CableTVCommentE = cableTVCommentE;
            FireplaceB = fireplaceB;
            FireplaceE = fireplaceE;
            FireplaceCommentB = fireplaceCommentB;
            FireplaceCommentE = fireplaceCommentE;
            Notes = notes;
        }

        public ConditionType WallAndTrimeB { get; private set; } // Begin Comment
        public ConditionType WallAndTrimeE { get; private set; } // End
        public string WallAndTrimsCommentB { get; private set; }
        public string WallAndTrimsCommentE { get; private set; }

        public ConditionType CeilingsB { get; private set; }
        public ConditionType CeilingsE { get; private set; }
        public string CeilingsCommentB { get; private set; }
        public string CeilingsCommentE { get; private set; }

        public ConditionType ClosetsB { get; private set; }
        public ConditionType ClosetsE { get; private set; }
        public string ClosetsCommentB { get; private set; }
        public string ClosetsCommentE { get; private set; }

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

        public ConditionType FloorCarpetB { get; private set; }
        public ConditionType FloorCarpetE { get; private set; }
        public string FloorCarpetCommentB { get; private set; }
        public string FloorCarpetCommentE { get; private set; }

        public ConditionType AirConditionerB { get; private set; }
        public ConditionType AirConditionerE { get; private set; }
        public string AirConditionerCommentB { get; private set; }
        public string AirConditionerCommentE { get; private set; }

        public ConditionType CableTVB { get; private set; }
        public ConditionType CableTVE { get; private set; }
        public string CableTVCommentB { get; private set; }
        public string CableTVCommentE { get; private set; }

        public ConditionType FireplaceB { get; private set; }
        public ConditionType FireplaceE { get; private set; }
        public string FireplaceCommentB { get; private set; }
        public string FireplaceCommentE { get; private set; }


        public string Notes { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
