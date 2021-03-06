﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Infrastructure
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
    }
}
