using REALWorks.AssetServer.Models;
using REALWorks.AssetServer.Services.ViewModels;
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
        Task AddOwnerToProperty(AddOwnerViewModel owner);

        /// <summary>
        /// Retrieve Operations (R)
        /// </summary>        
        Task<PropertyDetailViewModel> GetPropertyById(int id);
        Task<IQueryable<PropertyListViewModel>> GetAllProperty(); // Task<List<PropertyListViewModel>> GetAllProperty();


    }
}
