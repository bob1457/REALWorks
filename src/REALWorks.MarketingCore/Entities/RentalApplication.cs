using REALWorks.MarketingCore.Base;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class RentalApplication: Entity
    {
        private RentalApplication()
        {
        }

        public RentalApplication(int propertyId, RentalApplicant rentalApplicant, ApplicationStatus status, 
            DateTime created, DateTime updated)//, Reference rentlReference)
        {
            RentalPropertyId = propertyId;
            RentalApplicant = rentalApplicant;
            //RentalReference = rentlReference;
            Status = status;
            Created = created;
            Modified = updated;
        }

        public enum ApplicationStatus
        {
            NotSet,
            Pending,
            Approved,
            Declined,
            Other
        }

        public int RentalPropertyId { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public string Notes { get; private set; }

        public RentalProperty RentalProperty { get; private set; }
        public RentalApplicant RentalApplicant { get; private set; }
        //public Reference RentalReference { get; private private set; }




        public void AddApplicant(RentalApplicant applicant)
        {
            RentalApplicant = applicant;
        }

        public void StatusUpdate(RentalApplication application, ApplicationStatus status)
        {
            Status = status;
            Modified = DateTime.Now;
        }

    }
}
