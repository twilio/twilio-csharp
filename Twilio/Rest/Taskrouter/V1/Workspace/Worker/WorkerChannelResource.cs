using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class WorkerChannelResource : Resource 
    {
        private static Request BuildReadRequest(ReadWorkerChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Channels",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<WorkerChannelResource> Read(ReadWorkerChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<WorkerChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<WorkerChannelResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<WorkerChannelResource>> ReadAsync(ReadWorkerChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<WorkerChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<WorkerChannelResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<WorkerChannelResource> Read(string workspaceSid, string workerSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadWorkerChannelOptions(workspaceSid, workerSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<WorkerChannelResource>> ReadAsync(string workspaceSid, string workerSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadWorkerChannelOptions(workspaceSid, workerSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<WorkerChannelResource> NextPage(Page<WorkerChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<WorkerChannelResource>.FromJson("channels", response.Content);
        }
    
        private static Request BuildFetchRequest(FetchWorkerChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Channels/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkerChannelResource Fetch(FetchWorkerChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkerChannelResource> FetchAsync(FetchWorkerChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkerChannelResource Fetch(string workspaceSid, string workerSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchWorkerChannelOptions(workspaceSid, workerSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkerChannelResource> FetchAsync(string workspaceSid, string workerSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchWorkerChannelOptions(workspaceSid, workerSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateWorkerChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Channels/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static WorkerChannelResource Update(UpdateWorkerChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkerChannelResource> UpdateAsync(UpdateWorkerChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static WorkerChannelResource Update(string workspaceSid, string workerSid, string sid, int? capacity = null, bool? available = null, ITwilioRestClient client = null)
        {
            var options = new UpdateWorkerChannelOptions(workspaceSid, workerSid, sid){Capacity = capacity, Available = available};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkerChannelResource> UpdateAsync(string workspaceSid, string workerSid, string sid, int? capacity = null, bool? available = null, ITwilioRestClient client = null)
        {
            var options = new UpdateWorkerChannelOptions(workspaceSid, workerSid, sid){Capacity = capacity, Available = available};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkerChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerChannelResource object represented by the provided JSON </returns> 
        public static WorkerChannelResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkerChannelResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("assigned_tasks")]
        public int? AssignedTasks { get; private set; }
        [JsonProperty("available")]
        public bool? Available { get; private set; }
        [JsonProperty("available_capacity_percentage")]
        public int? AvailableCapacityPercentage { get; private set; }
        [JsonProperty("configured_capacity")]
        public int? ConfiguredCapacity { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("task_channel_sid")]
        public string TaskChannelSid { get; private set; }
        [JsonProperty("task_channel_unique_name")]
        public string TaskChannelUniqueName { get; private set; }
        [JsonProperty("worker_sid")]
        public string WorkerSid { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private WorkerChannelResource()
        {
        
        }
    }

}