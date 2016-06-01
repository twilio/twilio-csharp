using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Updaters.Taskrouter.V1 {

    public class WorkspaceUpdater : Updater<WorkspaceResource> {
        private string sid;
        private string defaultActivitySid;
        private string eventCallbackUrl;
        private string friendlyName;
        private string timeoutActivitySid;
    
        /**
         * Construct a new WorkspaceUpdater
         * 
         * @param sid The sid
         */
        public WorkspaceUpdater(string sid) {
            this.sid = sid;
        }
    
        /**
         * The default_activity_sid
         * 
         * @param defaultActivitySid The default_activity_sid
         * @return this
         */
        public WorkspaceUpdater setDefaultActivitySid(string defaultActivitySid) {
            this.defaultActivitySid = defaultActivitySid;
            return this;
        }
    
        /**
         * The event_callback_url
         * 
         * @param eventCallbackUrl The event_callback_url
         * @return this
         */
        public WorkspaceUpdater setEventCallbackUrl(string eventCallbackUrl) {
            this.eventCallbackUrl = eventCallbackUrl;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkspaceUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The timeout_activity_sid
         * 
         * @param timeoutActivitySid The timeout_activity_sid
         * @return this
         */
        public WorkspaceUpdater setTimeoutActivitySid(string timeoutActivitySid) {
            this.timeoutActivitySid = timeoutActivitySid;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated WorkspaceResource
         */
        public override async Task<WorkspaceResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return WorkspaceResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated WorkspaceResource
         */
        public override WorkspaceResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return WorkspaceResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (defaultActivitySid != "") {
                request.AddPostParam("DefaultActivitySid", defaultActivitySid);
            }
            
            if (eventCallbackUrl != "") {
                request.AddPostParam("EventCallbackUrl", eventCallbackUrl);
            }
            
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (timeoutActivitySid != "") {
                request.AddPostParam("TimeoutActivitySid", timeoutActivitySid);
            }
        }
    }
}