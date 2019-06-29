using MediatR;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class AddFeePaymentCommandHandler : IRequestHandler<AddFeePaymentCommand, Unit>
    {
        private readonly AppDataBaseContext _context;

        public AddFeePaymentCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddFeePaymentCommand request, CancellationToken cancellationToken)
        {
            var fee = new FeePayment(request.ManagementContractId, request.ScheduledPaymentAmt, request.ActualPaymentAmt,
                request.PayMethod, request.MangementFeeType, request.PaymentDueDate, request.PaymentReceivedDate, request.IsOnTime,
                request.InChargeOwnerId, request.Note, request.FeeForMonth, request.FeeForYear, DateTime.Now, DateTime.Now);

            _context.FeePayment.Add(fee);

            try
            {
                await _context.SaveChangesAsync();

                // logging

                // Send messages if necessary

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
