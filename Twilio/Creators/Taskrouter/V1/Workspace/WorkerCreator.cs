using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class WorkerCreator : Creator<WorkerResource> {
        private string workspaceSid;
        private string friendlyName;
        private string activitySid;
        private string attributes;
    
        /**
         * Construct a new WorkerCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         */
        public WorkerCreator(string workspaceSid, string friendlyName) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
        }
    
        /**
         * The activity_sid
         * 
         * @param activitySid The activity_sid
         * @return this
         */
        public WorkerCreator setActivitySid(string activitySid) {
            this.activitySid = activitySid;
            return this;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public WorkerCreator setAttributes(string attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created WorkerResource
         */
        public override async Task<WorkerResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkerResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return WorkerResource.FromJson(response.GetContent());
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
            
            if (activitySid != null) {
                request.AddPostParam("ActivitySid", activitySid);
            }
            
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes);
            }
        }
    }
}