using REALWork.LeaseManagementCore.Entities;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class Invoice : Entity
    {
        private Invoice()
        {
        }

        public Invoice(string invoiceTitle, decimal invoiceAmount, DateTime invoiceDate, 
            bool isPaid, DateTime paymentDate, string paymentMethod, decimal? paymentAmount, 
            int workOrderId, DateTime created, DateTime updated)
        {
            InvoiceTitle = invoiceTitle;
            InvoiceAmount = invoiceAmount;
            InvoiceDate = invoiceDate;
            IsPaid = isPaid;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            PaymentAmount = paymentAmount;
            WorkOrderId = workOrderId;
            Created = created;
            Modified = updated;
        }

        public string InvoiceTitle { get; private set; }
        public decimal InvoiceAmount { get; private set; }
        public string InvoiceDocUrl { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public bool IsPaid { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string PaymentMethod { get; private set; }
        public decimal? PaymentAmount { get; private set; }

        public int WorkOrderId { get; private set; }

        public WorkOrder WorkOrder { get; private set; }

        public Invoice Update(decimal paymentAmount, DateTime paymentDate,
            bool isPaid, string paymentMethod)
        {
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
            IsPaid = isPaid;
            PaymentMethod = paymentMethod;
            Modified = DateTime.Now;

            return this;
        }
        
    }
}
