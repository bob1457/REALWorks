using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class OwnerProperty
    {
        private OwnerProperty() { }

        public OwnerProperty(int propertyId, int propertyOwnerId)
        {
            PropertyId = propertyId;
            PropertyOwnerId = propertyOwnerId;
        }

        public OwnerProperty(Property property, PropertyOwner propertyOwner)
        {            
            Property = property;
            PropertyOwner = propertyOwner;
        }

        public OwnerProperty(int propertyId, PropertyOwner propertyOwner)
        {
            PropertyId = propertyId;
            PropertyOwner = propertyOwner;
        }

        public OwnerProperty(Property property, int propertyOwnerId)
        {
            PropertyOwnerId = propertyOwnerId;
            Property = property;
        }

        public int PropertyId { get; private set; }
        public int PropertyOwnerId { get; private set; }

        public Property Property { get; private set; }
        public PropertyOwner PropertyOwner { get; private set; }

        public void RemovegOwnerFromProperty(int propertyId, int ownerId)
        {

        }
    }
}
