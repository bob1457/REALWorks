using MediatR;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.Lease;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateLeaseCommand : IRequest<UpdateLeaseAgreementViewModel>
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
        public int LeaseEndCode { get; set; }
        public string RenewTerm { get; set; }
        public string Notes { get; set; }

        /// <summary>
        /// All rent coverage needs to be updated
        /// </summary>
        public bool Water { get; set; }
        public bool Cablevison { get; set; }
        public bool Electricity { get; set; }
        public bool Internet { get; set; }
        public bool Heat { get; set; }
        public bool NaturalGas { get; set; }
        public bool SewageDisposal { get; set; }
        public bool SnowRemoval { get; set; }
        public bool Storage { get; set; }
        public bool RecreationFacility { get; set; }
        public bool GarbageCollection { get; set; }
        public bool RecycleServices { get; set; }
        public bool KitchenScrapCollection { get; set; }
        public bool Laundry { get; set; }
        public bool FreeLaundry { get; set; }
        public bool Regigerator { get; set; }
        public bool Dishwasher { get; set; }
        public bool StoveOven { get; set; }
        public bool WindowCovering { get; set; }
        public bool Furniture { get; set; }
        public bool Carpets { get; set; }
        public int ParkingStall { get; set; }
        public string Other { get; set; }
    }
}
