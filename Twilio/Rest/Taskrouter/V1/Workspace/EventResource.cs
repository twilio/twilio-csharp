using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class EventResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> EventFetcher capable of executing the fetch </returns> 
        public static EventFetcher Fetcher(string workspaceSid, string sid)
        {
            return new EventFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> EventReader capable of executing the read </returns> 
        public static EventReader Reader(string workspaceSid)
        {
            return new EventReader(workspaceSid);
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
        public string AccountSid { get; set; }
        [JsonProperty("actor_sid")]
        public string ActorSid { get; set; }
        [JsonProperty("actor_type")]
        public string ActorType { get; set; }
        [JsonProperty("actor_url")]
        public Uri ActorUrl { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("event_data")]
        public Dictionary<string, string> EventData { get; set; }
        [JsonProperty("event_date")]
        public DateTime? EventDate { get; set; }
        [JsonProperty("event_type")]
        public string EventType { get; set; }
        [JsonProperty("resource_sid")]
        public string ResourceSid { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_url")]
        public Uri ResourceUrl { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("source_ip_address")]
        public string SourceIpAddress { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public EventResource()
        {
        
        }
    
        private EventResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("actor_sid")]
                              string actorSid, 
                              [JsonProperty("actor_type")]
                              string actorType, 
                              [JsonProperty("actor_url")]
                              Uri actorUrl, 
                              [JsonProperty("description")]
                              string description, 
                              [JsonProperty("event_data")]
                              Dictionary<string, string> eventData, 
                              [JsonProperty("event_date")]
                              string eventDate, 
                              [JsonProperty("event_type")]
                              string eventType, 
                              [JsonProperty("resource_sid")]
                              string resourceSid, 
                              [JsonProperty("resource_type")]
                              string resourceType, 
                              [JsonProperty("resource_url")]
                              Uri resourceUrl, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("source")]
                              string source, 
                              [JsonProperty("source_ip_address")]
                              string sourceIpAddress, 
                              [JsonProperty("url")]
                              Uri url)
                              {
            AccountSid = accountSid;
            ActorSid = actorSid;
            ActorType = actorType;
            ActorUrl = actorUrl;
            Description = description;
            EventData = eventData;
            EventDate = MarshalConverter.DateTimeFromString(eventDate);
            EventType = eventType;
            ResourceSid = resourceSid;
            ResourceType = resourceType;
            ResourceUrl = resourceUrl;
            Sid = sid;
            Source = source;
            SourceIpAddress = sourceIpAddress;
            Url = url;
        }
    }
}