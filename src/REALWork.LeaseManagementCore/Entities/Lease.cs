using REALWork.LeaseManagementCore.Base;
using REALWork.LeaseManagementCore.ValueObjects;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static REALWork.LeaseManagementCore.Entities.RentPayment;

namespace REALWork.LeaseManagementCore.Entities
{
    public class Lease: Entity, IAggregateRoot
    {
        private Lease()
        {
        }

        public enum LeaseTerm
        {
            NotSet,
            OneYear,
            ThreeMonth,
            SixMOnth,
            Other
        }

        public Lease(string leaseTitle, string leaseDesc, int rentalPropertyId, 
            DateTime leaseStartDate, DateTime leaseEndDate, LeaseTerm term, 
            string rentFrequency, decimal rentAmount, string rentDueOn, 
            decimal damageDepositAmount, decimal? petDepositAmount, DateTime leaseSignDate, 
            string leaseAgreementDocUrl, bool isActive, bool isAddendumAvailable, int endCode,
            string notes, DateTime creationDate, DateTime updateDate,  string renewTerm,
            RentCoverage rentCoverage, ICollection<Agent> agent, ICollection<Tenant> tenant)
        {
            LeaseTitle = leaseTitle;
            LeaseDesc = leaseDesc;
            RentalPropertyId = rentalPropertyId;
            LeaseStartDate = leaseStartDate;
            LeaseEndDate = leaseEndDate;
            Term = term;
            RentFrequency = rentFrequency;
            RentAmount = rentAmount;
            RentDueOn = rentDueOn;
            DamageDepositAmount = damageDepositAmount;
            PetDepositAmount = petDepositAmount;
            LeaseSignDate = leaseSignDate;
            LeaseAgreementDocUrl = leaseAgreementDocUrl;
            IsActive = isActive;
            IsAddendumAvailable = isAddendumAvailable;
            EndLeaseCode = endCode;  // 1: renew month by month, 2: renew by other term, 3: fixed term and renew by term, 4: fixed term and vacant, 0: n/a 
            RenewTerm = renewTerm;
            Notes = notes;
            Created = creationDate;
            Modified = updateDate;
            
            RentCoverage = rentCoverage;
            Agent = agent;
            Tenant = tenant;
        }

        public object Include()
        {
            throw new NotImplementedException();
        }

        public string LeaseTitle { get; private set; }
        public string LeaseDesc { get; private set; }
        public int RentalPropertyId { get; private set; }
        public DateTime LeaseStartDate { get; private set; }
        public DateTime LeaseEndDate { get; private set; }
        public LeaseTerm Term { get; private set; }
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

        public RentalProperty RentalProperty { get; private set; }
        public RentCoverage RentCoverage { get; private set; }
        public ICollection<Agent> Agent { get; private set; }
        public ICollection<RentPayment> RentPayment { get; private set; }
        public ICollection<Tenant> Tenant { get; set; }

        public ICollection<ServiceRequest> ServiceRequest { get; private set; }

        public ICollection<PropertyInspection> PropertyInspection { get; private set; }


        public void Update(string leaseTitle, string leaseDesc, DateTime startDate, DateTime endDate, LeaseTerm term,
            string rentFrequency, decimal rentAmount, string rentDueOn, decimal damageDeposit, decimal petDisposit, DateTime signDate, 
            bool isActive, bool addudum, int endCode, string renewTerm, string notes, RentCoverage rentCoverage)
        {
            LeaseTitle = leaseTitle;
            LeaseDesc = LeaseDesc;
            LeaseStartDate = startDate;
            LeaseEndDate = endDate;
            Term = term;
            RentFrequency = rentFrequency;
            RentAmount = rentAmount;
            RentDueOn = rentDueOn;
            DamageDepositAmount = damageDeposit;
            PetDepositAmount = petDisposit;
            LeaseSignDate = signDate;
            IsActive = isActive;
            IsAddendumAvailable = addudum;
            EndLeaseCode = endCode;
            RenewTerm = renewTerm;
            Modified = DateTime.Now;
            RentCoverage = rentCoverage;
        }


        public Tenant UpdateTenant(Tenant tenant, string firstName, string lastName, string contactEmail, string contactTel1, 
            string contactTel2, string contactOthers)
        {
            tenant.Update(firstName, lastName, contactEmail, contactTel1,
            contactTel2, contactOthers);

            return tenant;
        }

        public RentalProperty UpdatePropertyStatus(RentalProperty property, string status)
        {
            property.StatusUpdate(status);

            return property;
        }

        public Lease Finalize(DateTime signDate)
        {
            LeaseSignDate = signDate;

            return this;
        }

        public RentPayment AddRent(int LeaseId, decimal ScheduledPaymentAmt, decimal ActualPaymentAmt, PaymentMethod PayMethod,
                DateTime PaymentDueDate, DateTime PaymentReceivedDate, decimal Balance, bool IsOnTime, string RentalForMonth,
                string RentalForYear, int InChargeTenantId, string Note, DateTime added, DateTime updated)
        {
            var rent = new RentPayment(LeaseId, ScheduledPaymentAmt, ActualPaymentAmt, PayMethod,
                PaymentDueDate, PaymentReceivedDate, Balance, IsOnTime, RentalForMonth,
                RentalForYear, InChargeTenantId, Note, DateTime.Now, DateTime.Now);

            return rent;

        }

        public RentPayment UpdatePayment(RentPayment rent, bool onTime, decimal receivedAmnt, DateTime receivedDate, string note)
        {
            return rent.Update(onTime, receivedAmnt, receivedDate, note);
        }

        public ServiceRequest UpdateServiceRequest(ServiceRequest request, int status, int workOrderId)
        {
            var updated = request.Update(status, workOrderId);

            return updated;
        }
    }
}
