using MediatR;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class AllOwnerListQuery2 : IRequest<IQueryable<AllOwnerListViewMode>>
    {
        public int Id { get; set; }
    }
}
