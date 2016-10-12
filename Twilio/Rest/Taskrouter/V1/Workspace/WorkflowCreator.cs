using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkflowCreator : Creator<WorkflowResource> {
        private string workspaceSid;
        private string friendlyName;
        private string configuration;
        private Uri assignmentCallbackUrl;
        private Uri fallbackAssignmentCallbackUrl;
        private int? taskReservationTimeout;
    
        /// <summary>
        /// Construct a new WorkflowCreator
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="configuration"> The configuration </param>
        public WorkflowCreator(string workspaceSid, string friendlyName, string configuration) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
            this.configuration = configuration;
        }
    
        /// <summary>
        /// The assignment_callback_url
        /// </summary>
        ///
        /// <param name="assignmentCallbackUrl"> The assignment_callback_url </param>
        /// <returns> this </returns> 
        public WorkflowCreator setAssignmentCallbackUrl(Uri assignmentCallbackUrl) {
            this.assignmentCallbackUrl = assignmentCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The assignment_callback_url
        /// </summary>
        ///
        /// <param name="assignmentCallbackUrl"> The assignment_callback_url </param>
        /// <returns> this </returns> 
        public WorkflowCreator setAssignmentCallbackUrl(string assignmentCallbackUrl) {
            return setAssignmentCallbackUrl(Promoter.UriFromString(assignmentCallbackUrl));
        }
    
        /// <summary>
        /// The fallback_assignment_callback_url
        /// </summary>
        ///
        /// <param name="fallbackAssignmentCallbackUrl"> The fallback_assignment_callback_url </param>
        /// <returns> this </returns> 
        public WorkflowCreator setFallbackAssignmentCallbackUrl(Uri fallbackAssignmentCallbackUrl) {
            this.fallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The fallback_assignment_callback_url
        /// </summary>
        ///
        /// <param name="fallbackAssignmentCallbackUrl"> The fallback_assignment_callback_url </param>
        /// <returns> this </returns> 
        public WorkflowCreator setFallbackAssignmentCallbackUrl(string fallbackAssignmentCallbackUrl) {
            return setFallbackAssignmentCallbackUrl(Promoter.UriFromString(fallbackAssignmentCallbackUrl));
        }
    
        /// <summary>
        /// The task_reservation_timeout
        /// </summary>
        ///
        /// <param name="taskReservationTimeout"> The task_reservation_timeout </param>
        /// <returns> this </returns> 
        public WorkflowCreator setTaskReservationTimeout(int? taskReservationTimeout) {
            this.taskReservationTimeout = taskReservationTimeout;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkflowResource </returns> 
        public override async Task<WorkflowResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows"
            );
            
            addPostParams(request);
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
        public override WorkflowResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows"
            );
            
            addPostParams(request);
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
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (configuration != null) {
                request.AddPostParam("Configuration", configuration);
            }
            
            if (assignmentCallbackUrl != null) {
                request.AddPostParam("AssignmentCallbackUrl", assignmentCallbackUrl.ToString());
            }
            
            if (fallbackAssignmentCallbackUrl != null) {
                request.AddPostParam("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl.ToString());
            }
            
            if (taskReservationTimeout != null) {
                request.AddPostParam("TaskReservationTimeout", taskReservationTimeout.ToString());
            }
        }
    }
}