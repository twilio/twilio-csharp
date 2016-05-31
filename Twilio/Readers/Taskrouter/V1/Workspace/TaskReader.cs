using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Taskrouter.V1.Workspace {

    public class TaskReader : Reader<TaskResource> {
        private string workspaceSid;
        private int? priority;
        private TaskResource.Status assignmentStatus;
        private string workflowSid;
        private string workflowName;
        private string taskQueueSid;
        private string taskQueueName;
    
        /**
         * Construct a new TaskReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public TaskReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public TaskReader byPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * The assignment_status
         * 
         * @param assignmentStatus The assignment_status
         * @return this
         */
        public TaskReader byAssignmentStatus(TaskResource.Status assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /**
         * The workflow_sid
         * 
         * @param workflowSid The workflow_sid
         * @return this
         */
        public TaskReader byWorkflowSid(string workflowSid) {
            this.workflowSid = workflowSid;
            return this;
        }
    
        /**
         * The workflow_name
         * 
         * @param workflowName The workflow_name
         * @return this
         */
        public TaskReader byWorkflowName(string workflowName) {
            this.workflowName = workflowName;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public TaskReader byTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /**
         * The task_queue_name
         * 
         * @param taskQueueName The task_queue_name
         * @return this
         */
        public TaskReader byTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskResource ResourceSet
         */
        public override Task<ResourceSet<TaskResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            
            AddQueryParams(request);
            
            Page<TaskResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<TaskResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskResource ResourceSet
         */
        public override ResourceSet<TaskResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            
            AddQueryParams(request);
            
            Page<TaskResource> page = PageForRequest(client, request);
            
            return new ResourceSet<TaskResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TaskResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of TaskResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TaskResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.OK) {
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
            
            Page<TaskResource> result = new Page<TaskResource>();
            result.deserialize("tasks", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (priority != null) {
                request.AddQueryParam("Priority", priority.ToString());
            }
            
            if (assignmentStatus != null) {
                request.AddQueryParam("AssignmentStatus", assignmentStatus.ToString());
            }
            
            if (workflowSid != null) {
                request.AddQueryParam("WorkflowSid", workflowSid);
            }
            
            if (workflowName != null) {
                request.AddQueryParam("WorkflowName", workflowName);
            }
            
            if (taskQueueSid != null) {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            if (taskQueueName != null) {
                request.AddQueryParam("TaskQueueName", taskQueueName);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}