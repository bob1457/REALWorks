using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Models.ViewModels
{
    public class TokenResponseViewModel
    {
        public string token { get; set; }
        public int expiration { get; set; }

        public string role { get; set; }

        public string username { get; set; }
        public string email { get; set; }
        public string avatarImgUrl { get; set; }
    }
}
