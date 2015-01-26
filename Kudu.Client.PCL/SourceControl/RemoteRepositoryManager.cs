using System;
using System.Net;
using System.Threading.Tasks;
using Kudu.Client.PCL.Infrastructure;
using Kudu.Contracts.PCL.SourceControl;

namespace Kudu.Client.PCL.SourceControl
{
    public class RemoteRepositoryManager : KuduRemoteClientBase
    {
        public RemoteRepositoryManager(string serviceUrl, ICredentials credentials = null)
            : base(UrlUtility.EnsureTrailingSlash(serviceUrl), credentials)
        {
        }

        public Task<RepositoryInfo> GetRepositoryInfo()
        {
            return Client.GetJsonAsync<RepositoryInfo>("info");
        }

        public Task Delete(bool deleteWebRoot = false, bool ignoreErrors = false)
        {
            return Client.DeleteSafeAsync(
                String.Format("?deleteWebRoot={0}&ignoreErrors={1}",
                    deleteWebRoot ? "1" : "0",
                    ignoreErrors ? "1" : "0"));
        }
    }
}
