using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omni.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
