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
    }
}