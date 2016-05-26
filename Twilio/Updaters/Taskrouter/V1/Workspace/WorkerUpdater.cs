using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;
using Twilio.Updaters;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class WorkerUpdater : Updater<WorkerResource> {
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated WorkerResource
         */
        public override async Task<WorkerResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkerResource update failed: Unable to connect to server");
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
            
            return WorkerResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated WorkerResource
         */
        public override WorkerResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkerResource update failed: Unable to connect to server");
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
            
            return WorkerResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (activitySid != "") {
                request.AddPostParam("ActivitySid", activitySid);
            }
            
            if (attributes != "") {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}