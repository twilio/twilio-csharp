using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Ipmessaging.V1.Service;
using Twilio.Deleters.Ipmessaging.V1.Service;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1.Service;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1.Service;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1.Service;
using com.fasterxml.jackson.databind.JsonNode;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1.Service {

    public class Channel : SidResource {
        public enum ChannelType {
            PUBLIC="public",
            PRIVATE="private"
        };
    
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return ChannelFetcher capable of executing the fetch
         */
        public static ChannelFetcher fetch(String serviceSid, String sid) {
            return new ChannelFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return ChannelDeleter capable of executing the delete
         */
        public static ChannelDeleter delete(String serviceSid, String sid) {
            return new ChannelDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param friendlyName The friendly_name
         * @param uniqueName The unique_name
         * @return ChannelCreator capable of executing the create
         */
        public static ChannelCreator create(String serviceSid, String friendlyName, String uniqueName) {
            return new ChannelCreator(serviceSid, friendlyName, uniqueName);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return ChannelReader capable of executing the read
         */
        public static ChannelReader read(String serviceSid) {
            return new ChannelReader(serviceSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return ChannelUpdater capable of executing the update
         */
        public static ChannelUpdater update(String serviceSid, String sid) {
            return new ChannelUpdater(serviceSid, sid);
        }
    
        /**
         * Converts a JSON string into a Channel object
         * 
         * @param json Raw JSON string
         * @return Channel object represented by the provided JSON
         */
        public static Channel fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Channel>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("service_sid")]
        private readonly String serviceSid;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("unique_name")]
        private readonly String uniqueName;
        [JsonProperty("attributes")]
        private readonly JsonNode attributes;
        [JsonProperty("type")]
        private readonly Channel.ChannelType type;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("created_by")]
        private readonly String createdBy;
        [JsonProperty("url")]
        private readonly URI url;
        [JsonProperty("links")]
        private readonly Map<String, String> links;
    
        private Channel([JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("service_sid")]
                        String serviceSid, 
                        [JsonProperty("friendly_name")]
                        String friendlyName, 
                        [JsonProperty("unique_name")]
                        String uniqueName, 
                        [JsonProperty("attributes")]
                        JsonNode attributes, 
                        [JsonProperty("type")]
                        Channel.ChannelType type, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("created_by")]
                        String createdBy, 
                        [JsonProperty("url")]
                        URI url, 
                        [JsonProperty("links")]
                        Map<String, String> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.uniqueName = uniqueName;
            this.attributes = attributes;
            this.type = type;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
            this.url = url;
            this.links = links;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The service_sid
         */
        public String GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The unique_name
         */
        public String GetUniqueName() {
            return this.uniqueName;
        }
    
        /**
         * @return The attributes
         */
        public JsonNode GetAttributes() {
            return this.attributes;
        }
    
        /**
         * @return The type
         */
        public Channel.ChannelType GetType() {
            return this.type;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The created_by
         */
        public String GetCreatedBy() {
            return this.createdBy;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    
        /**
         * @return The links
         */
        public Map<String, String> GetLinks() {
            return this.links;
        }
    }
}