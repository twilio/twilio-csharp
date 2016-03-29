using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Monitor.V1;
using Twilio.Http;
using Twilio.Readers.Monitor.V1;
using Twilio.Resources;

namespace Twilio.Resources.Monitor.V1 {

    public class EventResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return EventFetcher capable of executing the fetch
         */
        public static EventFetcher fetch(string sid) {
            return new EventFetcher(sid);
        }
    
        /**
         * read
         * 
         * @return EventReader capable of executing the read
         */
        public static EventReader read() {
            return new EventReader();
        }
    
        /**
         * Converts a JSON string into a EventResource object
         * 
         * @param json Raw JSON string
         * @return EventResource object represented by the provided JSON
         */
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
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("event_data")]
        private readonly Object eventData;
        [JsonProperty("event_date")]
        private readonly DateTime eventDate;
        [JsonProperty("event_type")]
        private readonly string eventType;
        [JsonProperty("resource_sid")]
        private readonly string resourceSid;
        [JsonProperty("resource_type")]
        private readonly string resourceType;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("source")]
        private readonly string source;
        [JsonProperty("source_ip_address")]
        private readonly string sourceIpAddress;
    
        private EventResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("actor_sid")]
                              string actorSid, 
                              [JsonProperty("actor_type")]
                              string actorType, 
                              [JsonProperty("description")]
                              string description, 
                              [JsonProperty("event_data")]
                              Object eventData, 
                              [JsonProperty("event_date")]
                              string eventDate, 
                              [JsonProperty("event_type")]
                              string eventType, 
                              [JsonProperty("resource_sid")]
                              string resourceSid, 
                              [JsonProperty("resource_type")]
                              string resourceType, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("source")]
                              string source, 
                              [JsonProperty("source_ip_address")]
                              string sourceIpAddress) {
            this.accountSid = accountSid;
            this.actorSid = actorSid;
            this.actorType = actorType;
            this.description = description;
            this.eventData = eventData;
            this.eventDate = MarshalConverter.DateTimeFromString(eventDate);
            this.eventType = eventType;
            this.resourceSid = resourceSid;
            this.resourceType = resourceType;
            this.sid = sid;
            this.source = source;
            this.sourceIpAddress = sourceIpAddress;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The actor_sid
         */
        public string GetActorSid() {
            return this.actorSid;
        }
    
        /**
         * @return The actor_type
         */
        public string GetActorType() {
            return this.actorType;
        }
    
        /**
         * @return The description
         */
        public string GetDescription() {
            return this.description;
        }
    
        /**
         * @return The event_data
         */
        public Object GetEventData() {
            return this.eventData;
        }
    
        /**
         * @return The event_date
         */
        public DateTime GetEventDate() {
            return this.eventDate;
        }
    
        /**
         * @return The event_type
         */
        public string GetEventType() {
            return this.eventType;
        }
    
        /**
         * @return The resource_sid
         */
        public string GetResourceSid() {
            return this.resourceSid;
        }
    
        /**
         * @return The resource_type
         */
        public string GetResourceType() {
            return this.resourceType;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The source
         */
        public string GetSource() {
            return this.source;
        }
    
        /**
         * @return The source_ip_address
         */
        public string GetSourceIpAddress() {
            return this.sourceIpAddress;
        }
    }
}