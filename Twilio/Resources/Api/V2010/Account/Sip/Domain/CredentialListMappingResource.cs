using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip.Domain;
using Twilio.Deleters.Api.V2010.Account.Sip.Domain;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.Domain;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.Domain;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingResource : SidResource {
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialListMappingCreator capable of executing the create
         */
        public static CredentialListMappingCreator create(string accountSid, string domainSid, string credentialListSid) {
            return new CredentialListMappingCreator(accountSid, domainSid, credentialListSid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @return CredentialListMappingReader capable of executing the read
         */
        public static CredentialListMappingReader read(string accountSid, string domainSid) {
            return new CredentialListMappingReader(accountSid, domainSid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return CredentialListMappingFetcher capable of executing the fetch
         */
        public static CredentialListMappingFetcher fetch(string accountSid, string domainSid, string sid) {
            return new CredentialListMappingFetcher(accountSid, domainSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return CredentialListMappingDeleter capable of executing the delete
         */
        public static CredentialListMappingDeleter delete(string accountSid, string domainSid, string sid) {
            return new CredentialListMappingDeleter(accountSid, domainSid, sid);
        }
    
        /**
         * Converts a JSON string into a CredentialListMappingResource object
         * 
         * @param json Raw JSON string
         * @return CredentialListMappingResource object represented by the provided JSON
         */
        public static CredentialListMappingResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialListMappingResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private CredentialListMappingResource([JsonProperty("account_sid")]
                                              string accountSid, 
                                              [JsonProperty("date_created")]
                                              string dateCreated, 
                                              [JsonProperty("date_updated")]
                                              string dateUpdated, 
                                              [JsonProperty("friendly_name")]
                                              string friendlyName, 
                                              [JsonProperty("sid")]
                                              string sid, 
                                              [JsonProperty("uri")]
                                              string uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}