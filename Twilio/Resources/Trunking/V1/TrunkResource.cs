using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Trunking.V1;
using Twilio.Deleters.Trunking.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1;
using Twilio.Http;
using Twilio.Readers.Trunking.V1;
using Twilio.Resources;
using Twilio.Updaters.Trunking.V1;

namespace Twilio.Resources.Trunking.V1 {

    public class TrunkResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return TrunkFetcher capable of executing the fetch
         */
        public static TrunkFetcher Fetch(string sid) {
            return new TrunkFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return TrunkDeleter capable of executing the delete
         */
        public static TrunkDeleter Delete(string sid) {
            return new TrunkDeleter(sid);
        }
    
        /**
         * create
         * 
         * @return TrunkCreator capable of executing the create
         */
        public static TrunkCreator Create() {
            return new TrunkCreator();
        }
    
        /**
         * read
         * 
         * @return TrunkReader capable of executing the read
         */
        public static TrunkReader Read() {
            return new TrunkReader();
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return TrunkUpdater capable of executing the update
         */
        public static TrunkUpdater Update(string sid) {
            return new TrunkUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a TrunkResource object
         * 
         * @param json Raw JSON string
         * @return TrunkResource object represented by the provided JSON
         */
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
        private readonly System.Net.Http.HttpMethod disasterRecoveryMethod;
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
                              System.Net.Http.HttpMethod disasterRecoveryMethod, 
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The domain_name
         */
        public string GetDomainName() {
            return this.domainName;
        }
    
        /**
         * @return The disaster_recovery_method
         */
        public System.Net.Http.HttpMethod GetDisasterRecoveryMethod() {
            return this.disasterRecoveryMethod;
        }
    
        /**
         * @return The disaster_recovery_url
         */
        public Uri GetDisasterRecoveryUrl() {
            return this.disasterRecoveryUrl;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The secure
         */
        public bool? GetSecure() {
            return this.secure;
        }
    
        /**
         * @return The recording
         */
        public Object GetRecording() {
            return this.recording;
        }
    
        /**
         * @return The auth_type
         */
        public string GetAuthType() {
            return this.authType;
        }
    
        /**
         * @return The auth_type_set
         */
        public List<string> GetAuthTypeSet() {
            return this.authTypeSet;
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
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
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