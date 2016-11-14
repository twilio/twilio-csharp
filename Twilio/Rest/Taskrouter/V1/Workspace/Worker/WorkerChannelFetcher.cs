using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class WorkerChannelFetcher : Fetcher<WorkerChannelResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new WorkerChannelFetcher
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public WorkerChannelFetcher(string workspaceSid, string workerSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            WorkerSid = workerSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched WorkerChannelResource </returns> 
        public override async Task<WorkerChannelResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.WorkspaceSid + "/Workers/" + this.WorkerSid + "/Channels/" + this.Sid + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkerChannelResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkerChannelResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched WorkerChannelResource </returns> 
        public override WorkerChannelResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.WorkspaceSid + "/Workers/" + this.WorkerSid + "/Channels/" + this.Sid + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkerChannelResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkerChannelResource.FromJson(response.Content);
        }
    }
}