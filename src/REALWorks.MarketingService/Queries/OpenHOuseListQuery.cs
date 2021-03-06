﻿using MediatR;
using REALWorks.MarketingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Queries
{
    public class OpenHOuseListQuery: IRequest<IQueryable<OpenHouse>>
    {
        public int Id { get; set; }
    }
}
