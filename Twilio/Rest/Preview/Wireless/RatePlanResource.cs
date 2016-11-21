using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

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
        /// create
        /// </summary>
        ///
        /// <returns> RatePlanCreator capable of executing the create </returns> 
        public static RatePlanCreator Creator()
        {
            return new RatePlanCreator();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> RatePlanUpdater capable of executing the update </returns> 
        public static RatePlanUpdater Updater(string sid)
        {
            return new RatePlanUpdater(sid);
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
        [JsonProperty("roaming")]
        public List<string> Roaming { get; set; }
        [JsonProperty("data")]
        public Object Data { get; set; }
        [JsonProperty("commands")]
        public Object Commands { get; set; }
        [JsonProperty("renewal")]
        public Object Renewal { get; set; }
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
                                 [JsonProperty("roaming")]
                                 List<string> roaming, 
                                 [JsonProperty("data")]
                                 Object data, 
                                 [JsonProperty("commands")]
                                 Object commands, 
                                 [JsonProperty("renewal")]
                                 Object renewal, 
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
            Roaming = roaming;
            Data = data;
            Commands = commands;
            Renewal = renewal;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}