using Kudu.Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kudu.Contracts.PCL.Diagnostics;

namespace Kudu.Client.Diagnostics
{
    public class RemoteLogFilesManager : KuduRemoteClientBase
    {
        public RemoteLogFilesManager(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null)
            : base(serviceUrl, credentials, handler)
        {
        }

        public Task<IList<ApplicationLogEntry>> GetRecentLogEntriesAsync(int top)
        {
            return Client.GetJsonAsync<IList<ApplicationLogEntry>>("recent?top=" + top);
        }
    }
}
