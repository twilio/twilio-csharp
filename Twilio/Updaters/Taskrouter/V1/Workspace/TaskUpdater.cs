using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;
using Twilio.Updaters;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class TaskUpdater : Updater<TaskResource> {
        private string workspaceSid;
        private string sid;
        private string attributes;
        private TaskResource.Status assignmentStatus;
        private string reason;
        private int priority;
    
        /**
         * Construct a new TaskUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public TaskUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public TaskUpdater setAttributes(string attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * The assignment_status
         * 
         * @param assignmentStatus The assignment_status
         * @return this
         */
        public TaskUpdater setAssignmentStatus(TaskResource.Status assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /**
         * The reason
         * 
         * @param reason The reason
         * @return this
         */
        public TaskUpdater setReason(string reason) {
            this.reason = reason;
            return this;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public TaskUpdater setPriority(int priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated TaskResource
         */
        public override async Task<TaskResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return TaskResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (assignmentStatus != null) {
                request.AddPostParam("AssignmentStatus", assignmentStatus.ToString());
            }
            
            if (reason != null) {
                request.AddPostParam("Reason", reason);
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
        }
    }
}