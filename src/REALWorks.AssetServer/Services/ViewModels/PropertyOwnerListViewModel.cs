﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class PropertyOwnerListViewModel
    {
        public int PropertyOwnerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<Property> OwnedPropertyList { get; set; }

        //public string PropertyName { get; set; }
        //public string PropertyDesc { get; set; }
    }
}
