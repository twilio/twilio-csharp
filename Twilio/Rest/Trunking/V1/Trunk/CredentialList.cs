using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Trunking.V1.Trunk;
using Twilio.Deleters.Trunking.V1.Trunk;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1.Trunk;
using Twilio.Http;
using Twilio.Readers.Trunking.V1.Trunk;

namespace Twilio.Rest.Trunking.V1.Trunk {

    public class CredentialList : SidResource {
        /**
         * fetch
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return CredentialListFetcher capable of executing the fetch
         */
        public static CredentialListFetcher Fetch(string trunkSid, string sid) {
            return new CredentialListFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return CredentialListDeleter capable of executing the delete
         */
        public static CredentialListDeleter Delete(string trunkSid, string sid) {
            return new CredentialListDeleter(trunkSid, sid);
        }
    
        /**
         * create
         * 
         * @param trunkSid The trunk_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialListCreator capable of executing the create
         */
        public static CredentialListCreator Create(string trunkSid, string credentialListSid) {
            return new CredentialListCreator(trunkSid, credentialListSid);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return CredentialListReader capable of executing the read
         */
        public static CredentialListReader Read(string trunkSid) {
            return new CredentialListReader(trunkSid);
        }
    
        /**
         * Converts a JSON string into a CredentialList object
         * 
         * @param json Raw JSON string
         * @return CredentialList object represented by the provided JSON
         */
        public static CredentialList FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialList>(json);
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
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public CredentialList() {
        
        }
    
        private CredentialList([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("trunk_sid")]
                               string trunkSid, 
                               [JsonProperty("friendly_name")]
                               string friendlyName, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("url")]
                               Uri url) {
            this.accountSid = accountSid;
            this.sid = sid;
            this.trunkSid = trunkSid;
            this.friendlyName = friendlyName;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
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