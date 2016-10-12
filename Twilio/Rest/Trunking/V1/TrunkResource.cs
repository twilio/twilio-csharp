using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1 {

    public class TrunkResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TrunkFetcher capable of executing the fetch </returns> 
        public static TrunkFetcher Fetcher(string sid) {
            return new TrunkFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TrunkDeleter capable of executing the delete </returns> 
        public static TrunkDeleter Deleter(string sid) {
            return new TrunkDeleter(sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <returns> TrunkCreator capable of executing the create </returns> 
        public static TrunkCreator Creator() {
            return new TrunkCreator();
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> TrunkReader capable of executing the read </returns> 
        public static TrunkReader Reader() {
            return new TrunkReader();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TrunkUpdater capable of executing the update </returns> 
        public static TrunkUpdater Updater(string sid) {
            return new TrunkUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TrunkResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TrunkResource object represented by the provided JSON </returns> 
        public static TrunkResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TrunkResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("domain_name")]
        private readonly string domainName;
        [JsonProperty("disaster_recovery_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod disasterRecoveryMethod;
        [JsonProperty("disaster_recovery_url")]
        private readonly Uri disasterRecoveryUrl;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("secure")]
        private readonly bool? secure;
        [JsonProperty("recording")]
        private readonly Object recording;
        [JsonProperty("auth_type")]
        private readonly string authType;
        [JsonProperty("auth_type_set")]
        private readonly List<string> authTypeSet;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        public TrunkResource() {
        
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
                              Dictionary<string, string> links) {
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The domain_name </returns> 
        public string GetDomainName() {
            return this.domainName;
        }
    
        /// <returns> The disaster_recovery_method </returns> 
        public Twilio.Http.HttpMethod GetDisasterRecoveryMethod() {
            return this.disasterRecoveryMethod;
        }
    
        /// <returns> The disaster_recovery_url </returns> 
        public Uri GetDisasterRecoveryUrl() {
            return this.disasterRecoveryUrl;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The secure </returns> 
        public bool? GetSecure() {
            return this.secure;
        }
    
        /// <returns> The recording </returns> 
        public Object GetRecording() {
            return this.recording;
        }
    
        /// <returns> The auth_type </returns> 
        public string GetAuthType() {
            return this.authType;
        }
    
        /// <returns> The auth_type_set </returns> 
        public List<string> GetAuthTypeSet() {
            return this.authTypeSet;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
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