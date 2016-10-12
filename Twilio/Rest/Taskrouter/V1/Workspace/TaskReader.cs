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
    
        /// <summary>
        /// Construct a new TaskReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public TaskReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// The priority
        /// </summary>
        ///
        /// <param name="priority"> The priority </param>
        /// <returns> this </returns> 
        public TaskReader ByPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /// <summary>
        /// The assignment_status
        /// </summary>
        ///
        /// <param name="assignmentStatus"> The assignment_status </param>
        /// <returns> this </returns> 
        public TaskReader ByAssignmentStatus(TaskResource.Status assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /// <summary>
        /// The workflow_sid
        /// </summary>
        ///
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <returns> this </returns> 
        public TaskReader ByWorkflowSid(string workflowSid) {
            this.workflowSid = workflowSid;
            return this;
        }
    
        /// <summary>
        /// The workflow_name
        /// </summary>
        ///
        /// <param name="workflowName"> The workflow_name </param>
        /// <returns> this </returns> 
        public TaskReader ByWorkflowName(string workflowName) {
            this.workflowName = workflowName;
            return this;
        }
    
        /// <summary>
        /// The task_queue_sid
        /// </summary>
        ///
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <returns> this </returns> 
        public TaskReader ByTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /// <summary>
        /// The task_queue_name
        /// </summary>
        ///
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <returns> this </returns> 
        public TaskReader ByTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        /// <summary>
        /// The task_channel
        /// </summary>
        ///
        /// <param name="taskChannel"> The task_channel </param>
        /// <returns> this </returns> 
        public TaskReader ByTaskChannel(string taskChannel) {
            this.taskChannel = taskChannel;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TaskResource ResourceSet </returns> 
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
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TaskResource ResourceSet </returns> 
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
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<TaskResource> NextPage(Page<TaskResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of TaskResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<TaskResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource read failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<TaskResource>.FromJson("tasks", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
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