using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Task;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class TaskCreator : Creator<Task> {
        private String workspaceSid;
        private String attributes;
        private String workflowSid;
        private Integer timeout;
        private Integer priority;
    
        /**
         * Construct a new TaskCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param attributes The attributes
         * @param workflowSid The workflow_sid
         */
        public TaskCreator(String workspaceSid, String attributes, String workflowSid) {
            this.workspaceSid = workspaceSid;
            this.attributes = attributes;
            this.workflowSid = workflowSid;
        }
    
        /**
         * The timeout
         * 
         * @param timeout The timeout
         * @return this
         */
        public TaskCreator setTimeout(Integer timeout) {
            this.timeout = timeout;
            return this;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public TaskCreator setPriority(Integer priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Task
         */
        [Override]
        public Task execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Task creation failed: Unable to connect to server");
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
            
            return Task.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (attributes != null) {
                request.addPostParam("Attributes", attributes);
            }
            
            if (workflowSid != null) {
                request.addPostParam("WorkflowSid", workflowSid);
            }
            
            if (timeout != null) {
                request.addPostParam("Timeout", timeout.toString());
            }
            
            if (priority != null) {
                request.addPostParam("Priority", priority.toString());
            }
        }
    }
}