using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class RemovePropertyOwnerCommandResult
    {
        public int PropertyId { get; set; }
        public int PropertyOwnerId { get; set; }
    }
}
