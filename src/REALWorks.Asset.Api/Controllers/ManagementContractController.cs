using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using REALWorks.Asset.Api.Data;
using REALWorks.Asset.Api.Model;

namespace REALWorks.Asset.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ManagementContract")]
    public class ManagementContractController : Controller
    {
        private readonly IManagementContractRepository _contractRepository;

        public ManagementContractController(IManagementContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }


        [HttpPost]
        [Route("add")]
        public void AddManagementContract([FromBody] ManagementContract contract)
        {
            var mContract = new ManagementContract
            {
                PropertyId = contract.PropertyId,
                ContractTitle = contract.ContractTitle,
                ConttactDesc = contract.ConttactDesc,
                ClientName = contract.ClientName,
                ManagerName = contract.ManagerName,
                isActive = true,
                DocumentUrl = "",
                Notes = contract.Notes,

                EffectiveDate = contract.EffectiveDate,
                ExpiryDate = contract.ExpiryDate,
                SignedDate = contract.SignedDate,

                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now

            };

            try
            {
                _contractRepository.AddContractAsync(mContract);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ManagementContract> GetContractForProperty(string id) //(ObjectId id)
        {
            return await _contractRepository.GetPropertyManagementContract(id);
        }


    }
}