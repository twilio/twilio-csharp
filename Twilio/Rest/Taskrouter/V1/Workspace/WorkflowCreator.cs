using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkflowCreator : Creator<WorkflowResource> 
    {
        public string WorkspaceSid { get; }
        public string FriendlyName { get; }
        public string Configuration { get; }
        public Uri AssignmentCallbackUrl { get; set; }
        public Uri FallbackAssignmentCallbackUrl { get; set; }
        public int? TaskReservationTimeout { get; set; }
    
        /// <summary>
        /// Construct a new WorkflowCreator
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="configuration"> The configuration </param>
        public WorkflowCreator(string workspaceSid, string friendlyName, string configuration)
        {
            WorkspaceSid = workspaceSid;
            FriendlyName = friendlyName;
            Configuration = configuration;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkflowResource </returns> 
        public override async System.Threading.Tasks.Task<WorkflowResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Workflows"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkflowResource creation failed: Unable to connect to server");
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
            
            return WorkflowResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkflowResource </returns> 
        public override WorkflowResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Workflows"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkflowResource creation failed: Unable to connect to server");
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
            
            return WorkflowResource.FromJson(response.Content);
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
            
            if (Configuration != null)
            {
                request.AddPostParam("Configuration", Configuration);
            }
            
            if (AssignmentCallbackUrl != null)
            {
                request.AddPostParam("AssignmentCallbackUrl", AssignmentCallbackUrl.ToString());
            }
            
            if (FallbackAssignmentCallbackUrl != null)
            {
                request.AddPostParam("FallbackAssignmentCallbackUrl", FallbackAssignmentCallbackUrl.ToString());
            }
            
            if (TaskReservationTimeout != null)
            {
                request.AddPostParam("TaskReservationTimeout", TaskReservationTimeout.ToString());
            }
        }
    }
}