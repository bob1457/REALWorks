using MediatR;
using Microsoft.AspNetCore.Identity;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.CommandHandlers
{
    public class UpdateUserAvatarCommandHandler : IRequestHandler<UpdateUserAvatarCommand, bool>
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public UpdateUserAvatarCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/  ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(UpdateUserAvatarCommand request, CancellationToken cancellationToken)
        {
            var file = request.AvatarImage;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Avatars\\");
            string url = "images/" + file.FileName; //?

            var ext = Path.GetExtension(file.FileName);

            string newFileName = request.UserName + ext;

            if (file != null || file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }

            var user = await _userManager.FindByNameAsync(request.UserName);
            user.AvatarImgUrl = "Images/Avatars/" + newFileName;
            //user.CustomId = 1;
            user.LastUpdated = DateTime.Now;

            await _userManager.UpdateAsync(user);



            //throw new NotImplementedException();

            return true;
        }
    }
}
