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

            //GetUserOnlineStatusCommandResult returnedUser = new GetUserOnlineStatusCommandResult();

            //returnedUser.FirstName = user.FirstName;
            //returnedUser.LastName = user.LastName;
            //returnedUser.Email = user.ContactEmail;
            //returnedUser.Telephone1 = user.ContactTelephone1;
            //returnedUser.Telephone2 = user.ContactTelephone2;
            //returnedUser.AddressStreet = user.Address.StreetNumber;
            //returnedUser.AddressCity = user.Address.City;
            //returnedUser.AddressPostZipCode = user.Address.ZipPostCode;
            //returnedUser.AddressProvState = user.Address.StateProvince;
            //returnedUser.AddressCountry = user.Address.Country;


            //return returnedUser;

            if (user != null)
            {
                //var status = user.OnlineAccess;

                return true;
            }
            else
            {
                return false;
            }


            //throw new NotImplementedException();
        }
    }
}
