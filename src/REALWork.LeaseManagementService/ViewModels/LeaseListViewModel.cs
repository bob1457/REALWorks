using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class LeaseListViewModel
    {
        public string LeaseTitle { get; private set; }
        public string LeaseDesc { get; private set; }
        public int RentalPropertyId { get; private set; }
        public DateTime LeaseStartDate { get; private set; }
        public DateTime LeaseEndDate { get; private set; }
        //public LeaseTerm Term { get; private set; }
        public string RentFrequency { get; private set; }
        public decimal RentAmount { get; private set; }
        public string RentDueOn { get; private set; }
        public decimal DamageDepositAmount { get; private set; }
        public decimal? PetDepositAmount { get; private set; }
        public DateTime LeaseSignDate { get; private set; }
        public string LeaseAgreementDocUrl { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsAddendumAvailable { get; private set; }
        public int EndLeaseCode { get; private set; }
        public string RenewTerm { get; private set; }
        public string Notes { get; private set; }

    }
}
