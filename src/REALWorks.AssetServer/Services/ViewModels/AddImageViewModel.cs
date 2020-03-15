using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class AddImageViewModel
    {
        public IFormFile PropertyImage { get; set; }

        public int PropertyImgId { get; set; }
        public string PropertyImgTitle { get; set; }
        public string PropertyImgCaption { get; set; }
        public int PropertyId { get; set; }
        public DateTime CreatedOn { get; set; }

        //public Property Property { get; set; }
    }
}
