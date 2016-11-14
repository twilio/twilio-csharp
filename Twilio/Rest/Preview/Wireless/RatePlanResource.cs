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
        public string Sid { get; set; }
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("data_metering")]
        public string DataMetering { get; set; }
        [JsonProperty("capabilities")]
        public Object Capabilities { get; set; }
        [JsonProperty("voice_cap")]
        public int? VoiceCap { get; set; }
        [JsonProperty("messaging_cap")]
        public int? MessagingCap { get; set; }
        [JsonProperty("commands_cap")]
        public int? CommandsCap { get; set; }
        [JsonProperty("data_cap")]
        public int? DataCap { get; set; }
        [JsonProperty("cap_period")]
        public int? CapPeriod { get; set; }
        [JsonProperty("cap_unit")]
        public string CapUnit { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
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
            Sid = sid;
            Alias = alias;
            AccountSid = accountSid;
            FriendlyName = friendlyName;
            DataMetering = dataMetering;
            Capabilities = capabilities;
            VoiceCap = voiceCap;
            MessagingCap = messagingCap;
            CommandsCap = commandsCap;
            DataCap = dataCap;
            CapPeriod = capPeriod;
            CapUnit = capUnit;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}