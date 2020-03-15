using MediatR;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.ManagementContract;

namespace REALWorks.AssetServer.Commands
{
    public class AddManagementContractCommand: IRequest<ManagementContractDetailsViewModel>
    {
        public string ManagementContractTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlacementFeeScale { get; set; }
        public string ManagementFeeScale { get; set; }
        public DateTime ContractSignDate { get; set; }
        public int PropertyId { get; set; }
        public string ManagementContractDocUrl { get; set; }
        public ContractType ManagementContractType { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}
