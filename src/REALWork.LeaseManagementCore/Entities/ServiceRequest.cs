using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class ServiceRequest: Entity
    {
        public enum UrgencyLevel
        {
            NotSet,
            Urgent,           
            Regular
        }

        public enum RequestStatus
        {
            NotSet,
            New,
            Opened,
            InProgress,
            OnHold,
            Completed,
            Other
        }

        private ServiceRequest()
        {
        }

        public ServiceRequest(string requestSubject, string serviceCategory, string requestDetails, 
            UrgencyLevel urgent, RequestStatus status, int leaseId, int requestorId, int workOrderId, string notes,
            DateTime created, DateTime updated)
        {
            RequestSubject = requestSubject;
            ServiceCategory = serviceCategory;
            RequestDetails = requestDetails;
            Urgent = urgent;
            Status = status;
            LeaseId = leaseId;
            RequestorId = requestorId;
            WorkOrderId = workOrderId;
            Notes = notes;
            Created = created;
            Modified = updated;
        }

        public string RequestSubject { get; private set; }
        public string ServiceCategory { get; private set; }
        public string RequestDetails { get; private set; }
        public UrgencyLevel Urgent { get; private set; }
        public RequestStatus Status { get; private set; }
        public int LeaseId { get; private set; }
        public int RequestorId { get; private set; }
        public int WorkOrderId { get; private set; }
        public string Notes { get; private set; }

        public Lease Lease { get; set; }
        public ICollection<ServiceRequestComment> ServiceRequestComment { get; set; }


        public ServiceRequest Update(int status, int orderId)
        {
            Status = (RequestStatus)Enum.ToObject(typeof(RequestStatus), status) ;
            WorkOrderId = orderId;
            Modified = DateTime.Now;

            return this;
        }

    }
}
