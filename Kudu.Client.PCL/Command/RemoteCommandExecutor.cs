using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kudu.Client.PCL.Infrastructure;
using Kudu.Contracts.PCL.Commands;
using Newtonsoft.Json.Linq;

namespace Kudu.Client.PCL.Command
{
    public class RemoteCommandExecutor : KuduRemoteClientBase
    {
        public RemoteCommandExecutor(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null)
            : base(serviceUrl, credentials, handler)
        {
        }

        public Task<CommandResult> ExecuteCommand(string command, string workingDirectory)
        {
            JObject payload = new JObject(new JProperty("command", command), new JProperty("dir", workingDirectory));
            return Client.PostJsonAsync<JObject, CommandResult>(String.Empty, payload);
        }
    }
}
