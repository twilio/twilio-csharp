using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1 {

    public class ServiceResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceFetcher capable of executing the fetch </returns> 
        public static ServiceFetcher Fetcher(string sid) {
            return new ServiceFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceDeleter capable of executing the delete </returns> 
        public static ServiceDeleter Deleter(string sid) {
            return new ServiceDeleter(sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> ServiceCreator capable of executing the create </returns> 
        public static ServiceCreator Creator(string friendlyName) {
            return new ServiceCreator(friendlyName);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> ServiceReader capable of executing the read </returns> 
        public static ServiceReader Reader() {
            return new ServiceReader();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceUpdater capable of executing the update </returns> 
        public static ServiceUpdater Updater(string sid) {
            return new ServiceUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns> 
        public static ServiceResource FromJson(string json) {
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
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("default_service_role_sid")]
        private readonly string defaultServiceRoleSid;
        [JsonProperty("default_channel_role_sid")]
        private readonly string defaultChannelRoleSid;
        [JsonProperty("default_channel_creator_role_sid")]
        private readonly string defaultChannelCreatorRoleSid;
        [JsonProperty("read_status_enabled")]
        private readonly bool? readStatusEnabled;
        [JsonProperty("typing_indicator_timeout")]
        private readonly int? typingIndicatorTimeout;
        [JsonProperty("consumption_report_interval")]
        private readonly int? consumptionReportInterval;
        [JsonProperty("webhooks")]
        private readonly Object webhooks;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        public ServiceResource() {
        
        }
    
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
                                bool? readStatusEnabled, 
                                [JsonProperty("typing_indicator_timeout")]
                                int? typingIndicatorTimeout, 
                                [JsonProperty("consumption_report_interval")]
                                int? consumptionReportInterval, 
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
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The default_service_role_sid </returns> 
        public string GetDefaultServiceRoleSid() {
            return this.defaultServiceRoleSid;
        }
    
        /// <returns> The default_channel_role_sid </returns> 
        public string GetDefaultChannelRoleSid() {
            return this.defaultChannelRoleSid;
        }
    
        /// <returns> The default_channel_creator_role_sid </returns> 
        public string GetDefaultChannelCreatorRoleSid() {
            return this.defaultChannelCreatorRoleSid;
        }
    
        /// <returns> The read_status_enabled </returns> 
        public bool? GetReadStatusEnabled() {
            return this.readStatusEnabled;
        }
    
        /// <returns> The typing_indicator_timeout </returns> 
        public int? GetTypingIndicatorTimeout() {
            return this.typingIndicatorTimeout;
        }
    
        /// <returns> The consumption_report_interval </returns> 
        public int? GetConsumptionReportInterval() {
            return this.consumptionReportInterval;
        }
    
        /// <returns> The webhooks </returns> 
        public Object GetWebhooks() {
            return this.webhooks;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    
        /// <returns> The links </returns> 
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}