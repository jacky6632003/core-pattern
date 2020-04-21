using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Error
{
    public class FailInformation
    {
        [JsonProperty(PropertyName = "domain", Order = 0)]
        public string Domain
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "code", Order = 1)]
        public int ErrorCode
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "message", Order = 2)]
        public string Message
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "description", Order = 3)]
        public string Description
        {
            get;
            set;
        }
    }
}