using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, string>
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public UpdateUserProfileCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/  ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
        }


        public async Task<string> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Telepone1 = request.Telepone1;
            user.Telepone2 = request.Telepone2;
            user.SocialMediaContact1 = request.SocialMediaContact1;
            user.SocialMediaContact2 = request.SocialMediaContact2;
            user.Email = request.Email;

            try
            {
                await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return "User profile has been successfully updated.";

            //throw new NotImplementedException();
        }
    }
}
