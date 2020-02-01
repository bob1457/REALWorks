using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AssetServer.Queries;

namespace REALWorks.AssetServer.Controllers
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
        [Route("piechart")]
        public async Task<IActionResult> GetPropertyDataPieChart()
        {
            try
            {
                var properties = await _mediator.Send(new GetPieChartDataQuery());

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