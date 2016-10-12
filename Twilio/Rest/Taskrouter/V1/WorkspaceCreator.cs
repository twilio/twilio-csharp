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

    public class WorkspaceCreator : Creator<WorkspaceResource> {
        private string friendlyName;
        private Uri eventCallbackUrl;
        private string eventsFilter;
        private bool? multiTaskEnabled;
        private string template;
    
        /**
         * Construct a new WorkspaceCreator
         * 
         * @param friendlyName The friendly_name
         */
        public WorkspaceCreator(string friendlyName) {
            this.friendlyName = friendlyName;
        }
    
        /**
         * The event_callback_url
         * 
         * @param eventCallbackUrl The event_callback_url
         * @return this
         */
        public WorkspaceCreator setEventCallbackUrl(Uri eventCallbackUrl) {
            this.eventCallbackUrl = eventCallbackUrl;
            return this;
        }
    
        /**
         * The event_callback_url
         * 
         * @param eventCallbackUrl The event_callback_url
         * @return this
         */
        public WorkspaceCreator setEventCallbackUrl(string eventCallbackUrl) {
            return setEventCallbackUrl(Promoter.UriFromString(eventCallbackUrl));
        }
    
        /**
         * The events_filter
         * 
         * @param eventsFilter The events_filter
         * @return this
         */
        public WorkspaceCreator setEventsFilter(string eventsFilter) {
            this.eventsFilter = eventsFilter;
            return this;
        }
    
        /**
         * The multi_task_enabled
         * 
         * @param multiTaskEnabled The multi_task_enabled
         * @return this
         */
        public WorkspaceCreator setMultiTaskEnabled(bool? multiTaskEnabled) {
            this.multiTaskEnabled = multiTaskEnabled;
            return this;
        }
    
        /**
         * The template
         * 
         * @param template The template
         * @return this
         */
        public WorkspaceCreator setTemplate(string template) {
            this.template = template;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created WorkspaceResource
         */
        public override async Task<WorkspaceResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkspaceResource.FromJson(response.Content);
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created WorkspaceResource
         */
        public override WorkspaceResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkspaceResource.FromJson(response.Content);
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
            
            if (eventCallbackUrl != null) {
                request.AddPostParam("EventCallbackUrl", eventCallbackUrl.ToString());
            }
            
            if (eventsFilter != null) {
                request.AddPostParam("EventsFilter", eventsFilter);
            }
            
            if (multiTaskEnabled != null) {
                request.AddPostParam("MultiTaskEnabled", multiTaskEnabled.ToString());
            }
            
            if (template != null) {
                request.AddPostParam("Template", template);
            }
        }
    }
}