using REALWork.LeaseManagementCore.ValueObjects;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class PropertyInspection : Entity
    {
        //public enum InspectionTarget
        //{
        //    NotSet,
        //    Entry,
        //    Kitchen,
        //    LivingRoom,
        //    DinningRoom,
        //    StairWayHallWay,
        //    MainBathroom,            
        //    MasterBedroom,
        //    OtherBedroom,
        //    Exterior,
        //    UtilityRoom,
        //    GarageParkingArea,
        //    Basement,
        //    Storage,
        //    KeyAndControl,
        //    Others
        //}


        public DateTime MoveInDate { get; private set; }
        public DateTime MoveOutDate { get; private set; }
        public DateTime MoveInInspectionDate { get; private set; }
        public DateTime MoveOutIspectionDate { get; private set; }
        public string MoveInInspectionReportDocUrl { get; private set; }
        public string MoveOutInspectionReportDocUrl { get; private set; }

        public int LeaseId { get; private set; }

        public Entry EntryCondition { get; private set; }
        public Kitchen KitchenCondition { get; private set; }
        public LivingRoom LivingRoomCondition { get; private set; }
        public DinningRoom DinningRoomCondition { get; private set; }
        public StairWayHallWay StairWayHallWayCondition { get; private set; }
        public MainBathroom MainBathroomCondition { get; private set; }
        public MasterBedroom MasterBedroomCondition { get; private set; }
        public OtherBedroom OtherBedroomCondition { get; private set; }
        public Exterior ExteriorCondition { get; private set; }
        public UtilityRoom UtilityRoomCondition { get; private set; }
        public GarageParkingArea GarageParkingAreaCondition { get; private set; }
        public Basement BasementCondition { get; private set; }
        public Storage StorageCondition { get; private set; }
        public KeyAndControl KeyAndControlCondition { get; private set; }   
        
        public Lease Lease { get; private set; }


    }
}
