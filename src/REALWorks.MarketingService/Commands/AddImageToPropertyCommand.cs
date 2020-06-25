using MediatR;
using Microsoft.AspNetCore.Http;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class AddImageToPropertyCommand: IRequest<AddImageToPropertyViewModel>
    {
        public IFormFile PropertyImage { get; set; }

        public int PropertyImgId { get; set; }
        public string PropertyImgTitle { get; set; }
        public string PropertyImgUrl { get; set; }
        public int RentalPropertyId { get; set; }
        
    }
}
