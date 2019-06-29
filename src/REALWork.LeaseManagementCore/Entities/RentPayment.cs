using REALWork.LeaseManagementCore.Entities;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class RentPayment : Entity
    {
        private RentPayment()
        {
        }

        public enum PaymentMethod
        {
            NotSet,
            Cash,
            Cheque,
            ETransfer,
            BankTransfer,
            PreAuthorized,
            Online,
            Other
        }

        public RentPayment(int leaseId, decimal scheduledPaymentAmt, decimal actualPaymentAmt, PaymentMethod method,
            DateTime? paymentDueDate, DateTime? paymentReceivedDate, decimal? balance, bool isOnTime, 
            string rentalMonth, string rentalYear,
            int inChargeTenantId, string note, DateTime createdOn, DateTime updatedOn)
        {
            LeaseId = leaseId;
            ScheduledPaymentAmt = scheduledPaymentAmt;
            ActualPaymentAmt = actualPaymentAmt;
            PayMethod = method;
            PaymentDueDate = paymentDueDate;
            PaymentReceivedDate = paymentReceivedDate;
            Balance = balance;
            IsOnTime = isOnTime;
            RentalForMonth = rentalMonth;
            RentalForYear = rentalYear;
            InChargeTenantId = inChargeTenantId;
            Note = note;
            Created = createdOn;
            Modified = updatedOn;
        }

        public int LeaseId { get; private set; }
        public decimal ScheduledPaymentAmt { get; private set; }
        public decimal ActualPaymentAmt { get; private set; }
        public PaymentMethod PayMethod { get; private set; }
        public DateTime? PaymentDueDate { get; private set; }
        public DateTime? PaymentReceivedDate { get; private set; }
        public decimal? Balance { get; private set; }
        public bool IsOnTime { get; private set; }
        public int InChargeTenantId { get; private set; }
        public string Note { get; private set; }
        public string RentalForMonth { get; private set; }
        public string RentalForYear { get; private set; }

        //public DateTime? CreatedOn { get; private set; }
        //public DateTime? UpdatedOn { get; private set; }

        public Lease Lease { get; private set; }    
        

        //public RentPayment Add( int LeaseId, decimal ScheduledPaymentAmt, decimal ActualPaymentAmt, PaymentMethod PayMethod,
        //        DateTime PaymentDueDate, DateTime PaymentReceivedDate, decimal Balance, bool IsOnTime, string RentalForMonth,
        //        string RentalForYear, int InChargeTenantId, string Note, DateTime added, DateTime updated)
        //{
        //    var rent = new RentPayment(LeaseId, ScheduledPaymentAmt, ActualPaymentAmt, PayMethod,
        //        PaymentDueDate, PaymentReceivedDate, Balance, IsOnTime, RentalForMonth,
        //        RentalForYear, InChargeTenantId, Note, DateTime.Now, DateTime.Now);

        //    return rent;
        //}

        public RentPayment Update(bool onTime, decimal receivedAmnt, DateTime receivedDate, string note)
        {
            IsOnTime = onTime;
            ActualPaymentAmt = receivedAmnt;
            PaymentReceivedDate = receivedDate;
            Note = note;
            Modified = DateTime.Now;

            return this;
        }
        
    }
}
