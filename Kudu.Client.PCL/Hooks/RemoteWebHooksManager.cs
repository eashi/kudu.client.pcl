using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kudu.Client.PCL.Infrastructure;
using Kudu.Contracts.PCL.Hooks;

namespace Kudu.Client.PCL.Hooks
{
    public class RemoteWebHooksManager : KuduRemoteClientBase
    {
        public RemoteWebHooksManager(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null)
            : base(serviceUrl, credentials, handler)
        {
        }

        public Task<IEnumerable<WebHook>> GetWebHooksAsync()
        {
            return Client.GetJsonAsync<IEnumerable<WebHook>>("api/hooks");
        }

        public Task<WebHook> GetWebHookAsync(string hookId)
        {
            return Client.GetJsonAsync<WebHook>(BuildUrl(hookId));
        }

        public async Task<WebHook> SubscribeAsync(WebHook webHook)
        {
            return await Client.PostJsonAsync<WebHook, WebHook>(BuildUrl(), webHook);
        }

        public async Task PublishEventAsync<T>(string hookEventType, T eventContent)
        {
            await Client.PostJsonAsync<T, object>(BuildUrl("publish", hookEventType), eventContent);
        }

        public async Task UnsubscribeAsync(string hookId)
        {
            HttpResponseMessage response = await Client.DeleteAsync(hookId);
            response.EnsureSuccessful();
        }

        private string BuildUrl(params string[] parameters)
        {
            return "api/hooks/" + String.Join("/", parameters);
        }
    }
}