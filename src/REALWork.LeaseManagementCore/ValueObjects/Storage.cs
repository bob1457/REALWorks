using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class Storage : ValueObject
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

        private Storage()
        {
        }

        public Storage(ConditionType conditionB, ConditionType conditionE, string conditionCommentB, string conditionCommentE)
        {
            ConditionB = conditionB;
            ConditionE = conditionE;
            ConditionCommentB = conditionCommentB;
            ConditionCommentE = conditionCommentE;
        }

        public ConditionType ConditionB { get; private set; }
        public ConditionType ConditionE { get; private set; }
        public string ConditionCommentB { get; private set; }
        public string ConditionCommentE { get; private set; }


        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
