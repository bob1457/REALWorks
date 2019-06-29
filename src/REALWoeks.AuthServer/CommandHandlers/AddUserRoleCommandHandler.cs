using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.CommandHandlers
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, string>
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private readonly ILogger<AddUserRoleCommandHandler> _logger;

        public AddUserRoleCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/  
            ApplicationDbContext appDbContext, ILogger<AddUserRoleCommandHandler> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<string> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {

            ApplicationRole role = new ApplicationRole();
            role.Name = request.Name;
            role.Description = request.Description;

            try
            {
                var result = await _roleManager.CreateAsync(role);
                //if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                await _appDbContext.SaveChangesAsync();

                _logger.LogInformation("Role:" + request.Name + " has been added");

            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured :(" + ex.Message);
                return "Error occured: " + ex.Message;
            }

            return "Application Role: " + role.Name + ", Added";


            //throw new NotImplementedException();
        }
    }
}
