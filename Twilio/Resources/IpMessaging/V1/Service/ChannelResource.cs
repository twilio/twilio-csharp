using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Ipmessaging.V1.Service;
using Twilio.Deleters.Ipmessaging.V1.Service;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1.Service;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1.Service;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1.Service;

namespace Twilio.Resources.IpMessaging.V1.Service {

    public class ChannelResource : SidResource {
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
        public static ChannelFetcher fetch(string serviceSid, string sid) {
            return new ChannelFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return ChannelDeleter capable of executing the delete
         */
        public static ChannelDeleter delete(string serviceSid, string sid) {
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
        public static ChannelCreator create(string serviceSid, string friendlyName, string uniqueName) {
            return new ChannelCreator(serviceSid, friendlyName, uniqueName);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return ChannelReader capable of executing the read
         */
        public static ChannelReader read(string serviceSid) {
            return new ChannelReader(serviceSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return ChannelUpdater capable of executing the update
         */
        public static ChannelUpdater update(string serviceSid, string sid) {
            return new ChannelUpdater(serviceSid, sid);
        }
    
        /**
         * Converts a JSON string into a ChannelResource object
         * 
         * @param json Raw JSON string
         * @return ChannelResource object represented by the provided JSON
         */
        public static ChannelResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ChannelResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("unique_name")]
        private readonly string uniqueName;
        [JsonProperty("attributes")]
        private readonly Object attributes;
        [JsonProperty("type")]
        private readonly ChannelResource.ChannelType type;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("created_by")]
        private readonly string createdBy;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        private ChannelResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("unique_name")]
                                string uniqueName, 
                                [JsonProperty("attributes")]
                                Object attributes, 
                                [JsonProperty("type")]
                                ChannelResource.ChannelType type, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("created_by")]
                                string createdBy, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.uniqueName = uniqueName;
            this.attributes = attributes;
            this.type = type;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
            this.url = url;
            this.links = links;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The service_sid
         */
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The unique_name
         */
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /**
         * @return The attributes
         */
        public Object GetAttributes() {
            return this.attributes;
        }
    
        /**
         * @return The type
         */
        public ChannelResource.ChannelType GetChannelType() {
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
        public string GetCreatedBy() {
            return this.createdBy;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    
        /**
         * @return The links
         */
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}