using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kudu.Client.PCL.Infrastructure;
using Kudu.Contracts.PCL.SourceControl;

namespace Kudu.Client.PCL.Deployment
{
    public class RemoteFetchManager : KuduRemoteClientBase
    {
        public RemoteFetchManager(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null)
            : base(serviceUrl, credentials, handler)
        {
        }

        public Task TriggerFetch(string repositoryUrl, RepositoryType repositoryType)
        {
            var parameters = new[]
            {
                new KeyValuePair<string, string>("format", "basic"),
                new KeyValuePair<string, string>("url", repositoryUrl),
                new KeyValuePair<string, string>("scm", repositoryType == RepositoryType.Mercurial ? "hg" : null)
            };
            return Client.PostAsync("", parameters);
        }
    }
}
