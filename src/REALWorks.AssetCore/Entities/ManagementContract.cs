using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class ManagementContract: Entity
    {
        public enum ContractType
        {
            UnSet,
            New,
            Renewal,
            Others
        }

        public ManagementContract() { }

        public ManagementContract(string managementContractTitle, ContractType contractType, DateTime startDate, 
            DateTime endDate, string placementFeeScale, string managementFeeScale, 
            DateTime contractSignDate, int propertyId,   
            bool isActive, string notes, DateTime created, DateTime updated)
        {
            ManagementContractTitle = managementContractTitle;
            Type = contractType;
            StartDate = startDate;
            EndDate = endDate;
            PlacementFeeScale = placementFeeScale;
            ManagementFeeScale = managementFeeScale;
            ContractSignDate = contractSignDate;
            PropertyId = propertyId;
            IsActive = isActive;
            Notes = notes;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        public string ManagementContractTitle { get; private set; }
        public ContractType Type { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string PlacementFeeScale { get; private set; }
        public string ManagementFeeScale { get; private set; }
        public DateTime ContractSignDate { get; private set; }
        public int PropertyId { get; private set; }
        public string ManagementContractDocUrl { get; private set; }
        public bool IsActive { get; private set; }
        public string Notes { get; private set; }

        public Property Property { get; set; }
        public ICollection<FeePayment> FeePayment { get; private set; }





        public void Update(string title, DateTime startDate, DateTime endDate, 
            string placementFeeScale, string managementFeeScale, string notes)
        {
            ManagementContractTitle = title;
            StartDate = startDate;
            EndDate = endDate;
            PlacementFeeScale = placementFeeScale;
            ManagementFeeScale = managementFeeScale;
            Notes = notes;
            Modified = DateTime.Now;
        }

        public ManagementContract SetStatus(ManagementContract contract, bool status)
        {
             contract.IsActive = status;

            return contract;
        }
    }
}
