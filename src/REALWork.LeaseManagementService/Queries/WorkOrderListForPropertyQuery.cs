﻿using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class WorkOrderListForPropertyQuery : IRequest<IQueryable<WorkOrder>>
    {
        public int PropertyId { get; set; }
    }
}
