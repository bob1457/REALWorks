using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class Kitchen : ValueObject
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

        private Kitchen()
        {
        }

        public Kitchen(ConditionType wallAndTrimeB, ConditionType wallAndTrimeE, string wallAndTrimsCommentB, string wallAndTrimsCommentE, 
            ConditionType ceilingsB, ConditionType ceilingsE, string ceilingsCommentB, string ceilingsCommentE, ConditionType closetsB, 
            ConditionType closetsE, string closetsCommentB, string closetsCommentE, ConditionType lightingB, ConditionType lightingE, 
            string lightingCommentB, string lightingCommentE, ConditionType windowsCoveringB, ConditionType windowsCoveringE, 
            ConditionType windowsCoveringCommentB, ConditionType windowsCoveringCommentE, ConditionType electricalOutletsB, ConditionType electricalOutletsE, 
            string electricalOutletsCommentB, string electricalOutletsCommentE, ConditionType floorCarpetB, ConditionType floorCarpetE, string floorCarpetCommentB, 
            string floorCarpetCommentE, ConditionType ovenB, ConditionType ovenE, ConditionType ovenCommentB, ConditionType ovenCommentE, ConditionType countertopB, 
            ConditionType countertopE, string countertopCommentB, string countertopCommentE, ConditionType cabinetsAndDoorsB, ConditionType cabinetsAndDoorsE, 
            string cabinetsAndDoorsCommentB, string cabinetsAndDoorsCommentE, ConditionType hoodAndFanB, ConditionType hoodAndFanE, string hoodAndCommentFanB, 
            string hoodAndCommentFanE, ConditionType tapsSinksB, ConditionType tapsSinksE, string tapsSinksCommentB, string tapsSinksCommentE, 
            ConditionType refrigeratorExteriorB, ConditionType refrigeratorExteriorE, string refrigeratorExteriorCommentB, string refrigeratorExteriorCommentE, 
            ConditionType refrigeratorShelfB, ConditionType refrigeratorShelfE, string refrigeratorShelfCommentB, string refrigeratorShelfCommentE, 
            ConditionType refrigeratorFreezerB, ConditionType refrigeratorFreezerE, string refrigeratorFreezerCommentB, string refrigeratorFreezerCommentE, 
            ConditionType dishwasherB, ConditionType dishwasherE, string dishwasherCommentB, string dishwasherCommentE, ConditionType stoveB, ConditionType stoveE, 
            string stoveCommentB, string stoveCommentE, string notes)
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
            OvenB = ovenB;
            OvenE = ovenE;
            OvenCommentB = ovenCommentB;
            OvenCommentE = ovenCommentE;
            CountertopB = countertopB;
            CountertopE = countertopE;
            CountertopCommentB = countertopCommentB;
            CountertopCommentE = countertopCommentE;
            CabinetsAndDoorsB = cabinetsAndDoorsB;
            CabinetsAndDoorsE = cabinetsAndDoorsE;
            CabinetsAndDoorsCommentB = cabinetsAndDoorsCommentB;
            CabinetsAndDoorsCommentE = cabinetsAndDoorsCommentE;
            HoodAndFanB = hoodAndFanB;
            HoodAndFanE = hoodAndFanE;
            HoodAndCommentFanB = hoodAndCommentFanB;
            HoodAndCommentFanE = hoodAndCommentFanE;
            TapsSinksB = tapsSinksB;
            TapsSinksE = tapsSinksE;
            TapsSinksCommentB = tapsSinksCommentB;
            TapsSinksCommentE = tapsSinksCommentE;
            RefrigeratorExteriorB = refrigeratorExteriorB;
            RefrigeratorExteriorE = refrigeratorExteriorE;
            RefrigeratorExteriorCommentB = refrigeratorExteriorCommentB;
            RefrigeratorExteriorCommentE = refrigeratorExteriorCommentE;
            RefrigeratorShelfB = refrigeratorShelfB;
            RefrigeratorShelfE = refrigeratorShelfE;
            RefrigeratorShelfCommentB = refrigeratorShelfCommentB;
            RefrigeratorShelfCommentE = refrigeratorShelfCommentE;
            RefrigeratorFreezerB = refrigeratorFreezerB;
            RefrigeratorFreezerE = refrigeratorFreezerE;
            RefrigeratorFreezerCommentB = refrigeratorFreezerCommentB;
            RefrigeratorFreezerCommentE = refrigeratorFreezerCommentE;
            DishwasherB = dishwasherB;
            DishwasherE = dishwasherE;
            DishwasherCommentB = dishwasherCommentB;
            DishwasherCommentE = dishwasherCommentE;
            StoveB = stoveB;
            StoveE = stoveE;
            StoveCommentB = stoveCommentB;
            StoveCommentE = stoveCommentE;
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



        public ConditionType OvenB { get; private set; }
        public ConditionType OvenE { get; private set; }
        public ConditionType OvenCommentB { get; private set; }
        public ConditionType OvenCommentE { get; private set; }

        public ConditionType CountertopB { get; private set; }
        public ConditionType CountertopE { get; private set; }
        public string CountertopCommentB { get; private set; }
        public string CountertopCommentE { get; private set; }

        public ConditionType CabinetsAndDoorsB { get; private set; }
        public ConditionType CabinetsAndDoorsE { get; private set; }
        public string CabinetsAndDoorsCommentB { get; private set; }
        public string CabinetsAndDoorsCommentE { get; private set; }

        public ConditionType HoodAndFanB { get; private set; }
        public ConditionType HoodAndFanE { get; private set; }
        public string HoodAndCommentFanB { get; private set; }
        public string HoodAndCommentFanE { get; private set; }

        public ConditionType TapsSinksB { get; private set; }
        public ConditionType TapsSinksE { get; private set; }
        public string TapsSinksCommentB { get; private set; }
        public string TapsSinksCommentE { get; private set; }

        public ConditionType RefrigeratorExteriorB { get; private set; }
        public ConditionType RefrigeratorExteriorE { get; private set; }
        public string RefrigeratorExteriorCommentB { get; private set; }
        public string RefrigeratorExteriorCommentE { get; private set; }

        public ConditionType RefrigeratorShelfB { get; private set; }
        public ConditionType RefrigeratorShelfE { get; private set; }
        public string RefrigeratorShelfCommentB { get; private set; }
        public string RefrigeratorShelfCommentE { get; private set; }

        public ConditionType RefrigeratorFreezerB { get; private set; }
        public ConditionType RefrigeratorFreezerE { get; private set; }
        public string RefrigeratorFreezerCommentB { get; private set; }
        public string RefrigeratorFreezerCommentE { get; private set; }


        public ConditionType DishwasherB { get; private set; }
        public ConditionType DishwasherE { get; private set; }
        public string DishwasherCommentB { get; private set; }
        public string DishwasherCommentE { get; private set; }

        public ConditionType StoveB { get; private set; }
        public ConditionType StoveE { get; private set; }
        public string StoveCommentB { get; private set; }
        public string StoveCommentE { get; private set; }

        



        public string Notes { get; private set; }




        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
