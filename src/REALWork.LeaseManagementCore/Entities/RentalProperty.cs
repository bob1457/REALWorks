using REALWork.LeaseManagementCore.Base;
using REALWork.LeaseManagementCore.ValueObjects;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class RentalProperty: Entity, IAggregateRoot
    {
        private RentalProperty()
        {
        }

        public RentalProperty(int originalId, DateTime created, DateTime modified, int listinglId, string propertyName, 
            string propertyType, int propertyBuildYear, bool isShared, string status, bool isBasementSuite, 
            int numberOfBedrooms, int numberOfBathrooms, int numberOfLayers, int numberOfParking, 
            int totalLivingArea, string notes, string pmUserName, Address address, ICollection<RentalPropertyOwner> rentalPropertyOwners)
        {
            OriginalId = originalId;
            Created = created;
            Modified = modified;
            ListinglId = listinglId;
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyBuildYear = propertyBuildYear;
            IsShared = isShared;
            Status = status; // Pending, In Processing Rented
            IsBasementSuite = isBasementSuite;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfLayers = numberOfLayers;
            NumberOfParking = numberOfParking;
            TotalLivingArea = totalLivingArea;
            Notes = notes;
            PmUserName = pmUserName;
            Address = address;
            RentalPropertyOwners = rentalPropertyOwners;
        }

        public RentalProperty(int originalId, DateTime created, DateTime modified, int listinglId, string propertyName,
            string propertyType, int propertyBuildYear, bool isShared, string status, bool isBasementSuite,
            int numberOfBedrooms, int numberOfBathrooms, int numberOfLayers, int numberOfParking,
            int totalLivingArea, string notes, string pmUserName, Address address)
        {
            OriginalId = originalId;
            Created = created;
            Modified = modified;
            ListinglId = listinglId;
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyBuildYear = propertyBuildYear;
            IsShared = isShared;
            Status = status; // Pending, In Processing Rented
            IsBasementSuite = isBasementSuite;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfLayers = numberOfLayers;
            NumberOfParking = numberOfParking;
            TotalLivingArea = totalLivingArea;
            Notes = notes;
            PmUserName = pmUserName;
            Address = address;            
        }

        public int OriginalId { get; private set; }
        //public DateTime Created { get; private set; }
        //public DateTime Modified { get; private set; }
        public int ListinglId { get; private set; }
        public string PropertyName { get; private set; }
        public string PropertyType { get; private set; }
        public int PropertyBuildYear { get; private set; }
        public bool IsShared { get; private set; }
        public string Status { get; private set; }
        public bool IsBasementSuite { get; private set; }
        public int NumberOfBedrooms { get; private set; }
        public int NumberOfBathrooms { get; private set; }
        public int NumberOfLayers { get; private set; }
        public int NumberOfParking { get; private set; }
        public int TotalLivingArea { get; private set; }
        public string Notes { get; private set; }
        public string PmUserName { get; private set; }

        public Address Address { get; private set; }
        public ICollection<Lease> Lease { get; private set; }
        public ICollection<PropertyVisit> PropertyVisit { get; private set; }

        public ICollection<RentalPropertyOwner> RentalPropertyOwners { get; private set; }

        public ICollection<WorkOrder> WorkOrder { get; private set; }


        public void StatusUpdate(string status)
        {
            Status = status;
        }

        public WorkOrder AddWorkOrder(string WorkOrderName, string WorkOrderDetails, string WorkOrderCategory, int RentalPropertyId,
            int VendorId, string WorkOrderType, DateTime StartDate, DateTime EndDate, bool IsOwnerAuthorized, bool IsEmergency,
            string WorkOrderStatus, string Note)        {
            var order = new WorkOrder(WorkOrderName, WorkOrderDetails, WorkOrderCategory, RentalPropertyId, VendorId,
                WorkOrderType, StartDate, EndDate, IsOwnerAuthorized, IsEmergency, WorkOrderStatus, Note, DateTime.Now, DateTime.Now);

            return order;
        }
    }
}
