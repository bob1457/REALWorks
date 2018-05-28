using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using REALWorks.Asset.Api.Model;

namespace REALWorks.Asset.Api.Data
{
    public class ManagementContractRepository : IManagementContractRepository
    {

        private readonly DbContext _context = null;

        public ManagementContractRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }


        public Task AddContract(ManagementContract item)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateIndex()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManagementContract>> GetAllManagementContract()
        {
            throw new NotImplementedException();
        }

        public Task<ManagementContract> GetPropertyManagementContract(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllContracts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveContract(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContract(ObjectId id, ManagementContract contract)
        {
            throw new NotImplementedException();
        }
    }
}
