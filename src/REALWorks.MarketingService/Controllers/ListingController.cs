using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.Queries;
using REALWorks.MessagingServer.Messages;

namespace REALWorks.MarketingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IMediator _mediator;
        IMessagePublisher _messagePublisher;

        public ListingController(IMediator mediator, IMessagePublisher messagePublisher)
        {
            _mediator = mediator;
            _messagePublisher = messagePublisher;

        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllListing()
        {
            try
            {
                var listing = await _mediator.Send(new PropertyListingListQuery());

                if (listing == null)
                {
                    return NotFound();
                }

                 return Ok(listing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

           
        }

        /// <summary>
        /// The following two endpoints are for public website to see for rent listing and details
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("show")]
        public async Task<IActionResult> ShowAllListing()
        {
            try
            {
                var listing = await _mediator.Send(new PublishedListingQuery());

                if (listing == null)
                {
                    return NotFound();
                }

                return Ok(listing);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        [HttpGet]
        [Route("showdetails/{id}")]
        public async Task<IActionResult> ShowListingDetails(int id)
        {
            try
            {
                var getListing = new PropertyListingDetailsQuery()
                {
                    Id = id
                };

                var listing = await _mediator.Send(getListing);

                if (listing == null)
                {
                    return NotFound();
                }

                return Ok(listing);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }





        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetListingDetails(int id)
        {
            var getListing = new PropertyListingDetailsQuery()
            {
                Id = id
            };

            var listing = await _mediator.Send(getListing);

            return Ok(listing);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddListing([FromBody] CreatePropertyListingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }



        [HttpPost]
        [Route("status")]
        public async Task<IActionResult> StatusUpdate([FromBody] UpldatePropertyLisitngStatusCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpGet]
        [Route("allimgs")]
        public async Task<IActionResult> GetAllPropertyImages()
        {
            try
            {
                var listing = await _mediator.Send(new AllPropertyImagesListQuery());

                if (listing == null)
                {
                    return NotFound();
                }

                return Ok(listing);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        [HttpPost]
        [Route("addimg")]
        public async Task<IActionResult> AddImageToRentalProperty([FromForm] AddImageToPropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var f = Request.Form.Files;

            command.PropertyImage = f[0];

            if (command.PropertyImage == null || command.PropertyImage.Length == 0)
                return Content("file not selected");

            var result = await _mediator.Send(command);

            //return Content("Image uploaded successfully!");
            return Ok(result);
        }

        [HttpPost]
        [Route("removeimg")]
        public async Task<IActionResult> RemoveImageToRentalProperty([FromForm] RemoveImageToPropertyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Content("Image removed successfully!");
        }

        /// <summary>
        /// Listing status update involves related rental property status change
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateListing([FromBody] UpdatePropertyListingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// This endpoint simply remove/de-activate the listing without affecting rental property status, e.g cancel the lisitng
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveListing([FromBody] RemovePropertyListingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("allrentalproperties")]
        public async Task<IActionResult> GetAllRentalProperties()
        {
            try
            {
                var properties = await _mediator.Send(new AllRentalPropertiesQuery());

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

        #region Open House


        [HttpGet]
        [Route("property/id")]
        public async Task<IActionResult> GetRentalPropertyDetails(int id)
        {
            var getProperty = new RentalPropertyDetailsQuery()
            {
                Id = id
            };

            var property = await _mediator.Send(getProperty);

            return Ok(property);
        }

        [HttpPost]
        [Route("addopenhouse")]
        public async Task<IActionResult> AddOpenHouse([FromBody] CreateOpenHouseCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("updatepenhouse")]
        public async Task<IActionResult> UpdateOpenHouse([FromBody] CreateOpenHouseCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("openhouse/addviewer")]
        public async Task<IActionResult> AddOpenHouseViewer([FromBody] CreateOpenHouseAttendeeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        #endregion


    }
}