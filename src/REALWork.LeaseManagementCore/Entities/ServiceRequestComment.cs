using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class ServiceRequestComment: Entity
    {
        public ServiceRequestComment(int serviceRequestId, 
            string comment, int responderId, string notes)
        {
            ServiceRequestId = serviceRequestId;
            Comment = comment;
            ResponderId = responderId;
            Notes = notes;
        }

        private ServiceRequestComment()
        {
        }

        public int ServiceRequestId { get; private set; }
        public string Comment { get; private set; }
        public int ResponderId { get; private set; }
        public string Notes { get; private set; }

        public ServiceRequest ServiceRequest { get; private set; }
    }
}
