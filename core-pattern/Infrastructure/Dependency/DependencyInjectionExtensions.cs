using core_pattern.Repository.Implement;
using core_pattern.Repository.Interface;
using core_pattern.Service.Implement;
using core_pattern.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Dependency
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adds the dendency injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddDendencyInjection(this IServiceCollection services)
        {
            // Repository

            services.AddScoped<ITestRepository, TestRepository>();

            // Service
            services.AddScoped<ITestService, TestService>();

            return services;
        }
    }
}