using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class ActivityCreator : Creator<ActivityResource> {
        private string workspaceSid;
        private string friendlyName;
        private bool available;
    
        /**
         * Construct a new ActivityCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param available The available
         */
        public ActivityCreator(string workspaceSid, string friendlyName, bool available) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
            this.available = available;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created ActivityResource
         */
        public override ActivityResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ActivityResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return ActivityResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (available != null) {
                request.addPostParam("Available", available.ToString());
            }
        }
    }
}