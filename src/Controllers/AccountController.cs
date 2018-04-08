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

namespace REALWorks.AuthServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
    private readonly ApplicationDbContext _appDbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    //private readonly RoleManager<AppRole> _roleManager;
    //private readonly IMapper _mapper;

    public AccountController(UserManager<ApplicationUser> userManager, /*RoleManager<AppRole> roleManager,IMapper mapper,*/  ApplicationDbContext appDbContext)
    {
      _userManager = userManager;
      //_roleManager = roleManager;
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
        AvatarImgUrl = "~/Contents/Images/Avatars/default.png",
        JoinDate = DateTime.Now,
        EmailConfirmed = true
      };

      // Create the account
      var result = await _userManager.CreateAsync(user, model.Password);

      if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

      //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
      await _appDbContext.SaveChangesAsync();

      return new OkObjectResult("Account created");
    }
  }
}
