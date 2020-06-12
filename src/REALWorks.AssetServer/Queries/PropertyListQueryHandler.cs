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
    public class PropertyListQueryHandler : IRequestHandler<PropertyListQuery, IQueryable<PropertyListViewModel>>
    {
        private readonly AppDataBaseContext _context;

        public PropertyListQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<PropertyListViewModel>> Handle(PropertyListQuery request, CancellationToken cancellationToken)
        {

            var propertyList = (from p in _context.Property.Include(a => a.Address)
                                .Where(s => s.IsActive == true)

                                select new PropertyListViewModel
                                {
                                    Id = p.Id,
                                    PropertyName = p.PropertyName,
                                    PropertyLogoImgUrl = p.PropertyLogoImgUrl,
                                    IsActive = p.IsActive,
                                    IsShared = p.IsShared,
                                    Status = p.Status.ToString(),
                                    Type = p.Type.ToString(),
                                    PropertySuiteNumber = p.Address.PropertySuiteNumber,
                                    PropertyNumber = p.Address.PropertyNumber,
                                    PropertyStreet = p.Address.PropertyStreet,
                                    PropertyCity = p.Address.PropertyCity,
                                    PropertyStateProvince = p.Address.PropertyStateProvince,
                                    PropertyZipPostCode = p.Address.PropertyZipPostCode,
                                    PropertyCountry = p.Address.PropertyCountry,
                                    CreatedDate = p.Created,
                                    UpdateDate = p.Modified

                                }).AsQueryable();

            return propertyList;

            //throw new NotImplementedException();
        }

        
    }
}
