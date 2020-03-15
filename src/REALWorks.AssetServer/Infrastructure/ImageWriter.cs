using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace REALWorks.AssetServer.Infrastructure
{
    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            //throw new NotImplementedException();


            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            return "Invalid image file";

        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<string> WriteFile(IFormFile file)
        {
            //throw new NotImplementedException();

            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                  //for the file due to security reasons.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return fileName;
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            //throw new NotImplementedException();

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return UploadfileValidator.GetImageFormat(fileBytes) != UploadfileValidator.ImageFormat.unknown;
        }
    }
}
