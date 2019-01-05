using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class OwnerProperty
    {
        public int PropertyId { get; set; }
        public int PropertyOwnerId { get; set; }

        public Property Property { get; set; }
        public PropertyOwner PropertyOwner { get; set; }
    }
}
