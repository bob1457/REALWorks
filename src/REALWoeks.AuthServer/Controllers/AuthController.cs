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

namespace REALWorks.AuthServer.Controllers
{
  [Produces("application/json")]
  [Route("api/Auth")]
  public class AuthController : Controller
  {

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          IConfiguration configuration)
    {

      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Authenticate([FromBody] LoginViewModel model)
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
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

      // Add update user logon date
      //

      var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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

      return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

    }
  }
}
