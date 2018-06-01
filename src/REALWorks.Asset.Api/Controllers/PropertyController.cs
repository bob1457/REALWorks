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
                WaherDryer = property.PropertyFacility.WaherDryer,
                Internet = property.PropertyFacility.Internet,
                SecurityAlarm = property.PropertyFacility.SecurityAlarm,
                SmokeDetector = property.PropertyFacility.SmokeDetector,
                TVCable = property.PropertyFacility.TVCable,
                WindowsDrappers = property.PropertyFacility.WindowsDrappers,
                StoreOven = property.PropertyFacility.StoreOven,
                Notes = property.PropertyFacility.Notes
            };

            var owner = new Owner()
            {
                FirsName = property.PropertyOwner.FirsName,
                LastName = property.PropertyOwner.LastName,
                Addressline1 = property.PropertyOwner.Addressline1,
                Addressline2 = property.PropertyOwner.Addressline2,
                City = property.PropertyOwner.City,
                ProvinceState = property.PropertyOwner.ProvinceState,
                PostZipCode = property.PropertyOwner.PostZipCode,
                Country = property.PropertyOwner.Country,
                ContactEmail = property.PropertyOwner.ContactEmail,
                ContactTelephone = property.PropertyOwner.ContactTelephone
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
                    PropertyOwner = owner,
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

            
            try
            {
                _propertyRepository.AddTenantToProperty(id, tnt);
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
    }
}