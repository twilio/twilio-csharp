using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskReader : Reader<TaskResource> 
    {
        public string workspaceSid { get; }
        public int? priority { get; set; }
        public TaskResource.Status assignmentStatus { get; set; }
        public string workflowSid { get; set; }
        public string workflowName { get; set; }
        public string taskQueueSid { get; set; }
        public string taskQueueName { get; set; }
        public string taskChannel { get; set; }
    
        /// <summary>
        /// Construct a new TaskReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="priority"> The priority </param>
        /// <param name="assignmentStatus"> The assignment_status </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <param name="workflowName"> The workflow_name </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="taskChannel"> The task_channel </param>
        public TaskReader(string workspaceSid, int? priority=null, TaskResource.Status assignmentStatus=null, string workflowSid=null, string workflowName=null, string taskQueueSid=null, string taskQueueName=null, string taskChannel=null)
        {
            this.workspaceSid = workspaceSid;
            this.taskQueueSid = taskQueueSid;
            this.workflowSid = workflowSid;
            this.workflowName = workflowName;
            this.assignmentStatus = assignmentStatus;
            this.taskChannel = taskChannel;
            this.priority = priority;
            this.taskQueueName = taskQueueName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TaskResource ResourceSet </returns> 
        public override Task<ResourceSet<TaskResource>> ReadAsync(ITwilioRestClient client)
        {
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
        public override ResourceSet<TaskResource> Read(ITwilioRestClient client)
        {
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
        public override Page<TaskResource> NextPage(Page<TaskResource> page, ITwilioRestClient client)
        {
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
        protected Page<TaskResource> PageForRequest(ITwilioRestClient client, Request request)
        {
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
        private void AddQueryParams(Request request)
        {
            if (priority != null)
            {
                request.AddQueryParam("Priority", priority.ToString());
            }
            
            if (assignmentStatus != null)
            {
                request.AddQueryParam("AssignmentStatus", assignmentStatus.ToString());
            }
            
            if (workflowSid != null)
            {
                request.AddQueryParam("WorkflowSid", workflowSid);
            }
            
            if (workflowName != null)
            {
                request.AddQueryParam("WorkflowName", workflowName);
            }
            
            if (taskQueueSid != null)
            {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            if (taskQueueName != null)
            {
                request.AddQueryParam("TaskQueueName", taskQueueName);
            }
            
            if (taskChannel != null)
            {
                request.AddQueryParam("TaskChannel", taskChannel);
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}