﻿using MediatR;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateTenantCommand: IRequest<UpdateTenantViewModel>
    {
        public int LeaseId { get; set; }
        public int Id { get; set; }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public string ContactOthers { get; set; }        
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
       
    }
}
