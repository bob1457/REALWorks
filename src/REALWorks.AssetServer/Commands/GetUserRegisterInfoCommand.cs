using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class GetUserRegisterInfoCommand : IRequest<GetUserRegisterInfoCommandResult>
    {
        public string Email { get; set; }
    }
}
