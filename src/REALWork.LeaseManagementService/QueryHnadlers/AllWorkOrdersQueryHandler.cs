using MediatR;
using REALWork.LeaseManagementService.Queries;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class AllWorkOrdersQueryHandler : IRequestHandler<AllWorkOrdersQuery, IQueryable<WorkOrderListViewModel>>
    {
        public Task<IQueryable<WorkOrderListViewModel>> Handle(AllWorkOrdersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
