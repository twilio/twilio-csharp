using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Trunking.V1.Trunk;
using Twilio.Deleters.Trunking.V1.Trunk;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1.Trunk;
using Twilio.Http;
using Twilio.Readers.Trunking.V1.Trunk;
using Twilio.Resources;
using Twilio.Updaters.Trunking.V1.Trunk;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Trunking.V1.Trunk {

    public class OriginationUrl : SidResource {
        /**
         * fetch
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return OriginationUrlFetcher capable of executing the fetch
         */
        public static OriginationUrlFetcher fetch(String trunkSid, String sid) {
            return new OriginationUrlFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return OriginationUrlDeleter capable of executing the delete
         */
        public static OriginationUrlDeleter delete(String trunkSid, String sid) {
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
        public static OriginationUrlCreator create(String trunkSid, Integer weight, Integer priority, Boolean enabled, String friendlyName, URI sipUrl) {
            return new OriginationUrlCreator(trunkSid, weight, priority, enabled, friendlyName, sipUrl);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return OriginationUrlReader capable of executing the read
         */
        public static OriginationUrlReader read(String trunkSid) {
            return new OriginationUrlReader(trunkSid);
        }
    
        /**
         * update
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return OriginationUrlUpdater capable of executing the update
         */
        public static OriginationUrlUpdater update(String trunkSid, String sid) {
            return new OriginationUrlUpdater(trunkSid, sid);
        }
    
        /**
         * Converts a JSON string into a OriginationUrl object
         * 
         * @param json Raw JSON string
         * @return OriginationUrl object represented by the provided JSON
         */
        public static OriginationUrl fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<OriginationUrl>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("trunk_sid")]
        private readonly String trunkSid;
        [JsonProperty("weight")]
        private readonly Integer weight;
        [JsonProperty("enabled")]
        private readonly Boolean enabled;
        [JsonProperty("sip_url")]
        private readonly URI sipUrl;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("priority")]
        private readonly Integer priority;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly URI url;
    
        private OriginationUrl([JsonProperty("account_sid")]
                               String accountSid, 
                               [JsonProperty("sid")]
                               String sid, 
                               [JsonProperty("trunk_sid")]
                               String trunkSid, 
                               [JsonProperty("weight")]
                               Integer weight, 
                               [JsonProperty("enabled")]
                               Boolean enabled, 
                               [JsonProperty("sip_url")]
                               URI sipUrl, 
                               [JsonProperty("friendly_name")]
                               String friendlyName, 
                               [JsonProperty("priority")]
                               Integer priority, 
                               [JsonProperty("date_created")]
                               String dateCreated, 
                               [JsonProperty("date_updated")]
                               String dateUpdated, 
                               [JsonProperty("url")]
                               URI url) {
            this.accountSid = accountSid;
            this.sid = sid;
            this.trunkSid = trunkSid;
            this.weight = weight;
            this.enabled = enabled;
            this.sipUrl = sipUrl;
            this.friendlyName = friendlyName;
            this.priority = priority;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.url = url;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The trunk_sid
         */
        public String GetTrunkSid() {
            return this.trunkSid;
        }
    
        /**
         * @return The weight
         */
        public Integer GetWeight() {
            return this.weight;
        }
    
        /**
         * @return The enabled
         */
        public Boolean GetEnabled() {
            return this.enabled;
        }
    
        /**
         * @return The sip_url
         */
        public URI GetSipUrl() {
            return this.sipUrl;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The priority
         */
        public Integer GetPriority() {
            return this.priority;
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
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}