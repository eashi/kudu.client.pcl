using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kudu.Client.Infrastructure;
using Kudu.Contracts.PCL.Jobs;

namespace Kudu.Client.PCL.Jobs
{
    public class RemoteJobsManager : KuduRemoteClientBase
    {
        public RemoteJobsManager(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null)
            : base(serviceUrl, credentials, handler)
        {
        }

        public Task<IEnumerable<JobBase>> ListAllJobs()
        {
            return Client.GetJsonAsync<IEnumerable<JobBase>>("api/webjobs");
        }

        public Task<IEnumerable<ContinuousJob>> ListContinuousJobsAsync()
        {
            return Client.GetJsonAsync<IEnumerable<ContinuousJob>>("api/continuouswebjobs");
        }

        public Task<IEnumerable<TriggeredJob>> ListTriggeredJobsAsync()
        {
            return Client.GetJsonAsync<IEnumerable<TriggeredJob>>("api/triggeredwebjobs");
        }

        public Task<ContinuousJob> GetContinuousJobAsync(string jobName)
        {
            return Client.GetJsonAsync<ContinuousJob>("api/continuouswebjobs/" + jobName);
        }

        public Task<TriggeredJob> GetTriggeredJobAsync(string jobName)
        {
            return Client.GetJsonAsync<TriggeredJob>("api/triggeredwebjobs/" + jobName);
        }

        public Task<TriggeredJobHistory> GetTriggeredJobHistoryAsync(string jobName)
        {
            return Client.GetJsonAsync<TriggeredJobHistory>("api/triggeredwebjobs/" + jobName + "/history");
        }

        public Task<TriggeredJobRun> GetTriggeredJobRunAsync(string jobName, string runId)
        {
            return Client.GetJsonAsync<TriggeredJobRun>("api/triggeredwebjobs/" + jobName + "/history/" + runId);
        }

        public async Task EnableContinuousJobAsync(string jobName)
        {
            await Client.PostAsync("api/continuouswebjobs/" + jobName + "/start");
        }

        public async Task DisableContinuousJobAsync(string jobName)
        {
            await Client.PostAsync("api/continuouswebjobs/" + jobName + "/stop");
        }

        public async Task<JobSettings> GetContinuousJobSettingsAsync(string jobName)
        {
            return await Client.GetJsonAsync<JobSettings>("api/continuouswebjobs/" + jobName + "/settings");
        }

        public async Task SetContinuousJobSettingsAsync(string jobName, JobSettings jobSettings)
        {
            await Client.PutJsonAsync<JobSettings, object>("api/continuouswebjobs/" + jobName + "/settings", jobSettings);
        }

        public async Task InvokeTriggeredJobAsync(string jobName, string arguments = null)
        {
            if (arguments != null)
            {
                await Client.PostAsync("api/triggeredwebjobs/" + jobName + "/run?arguments=" + arguments);
            }
            else
            {
                await Client.PostAsync("api/triggeredwebjobs/" + jobName + "/run");
            }
        }

        //public async Task CreateContinuousJobAsync(string jobName, string scriptFileName, string content = null)
        //{
        //    await UploadJobScriptFile("continuouswebjobs/" + jobName, scriptFileName, content);
        //}

        //public async Task CreateTriggeredJobAsync(string jobName, string scriptFileName, string content = null)
        //{
        //    await UploadJobScriptFile("triggeredwebjobs/" + jobName, scriptFileName, content);
        //}

        public async Task DeleteContinuousJobAsync(string jobName)
        {
            await Client.DeleteSafeAsync("api/continuouswebjobs/" + jobName);
        }

        public async Task DeleteTriggeredJobAsync(string jobName)
        {
            await Client.DeleteSafeAsync("api/triggeredwebjobs/" + jobName);
        }

        public async Task<JobSettings> GetTriggeredJobSettingsAsync(string jobName)
        {
            return await Client.GetJsonAsync<JobSettings>("api/triggeredwebjobs/" + jobName + "/settings");
        }

        public async Task SetTriggeredJobSettingsAsync(string jobName, JobSettings jobSettings)
        {
            await Client.PutJsonAsync<JobSettings, object>("api/triggeredwebjobs/" + jobName + "/settings", jobSettings);
        }

        //private async Task UploadJobScriptFile(string urlPath, string filePath, string content = null)
        //{
        //    Stream stream;
        //    if (content != null)
        //    {
        //        stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
        //    }
        //    else
        //    {
        //        stream = File.OpenRead(filePath);
        //    }

        //    using (stream)
        //    {
        //        await UploadJobScriptFile(urlPath, filePath, stream);
        //    }
        //}

        //private async Task UploadJobScriptFile(string urlPath, string filePath, Stream stream)
        //{
        //    using (var request = new HttpRequestMessage())
        //    {
        //        request.Method = HttpMethod.Put;
        //        request.RequestUri = new Uri(urlPath, UriKind.Relative);
        //        var content = new StreamContent(stream);
        //        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
        //        {
        //            FileName = Path.GetFileName(filePath)
        //        };

        //        if (String.Equals(Path.GetExtension(filePath), ".zip", StringComparison.OrdinalIgnoreCase))
        //        {
        //            content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
        //        }

        //        request.Content = content;

        //        var response = await Client.SendAsync(request);
        //        response.EnsureSuccessful();
        //    }
        //}
    }
}