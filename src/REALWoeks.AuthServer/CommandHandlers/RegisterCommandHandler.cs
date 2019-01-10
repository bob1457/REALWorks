using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Helpers;
using REALWorks.AuthServer.Models;
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


        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/  ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
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
                CustomId = 0
            };

            try
            {
                // Create the account
                var result = await _userManager.CreateAsync(user, request.Password);

                // Add role to the new user
                var role_resuls = await _userManager.AddToRoleAsync(user, request.UserRole);

                //if (!result.Succeeded /*&& !role_resuls.Succeeded*/) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                await _appDbContext.SaveChangesAsync();
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
