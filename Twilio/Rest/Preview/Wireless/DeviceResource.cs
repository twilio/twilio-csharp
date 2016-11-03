using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class DeviceResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DeviceFetcher capable of executing the fetch </returns> 
        public static DeviceFetcher Fetcher(string sid)
        {
            return new DeviceFetcher(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> DeviceReader capable of executing the read </returns> 
        public static DeviceReader Reader()
        {
            return new DeviceReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <returns> DeviceCreator capable of executing the create </returns> 
        public static DeviceCreator Creator(string ratePlan)
        {
            return new DeviceCreator(ratePlan);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DeviceUpdater capable of executing the update </returns> 
        public static DeviceUpdater Updater(string sid)
        {
            return new DeviceUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a DeviceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeviceResource object represented by the provided JSON </returns> 
        public static DeviceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DeviceResource>(json);
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
        [JsonProperty("rate_plan_sid")]
        public string ratePlanSid { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("sim_identifier")]
        public string simIdentifier { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("commands_callback_url")]
        public Uri commandsCallbackUrl { get; set; }
        [JsonProperty("commands_callback_method")]
        public string commandsCallbackMethod { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; set; }
    
        public DeviceResource()
        {
        
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
                               Dictionary<string, string> links)
                               {
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
    }
}