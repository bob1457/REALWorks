using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class ManagementContractQueryHandler : IRequestHandler<ManagementContractQuery, ManagementContract>
    {
        private readonly AppDataBaseContext _context;

        public ManagementContractQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }


        public async Task<ManagementContract> Handle(ManagementContractQuery request, CancellationToken cancellationToken)
        {
            var contract = _context.ManagementContract
                .Include(p => p.Property)//;
                .ThenInclude(op => op.OwnerProperty)
                .ThenInclude(o => o.PropertyOwner).ToList();

            return contract.FirstOrDefault(c => c.Id == request.Id);

            throw new NotImplementedException();
        }
    }
}
