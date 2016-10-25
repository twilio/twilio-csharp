using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless.Device {

    public class UsageResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="deviceSid"> The device_sid </param>
        /// <param name="end"> The end </param>
        /// <param name="start"> The start </param>
        /// <returns> UsageFetcher capable of executing the fetch </returns> 
        public static UsageFetcher Fetcher(string deviceSid, string end=null, string start=null) {
            return new UsageFetcher(deviceSid, end:end, start:start);
        }
    
        /// <summary>
        /// Converts a JSON string into a UsageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UsageResource object represented by the provided JSON </returns> 
        public static UsageResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<UsageResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("device_sid")]
        public string deviceSid { get; }
        [JsonProperty("device_alias")]
        public string deviceAlias { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("period")]
        public Object period { get; }
        [JsonProperty("commands_usage")]
        public Object commandsUsage { get; }
        [JsonProperty("commands_costs")]
        public Object commandsCosts { get; }
        [JsonProperty("data_usage")]
        public Object dataUsage { get; }
        [JsonProperty("data_costs")]
        public Object dataCosts { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
        public UsageResource() {
        
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
                              Uri url) {
            this.deviceSid = deviceSid;
            this.deviceAlias = deviceAlias;
            this.accountSid = accountSid;
            this.period = period;
            this.commandsUsage = commandsUsage;
            this.commandsCosts = commandsCosts;
            this.dataUsage = dataUsage;
            this.dataCosts = dataCosts;
            this.url = url;
        }
    }
}