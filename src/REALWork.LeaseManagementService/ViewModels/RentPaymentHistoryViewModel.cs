﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.RentPayment;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class RentPaymentHistoryViewModel
    {
        //public int LeaseId { get;  set; }
        public decimal ScheduledPaymentAmt { get; set; }
        public decimal ActualPaymentAmt { get; set; }
        public PaymentMethod PayMethod { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? PaymentReceivedDate { get; set; }
        public decimal? Balance { get; set; }
        public bool IsOnTime { get; set; }
        //public int InChargeTenantId { get;  set; }
        public string Note { get;  set; }
        public string RentalForMonth { get; set; }
        public string RentalForYear { get; set; }

        public int LeaseId { get; set; }

        public int Id { get; set; }
        public string LeaseTitle { get; set; }

        public string PropertyName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
