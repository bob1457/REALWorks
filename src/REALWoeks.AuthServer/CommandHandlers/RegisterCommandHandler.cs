using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Events;
using REALWorks.AuthServer.Helpers;
using REALWorks.AuthServer.Models;
using REALWorks.AuthServer.Models.DomainEvents;
using REALWorks.AuthServer.Models.ViewModels;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        IMessagePublisher _messagePublisher;

        private IMediator _mediator;
        //private readonly HttpClient _httpClient;

        public IConfiguration _config { get; }

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,, HttpClient httpClient*/  
            ApplicationDbContext appDbContext, IMessagePublisher messagePublisher, IMediator mediator, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
            _messagePublisher = messagePublisher;
            _mediator = mediator;
            //_httpClient = httpClient;
            _config = configuration;
        }

        


        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var configSection = _config.GetSection("ServiceUri");

            string AssetServiceHost = configSection["Asset"];


            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email, // it is critical here, it comes from client via query string
                AvatarImgUrl = "Images/Avatars/default.png",
                //FirstName = request.FirstName,
                //LastName = request.LastName,
                JoinDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                EmailConfirmed = true,
                UserRole = request.UserRole,
                CustomId = 0,
                IsDisabled = false,
                // The following are not required here
                Telephone1 = request.Telephone1,
                Telephone2 = request.Telephone2,
                AddressStreet = request.AddressStreet,
                AddressCity = request.AddressCity,
                AddressStateProv = request.AddressProvState,
                AddressZipPostCode = request.AddressPostZipCode,
                AddressCountry = request.AddressCountry
            };

            try
            {
                if (user.UserRole != "pm") // Verify the eligibility of registration for users other than property manager (pm) ***********************************
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(AssetServiceHost + "api/Property");
                    var status = await client.GetAsync(client.BaseAddress + "/user/" + user.Email);

                    status.EnsureSuccessStatusCode();
                    string responseBody = await status.Content.ReadAsStringAsync(); //.;CopyToAsync()


                    if (responseBody == "false")
                    {
                        return "Not eligible for self-registration";
                    }


                    // New code *******************************************************************

                    var queryString = AssetServiceHost + "api/Property/userInfo/" + request.Email;
                    var response = await client.GetAsync(queryString);

                    var content = response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(content.Result);

                    bool online = json.SelectToken("onlineEnabled").Value<bool>();

                    if (!online) return "Not eligible for self-registration";


                    //user.Email = json.SelectToken("email").Value<string>(); // it takes from input request
                    user.FirstName = json.SelectToken("firstName").Value<string>();
                    user.LastName = json.SelectToken("lastName").Value<string>();
                    user.Telephone1 = json.SelectToken("telephone1").Value<string>();
                    user.Telephone2 = json.SelectToken("telephone2").Value<string>();
                    user.LastName = json.SelectToken("lastName").Value<string>();
                    user.SocialMediaContact1 = json.SelectToken("socialMediaContact1").Value<string>();
                    user.SocialMediaContact2 = json.SelectToken("socialMediaContact2").Value<string>();
                    user.AddressStreet = json.SelectToken("addressStreet").Value<string>();
                    user.AddressCity = json.SelectToken("addressCity").Value<string>();
                    user.AddressStateProv = json.SelectToken("addressProvState").Value<string>();
                    user.AddressZipPostCode = json.SelectToken("addressPostZipCode").Value<string>();
                    user.AddressCountry = json.SelectToken("addressCountry").Value<string>();

                }
                

                



                // Create the account
                var result = await _userManager.CreateAsync(user, request.Password);

                // Add role to the new user
                var role_resuls = await _userManager.AddToRoleAsync(user, request.UserRole);

                if (!result.Succeeded /*&& !role_resuls.Succeeded*/) return "Registration failed";  //new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                //await _appDbContext.SaveChangesAsync(); // commented out for testing ONLY

                // Raise domain event for email notificaiton or directly invoke email sending

                string subject = "Account Registration";

                // Imporve the follwing with string buidler in C#
                string body = "Dear " + user.FirstName + " " + user.LastName + ":" + "\n" + "Your account registration has completed successfully, you can login now.";
                /*
                               AccountRegistrationEvent e = new AccountRegistrationEvent(user.Email, user.UserName, "", subject, body);

                               await _mediator.Publish(e);

                */
                //Send message to message queue(notificaiton) - integratin event
                EmailNotificationEvent e = new EmailNotificationEvent(Guid.NewGuid(), user.Email, body, subject);

                // Send message to message queue for other service
                //RegisterAccountEvent e = new RegisterAccountEvent(Guid.NewGuid(), user.Email, "ml477344@telus.net", user.UserName,  body, subject); // This event will be re-defined

                // Send message to message queue for other services, e.g.lease service if the roleId is other type, e.g. tenant, vendor, etc.

                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "notification");
                    Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
                }
                catch(Exception ex)
                {
                    //throw ex;
                    Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                }
               
            }
            catch (Exception ex)
            {
                //throw ex;
                return "Error occured: " + ex.Message;
            }

            return "User Account: " + user.UserName + " Successfully Created!";

            //throw new NotImplementedException();
        }
    }
}
