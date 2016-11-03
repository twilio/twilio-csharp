using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkflowUpdater : Updater<WorkflowResource> 
    {
        public string workspaceSid { get; }
        public string sid { get; }
        public string friendlyName { get; set; }
        public Uri assignmentCallbackUrl { get; set; }
        public Uri fallbackAssignmentCallbackUrl { get; set; }
        public string configuration { get; set; }
        public int? taskReservationTimeout { get; set; }
    
        /// <summary>
        /// Construct a new WorkflowUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public WorkflowUpdater(string workspaceSid, string sid)
        {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkflowResource </returns> 
        public override async Task<WorkflowResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkflowResource update failed: Unable to connect to server");
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
            
            return WorkflowResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated WorkflowResource </returns> 
        public override WorkflowResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkflowResource update failed: Unable to connect to server");
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
            
            return WorkflowResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (assignmentCallbackUrl != null)
            {
                request.AddPostParam("AssignmentCallbackUrl", assignmentCallbackUrl.ToString());
            }
            
            if (fallbackAssignmentCallbackUrl != null)
            {
                request.AddPostParam("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl.ToString());
            }
            
            if (configuration != null)
            {
                request.AddPostParam("Configuration", configuration);
            }
            
            if (taskReservationTimeout != null)
            {
                request.AddPostParam("TaskReservationTimeout", taskReservationTimeout.ToString());
            }
        }
    }
}