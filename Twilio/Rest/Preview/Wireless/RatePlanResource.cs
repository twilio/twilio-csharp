using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless {

    public class RatePlanResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> RatePlanReader capable of executing the read </returns> 
        public static RatePlanReader Reader() {
            return new RatePlanReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> RatePlanFetcher capable of executing the fetch </returns> 
        public static RatePlanFetcher Fetcher(string sid) {
            return new RatePlanFetcher(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a RatePlanResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RatePlanResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The alias </returns> 
        public string GetAlias() {
            return this.alias;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The data_metering </returns> 
        public string GetDataMetering() {
            return this.dataMetering;
        }
    
        /// <returns> The capabilities </returns> 
        public Object GetCapabilities() {
            return this.capabilities;
        }
    
        /// <returns> The voice_cap </returns> 
        public int? GetVoiceCap() {
            return this.voiceCap;
        }
    
        /// <returns> The messaging_cap </returns> 
        public int? GetMessagingCap() {
            return this.messagingCap;
        }
    
        /// <returns> The commands_cap </returns> 
        public int? GetCommandsCap() {
            return this.commandsCap;
        }
    
        /// <returns> The data_cap </returns> 
        public int? GetDataCap() {
            return this.dataCap;
        }
    
        /// <returns> The cap_period </returns> 
        public int? GetCapPeriod() {
            return this.capPeriod;
        }
    
        /// <returns> The cap_unit </returns> 
        public string GetCapUnit() {
            return this.capUnit;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}