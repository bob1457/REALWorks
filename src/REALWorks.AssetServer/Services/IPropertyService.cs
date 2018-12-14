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
        Task AddOwnerToProperty(OwnerAddViewModel owner);
        Task<ManagementContractAddViewModel>AddManagementContract(ManagementContractAddViewModel contract);

        /// <summary>
        /// Retrieve Operations (R)
        /// </summary>        
        Task<PropertyDetailViewModel> GetPropertyById(int id);
        Task<IQueryable<PropertyListViewModel>> GetAllProperty(); // Task<List<PropertyListViewModel>> GetAllProperty();
        Task<IQueryable<PropertyOwner>> GetOwnerListByProperty(int id); // id: property id
        Task<Property> GetPropertyAndOwner(int id);

        /// <summary>
        /// Update Operations (U)
        /// </summary>        
        Task<RentalStatus> UpdateRentalStatus(int id, int statusId);
        Task<bool> UpdateProeprtyStatus(int id, bool status);
        Task<PropertyOwner> UpdatePropertyOwner(PropertyOwner owner);
        Task<ManagementContract> UpdateContract(ManagementContract contract);

        Task<PropertyUpdateViewModel> UpdateProperty(PropertyUpdateViewModel property);


    }
}
