using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Worker;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class WorkerUpdater : Updater<Worker> {
        private string workspaceSid;
        private string sid;
        private string activitySid;
        private string attributes;
        private string friendlyName;
    
        /**
         * Construct a new WorkerUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public WorkerUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * The activity_sid
         * 
         * @param activitySid The activity_sid
         * @return this
         */
        public WorkerUpdater setActivitySid(string activitySid) {
            this.activitySid = activitySid;
            return this;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public WorkerUpdater setAttributes(string attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkerUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Worker
         */
        [Override]
        public Worker execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Worker update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Worker.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (activitySid != null) {
                request.addPostParam("ActivitySid", activitySid);
            }
            
            if (attributes != null) {
                request.addPostParam("Attributes", attributes);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
        }
    }
}