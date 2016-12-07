using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Taskrouter.V1 
{

    public class WorkspaceResource : Resource 
    {
        public sealed class QueueOrderEnum : StringEnum 
        {
            private QueueOrderEnum(string value) : base(value) {}
            public QueueOrderEnum() {}
        
            public static readonly QueueOrderEnum Fifo = new QueueOrderEnum("FIFO");
            public static readonly QueueOrderEnum Lifo = new QueueOrderEnum("LIFO");
        }
    
        private static Request BuildFetchRequest(FetchWorkspaceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkspaceResource Fetch(FetchWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkspaceResource> FetchAsync(FetchWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkspaceResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchWorkspaceOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkspaceResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchWorkspaceOptions(sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateWorkspaceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static WorkspaceResource Update(UpdateWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkspaceResource> UpdateAsync(UpdateWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static WorkspaceResource Update(string sid, string defaultActivitySid = null, Uri eventCallbackUrl = null, string eventsFilter = null, string friendlyName = null, bool? multiTaskEnabled = null, string timeoutActivitySid = null, WorkspaceResource.QueueOrderEnum prioritizeQueueOrder = null, ITwilioRestClient client = null)
        {
            var options = new UpdateWorkspaceOptions(sid){DefaultActivitySid = defaultActivitySid, EventCallbackUrl = eventCallbackUrl, EventsFilter = eventsFilter, FriendlyName = friendlyName, MultiTaskEnabled = multiTaskEnabled, TimeoutActivitySid = timeoutActivitySid, PrioritizeQueueOrder = prioritizeQueueOrder};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkspaceResource> UpdateAsync(string sid, string defaultActivitySid = null, Uri eventCallbackUrl = null, string eventsFilter = null, string friendlyName = null, bool? multiTaskEnabled = null, string timeoutActivitySid = null, WorkspaceResource.QueueOrderEnum prioritizeQueueOrder = null, ITwilioRestClient client = null)
        {
            var options = new UpdateWorkspaceOptions(sid){DefaultActivitySid = defaultActivitySid, EventCallbackUrl = eventCallbackUrl, EventsFilter = eventsFilter, FriendlyName = friendlyName, MultiTaskEnabled = multiTaskEnabled, TimeoutActivitySid = timeoutActivitySid, PrioritizeQueueOrder = prioritizeQueueOrder};
            return await UpdateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadWorkspaceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<WorkspaceResource> Read(ReadWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<WorkspaceResource>.FromJson("workspaces", response.Content);
            return new ResourceSet<WorkspaceResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<WorkspaceResource>> ReadAsync(ReadWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<WorkspaceResource>.FromJson("workspaces", response.Content);
            return new ResourceSet<WorkspaceResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<WorkspaceResource> Read(string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadWorkspaceOptions{FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<WorkspaceResource>> ReadAsync(string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadWorkspaceOptions{FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<WorkspaceResource> NextPage(Page<WorkspaceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<WorkspaceResource>.FromJson("workspaces", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateWorkspaceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static WorkspaceResource Create(CreateWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkspaceResource> CreateAsync(CreateWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static WorkspaceResource Create(string friendlyName, Uri eventCallbackUrl = null, string eventsFilter = null, bool? multiTaskEnabled = null, string template = null, WorkspaceResource.QueueOrderEnum prioritizeQueueOrder = null, ITwilioRestClient client = null)
        {
            var options = new CreateWorkspaceOptions(friendlyName){EventCallbackUrl = eventCallbackUrl, EventsFilter = eventsFilter, MultiTaskEnabled = multiTaskEnabled, Template = template, PrioritizeQueueOrder = prioritizeQueueOrder};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkspaceResource> CreateAsync(string friendlyName, Uri eventCallbackUrl = null, string eventsFilter = null, bool? multiTaskEnabled = null, string template = null, WorkspaceResource.QueueOrderEnum prioritizeQueueOrder = null, ITwilioRestClient client = null)
        {
            var options = new CreateWorkspaceOptions(friendlyName){EventCallbackUrl = eventCallbackUrl, EventsFilter = eventsFilter, MultiTaskEnabled = multiTaskEnabled, Template = template, PrioritizeQueueOrder = prioritizeQueueOrder};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteWorkspaceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteWorkspaceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteWorkspaceOptions(sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteWorkspaceOptions(sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkspaceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkspaceResource object represented by the provided JSON </returns> 
        public static WorkspaceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkspaceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("default_activity_name")]
        public string DefaultActivityName { get; private set; }
        [JsonProperty("default_activity_sid")]
        public string DefaultActivitySid { get; private set; }
        [JsonProperty("event_callback_url")]
        public Uri EventCallbackUrl { get; private set; }
        [JsonProperty("events_filter")]
        public string EventsFilter { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("multi_task_enabled")]
        public bool? MultiTaskEnabled { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("timeout_activity_name")]
        public string TimeoutActivityName { get; private set; }
        [JsonProperty("timeout_activity_sid")]
        public string TimeoutActivitySid { get; private set; }
        [JsonProperty("prioritize_queue_order")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WorkspaceResource.QueueOrderEnum PrioritizeQueueOrder { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private WorkspaceResource()
        {
        
        }
    }

}