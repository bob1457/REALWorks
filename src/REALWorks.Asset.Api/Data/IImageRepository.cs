using MongoDB.Bson;
using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Data
{
    public interface IImageRepository
    {
        Task<IEnumerable<PropertyImage>> GetAllImagesForProperty(string propertyId);

        Task<PropertyImage> GetImage(ObjectId id);

        // add new roperty document
        Task AddImageAsync(PropertyImage item);

        // remove a single document / roperty
        Task<bool> RemoveImage(ObjectId id);


        // creates a sample index
        Task<string> CreateIndex();
    }
}
