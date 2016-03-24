using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Ipmessaging.V1;
using Twilio.Deleters.Ipmessaging.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1;

namespace Twilio.Resources.IpMessaging.V1 {

    public class ServiceResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return ServiceFetcher capable of executing the fetch
         */
        public static ServiceFetcher fetch(string sid) {
            return new ServiceFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return ServiceDeleter capable of executing the delete
         */
        public static ServiceDeleter delete(string sid) {
            return new ServiceDeleter(sid);
        }
    
        /**
         * create
         * 
         * @param friendlyName The friendly_name
         * @return ServiceCreator capable of executing the create
         */
        public static ServiceCreator create(string friendlyName) {
            return new ServiceCreator(friendlyName);
        }
    
        /**
         * read
         * 
         * @return ServiceReader capable of executing the read
         */
        public static ServiceReader read() {
            return new ServiceReader();
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return ServiceUpdater capable of executing the update
         */
        public static ServiceUpdater update(string sid) {
            return new ServiceUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a ServiceResource object
         * 
         * @param json Raw JSON string
         * @return ServiceResource object represented by the provided JSON
         */
        public static ServiceResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("default_service_role_sid")]
        private readonly string defaultServiceRoleSid;
        [JsonProperty("default_channel_role_sid")]
        private readonly string defaultChannelRoleSid;
        [JsonProperty("default_channel_creator_role_sid")]
        private readonly string defaultChannelCreatorRoleSid;
        [JsonProperty("read_status_enabled")]
        private readonly bool readStatusEnabled;
        [JsonProperty("typing_indicator_timeout")]
        private readonly int typingIndicatorTimeout;
        [JsonProperty("consumption_report_interval")]
        private readonly int consumptionReportInterval;
        [JsonProperty("webhooks")]
        private readonly Object webhooks;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        private ServiceResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("default_service_role_sid")]
                                string defaultServiceRoleSid, 
                                [JsonProperty("default_channel_role_sid")]
                                string defaultChannelRoleSid, 
                                [JsonProperty("default_channel_creator_role_sid")]
                                string defaultChannelCreatorRoleSid, 
                                [JsonProperty("read_status_enabled")]
                                bool readStatusEnabled, 
                                [JsonProperty("typing_indicator_timeout")]
                                int typingIndicatorTimeout, 
                                [JsonProperty("consumption_report_interval")]
                                int consumptionReportInterval, 
                                [JsonProperty("webhooks")]
                                Object webhooks, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.defaultServiceRoleSid = defaultServiceRoleSid;
            this.defaultChannelRoleSid = defaultChannelRoleSid;
            this.defaultChannelCreatorRoleSid = defaultChannelCreatorRoleSid;
            this.readStatusEnabled = readStatusEnabled;
            this.typingIndicatorTimeout = typingIndicatorTimeout;
            this.consumptionReportInterval = consumptionReportInterval;
            this.webhooks = webhooks;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
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
         * @return The default_service_role_sid
         */
        public string GetDefaultServiceRoleSid() {
            return this.defaultServiceRoleSid;
        }
    
        /**
         * @return The default_channel_role_sid
         */
        public string GetDefaultChannelRoleSid() {
            return this.defaultChannelRoleSid;
        }
    
        /**
         * @return The default_channel_creator_role_sid
         */
        public string GetDefaultChannelCreatorRoleSid() {
            return this.defaultChannelCreatorRoleSid;
        }
    
        /**
         * @return The read_status_enabled
         */
        public bool GetReadStatusEnabled() {
            return this.readStatusEnabled;
        }
    
        /**
         * @return The typing_indicator_timeout
         */
        public int GetTypingIndicatorTimeout() {
            return this.typingIndicatorTimeout;
        }
    
        /**
         * @return The consumption_report_interval
         */
        public int GetConsumptionReportInterval() {
            return this.consumptionReportInterval;
        }
    
        /**
         * @return The webhooks
         */
        public Object GetWebhooks() {
            return this.webhooks;
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