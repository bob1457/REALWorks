using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class DeletePropertyCommand: IRequest<bool>
    {
        public int PropertyId { get; set; }
        public bool IsActive { get; set; }
    }
}
