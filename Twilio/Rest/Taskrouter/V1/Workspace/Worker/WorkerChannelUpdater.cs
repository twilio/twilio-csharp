using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class WorkerChannelUpdater : Updater<WorkerChannelResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public string Sid { get; }
        public int? Capacity { get; set; }
        public bool? Available { get; set; }
    
        /// <summary>
        /// Construct a new WorkerChannelUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public WorkerChannelUpdater(string workspaceSid, string workerSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            WorkerSid = workerSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkerChannelResource </returns> 
        public override async System.Threading.Tasks.Task<WorkerChannelResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Workers/" + WorkerSid + "/Channels/" + Sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkerChannelResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkerChannelResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkerChannelResource </returns> 
        public override WorkerChannelResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Workers/" + WorkerSid + "/Channels/" + Sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkerChannelResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkerChannelResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Capacity != null)
            {
                request.AddPostParam("Capacity", Capacity.ToString());
            }
            
            if (Available != null)
            {
                request.AddPostParam("Available", Available.ToString());
            }
        }
    }
}