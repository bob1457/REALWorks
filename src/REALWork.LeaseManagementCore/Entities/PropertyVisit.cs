using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class PropertyVisit: Entity
    {
        private PropertyVisit()
        {
        }

        public PropertyVisit(int rentalPropertyId, string visitPurpose, string mileageDriven, 
            string timeSpent, DateTime visitDate, string visitStartTime, string visitEndTime, 
            decimal hoursSpent, DateTime createdOn, DateTime updatedOn, string notes)
        {
            RentalPropertyId = rentalPropertyId;
            VisitPurpose = visitPurpose;
            MileageDriven = mileageDriven;
            TimeSpent = timeSpent;
            VisitDate = visitDate;
            VisitStartTime = visitStartTime;
            VisitEndTime = visitEndTime;
            HoursSpent = hoursSpent;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            Notes = notes;
        }

        public int RentalPropertyId { get; private set; }
        public string VisitPurpose { get; private set; }
        public string MileageDriven { get; private set; }
        public string TimeSpent { get; private set; }
        public DateTime VisitDate { get; private set; }
        public string VisitStartTime { get; private set; }
        public string VisitEndTime { get; private set; }
        public decimal HoursSpent { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public string Notes { get; private set; }

        public RentalProperty RentalProperty { get; private set; }
    }
}
