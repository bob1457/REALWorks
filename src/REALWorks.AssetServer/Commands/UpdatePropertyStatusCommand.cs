using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.Property;

namespace REALWorks.AssetServer.Commands
{
    public class UpdatePropertyStatusCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public RentalStatus Status {get; set;}
    }
}
