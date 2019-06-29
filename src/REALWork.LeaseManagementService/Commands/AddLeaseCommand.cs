using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.Lease;

namespace REALWork.LeaseManagementService.Commands
{
    public class AddLeaseCommand: IRequest<Unit>
    {
        /// <summary>
        /// Lease - Main
        /// </summary>
        public string LeaseTitle { get;set; }
        public string LeaseDesc { get;set; }
        public int RentalPropertyId { get;set; }
        public DateTime LeaseStartDate { get;set; }
        public DateTime LeaseEndDate { get;set; }
        public LeaseTerm Term { get;set; }
        public string RentFrequency { get;set; }
        public decimal RentAmount { get;set; }
        public string RentDueOn { get;set; }
        public decimal DamageDepositAmount { get;set; }
        public decimal? PetDepositAmount { get;set; }
        public DateTime LeaseSignDate { get;set; }
        public string LeaseAgreementDocUrl { get;set; }
        public bool IsActive { get;set; }
        public bool IsAddendumAvailable { get;set; }
        public int LeaseEndCode { get; set; }
        public string RenewTerm { get; set; }
        public string Notes { get;set; }

        /// <summary>
        /// Tenant 
        /// </summary>
        public int NewTenantId { get; set; }
        //public string UserName { get;set; }
        //public string FirstName { get;set; }
        //public string LastName { get;set; }
        //public string ContactEmail { get;set; }
        //public string ContactTelephone1 { get;set; }
        //public string ContactTelephone2 { get;set; }
        //public string ContactOthers { get;set; }
        public bool OnlineAccessEnbaled { get;set; }
        public string UserAvartaImgUrl { get;set; }        
        public int RoleId { get;set; }

        /// <summary>
        /// Agent
        /// </summary>
        public string AgentFirstName { get;set; }
        public string AgentLastName { get;set; }
        public string AgentContactEmail { get;set; }
        public string ContatTel { get;set; }
        public string AgentContactOthers { get;set; }
        public bool IsPropertyManager { get;set; }
        public string AddressStreetNumber { get;set; }
        public string AddressCity { get;set; }
        public string AddressStateProv { get;set; }
        public string AddressZipPostCode { get;set; }
        public string AddressCountry { get;set; }

        /// <summary>
        /// Rental Property
        /// </summary>
        public string PropertyName { get;set; }
        public string PropertyType { get;set; }

        /// <summary>
        /// Rental Property Address
        /// </summary>
        public string StreetNum { get;set; }
        public string City { get;set; }
        public string StateProvince { get;set; }
        public string Country { get;set; }
        public string ZipPostCode { get;set; }


        /// <summary>
        /// Rental Coverage
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
        public bool Regfrigerator { get; set; }
        public bool Dishwasher { get; set; }
        public bool StoveOven { get; set; }
        public bool WindowCovering { get; set; }
        public bool Furniture { get; set; }
        public bool Carpets { get; set; }
        public int ParkingStall { get; set; }
        public string Other { get; set; }
    }
}
