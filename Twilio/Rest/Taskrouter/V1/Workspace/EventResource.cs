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

    public class EventResource : Resource 
    {
        private static Request BuildFetchRequest(FetchEventOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Events/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static EventResource Fetch(FetchEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<EventResource> FetchAsync(FetchEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static EventResource Fetch(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchEventOptions(workspaceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<EventResource> FetchAsync(string workspaceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchEventOptions(workspaceSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadEventOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Events",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<EventResource> Read(ReadEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<EventResource>.FromJson("events", response.Content);
            return new ResourceSet<EventResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(ReadEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<EventResource>.FromJson("events", response.Content);
            return new ResourceSet<EventResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<EventResource> Read(string workspaceSid, DateTime? endDate = null, string eventType = null, int? minutes = null, string reservationSid = null, DateTime? startDate = null, string taskQueueSid = null, string taskSid = null, string workerSid = null, string workflowSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions(workspaceSid){EndDate = endDate, EventType = eventType, Minutes = minutes, ReservationSid = reservationSid, StartDate = startDate, TaskQueueSid = taskQueueSid, TaskSid = taskSid, WorkerSid = workerSid, WorkflowSid = workflowSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(string workspaceSid, DateTime? endDate = null, string eventType = null, int? minutes = null, string reservationSid = null, DateTime? startDate = null, string taskQueueSid = null, string taskSid = null, string workerSid = null, string workflowSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions(workspaceSid){EndDate = endDate, EventType = eventType, Minutes = minutes, ReservationSid = reservationSid, StartDate = startDate, TaskQueueSid = taskQueueSid, TaskSid = taskSid, WorkerSid = workerSid, WorkflowSid = workflowSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a EventResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EventResource object represented by the provided JSON </returns> 
        public static EventResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<EventResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("actor_sid")]
        public string ActorSid { get; private set; }
        [JsonProperty("actor_type")]
        public string ActorType { get; private set; }
        [JsonProperty("actor_url")]
        public Uri ActorUrl { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("event_data")]
        public Dictionary<string, string> EventData { get; private set; }
        [JsonProperty("event_date")]
        public DateTime? EventDate { get; private set; }
        [JsonProperty("event_type")]
        public string EventType { get; private set; }
        [JsonProperty("resource_sid")]
        public string ResourceSid { get; private set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; private set; }
        [JsonProperty("resource_url")]
        public Uri ResourceUrl { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("source")]
        public string Source { get; private set; }
        [JsonProperty("source_ip_address")]
        public string SourceIpAddress { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private EventResource()
        {
        
        }
    }

}