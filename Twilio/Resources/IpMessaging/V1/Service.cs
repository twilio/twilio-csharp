using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Ipmessaging.V1;
using Twilio.Deleters.Ipmessaging.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1;
using com.fasterxml.jackson.databind.JsonNode;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1 {

    public class Service : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return ServiceFetcher capable of executing the fetch
         */
        public static ServiceFetcher fetch(String sid) {
            return new ServiceFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return ServiceDeleter capable of executing the delete
         */
        public static ServiceDeleter delete(String sid) {
            return new ServiceDeleter(sid);
        }
    
        /**
         * create
         * 
         * @param friendlyName The friendly_name
         * @return ServiceCreator capable of executing the create
         */
        public static ServiceCreator create(String friendlyName) {
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
        public static ServiceUpdater update(String sid) {
            return new ServiceUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a Service object
         * 
         * @param json Raw JSON string
         * @return Service object represented by the provided JSON
         */
        public static Service fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Service>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("default_service_role_sid")]
        private readonly String defaultServiceRoleSid;
        [JsonProperty("default_channel_role_sid")]
        private readonly String defaultChannelRoleSid;
        [JsonProperty("default_channel_creator_role_sid")]
        private readonly String defaultChannelCreatorRoleSid;
        [JsonProperty("read_status_enabled")]
        private readonly Boolean readStatusEnabled;
        [JsonProperty("typing_indicator_timeout")]
        private readonly Integer typingIndicatorTimeout;
        [JsonProperty("consumption_report_interval")]
        private readonly Integer consumptionReportInterval;
        [JsonProperty("webhooks")]
        private readonly JsonNode webhooks;
        [JsonProperty("url")]
        private readonly URI url;
        [JsonProperty("links")]
        private readonly Map<String, String> links;
    
        private Service([JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("friendly_name")]
                        String friendlyName, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("default_service_role_sid")]
                        String defaultServiceRoleSid, 
                        [JsonProperty("default_channel_role_sid")]
                        String defaultChannelRoleSid, 
                        [JsonProperty("default_channel_creator_role_sid")]
                        String defaultChannelCreatorRoleSid, 
                        [JsonProperty("read_status_enabled")]
                        Boolean readStatusEnabled, 
                        [JsonProperty("typing_indicator_timeout")]
                        Integer typingIndicatorTimeout, 
                        [JsonProperty("consumption_report_interval")]
                        Integer consumptionReportInterval, 
                        [JsonProperty("webhooks")]
                        JsonNode webhooks, 
                        [JsonProperty("url")]
                        URI url, 
                        [JsonProperty("links")]
                        Map<String, String> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
         * @return The friendly_name
         */
        public String GetFriendlyName() {
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
        public String GetDefaultServiceRoleSid() {
            return this.defaultServiceRoleSid;
        }
    
        /**
         * @return The default_channel_role_sid
         */
        public String GetDefaultChannelRoleSid() {
            return this.defaultChannelRoleSid;
        }
    
        /**
         * @return The default_channel_creator_role_sid
         */
        public String GetDefaultChannelCreatorRoleSid() {
            return this.defaultChannelCreatorRoleSid;
        }
    
        /**
         * @return The read_status_enabled
         */
        public Boolean GetReadStatusEnabled() {
            return this.readStatusEnabled;
        }
    
        /**
         * @return The typing_indicator_timeout
         */
        public Integer GetTypingIndicatorTimeout() {
            return this.typingIndicatorTimeout;
        }
    
        /**
         * @return The consumption_report_interval
         */
        public Integer GetConsumptionReportInterval() {
            return this.consumptionReportInterval;
        }
    
        /**
         * @return The webhooks
         */
        public JsonNode GetWebhooks() {
            return this.webhooks;
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