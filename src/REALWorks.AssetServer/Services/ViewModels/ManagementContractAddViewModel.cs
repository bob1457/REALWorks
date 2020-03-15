using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class ManagementContractAddViewModel
    {
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
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        //public string PropertyName { get; set; }

        //public string ManagementFeeType1 { get; set; }
        //public decimal ManagementFeeAmount { get; set; }

        //public string ManagementFeeType2 { get; set; }
        //public decimal PlacementFeeAmount { get; set; }
        public string ManagemetnFeeNotes { get; set; }

        

    }
}
