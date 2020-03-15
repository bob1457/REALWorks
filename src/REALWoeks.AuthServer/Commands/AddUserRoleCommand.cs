using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Commands
{
    public class AddUserRoleCommand: IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
