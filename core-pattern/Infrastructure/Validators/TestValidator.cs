using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Validators
{
    public class TestValidator : IValidator
    {
        public async Task<IEnumerable<ValidatorErrorResult>> ValidateAsync(IDictionary<string, object> arg)
        {
            var result = new List<ValidatorErrorResult>();

            var parameter = (string)arg["aa"];

            if (parameter == "hi")
            {
                result.Add(new ValidatorErrorResult
                {
                    ErrorMessage = "test",
                    Name = "aa"
                });
            }

            return result;
        }
    }
}