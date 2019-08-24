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
    public class AllOwnerListQueryHandler : IRequestHandler<AllOwnerListQuery, IQueryable<PropertyOwner>>
    {
        private readonly AppDataBaseContext _context;

        public AllOwnerListQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<PropertyOwner>> Handle(AllOwnerListQuery request, CancellationToken cancellationToken)
        {
            //var allOwners = (from o in _context.PropertyOwner
            //                 join op in _context.OwnerProperty on o.Id equals op.PropertyOwnerId
            //                 join p in _context.Property on op.PropertyId equals p.Id
            //                 select  new {
            //                 }
            //    );


            var owners = _context.PropertyOwner
                .Include(a => a.Address)
                .ToList();

            foreach(var owner in owners)
            {
                _context.Entry(owner)
               .Collection(c => c.OwnerProperty).Load();
                foreach(var op in owner.OwnerProperty)
                {
                    _context.Entry(op)
                    .Reference(o => o.Property).Load();
                }
            }



            //var result = _context.PropertyOwner //;

            //.Include(op => op.OwnerProperty);
            //.ThenInclude(p => p.)

            //return result.AsQueryable();
            return owners.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
