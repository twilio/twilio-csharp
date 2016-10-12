using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class EventResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> EventFetcher capable of executing the fetch </returns> 
        public static EventFetcher Fetcher(string workspaceSid, string sid) {
            return new EventFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> EventReader capable of executing the read </returns> 
        public static EventReader Reader(string workspaceSid) {
            return new EventReader(workspaceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a EventResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EventResource object represented by the provided JSON </returns> 
        public static EventResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<EventResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("actor_sid")]
        private readonly string actorSid;
        [JsonProperty("actor_type")]
        private readonly string actorType;
        [JsonProperty("actor_url")]
        private readonly Uri actorUrl;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("event_data")]
        private readonly Dictionary<string, string> eventData;
        [JsonProperty("event_date")]
        private readonly DateTime? eventDate;
        [JsonProperty("event_type")]
        private readonly string eventType;
        [JsonProperty("resource_sid")]
        private readonly string resourceSid;
        [JsonProperty("resource_type")]
        private readonly string resourceType;
        [JsonProperty("resource_url")]
        private readonly Uri resourceUrl;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("source")]
        private readonly string source;
        [JsonProperty("source_ip_address")]
        private readonly string sourceIpAddress;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public EventResource() {
        
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
                              Uri url) {
            this.accountSid = accountSid;
            this.actorSid = actorSid;
            this.actorType = actorType;
            this.actorUrl = actorUrl;
            this.description = description;
            this.eventData = eventData;
            this.eventDate = MarshalConverter.DateTimeFromString(eventDate);
            this.eventType = eventType;
            this.resourceSid = resourceSid;
            this.resourceType = resourceType;
            this.resourceUrl = resourceUrl;
            this.sid = sid;
            this.source = source;
            this.sourceIpAddress = sourceIpAddress;
            this.url = url;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The actor_sid </returns> 
        public string GetActorSid() {
            return this.actorSid;
        }
    
        /// <returns> The actor_type </returns> 
        public string GetActorType() {
            return this.actorType;
        }
    
        /// <returns> The actor_url </returns> 
        public Uri GetActorUrl() {
            return this.actorUrl;
        }
    
        /// <returns> The description </returns> 
        public string GetDescription() {
            return this.description;
        }
    
        /// <returns> The event_data </returns> 
        public Dictionary<string, string> GetEventData() {
            return this.eventData;
        }
    
        /// <returns> The event_date </returns> 
        public DateTime? GetEventDate() {
            return this.eventDate;
        }
    
        /// <returns> The event_type </returns> 
        public string GetEventType() {
            return this.eventType;
        }
    
        /// <returns> The resource_sid </returns> 
        public string GetResourceSid() {
            return this.resourceSid;
        }
    
        /// <returns> The resource_type </returns> 
        public string GetResourceType() {
            return this.resourceType;
        }
    
        /// <returns> The resource_url </returns> 
        public Uri GetResourceUrl() {
            return this.resourceUrl;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The source </returns> 
        public string GetSource() {
            return this.source;
        }
    
        /// <returns> The source_ip_address </returns> 
        public string GetSourceIpAddress() {
            return this.sourceIpAddress;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}