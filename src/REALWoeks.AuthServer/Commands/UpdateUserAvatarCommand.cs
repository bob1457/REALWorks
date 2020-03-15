using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Commands
{
    public class UpdateUserAvatarCommand : IRequest<bool>
    {
        public IFormFile AvatarImage { get; set; }
        public string UserName { get; set; }
    }
}
