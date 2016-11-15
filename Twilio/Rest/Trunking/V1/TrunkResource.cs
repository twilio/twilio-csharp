using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

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
        public string AccountSid { get; set; }
        [JsonProperty("domain_name")]
        public string DomainName { get; set; }
        [JsonProperty("disaster_recovery_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod DisasterRecoveryMethod { get; set; }
        [JsonProperty("disaster_recovery_url")]
        public Uri DisasterRecoveryUrl { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("secure")]
        public bool? Secure { get; set; }
        [JsonProperty("recording")]
        public Object Recording { get; set; }
        [JsonProperty("auth_type")]
        public string AuthType { get; set; }
        [JsonProperty("auth_type_set")]
        public List<string> AuthTypeSet { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
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
            AccountSid = accountSid;
            DomainName = domainName;
            DisasterRecoveryMethod = disasterRecoveryMethod;
            DisasterRecoveryUrl = disasterRecoveryUrl;
            FriendlyName = friendlyName;
            Secure = secure;
            Recording = recording;
            AuthType = authType;
            AuthTypeSet = authTypeSet;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Sid = sid;
            Url = url;
            Links = links;
        }
    }
}