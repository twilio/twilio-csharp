using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;
using Twilio.Updaters;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class ActivityUpdater : Updater<ActivityResource> {
        private string workspaceSid;
        private string sid;
        private string friendlyName;
    
        /**
         * Construct a new ActivityUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         */
        public ActivityUpdater(string workspaceSid, string sid, string friendlyName) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
            this.friendlyName = friendlyName;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated ActivityResource
         */
        public override ActivityResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ActivityResource update failed: Unable to connect to server");
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
        }
    }
}