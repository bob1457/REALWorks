﻿using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class MainBathroom : ValueObject
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

        private MainBathroom()
        {
        }

        public MainBathroom(ConditionType wallAndTrimeB, ConditionType wallAndTrimeE, string wallAndTrimsCommentB, 
            string wallAndTrimsCommentE, ConditionType ceilingsB, ConditionType ceilingsE, string ceilingsCommentB, 
            string ceilingsCommentE, ConditionType closetsB, ConditionType closetsE, string closetsCommentB, 
            string closetsCommentE, ConditionType toiletB, ConditionType toiletE, string toiletCommentB, string toiletCommentE, 
            ConditionType doorB, ConditionType doorE, string doorCommentB, string doorCommentE, ConditionType sinkB, 
            ConditionType sinkE, string sinkCommentB, string sinkCommentE, ConditionType showerTubB, ConditionType showerTubE, 
            string showerTubCommentB, string showerTubCommentE, ConditionType lightingB, ConditionType lightingE, string lightingCommentB, 
            string lightingCommentE, ConditionType windowsCoveringB, ConditionType windowsCoveringE, ConditionType windowsCoveringCommentB, 
            ConditionType windowsCoveringCommentE, ConditionType electricalOutletsB, ConditionType electricalOutletsE, string electricalOutletsCommentB, 
            string electricalOutletsCommentE, ConditionType floorCarpetB, ConditionType floorCarpetE, string floorCarpetCommentB, string floorCarpetCommentE)
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
            ToiletB = toiletB;
            ToiletE = toiletE;
            ToiletCommentB = toiletCommentB;
            ToiletCommentE = toiletCommentE;
            DoorB = doorB;
            DoorE = doorE;
            DoorCommentB = doorCommentB;
            DoorCommentE = doorCommentE;
            SinkB = sinkB;
            SinkE = sinkE;
            SinkCommentB = sinkCommentB;
            SinkCommentE = sinkCommentE;
            ShowerTubB = showerTubB;
            ShowerTubE = showerTubE;
            ShowerTubCommentB = showerTubCommentB;
            ShowerTubCommentE = showerTubCommentE;
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
        }

        public ConditionType WallAndTrimeB { get; private set; } // Begin Comment
        public ConditionType WallAndTrimeE { get; private set; } // End
        public string WallAndTrimsCommentB { get; private set; }
        public string WallAndTrimsCommentE { get; private set; }

        public ConditionType CeilingsB { get; private set; }
        public ConditionType CeilingsE { get; private set; }
        public string CeilingsCommentB { get; private set; }
        public string CeilingsCommentE { get; private set; }

        public ConditionType ClosetsB { get; private set; } //
        public ConditionType ClosetsE { get; private set; }
        public string ClosetsCommentB { get; private set; }
        public string ClosetsCommentE { get; private set; }

        public ConditionType ToiletB { get; private set; } //
        public ConditionType ToiletE { get; private set; }
        public string ToiletCommentB { get; private set; }
        public string ToiletCommentE { get; private set; }

        public ConditionType DoorB { get; private set; }
        public ConditionType DoorE { get; private set; }
        public string DoorCommentB { get; private set; }
        public string DoorCommentE { get; private set; }

        public ConditionType SinkB { get; private set; }
        public ConditionType SinkE { get; private set; }
        public string SinkCommentB { get; private set; }
        public string SinkCommentE { get; private set; }

        public ConditionType ShowerTubB { get; private set; }
        public ConditionType ShowerTubE { get; private set; }
        public string ShowerTubCommentB { get; private set; }
        public string ShowerTubCommentE { get; private set; }

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


        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
