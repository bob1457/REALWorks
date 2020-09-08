using REALWork.LeaseManagementCore.ValueObjects;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class WorkOrder: Entity
    {
        private WorkOrder()
        {
        }

        public WorkOrder(string workOrderName, string workOrderDetails, string workOrderCategory, 
            int rentalPropertyId, int vendorId, string workOrderType, DateTime startDate, DateTime endDate, 
            bool isOwnerAuthorized, bool isEmergency, string workOrderStatus, string note, DateTime created, DateTime updated)
        {
            WorkOrderName = workOrderName;
            WorkOrderDetails = workOrderDetails;
            WorkOrderCategory = workOrderCategory;
            RentalPropertyId = rentalPropertyId;
            VendorId = vendorId;
            WorkOrderType = workOrderType;
            //InvoiceAmount = invoiceAmount;
            //InvoiceDocUrl = invoiceDocUrl;
            //InvoiceDate = invoiceDate;
            StartDate = startDate;
            EndDate = endDate;
            IsOwnerAuthorized = isOwnerAuthorized;
            IsEmergency = isEmergency;
            WorkOrderStatus = workOrderStatus;
            //IsPaid = isPaid;
            //PaymentDate = paymentDate;
            //PaymentMethod = paymentMethod;
            //PaymentAmount = paymentAmount;            
            Note = note;
            Created = created;
            Modified = updated;
        }

        public string WorkOrderName { get; private set; }
        public string WorkOrderDetails { get; private set; }
        public string WorkOrderCategory { get; private set; }
        public int RentalPropertyId { get; private set; }
        public int VendorId { get; private set; }
        public string WorkOrderType { get; private set; }
        //public decimal InvoiceAmount { get; private set; }
        //public string InvoiceDocUrl { get; private set; }
        //public DateTime InvoiceDate { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool IsOwnerAuthorized { get; private set; }
        public bool IsEmergency { get; private set; }
        public string WorkOrderStatus { get; private set; }
        //public bool IsPaid { get; private set; }
        //public DateTime PaymentDate { get; private set; }
        //public string PaymentMethod { get; private set; }
        //public decimal? PaymentAmount { get; private set; }        
        public string Note { get; private set; }

        public RentalProperty RentalProperty { get; private set; }
        public Invoice Invoice { get; private set; }
        public Vendor Vendor { get; private set; }


        public WorkOrder Update(string workOrderDetails, string workOrderCategory, string workOrderType, DateTime startDate, 
            DateTime endDate, string orderStatus, string note)
        {
            WorkOrderDetails = workOrderDetails;
            WorkOrderCategory = workOrderCategory;
            WorkOrderType = workOrderType;
            StartDate = startDate;
            EndDate = endDate;
            WorkOrderStatus = orderStatus;
            Modified = DateTime.Now;

            return this;
        }


        public Invoice AddInvoice(string invoiceTitle, decimal invoiceAmount, DateTime invoiceDate,
            bool isPaid, DateTime paymentDate, string paymentMethod, decimal? paymentAmount,
            int workOrderId)
        {
            var invoice = new Invoice(invoiceTitle, invoiceAmount, invoiceDate, isPaid, paymentDate, paymentMethod, paymentAmount, workOrderId,
                DateTime.Now, DateTime.Now);
                        

            return invoice;

        }


        

        public Invoice UpdateInvoice(Invoice invoice, decimal paymentAmount, DateTime paymentDate,
            bool isPaid, string paymentMethod)
        {
            return invoice.Update(paymentAmount, paymentDate, isPaid, paymentMethod);
        }
    }
}
