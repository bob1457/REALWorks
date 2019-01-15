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
        public bool IsRenewal { get; set; }

    }
}
