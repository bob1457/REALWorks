using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace REALWorks.Asset.Api.Data
{
    public class PropertyRepository: IPropertyRepository
    {
        //delcaring mongo db
        private readonly DbContext _context = null;



        public PropertyRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task AddProperty(Property item)
        {
            try
            {
                await _context.Property.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<Property>> GetAllProperties()
        {
            //throw new NotImplementedException();
            try
            {
                //return await _context.Property
                //        .Find(_ => true).ToListAsync();
                var result = _context.Property.AsQueryable();

                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Property> GetProperty(ObjectId id)
        {
            //throw new NotImplementedException();
            try
            {
                var query = _context.Property.AsQueryable()
                    .Where(p => p.Id == id);

                //var cp = _context.ManagementContract.AsQueryable().Where(c => c.PropertyId == id);

                //var query = from property in _context.Property.AsQueryable()
                //            join contract in _context.ManagementContract.AsQueryable()

                //            on property.Id equals contract.PropertyId   
                //            into ppt
                //            select new
                //            {
                //                Name = property.PropertyName//,
                //                //Contract = cp

                //            };

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task AddOwner(string id, Owner owner)
        {
            try
            {
                await _context.Owner.InsertOneAsync(owner);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddTenantToProperty(string id, Tenant tenant)
        {
            //var propertyId = new ObjectId(id);

            //var property = Builders<Property>.Filter.Eq(p => p.Id, propertyId);

            //var updateBuilder = Builders<Property>.Update.AddToSet(p => p.TenantList, tenant);

            //try
            //{
            //    _context.Property.UpdateOneAsync(property, updateBuilder, new UpdateOptions() { IsUpsert = true }).Wait();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                await _context.Tenant.InsertOneAsync(tenant);
            }
            catch (Exception ex)
            {
                throw ex;
            }            

        }

        public async Task<IEnumerable<Tenant>> GetTenantsForProperty(string id)
        {
            //throw new NotImplementedException();
            var query = _context.Tenant.AsQueryable()
                   .Where(p => p.ProoertyId == id);

            return await query.ToListAsync();
        }


        public async Task<bool> RemoveAllroperties()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Property.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveProperty(ObjectId id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Property.DeleteOneAsync(
                        Builders<Property>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateProperty(ObjectId id, Property property) // This update will update ALL fields of the document
        {

            var filter = Builders<Property>.Filter.Eq(s => s.Id, id);
            var update = Builders<Property>.Update
                            .Set(s => s.PropertyName, property.PropertyName)
                            .Set(a => a.PropertyDesc, property.PropertyDesc)
                            .Set(y => y.YearBuilt, property.YearBuilt)
                            .Set(b => b.PropertyAddress.Addressline1, property.PropertyAddress.Addressline1)
                            .Set(b => b.PropertyAddress.Addressline2, property.PropertyAddress.Addressline2)
                            .Set(b => b.PropertyAddress.City, property.PropertyAddress.City)
                            .Set(b => b.PropertyAddress.ProvinceState, property.PropertyAddress.ProvinceState)
                            .Set(b => b.PropertyAddress.PostZipCode, property.PropertyAddress.PostZipCode)
                            .Set(b => b.PropertyAddress.Country, property.PropertyAddress.Country)
                            .Set(b => b.PropertyFeature.NumOfBathrooms, property.PropertyFeature.NumOfBathrooms)
                            .Set(b => b.PropertyFeature.NumOfBedrooms, property.PropertyFeature.NumOfBedrooms)
                            .Set(b => b.PropertyFeature.NumOfParking, property.PropertyFeature.NumOfParking)
                            .Set(b => b.PropertyFeature.IsBasement, property.PropertyFeature.IsBasement)
                            .Set(b => b.PropertyFeature.IsShared, property.PropertyFeature.IsShared)
                            .Set(b => b.PropertyFeature.Notes, property.PropertyFeature.Notes)
                            .Set(b => b.PropertyFeature.NumOflayers, property.PropertyFeature.NumOflayers)
                            .Set(b => b.PropertyFeature.Others, property.PropertyFeature.Others)
                            .Set(b => b.PropertyFacility.Notes, property.PropertyFacility.Notes)
                            .Set(b => b.PropertyFacility.Fridgerator, property.PropertyFacility.Fridgerator)
                            .Set(b => b.PropertyFacility.StoreOven, property.PropertyFacility.StoreOven)
                            .Set(b => b.PropertyFacility.SecurityAlarm, property.PropertyFacility.SecurityAlarm)
                            .Set(b => b.PropertyFacility.WindowsDrappers, property.PropertyFacility.WindowsDrappers)
                            .Set(b => b.PropertyFacility.SmokeDetector, property.PropertyFacility.SmokeDetector)
                            .Set(b => b.PropertyFacility.TVCable, property.PropertyFacility.TVCable)
                            .Set(b => b.PropertyFacility.Internet, property.PropertyFacility.Internet)
                            //.Set(b => b.PropertyOwner.FirsName, property.PropertyOwner.FirsName) //need a separate operation to update owner(s) in property
                            //.Set(b => b.PropertyOwner.LastName, property.PropertyOwner.LastName)
                            //.Set(b => b.PropertyOwner.Addressline1, property.PropertyOwner.Addressline1)
                            //.Set(b => b.PropertyOwner.Addressline2, property.PropertyOwner.Addressline2)
                            //.Set(b => b.PropertyOwner.City, property.PropertyOwner.City)
                            //.Set(b => b.PropertyOwner.ProvinceState, property.PropertyOwner.ProvinceState)
                            //.Set(b => b.PropertyOwner.PostZipCode, property.PropertyOwner.PostZipCode)
                            //.Set(b => b.PropertyOwner.Country, property.PropertyOwner.Country)
                            //.Set(b => b.PropertyOwner.ContactEmail, property.PropertyOwner.ContactEmail)
                            //.Set(b => b.PropertyOwner.ContactTelephone, property.PropertyOwner.ContactTelephone)
                            .CurrentDate(s => s.DateUpdated);

            try
            {
                UpdateResult actionResult
                    = await _context.Property.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        //public async Task<bool> UpdateropertyDocument(string id, string body)
        //{
        //    throw new NotImplementedException();
        //}

        // it creates a compound index (first using UserId, and then Body)
        // MongoDb automatically detects if the index already exists - in this case it just returns the index details


        public async Task<bool> UpdatePropertyStatus(ObjectId id, string status)
        {
            //throw new NotImplementedException();
            var filter = Builders<Property>.Filter.Eq(s => s.Id, id);

            var update = Builders<Property>.Update
                .Set(s => s.Status, status);

            try
            {
                UpdateResult actionResult
                    = await _context.Property.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            

        }

        public async Task<string> CreateIndex()
        {
            try
            {
                return await _context.Property.Indexes
                                           .CreateOneAsync(Builders<Property>
                                           .IndexKeys
                                           .Ascending(item => item.Id)
                                           .Ascending(item => item.PropertyName));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }



        #region Private Implementation

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }


        #endregion
    }
}
