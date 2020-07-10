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
    public class LeaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        IMessagePublisher _messagePublisher;

        public LeaseController(IMediator mediator, IMessagePublisher messagePublisher)
        {
            _mediator = mediator;
            _messagePublisher = messagePublisher;

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddLease([FromBody] AddLeaseCommand command)
        {
            var newLease = await _mediator.Send(command);

            return Ok(newLease);
        }

        [HttpPost]
        [Route("addTenant")]
        public async Task<IActionResult> AddTenantToLease([FromBody] AddTenantToLeaseCommand command)
        {
            await _mediator.Send(command);

            return Ok("Tenant has been added to the lease!");
        }


        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllLeaseAgreements()
        {
            try
            {
                var leases = await _mediator.Send(new AllLeaseListQuery());

                if (leases == null)
                {
                    return NotFound();
                }

                return Ok(leases);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpGet]
        [Route("tenants")]
        public async Task<IActionResult> GetAllTenants()
        {
            try
            {
                var tenants = await _mediator.Send(new AllTenantListQuery());

                if (tenants == null)
                {
                    return NotFound();
                }

                return Ok(tenants);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        [HttpGet]
        [Route("tenant/{id}")]
        public async Task<IActionResult> GetTenantDetails(int id)
        {
            var getTenant = new TenantDetailsQuery
                {
                    Id = id
                };
            
            try
            {
                var tenant = await _mediator.Send(getTenant);

                if (tenant == null)
                {
                    return NotFound();
                }

                return Ok(tenant);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLeaseAgreementDetails(int id)
        {
            var getLease = new LeaseDetailsQuery
            {
                Id = id
            };

            try
            {
                var leases = await _mediator.Send(getLease);

                if (leases == null)
                {
                    return NotFound();
                }

                return Ok(leases);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateLeaseAgreement([FromBody] UpdateLeaseCommand command)
        {
            if(command == null)
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
        [Route("tenant/update")]
        public async Task<IActionResult> UpdateTenant([FromBody] UpdateTenantCommand command)
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
        [Route("finalize")]
        public async Task<IActionResult> FinalizeLease([FromBody] FinalizeLeaseCommand command)
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

            return Ok();

            //throw new NotImplementedException();
        }


        [HttpPost]
        [Route("inspectioin/add")]
        public async Task<IActionResult> FinalizeLease([FromBody] AddInspectionReportToLeaseCommand command)
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

            return Ok();

            //throw new NotImplementedException();
        }


        [HttpGet]
        [Route("allproperty")]
        public async Task<IActionResult> GetAllRentalProperty()
        {
            try
            {
                var ppts = await _mediator.Send(new AllRentalPropeprtyListQuery());

                if (ppts == null)
                {
                    return NotFound();
                }

                return Ok(ppts);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        [HttpGet]
        [Route("newtenants")]
        public async Task<IActionResult> GetAllNewTenants()
        {
            try
            {
                var ppts = await _mediator.Send(new AlNewTenantsListQuery());

                if (ppts == null)
                {
                    return NotFound();
                }

                return Ok(ppts);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        //************************************
        // The following endpoints have been moved to RentPaymentController
        //************************************

        //[HttpPost]
        //[Route("rent/add")]
        //public async Task<IActionResult> AddRentPayment([FromBody] AddRentPaymentCommand command)
        //{
        //    if (command == null)
        //    {
        //        throw new ArgumentNullException(nameof(command));
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    await _mediator.Send(command);

        //    return Ok();

        //    //throw new NotImplementedException();
        //}


        //[HttpPost]
        //[Route("rent/update")]
        //public async Task<IActionResult> UpdateRentPayment([FromBody] UpdateRentPaymentCommand command)
        //{
        //    if (command == null)
        //    {
        //        throw new ArgumentNullException(nameof(command));
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(400);
        //    }

        //    var lease = await _mediator.Send(command);

        //    return Ok(lease);

        //    //throw new NotImplementedException();
        //}


        //[HttpGet]
        //[Route("renthistory/{id}/{cid}")]
        //public async Task<IActionResult> GetRentPaymentHistoryByLease(int id, int cid) //id: lease id
        //{
        //    var getLease = new RentPaymentHistoryQuery
        //    {
        //        Id = id,
        //        InChargeTenantId = cid
        //    };

        //    try
        //    {
        //        var rentpayment = await _mediator.Send(getLease);

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


        //[HttpGet]
        //[Route("rentpayment/{id}")]
        //public async Task<IActionResult> GetRentPaymentDetails(int id) //id: rent payment id
        //{
        //    var getPayment = new RentPaymentDetailsQuery
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


        [HttpGet]
        [Route("requests/{id}")]
        public async Task<IActionResult> GetServiceRequestByLease(int id)
        {
            var getRequestrList = new ServiceRequestListByLeaseQuery()
            {
                LeaeeId = id
            };

            try
            {
                var requests = await _mediator.Send(getRequestrList);

                if (requests == null)
                {
                    return NotFound();
                }

                return Ok(requests);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpPost]
        [Route("request/update")]
        public async Task<IActionResult> UpdateServiceRequest([FromBody] UpdateServiceCommand command)
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

            return Ok();

            //throw new NotImplementedException();
        }




    }

    
}
