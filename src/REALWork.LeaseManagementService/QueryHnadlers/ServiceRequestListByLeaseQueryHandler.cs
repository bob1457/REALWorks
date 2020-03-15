using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
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
    public class ServiceRequestListByLeaseQueryHandler : IRequestHandler<ServiceRequestListByLeaseQuery, IQueryable<ServiceRequestViewModel>>
     //: IRequestHandler<ServiceRequestListByLeaseQuery, IQueryable<ServiceRequest>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public ServiceRequestListByLeaseQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ServiceRequestViewModel>> Handle(ServiceRequestListByLeaseQuery request, CancellationToken cancellationToken)
        {
            var requests = (from req in _context.Request
                            join lease in _context.Lease on req.LeaseId equals lease.Id
                            join tenant in _context.Tenant on req.RequestorId equals tenant.Id
                            join property in _context.RentalProperty on lease.RentalPropertyId equals property.Id  
                            
                            //join workorder in _context.WorkOrder on req.WorkOrderId equals workorder.Id
                            where req.LeaseId == request.LeaeeId 
                              

                            select new ServiceRequestViewModel {

                                RequestSubject = req.RequestSubject,
                                RequestDetails = req.RequestDetails,
                                ServiceCategory = req.ServiceCategory,
                                Urgent = req.Urgent,
                                Status = req.Status,
                                Notes = req.Notes,

                                PropertyName = property.PmUserName,
                                RentalPropertyId = property.Id,
                                PropertyType = property.PropertyType,
                                PropertyBuildYear = property.PropertyBuildYear,

                                FirstName = tenant.FirstName,
                                LastName = tenant.LastName,
                                ContactTelephone1 = tenant.ContactTelephone1,
                                ContactEmail = tenant.ContactEmail

                                //WorkOrderName = workorder.WorkOrderName



                           }).ToList();


            return requests.AsQueryable();

            //throw new NotImplementedException();
        }

        //public async Task<IQueryable<ServiceRequest>> Handle(ServiceRequestListByLeaseQuery request, CancellationToken cancellationToken)
        //{
        //    var requestHistory = _context.Request
        //        //.FirstOrDefault(i => i.LeaseId == request.LeaeeId)
        //        .Include(l => l.Lease)
        //            .ThenInclude(p => p.RentalProperty)
        //        //.Include(l => l.Tenant)                
        //        .ToList();

        //    //var result = _context.Lease.
        //    //    Include(p => p.RentalProperty)
        //    //    .Include(t => t.Tenant)
        //    //    .Include(s => s.ServiceRequest).ToList();

        //    //return result;

        //    throw new NotImplementedException();
        //}


    }
}
