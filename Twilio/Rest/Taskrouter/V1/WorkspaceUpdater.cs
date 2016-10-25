using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1 
{

    public class WorkspaceUpdater : Updater<WorkspaceResource> 
    {
        public string sid { get; }
        public string defaultActivitySid { get; set; }
        public Uri eventCallbackUrl { get; set; }
        public string eventsFilter { get; set; }
        public string friendlyName { get; set; }
        public bool? multiTaskEnabled { get; set; }
        public string timeoutActivitySid { get; set; }
    
        /// <summary>
        /// Construct a new WorkspaceUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="defaultActivitySid"> The default_activity_sid </param>
        /// <param name="eventCallbackUrl"> The event_callback_url </param>
        /// <param name="eventsFilter"> The events_filter </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="multiTaskEnabled"> The multi_task_enabled </param>
        /// <param name="timeoutActivitySid"> The timeout_activity_sid </param>
        public WorkspaceUpdater(string sid, string defaultActivitySid=null, Uri eventCallbackUrl=null, string eventsFilter=null, string friendlyName=null, bool? multiTaskEnabled=null, string timeoutActivitySid=null)
        {
            this.sid = sid;
            this.defaultActivitySid = defaultActivitySid;
            this.multiTaskEnabled = multiTaskEnabled;
            this.eventCallbackUrl = eventCallbackUrl;
            this.timeoutActivitySid = timeoutActivitySid;
            this.friendlyName = friendlyName;
            this.eventsFilter = eventsFilter;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkspaceResource </returns> 
        public override async Task<WorkspaceResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkspaceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkspaceResource </returns> 
        public override WorkspaceResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
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
        private void AddPostParams(Request request)
        {
            if (defaultActivitySid != null)
            {
                request.AddPostParam("DefaultActivitySid", defaultActivitySid);
            }
            
            if (eventCallbackUrl != null)
            {
                request.AddPostParam("EventCallbackUrl", eventCallbackUrl.ToString());
            }
            
            if (eventsFilter != null)
            {
                request.AddPostParam("EventsFilter", eventsFilter);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (multiTaskEnabled != null)
            {
                request.AddPostParam("MultiTaskEnabled", multiTaskEnabled.ToString());
            }
            
            if (timeoutActivitySid != null)
            {
                request.AddPostParam("TimeoutActivitySid", timeoutActivitySid);
            }
        }
    }
}