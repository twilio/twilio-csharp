using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless.Device 
{

    public class UsageResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="deviceSid"> The device_sid </param>
        /// <returns> UsageFetcher capable of executing the fetch </returns> 
        public static UsageFetcher Fetcher(string deviceSid)
        {
            return new UsageFetcher(deviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a UsageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UsageResource object represented by the provided JSON </returns> 
        public static UsageResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<UsageResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("device_sid")]
        public string DeviceSid { get; set; }
        [JsonProperty("device_alias")]
        public string DeviceAlias { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("period")]
        public Object Period { get; set; }
        [JsonProperty("commands_usage")]
        public Object CommandsUsage { get; set; }
        [JsonProperty("commands_costs")]
        public Object CommandsCosts { get; set; }
        [JsonProperty("data_usage")]
        public Object DataUsage { get; set; }
        [JsonProperty("data_costs")]
        public Object DataCosts { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public UsageResource()
        {
        
        }
    
        private UsageResource([JsonProperty("device_sid")]
                              string deviceSid, 
                              [JsonProperty("device_alias")]
                              string deviceAlias, 
                              [JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("period")]
                              Object period, 
                              [JsonProperty("commands_usage")]
                              Object commandsUsage, 
                              [JsonProperty("commands_costs")]
                              Object commandsCosts, 
                              [JsonProperty("data_usage")]
                              Object dataUsage, 
                              [JsonProperty("data_costs")]
                              Object dataCosts, 
                              [JsonProperty("url")]
                              Uri url)
                              {
            DeviceSid = deviceSid;
            DeviceAlias = deviceAlias;
            AccountSid = accountSid;
            Period = period;
            CommandsUsage = commandsUsage;
            CommandsCosts = commandsCosts;
            DataUsage = dataUsage;
            DataCosts = dataCosts;
            Url = url;
        }
    }
}