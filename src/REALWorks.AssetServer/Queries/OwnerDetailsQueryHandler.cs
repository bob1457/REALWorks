using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class OwnerDetailsQueryHandler : IRequestHandler<OwnerDetailsQuery, PropertyOwner>
    {
        private readonly AppDataBaseContext _context;

        public OwnerDetailsQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }
                      

        public async Task<PropertyOwner> Handle(OwnerDetailsQuery request, CancellationToken cancellationToken)
        {
            var owner = _context.PropertyOwner
                 .Include(op => op.OwnerProperty)
                 .ThenInclude(p => p.Property).ToList();

            return owner.FirstOrDefault(i => i.Id == request.Id);
        }
    }
}
