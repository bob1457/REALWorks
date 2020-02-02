using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.MarketingService.Queries;

namespace REALWorks.MarketingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("marketing/piechart")]
        public async Task<IActionResult> GetAllListing()
        {
            try
            {
                var listing = await _mediator.Send(new PieChartDataQuery());

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
        [Route("marketing/barchart")]
        public async Task<IActionResult> GetPropertyDataBarChart()
        {
            try
            {
                var properties = await _mediator.Send(new GetBarChartDataQuery());

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

    }
}