using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kudu.Client.PCL.Infrastructure;
using Kudu.Contracts.PCL.Diagnostics;

namespace Kudu.Client.PCL.Diagnostics
{
    public class RemoteRuntimeManager : KuduRemoteClientBase
    {
        public RemoteRuntimeManager(string serviceUrl, ICredentials credentials, HttpMessageHandler handler = null)
            : base(serviceUrl, credentials, handler)
        {
        }

        public Task<RuntimeInfo> GetRuntimeInfo()
        {
            return Client.GetJsonAsync<RuntimeInfo>("");
        }
    }
}
