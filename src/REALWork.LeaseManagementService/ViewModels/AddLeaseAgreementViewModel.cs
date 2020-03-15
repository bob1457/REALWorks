using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.Lease;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class AddLeaseAgreementViewModel
    {
        // Coped from LeaseListViewModel but with public setter
        //
        public int LeaseId { get; set; }
        public string LeaseTitle { get; set; }
        public string LeaseDesc { get; set; }
        //public int RentalPropertyId { get;  set; }
        public DateTime LeaseStartDate { get;  set; }
        public DateTime LeaseEndDate { get;  set; }
        public LeaseTerm Term { get; set; }
        public string RentFrequency { get;  set; }
        public decimal RentAmount { get;  set; }
        public string RentDueOn { get;  set; }
        public decimal DamageDepositAmount { get;  set; }
        public decimal? PetDepositAmount { get;  set; }
        public DateTime LeaseSignDate { get;  set; }
        public string LeaseAgreementDocUrl { get;  set; }
        public bool IsActive { get;  set; }
        public bool IsAddendumAvailable { get;  set; }
        public int EndLeaseCode { get;  set; }
        public string RenewTerm { get;  set; }
        public string Notes { get;  set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
