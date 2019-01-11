using REALWorks.AssetServer.Data;
using REALWorks.AssetServer.Models;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.IO;
using Microsoft.AspNetCore.Http;
using REALWorks.AssetServer.Infrastructure;
using REALWorks.AssetData;

namespace REALWorks.AssetServer.Services
{
    public class PropertyService: IPropertyService, IService
    {
        private readonly REALAssetContext _context;
        private readonly AppDataBaseContext _context2;

        private readonly IImageHandler _imageHandler;

        public PropertyService(REALAssetContext context, AppDataBaseContext context2, IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
            _context2 = context2; 
        }


        #region Create

        

        //public Task<PropertyOwner> AddOwnerToProperty(PropertyOwner owner, int id)
        //{
        //    throw new NotImplementedException();
        //}

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
                              PropertyType1 = t.PropertyType1,
                              CreatedDate = p.CreatedDate,
                              UpdateDate = p.UpdateDate

                          }).AsQueryable(); //.ToListAsync()
        }

        //**************************Archived for future use! Use the eager loading below
        public async Task<PropertyDetailViewModel> GetPropertyById(int id)  // **************** Use view model (DTO) to load only the attributes needed!!!!
        {
            //throw new NotImplementedException();

            //return _context.Property.Where(p => p.PropertyId == id).FirstOrDefault();
            var property = (from p in _context.Property.Include(c => c.ManagementContract).Include(op => op.OwnerProperty).ThenInclude(po => po.PropertyOwner)                                                       
                            from a in _context.PropertyAddress where p.PropertyAddressId == a.PropertyAddressId
                            //from o in _context.PropertyOwner.Select(o => o.OwnerProperty).ToList()
                            //join c in _context.ManagementContract on p.PropertyId equals c.PropertyId into ManagementConract          // Left Outer Join to get management contract even if it is empty          
                            from fe in _context.PropertyFeature
                            from fa in _context.PropertyFacility
                            from t in _context.PropertyType
                            from s in _context.RentalStatus
                            where p.RentalStatusId == s.RentalStatusId
                            where p.PropertyTypeId == t.PropertyTypeId                            
                            where p.PropertyFeatureId == fe.PropertyFeatureId
                            where p.PropertyFacilityId == fa.PropertyFacilityId
                            where p.PropertyId == id
                            select new PropertyDetailViewModel
                            {
                                //Property attributers
                                PropertyId = p.PropertyId,
                                PropertyName = p.PropertyName,
                                PropertyLogoImgUrl = p.PropertyLogoImgUrl,
                                IsActive = p.IsActive,
                                IsShared = p.IsShared,
                                Status = s.Status,  //p.OwnerProperty.First().PropertyOwner.f // 
                                PropertyType1 = t.PropertyType1,

                                // ManagementContractTitile = ManagementConract.FirstOrDefault().ManagementContractTitile,

                                // Features
                                NumberOfBedrooms = fe.NumberOfBedrooms,
                                NumberOfBathrooms = fe.NumberOfBathrooms,

                                // ...


                                // Facilities
                                Stove = fa.Stove,

                                //...

                                

                            // Address
                            PropertySuiteNumber = a.PropertySuiteNumber,
                            PropertyNumber = a.PropertyNumber,
                            PropertyStreet = a.PropertyStreet,
                            PropertyStateProvince = a.PropertyStateProvince,
                            PropertyZipPostCode = a.PropertyZipPostCode,
                            PropertyCountry = a.PropertyCountry

                        })/*.Include(o => o.OwnerList)*/.FirstOrDefault();

            //var owners = _context.PropertyOwner.Include(o => o.OwnerProperty);

            //var contracts = _context.ManagementContract.Where(x => x.PropertyId == id).ToList();

            //property.OwnerList = owners.ToList(); // Also see the service below with eager loading example (without using view model)
            //property.CotnractList = contracts;


            return property;
        }
        //******************************************************************************
        
        public async Task<IQueryable<PropertyOwner>> GetOwnerListByProperty(int id)
        {
            //throw new NotImplementedException();
            //var owners =   (from o in _context.PropertyOwner//.Include(pt => pt.OwnerProperty).ThenInclude(x => x.Property)
            //               from op in _context.OwnerProperty where o.PropertyOwnerId == op.PropertyOwnerId
            //                from p in _context.Property where p.PropertyId == op.PropertyId
            //                where op.PropertyId == id
            //                select new PropertyOwnerListViewModel
            //                {
            //                    FirstName = o.FirstName,
            //                    LastName = o.LastName,
            //                    PropertyName = p.PropertyName
            //                }).AsQueryable();

            var owners = _context.PropertyOwner.Include(op => op.OwnerProperty).ThenInclude(po => po.PropertyOwner).ToList();


            return owners.AsQueryable();
            
        }


        #endregion

        #region Other Implementation (Business Logics) 

        public async Task AddOwnerToProperty(OwnerAddViewModel owner)
        {
            //throw new NotImplementedException();

            var property = _context.Find<Property>(owner.PropertyId); // Get the property to which the owner will be added

            //property.AddOwner(owner.PropertyOwnerId, owner.FirstName, owner.LastName, owner.ContactEmail, owner.ContactTelephone1, owner.ContactTelephone2, owner.OnlineAccessEnbaled);

            object ownerProperty;
            object pOwner;

            if (owner.PropertyOwnerId == 0) // this PeoprtyOwnerId coming from the ViewModel thorugh web api controller
            {
                // New Owner
                pOwner = new PropertyOwner(
                    owner.FirstName,
                    owner.LastName,
                    owner.ContactEmail,
                    owner.ContactTelephone1,
                    owner.ContactTelephone2,
                    owner.OnlineAccessEnbaled)
                {
                    UserName = "notset",
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    ContactEmail = owner.ContactEmail,
                    ContactTelephone1 = owner.ContactTelephone1,
                    ContactTelephone2 = owner.ContactTelephone2,
                    OnlineAccessEnbaled = owner.OnlineAccessEnbaled,
                    UserAvartaImgUrl = "",
                    RoleId = 2,
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                await _context.AddAsync(pOwner);

                ownerProperty = new OwnerProperty()
                {
                    Property = property,
                    PropertyOwner = (PropertyOwner)pOwner
                    //PropertyId = newProperty.PropertyId,
                    //PropertyOwnerId = pOwner.PropertyOwnerId
                };

                //await _context.AddAsync(ownerProperty);
            }
            else
            {
                // Existing Owner
                ownerProperty = new OwnerProperty()
                {
                    Property = property,
                    //PropertyOwner = pOwner
                    //PropertyId = newProperty.PropertyId,
                    PropertyOwnerId = owner.PropertyOwnerId
                };

                //await _context.AddAsync(ownerProperty);
            }

            await _context.AddAsync(ownerProperty);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PropertyImg> AddImgToProperty(PropertyImg img, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ManagementContractAddViewModel> AddManagementContract(ManagementContractAddViewModel contract)
        {
            //throw new NotImplementedException();
            var property = _context.Find<Property>(contract.PropertyId); // Get the property to which the contract will be added

            var newContract = new ManagementContract(
                contract.PropertyId,
                contract.ManagementContractTitile,
                contract.StartDate,
                contract.EndDate,
                contract.PlacementFeeScale,
                contract.ManagementFeeScale,
                contract.ContractSignDate,
                contract.ManagementContractDocUrl,
                contract.IsActive,
                contract.IsRenewal
                )
            {
                PropertyId = contract.PropertyId,
                ManagementContractTitile = contract.ManagementContractTitile,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                PlacementFeeScale = contract.PlacementFeeScale,
                ManagementFeeScale = contract.ManagementFeeScale,
                ContractSignDate = contract.StartDate,
                ManagementContractDocUrl = contract.ManagementContractDocUrl,
                IsActive = contract.IsActive,
                IsRenewal = contract.IsRenewal,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            //var placementFee = new ManagementFee()
            //{
            //    ManagementFeeType = contract.ManagementFeeType1,
            //    ManagementFeeAmount = contract.ManagementFeeAmount,
            //    Notes = contract.ManagemetnFeeNotes
            //};

            //var managementFee = new ManagementFee()
            //{
            //    ManagementFeeType = contract.ManagementFeeType2,
            //    ManagementFeeAmount = contract.ManagementFeeAmount,
            //    Notes = contract.ManagemetnFeeNotes
            //};

            //newContract.ManagementFee.Add(managementFee);
            //newContract.ManagementFee.Add(placementFee);
                      

            try
            {
                await _context.AddAsync(newContract);

                await _context.SaveChangesAsync();

                contract.ManagementContractId = newContract.ManagementContractId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contract;
        }

        public async Task<RentalStatus> UpdateRentalStatus(int id, int statusId) //id: property id
        {
            var property = _context.Find<Property>(id);

            property.RentalStatusId = statusId;

            //EntityEntry entiy = _context.Entry(property);

            await _context.SaveChangesAsync();

            var newStatus = _context.RentalStatus.Where(s => s.RentalStatusId == statusId);

            return await newStatus.FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateProeprtyStatus(int id, bool status)
        {
            var property = _context.Find<Property>(id);

            property.IsActive = status;

            //var newStatus = _context.Property.Where(s => s.IsActive == status);

            await _context.SaveChangesAsync();

            return status;

        }

        public async Task<PropertyUpdateViewModel> UpdateProperty(PropertyUpdateViewModel property)
        {
            //throw new NotImplementedException();

            // Populate the object with new updated value, NOTE: entity Id must be present or a new record will be inserted

            var feature = new PropertyFeature()
            {
                PropertyFeatureId = property.PropertyFeatureId,
                BasementAvailable = property.BasementAvailable,
                IsShared = property.IsShared,
                NumberOfBedrooms = property.NumberOfBedrooms,
                NumberOfBathrooms = property.NumberOfBathrooms,
                TotalLivingArea = property.TotalLivingArea,
                NumberOfLayers = property.NumberOfLayers,
                NumberOfParking = property.NumberOfParking,
                Notes = property.FacilityNotes
            };

            var facility = new PropertyFacility()
            {
                PropertyFacilityId = property.PropertyFacilityId,
                CommonFacility = property.CommonFacility,
                Refrigerator = property.Refrigerator,
                Laundry = property.Laundry,
                UtilityIncluded = property.UtilityIncluded,
                SecuritySystem = property.SecuritySystem,
                FireAlarmSystem = property.FireAlarmSystem,
                Tvinternet = property.Tvinternet,
                BlindsCurtain = property.BlindsCurtain,
                Stove = property.Stove,
                Dishwasher = property.Dishwasher,
                Notes = property.FacilityNotes
            };

            var address = new PropertyAddress()
            {
                PropertyAddressId = property.PropertyAddressId,
                PropertySuiteNumber = property.PropertySuiteNumber,
                PropertyNumber = property.PropertyNumber,
                PropertyStreet = property.PropertyStreet,
                PropertyCity = property.PropertyCity,
                PropertyStateProvince = property.PropertyStateProvince,
                PropertyZipPostCode = property.PropertyZipPostCode,
                PropertyCountry = property.PropertyCountry
            };


            var ppt = new Property() //_context.Property.Find(property.PropertyId);
            {
                PropertyId = property.PropertyId,
                PropertyName = property.PropertyName,
                PropertyDesc = property.PropertyDesc,                
                PropertyBuildYear = property.PropertyBuildYear,
                IsActive = property.IsActive,
                IsShared = property.IsShared,
                IsBasementSuite = property.IsBasementSuite,
                PropertyAddress = address,
                PropertyFacility = facility,
                PropertyFeature = feature,
                PropertyTypeId = property.PropertyTypeId,
                RentalStatusId = property.RentalStatusId,                
                UpdateDate = DateTime.Now
            };
            

            //ppt.UpdateDate = DateTime.Now;

            _context.Property.Update(ppt);
            _context.PropertyFeature.Update(feature);
            _context.PropertyFacility.Update(facility);
            _context.PropertyAddress.Update(address);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return property;

        }




        public async Task<AssetCore.Entities.Property> GetPropertyAndOwner(int id) // ****** Get Property By Id ******************** Without view model (DTO), all attributes will be loaded!!!
        {
            //throw new NotImplementedException();

            // Explicit Loading
            //
            //var property = _context.Property.First(p => p.PropertyId == id);
            //_context.Entry(property)
            //    .Collection(o => o.OwnerProperty).Load();
            //foreach (var owner in property.OwnerProperty)
            //{
            //    _context.Entry(owner)
            //        .Reference(po => po.PropertyOwner).Load();
            //}

            //_context.Entry(property)
            //    .Collection(c => c.ManagementContract).Load();

            //foreach (var contract in property.ManagementContract)
            //{
            //    _context.Entry(contract)
            //        .Reference(co => co.ManagementContractTitile).Load();
            //}

            //Eager Loading (NO VIEW MODEL - Load all attributes)
            //
            /*var property = _context.Property
                .Include(c=>c.ManagementContract)
                .Include(fe => fe.PropertyFeature)
                .Include(fa => fa.PropertyFacility)
                .Include(a => a.PropertyAddress)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner).ToList()                
                .First(p => p.PropertyId == id);*/



            var property = _context2.Property
                //.Include(c => c.ManagementContract)
                .Include(fe => fe.Feature)
                .Include(fa => fa.Facility)
                .Include(a => a.Address)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner).ToList()
                .First(p => p.Id == id);



            //_context.Entry(property)
            //    .Collection(m => m.PropertyImg).Load(); // Not necessary in this case (already loaded - eager load)

            return property;
        }

        public async Task<PropertyOwner> UpdatePropertyOwner(PropertyOwner owner)
        {
            //throw new NotImplementedException();

            var ownerUpdated = new PropertyOwner()
            {
                PropertyOwnerId = owner.PropertyOwnerId,
                UserName = owner.UserName,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ContactEmail = owner.ContactEmail,
                IsActive = owner.IsActive,
                ContactTelephone1 = owner.ContactTelephone1,
                ContactTelephone2 = owner.ContactTelephone2,
                UserAvartaImgUrl = owner.UserAvartaImgUrl,
                RoleId = owner.RoleId,
                UpdateDate = DateTime.Now
            };

            _context.Update(ownerUpdated);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ownerUpdated;
        }

        public async Task<ManagementContract> UpdateContract(ManagementContract contract)
        {
            //throw new NotImplementedException();

            var contractUpdate = new ManagementContract()
            {
                ManagementContractId = contract.ManagementContractId,
                ManagementContractTitile = contract.ManagementContractTitile,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                ContractSignDate = contract.ContractSignDate,
                ContentTemplateUrl = contract.ContentTemplateUrl,
                ManagementContractDocUrl = contract.ManagementContractDocUrl,
                ManagementFeeScale = contract.ManagementFeeScale,
                PlacementFeeScale = contract.PlacementFeeScale,
                IsActive = contract.IsActive,
                IsRenewal = contract.IsRenewal,
                PropertyId = contract.PropertyId,
                UpdateDate = DateTime.Now
            };

            _context.Update(contractUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contractUpdate;
        }

        public async Task<AddImageViewModel> AddImgToProperty(AddImageViewModel img)
        {
            //throw new NotImplementedException();
            var file = img.PropertyImage;
            /*
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");

                        using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fs);

                            // Add image path to DB


                            {
                                var imgUpload = new PropertyImg()
                                {
                                    PropertyImgTitle = img.PropertyImgTitle,
                                    PropertyImgCaption = "images/" + file.FileName, // This field used as the image URL                    
                                    PropertyId = img.PropertyId, // "62541",
                                    CreatedOn = DateTime.Now
                                };
                                //Url = "~/Contents/" + file.FileName, // Path.Combine(path, file.FileName),

                                await _context.AddAsync(img);

                                try
                                {
                                    await _context.SaveChangesAsync();
                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                            };
                        }
            */
            try
            {
                //Upload image file
                //
                await _imageHandler.UploadImage(file);

                // Create DB entry
                //
                var imgUpload = new PropertyImg()
                {
                    PropertyImgTitle = img.PropertyImgTitle,
                    PropertyImgCaption = "images/" + file.FileName, // This field used as the image URL                    
                    PropertyId = img.PropertyId, // "62541",
                    CreatedOn = DateTime.Now
                };
                //Url = "~/Contents/" + file.FileName, // Path.Combine(path, file.FileName),

                await _context.AddAsync(img);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return img;
        }

        public async Task<string> AddImage(IFormFile file, PropertyImg propertyImg)
        {
            //throw new NotImplementedException();

            var imgUpload = new PropertyImg()
            {
                PropertyImgTitle = propertyImg.PropertyImgTitle,
                PropertyImgCaption = "images/" + file.FileName, // This field used as the image URL                    
                PropertyId = propertyImg.PropertyId, // "62541",
                CreatedOn = DateTime.Now
            };

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");

            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    
                    
                }
            }

            await _context.AddAsync(imgUpload);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return file.FileName;
        }



        #endregion
    }
}
