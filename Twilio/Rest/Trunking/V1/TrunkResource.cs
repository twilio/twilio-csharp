using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1 
{

    public class TrunkResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TrunkFetcher capable of executing the fetch </returns> 
        public static TrunkFetcher Fetcher(string sid)
        {
            return new TrunkFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TrunkDeleter capable of executing the delete </returns> 
        public static TrunkDeleter Deleter(string sid)
        {
            return new TrunkDeleter(sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <returns> TrunkCreator capable of executing the create </returns> 
        public static TrunkCreator Creator()
        {
            return new TrunkCreator();
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> TrunkReader capable of executing the read </returns> 
        public static TrunkReader Reader()
        {
            return new TrunkReader();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TrunkUpdater capable of executing the update </returns> 
        public static TrunkUpdater Updater(string sid)
        {
            return new TrunkUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TrunkResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TrunkResource object represented by the provided JSON </returns> 
        public static TrunkResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TrunkResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("domain_name")]
        public string domainName { get; set; }
        [JsonProperty("disaster_recovery_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod disasterRecoveryMethod { get; set; }
        [JsonProperty("disaster_recovery_url")]
        public Uri disasterRecoveryUrl { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("secure")]
        public bool? secure { get; set; }
        [JsonProperty("recording")]
        public Object recording { get; set; }
        [JsonProperty("auth_type")]
        public string authType { get; set; }
        [JsonProperty("auth_type_set")]
        public List<string> authTypeSet { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; set; }
    
        public TrunkResource()
        {
        
        }
    
        private TrunkResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("domain_name")]
                              string domainName, 
                              [JsonProperty("disaster_recovery_method")]
                              Twilio.Http.HttpMethod disasterRecoveryMethod, 
                              [JsonProperty("disaster_recovery_url")]
                              Uri disasterRecoveryUrl, 
                              [JsonProperty("friendly_name")]
                              string friendlyName, 
                              [JsonProperty("secure")]
                              bool? secure, 
                              [JsonProperty("recording")]
                              Object recording, 
                              [JsonProperty("auth_type")]
                              string authType, 
                              [JsonProperty("auth_type_set")]
                              List<string> authTypeSet, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("url")]
                              Uri url, 
                              [JsonProperty("links")]
                              Dictionary<string, string> links)
                              {
            this.accountSid = accountSid;
            this.domainName = domainName;
            this.disasterRecoveryMethod = disasterRecoveryMethod;
            this.disasterRecoveryUrl = disasterRecoveryUrl;
            this.friendlyName = friendlyName;
            this.secure = secure;
            this.recording = recording;
            this.authType = authType;
            this.authTypeSet = authTypeSet;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.sid = sid;
            this.url = url;
            this.links = links;
        }
    }
}