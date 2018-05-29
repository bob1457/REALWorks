using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using REALWorks.Asset.Api.Model;
using MongoDB.Driver.Linq;




namespace REALWorks.Asset.Api.Data
{
    public class ManagementContractRepository : IManagementContractRepository
    {

        private readonly DbContext _context = null;

        public ManagementContractRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }


        public async Task AddContractAsync(ManagementContract item)
        {
            try
            {
                await _context.ManagementContract.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<string> CreateIndex()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManagementContract>> GetAllManagementContract()
        {
            throw new NotImplementedException();
        }

        public async Task<ManagementContract> GetPropertyManagementContract(string propertyId)
        {
            try
            {
                var query = _context.ManagementContract.AsQueryable<ManagementContract>()
                    .Where(m => m.PropertyId == propertyId);
                return await query.FirstOrDefaultAsync();
            }

            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllContracts()
        {
            //throw new NotImplementedException();
            try
            {
                DeleteResult actionResult
                    = await _context.ManagementContract.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveContract(ObjectId id)
        {
            //throw new NotImplementedException();
            try
            {
                DeleteResult actionResult
                    = await _context.ManagementContract.DeleteOneAsync(
                        Builders<ManagementContract>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<bool> UpdateContract(ObjectId id, ManagementContract contract)
        {
            throw new NotImplementedException();
        }
    }
}
