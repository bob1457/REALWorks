using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class OwnerListByPropertyQueryHandler : IRequestHandler<OwnerListByPropertyQuery, IQueryable<OwnerListByPropertyViewModel>>
    {
        private readonly AppDataBaseContext _context;

        public OwnerListByPropertyQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<OwnerListByPropertyViewModel>> Handle(OwnerListByPropertyQuery request, CancellationToken cancellationToken)
        {
            var ownerList = (from o in _context.PropertyOwner
                            .Include(op => op.OwnerProperty)
                            .ThenInclude(p => p.Property)

                             select new OwnerListByPropertyViewModel
                             {
                                 UserName = o.UserName,
                                 FirstName = o.FirstName,
                                 LastName = o.LastName,
                                 ContactEmail = o.ContactEmail,
                                 ContactTelephone1 = o.ContactTelephone1,
                                 ContactTelephone2 = o.ContactTelephone2,
                                 OnlineAccess = o.OnlineAccess,
                                 RoleId = o.RoleId,
                                 Notes = o.Notes

                             }).AsQueryable();

            return ownerList;
        }
    }
}
