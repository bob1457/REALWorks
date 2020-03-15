using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AuthServer.Data;
using Microsoft.AspNetCore.Identity;
using REALWorks.AuthServer.Models;
using REALWorks.AuthServer.Models.ViewModels;
using REALWorks.AuthServer.Helpers;
using System.Security.Claims;
using MediatR;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Events;
using Serilog;
using REALWorks.MessagingServer.Messages;

namespace REALWorks.AuthServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator; // Only this one is required

        private readonly ApplicationDbContext _appDbContext;

        // The following are not required
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        //private readonly IMapper _mapper;

        IMessagePublisher _messagePublisher;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/IMessagePublisher messagePublisher,  ApplicationDbContext appDbContext, IMediator mediator)
        {
          _userManager = userManager;
          _roleManager = roleManager;
          //_mapper = mapper;
          _messagePublisher = messagePublisher;
          _appDbContext = appDbContext;
          _mediator = mediator;
        }
/*
        // account registration
        [HttpPost]
        [Route("register1")]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
          if (!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }

          var user = new ApplicationUser
          {
            UserName = model.UserName,
            Email = model.Email,
            AvatarImgUrl = "Images/Avatars/default.png",
            FirstName = model.FirstName,
            LastName = model.LastName,
            JoinDate = DateTime.Now,
            EmailConfirmed = true,
            UserRole = model.UserRole
          };


        // Create the account
        var result = await _userManager.CreateAsync(user, model.Password);
          
          // Add role to the new user
          var role_resuls = await _userManager.AddToRoleAsync(user, model.UserRole);

          if (!result.Succeeded ) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

          //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
          await _appDbContext.SaveChangesAsync();

          return new OkObjectResult("Account: " + user.UserName + ", created");
        }

*//*&& !role_resuls.Succeeded*/

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }

/*
        [HttpPost]
        [Route("addrole1")]
        public async Task<IActionResult> AddRole1([FromBody]ApplicationRoleModel model)
        {
            ApplicationRole role = new ApplicationRole();
            role.Name = model.Name;
            role.Description = model.Description;

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded ) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Application Role: " + role.Name + ", Added");
        }
*/
        [HttpPost]
        [Route("addrole")]
        public async Task<IActionResult> AddRole([FromBody]AddUserRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPost]
        [Route("resetpass")]
        public async Task<IActionResult> ResetPassword(string email) // This endpoint may not be used in production, instead sending email to admin for resetting password
        {
            var user = await _userManager.FindByEmailAsync(email);

            var restToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = Url.Action("ResetPassword",
                    "Account", new { token = restToken },
                     protocol: HttpContext.Request.Scheme);

            // Send email - Send message to message queue(notificaiton) - integration event

            var emailBody = "";

            EmailNotificationEvent e = new EmailNotificationEvent(new Guid(), email, "Password Reset", emailBody);

            try
            {
                await _messagePublisher.PublishMessageAsync(e.MessageType, e, "notification");
                Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
            }


            return Ok(resetLink);
        }

        //[HttpPost]
        //[Route("resetpass")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}


        //[HttpPost]
        //[Route("changepss")]
        //public async Task<IActionResult> ChangePassword(string newpass, string username)
        //{
        //    var user = await _userManager.FindByNameAsync(username);

        //    var newPassword = _userManager.PasswordHasher.HashPassword(user, newpass);

        //    user.PasswordHash = newPassword;

        //    var result = await _userManager.UpdateAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return Ok("Password changed successfully!");
        //    }

        //    //return StatusCode(500);  //OkObjectResult("Error changing passowrd, please try again!");
        //    return Ok("Password change failed");


        //    //return Ok(resetLink);
        //}

        [HttpPost]
        [Route("changepss")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);


            //return Ok(resetLink);
        }



        [HttpGet]
        [Route("user/{username}")]
        public async Task<IActionResult> GetUserInfo(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return  Ok(user);
        }
    }
}
