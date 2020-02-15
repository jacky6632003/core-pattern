using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Validators
{
    public class ValidatorAttribute : ActionFilterAttribute
    {
        private readonly Type _type;

        public ValidatorAttribute(Type type)
        {
            this._type = type;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var Validator = (IValidator)Activator.CreateInstance(this._type);

            if (context.ActionArguments.Count > 0)
            {
                var result = await Validator.ValidateAsync(context.ActionArguments);

                if (result.Count() > 0)
                {
                    var fail = new FailOutputModel()
                    {
                        ApiVersion = "1.0.0",
                        Method = string.Format("{0}.{1}", context.HttpContext.Request.Path, context.HttpContext.Request.Method),
                        Status = "ERROR",
                        Error = result,
                        Id = Guid.NewGuid(),
                    };
                    context.Result = new ObjectResult(fail)
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }
}