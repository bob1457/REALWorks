using MediatR;
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
    public class ManagementContractListQueryHandler : IRequestHandler<ManagementContractListQuery, IQueryable<ManagementContractListByPropertyViewModel>>
    {
        private readonly AppDataBaseContext _context;

        public ManagementContractListQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<ManagementContractListByPropertyViewModel>> Handle(ManagementContractListQuery request, CancellationToken cancellationToken)
        {
            var contractList = from c in _context.ManagementContract
                               join p in _context.Property on c.PropertyId equals p.Id
                               //join o in _context.OwnerProperty on p.Id equals o.PropertyId
                               //join po in _context.PropertyOwner on o.PropertyOwnerId equals po.Id

                               where c.PropertyId == request.Id
                               select new ManagementContractListByPropertyViewModel
                               {
                                   Id = c.Id,
                                   ManagementContractTitle = c.ManagementContractTitle,
                                   StartDate = c.StartDate,
                                   EndDate = c.EndDate,
                                   ContractSignDate = c.ContractSignDate,
                                   PlacementFeeScale = c.PlacementFeeScale,
                                   ManagementContractDocUrl = c.ManagementContractDocUrl,
                                   ManagementFeeScale = c.ManagementFeeScale,
                                   ManagementContractType = c.Type,
                                   //OwnerFirstName = po.FirstName,
                                   //OnwerLastName = po.LastName,
                                   PropertyName = p.PropertyName,
                                   Notes = c.Notes,
                                   IsActive = c.IsActive,
                                   Created = c.Created,
                                   Modified = c.Modified                                   
                               };

            return contractList.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
