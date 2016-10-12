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
    
        /// <summary>
        /// Construct a new WorkspaceCreator
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public WorkspaceCreator(string friendlyName) {
            this.friendlyName = friendlyName;
        }
    
        /// <summary>
        /// The event_callback_url
        /// </summary>
        ///
        /// <param name="eventCallbackUrl"> The event_callback_url </param>
        /// <returns> this </returns> 
        public WorkspaceCreator setEventCallbackUrl(Uri eventCallbackUrl) {
            this.eventCallbackUrl = eventCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The event_callback_url
        /// </summary>
        ///
        /// <param name="eventCallbackUrl"> The event_callback_url </param>
        /// <returns> this </returns> 
        public WorkspaceCreator setEventCallbackUrl(string eventCallbackUrl) {
            return setEventCallbackUrl(Promoter.UriFromString(eventCallbackUrl));
        }
    
        /// <summary>
        /// The events_filter
        /// </summary>
        ///
        /// <param name="eventsFilter"> The events_filter </param>
        /// <returns> this </returns> 
        public WorkspaceCreator setEventsFilter(string eventsFilter) {
            this.eventsFilter = eventsFilter;
            return this;
        }
    
        /// <summary>
        /// The multi_task_enabled
        /// </summary>
        ///
        /// <param name="multiTaskEnabled"> The multi_task_enabled </param>
        /// <returns> this </returns> 
        public WorkspaceCreator setMultiTaskEnabled(bool? multiTaskEnabled) {
            this.multiTaskEnabled = multiTaskEnabled;
            return this;
        }
    
        /// <summary>
        /// The template
        /// </summary>
        ///
        /// <param name="template"> The template </param>
        /// <returns> this </returns> 
        public WorkspaceCreator setTemplate(string template) {
            this.template = template;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkspaceResource </returns> 
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
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkspaceResource </returns> 
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
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
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