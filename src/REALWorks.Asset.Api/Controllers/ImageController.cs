using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using REALWorks.Asset.Api.Data;
using REALWorks.Asset.Api.Model;

namespace REALWorks.Asset.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageReposioty, IHostingEnvironment hostingEnvironment)
        {
            _imageRepository = imageReposioty;
            _hostingEnvironment = hostingEnvironment;
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

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Contents\\");
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

        [HttpDelete]
        [Route("delete/{id:length(24)}")]
        public async Task DeleteImageAsync(string id)
        {
            string filePath = _hostingEnvironment.ContentRootPath + "\\Contents";


            // Get the image by id, then URL, then the filename in the URL path

            var imgId = new ObjectId(id);

            PropertyImage img = await _imageRepository.GetImage(imgId);

            int start = img.Url.LastIndexOf("/");

            string fName = img.Url.Substring(start + 1);


            try
            {
                await _imageRepository.RemoveImage(imgId);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

 System.IO.File.Delete(filePath + fName); // Delete the file from storage

        }
    }
}