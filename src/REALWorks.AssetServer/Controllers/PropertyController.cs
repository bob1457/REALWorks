using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REALWorks.AssetServer.Models;
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

        public PropertyController(IPropertyService propertyServic)
        {
            _propertyService = propertyServic;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProperty([FromBody] PropertyAddViewModel property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var ppt = await _propertyService.AddProperty(property);

            return Ok(ppt);

        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllProperties()
        {
            try
            {
                var properties = await _propertyService.GetAllProperty();

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
*/
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Property>> GetPropertyAndOnwers(int id)
        {            
            try
            {
                Property property = await _propertyService.GetPropertyAndOwner(id);
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




        [HttpPost]
        [Route("addOwner")] 
        public async Task<IActionResult> AddPropertyOwner([FromBody] OwnerAddViewModel owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            await _propertyService.AddOwnerToProperty(owner);

            return Ok();
        }

        [HttpPost]
        [Route("addContract")] 
        public async Task<IActionResult> AddManagementContract([FromBody] ManagementContractAddViewModel contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var ct = await _propertyService.AddManagementContract(contract);

            return Ok(ct);
        }

        [HttpPost]
        [Route("updateStatus/id/statusId")]
        public async Task<IActionResult> UpdateRentalStatus(int id, int statusId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var status = await _propertyService.UpdateRentalStatus(id, statusId);

            return Ok(status);
        }

        [HttpPost]
        [Route("status/state")]
        public async Task<IActionResult> UpdatePropertyStatus(int id, bool status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var state = await _propertyService.UpdateProeprtyStatus(id, status);

            return Ok(state);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateProperty(PropertyUpdateViewModel property)
        {

            await _propertyService.UpdateProperty(property);

            return Ok();
        }
    }
}