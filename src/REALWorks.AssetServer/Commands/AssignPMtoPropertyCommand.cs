using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class AssignPMtoPropertyCommand: IRequest<string>
    {
        public int PropertyId { get; set; }
        public string PmUserName { get; set; }
    }
}
