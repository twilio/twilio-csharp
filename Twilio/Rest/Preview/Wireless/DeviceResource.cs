using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless {

    public class DeviceResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DeviceFetcher capable of executing the fetch </returns> 
        public static DeviceFetcher Fetcher(string sid) {
            return new DeviceFetcher(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> DeviceReader capable of executing the read </returns> 
        public static DeviceReader Reader() {
            return new DeviceReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <returns> DeviceCreator capable of executing the create </returns> 
        public static DeviceCreator Creator(string ratePlan) {
            return new DeviceCreator(ratePlan);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DeviceUpdater capable of executing the update </returns> 
        public static DeviceUpdater Updater(string sid) {
            return new DeviceUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a DeviceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeviceResource object represented by the provided JSON </returns> 
        public static DeviceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<DeviceResource>(json);
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
        [JsonProperty("rate_plan_sid")]
        private readonly string ratePlanSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sim_identifier")]
        private readonly string simIdentifier;
        [JsonProperty("status")]
        private readonly string status;
        [JsonProperty("commands_callback_url")]
        private readonly Uri commandsCallbackUrl;
        [JsonProperty("commands_callback_method")]
        private readonly string commandsCallbackMethod;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        public DeviceResource() {
        
        }
    
        private DeviceResource([JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("alias")]
                               string alias, 
                               [JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("rate_plan_sid")]
                               string ratePlanSid, 
                               [JsonProperty("friendly_name")]
                               string friendlyName, 
                               [JsonProperty("sim_identifier")]
                               string simIdentifier, 
                               [JsonProperty("status")]
                               string status, 
                               [JsonProperty("commands_callback_url")]
                               Uri commandsCallbackUrl, 
                               [JsonProperty("commands_callback_method")]
                               string commandsCallbackMethod, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("url")]
                               Uri url, 
                               [JsonProperty("links")]
                               Dictionary<string, string> links) {
            this.sid = sid;
            this.alias = alias;
            this.accountSid = accountSid;
            this.ratePlanSid = ratePlanSid;
            this.friendlyName = friendlyName;
            this.simIdentifier = simIdentifier;
            this.status = status;
            this.commandsCallbackUrl = commandsCallbackUrl;
            this.commandsCallbackMethod = commandsCallbackMethod;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
            this.links = links;
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
    
        /// <returns> The rate_plan_sid </returns> 
        public string GetRatePlanSid() {
            return this.ratePlanSid;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The sim_identifier </returns> 
        public string GetSimIdentifier() {
            return this.simIdentifier;
        }
    
        /// <returns> The status </returns> 
        public string GetStatus() {
            return this.status;
        }
    
        /// <returns> The commands_callback_url </returns> 
        public Uri GetCommandsCallbackUrl() {
            return this.commandsCallbackUrl;
        }
    
        /// <returns> The commands_callback_method </returns> 
        public string GetCommandsCallbackMethod() {
            return this.commandsCallbackMethod;
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
    
        /// <returns> The links </returns> 
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}