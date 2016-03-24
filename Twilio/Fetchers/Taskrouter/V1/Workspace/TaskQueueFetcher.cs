using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace {

    public class TaskQueueFetcher : Fetcher<TaskQueueResource> {
        private string workspaceSid;
        private string sid;
    
        /**
         * Construct a new TaskQueueFetcher
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public TaskQueueFetcher(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched TaskQueueResource
         */
        public override TaskQueueResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/" + this.sid + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueueResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return TaskQueueResource.fromJson(response.GetContent());
        }
    }
}