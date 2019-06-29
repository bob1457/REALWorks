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
    public class AddVendorCommandHandler : IRequestHandler<AddVendorCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AddVendorCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = new Vendor("NotSet", request.VendorBusinessName, request.FirstName, request.LastName,
                request.VendorDesc, request.VendorSpecialty, request.VendorContactTelephone1, request.VendorContactOthers,
                request.VendorContactEmail, request.IsActive, 4, false, request.UserAvartaImgUrl, DateTime.Now, DateTime.Now);

            _context.Vendor.Add(vendor);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY

                Log.Information("Then vendor  {VendorName} has been added successfully", vendor.VendorBusinessName);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while adding the vendor {VendorName}.", vendor.VendorBusinessName);
            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
