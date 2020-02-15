using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Validators
{
    public interface IValidator
    {
        Task<IEnumerable<ValidatorErrorResult>> ValidateAsync(IDictionary<string, object> arg);
    }
}