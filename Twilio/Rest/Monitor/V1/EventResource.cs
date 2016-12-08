using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Monitor.V1 
{

    public class EventResource : Resource 
    {
        private static Request BuildFetchRequest(FetchEventOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Monitor,
                "/v1/Events/" + options.Sid + "",
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
        public static EventResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchEventOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<EventResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchEventOptions(sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadEventOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Monitor,
                "/v1/Events",
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
        public static ResourceSet<EventResource> Read(string actorSid = null, string eventType = null, string resourceSid = null, string sourceIpAddress = null, DateTime? startDate = null, DateTime? endDate = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions{ActorSid = actorSid, EventType = eventType, ResourceSid = resourceSid, SourceIpAddress = sourceIpAddress, StartDate = startDate, EndDate = endDate, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(string actorSid = null, string eventType = null, string resourceSid = null, string sourceIpAddress = null, DateTime? startDate = null, DateTime? endDate = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions{ActorSid = actorSid, EventType = eventType, ResourceSid = resourceSid, SourceIpAddress = sourceIpAddress, StartDate = startDate, EndDate = endDate, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Monitor,
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
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("event_data")]
        public object EventData { get; private set; }
        [JsonProperty("event_date")]
        public DateTime? EventDate { get; private set; }
        [JsonProperty("event_type")]
        public string EventType { get; private set; }
        [JsonProperty("resource_sid")]
        public string ResourceSid { get; private set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("source")]
        public string Source { get; private set; }
        [JsonProperty("source_ip_address")]
        public string SourceIpAddress { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private EventResource()
        {
        
        }
    }

}