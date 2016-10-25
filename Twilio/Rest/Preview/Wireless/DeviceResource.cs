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
        /// <param name="status"> The status </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="ratePlan"> The rate_plan </param>
        /// <returns> DeviceReader capable of executing the read </returns> 
        public static DeviceReader Reader(string status=null, string simIdentifier=null, string ratePlan=null)
        {
            return new DeviceReader(status:status, simIdentifier:simIdentifier, ratePlan:ratePlan);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="alias"> The alias </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="status"> The status </param>
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <returns> DeviceCreator capable of executing the create </returns> 
        public static DeviceCreator Creator(string ratePlan, string alias=null, string callbackMethod=null, Uri callbackUrl=null, string friendlyName=null, string simIdentifier=null, string status=null, string commandsCallbackMethod=null, Uri commandsCallbackUrl=null)
        {
            return new DeviceCreator(ratePlan, alias:alias, callbackMethod:callbackMethod, callbackUrl:callbackUrl, friendlyName:friendlyName, simIdentifier:simIdentifier, status:status, commandsCallbackMethod:commandsCallbackMethod, commandsCallbackUrl:commandsCallbackUrl);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="alias"> The alias </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="status"> The status </param>
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <returns> DeviceUpdater capable of executing the update </returns> 
        public static DeviceUpdater Updater(string sid, string alias=null, string callbackMethod=null, Uri callbackUrl=null, string friendlyName=null, string ratePlan=null, string simIdentifier=null, string status=null, string commandsCallbackMethod=null, Uri commandsCallbackUrl=null)
        {
            return new DeviceUpdater(sid, alias:alias, callbackMethod:callbackMethod, callbackUrl:callbackUrl, friendlyName:friendlyName, ratePlan:ratePlan, simIdentifier:simIdentifier, status:status, commandsCallbackMethod:commandsCallbackMethod, commandsCallbackUrl:commandsCallbackUrl);
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
        public string sid { get; }
        [JsonProperty("alias")]
        public string alias { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("rate_plan_sid")]
        public string ratePlanSid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sim_identifier")]
        public string simIdentifier { get; }
        [JsonProperty("status")]
        public string status { get; }
        [JsonProperty("commands_callback_url")]
        public Uri commandsCallbackUrl { get; }
        [JsonProperty("commands_callback_method")]
        public string commandsCallbackMethod { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("url")]
        public Uri url { get; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; }
    
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