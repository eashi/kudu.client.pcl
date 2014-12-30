using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kudu.Contracts.PCL.Jobs
{
    public class TriggeredJobHistory
    {
        [JsonProperty(PropertyName = "runs")]
        public IEnumerable<TriggeredJobRun> TriggeredJobRuns { get; set; }
    }
}