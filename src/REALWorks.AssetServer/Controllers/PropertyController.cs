using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Queries;


namespace REALWorks.AssetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyController(  IMediator mediator)
        {
           _mediator = mediator;
        }


        #region Properties Management

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
                var properties = await _mediator.Send(new PropertyListQuery());

                if (properties == null)
                {
                    return NotFound();
                }

                return Ok(properties);
            }
            catch (Exception ex)
            {
                throw ex;   
                
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AssetCore.Entities.Property>> GetPropertyDetails(int id)      
        {
            var getProperty = new PropertyDetailsQuery
            {
                Id = id
            };

            try
            {
                var property = await _mediator.Send(getProperty); 

                if (property == null)
                {
                    return NotFound();
                }

                return Ok(property);     
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveProperty(DeletePropertyCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("status/state")]
        public async Task<IActionResult> UpdatePropertyStatus(UpdatePropertyStatusCommand command)     
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


        [HttpPost]
        [Route("pm/assign")]
        public async Task<IActionResult> AssignPmToProperty([FromBody] AssignPMtoPropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);

        }

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

        [HttpPost]
        [Route("img/delete")]
        public async Task<IActionResult> DeleteImage([FromBody] DeleteImageFromPropertyCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        #endregion


        #region Property Owner Management

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


        [HttpPost]
        [Route("owner/update")]
        public async Task<IActionResult> UpdateOwner(UpdatePropertyOwnerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("owner/remove")]
        public async Task<IActionResult> RemoveOwnerFromProperty(RemoveOwnerFromPropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        #endregion



        [HttpPost]
        [Route("contract/add")]
        public async Task<IActionResult> AddManagementContract([FromBody] AddManagementContractCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var ct = await _mediator.Send(command);

            return Ok(ct);
        }
        

        [HttpPost]
        [Route("contract/update")]
        public async Task<IActionResult> UpdateManagementContract([FromBody] UpdateManagementContractCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

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
            var getContract = new ManagementContractQuery
            {
                Id = id
            };
                        
            var ct = await _mediator.Send(getContract);

            return Ok(ct);
        }

        [HttpGet]
        [Route("contracts/{id}")]       
        public async Task<IActionResult> GetContractsByProoperty(int id)
        {
            var getContractList = new ManagementContractListQuery
            {
                Id = id
            };

            var list = await _mediator.Send(getContractList);

            return Ok(list);

            
        }

    }
}