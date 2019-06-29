using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Events;
using REALWorks.AuthServer.Models;
using REALWorks.MessagingServer.Messages;
using System;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.EventHandlers
{
    public class EventHandler : IMessageHandlerCallback
    {
        IMessageHandler _messageHandler;
        private readonly ApplicationDbContext _appDbContext;

        
        private readonly UserManager<ApplicationUser> _userManager;

        public EventHandler(IMessageHandler messageHandler, ApplicationDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _messageHandler = messageHandler;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        

        //public EventHandler(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);

            try
            {
                switch (messageType)
                {
                    case "EnableOnlineAccessEvent":
                        await HandleAsync(messageObject.ToObject<EnableOnlineAccessEvent>());//, _userManager);
                        break;
                    //case "VehicleRegistered":
                    //    await HandleAsync(messageObject.ToObject<VehicleRegistered>());
                    //    break;
                    //case "MaintenanceJobPlanned":
                    //    await HandleAsync(messageObject.ToObject<MaintenanceJobPlanned>());
                    //    break;
                    //case "MaintenanceJobFinished":
                    //    await HandleAsync(messageObject.ToObject<MaintenanceJobFinished>());
                    //    break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            catch (Exception ex)
            {

            }

            return true;

            //throw new NotImplementedException();
        }

        private async Task<bool> HandleAsync(EnableOnlineAccessEvent onlineAccessEnabledEvent)//, [FromServices]UserManager<ApplicationUser> _userManager)
        {
            
            var user = new ApplicationUser
            {
                UserName = onlineAccessEnabledEvent.UserName,
                Email = onlineAccessEnabledEvent.Email,
                AvatarImgUrl = "Images/Avatars/default.png",
                FirstName = onlineAccessEnabledEvent.FirstName,
                LastName = onlineAccessEnabledEvent.LastName,
                JoinDate = DateTime.Now,
                EmailConfirmed = true,
                UserRole = onlineAccessEnabledEvent.UserRole
            };

            try
            {
                var result = await _userManager.CreateAsync(user, onlineAccessEnabledEvent.Password);

                var role_resuls = await _userManager.AddToRoleAsync(user, onlineAccessEnabledEvent.UserRole);

                if (!result.Succeeded /*&& !role_resuls.Succeeded*/) return false; // BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return true;

            //throw new NotImplementedException();
        }

        
    }
}
