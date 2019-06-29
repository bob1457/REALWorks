using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using REALWorks.InfrastructureServer.MessageLog;
using IMessageLoggingService = REALWorks.InfrastructureServer.MessageLog.IMessageLoggingService;
using Message = REALWorks.InfrastructureServer.MessageLog.Message;

namespace REALWorks.AssetServer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IMessageLoggingService _loggingService;

        public ValuesController(ILogger<ValuesController> logger, IMessageLoggingService loggingService)
        {
            _logger = logger;
            _loggingService = loggingService;

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            try
            {
                _logger.LogInformation("Accessed here...");
                throw new Exception("break here...");
            }
            catch(Exception e)
            {
                _logger.LogError(e, "It broke :(");
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost] // Testing writing message to Mongodb
        [Route("log")]
        public IActionResult Log([FromBody] Message message)
        {
            var payload = new Payload();

            payload.data = "ferqw";
            payload.data2 = 5;
            payload.data3 = true;

            var bsonPayload = payload.ToBsonDocument();

            message.Payload = bsonPayload;

            _loggingService.LogMessage(message);

            return Ok("logged successfully");
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllMessages()
        {

            var msgs = await _loggingService.GetMessages();

            return Ok(msgs);
        }

    }
}
