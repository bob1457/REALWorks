using REALWorks.AssetServer.Models;
using REALWorks.AssetServer.Services.ViewModels;
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
        
        Task<PropertyAddViewModel> AddProperty(PropertyAddViewModel property);
        Task<PropertyImg> AddImgToProperty(PropertyImg img, int id);
        Task<PropertyOwner> AddOwnerToProperty(PropertyOwner owner, int id);

        /// <summary>
        /// Retrieve Operations (R)
        /// </summary>
        
        Task<Property> GetPropertyById(int id);
        Task<IQueryable<PropertyListViewModel>> GetAllProperty(); // Task<List<PropertyListViewModel>> GetAllProperty();


    }
}
