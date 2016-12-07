using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkflowResource : Resource 
    {
        private static Request BuildFetchRequest(FetchWorkflowOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workflows/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkflowResource Fetch(FetchWorkflowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowResource> FetchAsync(FetchWorkflowOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkflowResource Fetch(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchWorkflowOptions(workspaceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowResource> FetchAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchWorkflowOptions(workspaceSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateWorkflowOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workflows/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static WorkflowResource Update(UpdateWorkflowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowResource> UpdateAsync(UpdateWorkflowOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static WorkflowResource Update(string workspaceSid, string sid, string friendlyName = null, Uri assignmentCallbackUrl = null, Uri fallbackAssignmentCallbackUrl = null, string configuration = null, int? taskReservationTimeout = null, ITwilioRestClient client = null)
        {
            var options = new UpdateWorkflowOptions(workspaceSid, sid){FriendlyName = friendlyName, AssignmentCallbackUrl = assignmentCallbackUrl, FallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl, Configuration = configuration, TaskReservationTimeout = taskReservationTimeout};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowResource> UpdateAsync(string workspaceSid, string sid, string friendlyName = null, Uri assignmentCallbackUrl = null, Uri fallbackAssignmentCallbackUrl = null, string configuration = null, int? taskReservationTimeout = null, ITwilioRestClient client = null)
        {
            var options = new UpdateWorkflowOptions(workspaceSid, sid){FriendlyName = friendlyName, AssignmentCallbackUrl = assignmentCallbackUrl, FallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl, Configuration = configuration, TaskReservationTimeout = taskReservationTimeout};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteWorkflowOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workflows/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteWorkflowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteWorkflowOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteWorkflowOptions(workspaceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteWorkflowOptions(workspaceSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadWorkflowOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workflows",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<WorkflowResource> Read(ReadWorkflowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<WorkflowResource>.FromJson("workflows", response.Content);
            return new ResourceSet<WorkflowResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<WorkflowResource>> ReadAsync(ReadWorkflowOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<WorkflowResource> Read(string workspaceSid, string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadWorkflowOptions(workspaceSid){FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<WorkflowResource>> ReadAsync(string workspaceSid, string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadWorkflowOptions(workspaceSid){FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<WorkflowResource> NextPage(Page<WorkflowResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<WorkflowResource>.FromJson("workflows", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateWorkflowOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workflows",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static WorkflowResource Create(CreateWorkflowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowResource> CreateAsync(CreateWorkflowOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static WorkflowResource Create(string workspaceSid, string friendlyName, string configuration, Uri assignmentCallbackUrl = null, Uri fallbackAssignmentCallbackUrl = null, int? taskReservationTimeout = null, ITwilioRestClient client = null)
        {
            var options = new CreateWorkflowOptions(workspaceSid, friendlyName, configuration){AssignmentCallbackUrl = assignmentCallbackUrl, FallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl, TaskReservationTimeout = taskReservationTimeout};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowResource> CreateAsync(string workspaceSid, string friendlyName, string configuration, Uri assignmentCallbackUrl = null, Uri fallbackAssignmentCallbackUrl = null, int? taskReservationTimeout = null, ITwilioRestClient client = null)
        {
            var options = new CreateWorkflowOptions(workspaceSid, friendlyName, configuration){AssignmentCallbackUrl = assignmentCallbackUrl, FallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl, TaskReservationTimeout = taskReservationTimeout};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkflowResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkflowResource object represented by the provided JSON </returns> 
        public static WorkflowResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkflowResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("assignment_callback_url")]
        public Uri AssignmentCallbackUrl { get; private set; }
        [JsonProperty("configuration")]
        public string Configuration { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("document_content_type")]
        public string DocumentContentType { get; private set; }
        [JsonProperty("fallback_assignment_callback_url")]
        public Uri FallbackAssignmentCallbackUrl { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("task_reservation_timeout")]
        public int? TaskReservationTimeout { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private WorkflowResource()
        {
        
        }
    }

}