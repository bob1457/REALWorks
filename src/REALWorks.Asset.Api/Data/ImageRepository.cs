using Microsoft.Extensions.Options;
using MongoDB.Driver;
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


        public Task<PropertyImage> GetImage(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveImage(PropertyImage id)
        {
            throw new NotImplementedException();
        }
    }
}
