using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip.Domain;
using Twilio.Deleters.Api.V2010.Account.Sip.Domain;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.Domain;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.Domain;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip.Domain {

    public class CredentialListMapping : SidResource {
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialListMappingCreator capable of executing the create
         */
        public static CredentialListMappingCreator create(String accountSid, String domainSid, String credentialListSid) {
            return new CredentialListMappingCreator(accountSid, domainSid, credentialListSid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @return CredentialListMappingReader capable of executing the read
         */
        public static CredentialListMappingReader read(String accountSid, String domainSid) {
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
        public static CredentialListMappingFetcher fetch(String accountSid, String domainSid, String sid) {
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
        public static CredentialListMappingDeleter delete(String accountSid, String domainSid, String sid) {
            return new CredentialListMappingDeleter(accountSid, domainSid, sid);
        }
    
        /**
         * Converts a JSON string into a CredentialListMapping object
         * 
         * @param json Raw JSON string
         * @return CredentialListMapping object represented by the provided JSON
         */
        public static CredentialListMapping fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialListMapping>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private CredentialListMapping([JsonProperty("account_sid")]
                                      String accountSid, 
                                      [JsonProperty("date_created")]
                                      String dateCreated, 
                                      [JsonProperty("date_updated")]
                                      String dateUpdated, 
                                      [JsonProperty("friendly_name")]
                                      String friendlyName, 
                                      [JsonProperty("sid")]
                                      String sid, 
                                      [JsonProperty("uri")]
                                      String uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
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
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}