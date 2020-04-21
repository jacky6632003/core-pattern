using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Error
{
    public class ErrorFactory
    {
        /// <summary>
        /// Class ExceptionHelper
        /// </summary>
        /// <summary>
        /// The exception category
        /// </summary>
        private static readonly Dictionary<string, IError> ExceptionCategory;

        /// <summary>
        /// </summary>
        static ErrorFactory()
        {
            ExceptionCategory = new Dictionary<string, IError>
            {
            };
        }

        /// <summary>
        /// Gets the type of the exception.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>ICustomExceptionHandler</returns>
        public static IError GetExceptionType(ExceptionContext context)
        {
            var exceptionType = ExceptionCategory.Where(
                x => x.Key == context.Exception.GetType()?.Name ||
                     x.Key == context.Exception.InnerException?.GetType()?.Name)
                .Select(x => x.Value)
                .FirstOrDefault();

            return exceptionType;
        }
    }
}