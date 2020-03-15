using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class AddImageToPropertyCommand: IRequest<bool>
    {
        public IFormFile PropertyImage { get; set; }

        public int PropertyImgId { get; set; }
        public string PropertyImgTitle { get; set; }
        public string PropertyImgUrl { get; set; }
        public int RentalPropertyId { get; set; }
        
    }
}
