using MediatR;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class GetUserOnlineStatusCommandHandler : IRequestHandler<GetUserOnlineStatusCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public GetUserOnlineStatusCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(GetUserOnlineStatusCommand request, CancellationToken cancellationToken)
        {
            var user = _context.PropertyOwner.FirstOrDefault(e => e.ContactEmail == request.Email);

            if (user != null)
            {
                var status = user.OnlineAccess;

                return status;
            }
            else
            {
                return false;
            }
            

            //throw new NotImplementedException();
        }
    }
}
