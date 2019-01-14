using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class ManagementContractDetailsViewModel
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

    /// <summary>
        /// Property 
        /// </summary>
        public string PropertyName { get; set; }        
        public string PropertySuiteNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateProvince { get; set; }
        public string PropertyCountry { get; set; }
        public string PropertyZipPostCode { get; set; }

        /// <summary>
        /// Owner 
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }

        //public string ManagementFeeType1 { get; set; }
        //public decimal ManagementFeeAmount { get; set; }

        //public string ManagementFeeType2 { get; set; }
        //public decimal PlacementFeeAmount { get; set; }
        public string ManagemetnFeeNotes { get; set; }
    }
}
