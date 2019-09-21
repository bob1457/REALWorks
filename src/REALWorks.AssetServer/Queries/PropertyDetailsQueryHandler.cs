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
    public class PropertyDetailsQueryHandler : IRequestHandler<PropertyDetailsQuery, PropertyDetailViewModel>
    {
        private readonly AppDataBaseContext _context;

        public PropertyDetailsQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<PropertyDetailViewModel> Handle(PropertyDetailsQuery request, CancellationToken cancellationToken)
        {
            //var ppt = _context.Property
            //    .Select(p => new
            //    {
            //        p.Id,
            //        p.PropertyName,
            //        Owners = string.Join(", ", p.OwnerProperty                                  
            //       .Select(o => o.PropertyOwner.FirstName))

            //    }).FirstOrDefault(i => i.Id == request.Id);

            var ppt = _context.Property
                .Include(a => a.Address)
                .FirstOrDefault(p => p.Id == request.Id);

            _context.Entry(ppt)
                .Collection(c => c.OwnerProperty).Load();
            foreach(var op in ppt.OwnerProperty)
            {
                _context.Entry(op)
                    .Reference(o => o.PropertyOwner).Load();
            }


            var prop = _context.Property
                //.Include(c => c.ManagementContract)
                .Include(fe => fe.Feature)
                .Include(fa => fa.Facility)
                .Include(a => a.Address)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner)
                .Where(po => po.Id == request.Id)
                .Select(op => new PropertyDetailViewModel
                {
                    PropertyName = op.PropertyName,
                    PropertyId = op.Id,
                    OwnerList = op.OwnerProperty.Select(o => o.PropertyOwner).ToList(),
                    ContractList = op.ManagementContract/*.Where(c =>c.IsActive == true)*/.ToList()
                });
                //.FirstOrDefault(op => op.PropertyId == request.Id);


            //var pptList = (from p in _context.Property
            //               .Include(fe => fe.Feature)
            //               .Include(fa => fa.Facility)
            //               .Include(a => a.Address)
            //               .Include(m => m.PropertyImg)
            //               join op in _context.OwnerProperty on p.Id equals op.PropertyId
            //               join po in _context.PropertyOwner on op.PropertyOwnerId equals po.Id

            //               select new PropertyDetailViewModel
            //               {
            //                   PropertyName = p.PropertyName
            //               }





            //               );



            var property = _context.Property
                .Include(c => c.ManagementContract)
                .Include(fe => fe.Feature)
                .Include(fa => fa.Facility)
                .Include(a => a.Address)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner).ToList();

            //return property.FirstOrDefault(p => p.Id == request.Id);

            return prop.FirstOrDefault(p => p.PropertyId == request.Id);


            //throw new NotImplementedException();
        }
    }
}
