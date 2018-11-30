using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class Community
    {
        public int CommunityId { get; set; }
        public string CommunityName { get; set; }
        public string Description { get; set; }
        public int PropertyAddressId { get; set; }

        public PropertyAddress PropertyAddress { get; set; }
    }
}
