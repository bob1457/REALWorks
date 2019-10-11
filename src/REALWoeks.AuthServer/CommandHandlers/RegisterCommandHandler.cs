using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Events;
using REALWorks.AuthServer.Helpers;
using REALWorks.AuthServer.Models;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;

using System.Collections.Generic;
using System.Linq;
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


        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/  ApplicationDbContext appDbContext, IMessagePublisher messagePublisher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
            _messagePublisher = messagePublisher;
        }

        

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                AvatarImgUrl = "Images/Avatars/default.png",
                FirstName = request.FirstName,
                LastName = request.LastName,
                JoinDate = DateTime.Now,
                EmailConfirmed = true,
                UserRole = request.UserRole,
                CustomId = 0,
                IsDisabled = false
            };

            try
            {
                // Create the account
                var result = await _userManager.CreateAsync(user, request.Password);

                // Add role to the new user
                var role_resuls = await _userManager.AddToRoleAsync(user, request.UserRole);

                //if (!result.Succeeded /*&& !role_resuls.Succeeded*/) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                await _appDbContext.SaveChangesAsync(); // commented out for testing ONLY

                string subject = "";
                string body = "";

                // Send message to message queue (notificaiton)
                RegisterAccountEvent e = new RegisterAccountEvent(Guid.NewGuid(), user.Email, user.UserName, "", body, subject);

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
