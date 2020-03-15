using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class DeletePropertyCommand: IRequest<DeletePropertyCommandResult> // return type: int
    {
        public int PropertyId { get; set; }
        public bool IsActive { get; set; }
    }
}
