using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class GetUserOnlineStatusCommand : IRequest<bool> /*GetUserOnlineStatusCommandResult*/
    {
        public string Email { get; set; }
    }
}
