using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Error
{
    public interface IError
    {
        /// <summary>
        /// Exceptions the message.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>HttpResponseMessage</returns>
        FailResultViewModel GenerateExceptionMessage(ExceptionContext context);
    }
}