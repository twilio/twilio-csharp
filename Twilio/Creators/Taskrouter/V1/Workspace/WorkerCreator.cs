using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Worker;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class WorkerCreator : Creator<Worker> {
        private String workspaceSid;
        private String friendlyName;
        private String activitySid;
        private String attributes;
    
        /**
         * Construct a new WorkerCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         */
        public WorkerCreator(String workspaceSid, String friendlyName) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
        }
    
        /**
         * The activity_sid
         * 
         * @param activitySid The activity_sid
         * @return this
         */
        public WorkerCreator setActivitySid(String activitySid) {
            this.activitySid = activitySid;
            return this;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public WorkerCreator setAttributes(String attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Worker
         */
        [Override]
        public Worker execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Worker creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (activitySid != null) {
                request.addPostParam("ActivitySid", activitySid);
            }
            
            if (attributes != null) {
                request.addPostParam("Attributes", attributes);
            }
        }
    }
}