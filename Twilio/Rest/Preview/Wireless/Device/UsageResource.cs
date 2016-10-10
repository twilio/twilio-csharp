using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless.Device {

    public class UsageResource : Resource {
        /**
         * fetch
         * 
         * @param deviceSid The device_sid
         * @return UsageFetcher capable of executing the fetch
         */
        public static UsageFetcher Fetcher(string deviceSid) {
            return new UsageFetcher(deviceSid);
        }
    
        /**
         * Converts a JSON string into a UsageResource object
         * 
         * @param json Raw JSON string
         * @return UsageResource object represented by the provided JSON
         */
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
    
        /**
         * @return The device_sid
         */
        public string GetDeviceSid() {
            return this.deviceSid;
        }
    
        /**
         * @return The device_alias
         */
        public string GetDeviceAlias() {
            return this.deviceAlias;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The period
         */
        public Object GetPeriod() {
            return this.period;
        }
    
        /**
         * @return The commands_usage
         */
        public Object GetCommandsUsage() {
            return this.commandsUsage;
        }
    
        /**
         * @return The commands_costs
         */
        public Object GetCommandsCosts() {
            return this.commandsCosts;
        }
    
        /**
         * @return The data_usage
         */
        public Object GetDataUsage() {
            return this.dataUsage;
        }
    
        /**
         * @return The data_costs
         */
        public Object GetDataCosts() {
            return this.dataCosts;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}