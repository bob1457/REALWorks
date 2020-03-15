using MediatR;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class OwnerDetailsQuery : IRequest<PropertyOwner>
    {
        public int Id { get; set; }
    }
}
