using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip.CredentialList;
using Twilio.Deleters.Api.V2010.Account.Sip.CredentialList;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.CredentialList;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.CredentialList;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip.CredentialList;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip.Credentiallist {

    public class Credential : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialReader capable of executing the read
         */
        public static CredentialReader read(String accountSid, String credentialListSid) {
            return new CredentialReader(accountSid, credentialListSid);
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param username The username
         * @param password The password
         * @return CredentialCreator capable of executing the create
         */
        public static CredentialCreator create(String accountSid, String credentialListSid, String username, String password) {
            return new CredentialCreator(accountSid, credentialListSid, username, password);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher fetch(String accountSid, String credentialListSid, String sid) {
            return new CredentialFetcher(accountSid, credentialListSid, sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @param username The username
         * @param password The password
         * @return CredentialUpdater capable of executing the update
         */
        public static CredentialUpdater update(String accountSid, String credentialListSid, String sid, String username, String password) {
            return new CredentialUpdater(accountSid, credentialListSid, sid, username, password);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter delete(String accountSid, String credentialListSid, String sid) {
            return new CredentialDeleter(accountSid, credentialListSid, sid);
        }
    
        /**
         * Converts a JSON string into a Credential object
         * 
         * @param json Raw JSON string
         * @return Credential object represented by the provided JSON
         */
        public static Credential fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Credential>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("credential_list_sid")]
        private readonly String credentialListSid;
        [JsonProperty("username")]
        private readonly String username;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Credential([JsonProperty("sid")]
                           String sid, 
                           [JsonProperty("account_sid")]
                           String accountSid, 
                           [JsonProperty("credential_list_sid")]
                           String credentialListSid, 
                           [JsonProperty("username")]
                           String username, 
                           [JsonProperty("date_created")]
                           String dateCreated, 
                           [JsonProperty("date_updated")]
                           String dateUpdated, 
                           [JsonProperty("uri")]
                           String uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The credential_list_sid
         */
        public String GetCredentialListSid() {
            return this.credentialListSid;
        }
    
        /**
         * @return The username
         */
        public String GetUsername() {
            return this.username;
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
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}