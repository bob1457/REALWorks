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
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateVendorCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = _context.Vendor.FirstOrDefault(v => v.Id == request.Id);

            var updated = vendor.Update(request.VendorBusinessName, request.FirstName, request.LastName, request.VendorSpecialty,
                request.VendorContactTelephone1, request.VendorContactOthers, request.VendorContactEmail, request.IsActive);

            _context.Vendor.Update(updated);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while updating the vendor {VendorName}.", vendor.VendorBusinessName);
            }

            return await Unit.Task;
            //throw new NotImplementedException();
        }
    }
}
