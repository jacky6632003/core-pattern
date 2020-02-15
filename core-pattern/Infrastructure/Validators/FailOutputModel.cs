using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Validators
{
    public class FailOutputModel
    {
        public string ApiVersion { get; set; }
        public IEnumerable<ValidatorErrorResult> Error { get; set; }
        public Guid Id { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
    }
}