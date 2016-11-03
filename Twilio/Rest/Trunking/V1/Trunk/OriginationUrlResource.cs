using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class OriginationUrlResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> OriginationUrlFetcher capable of executing the fetch </returns> 
        public static OriginationUrlFetcher Fetcher(string trunkSid, string sid)
        {
            return new OriginationUrlFetcher(trunkSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> OriginationUrlDeleter capable of executing the delete </returns> 
        public static OriginationUrlDeleter Deleter(string trunkSid, string sid)
        {
            return new OriginationUrlDeleter(trunkSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="weight"> The weight </param>
        /// <param name="priority"> The priority </param>
        /// <param name="enabled"> The enabled </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="sipUrl"> The sip_url </param>
        /// <returns> OriginationUrlCreator capable of executing the create </returns> 
        public static OriginationUrlCreator Creator(string trunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl)
        {
            return new OriginationUrlCreator(trunkSid, weight, priority, enabled, friendlyName, sipUrl);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <returns> OriginationUrlReader capable of executing the read </returns> 
        public static OriginationUrlReader Reader(string trunkSid)
        {
            return new OriginationUrlReader(trunkSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> OriginationUrlUpdater capable of executing the update </returns> 
        public static OriginationUrlUpdater Updater(string trunkSid, string sid)
        {
            return new OriginationUrlUpdater(trunkSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a OriginationUrlResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OriginationUrlResource object represented by the provided JSON </returns> 
        public static OriginationUrlResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<OriginationUrlResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("trunk_sid")]
        public string trunkSid { get; set; }
        [JsonProperty("weight")]
        public int? weight { get; set; }
        [JsonProperty("enabled")]
        public bool? enabled { get; set; }
        [JsonProperty("sip_url")]
        public Uri sipUrl { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("priority")]
        public int? priority { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public OriginationUrlResource()
        {
        
        }
    
        private OriginationUrlResource([JsonProperty("account_sid")]
                                       string accountSid, 
                                       [JsonProperty("sid")]
                                       string sid, 
                                       [JsonProperty("trunk_sid")]
                                       string trunkSid, 
                                       [JsonProperty("weight")]
                                       int? weight, 
                                       [JsonProperty("enabled")]
                                       bool? enabled, 
                                       [JsonProperty("sip_url")]
                                       Uri sipUrl, 
                                       [JsonProperty("friendly_name")]
                                       string friendlyName, 
                                       [JsonProperty("priority")]
                                       int? priority, 
                                       [JsonProperty("date_created")]
                                       string dateCreated, 
                                       [JsonProperty("date_updated")]
                                       string dateUpdated, 
                                       [JsonProperty("url")]
                                       Uri url)
                                       {
            this.accountSid = accountSid;
            this.sid = sid;
            this.trunkSid = trunkSid;
            this.weight = weight;
            this.enabled = enabled;
            this.sipUrl = sipUrl;
            this.friendlyName = friendlyName;
            this.priority = priority;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    }
}