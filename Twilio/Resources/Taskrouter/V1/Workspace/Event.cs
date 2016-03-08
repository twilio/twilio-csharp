using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Taskrouter.V1.Workspace {

    public class Event : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return EventFetcher capable of executing the fetch
         */
        public static EventFetcher fetch(String workspaceSid, String sid) {
            return new EventFetcher(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return EventReader capable of executing the read
         */
        public static EventReader read(String workspaceSid) {
            return new EventReader(workspaceSid);
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
        [JsonProperty("actor_url")]
        private readonly URI actorUrl;
        [JsonProperty("description")]
        private readonly String description;
        [JsonProperty("event_data")]
        private readonly Map<String, String> eventData;
        [JsonProperty("event_date")]
        private readonly DateTime eventDate;
        [JsonProperty("event_type")]
        private readonly String eventType;
        [JsonProperty("resource_sid")]
        private readonly String resourceSid;
        [JsonProperty("resource_type")]
        private readonly String resourceType;
        [JsonProperty("resource_url")]
        private readonly URI resourceUrl;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("source")]
        private readonly String source;
        [JsonProperty("source_ip_address")]
        private readonly String sourceIpAddress;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Event([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("actor_sid")]
                      String actorSid, 
                      [JsonProperty("actor_type")]
                      String actorType, 
                      [JsonProperty("actor_url")]
                      URI actorUrl, 
                      [JsonProperty("description")]
                      String description, 
                      [JsonProperty("event_data")]
                      Map<String, String> eventData, 
                      [JsonProperty("event_date")]
                      String eventDate, 
                      [JsonProperty("event_type")]
                      String eventType, 
                      [JsonProperty("resource_sid")]
                      String resourceSid, 
                      [JsonProperty("resource_type")]
                      String resourceType, 
                      [JsonProperty("resource_url")]
                      URI resourceUrl, 
                      [JsonProperty("sid")]
                      String sid, 
                      [JsonProperty("source")]
                      String source, 
                      [JsonProperty("source_ip_address")]
                      String sourceIpAddress, 
                      [JsonProperty("url")]
                      URI url) {
            this.accountSid = accountSid;
            this.actorSid = actorSid;
            this.actorType = actorType;
            this.actorUrl = actorUrl;
            this.description = description;
            this.eventData = eventData;
            this.eventDate = MarshalConverter.dateTimeFromString(eventDate);
            this.eventType = eventType;
            this.resourceSid = resourceSid;
            this.resourceType = resourceType;
            this.resourceUrl = resourceUrl;
            this.sid = sid;
            this.source = source;
            this.sourceIpAddress = sourceIpAddress;
            this.url = url;
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
         * @return The actor_url
         */
        public URI GetActorUrl() {
            return this.actorUrl;
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
        public Map<String, String> GetEventData() {
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
         * @return The resource_url
         */
        public URI GetResourceUrl() {
            return this.resourceUrl;
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
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}