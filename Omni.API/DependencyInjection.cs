using Omni.Application;
using Omni.Infrastructure;
using Omni.Persistence;

namespace Omni.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI();
            services.AddInfrastructureDI();
            services.AddPersistenceDI(configuration);
            return services;    
        }
    }
}
