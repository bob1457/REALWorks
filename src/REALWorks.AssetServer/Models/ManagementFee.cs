using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class ManagementFee
    {
        public int ManagementFeeId { get; set; }
        public int ManagementContractId { get; set; }
        public string ManagementFeeType { get; set; }
        public decimal ManagementFeeAmount { get; set; }
        public string Notes { get; set; }

        public ManagementContract ManagementContract { get; set; }
    }
}
