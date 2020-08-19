using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.Queries;
using REALWorks.MessagingServer.Messages;

namespace REALWork.LeaseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalPaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        IMessagePublisher _messagePublisher;

        public RentalPaymentController(IMediator mediator, IMessagePublisher messagePublisher)
        {
            _mediator = mediator;
            _messagePublisher = messagePublisher;

        }

        [HttpPost]
        [Route("rent/add")]
        public async Task<IActionResult> AddRentPayment([FromBody] AddRentPaymentCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var result = await _mediator.Send(command);

            return Ok(result);

            //throw new NotImplementedException();
        }


        [HttpPost]
        [Route("rent/update")]
        public async Task<IActionResult> UpdateRentPayment([FromBody] UpdateRentPaymentCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var lease = await _mediator.Send(command);

            return Ok(lease);

            //throw new NotImplementedException();
        }


        [HttpGet]
        [Route("renthistory/{id}/{cid}")]
        public async Task<IActionResult> GetRentPaymentHistoryByLease(int id, int cid) //id: lease id
        {
            var getLease = new RentPaymentHistoryQuery
            {
                Id = id,
                InChargeTenantId = cid
            };

            try
            {
                var rentpayment = await _mediator.Send(getLease);

                if (rentpayment == null)
                {
                    return NotFound();
                }

                return Ok(rentpayment);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpGet]
        [Route("rentpayment/{id}")]
        public async Task<IActionResult> GetRentPaymentDetails(int id) //id: rent payment id
        {
            var getPayment = new RentPaymentDetailsQuery
            {
                Id = id,
            };

            try
            {
                var rentpayment = await _mediator.Send(getPayment);

                if (rentpayment == null)
                {
                    return NotFound();
                }

                return Ok(rentpayment);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}