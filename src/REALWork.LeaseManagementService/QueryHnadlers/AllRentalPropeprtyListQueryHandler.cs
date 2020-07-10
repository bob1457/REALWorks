using MediatR;
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
    public class AllRentalPropeprtyListQueryHandler : IRequestHandler<AllRentalPropeprtyListQuery, IQueryable<RentalProperty>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllRentalPropeprtyListQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<RentalProperty>> Handle(AllRentalPropeprtyListQuery request, CancellationToken cancellationToken)
        {
            var propertyList = _context.RentalProperty;

            return propertyList;

            //throw new NotImplementedException();
        }
    }
}
