using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1;
using Twilio.Updaters;

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
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated WorkspaceResource
         */
        public override WorkspaceResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceResource update failed: Unable to connect to server");
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
            
            return WorkspaceResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (defaultActivitySid != null) {
                request.addPostParam("DefaultActivitySid", defaultActivitySid);
            }
            
            if (eventCallbackUrl != null) {
                request.addPostParam("EventCallbackUrl", eventCallbackUrl);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (timeoutActivitySid != null) {
                request.addPostParam("TimeoutActivitySid", timeoutActivitySid);
            }
        }
    }
}