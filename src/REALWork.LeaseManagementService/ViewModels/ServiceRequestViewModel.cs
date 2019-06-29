using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.ServiceRequest;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class ServiceRequestViewModel
    {
        public string RequestSubject { get; set; }
        public string ServiceCategory { get; set; }
        public string RequestDetails { get; set; }
        public UrgencyLevel Urgent { get; set; }
        public RequestStatus Status { get; set; }        
        public string Notes { get; set; }

        public int LeaseId { get; set; }
        public string LeaseTitle { get; set; }
        public string LeaseDesc { get; set; }

        public int RentalPropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public int PropertyBuildYear { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }

        public string WorkOrderName { get; set; }

    }
}
