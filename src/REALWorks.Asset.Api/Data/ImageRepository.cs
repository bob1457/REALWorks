//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Data
{
    public class ImageRepository: IImageRepository
    {
        //delcaring mongo db
        private readonly DbContext _context = null;

        public ImageRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task AddImageAsync(PropertyImage image)
        {
            try
            {
                await _context.PropertyImage.InsertOneAsync(image);
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

        public async Task<IEnumerable<PropertyImage>> GetAllImagesForProperty(string propertyId)
        {
            //throw new NotImplementedException();
            try
            {
                var result = _context.PropertyImage.AsQueryable()
                    .Where(i => i.PropertyId == propertyId);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<PropertyImage> GetImage(ObjectId id)
        {
            //throw new NotImplementedException();
            try
            {                
                var query = _context.PropertyImage.AsQueryable()
                    .Where(p => p.Id == id);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveImage(ObjectId id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.PropertyImage.DeleteOneAsync(
                        Builders<PropertyImage>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
