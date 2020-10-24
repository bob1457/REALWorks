﻿using MediatR;
using Microsoft.AspNetCore.Http;
using REALWorks.AuthServer.Models;
using REALWorks.AuthServer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Commands
{
    public class UpdateUserProfileCommand: IRequest<ApplicationUser>
    {
        //public IFormFile AvatarImage { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public int CustomId { get; set; }
        //public string AvatarImgUrl { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string SocialMediaContact1 { get; set; }
        public string SocialMediaContact2 { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvState { get; set; }
        public string AddressPostZipCode { get; set; }
        public string AddressCountry { get; set; }
    }
}
