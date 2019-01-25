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
            // Get the attached file
            var file = request.AvatarImage;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Avatars\\");

            string url = "";

            // Check if a file is attached, if yes, uplaod it
            if (file != null)
            {                

                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
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


                int location = file.FileName.IndexOf(".");

                var fileNameOnly = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = file.FileName.Substring(location + 1);  //Path.GetExtension(file.Name);

                //var newFileName = fileNameOnly + "-" + request.UserName + "." + fileExtension;
                var newFileName = "avatar-" + request.UserName + "." + fileExtension;

                if (File.Exists(path + newFileName))
                {
                    File.Delete(path + newFileName);
                }

                File.Move(path + file.FileName, path + newFileName);

                url = "images/Avatars/" + newFileName; //file.FileName;

            }

            //Rename the file

            //int location = file.FileName.IndexOf(".");

            //var fileNameOnly = Path.GetFileNameWithoutExtension(file.FileName);
            //var fileExtension = file.FileName.Substring(location + 1);  //Path.GetExtension(file.Name);

            //var newFileName = fileNameOnly + "-" + request.UserName + "." + fileExtension;

            //File.Move( path + file.FileName, path + newFileName);

            //string url = "images/Avatars/" + newFileName; //file.FileName;

            var user = await _userManager.FindByNameAsync(request.UserName);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Telephone1 = request.Telephone1;
            user.Telephone2 = request.Telephone2;
            user.SocialMediaContact1 = request.SocialMediaContact1;
            user.SocialMediaContact2 = request.SocialMediaContact2;
            user.Email = request.Email;
            if(url == "")
            {
                user.AvatarImgUrl = request.AvatarImgUrl;
            }
            else
            {
                user.AvatarImgUrl = url;
            }
            

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
