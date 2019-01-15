using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class OwnerProperty
    {
        //public OwnerProperty() { }

        //public OwnerProperty(int propertyId, int propertyOwnerId, Property property, PropertyOwner propertyOwner)
        //{
        //    PropertyId = propertyId;
        //    PropertyOwnerId = propertyOwnerId;
        //    Property = property;
        //    PropertyOwner = propertyOwner;
        //}

        public int PropertyId { get; /*private*/ set; }
        public int PropertyOwnerId { get; /*private*/ set; }

        public Property Property { get; /*private*/ set; }
        public PropertyOwner PropertyOwner { get; /*private*/ set; }


    }
}
