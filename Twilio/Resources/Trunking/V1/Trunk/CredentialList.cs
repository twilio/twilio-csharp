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
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Trunking.V1.Trunk {

    public class CredentialList : SidResource {
        /**
         * fetch
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return CredentialListFetcher capable of executing the fetch
         */
        public static CredentialListFetcher fetch(String trunkSid, String sid) {
            return new CredentialListFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return CredentialListDeleter capable of executing the delete
         */
        public static CredentialListDeleter delete(String trunkSid, String sid) {
            return new CredentialListDeleter(trunkSid, sid);
        }
    
        /**
         * create
         * 
         * @param trunkSid The trunk_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialListCreator capable of executing the create
         */
        public static CredentialListCreator create(String trunkSid, String credentialListSid) {
            return new CredentialListCreator(trunkSid, credentialListSid);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return CredentialListReader capable of executing the read
         */
        public static CredentialListReader read(String trunkSid) {
            return new CredentialListReader(trunkSid);
        }
    
        /**
         * Converts a JSON string into a CredentialList object
         * 
         * @param json Raw JSON string
         * @return CredentialList object represented by the provided JSON
         */
        public static CredentialList fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialList>(json);
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
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly URI url;
    
        private CredentialList([JsonProperty("account_sid")]
                               String accountSid, 
                               [JsonProperty("sid")]
                               String sid, 
                               [JsonProperty("trunk_sid")]
                               String trunkSid, 
                               [JsonProperty("friendly_name")]
                               String friendlyName, 
                               [JsonProperty("date_created")]
                               String dateCreated, 
                               [JsonProperty("date_updated")]
                               String dateUpdated, 
                               [JsonProperty("url")]
                               URI url) {
            this.accountSid = accountSid;
            this.sid = sid;
            this.trunkSid = trunkSid;
            this.friendlyName = friendlyName;
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
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
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