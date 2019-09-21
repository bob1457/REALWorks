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
    public class RentalApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        IMessagePublisher _messagePublisher;

        public RentalApplicationController(IMediator mediator, IMessagePublisher messagePublisher)
        {
            _mediator = mediator;
            _messagePublisher = messagePublisher;

        }


        [HttpGet]
        [Route("all/{id}")]
        public async Task<IActionResult> GetAllApplicationsByProperty(int id) // all applications for property (on rental property id)
        {
            var getProperty = new ApplicationiListQuery()
            {
                Id = id
            };

            var applications = await _mediator.Send(getProperty);


            return Ok(applications);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationDetails(int id) // application id
        {
            var getApplication = new ApplicationDetailsQuery()
            {
                Id = id
            };

            var application = await _mediator.Send(getApplication);

            return Ok(application);
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddApplication([FromBody] CreateRentalApplicationCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPost]
        [Route("approve")]
        public async Task<IActionResult> ApproveApplication([FromBody] ApproveApplicationCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}