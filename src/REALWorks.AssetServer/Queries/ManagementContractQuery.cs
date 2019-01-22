using MediatR;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class ManagementContractQuery: IRequest<ManagementContract>
    {
        public int Id { get; set; }
    }
}
