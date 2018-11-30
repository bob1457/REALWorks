using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class PropertyImg
    {
        public int PropertyImgId { get; set; }
        public string PropertyImgTitle { get; set; }
        public string PropertyImgCaption { get; set; }
        public int PropertyId { get; set; }
        public DateTime CreatedOn { get; set; }

        public Property Property { get; set; }
    }
}
