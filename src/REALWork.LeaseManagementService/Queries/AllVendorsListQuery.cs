using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System.Linq;

namespace REALWork.LeaseManagementService.Queries
{
    public class AllVendorsListQuery : IRequest<IQueryable<Vendor>>
    {
    }
}
