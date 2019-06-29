﻿using MediatR;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Queries
{
    public class ApplicationiListQuery: IRequest<IQueryable<ApplicationListViewModel>>
    {
        public int Id { get; set; }
    }
}
