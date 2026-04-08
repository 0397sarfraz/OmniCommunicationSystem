using Microsoft.EntityFrameworkCore;
using Omni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Persistence.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
