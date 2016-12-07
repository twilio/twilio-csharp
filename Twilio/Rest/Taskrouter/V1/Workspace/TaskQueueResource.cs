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

    public class TaskQueueResource : Resource 
    {
        public sealed class TaskOrderEnum : StringEnum 
        {
            private TaskOrderEnum(string value) : base(value) {}
            public TaskOrderEnum() {}
        
            public static readonly TaskOrderEnum Fifo = new TaskOrderEnum("FIFO");
            public static readonly TaskOrderEnum Lifo = new TaskOrderEnum("LIFO");
        }
    
        private static Request BuildFetchRequest(FetchTaskQueueOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TaskQueueResource Fetch(FetchTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueResource> FetchAsync(FetchTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TaskQueueResource Fetch(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchTaskQueueOptions(workspaceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueResource> FetchAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchTaskQueueOptions(workspaceSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateTaskQueueOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static TaskQueueResource Update(UpdateTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueResource> UpdateAsync(UpdateTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static TaskQueueResource Update(string workspaceSid, string sid, string friendlyName = null, string targetWorkers = null, string reservationActivitySid = null, string assignmentActivitySid = null, int? maxReservedWorkers = null, TaskQueueResource.TaskOrderEnum taskOrder = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTaskQueueOptions(workspaceSid, sid){FriendlyName = friendlyName, TargetWorkers = targetWorkers, ReservationActivitySid = reservationActivitySid, AssignmentActivitySid = assignmentActivitySid, MaxReservedWorkers = maxReservedWorkers, TaskOrder = taskOrder};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueResource> UpdateAsync(string workspaceSid, string sid, string friendlyName = null, string targetWorkers = null, string reservationActivitySid = null, string assignmentActivitySid = null, int? maxReservedWorkers = null, TaskQueueResource.TaskOrderEnum taskOrder = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTaskQueueOptions(workspaceSid, sid){FriendlyName = friendlyName, TargetWorkers = targetWorkers, ReservationActivitySid = reservationActivitySid, AssignmentActivitySid = assignmentActivitySid, MaxReservedWorkers = maxReservedWorkers, TaskOrder = taskOrder};
            return await UpdateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadTaskQueueOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TaskQueueResource> Read(ReadTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TaskQueueResource>.FromJson("task_queues", response.Content);
            return new ResourceSet<TaskQueueResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TaskQueueResource>> ReadAsync(ReadTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<TaskQueueResource>.FromJson("task_queues", response.Content);
            return new ResourceSet<TaskQueueResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TaskQueueResource> Read(string workspaceSid, string friendlyName = null, string evaluateWorkerAttributes = null, string workerSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskQueueOptions(workspaceSid){FriendlyName = friendlyName, EvaluateWorkerAttributes = evaluateWorkerAttributes, WorkerSid = workerSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TaskQueueResource>> ReadAsync(string workspaceSid, string friendlyName = null, string evaluateWorkerAttributes = null, string workerSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskQueueOptions(workspaceSid){FriendlyName = friendlyName, EvaluateWorkerAttributes = evaluateWorkerAttributes, WorkerSid = workerSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<TaskQueueResource> NextPage(Page<TaskQueueResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TaskQueueResource>.FromJson("task_queues", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateTaskQueueOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static TaskQueueResource Create(CreateTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueResource> CreateAsync(CreateTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static TaskQueueResource Create(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid, string targetWorkers = null, int? maxReservedWorkers = null, TaskQueueResource.TaskOrderEnum taskOrder = null, ITwilioRestClient client = null)
        {
            var options = new CreateTaskQueueOptions(workspaceSid, friendlyName, reservationActivitySid, assignmentActivitySid){TargetWorkers = targetWorkers, MaxReservedWorkers = maxReservedWorkers, TaskOrder = taskOrder};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueResource> CreateAsync(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid, string targetWorkers = null, int? maxReservedWorkers = null, TaskQueueResource.TaskOrderEnum taskOrder = null, ITwilioRestClient client = null)
        {
            var options = new CreateTaskQueueOptions(workspaceSid, friendlyName, reservationActivitySid, assignmentActivitySid){TargetWorkers = targetWorkers, MaxReservedWorkers = maxReservedWorkers, TaskOrder = taskOrder};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteTaskQueueOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteTaskQueueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteTaskQueueOptions options, ITwilioRestClient client = null)
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
            var options = new DeleteTaskQueueOptions(workspaceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteTaskQueueOptions(workspaceSid, sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueResource object represented by the provided JSON </returns> 
        public static TaskQueueResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskQueueResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("assignment_activity_sid")]
        public string AssignmentActivitySid { get; private set; }
        [JsonProperty("assignment_activity_name")]
        public string AssignmentActivityName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("max_reserved_workers")]
        public int? MaxReservedWorkers { get; private set; }
        [JsonProperty("reservation_activity_sid")]
        public string ReservationActivitySid { get; private set; }
        [JsonProperty("reservation_activity_name")]
        public string ReservationActivityName { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("target_workers")]
        public string TargetWorkers { get; private set; }
        [JsonProperty("task_order")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskQueueResource.TaskOrderEnum TaskOrder { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private TaskQueueResource()
        {
        
        }
    }

}