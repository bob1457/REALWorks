using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementData
{
    public static class DBInitializer
    {
        public static void Initialize(AppLeaseManagementDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
