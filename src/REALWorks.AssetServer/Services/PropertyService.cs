using REALWorks.AssetServer.Data;
using REALWorks.AssetServer.Models;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Task<PropertyOwner> AddOwnerToProperty(PropertyOwner owner, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PropertyAddViewModel> AddProperty(PropertyAddViewModel property)
        {
            //throw new NotImplementedException();

            object pOwner;
            object ownerProperty;

            var address = new PropertyAddress()
            {
                PropertySuiteNumber = property.PropertySuiteNumber,
                PropertyNumber = property.PropertyNumber,
                PropertyStreet = property.PropertyStreet,
                PropertyCity = property.PropertyCity,
                PropertyStateProvince = property.PropertyStateProvince,
                PropertyZipPostCode = property.PropertyZipPostCode,
                PropertyCountry = property.PropertyCountry
            };
                       

            var feature = new PropertyFeature()
            {
                BasementAvailable = property.BasementAvailable,
                IsShared = property.IsShared,
                NumberOfBedrooms = property.NumberOfBathrooms,
                NumberOfBathrooms = property.NumberOfBathrooms,
                TotalLivingArea = property.TotalLivingArea,
                NumberOfLayers = property.NumberOfLayers,
                NumberOfParking = property.NumberOfParking,                
                Notes = property.FacilityNotes
            };

            var facility = new PropertyFacility()
            {
                CommonFacility = property.CommonFacility,
                Refrigerator = property.Refrigerator,
                Laundry = property.Laundry,
                UtilityIncluded = property.UtilityIncluded,
                SecuritySystem = property.SecuritySystem,
                FireAlarmSystem = property.FireAlarmSystem,
                Tvinternet = property.Tvinternet,
                BlindsCurtain = property.BlindsCurtain,
                Stove = property.Stove,
                Notes = property.FacilityNotes
            };


            var newProperty = new Property(
                       property.PropertyName,
                       property.PropertyDesc,
                       //property.PropertyAddressId,
                       //property.PropertyFeatureId,
                       //property.PropertyFacilityId,
                       //property.PropertyOwnerId,
                       //property.PropertyManagerId,
                       property.PropertyBuildYear,
                       property.IsActive,
                       property.IsShared,                       
                       property.IsBasementSuite,
                       address,
                       facility,
                       feature,
                       property.PropertyTypeId,
                       property.RentalStatusId
                       )
            {
                PropertyName = property.PropertyName,
                PropertyDesc = property.PropertyDesc,
                //PropertyAddressId = property.PropertyAddressId,
                //PropertyFeatureId = property.PropertyFeatureId,
                //PropertyFacilityId = property.PropertyFacilityId,
                //PropertyOwnerId = property.PropertyOwnerId,
                //PropertyManagerId = property.PropertyManagerId,
                PropertyBuildYear = property.PropertyBuildYear,
                IsActive = property.IsActive,
                IsShared = property.IsShared,
                IsBasementSuite = property.IsBasementSuite,
                PropertyAddress = address,
                PropertyFacility = facility,
                PropertyFeature = feature,
                PropertyTypeId = property.PropertyTypeId,
                RentalStatusId = property.RentalStatusId,
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now
                
            };


            await _context.AddAsync(newProperty);

            if (property.PropertyOwnerId == 0)
            {
               pOwner = new PropertyOwner()
                {
                    UserName = "notset",
                    //PropertyOwnerId = property.PropertyOwnerId
                    FirstName = property.FirstName,
                    LastName = property.LastName,
                    ContactEmail = property.ContactEmail,
                    ContactTelephone1 = property.ContactTelephone1,
                    ContactTelephone2 = property.ContactTelephone2,
                    UserAvartaImgUrl = "",
                    IsActive = true,
                    RoleId = 2, // RoleId = 1: pm, 2:owner, 3: tenant, 4: vendor
                    OnlineAccessEnbaled = false,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now                
                };

                await _context.AddAsync(pOwner);

                ownerProperty = new OwnerProperty()
                {
                    Property = newProperty,
                    PropertyOwner = (PropertyOwner)pOwner
                    //PropertyId = newProperty.PropertyId,
                    //PropertyOwnerId = pOwner.PropertyOwnerId
                };
            }
            else
            {
                //Get owner
                //pOwner = _context.PropertyOwner.Where(o => o.PropertyOwnerId == property.PropertyOwnerId); //this could be a verification that the owner does exist

                ownerProperty = new OwnerProperty()
                {
                    Property = newProperty,
                    //PropertyOwner = pOwner
                    //PropertyId = newProperty.PropertyId,
                    PropertyOwnerId = property.PropertyOwnerId
                };


            }

            

            

            

            try
            {
                
                if (_context != null)
                {
                    //await _context.AddAsync(pOwner);
                    await _context.AddAsync(address);
                    await _context.AddAsync(feature);
                    await _context.AddAsync(facility);

                    

                    //await  _context.AddAsync(newProperty);// if use fuill ddd pattern then use the followsing Create

                    //var ppt = Property.CreateProperty(property.PropertyName, // This will be tested in full ddd environemnt later
                    //    property.PropertyDesc, 
                    //    property.PropertyManagerId, 
                    //    property.PropertyBuildYear, 
                    //    property.IsActive, 
                    //    property.IsShared, 
                    //    property.IsBasementSuite, 
                    //    property.PropertyTypeId, 
                    //    property.RentalStatusId//, 
                    //    //property.CreatedDate, 
                    //    //property.UpdateDate
                    //    );

                    


                    //var ownerProperty = new OwnerProperty()
                    //{
                    //    Property = newProperty,
                    //    PropertyOwner = pOwner
                    //    //PropertyId = newProperty.PropertyId,
                    //    //PropertyOwnerId = pOwner.PropertyOwnerId
                    //};

                    await _context.AddAsync(ownerProperty);

                    //newProperty.OwnerProperty.Add(ownerProperty);

                    try
                    {
                        await _context.SaveChangesAsync();

                        int propertyId = newProperty.PropertyId;

                        //Update the view model to be returned
                        property.PropertyId = newProperty.PropertyId;
                        property.CreatedDate = newProperty.CreatedDate;
                        property.UpdateDate = newProperty.UpdateDate;

                    } catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                   
                }
            } catch(Exception ex)
            {
                throw ex;
            }

            return property; // ViewModel is returned on successful create record
        }

        #endregion

        #region Retrive

        public async Task<IQueryable<PropertyListViewModel>> GetAllProperty() // Task<List<PropertyListViewModel>> GetAllProperty()
        {
            //throw new NotImplementedException();
            //  var allProperties = _context.Property; //.Include(t => t.PropertyType).Include(s => s.RentalStatus).ToList(); // using Microsoft.EntityFrameworkCore; is required
            //  return allProperties.AsQueryable();

            return /*await*/ (from p in _context.Property
                          from t in _context.PropertyType
                          from s in _context.RentalStatus
                          where p.RentalStatusId == s.RentalStatusId
                          where p.PropertyTypeId == t.PropertyTypeId
                          select new PropertyListViewModel
                          {
                              PropertyId = p.PropertyId,
                              PropertyName = p.PropertyName,
                              PropertyLogoImgUrl = p.PropertyLogoImgUrl,
                              IsActive = p.IsActive,
                              IsShared = p.IsShared,
                              Status = s.Status,
                              PropertyType1 = t.PropertyType1

                          }).AsQueryable(); //.ToListAsync()
        }

        public async Task<Property> GetPropertyById(int id)
        {
            //throw new NotImplementedException();

            return _context.Property.Where(p => p.PropertyId == id).FirstOrDefault();
        }
        

        #endregion
    }
}
