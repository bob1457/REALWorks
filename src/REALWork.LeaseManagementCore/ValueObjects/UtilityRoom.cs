using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class UtilityRoom : ValueObject
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

        private UtilityRoom()
        {
        }

        public UtilityRoom(ConditionType electricalOutletsB, ConditionType electricalOutletsE, string electricalOutletsCommentB, 
            string electricalOutletsCommentE, ConditionType washerDryerB, ConditionType washerDryerE, string washerDryerCommentB, 
            string washerDryerCommentE)
        {
            ElectricalOutletsB = electricalOutletsB;
            ElectricalOutletsE = electricalOutletsE;
            ElectricalOutletsCommentB = electricalOutletsCommentB;
            ElectricalOutletsCommentE = electricalOutletsCommentE;
            WasherDryerB = washerDryerB;
            WasherDryerE = washerDryerE;
            WasherDryerCommentB = washerDryerCommentB;
            WasherDryerCommentE = washerDryerCommentE;
        }

        public ConditionType ElectricalOutletsB { get; private set; }
        public ConditionType ElectricalOutletsE { get; private set; }
        public string ElectricalOutletsCommentB { get; private set; }
        public string ElectricalOutletsCommentE { get; private set; }

        public ConditionType WasherDryerB { get; private set; }
        public ConditionType WasherDryerE { get; private set; }
        public string WasherDryerCommentB { get; private set; }
        public string WasherDryerCommentE { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
