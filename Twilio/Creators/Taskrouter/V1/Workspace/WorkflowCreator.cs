using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Workflow;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class WorkflowCreator : Creator<Workflow> {
        private string workspaceSid;
        private string friendlyName;
        private string configuration;
        private string assignmentCallbackUrl;
        private string fallbackAssignmentCallbackUrl;
        private int taskReservationTimeout;
    
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
        public WorkflowCreator setTaskReservationTimeout(int taskReservationTimeout) {
            this.taskReservationTimeout = taskReservationTimeout;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Workflow
         */
        [Override]
        public Workflow execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Workflow creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Workflow.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (configuration != null) {
                request.addPostParam("Configuration", configuration);
            }
            
            if (assignmentCallbackUrl != null) {
                request.addPostParam("AssignmentCallbackUrl", assignmentCallbackUrl);
            }
            
            if (fallbackAssignmentCallbackUrl != null) {
                request.addPostParam("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl);
            }
            
            if (taskReservationTimeout != null) {
                request.addPostParam("TaskReservationTimeout", taskReservationTimeout.ToString());
            }
        }
    }
}