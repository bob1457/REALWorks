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
        public string UserRole { get; set; }
        public int CustomId { get; set; }
        public string AvatarImgUrl { get; set; }       
        public string Telepone1 { get; set; }
        public string Telepone2 { get; set; }
        public string SocialMediaContact1 { get; set; }
        public string SocialMediaContact2 { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogOn { get; set; }
    }
}
