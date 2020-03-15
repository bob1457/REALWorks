using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Commands
{
    public class LoginCommand: IRequest<LoginCommandResult>
    {
        //[Required]
        //public string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
