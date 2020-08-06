using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REALWorks.NotificationService.Services.EmailService;

namespace REALWorks.NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        //private readonly ISMTPMailSender _smtpMailSender;

        public ValuesController(IEmailSender emailSender/*, ISMTPMailSender smtpMailSender*/)
        {
            _emailSender = emailSender;
            //_smtpMailSender = smtpMailSender;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
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

        [HttpPost]
        [Route("sendmail")]
        public async Task<IActionResult> SendMail([FromBody]string value)
        {
            var emails = new List<string>();

            var email = "bob.yuan@yahoo.com";

            emails.Add(email);

            var subject = "Email Test";

            var message = "This is a test message.";

            var result = await _emailSender.SendEmailAsync(email, subject, message);
            //await _smtpMailSender.SendEmailAsync(email, "", subject, message);
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

            return Ok(result);
        }
    }
}
