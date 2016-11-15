using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskReader : Reader<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public int? Priority { get; set; }
        public TaskResource.StatusEnum AssignmentStatus { get; set; }
        public string WorkflowSid { get; set; }
        public string WorkflowName { get; set; }
        public string TaskQueueSid { get; set; }
        public string TaskQueueName { get; set; }
        public string TaskChannel { get; set; }
    
        /// <summary>
        /// Construct a new TaskReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public TaskReader(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TaskResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<TaskResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Tasks"
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
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Tasks"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<TaskResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<TaskResource> NextPage(Page<TaskResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter
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
            if (Priority != null)
            {
                request.AddQueryParam("Priority", Priority.ToString());
            }
            
            if (AssignmentStatus != null)
            {
                request.AddQueryParam("AssignmentStatus", AssignmentStatus.ToString());
            }
            
            if (WorkflowSid != null)
            {
                request.AddQueryParam("WorkflowSid", WorkflowSid);
            }
            
            if (WorkflowName != null)
            {
                request.AddQueryParam("WorkflowName", WorkflowName);
            }
            
            if (TaskQueueSid != null)
            {
                request.AddQueryParam("TaskQueueSid", TaskQueueSid);
            }
            
            if (TaskQueueName != null)
            {
                request.AddQueryParam("TaskQueueName", TaskQueueName);
            }
            
            if (TaskChannel != null)
            {
                request.AddQueryParam("TaskChannel", TaskChannel);
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}