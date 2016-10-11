using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskReader : Reader<TaskResource> {
        private string workspaceSid;
        private int? priority;
        private TaskResource.Status assignmentStatus;
        private string workflowSid;
        private string workflowName;
        private string taskQueueSid;
        private string taskQueueName;
        private string taskChannel;
    
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
        public TaskReader ByPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * The assignment_status
         * 
         * @param assignmentStatus The assignment_status
         * @return this
         */
        public TaskReader ByAssignmentStatus(TaskResource.Status assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /**
         * The workflow_sid
         * 
         * @param workflowSid The workflow_sid
         * @return this
         */
        public TaskReader ByWorkflowSid(string workflowSid) {
            this.workflowSid = workflowSid;
            return this;
        }
    
        /**
         * The workflow_name
         * 
         * @param workflowName The workflow_name
         * @return this
         */
        public TaskReader ByWorkflowName(string workflowName) {
            this.workflowName = workflowName;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public TaskReader ByTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /**
         * The task_queue_name
         * 
         * @param taskQueueName The task_queue_name
         * @return this
         */
        public TaskReader ByTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        /**
         * The task_channel
         * 
         * @param taskChannel The task_channel
         * @return this
         */
        public TaskReader ByTaskChannel(string taskChannel) {
            this.taskChannel = taskChannel;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskResource ResourceSet
         */
        public override Task<ResourceSet<TaskResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<TaskResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TaskResource ResourceSet
         */
        public override ResourceSet<TaskResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<TaskResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TaskResource> NextPage(Page<TaskResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of TaskResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TaskResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return Page<TaskResource>.FromJson("tasks", response.GetContent());
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
            
            if (taskChannel != null) {
                request.AddQueryParam("TaskChannel", taskChannel);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}