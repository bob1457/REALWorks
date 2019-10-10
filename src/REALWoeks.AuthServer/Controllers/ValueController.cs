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
            /*
            String APIKey = "75e9a30fdb6750c5c5c5959ba1e0fba6";
            String SecretKey = "91e32634f1b7b24b8135f5380f927e8c";
                        String From = "ml477344@telus.net";
                        String To = "bob.yuan@yahoo.com";

                        MailMessage msg = new MailMessage();

                        msg.From = new MailAddress(From);

                        msg.To.Add(new MailAddress(To));

                        msg.Subject = "Your mail from Gamil";
                        msg.Body = "Your mail from Mailjet, sent by C#.";

                        SmtpClient client = new SmtpClient("in-v3.mailjet.com", 587);
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(APIKey, SecretKey);

                       client.Send(msg);
          */

            return Ok( "Send test email was successful.");
        }

    }
}
