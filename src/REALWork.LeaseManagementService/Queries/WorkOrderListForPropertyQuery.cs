using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class WorkOrderListForPropertyQuery : IRequest<IQueryable<WorkOrderListViewModel>>
    {
        public int PropertyId { get; set; }
    }
}
