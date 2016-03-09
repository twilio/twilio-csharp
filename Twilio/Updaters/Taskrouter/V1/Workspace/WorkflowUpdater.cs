using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Workflow;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class WorkflowUpdater : Updater<Workflow> {
        private string workspaceSid;
        private string sid;
        private string friendlyName;
        private string assignmentCallbackUrl;
        private string fallbackAssignmentCallbackUrl;
        private string configuration;
        private int taskReservationTimeout;
    
        /**
         * Construct a new WorkflowUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public WorkflowUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkflowUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The assignment_callback_url
         * 
         * @param assignmentCallbackUrl The assignment_callback_url
         * @return this
         */
        public WorkflowUpdater setAssignmentCallbackUrl(string assignmentCallbackUrl) {
            this.assignmentCallbackUrl = assignmentCallbackUrl;
            return this;
        }
    
        /**
         * The fallback_assignment_callback_url
         * 
         * @param fallbackAssignmentCallbackUrl The fallback_assignment_callback_url
         * @return this
         */
        public WorkflowUpdater setFallbackAssignmentCallbackUrl(string fallbackAssignmentCallbackUrl) {
            this.fallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl;
            return this;
        }
    
        /**
         * The configuration
         * 
         * @param configuration The configuration
         * @return this
         */
        public WorkflowUpdater setConfiguration(string configuration) {
            this.configuration = configuration;
            return this;
        }
    
        /**
         * The task_reservation_timeout
         * 
         * @param taskReservationTimeout The task_reservation_timeout
         * @return this
         */
        public WorkflowUpdater setTaskReservationTimeout(int taskReservationTimeout) {
            this.taskReservationTimeout = taskReservationTimeout;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Workflow
         */
        [Override]
        public Workflow execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Workflow update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            if (assignmentCallbackUrl != null) {
                request.addPostParam("AssignmentCallbackUrl", assignmentCallbackUrl);
            }
            
            if (fallbackAssignmentCallbackUrl != null) {
                request.addPostParam("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl);
            }
            
            if (configuration != null) {
                request.addPostParam("Configuration", configuration);
            }
            
            if (taskReservationTimeout != null) {
                request.addPostParam("TaskReservationTimeout", taskReservationTimeout.ToString());
            }
        }
    }
}