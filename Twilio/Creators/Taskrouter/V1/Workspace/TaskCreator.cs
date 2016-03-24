using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Creators.Taskrouter.V1.Workspace {

    public class TaskCreator : Creator<TaskResource> {
        private string workspaceSid;
        private string attributes;
        private string workflowSid;
        private int timeout;
        private int priority;
    
        /**
         * Construct a new TaskCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param attributes The attributes
         * @param workflowSid The workflow_sid
         */
        public TaskCreator(string workspaceSid, string attributes, string workflowSid) {
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
        public TaskCreator setTimeout(int timeout) {
            this.timeout = timeout;
            return this;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public TaskCreator setPriority(int priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created TaskResource
         */
        public override TaskResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return TaskResource.fromJson(response.GetContent());
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
                request.addPostParam("Timeout", timeout.ToString());
            }
            
            if (priority != null) {
                request.addPostParam("Priority", priority.ToString());
            }
        }
    }
}