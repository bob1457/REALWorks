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

namespace REALWorks.AuthServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        //private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,*/  ApplicationDbContext appDbContext)
        {
          _userManager = userManager;
          _roleManager = roleManager;
          //_mapper = mapper;
          _appDbContext = appDbContext;
        }

        // account registration
        [HttpPost]
        [Route("register")]
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

          if (!result.Succeeded /*&& !role_resuls.Succeeded*/) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

          //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
          await _appDbContext.SaveChangesAsync();

          return new OkObjectResult("Account: " + user.UserName + ", created");
        }

        [Route("addrole")]
        public async Task<IActionResult> AddRole([FromBody]ApplicationRoleModel model)
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

        [HttpGet]
        [Route("user/{username}")]
        public async Task<IActionResult> GetUserInfo(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return  Ok(user);
        }
    }
}
