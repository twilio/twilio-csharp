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
    
        /**
         * Construct a new WorkflowCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param configuration The configuration
         */
        public WorkflowCreator(string workspaceSid, string friendlyName, string configuration) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
            this.configuration = configuration;
        }
    
        /**
         * The assignment_callback_url
         * 
         * @param assignmentCallbackUrl The assignment_callback_url
         * @return this
         */
        public WorkflowCreator setAssignmentCallbackUrl(Uri assignmentCallbackUrl) {
            this.assignmentCallbackUrl = assignmentCallbackUrl;
            return this;
        }
    
        /**
         * The assignment_callback_url
         * 
         * @param assignmentCallbackUrl The assignment_callback_url
         * @return this
         */
        public WorkflowCreator setAssignmentCallbackUrl(string assignmentCallbackUrl) {
            return setAssignmentCallbackUrl(Promoter.UriFromString(assignmentCallbackUrl));
        }
    
        /**
         * The fallback_assignment_callback_url
         * 
         * @param fallbackAssignmentCallbackUrl The fallback_assignment_callback_url
         * @return this
         */
        public WorkflowCreator setFallbackAssignmentCallbackUrl(Uri fallbackAssignmentCallbackUrl) {
            this.fallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl;
            return this;
        }
    
        /**
         * The fallback_assignment_callback_url
         * 
         * @param fallbackAssignmentCallbackUrl The fallback_assignment_callback_url
         * @return this
         */
        public WorkflowCreator setFallbackAssignmentCallbackUrl(string fallbackAssignmentCallbackUrl) {
            return setFallbackAssignmentCallbackUrl(Promoter.UriFromString(fallbackAssignmentCallbackUrl));
        }
    
        /**
         * The task_reservation_timeout
         * 
         * @param taskReservationTimeout The task_reservation_timeout
         * @return this
         */
        public WorkflowCreator setTaskReservationTimeout(int? taskReservationTimeout) {
            this.taskReservationTimeout = taskReservationTimeout;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created WorkflowResource
         */
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
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return WorkflowResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created WorkflowResource
         */
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
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return WorkflowResource.FromJson(response.GetContent());
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