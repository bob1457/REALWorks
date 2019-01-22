using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static REALWorks.AssetCore.Entities.ManagementContract;

namespace REALWorks.AssetServer.Commands
{
    public class UpdateManagementContractCommand: IRequest<bool>
    {
        public int ManagementContractId { get; set; }
        public string ManagementContractTitle { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlacementFeeScale { get; set; }
        public string ManagementFeeScale { get; set; }
        public string Notes { get; set; }
        //public ContractType ManagementContractType { get; set; }
    }
}
