using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class OwnerProperty
    {
        public int PropertyId { get; set; }
        public int PropertyOwnerId { get; set; }

        public Property Property { get; set; }
        public PropertyOwner PropertyOwner { get; set; }
    }
}
