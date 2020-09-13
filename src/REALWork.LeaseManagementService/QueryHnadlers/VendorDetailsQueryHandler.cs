using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class VendorDetailsQueryHandler : IRequestHandler<VendorDetailsQuery, Vendor>
    {
        private readonly AppLeaseManagementDbContext _context;

        public VendorDetailsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Vendor> Handle(VendorDetailsQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            //var result = (from v in _context.Vendor
            //              join wo in _context.WorkOrder on v.Id equals wo.VendorId
            //              join rp in _context.RentalProperty on wo.RentalPropertyId equals rp.Id
            //              )


            var vendor = _context.Vendor
                .Include(v => v.WorkOrder)
                //
                .ThenInclude(w => w.RentalProperty).ToList(); // newly added;

            return vendor.FirstOrDefault(v => v.Id == request.Id);
        }
    }
}
