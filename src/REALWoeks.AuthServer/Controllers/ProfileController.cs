using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REALWorks.AuthServer.Commands;
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
        private readonly IMediator _mediator;

        public ProfileController(UserManager<ApplicationUser> userManager, /*RoleManager<AppRole> roleManager,IMapper mapper,*/  ApplicationDbContext appDbContext, IMediator mediator)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("user/{username}")]
        public async Task<IActionResult> GetUserInfo(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return Ok(user);
        }

        // More user profile management

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUserProfile([FromForm] UpdateUserProfileCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var f = Request.Form.Files;

            if (f.Count > 0)
            {
                command.AvatarImage = f[0];
            }
                        

            //if (command.AvatarImage == null || command.AvatarImage.Length == 0)
            //    return Content("file not selected");

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPost]
        [Route("disable")]
        public async Task<IActionResult> DisableUserAccount()
        {
            throw new NotImplementedException();
        }
    }
}