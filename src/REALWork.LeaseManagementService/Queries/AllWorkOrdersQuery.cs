using MediatR;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class AllWorkOrdersQuery : IRequest<IQueryable<WorkOrderListViewModel>>
    {
    }
}
