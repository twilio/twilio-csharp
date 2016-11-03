using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class RatePlanResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> RatePlanReader capable of executing the read </returns> 
        public static RatePlanReader Reader()
        {
            return new RatePlanReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> RatePlanFetcher capable of executing the fetch </returns> 
        public static RatePlanFetcher Fetcher(string sid)
        {
            return new RatePlanFetcher(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a RatePlanResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RatePlanResource object represented by the provided JSON </returns> 
        public static RatePlanResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RatePlanResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("alias")]
        public string alias { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("data_metering")]
        public string dataMetering { get; set; }
        [JsonProperty("capabilities")]
        public Object capabilities { get; set; }
        [JsonProperty("voice_cap")]
        public int? voiceCap { get; set; }
        [JsonProperty("messaging_cap")]
        public int? messagingCap { get; set; }
        [JsonProperty("commands_cap")]
        public int? commandsCap { get; set; }
        [JsonProperty("data_cap")]
        public int? dataCap { get; set; }
        [JsonProperty("cap_period")]
        public int? capPeriod { get; set; }
        [JsonProperty("cap_unit")]
        public string capUnit { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public RatePlanResource()
        {
        
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
                                 Uri url)
                                 {
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
    }
}