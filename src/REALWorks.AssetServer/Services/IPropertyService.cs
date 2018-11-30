using REALWorks.AssetServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services
{
    public interface IPropertyService
    {
        /// <summary>
        /// Create Operations (C)
        /// </summary>
        
        Task<Property> AddProperty(Property property, PropertyOwner owner);
        Task<PropertyImg> AddImgToProperty(PropertyImg img, int id);
        Task<PropertyOwner> AddOnerToProperty(PropertyOwner owner, int id);

        /// <summary>
        /// Retrieve Operations (R)
        /// </summary>
        
        Task<Property> GetPropertyById(int id);
        Task<IQueryable<Property>> GetAllProperty();


    }
}
