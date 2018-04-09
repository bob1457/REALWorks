using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Models.ViewModels
{
    public class AccountModel
    {
        public string Email { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
