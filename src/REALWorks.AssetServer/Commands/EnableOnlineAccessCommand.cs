using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class EnableOnlineAccessCommand : IRequest<bool>
    {
        public int Id { get; set; } // user(owner, tenant, or vendor) Id
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public bool Enable { get; set ;}

        public string Email { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

    }
}
