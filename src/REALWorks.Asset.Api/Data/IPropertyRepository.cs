using MongoDB.Bson;
using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Data
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllProperties();
        Task<Property> GetProperty(ObjectId id);

        // add new roperty document
        Task Addroperty(Property item);

        // remove a single document / roperty
        Task<bool> RemoveProperty(ObjectId id);

        // update just a single document / roperty
        Task<bool> Updateroperty(ObjectId id, Property body);

        // demo interface - full document update
        //Task<bool> UpdateropertyDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllroperties();

        // creates a sample index
        Task<string> CreateIndex();
    }
}
