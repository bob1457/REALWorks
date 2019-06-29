using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class Exterior : ValueObject
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

        private Exterior()
        {
        }

        public Exterior(ConditionType lightingB, ConditionType lightingE, string lightingCommentB, string lightingCommentE, 
            ConditionType windowsCoveringB, ConditionType windowsCoveringE, ConditionType windowsCoveringCommentB, 
            ConditionType windowsCoveringCommentE, ConditionType entrancesB, ConditionType entrancesE, string entrancesCommentB, 
            string entrancesCommentE, ConditionType patioBalconyDoorsB, ConditionType patioBalconyDoorsE, ConditionType patioBalconyDoorsCommentB, 
            ConditionType patioBalconyDoorsCommentE, ConditionType garbageContainersB, ConditionType garbageContainersE, 
            ConditionType garbageContainersCommentB, ConditionType garbageContainersCommentE, ConditionType glassAndFramesB, 
            ConditionType glassAndFramesE, ConditionType glassAndFramesCommentB, ConditionType glassAndFramesCommentE, ConditionType stuccoSidingB, 
            ConditionType stuccoSidingE, ConditionType stuccoSidingCommentB, ConditionType stuccoSidingCommentE, ConditionType groundsAndWalksB, 
            ConditionType groundsAndWalksE, ConditionType groundsAndWalksCommentB, ConditionType groundsAndWalksCommentE)
        {
            LightingB = lightingB;
            LightingE = lightingE;
            LightingCommentB = lightingCommentB;
            LightingCommentE = lightingCommentE;
            WindowsCoveringB = windowsCoveringB;
            WindowsCoveringE = windowsCoveringE;
            WindowsCoveringCommentB = windowsCoveringCommentB;
            WindowsCoveringCommentE = windowsCoveringCommentE;
            EntrancesB = entrancesB;
            EntrancesE = entrancesE;
            EntrancesCommentB = entrancesCommentB;
            EntrancesCommentE = entrancesCommentE;
            PatioBalconyDoorsB = patioBalconyDoorsB;
            PatioBalconyDoorsE = patioBalconyDoorsE;
            PatioBalconyDoorsCommentB = patioBalconyDoorsCommentB;
            PatioBalconyDoorsCommentE = patioBalconyDoorsCommentE;
            GarbageContainersB = garbageContainersB;
            GarbageContainersE = garbageContainersE;
            GarbageContainersCommentB = garbageContainersCommentB;
            GarbageContainersCommentE = garbageContainersCommentE;
            GlassAndFramesB = glassAndFramesB;
            GlassAndFramesE = glassAndFramesE;
            GlassAndFramesCommentB = glassAndFramesCommentB;
            GlassAndFramesCommentE = glassAndFramesCommentE;
            StuccoSidingB = stuccoSidingB;
            StuccoSidingE = stuccoSidingE;
            StuccoSidingCommentB = stuccoSidingCommentB;
            StuccoSidingCommentE = stuccoSidingCommentE;
            GroundsAndWalksB = groundsAndWalksB;
            GroundsAndWalksE = groundsAndWalksE;
            GroundsAndWalksCommentB = groundsAndWalksCommentB;
            GroundsAndWalksCommentE = groundsAndWalksCommentE;
        }

        public ConditionType LightingB { get; private set; }
        public ConditionType LightingE { get; private set; }
        public string LightingCommentB { get; private set; }
        public string LightingCommentE { get; private set; }

        public ConditionType WindowsCoveringB { get; private set; }
        public ConditionType WindowsCoveringE { get; private set; }
        public ConditionType WindowsCoveringCommentB { get; private set; }
        public ConditionType WindowsCoveringCommentE { get; private set; }

        public ConditionType EntrancesB { get; private set; }
        public ConditionType EntrancesE { get; private set; }
        public string EntrancesCommentB { get; private set; }
        public string EntrancesCommentE { get; private set; }

        public ConditionType PatioBalconyDoorsB { get; private set; }
        public ConditionType PatioBalconyDoorsE { get; private set; }
        public ConditionType PatioBalconyDoorsCommentB { get; private set; }
        public ConditionType PatioBalconyDoorsCommentE { get; private set; }

        public ConditionType GarbageContainersB { get; private set; }
        public ConditionType GarbageContainersE { get; private set; }
        public ConditionType GarbageContainersCommentB { get; private set; }
        public ConditionType GarbageContainersCommentE { get; private set; }

        public ConditionType GlassAndFramesB { get; private set; }
        public ConditionType GlassAndFramesE { get; private set; }
        public ConditionType GlassAndFramesCommentB { get; private set; }
        public ConditionType GlassAndFramesCommentE { get; private set; }

        public ConditionType StuccoSidingB { get; private set; }
        public ConditionType StuccoSidingE { get; private set; }
        public ConditionType StuccoSidingCommentB { get; private set; }
        public ConditionType StuccoSidingCommentE { get; private set; }

        public ConditionType GroundsAndWalksB { get; private set; }
        public ConditionType GroundsAndWalksE { get; private set; }
        public ConditionType GroundsAndWalksCommentB { get; private set; }
        public ConditionType GroundsAndWalksCommentE { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
