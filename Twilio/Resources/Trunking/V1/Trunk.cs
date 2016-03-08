using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Trunking.V1;
using Twilio.Deleters.Trunking.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1;
using Twilio.Http;
using Twilio.Readers.Trunking.V1;
using Twilio.Resources;
using Twilio.Updaters.Trunking.V1;
using com.fasterxml.jackson.databind.JsonNode;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using java.util.List;
using org.joda.time.DateTime;

namespace Twilio.Resources.Trunking.V1 {

    public class Trunk : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return TrunkFetcher capable of executing the fetch
         */
        public static TrunkFetcher fetch(String sid) {
            return new TrunkFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return TrunkDeleter capable of executing the delete
         */
        public static TrunkDeleter delete(String sid) {
            return new TrunkDeleter(sid);
        }
    
        /**
         * create
         * 
         * @return TrunkCreator capable of executing the create
         */
        public static TrunkCreator create() {
            return new TrunkCreator();
        }
    
        /**
         * read
         * 
         * @return TrunkReader capable of executing the read
         */
        public static TrunkReader read() {
            return new TrunkReader();
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return TrunkUpdater capable of executing the update
         */
        public static TrunkUpdater update(String sid) {
            return new TrunkUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a Trunk object
         * 
         * @param json Raw JSON string
         * @return Trunk object represented by the provided JSON
         */
        public static Trunk fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Trunk>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("domain_name")]
        private readonly String domainName;
        [JsonProperty("disaster_recovery_method")]
        private readonly HttpMethod disasterRecoveryMethod;
        [JsonProperty("disaster_recovery_url")]
        private readonly URI disasterRecoveryUrl;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("secure")]
        private readonly Boolean secure;
        [JsonProperty("recording")]
        private readonly JsonNode recording;
        [JsonProperty("auth_type")]
        private readonly String authType;
        [JsonProperty("auth_type_set")]
        private readonly List<String> authTypeSet;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("url")]
        private readonly URI url;
        [JsonProperty("links")]
        private readonly Map<String, String> links;
    
        private Trunk([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("domain_name")]
                      String domainName, 
                      [JsonProperty("disaster_recovery_method")]
                      HttpMethod disasterRecoveryMethod, 
                      [JsonProperty("disaster_recovery_url")]
                      URI disasterRecoveryUrl, 
                      [JsonProperty("friendly_name")]
                      String friendlyName, 
                      [JsonProperty("secure")]
                      Boolean secure, 
                      [JsonProperty("recording")]
                      JsonNode recording, 
                      [JsonProperty("auth_type")]
                      String authType, 
                      [JsonProperty("auth_type_set")]
                      List<String> authTypeSet, 
                      [JsonProperty("date_created")]
                      String dateCreated, 
                      [JsonProperty("date_updated")]
                      String dateUpdated, 
                      [JsonProperty("sid")]
                      String sid, 
                      [JsonProperty("url")]
                      URI url, 
                      [JsonProperty("links")]
                      Map<String, String> links) {
            this.accountSid = accountSid;
            this.domainName = domainName;
            this.disasterRecoveryMethod = disasterRecoveryMethod;
            this.disasterRecoveryUrl = disasterRecoveryUrl;
            this.friendlyName = friendlyName;
            this.secure = secure;
            this.recording = recording;
            this.authType = authType;
            this.authTypeSet = authTypeSet;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.sid = sid;
            this.url = url;
            this.links = links;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The domain_name
         */
        public String GetDomainName() {
            return this.domainName;
        }
    
        /**
         * @return The disaster_recovery_method
         */
        public HttpMethod GetDisasterRecoveryMethod() {
            return this.disasterRecoveryMethod;
        }
    
        /**
         * @return The disaster_recovery_url
         */
        public URI GetDisasterRecoveryUrl() {
            return this.disasterRecoveryUrl;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The secure
         */
        public Boolean GetSecure() {
            return this.secure;
        }
    
        /**
         * @return The recording
         */
        public JsonNode GetRecording() {
            return this.recording;
        }
    
        /**
         * @return The auth_type
         */
        public String GetAuthType() {
            return this.authType;
        }
    
        /**
         * @return The auth_type_set
         */
        public List<String> GetAuthTypeSet() {
            return this.authTypeSet;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    
        /**
         * @return The links
         */
        public Map<String, String> GetLinks() {
            return this.links;
        }
    }
}