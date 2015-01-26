using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kudu.Contracts.PCL.Diagnostics
{
    public class RuntimeInfo
    {
        [JsonProperty(PropertyName = "nodejs")]
        public IEnumerable<Dictionary<string, string>> NodeVersions { get; set; }
    }
}
