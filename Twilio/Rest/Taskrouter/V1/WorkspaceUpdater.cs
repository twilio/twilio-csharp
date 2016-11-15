using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1 
{

    public class WorkspaceUpdater : Updater<WorkspaceResource> 
    {
        public string Sid { get; }
        public string DefaultActivitySid { get; set; }
        public Uri EventCallbackUrl { get; set; }
        public string EventsFilter { get; set; }
        public string FriendlyName { get; set; }
        public bool? MultiTaskEnabled { get; set; }
        public string TimeoutActivitySid { get; set; }
    
        /// <summary>
        /// Construct a new WorkspaceUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public WorkspaceUpdater(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkspaceResource </returns> 
        public override async System.Threading.Tasks.Task<WorkspaceResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + Sid + ""
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
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + Sid + ""
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
            if (DefaultActivitySid != null)
            {
                request.AddPostParam("DefaultActivitySid", DefaultActivitySid);
            }
            
            if (EventCallbackUrl != null)
            {
                request.AddPostParam("EventCallbackUrl", EventCallbackUrl.ToString());
            }
            
            if (EventsFilter != null)
            {
                request.AddPostParam("EventsFilter", EventsFilter);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (MultiTaskEnabled != null)
            {
                request.AddPostParam("MultiTaskEnabled", MultiTaskEnabled.ToString());
            }
            
            if (TimeoutActivitySid != null)
            {
                request.AddPostParam("TimeoutActivitySid", TimeoutActivitySid);
            }
        }
    }
}