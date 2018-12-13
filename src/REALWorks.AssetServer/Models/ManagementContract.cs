using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class ManagementContract
    {
        public ManagementContract()
        {
            
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
            bool isActive,
            bool isRenewal
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
            IsActive = isActive;
            IsRenewal = isRenewal;
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
        public string ContentTemplateUrl { get; set; }
        public bool IsActive { get; set; }
        public bool? IsRenewal { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Property Property { get; set; }
    }
}
