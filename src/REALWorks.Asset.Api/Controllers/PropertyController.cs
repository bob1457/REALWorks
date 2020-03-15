using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using REALWorks.Asset.Api.Data;
using REALWorks.Asset.Api.Model;

namespace REALWorks.Asset.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        #region Testing

        [HttpPost]
        [Route("owner")]
        public async Task<IActionResult> AddOwner(Owner owner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //await _propertyRepository.AddOwner();
            return Ok(owner);
        }

        [HttpPost]
        [Route("init")]
        public void Initialize() // Add initial/seed data (for testing purposes) - for property 
        {
            var address = new Address()
            {
                Addressline1 = "10621 158A Street",
                Addressline2 = "",
                City = "Surrey",
                ProvinceState = "BC",
                PostZipCode = "V4N 3J2",
                Country ="Canada"
            };




            var feature = new Feature()
            {
                IsBasement = false,
                IsShared = false,
                NumOfBathrooms = "3",
                NumOfBedrooms = "4",
                TotalArea = "2400",
                NumOflayers = "2",
                NumOfParking = "2",
                Others = "",
                Notes = ""
            };

            var facility = new Facility()
            {
                CommonArea = false,
                Fridgerator = true,
                WasherDryer = true,
                Internet = false,
                SecurityAlarm = false,
                SmokeDetector = true,
                TVCable = false,
                WindowsDrappers = true,
                StoreOven = true,
                Notes = ""
            };

            /* // need a separate operation to add owner(s) to property*/

            var owner = new Owner()
            {
                OwnerId = "5b731f5752c40e3944cdfb51",
                FirsName = "Michelle",
                LastName = "Lu",
                Addressline1 = "15686 107 Avenue",
                Addressline2 = "",
                City = "Surrey",
                ProvinceState = "BC",
                PostZipCode = "V4N 3H8",
                Country = "Canada",
                ContactEmail = "778-863-0550",
                ContactTelephone = "cadlu2000@yahoo.com",
                OwnedProperty = {
                    "6bc731f5752c40e3944cdfb40"
                },

                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now

            };

            try
            {
                _propertyRepository.AddOwner("6bc731f5752c40e3944cdfb40", owner);

                _propertyRepository.AddProperty(new Property
                {
                    //Id = property.Id,
                    PropertyName = "10621 Fraser Height",
                    PropertyDesc = "Two level family home in North Surrey",
                    Category = "Single Family Home",
                    YearBuilt = 1996,

                    PropertyAddress = address,
                    PropertyFacility = facility,
                    PropertyFeature = feature,

                    //PropertyOwner = owner,
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        #endregion

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Property>> GetAll()
        {
            return await _propertyRepository.GetAllProperties();
        }

        [HttpGet]
        [Route("{id:length(24)}")]
        public async Task<Property> GetProperty(string id) //(ObjectId id)
        {
            var propertyId = new ObjectId(id);

            return await _propertyRepository.GetProperty(propertyId);
        }

        [HttpPost]
        [Route("add")]
        public void AddProperty([FromBody] Property property)
        {
            var address = new Address()
            {
                Addressline1 = property.PropertyAddress.Addressline1,
                Addressline2 = property.PropertyAddress.Addressline2,
                City = property.PropertyAddress.City,
                ProvinceState = property.PropertyAddress.ProvinceState,
                PostZipCode = property.PropertyAddress.PostZipCode,
                Country = property.PropertyAddress.Country
            };




            var feature = new Feature()
            {
                IsBasement = property.PropertyFeature.IsBasement,
                IsShared = property.PropertyFeature.IsShared,
                NumOfBathrooms = property.PropertyFeature.NumOfBathrooms,
                NumOfBedrooms = property.PropertyFeature.NumOfBedrooms,
                TotalArea = property.PropertyFeature.TotalArea,
                NumOflayers = property.PropertyFeature.NumOflayers,
                NumOfParking = property.PropertyFeature.NumOfParking,
                Others = property.PropertyFeature.Others,
                Notes = property.PropertyFeature.Notes
            };

            var facility = new Facility()
            {
                CommonArea = property.PropertyFacility.CommonArea,
                Fridgerator = property.PropertyFacility.Fridgerator,
                WasherDryer = property.PropertyFacility.WasherDryer,
                Internet = property.PropertyFacility.Internet,
                SecurityAlarm = property.PropertyFacility.SecurityAlarm,
                SmokeDetector = property.PropertyFacility.SmokeDetector,
                TVCable = property.PropertyFacility.TVCable,
                WindowsDrappers = property.PropertyFacility.WindowsDrappers,
                StoreOven = property.PropertyFacility.StoreOven,
                Notes = property.PropertyFacility.Notes
            };

            /* // need a separate operation to add owner(s) to property*/

            var owner = new List<Owner>()
            {
                //FirsName = property.PropertyOwner.FirsName,
                //LastName = property.PropertyOwner.LastName,
                //Addressline1 = property.PropertyOwner.Addressline1,
                //Addressline2 = property.PropertyOwner.Addressline2,
                //City = property.PropertyOwner.City,
                //ProvinceState = property.PropertyOwner.ProvinceState,
                //PostZipCode = property.PropertyOwner.PostZipCode,
                //Country = property.PropertyOwner.Country,
                //ContactEmail = property.PropertyOwner.ContactEmail,
                //ContactTelephone = property.PropertyOwner.ContactTelephone
                
            };

            try
            {
                _propertyRepository.AddProperty(new Property
                {
                    Id = property.Id,
                    PropertyName = property.PropertyName,
                    PropertyDesc = property.PropertyDesc,
                    Category = property.Category,
                    YearBuilt = property.YearBuilt,

                    PropertyAddress = address,
                    PropertyFacility = facility,
                    PropertyFeature = feature,

                    //PropertyOwner = owner,
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }

        [HttpPost]
        [Route("addOwner/{id}")] //id:property Id
        public void AddOwnerToProperty(string id, Owner owner)
        {

            /**/
            var propertyOwner = new Owner()
            {
                FirsName = owner.FirsName,
                LastName = owner.LastName,
                Addressline1 = owner.Addressline1,
                Addressline2 = owner.Addressline2,
                City = owner.City,
                ProvinceState = owner.ProvinceState,
                PostZipCode = owner.PostZipCode,
                Country = owner.Country,
                ContactTelephone = owner.ContactTelephone,
                ContactEmail = owner.ContactEmail,
                

                CreatedOn = owner.CreatedOn,
                UpdatedOn = owner.UpdatedOn
            };

            try
            {
                _propertyRepository.AddOwner(id, propertyOwner);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            //var doc = CreateOwner(id, owner).ToBsonDocument();


            //var ownerId = new ObjectId(doc.GetElement("_id").Value.ToString());  // new ObjectId(""); // owner.ObjectId; //new Owner()
            var oId = "5bfa17b5efde9332a03768b0";

            var ownerId = new ObjectId(oId);
            //{
            //FirsName = owner.FirsName,
            //    LastName = owner.LastName,
            //    Addressline1 = owner.Addressline1,
            //    Addressline2 = owner.Addressline2,
            //    City = owner.City,
            //    ProvinceState = owner.ProvinceState,
            //    PostZipCode = owner.PostZipCode,
            //    Country = owner.Country,
            //    ContactTelephone = owner.ContactTelephone,
            //    ContactEmail = owner.ContactEmail,

            //    CreatedOn = owner.CreatedOn,
            //    UpdatedOn = owner.UpdatedOn

            //};

            var ownerList = new List<ObjectId>();
            ownerList.Add(ownerId);

            var propertyId = new ObjectId(id);
            // find the by Id
            var property = _propertyRepository.GetProperty(propertyId).ToBsonDocument();
            
            try
            {
                property.Add("PropertyOwners", new BsonArray( ownerList) );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("addTenant/{id}")]
        public void AddTenantToProperty(string id, Tenant tenant) // It runs whenever the property is rented
        {
            var tnt = new Tenant()
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                ContactEmail = tenant.ContactEmail,
                ContactTelephone = tenant.ContactTelephone,
                ProoertyId = id,
                MoveInDate = tenant.MoveInDate,
                RentalStartDate = tenant.RentalStartDate,
                MoveOutDate = tenant.MoveOutDate,
                RentalEndDate = tenant.RentalEndDate,
                Notes = tenant.Notes,

                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            var tenantList = new List<Tenant>();
            tenantList.Add(tnt);

            var propertyId = new ObjectId(id);
            // find the by Id
            var property = _propertyRepository.GetProperty(propertyId).ToBsonDocument();

            try
            {
                //_propertyRepository.AddTenantToProperty(id, tnt);
                property.Add("PropertyTenants", new BsonArray(tenantList));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        [HttpGet]
        [Route("tenant/{id}")]
        public async Task<IEnumerable<Tenant>> GetTenantsForProperty(string id)
        {
            return await _propertyRepository.GetTenantsForProperty(id);
        }

        [HttpPut]
        [Route("{id:length(24)}")]
        public void UpdateProperty(string id, [FromBody] Property value)
        {
            var propertyId = new ObjectId(id);

            _propertyRepository.UpdateProperty(propertyId, value);
        }


        [HttpPost]
        [Route("status/id:length(24)")]
        public void UpdatePropertyStatus(string id, string status)
        {
            var propertyId = new ObjectId(id);

            _propertyRepository.UpdatePropertyStatus(propertyId, status);
        }




        [HttpDelete]
        [Route("delete/{id:length(24)}")]
        public void DeleteProperty(string id)
        {
            var propertyId = new ObjectId(id);

            _propertyRepository.RemoveProperty(propertyId);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteAllProperty()
        {
            _propertyRepository.RemoveAllroperties();
        }

        #region Private Implementation

        private Task CreateOwner(string id, Owner owner)
        {
            var propertyOwner = new Owner()
            {
                FirsName = owner.FirsName,
                LastName = owner.LastName,
                Addressline1 = owner.Addressline1,
                Addressline2 = owner.Addressline2,
                City = owner.City,
                ProvinceState = owner.ProvinceState,
                PostZipCode = owner.PostZipCode,
                Country = owner.Country,
                ContactTelephone = owner.ContactTelephone,
                ContactEmail = owner.ContactEmail,

                CreatedOn = owner.CreatedOn,
                UpdatedOn = owner.UpdatedOn
            };

            try
            {
                return _propertyRepository.AddOwner(id, propertyOwner);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}