using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList {

    public class CredentialResource : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialReader capable of executing the read
         */
        public static CredentialReader Reader(string accountSid, string credentialListSid) {
            return new CredentialReader(accountSid, credentialListSid);
        }
    
        /**
         * Create a CredentialReader to execute read.
         * 
         * @param credentialListSid The credential_list_sid
         * @return CredentialReader capable of executing the read
         */
        public static CredentialReader Reader(string credentialListSid) {
            return new CredentialReader(credentialListSid);
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
        public static CredentialCreator Creator(string accountSid, string credentialListSid, string username, string password) {
            return new CredentialCreator(accountSid, credentialListSid, username, password);
        }
    
        /**
         * Create a CredentialCreator to execute create.
         * 
         * @param credentialListSid The credential_list_sid
         * @param username The username
         * @param password The password
         * @return CredentialCreator capable of executing the create
         */
        public static CredentialCreator Creator(string credentialListSid, 
                                                string username, 
                                                string password) {
            return new CredentialCreator(credentialListSid, username, password);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher Fetcher(string accountSid, string credentialListSid, string sid) {
            return new CredentialFetcher(accountSid, credentialListSid, sid);
        }
    
        /**
         * Create a CredentialFetcher to execute fetch.
         * 
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher Fetcher(string credentialListSid, 
                                                string sid) {
            return new CredentialFetcher(credentialListSid, sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialUpdater capable of executing the update
         */
        public static CredentialUpdater Updater(string accountSid, string credentialListSid, string sid) {
            return new CredentialUpdater(accountSid, credentialListSid, sid);
        }
    
        /**
         * Create a CredentialUpdater to execute update.
         * 
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialUpdater capable of executing the update
         */
        public static CredentialUpdater Updater(string credentialListSid, 
                                                string sid) {
            return new CredentialUpdater(credentialListSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter Deleter(string accountSid, string credentialListSid, string sid) {
            return new CredentialDeleter(accountSid, credentialListSid, sid);
        }
    
        /**
         * Create a CredentialDeleter to execute delete.
         * 
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter Deleter(string credentialListSid, 
                                                string sid) {
            return new CredentialDeleter(credentialListSid, sid);
        }
    
        /**
         * Converts a JSON string into a CredentialResource object
         * 
         * @param json Raw JSON string
         * @return CredentialResource object represented by the provided JSON
         */
        public static CredentialResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("credential_list_sid")]
        private readonly string credentialListSid;
        [JsonProperty("username")]
        private readonly string username;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public CredentialResource() {
        
        }
    
        private CredentialResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("credential_list_sid")]
                                   string credentialListSid, 
                                   [JsonProperty("username")]
                                   string username, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("uri")]
                                   string uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The credential_list_sid
         */
        public string GetCredentialListSid() {
            return this.credentialListSid;
        }
    
        /**
         * @return The username
         */
        public string GetUsername() {
            return this.username;
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
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}