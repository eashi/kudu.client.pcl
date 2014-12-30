using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kudu.Contracts.PCL.Tracing
{
    public interface ITracer
    {
        TraceLevel TraceLevel { get; }
        IDisposable Step(string message, IDictionary<string, string> attributes);
        void Trace(string message, IDictionary<string, string> attributes);
    }
}
