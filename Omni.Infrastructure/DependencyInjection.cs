using Microsoft.Extensions.DependencyInjection;
using Omni.Domain.Interfaces;
using Omni.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped<ITwilioService, TwilioService>();
            services.AddScoped<ICallService, CallService>();
            services.AddScoped<IIvrService, IvrService>();
            return services;
        }
    }
}
