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
        /// <returns> UsageFetcher capable of executing the fetch </returns> 
        public static UsageFetcher Fetcher(string deviceSid) {
            return new UsageFetcher(deviceSid);
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
        private readonly string deviceSid;
        [JsonProperty("device_alias")]
        private readonly string deviceAlias;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("period")]
        private readonly Object period;
        [JsonProperty("commands_usage")]
        private readonly Object commandsUsage;
        [JsonProperty("commands_costs")]
        private readonly Object commandsCosts;
        [JsonProperty("data_usage")]
        private readonly Object dataUsage;
        [JsonProperty("data_costs")]
        private readonly Object dataCosts;
        [JsonProperty("url")]
        private readonly Uri url;
    
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
    
        /// <returns> The device_sid </returns> 
        public string GetDeviceSid() {
            return this.deviceSid;
        }
    
        /// <returns> The device_alias </returns> 
        public string GetDeviceAlias() {
            return this.deviceAlias;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The period </returns> 
        public Object GetPeriod() {
            return this.period;
        }
    
        /// <returns> The commands_usage </returns> 
        public Object GetCommandsUsage() {
            return this.commandsUsage;
        }
    
        /// <returns> The commands_costs </returns> 
        public Object GetCommandsCosts() {
            return this.commandsCosts;
        }
    
        /// <returns> The data_usage </returns> 
        public Object GetDataUsage() {
            return this.dataUsage;
        }
    
        /// <returns> The data_costs </returns> 
        public Object GetDataCosts() {
            return this.dataCosts;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}