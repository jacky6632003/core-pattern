using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_pattern.Infrastructure.Error
{
    public class FailResultViewModel
    {
        [JsonProperty(PropertyName = "id", Order = 4)]
        public string CorrelationId
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "apiVersion", Order = 0)]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "method", Order = 1)]
        public string Method
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "status", Order = 2)]
        public string Status
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "error", Order = 5)]
        public FailInformation Error
        {
            get;
            set;
        }
    }
}