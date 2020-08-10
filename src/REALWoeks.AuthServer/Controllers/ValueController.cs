using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using REALWorks.AuthServer.Services;

using System.Net;
using System.Net.Mail;

namespace REALWorks.AuthServer.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]     
    public class ValueController : Controller
    {

        private readonly IEmailSender _emailSender;
        public ValueController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
      // GET api/values
      [HttpGet]
      public IEnumerable<string> Get()
      {
        return new string[] { "value1_secured", "value2_secured" };
      }

      [HttpGet]
      [Route("hello")]
      public string SayHello()
      {
         return "Hello!";
      }

      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
        return "value";
      }

      // POST api/values
      [HttpPost]
      public void Post([FromBody]string value)
      {
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]string value)
      {
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }

        [HttpPost]
        [Route("api/sendmail")]
        public async Task<IActionResult> SendMail([FromBody]string value)
        {
            var email = "bob.yuan@yahoo.com";

            var subject = "Email Test";

            var message = "This is a test message.";

            await _emailSender.SendEmailAsync(email, subject, message);
           

            return Ok( "Send test email was successful.");
        }

    }
}
