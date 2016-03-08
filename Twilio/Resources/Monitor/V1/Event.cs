using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Monitor.V1;
using Twilio.Http;
using Twilio.Readers.Monitor.V1;
using Twilio.Resources;
using com.fasterxml.jackson.databind.JsonNode;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Monitor.V1 {

    public class Event : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return EventFetcher capable of executing the fetch
         */
        public static EventFetcher fetch(String sid) {
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
         * Converts a JSON string into a Event object
         * 
         * @param json Raw JSON string
         * @return Event object represented by the provided JSON
         */
        public static Event fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Event>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("actor_sid")]
        private readonly String actorSid;
        [JsonProperty("actor_type")]
        private readonly String actorType;
        [JsonProperty("description")]
        private readonly String description;
        [JsonProperty("event_data")]
        private readonly JsonNode eventData;
        [JsonProperty("event_date")]
        private readonly DateTime eventDate;
        [JsonProperty("event_type")]
        private readonly String eventType;
        [JsonProperty("resource_sid")]
        private readonly String resourceSid;
        [JsonProperty("resource_type")]
        private readonly String resourceType;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("source")]
        private readonly String source;
        [JsonProperty("source_ip_address")]
        private readonly String sourceIpAddress;
    
        private Event([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("actor_sid")]
                      String actorSid, 
                      [JsonProperty("actor_type")]
                      String actorType, 
                      [JsonProperty("description")]
                      String description, 
                      [JsonProperty("event_data")]
                      JsonNode eventData, 
                      [JsonProperty("event_date")]
                      String eventDate, 
                      [JsonProperty("event_type")]
                      String eventType, 
                      [JsonProperty("resource_sid")]
                      String resourceSid, 
                      [JsonProperty("resource_type")]
                      String resourceType, 
                      [JsonProperty("sid")]
                      String sid, 
                      [JsonProperty("source")]
                      String source, 
                      [JsonProperty("source_ip_address")]
                      String sourceIpAddress) {
            this.accountSid = accountSid;
            this.actorSid = actorSid;
            this.actorType = actorType;
            this.description = description;
            this.eventData = eventData;
            this.eventDate = MarshalConverter.dateTimeFromString(eventDate);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The actor_sid
         */
        public String GetActorSid() {
            return this.actorSid;
        }
    
        /**
         * @return The actor_type
         */
        public String GetActorType() {
            return this.actorType;
        }
    
        /**
         * @return The description
         */
        public String GetDescription() {
            return this.description;
        }
    
        /**
         * @return The event_data
         */
        public JsonNode GetEventData() {
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
        public String GetEventType() {
            return this.eventType;
        }
    
        /**
         * @return The resource_sid
         */
        public String GetResourceSid() {
            return this.resourceSid;
        }
    
        /**
         * @return The resource_type
         */
        public String GetResourceType() {
            return this.resourceType;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The source
         */
        public String GetSource() {
            return this.source;
        }
    
        /**
         * @return The source_ip_address
         */
        public String GetSourceIpAddress() {
            return this.sourceIpAddress;
        }
    }
}