using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AssetServer.Models;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            try
            {
                var property = await _propertyService.GetPropertyById(id);
                if(property == null)
                {
                    return NotFound();
                }

                return Ok(property);
            }
            catch (Exception ex)
            {
                throw ex; // For testing
                //return BadRequest(); // For production
            }
        }
    }
}