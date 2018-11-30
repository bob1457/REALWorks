using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            Property = new HashSet<Property>();
        }

        public int PropertyTypeId { get; set; }
        public string PropertyType1 { get; set; }
        public string Description { get; set; }

        public ICollection<Property> Property { get; set; }
    }
}
