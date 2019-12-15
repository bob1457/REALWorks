using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using REALWorks.AuthServer.Commands;
using REALWorks.AuthServer.Helpers;
using REALWorks.AuthServer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginCommandHandler> _logger;

        //constructor
        public LoginCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ILogger<LoginCommandHandler> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            // check if there's an user with the given username
            ApplicationUser user = await _userManager.FindByNameAsync(request.UserName);
            // fallback to support e-mail address instead of username
            if (user == null && request.UserName.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(request.UserName);
            }

            // var user = await _userManager.FindByNameAsync(model.UserName);

            var userToVerify = await _userManager.CheckPasswordAsync(user, request.Password);

            if (await _userManager.CheckPasswordAsync(user, request.Password) == false)
            {
                //return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
                //throw new HttpException(401, "Unauthorized access");
                _logger.LogInformation("User " + request.UserName + " failed to login.");
                //return new LoginCommandResult() { token = null, user = null, errorMessage = "Login failed!" };
                //return new LoginCommandResult();
                return null;
            }

            //Check if the user account is disabled
            //
            if(user.IsDisabled == true)
            {
                _logger.LogInformation("Disabled user " + request.UserName + " tried to login.");
                return new LoginCommandResult();
            }




            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, request.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        /*
                        //new Claim(JwtRegisteredClaimNames.GivenName, UserRole), // Add user role to claim
                        new Claim(JwtRegisteredClaimNames.FamilyName, user.AvatarImgUrl),
                        new Claim(JwtRegisteredClaimNames.Gender, user.UserName),
                        //new Claim(ClaimTypes.Role, UserRole), // Add user role to claim
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)*/
                    };

            var token = new JwtSecurityToken
                          (
                              issuer: _configuration["Token:Issuer"],
                              audience: _configuration["Token:Audience"],
                              claims: claims,
                              expires: DateTime.UtcNow.AddDays(60),
                              notBefore: DateTime.UtcNow,
                              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                      SecurityAlgorithms.HmacSha256)
                          );




            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            _logger.LogInformation("User " + request.UserName + " logged in.");

            // Update last logged in date
            var loggedinUser = await _userManager.FindByNameAsync(request.UserName);
            loggedinUser.LastLogOn = DateTime.Now;
            await _userManager.UpdateAsync(loggedinUser);

            return new LoginCommandResult() { token = encodedToken, user = user };

        }
    }
}
