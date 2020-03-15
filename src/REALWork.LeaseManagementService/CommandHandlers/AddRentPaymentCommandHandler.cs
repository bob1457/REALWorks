using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class AddRentPaymentCommandHandler : IRequestHandler<AddRentPaymentCommand, Unit>
    {

        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public AddRentPaymentCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }


        public async Task<Unit> Handle(AddRentPaymentCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);

            var rent = lease.AddRent(request.LeaseId, request.ScheduledPaymentAmt, request.ActualPaymentAmt, request.PayMethod,
                request.PaymentDueDate, request.PaymentReceivedDate, request.Balance, request.IsOnTime, request.RentalForMonth,
                request.RentalForYear, request.InChargeTenantId, request.Note, DateTime.Now, DateTime.Now);

            //var rent = new RentPayment(request.LeaseId, request.ScheduledPaymentAmt, request.ActualPaymentAmt, request.PayMethod,
            //    request.PaymentDueDate, request.PaymentReceivedDate, request.Balance, request.IsOnTime, request.RentalForMonth, 
            //    request.RentalForYear, request.InChargeTenantId, request.Note, DateTime.Now, DateTime.Now);

            _context.RentPayment.Add(rent);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY


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

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
