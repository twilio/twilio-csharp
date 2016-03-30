using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class WorkflowCreator : Creator<WorkflowResource> {
        private string workspaceSid;
        private string friendlyName;
        private string configuration;
        private string assignmentCallbackUrl;
        private string fallbackAssignmentCallbackUrl;
        private int? taskReservationTimeout;
    
        /**
         * Construct a new WorkflowCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param configuration The configuration
         * @param assignmentCallbackUrl The assignment_callback_url
         */
        public WorkflowCreator(string workspaceSid, string friendlyName, string configuration, string assignmentCallbackUrl) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
            this.configuration = configuration;
            this.assignmentCallbackUrl = assignmentCallbackUrl;
        }
    
        /**
         * The fallback_assignment_callback_url
         * 
         * @param fallbackAssignmentCallbackUrl The fallback_assignment_callback_url
         * @return this
         */
        public WorkflowCreator setFallbackAssignmentCallbackUrl(string fallbackAssignmentCallbackUrl) {
            this.fallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl;
            return this;
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
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created WorkflowResource
         */
        public override async Task<WorkflowResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkflowResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
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
                request.AddPostParam("AssignmentCallbackUrl", assignmentCallbackUrl);
            }
            
            if (fallbackAssignmentCallbackUrl != null) {
                request.AddPostParam("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl);
            }
            
            if (taskReservationTimeout != null) {
                request.AddPostParam("TaskReservationTimeout", taskReservationTimeout.ToString());
            }
        }
    }
}