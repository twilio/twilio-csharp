using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1.Trunk {

    public class OriginationUrlResource : SidResource {
        /**
         * fetch
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return OriginationUrlFetcher capable of executing the fetch
         */
        public static OriginationUrlFetcher Fetcher(string trunkSid, string sid) {
            return new OriginationUrlFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return OriginationUrlDeleter capable of executing the delete
         */
        public static OriginationUrlDeleter Deleter(string trunkSid, string sid) {
            return new OriginationUrlDeleter(trunkSid, sid);
        }
    
        /**
         * create
         * 
         * @param trunkSid The trunk_sid
         * @param weight The weight
         * @param priority The priority
         * @param enabled The enabled
         * @param friendlyName The friendly_name
         * @param sipUrl The sip_url
         * @return OriginationUrlCreator capable of executing the create
         */
        public static OriginationUrlCreator Creator(string trunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl) {
            return new OriginationUrlCreator(trunkSid, weight, priority, enabled, friendlyName, sipUrl);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return OriginationUrlReader capable of executing the read
         */
        public static OriginationUrlReader Reader(string trunkSid) {
            return new OriginationUrlReader(trunkSid);
        }
    
        /**
         * update
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return OriginationUrlUpdater capable of executing the update
         */
        public static OriginationUrlUpdater Updater(string trunkSid, string sid) {
            return new OriginationUrlUpdater(trunkSid, sid);
        }
    
        /**
         * Converts a JSON string into a OriginationUrlResource object
         * 
         * @param json Raw JSON string
         * @return OriginationUrlResource object represented by the provided JSON
         */
        public static OriginationUrlResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<OriginationUrlResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("trunk_sid")]
        private readonly string trunkSid;
        [JsonProperty("weight")]
        private readonly int? weight;
        [JsonProperty("enabled")]
        private readonly bool? enabled;
        [JsonProperty("sip_url")]
        private readonly Uri sipUrl;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("priority")]
        private readonly int? priority;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public OriginationUrlResource() {
        
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
                                       Uri url) {
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The trunk_sid
         */
        public string GetTrunkSid() {
            return this.trunkSid;
        }
    
        /**
         * @return The weight
         */
        public int? GetWeight() {
            return this.weight;
        }
    
        /**
         * @return The enabled
         */
        public bool? GetEnabled() {
            return this.enabled;
        }
    
        /**
         * @return The sip_url
         */
        public Uri GetSipUrl() {
            return this.sipUrl;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The priority
         */
        public int? GetPriority() {
            return this.priority;
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
    }
}