﻿using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Data
{
    public interface IImageRepository
    {
        Task<IEnumerable<PropertyImage>> GetAllImagesForProperty(string propertyId);
        Task<PropertyImage> GetImage(string id);

        // add new roperty document
        Task AddImageAsync(PropertyImage item);

        // remove a single document / roperty
        Task<bool> RemoveImage(PropertyImage id);


        // creates a sample index
        Task<string> CreateIndex();
    }
}
