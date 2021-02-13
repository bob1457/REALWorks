using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class UploadSignedContractCommand : IRequest<bool>
    {
        public IFormFile ContractFile { get; set; }

        public int ContractId { get; set; }
        //public string Caption { get; set; }
        //public string ContractFileUrl { get; set; }
        //public int PropertyId { get; set; }
    }
}
