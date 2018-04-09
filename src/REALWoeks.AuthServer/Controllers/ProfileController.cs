using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AuthServer.Data;
using REALWorks.AuthServer.Models;

namespace REALWorks.AuthServer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Profile")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<AppRole> _roleManager;
        //private readonly IMapper _mapper;

        public ProfileController(UserManager<ApplicationUser> userManager, /*RoleManager<AppRole> roleManager,IMapper mapper,*/  ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.FindByNameAsync("bob");

            return Ok(user);
        }
    }
}