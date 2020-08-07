using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REALWorks.NotificationService.Services.EmailService;
using REALWorks.NotificationService.Services.MessageService;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace REALWorks.NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        private readonly ITwilioRestClient _client;

        //private readonly ISMTPMailSender _smtpMailSender;

        public ValuesController(IEmailSender emailSender, ISmsSender smsSender, ITwilioRestClient client)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
            _client = client;
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

            var message = "This is a test message with configuration parameters.";

            var result = await _emailSender.SendEmailAsync(email, subject, message);
            

            return Ok(result);
        }

        [HttpPost]
        [Route("sendsms")]
        public async Task<IActionResult> SendSmsText(/*MessageModel model*/)
        {

            //var message = MessageResource.Create(
            //    to: new PhoneNumber(model.To),
            //    from: new PhoneNumber(model.From),
            //    body: model.Message,
            //    client: _client); // pass in the custom client

            //return Ok(message.Sid);

            string from = "+16042434804";
            string to = "16043497898";
            string content = "Test sms....with config data";

            var result = _smsSender.SendTextAsync(to, from, content);

            return Ok(result);
        }
    }
}
