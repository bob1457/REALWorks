using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Commands
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public string NewPassword { get; set; }
        public string UserName { get; set; }
    }
}
