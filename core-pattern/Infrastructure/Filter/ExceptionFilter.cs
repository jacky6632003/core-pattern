using core_pattern.Infrastructure.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Filter
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ExceptionFilter(
            ILogger<ExceptionFilter> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception"/>.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext"/>.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> that on completion indicates the filter
        /// has executed.
        /// </returns>
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            this._logger?.LogError(context.Exception.ToString());
            IError error = ErrorFactory.GetExceptionType(context);

            if (error != null)
            {
                var exception = error.GenerateExceptionMessage(context);
                context.Result = new ObjectResult(exception)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };

                context.ExceptionHandled = true;

                await Task.Yield();
            }

            var result = new FailResultViewModel
            {
                CorrelationId = Guid.NewGuid().ToString(),
                Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                Status = "Error",
                Version = "1.0.0",
                Error = new FailInformation
                {
                    Domain = "localhost",
                    ErrorCode = 40000,
                    Message = context.Exception.Message,
                    Description = context.Exception.ToString()
                }
            };

            context.Result = new ObjectResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            context.ExceptionHandled = true;

            await Task.Yield();
        }
    }
}