using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateRentPaymentCommandHandler : IRequestHandler<UpdateRentPaymentCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateRentPaymentCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRentPaymentCommand request, CancellationToken cancellationToken)
        {
            var rentPayment = _context.RentPayment.FirstOrDefault(p => p.Id == request.Id);

            var lease = _context.Lease.FirstOrDefault(l => l.Id == rentPayment.LeaseId);

            var updated = lease.UpdatePayment(rentPayment, request.IsOnTime, request.RentAmount, request.PaymentReceivedDate, request.Note);

            _context.RentPayment.Update(updated);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while updating the rent payment {LeaseTile}.", lease.LeaseTitle);
            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
