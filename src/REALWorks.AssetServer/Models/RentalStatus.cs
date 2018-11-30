using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class RentalStatus
    {
        public RentalStatus()
        {
            Property = new HashSet<Property>();
        }

        public int RentalStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public ICollection<Property> Property { get; set; }
    }
}
