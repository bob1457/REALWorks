using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.Lease;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class UpdateLeaseAgreementViewModel
    {
        public int Id { get; set; }
        public string LeaseTitle { get; set; }
        public string LeaseDesc { get; set; }
        public int RentalPropertyId { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public LeaseTerm Term { get; set; }
        public string RentFrequency { get; set; }
        public decimal RentAmount { get; set; }
        public string RentDueOn { get; set; }
        public decimal DamageDepositAmount { get; set; }
        public decimal PetDepositAmount { get; set; }
        public DateTime LeaseSignDate { get; set; }
        public string LeaseAgreementDocUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsAddendumAvailable { get; set; }
        public int EndLeaseCode { get; set; }
        public string RenewTerm { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


        /// <summary>
        /// All rent coverage needs to be updated
        /// </summary>
        public RentCoverage rentCoverage { get; set; }

        public List<Tenant> Tenant { get; set; }

        public RentalProperty rentalProperty { get; set; }

        public IList<RentalPropertyOwner> propertyOwners { get; set; }
    }
}
