using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kudu.Client.PCL.Infrastructure;
using Kudu.Contracts.PCL.Diagnostics;

namespace Kudu.Client.PCL.Diagnostics
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
