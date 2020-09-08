using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Queries;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class AllServiceRequestsQueryHandler : IRequestHandler<AllServiceRequestsQuery, IQueryable<ServiceRequestViewModel>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllServiceRequestsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<ServiceRequestViewModel>> Handle(AllServiceRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = (from req in _context.Request
                            join lease in _context.Lease on req.LeaseId equals lease.Id
                            join tenant in _context.Tenant on req.RequestorId equals tenant.Id
                            join property in _context.RentalProperty on lease.RentalPropertyId equals property.Id                            

                            select new ServiceRequestViewModel
                            {
                                Id = req.Id,
                                RequestSubject = req.RequestSubject,
                                RequestDetails = req.RequestDetails,
                                ServiceCategory = req.ServiceCategory,
                                Urgent = req.Urgent,
                                Status = req.Status,
                                Notes = req.Notes,

                                PropertyName = property.PropertyName,
                                RentalPropertyId = property.Id,
                                PropertyType = property.PropertyType,
                                PropertyBuildYear = property.PropertyBuildYear,

                                FirstName = tenant.FirstName,
                                LastName = tenant.LastName,
                                ContactTelephone1 = tenant.ContactTelephone1,
                                ContactEmail = tenant.ContactEmail,

                                //WorkOrderName = workorder.WorkOrderName
                                
                                Created = req.Created,
                                Updated = req.Modified

                            }).ToList();

            var requestList = _context.Request.Include(s => s.Lease).ThenInclude(l => l.RentalProperty).ToList(); // for futher review

            var list = new ServiceRequestViewModel();


            return requests.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
