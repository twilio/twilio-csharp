using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1 
{

    public class WorkspaceCreator : Creator<WorkspaceResource> 
    {
        public string FriendlyName { get; }
        public Uri EventCallbackUrl { get; set; }
        public string EventsFilter { get; set; }
        public bool? MultiTaskEnabled { get; set; }
        public string Template { get; set; }
    
        /// <summary>
        /// Construct a new WorkspaceCreator
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public WorkspaceCreator(string friendlyName)
        {
            FriendlyName = friendlyName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkspaceResource </returns> 
        public override async System.Threading.Tasks.Task<WorkspaceResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Taskrouter,
                "/v1/Workspaces"
            );
            
            AddPostParams(request);
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
        public override WorkspaceResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Taskrouter,
                "/v1/Workspaces"
            );
            
            AddPostParams(request);
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
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (EventCallbackUrl != null)
            {
                request.AddPostParam("EventCallbackUrl", EventCallbackUrl.ToString());
            }
            
            if (EventsFilter != null)
            {
                request.AddPostParam("EventsFilter", EventsFilter);
            }
            
            if (MultiTaskEnabled != null)
            {
                request.AddPostParam("MultiTaskEnabled", MultiTaskEnabled.ToString());
            }
            
            if (Template != null)
            {
                request.AddPostParam("Template", Template);
            }
        }
    }
}