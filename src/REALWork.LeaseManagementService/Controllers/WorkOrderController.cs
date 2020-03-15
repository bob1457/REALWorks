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
    public class WorkOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        IMessagePublisher _messagePublisher;

        public WorkOrderController(IMediator mediator, IMessagePublisher messagePublisher)
        {
            _mediator = mediator;
            _messagePublisher = messagePublisher;

        }

        //[HttpGet]
        //[Route("renthistory/{id}")]
        //public async Task<IActionResult> GetRentPaymentDetails(int id) //id: lease id
        //{
        //    var getPayment = new RentPaymentHistoryQuery
        //    {
        //        Id = id,
        //    };

        //    try
        //    {
        //        var rentpayment = await _mediator.Send(getPayment);

        //        if (rentpayment == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(rentpayment);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}

        [HttpPost]
        [Route("vendor/add")]
        public async Task<IActionResult> AddVendor([FromBody] AddVendorCommand command)
        {
            await _mediator.Send(command);

            return Ok("Vendor added!");
        }


        [HttpPost]
        [Route("vendor/update")]
        public async Task<IActionResult> UpdateVandor([FromBody] UpdateVendorCommand command)
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

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddWorkOrder([FromBody] AddWorkOrderCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var order = await _mediator.Send(command);

            return Ok(order);
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateWorkOrder([FromBody] UpdateWorkOrderCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var order = await _mediator.Send(command);

            return Ok(order);
        }


        [HttpGet]
        [Route("rental/{id}")]
        public async Task<IActionResult> GetAllWorkOrders(int id)
        {
            var getOrderList = new WorkOrderListForPropertyQuery()
            {
                PropertyId = id
            };

            try
            {
                var orders = await _mediator.Send(getOrderList);

                if (orders == null)
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        [HttpPost]
        [Route("invoice/add")]
        public async Task<IActionResult> AddInvoiceToWorkOrder([FromBody] AddInvoiceToWorkOrderCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var order = await _mediator.Send(command);

            return Ok(order);
        }


        [HttpPost]
        [Route("invoice/update")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            await _mediator.Send(command);

            return Ok("Invoice has been updated!");
        }



        [HttpPost]
        [Route("request/add")]
        public async Task<IActionResult> AddServiceRequest([FromBody] AddServiceRequestCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var request = await _mediator.Send(command);

            return Ok(request);
        }


        //[HttpGet]
        //[Route("request/{id}")]
        //public async Task<IActionResult> GetServiceRequestForLease(int id)
        //{
        //    var getRequestrList = new ServiceRequestListByLeaseQuery()
        //    {
        //        LeaeeId = id
        //    };

        //    try
        //    {
        //        var requests = await _mediator.Send(getRequestrList);

        //        if (requests == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(requests);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}

    }
}
