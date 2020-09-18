using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.ViewModels;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class AddRentPaymentCommandHandler : IRequestHandler<AddRentPaymentCommand, RentPaymentHistoryViewModel>
    {

        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public AddRentPaymentCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }


        public async Task<RentPaymentHistoryViewModel> Handle(AddRentPaymentCommand request, CancellationToken cancellationToken)
        {
           
            var lease = _context.Lease.Include(l => l.Tenant).FirstOrDefault(l => l.Id == request.LeaseId);

            var tenantId = lease.Tenant.FirstOrDefault().Id;
            

            var rent = lease.AddRent(request.LeaseId, /*request.ScheduledPaymentAmt*/lease.RentAmount, request.ActualPaymentAmt, request.PayMethod,
                request.PaymentDueDate, request.PaymentReceivedDate, request.Balance, request.IsOnTime, request.RentalForMonth,
                request.RentalForYear, /*request.InChargeTenantId*/tenantId, request.Note, DateTime.Now, DateTime.Now);

            //var rent = new RentPayment(request.LeaseId, request.ScheduledPaymentAmt, request.ActualPaymentAmt, request.PayMethod,
            //    request.PaymentDueDate, request.PaymentReceivedDate, request.Balance, request.IsOnTime, request.RentalForMonth, 
            //    request.RentalForYear, request.InChargeTenantId, request.Note, DateTime.Now, DateTime.Now);

            _context.RentPayment.Add(rent);

            var added = new RentPaymentHistoryViewModel();

            added.ScheduledPaymentAmt = rent.ScheduledPaymentAmt;
            added.ActualPaymentAmt = rent.ActualPaymentAmt;
            added.PaymentDueDate = rent.PaymentDueDate;
            added.PayMethod = rent.PayMethod;
            added.PaymentDueDate = rent.PaymentDueDate;
            added.PaymentReceivedDate = rent.PaymentReceivedDate;
            added.IsOnTime = rent.IsOnTime;
            added.Note = rent.Note;
            added.Balance = rent.Balance;
            added.RentalForMonth = rent.RentalForMonth;
            added.RentalForYear = rent.RentalForYear;
            added.LeaseId = rent.LeaseId;
            added.Created = rent.Created;
            added.Modified = rent.Modified;


            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY

                added.Id = rent.Id;
                // Send message to MQ if needed - notification
                //

                // Logging
                Log.Information("Rent payment amount of {RentAmt} has been added to lease {LeaseTitle} : ", request.ActualPaymentAmt, lease.LeaseTitle);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while adding rent payment to lease {LeaseTile}.", lease.LeaseTitle);
            }

            return added;

            //throw new NotImplementedException();
        }
    }
}
