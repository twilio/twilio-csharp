using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class WorkerChannelUpdater : Updater<WorkerChannelResource> {
        private string workspaceSid;
        private string workerSid;
        private string sid;
        private int? capacity;
        private bool? available;
    
        /**
         * Construct a new WorkerChannelUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param workerSid The worker_sid
         * @param sid The sid
         */
        public WorkerChannelUpdater(string workspaceSid, string workerSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.workerSid = workerSid;
            this.sid = sid;
        }
    
        /**
         * The capacity
         * 
         * @param capacity The capacity
         * @return this
         */
        public WorkerChannelUpdater setCapacity(int? capacity) {
            this.capacity = capacity;
            return this;
        }
    
        /**
         * The available
         * 
         * @param available The available
         * @return this
         */
        public WorkerChannelUpdater setAvailable(bool? available) {
            this.available = available;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated WorkerChannelResource
         */
        public override async Task<WorkerChannelResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.workerSid + "/Channels/" + this.sid + ""
            );
            addPostParams(request);
            
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
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated WorkerChannelResource
         */
        public override WorkerChannelResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.workerSid + "/Channels/" + this.sid + ""
            );
            addPostParams(request);
            
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (capacity != null) {
                request.AddPostParam("Capacity", capacity.ToString());
            }
            
            if (available != null) {
                request.AddPostParam("Available", available.ToString());
            }
        }
    }
}