using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, VendorUpdateResultViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateVendorCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<VendorUpdateResultViewModel> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
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

            var newVendor = _context.Vendor
                .Include(v => v.WorkOrder).ToList()
                .FirstOrDefault(v => v.Id == request.Id);

            var updatedVendor = new VendorUpdateResultViewModel();

            updatedVendor.Id = newVendor.Id;
            updatedVendor.FirstName = newVendor.FirstName;
            updatedVendor.LastName = newVendor.LastName;
            updatedVendor.VendorDesc = newVendor.VendorDesc;
            updatedVendor.VendorBusinessName = newVendor.VendorBusinessName;
            updatedVendor.VendorSpecialty = newVendor.VendorSpecialty;
            updatedVendor.VendorContactEmail = newVendor.VendorContactEmail;
            updatedVendor.VendorContactOthers = newVendor.VendorContactOthers;
            updatedVendor.VendorContactTelephone1 = newVendor.VendorContactTelephone1;
            updatedVendor.IsActive = newVendor.IsActive;
            updatedVendor.OnlineAccessEnbaled = newVendor.OnlineAccessEnbaled;
            updatedVendor.Created = newVendor.Created;
            updatedVendor.Updated = newVendor.Created;
            updatedVendor.WrokOrderList = newVendor.WorkOrder.ToList();

            return updatedVendor;
            //throw new NotImplementedException();
        }
    }
}
