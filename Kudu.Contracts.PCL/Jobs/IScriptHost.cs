using System.Collections.Generic;

namespace Kudu.Contracts.PCL.Jobs
{
    public interface IScriptHost
    {
        string HostPath { get; }

        string ArgumentsFormat { get; }

        IEnumerable<string> SupportedExtensions { get; }
    }
}