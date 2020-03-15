using MediatR;
using REALWork.LeaseManagementCore.Entities;
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
    public class AddServiceRequestCommandHandler : IRequestHandler<AddServiceRequestCommand, ServiceRequest>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AddServiceRequestCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceRequest> Handle(AddServiceRequestCommand request, CancellationToken cancellationToken)
        {
            var req = new ServiceRequest(request.RequestSubject, request.ServiceCategory, request.RequestDetails,
                request.Urgent, request.Status, request.LeaseId, request.RequestorId, 0, request.Notes, DateTime.Now, DateTime.Now);

            _context.Request.Add(req);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY
                Log.Information("The service request {Request} has been submitted.", req.RequestSubject);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while receiving the service request {Request}.", req.RequestSubject);
            }

            return req;

            //throw new NotImplementedException();
        }

        

        
    }
}
