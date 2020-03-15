using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class GarageParkingArea : ValueObject
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

        private GarageParkingArea()
        {
        }

        public GarageParkingArea(ConditionType electricalOutletsB, ConditionType electricalOutletsE, 
            string electricalOutletsCommentB, string electricalOutletsCommentE)
        {
            ElectricalOutletsB = electricalOutletsB;
            ElectricalOutletsE = electricalOutletsE;
            ElectricalOutletsCommentB = electricalOutletsCommentB;
            ElectricalOutletsCommentE = electricalOutletsCommentE;
        }

        public ConditionType ElectricalOutletsB { get; private set; }
        public ConditionType ElectricalOutletsE { get; private set; }
        public string ElectricalOutletsCommentB { get; private set; }
        public string ElectricalOutletsCommentE { get; private set; }


        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
