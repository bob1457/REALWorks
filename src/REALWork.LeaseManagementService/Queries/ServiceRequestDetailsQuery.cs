using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class ServiceRequestDetailsQuery : IRequest<ServiceRequest>
    {
        public int Id { get; set; }
    }
}
