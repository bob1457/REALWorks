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
    public class AllOwnerListQueryHandler2 : IRequestHandler<AllOwnerListQuery2, IQueryable<AllOwnerListViewMode>>
    {
        private readonly AppDataBaseContext _context;

        public AllOwnerListQueryHandler2(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<AllOwnerListViewMode>> Handle(AllOwnerListQuery2 request, CancellationToken cancellationToken)
        {
            var ownerList = (from o in _context.PropertyOwner.Include(a => a.Address)
                             select new AllOwnerListViewMode
                             {
                                 Id = o.Id,
                                 FirstName = o.FirstName,
                                 LastName = o.LastName,
                                 Created = o.Created,
                                 Updated = o.Modified,
                                 ContactEmail = o.ContactEmail,
                                 ContactTelephone1 = o.ContactTelephone1,
                                 OnlineAccess = o.OnlineAccess,
                                 UserAvartaImgUrl= o.UserAvartaImgUrl,
                                 StreetNumber = o.Address.StreetNumber,
                                 City = o.Address.City,
                                 StateProvince = o.Address.StateProvince,
                                 ZipPostCode = o.Address.ZipPostCode,
                                 Country = o.Address.Country
                             }).AsQueryable();


            return ownerList;

            //throw new NotImplementedException();
        }
    }
}
