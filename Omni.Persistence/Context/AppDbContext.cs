using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Persistence.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
    {
        public DbSet<Domain.Entities.Company> Companies { get; set; }
        public DbSet<Domain.Entities.Agent> Agents { get; set; }
        public DbSet<Domain.Entities.IvrMenu> IvrMenus { get; set; }
        public DbSet<Domain.Entities.CallLog> CallLogs { get; set; }
        public DbSet<Domain.Entities.CallAction> CallActions { get; set; }

    }
}
