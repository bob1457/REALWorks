﻿using System;
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

            await _mediator.Send(command);

            return Content("file uploaded successfully!");
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateListing([FromBody] UpdatePropertyListingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

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
        [Route("openhouse/addviewer")]
        public async Task<IActionResult> AddOpenHouseViewer([FromBody] CreateOpenHouseAttendeeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


    }
}