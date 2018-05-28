using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALWorks.Asset.Api.Data;

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





    }
}