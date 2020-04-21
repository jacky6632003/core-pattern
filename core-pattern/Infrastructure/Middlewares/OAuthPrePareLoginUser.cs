using core_pattern.Common.LoginUser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Middlewares
{
    public static class OAuthPrePareLoginUser
    {
        /// <summary>
        /// OAuth取得登入者資訊
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddOAuthPrePareLoginUser(this IServiceCollection services)
        {
            services.AddScoped<LoginUser>();
            services.AddTransient<ILoginUser>((sp) => { return sp.GetService<LoginUser>(); });

            return services;
        }
    }
}