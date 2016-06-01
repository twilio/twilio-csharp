using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Preview.Wireless;
using Twilio.Exceptions;
using Twilio.Fetchers.Preview.Wireless;
using Twilio.Http;
using Twilio.Readers.Preview.Wireless;
using Twilio.Resources;
using Twilio.Updaters.Preview.Wireless;

namespace Twilio.Resources.Preview.Wireless {

    public class DeviceResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return DeviceFetcher capable of executing the fetch
         */
        public static DeviceFetcher Fetch(string sid) {
            return new DeviceFetcher(sid);
        }
    
        /**
         * read
         * 
         * @return DeviceReader capable of executing the read
         */
        public static DeviceReader Read() {
            return new DeviceReader();
        }
    
        /**
         * create
         * 
         * @param ratePlan The rate_plan
         * @return DeviceCreator capable of executing the create
         */
        public static DeviceCreator Create(string ratePlan) {
            return new DeviceCreator(ratePlan);
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return DeviceUpdater capable of executing the update
         */
        public static DeviceUpdater Update(string sid) {
            return new DeviceUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a DeviceResource object
         * 
         * @param json Raw JSON string
         * @return DeviceResource object represented by the provided JSON
         */
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
         * @return The rate_plan_sid
         */
        public string GetRatePlanSid() {
            return this.ratePlanSid;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sim_identifier
         */
        public string GetSimIdentifier() {
            return this.simIdentifier;
        }
    
        /**
         * @return The status
         */
        public string GetStatus() {
            return this.status;
        }
    
        /**
         * @return The commands_callback_url
         */
        public Uri GetCommandsCallbackUrl() {
            return this.commandsCallbackUrl;
        }
    
        /**
         * @return The commands_callback_method
         */
        public string GetCommandsCallbackMethod() {
            return this.commandsCallbackMethod;
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
    
        /**
         * @return The links
         */
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}