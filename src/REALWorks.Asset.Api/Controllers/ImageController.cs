using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.Asset.Api.Data;
using REALWorks.Asset.Api.Model;

namespace REALWorks.Asset.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageReposioty)
        {
            _imageRepository = imageReposioty;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file, PropertyImage image)// [FromBody] PropertyImage image)    //public async Task<IActionResult> UploadImage(IFormFile file, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (file == null || file.Length == 0)
                return Content("file not selected");

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Contents");
            using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
            {
                await file.CopyToAsync(fs);

                // Add image path to DB

                await _imageRepository.AddImageAsync(new PropertyImage
                {
                    Url = "~/Contents/" + file.FileName, // Path.Combine(path, file.FileName),
                    Caption = "First image for the property",
                    PropertyId = image.PropertyId, // "62541",
                    DateAdded = DateTime.Now
                });
            }

            return Content("file uploaded");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IEnumerable<PropertyImage>> GetAllImageForProperty(string id)
        {
            return await _imageRepository.GetAllImagesForProperty(id);
        }
    }
}