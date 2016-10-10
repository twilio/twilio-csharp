using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1 {

    public class WorkspaceUpdater : Updater<WorkspaceResource> {
        private string sid;
        private string defaultActivitySid;
        private Uri eventCallbackUrl;
        private string eventsFilter;
        private string friendlyName;
        private bool? multiTaskEnabled;
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
        public WorkspaceUpdater setEventCallbackUrl(Uri eventCallbackUrl) {
            this.eventCallbackUrl = eventCallbackUrl;
            return this;
        }
    
        /**
         * The event_callback_url
         * 
         * @param eventCallbackUrl The event_callback_url
         * @return this
         */
        public WorkspaceUpdater setEventCallbackUrl(string eventCallbackUrl) {
            return setEventCallbackUrl(Promoter.UriFromString(eventCallbackUrl));
        }
    
        /**
         * The events_filter
         * 
         * @param eventsFilter The events_filter
         * @return this
         */
        public WorkspaceUpdater setEventsFilter(string eventsFilter) {
            this.eventsFilter = eventsFilter;
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
         * The multi_task_enabled
         * 
         * @param multiTaskEnabled The multi_task_enabled
         * @return this
         */
        public WorkspaceUpdater setMultiTaskEnabled(bool? multiTaskEnabled) {
            this.multiTaskEnabled = multiTaskEnabled;
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
        public override async Task<WorkspaceResource> UpdateAsync(ITwilioRestClient client) {
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
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
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
        public override WorkspaceResource Update(ITwilioRestClient client) {
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
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
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
            if (defaultActivitySid != null) {
                request.AddPostParam("DefaultActivitySid", defaultActivitySid);
            }
            
            if (eventCallbackUrl != null) {
                request.AddPostParam("EventCallbackUrl", eventCallbackUrl.ToString());
            }
            
            if (eventsFilter != null) {
                request.AddPostParam("EventsFilter", eventsFilter);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (multiTaskEnabled != null) {
                request.AddPostParam("MultiTaskEnabled", multiTaskEnabled.ToString());
            }
            
            if (timeoutActivitySid != null) {
                request.AddPostParam("TimeoutActivitySid", timeoutActivitySid);
            }
        }
    }
}