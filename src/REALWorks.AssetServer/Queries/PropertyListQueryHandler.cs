using MediatR;
using REALWorks.AssetData;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class PropertyListQueryHandler : IRequestHandler<PropertyListQuery, IQueryable<PropertyListViewModel>>
    {
        private readonly AppDataBaseContext _context;

        public PropertyListQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<PropertyListViewModel>> Handle(PropertyListQuery request, CancellationToken cancellationToken)
        {

            var propertyList = (from p in _context.Property                            
                                
                                select new PropertyListViewModel
                                {
                                    PropertyId = p.Id,
                                    PropertyName = p.PropertyName,
                                    PropertyLogoImgUrl = p.PropertyLogoImgUrl,
                                    IsActive = p.IsActive,
                                    IsShared = p.IsShared,
                                    Status = p.Status.ToString(),
                                    PropertyType1 = p.Type.ToString(),
                                    CreatedDate = p.Created,
                                    UpdateDate = p.Modified

                                }).AsQueryable();

            return propertyList;

            //throw new NotImplementedException();
        }

        
    }
}
