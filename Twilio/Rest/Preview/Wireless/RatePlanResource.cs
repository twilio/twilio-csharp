using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless {

    public class RatePlanResource : SidResource {
        /**
         * read
         * 
         * @return RatePlanReader capable of executing the read
         */
        public static RatePlanReader Read() {
            return new RatePlanReader();
        }
    
        /**
         * fetch
         * 
         * @param sid The sid
         * @return RatePlanFetcher capable of executing the fetch
         */
        public static RatePlanFetcher Fetch(string sid) {
            return new RatePlanFetcher(sid);
        }
    
        /**
         * Converts a JSON string into a RatePlanResource object
         * 
         * @param json Raw JSON string
         * @return RatePlanResource object represented by the provided JSON
         */
        public static RatePlanResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RatePlanResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("alias")]
        private readonly string alias;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("data_metering")]
        private readonly string dataMetering;
        [JsonProperty("capabilities")]
        private readonly Object capabilities;
        [JsonProperty("voice_cap")]
        private readonly int? voiceCap;
        [JsonProperty("messaging_cap")]
        private readonly int? messagingCap;
        [JsonProperty("commands_cap")]
        private readonly int? commandsCap;
        [JsonProperty("data_cap")]
        private readonly int? dataCap;
        [JsonProperty("cap_period")]
        private readonly int? capPeriod;
        [JsonProperty("cap_unit")]
        private readonly string capUnit;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public RatePlanResource() {
        
        }
    
        private RatePlanResource([JsonProperty("sid")]
                                 string sid, 
                                 [JsonProperty("alias")]
                                 string alias, 
                                 [JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("friendly_name")]
                                 string friendlyName, 
                                 [JsonProperty("data_metering")]
                                 string dataMetering, 
                                 [JsonProperty("capabilities")]
                                 Object capabilities, 
                                 [JsonProperty("voice_cap")]
                                 int? voiceCap, 
                                 [JsonProperty("messaging_cap")]
                                 int? messagingCap, 
                                 [JsonProperty("commands_cap")]
                                 int? commandsCap, 
                                 [JsonProperty("data_cap")]
                                 int? dataCap, 
                                 [JsonProperty("cap_period")]
                                 int? capPeriod, 
                                 [JsonProperty("cap_unit")]
                                 string capUnit, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("url")]
                                 Uri url) {
            this.sid = sid;
            this.alias = alias;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dataMetering = dataMetering;
            this.capabilities = capabilities;
            this.voiceCap = voiceCap;
            this.messagingCap = messagingCap;
            this.commandsCap = commandsCap;
            this.dataCap = dataCap;
            this.capPeriod = capPeriod;
            this.capUnit = capUnit;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The alias
         */
        public string GetAlias() {
            return this.alias;
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
         * @return The data_metering
         */
        public string GetDataMetering() {
            return this.dataMetering;
        }
    
        /**
         * @return The capabilities
         */
        public Object GetCapabilities() {
            return this.capabilities;
        }
    
        /**
         * @return The voice_cap
         */
        public int? GetVoiceCap() {
            return this.voiceCap;
        }
    
        /**
         * @return The messaging_cap
         */
        public int? GetMessagingCap() {
            return this.messagingCap;
        }
    
        /**
         * @return The commands_cap
         */
        public int? GetCommandsCap() {
            return this.commandsCap;
        }
    
        /**
         * @return The data_cap
         */
        public int? GetDataCap() {
            return this.dataCap;
        }
    
        /**
         * @return The cap_period
         */
        public int? GetCapPeriod() {
            return this.capPeriod;
        }
    
        /**
         * @return The cap_unit
         */
        public string GetCapUnit() {
            return this.capUnit;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}