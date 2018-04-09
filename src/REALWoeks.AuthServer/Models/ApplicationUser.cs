using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Models
{
    public class ApplicationUser: IdentityUser
  {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime JoinDate { get; set; }
      public string AvatarImgUrl { get; set; }
    }
}
