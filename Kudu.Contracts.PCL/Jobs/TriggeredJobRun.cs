﻿using System;
using Newtonsoft.Json;

namespace Kudu.Contracts.PCL.Jobs
{
    public class TriggeredJobRun
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public string Duration
        {
            get
            {
                if (StartTime == default(DateTime))
                {
                    return null;
                }

                DateTime endTime = EndTime == default(DateTime) ? DateTime.UtcNow : EndTime;

                return (endTime - StartTime).ToString();
            }
        }

        [JsonProperty(PropertyName = "output_url")]
        public Uri OutputUrl { get; set; }

        [JsonProperty(PropertyName = "error_url")]
        public Uri ErrorUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }

        [JsonProperty(PropertyName = "job_name")]
        public string JobName { get; set; }

        public override int GetHashCode()
        {
            return HashHelpers.CalculateCompositeHash(Id, Status, Duration);
        }
    }
}
