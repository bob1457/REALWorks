using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Infrastructure;
using REALWorks.AssetServer.Models;
using REALWorks.AssetServer.Queries;
//using REALWorks.AssetServer.Models;
using REALWorks.AssetServer.Services;
using REALWorks.AssetServer.Services.ViewModels;

namespace REALWorks.AssetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        //private readonly IImageHandler _imageHandler;
        private readonly IMediator _mediator;

        public PropertyController(IPropertyService propertyServic, IMediator mediator)
        {
            _propertyService = propertyServic;
            //_imageHandler = imageHandler;
            _mediator = mediator;
        }

        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> AddProperty([FromBody] PropertyAddViewModel property)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    var ppt = await _propertyService.AddProperty(property);

        //    return Ok(ppt);

        //}


        [HttpPost]
        [Route("asset")]
        public async Task<IActionResult> AddAsset([FromBody] CreatePropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var result = await _mediator.Send(command);

            return Ok(result);

        }


        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllProperties()
        {
            try
            {
                //var properties = await _propertyService.GetAllProperty();

                var properties = await _mediator.Send(new PropertyListQuery());

                if (properties == null)
                {
                    return NotFound();
                }

                return Ok(properties);
            }
            catch (Exception ex)
            {
                throw ex; // For testing
                //return BadRequest(); // For production
            }
        }
/*
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PropertyDetailViewModel>> GetPropertyById(int id)
        {
            var options = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            try
              {
                PropertyDetailViewModel property = await _propertyService.GetPropertyById(id);
                if (property == null)
                {
                    return NotFound();
                }

                return new OkObjectResult(property); //  Ok(property);  //await _propertyService.GetPropertyById(id);
                //return Json(property, options);

            }
            catch (Exception ex) {
                    throw ex;
                }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AssetCore.Entities.Property>> GetPropertyAndOnwers(int id) //id: property id
        {            
            try
            {
                AssetCore.Entities.Property property = await _propertyService.GetPropertyAndOwner(id);
                if (property == null)
                {
                    return NotFound();
                }

                return new OkObjectResult(property); //  Ok(property);  //await _propertyService.GetPropertyById(id);
                //return Json(property, options);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
*/
/**/
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AssetCore.Entities.Property>> GetPropertyDetails(int id) //id: property id -- use MediatR
        {
            var getProperty = new PropertyDetailsQuery
            {
                Id = id
            };

            try
            {
                var property = await _mediator.Send(getProperty); //_propertyService.GetPropertyAndOwner(id);

                if (property == null)
                {
                    return NotFound();
                }

                return new OkObjectResult(property); //  Ok(property);  //await _propertyService.GetPropertyById(id);
                //return Json(property, options);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("owners/{id}")]
        public async Task<IActionResult> GetOwnersByProperty(int id)
        {
            try
            {
                var owners = await _propertyService.GetOwnerListByProperty(id);

                if (owners == null)
                {
                    return NotFound();
                }

                return Ok(owners);

            } catch(Exception ex)
            {
                throw ex;
            }
        }




        //[HttpPost]
        //[Route("addOwner")] 
        //public async Task<IActionResult> AddPropertyOwner([FromBody] OwnerAddViewModel owner)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    await _propertyService.AddOwnerToProperty(owner);

        //    return Ok();
        //}

        [HttpPost]
        [Route("addOwner")]
        public async Task<IActionResult> AddPropertyOwner([FromBody] AddOwnerToExistingPropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            await _mediator.Send(command);

            return Ok();
        }

        //[HttpPost]
        //[Route("addContract")] 
        //public async Task<IActionResult> AddManagementContract([FromBody] ManagementContractAddViewModel contract)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    var ct = await _propertyService.AddManagementContract(contract);

        //    return Ok(ct);
        //}


        [HttpPost]
        [Route("addContract")]
        public async Task<IActionResult> AddManagementContract([FromBody] AddManagementContractCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var ct = await _mediator.Send(command);

            return Ok(ct);
        }


        [HttpGet]
        [Route("contract/{id}")]
        public async Task<IActionResult> GetContractDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var ct = await _propertyService.GetFullContract(id);

            return Ok(ct);
        }





        //[HttpPost]
        //[Route("updateStatus/id/statusId")]
        //public async Task<IActionResult> UpdateRentalStatus(int id, int statusId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    var status = await _propertyService.UpdateRentalStatus(id, statusId);

        //    return Ok(status);
        //}

        //[HttpPost]
        //[Route("status/state")]
        //public async Task<IActionResult> UpdatePropertyStatus(int id, bool status)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    var state = await _propertyService.UpdateProeprtyStatus(id, status);

        //    return Ok(state);
        //}


        [HttpPost]
        [Route("status/state")]
        public async Task<IActionResult> UpdatePropertyStatus(UpdatePropertyStatusCommand command) // Update property rental status
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateProperty(UpdatePropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }



        //[HttpPost]
        //[Route("update")]
        //public async Task<IActionResult> UpdateProperty(PropertyUpdateViewModel property)
        //{

        //    await _propertyService.UpdateProperty(property);

        //    return Ok();
        //}




        //[HttpPost]
        //[Route("owner/update")]
        //public async Task<IActionResult> UpdateOwner(PropertyOwner owner)
        //{
        //    await _propertyService.UpdatePropertyOwner(owner);

        //    return Ok(owner);
        //}

        [HttpPost]
        [Route("owner/update")]
        public async Task<IActionResult> UpdateOwner(UpdatePropertyOwnerCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("contract/update")]
        public async Task<IActionResult> UpdateContract(ManagementContract contract)
        {
            await _propertyService.UpdateContract(contract);

            return Ok(contract);
        }


        //[HttpPost]
        //[Route("img/upload")]
        //public async Task<IActionResult> UploadImage(/**/[FromForm]PropertyImg image, [FromForm]IFormFile file)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //using(var memoryStream = new MemoryStream())
        //    //{
        //    //    await image.PropertyImage.CopyToAsync(memoryStream);
        //    //}

        //    //var file = image.PropertyImage;

        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");
        //    //using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
        //    //{
        //    //    await file.CopyToAsync(fs);

        //    //    // Add image path to DB

                
        //    //    //{
        //    //    //    var imgUpload = new PropertyImg()
        //    //    //    {
        //    //    //        PropertyImgTitle = image.PropertyImgTitle,
        //    //    //        PropertyImgCaption = "images/" + file.FileName, // This field used as the image URL                    
        //    //    //        PropertyId = image.PropertyId, // "62541",
        //    //    //        CreatedOn = DateTime.Now
        //    //    //    };
        //    //    //    //Url = "~/Contents/" + file.FileName, // Path.Combine(path, file.FileName),
                    
        //    //    //};
        //    //}
        //    var filename = await _propertyService.AddImage(file, image);

        //    return Content(filename +" uploaded");
        //}

        [HttpPost]
        [Route("img/add")]
        public async Task<IActionResult> AddImage([FromForm] AddImageToPropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var f = Request.Form.Files;

            command.PropertyImage = f[0];

            if (command.PropertyImage == null || command.PropertyImage.Length == 0)
                return Content("file not selected");

            await _mediator.Send(command);

            return Content("file uploaded successfully!");
        }


    }
}