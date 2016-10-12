using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList {

    public class CredentialResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialReader capable of executing the read </returns> 
        public static CredentialReader Reader(string accountSid, string credentialListSid) {
            return new CredentialReader(accountSid, credentialListSid);
        }
    
        /// <summary>
        /// Create a CredentialReader to execute read.
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialReader capable of executing the read </returns> 
        public static CredentialReader Reader(string credentialListSid) {
            return new CredentialReader(credentialListSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        /// <returns> CredentialCreator capable of executing the create </returns> 
        public static CredentialCreator Creator(string accountSid, string credentialListSid, string username, string password) {
            return new CredentialCreator(accountSid, credentialListSid, username, password);
        }
    
        /// <summary>
        /// Create a CredentialCreator to execute create.
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        /// <returns> CredentialCreator capable of executing the create </returns> 
        public static CredentialCreator Creator(string credentialListSid, 
                                                string username, 
                                                string password) {
            return new CredentialCreator(credentialListSid, username, password);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialFetcher capable of executing the fetch </returns> 
        public static CredentialFetcher Fetcher(string accountSid, string credentialListSid, string sid) {
            return new CredentialFetcher(accountSid, credentialListSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialFetcher capable of executing the fetch </returns> 
        public static CredentialFetcher Fetcher(string credentialListSid, 
                                                string sid) {
            return new CredentialFetcher(credentialListSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialUpdater capable of executing the update </returns> 
        public static CredentialUpdater Updater(string accountSid, string credentialListSid, string sid) {
            return new CredentialUpdater(accountSid, credentialListSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialUpdater to execute update.
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialUpdater capable of executing the update </returns> 
        public static CredentialUpdater Updater(string credentialListSid, 
                                                string sid) {
            return new CredentialUpdater(credentialListSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialDeleter capable of executing the delete </returns> 
        public static CredentialDeleter Deleter(string accountSid, string credentialListSid, string sid) {
            return new CredentialDeleter(accountSid, credentialListSid, sid);
        }
    
        /// <summary>
        /// Create a CredentialDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialDeleter capable of executing the delete </returns> 
        public static CredentialDeleter Deleter(string credentialListSid, 
                                                string sid) {
            return new CredentialDeleter(credentialListSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The credential_list_sid </returns> 
        public string GetCredentialListSid() {
            return this.credentialListSid;
        }
    
        /// <returns> The username </returns> 
        public string GetUsername() {
            return this.username;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}