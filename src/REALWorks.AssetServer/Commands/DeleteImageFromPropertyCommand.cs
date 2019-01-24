using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class DeleteImageFromPropertyCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
