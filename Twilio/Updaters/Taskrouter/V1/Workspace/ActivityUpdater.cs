using System.Threading.Tasks;
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
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ActivityResource
         */
        public override async Task<ActivityResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ActivityResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.FromJson(response.GetContent());
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
            
            return ActivityResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}