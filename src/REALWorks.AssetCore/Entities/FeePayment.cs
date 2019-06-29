using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class FeePayment : Entity
    {

        public enum FeeType
        {
            NotSet,
            Soliciting,
            Management,
            Other
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

        private FeePayment()
        {
        }

        public FeePayment(int managementContractId, decimal scheduledPaymentAmt, decimal actualPaymentAmt, 
            PaymentMethod payMethod, FeeType mangementFeeType, DateTime paymentDueDate, DateTime paymentReceivedDate, 
            /*decimal? balance,*/ bool isOnTime, int inChargeOwnerId, string note, string feeForMonth, string feeForYear,
            DateTime created, DateTime updated)
        {
            ManagementContractId = managementContractId;
            ScheduledPaymentAmt = scheduledPaymentAmt;
            ActualPaymentAmt = actualPaymentAmt;
            PayMethod = payMethod;
            MangementFeeType = mangementFeeType;
            PaymentDueDate = paymentDueDate;
            PaymentReceivedDate = paymentReceivedDate;
            //Balance = balance;
            IsOnTime = isOnTime;
            InChargeOwnerId = inChargeOwnerId;
            Note = note;
            FeeForMonth = feeForMonth;
            FeeForYear = feeForYear;
            Created = created;
            Modified = updated;
        }

        public int ManagementContractId { get; private set; }
        public decimal ScheduledPaymentAmt { get; private set; }
        public decimal ActualPaymentAmt { get; private set; }
        public PaymentMethod PayMethod { get; private set; }
        public FeeType MangementFeeType { get; private set; }
        public DateTime PaymentDueDate { get; private set; }
        public DateTime PaymentReceivedDate { get; private set; }
        public decimal? Balance { get; private set; }
        public bool IsOnTime { get; private set; }
        public int InChargeOwnerId { get; private set; }
        public string Note { get; private set; }
        public string FeeForMonth { get; private set; }
        public string FeeForYear { get; private set; }

        //public DateTime? CreatedOn { get; private set; }
        //public DateTime? UpdatedOn { get; private set; }

        public ManagementContract Contract { get; private set; }
    }
}
