using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using REALWorks.AuthServer.Models;
using Microsoft.Extensions.Configuration;
using REALWorks.AuthServer.Models.ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using REALWorks.AuthServer.Helpers;
using MediatR;
using REALWorks.AuthServer.Commands;
using Microsoft.Extensions.Logging;

namespace REALWorks.AuthServer.Controllers
{
  [Produces("application/json")]
  [Route("api/Auth")]
  public class AuthController : Controller
  {
        private readonly IMediator _mediator; // Only this one is required

        // The DI below will NOT be required as MediatR is implemented, will be retired
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, 
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        ILogger<AuthController> logger)
        {
            _mediator = mediator;// Only this one is required

            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
        }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Authenticate([FromBody] LoginViewModel model) // This endpoint will be retired, instead using the MediatR pattern
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

            // check if there's an user with the given username
            var user = await _userManager.FindByNameAsync(model.UserName);
            // fallback to support e-mail address instead of username
            if (user == null && model.UserName.Contains("@"))
                user = await _userManager.FindByEmailAsync(model.UserName);

            // var user = await _userManager.FindByNameAsync(model.UserName);

            var userToVerify = await _userManager.CheckPasswordAsync(user, model.Password);

          //if (user == null)
          //{
          //  return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
          //}

          if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
           {
                _logger.LogInformation("User: " + model.UserName + " failed to login.");
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
           }

            //Check if the user account is disabled
            //
            if (user.IsDisabled == true)
            {
                _logger.LogInformation("Disabled user: " + model.UserName + " tried to login.");
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            // Add update user logon date
            //

            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
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

            //var jwtToken = new JwtSecurityToken(encodedToken);

            /*
            var jwtToken = new JwtSecurityToken(encodedToken);

            
            var response = new TokenResponseViewModel()
            {
                token = encodedToken,
                //expiration = tokenExpirationMins,

                //role = jwtToken.Claims.First().Value
                role = jwtToken.Claims.FirstOrDefault(r => r.Type == "given_name").Value,
                //};
                avatarImgUrl = jwtToken.Claims.FirstOrDefault(i => i.Type == "family_name").Value,
                username = jwtToken.Claims.FirstOrDefault(i => i.Type == "gender").Value,
                email = jwtToken.Claims.FirstOrDefault(i => i.Type == "email").Value
            };
            */

            _logger.LogInformation("User: " + model.UserName + " successfully logged in.");

            return Json(encodedToken);
            //return Json(response);

            //return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

        }


        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
  }
}
