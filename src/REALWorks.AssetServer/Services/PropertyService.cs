using REALWorks.AssetServer.Data;
using REALWorks.AssetServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services
{
    public class PropertyService: IPropertyService, IService
    {
        private readonly REALAssetContext _context;

        public PropertyService(REALAssetContext context)
        {
            _context = context;
        }


        #region Create

        public Task<PropertyImg> AddImgToProperty(PropertyImg img, int id)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyOwner> AddOnerToProperty(PropertyOwner owner, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Property> AddProperty(Property property, PropertyOwner owner)
        {
            //throw new NotImplementedException();
            var address = new PropertyAddress()
            {
                PropertySuiteNumber = property.PropertyAddress.PropertySuiteNumber,
                PropertyNumber = property.PropertyAddress.PropertyNumber,
                PropertyStreet = property.PropertyAddress.PropertyStreet,
                PropertyCity = property.PropertyAddress.PropertyCity,
                PropertyStateProvince = property.PropertyAddress.PropertyStateProvince,
                PropertyZipPostCode = property.PropertyAddress.PropertyZipPostCode,
                PropertyCountry = property.PropertyAddress.PropertyCountry
            };
                       

            var feature = new PropertyFeature()
            {
                BasementAvailable = property.PropertyFeature.BasementAvailable,
                IsShared = property.PropertyFeature.IsShared,
                NumberOfBedrooms = property.PropertyFeature.NumberOfBathrooms,
                NumberOfBathrooms = property.PropertyFeature.NumberOfBathrooms,
                TotalLivingArea = property.PropertyFeature.TotalLivingArea,
                NumberOfLayers = property.PropertyFeature.NumberOfLayers,
                NumberOfParking = property.PropertyFeature.NumberOfParking,                
                Notes = property.PropertyFeature.Notes
            };

            var facility = new PropertyFacility()
            {
                CommonFacility = property.PropertyFacility.CommonFacility,
                Refrigerator = property.PropertyFacility.Refrigerator,
                Laundry = property.PropertyFacility.Laundry,
                UtilityIncluded = property.PropertyFacility.UtilityIncluded,
                SecuritySystem = property.PropertyFacility.SecuritySystem,
                FireAlarmSystem = property.PropertyFacility.FireAlarmSystem,
                Tvinternet = property.PropertyFacility.Tvinternet,
                BlindsCurtain = property.PropertyFacility.BlindsCurtain,
                Stove = property.PropertyFacility.Stove,
                Notes = property.PropertyFacility.Notes
            };

            var pOwner = new PropertyOwner()
            {
                UserName = "notset",
                //PropertyOwnerId = property.PropertyOwnerId
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ContactEmail = owner.ContactEmail,
                ContactTelephone1 = owner.ContactTelephone1,
                ContactTelephone2 = owner.ContactTelephone2,
                UserAvartaImgUrl = "",
                IsActive = true,
                RoleId = 2, // RoleId = 1: pm, 2:owner, 3: tenant, 4: vendor
                OnlineAccessEnbaled = false,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now                
            };

            


            try
            {
                if (_context != null)
                {
                    await _context.AddAsync(pOwner);

                    //await  _context.AddAsync(new Property {
                    //    PropertyName = property.PropertyName,


                    //});

                    Property.CreateProperty(property.PropertyName, 
                        property.PropertyDesc, 
                        property.PropertyManagerId, 
                        property.PropertyBuildYear, 
                        property.IsActive, 
                        property.IsShared, 
                        property.IsBasementSuite, 
                        property.PropertyTypeId, 
                        property.RentalStatusId//, 
                        //property.CreatedDate, 
                        //property.UpdateDate
                        );

                    

                    var ownerProperty = new OwnerProperty()
                    {
                        Property = property,
                        PropertyOwner = pOwner
                    };

                    property.OwnerProperty.Add(ownerProperty);                   


                   
                }
            } catch(Exception ex)
            {
                throw ex;
            }

            return property;
        }

        #endregion

        #region Retrive

        public Task<IQueryable<Property>> GetAllProperty()
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
