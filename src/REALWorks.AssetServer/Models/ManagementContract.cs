using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class ManagementContract
    {
        public ManagementContract()
        {
            ManagementFee = new HashSet<ManagementFee>();
        }

        public ManagementContract(
            int propertyId,
            string managementContractTitile,
            DateTime startDate,
            DateTime endDate,
            string placementFeeScale,
            string managementFeeScale,
            DateTime contractSignDate,
            string managementContractDocUrl,
            bool isActive//, 
                         //ICollection<ManagementFee> managementFee
            )
        {
            PropertyId = propertyId;
            ManagementContractTitile = managementContractTitile;
            StartDate = startDate;
            EndDate = endDate;
            PlacementFeeScale = placementFeeScale;
            ManagementFeeScale = managementFeeScale;
            ContractSignDate = contractSignDate;
            ManagementContractDocUrl = managementContractDocUrl;
            IsActive = isActive;//;
           // ManagementFee = managementFee;
        }

        public int ManagementContractId { get; set; }
        public string ManagementContractTitile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlacementFeeScale { get; set; }
        public string ManagementFeeScale { get; set; }
        public DateTime ContractSignDate { get; set; }
        public int PropertyId { get; set; }
        public string ManagementContractDocUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Property Property { get; set; }
        public ICollection<ManagementFee> ManagementFee { get; set; }
    }
}
