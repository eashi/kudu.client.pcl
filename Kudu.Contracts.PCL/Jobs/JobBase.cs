﻿using System;
using Newtonsoft.Json;

namespace Kudu.Contracts.PCL.Jobs
{
    public abstract class JobBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "run_command")]
        public string RunCommand { get; set; }

        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }

        [JsonProperty(PropertyName = "extra_info_url")]
        public Uri ExtraInfoUrl { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string JobType { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "using_sdk")]
        public bool UsingSdk { get; set; }

        [JsonIgnore]
        public IScriptHost ScriptHost { get; set; }

        [JsonIgnore]
        public string ScriptFilePath { get; set; }

        [JsonIgnore]
        public string JobBinariesRootPath { get; set; }

        [JsonIgnore]
        public string CommandArguments { get; set; }

        public override int GetHashCode()
        {
            return HashHelpers.CalculateCompositeHash(Name, RunCommand, JobType, Error);
        }
    }
}
