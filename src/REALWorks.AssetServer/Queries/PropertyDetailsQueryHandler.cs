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
    public class PropertyDetailsQueryHandler : IRequestHandler<PropertyDetailsQuery, Property>
    {
        private readonly AppDataBaseContext _context;

        public PropertyDetailsQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Property> Handle(PropertyDetailsQuery request, CancellationToken cancellationToken)
        {

            var property = _context.Property
                //.Include(c => c.ManagementContract)
                .Include(fe => fe.Feature)
                .Include(fa => fa.Facility)
                .Include(a => a.Address)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner).ToList();

            return property.FirstOrDefault(p => p.Id == request.Id);


            //throw new NotImplementedException();
        }
    }
}
