using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class PropertyImg: Entity
    {
        public PropertyImg() { } // Required by EF Core

        public PropertyImg(string propertyImgTitle, string propertyImgCaption, int propertyId)
        {
            PropertyImgTitle = propertyImgTitle;
            PropertyImgCaption = propertyImgCaption;
            PropertyId = propertyId;
        }

        public string PropertyImgTitle { get; private set; }
        public string PropertyImgCaption { get; private set; }
        public int PropertyId { get; private set; }        

        public Property Property { get; private set; }
    }
}
