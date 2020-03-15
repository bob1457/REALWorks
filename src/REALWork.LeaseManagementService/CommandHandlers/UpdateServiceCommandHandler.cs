using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateServiceCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }


        public Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var req = _context.Request.FirstOrDefault(r => r.Id == request.ServiceRequestId);

            var lease = _context.Lease.FirstOrDefault(l => l.Id == req.LeaseId);

            var updated = lease.UpdateServiceRequest(req, request.Status, request.WorkOrderId);

            _context.Request.Update(updated);

            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Unit.Task;
            //throw new NotImplementedException();
        }
    }
}
