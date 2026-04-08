using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
