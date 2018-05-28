using MongoDB.Bson;
using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Data
{
    public interface IManagementContractRepository
    {
        Task<IEnumerable<ManagementContract>> GetAllManagementContract();

        Task<ManagementContract> GetPropertyManagementContract(string id);

        // add new roperty document
        Task AddContractAsync(ManagementContract item);

        // remove a single document / roperty
        Task<bool> RemoveContract(ObjectId id);

        // update just a single document / roperty
        Task<bool> UpdateContract(ObjectId id, ManagementContract contract);

        // demo interface - full document update
        //Task<bool> UpdateropertyDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllContracts();

        // creates a sample index
        Task<string> CreateIndex();
    }
}
