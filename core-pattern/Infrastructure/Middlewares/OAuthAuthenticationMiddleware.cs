using core_pattern.Common.LoginUser;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Middlewares
{
    public class OAuthAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public OAuthAuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(
            HttpContext context,
            LoginUser user
           )
        {
            if (context.Request.Path.StartsWithSegments("/swagger") ||
               context.Request.Path.StartsWithSegments("/health") ||
               context.Request.Path.StartsWithSegments("/ping") ||
               context.Request.Path.StartsWithSegments("/api/metrics"))
            {
                await this._next(context);

                return;
            }

            if (user.IsLogin = context.User?.Identity.IsAuthenticated == true)
            {
                //取得員編
                var employeeId = context.User.Identity.Name;

                user.EmployeeId = employeeId;

                // 取得 Session ID
                var sessionId = context.User?.FindFirst(c => c.Type == "session_id")?.Value;

                if (!string.IsNullOrWhiteSpace(sessionId))
                {
                }

                if (!string.IsNullOrEmpty(context.Request.ContentType) &&
                    context.Request.ContentType.Contains("multipart/form-data"))
                {
                    await this._next(context);
                }
                else
                {
                    await this._next(context);
                }
            }
            else
            {
                context.Response.StatusCode = 403;
                return;
            }
        }
    }
}