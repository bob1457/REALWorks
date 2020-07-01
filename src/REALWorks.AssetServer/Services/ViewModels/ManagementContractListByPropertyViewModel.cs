using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.ManagementContract;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class ManagementContractListByPropertyViewModel
    {
        public int Id { get; set; }
        public string ManagementContractTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlacementFeeScale { get; set; }
        public string ManagementFeeScale { get; set; }
        public DateTime ContractSignDate { get; set; }
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string ManagementContractDocUrl { get; set; }
        public ContractType ManagementContractType { get; set; }
        //public string OwnerFirstName { get; set; }
        //public string OnwerLastName { get; set; }
        public bool IsActive { get; set; }
        public bool solicitingOnly { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Property Property { get; set; }

    }
}
