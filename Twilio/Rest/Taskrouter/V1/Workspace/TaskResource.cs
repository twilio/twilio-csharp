using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Pending = new StatusEnum("pending");
            public static readonly StatusEnum Reserved = new StatusEnum("reserved");
            public static readonly StatusEnum Assigned = new StatusEnum("assigned");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
        }
    
        private static Request BuildFetchRequest(FetchTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Tasks/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TaskResource Fetch(FetchTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskResource> FetchAsync(FetchTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TaskResource Fetch(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchTaskOptions(workspaceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskResource> FetchAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchTaskOptions(workspaceSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Tasks/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static TaskResource Update(UpdateTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskResource> UpdateAsync(UpdateTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static TaskResource Update(string workspaceSid, string sid, string attributes = null, TaskResource.StatusEnum assignmentStatus = null, string reason = null, int? priority = null, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTaskOptions(workspaceSid, sid){Attributes = attributes, AssignmentStatus = assignmentStatus, Reason = reason, Priority = priority, TaskChannel = taskChannel};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskResource> UpdateAsync(string workspaceSid, string sid, string attributes = null, TaskResource.StatusEnum assignmentStatus = null, string reason = null, int? priority = null, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTaskOptions(workspaceSid, sid){Attributes = attributes, AssignmentStatus = assignmentStatus, Reason = reason, Priority = priority, TaskChannel = taskChannel};
            return await UpdateAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Tasks/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteTaskOptions(workspaceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteTaskOptions(workspaceSid, sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Tasks",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TaskResource> Read(ReadTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TaskResource>.FromJson("tasks", response.Content);
            return new ResourceSet<TaskResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TaskResource>> ReadAsync(ReadTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<TaskResource>.FromJson("tasks", response.Content);
            return new ResourceSet<TaskResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TaskResource> Read(string workspaceSid, int? priority = null, TaskResource.StatusEnum assignmentStatus = null, string workflowSid = null, string workflowName = null, string taskQueueSid = null, string taskQueueName = null, string taskChannel = null, string evaluateTaskAttributes = null, string ordering = null, bool? hasAddons = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskOptions(workspaceSid){Priority = priority, AssignmentStatus = assignmentStatus, WorkflowSid = workflowSid, WorkflowName = workflowName, TaskQueueSid = taskQueueSid, TaskQueueName = taskQueueName, TaskChannel = taskChannel, EvaluateTaskAttributes = evaluateTaskAttributes, Ordering = ordering, HasAddons = hasAddons, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TaskResource>> ReadAsync(string workspaceSid, int? priority = null, TaskResource.StatusEnum assignmentStatus = null, string workflowSid = null, string workflowName = null, string taskQueueSid = null, string taskQueueName = null, string taskChannel = null, string evaluateTaskAttributes = null, string ordering = null, bool? hasAddons = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskOptions(workspaceSid){Priority = priority, AssignmentStatus = assignmentStatus, WorkflowSid = workflowSid, WorkflowName = workflowName, TaskQueueSid = taskQueueSid, TaskQueueName = taskQueueName, TaskChannel = taskChannel, EvaluateTaskAttributes = evaluateTaskAttributes, Ordering = ordering, HasAddons = hasAddons, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<TaskResource> NextPage(Page<TaskResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TaskResource>.FromJson("tasks", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Tasks",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static TaskResource Create(CreateTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskResource> CreateAsync(CreateTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static TaskResource Create(string workspaceSid, string attributes = null, string workflowSid = null, int? timeout = null, int? priority = null, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new CreateTaskOptions(workspaceSid){Attributes = attributes, WorkflowSid = workflowSid, Timeout = timeout, Priority = priority, TaskChannel = taskChannel};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskResource> CreateAsync(string workspaceSid, string attributes = null, string workflowSid = null, int? timeout = null, int? priority = null, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new CreateTaskOptions(workspaceSid){Attributes = attributes, WorkflowSid = workflowSid, Timeout = timeout, Priority = priority, TaskChannel = taskChannel};
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TaskResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskResource object represented by the provided JSON </returns> 
        public static TaskResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("age")]
        public int? Age { get; private set; }
        [JsonProperty("assignment_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskResource.StatusEnum AssignmentStatus { get; private set; }
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }
        [JsonProperty("addons")]
        public string Addons { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("priority")]
        public int? Priority { get; private set; }
        [JsonProperty("reason")]
        public string Reason { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("task_queue_sid")]
        public string TaskQueueSid { get; private set; }
        [JsonProperty("task_queue_friendly_name")]
        public string TaskQueueFriendlyName { get; private set; }
        [JsonProperty("task_channel_sid")]
        public string TaskChannelSid { get; private set; }
        [JsonProperty("task_channel_unique_name")]
        public string TaskChannelUniqueName { get; private set; }
        [JsonProperty("timeout")]
        public int? Timeout { get; private set; }
        [JsonProperty("workflow_sid")]
        public string WorkflowSid { get; private set; }
        [JsonProperty("workflow_friendly_name")]
        public string WorkflowFriendlyName { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private TaskResource()
        {
        
        }
    }

}