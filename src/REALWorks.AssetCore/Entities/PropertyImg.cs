using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class PropertyImg: Entity
    {
        private PropertyImg() { }     

        public PropertyImg(string propertyImgTitle, string propertyImgUrl, int propertyId)
        {
            PropertyImgTitle = propertyImgTitle;
            PropertyImgUrl = propertyImgUrl;
            PropertyId = propertyId;
        }

        public string PropertyImgTitle { get; private set; }
        public string PropertyImgUrl { get; private set; }
        public int PropertyId { get; private set; }        

        public Property Property { get; private set; }
    }
}
