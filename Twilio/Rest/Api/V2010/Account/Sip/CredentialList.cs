using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Updaters.Api.V2010.Account.Sip;

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class CredentialList : SidResource {
        /**
         * Retrieve a list of Credentials belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return CredentialListReader capable of executing the read
         */
        public static CredentialListReader Read(string accountSid) {
            return new CredentialListReader(accountSid);
        }
    
        /**
         * Create a CredentialListReader to execute read.
         * 
         * @return CredentialListReader capable of executing the read
         */
        public static CredentialListReader Read() {
            return new CredentialListReader();
        }
    
        /**
         * Add a Credential to the list
         * 
         * @param accountSid The account_sid
         * @param friendlyName The friendly_name
         * @return CredentialListCreator capable of executing the create
         */
        public static CredentialListCreator Create(string accountSid, string friendlyName) {
            return new CredentialListCreator(accountSid, friendlyName);
        }
    
        /**
         * Create a CredentialListCreator to execute create.
         * 
         * @param friendlyName The friendly_name
         * @return CredentialListCreator capable of executing the create
         */
        public static CredentialListCreator Create(string friendlyName) {
            return new CredentialListCreator(friendlyName);
        }
    
        /**
         * Retrieve a specific Credential in a list
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique credential Sid
         * @return CredentialListFetcher capable of executing the fetch
         */
        public static CredentialListFetcher Fetch(string accountSid, string sid) {
            return new CredentialListFetcher(accountSid, sid);
        }
    
        /**
         * Create a CredentialListFetcher to execute fetch.
         * 
         * @param sid Fetch by unique credential Sid
         * @return CredentialListFetcher capable of executing the fetch
         */
        public static CredentialListFetcher Fetch(string sid) {
            return new CredentialListFetcher(sid);
        }
    
        /**
         * Change the password of a Credential record
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @return CredentialListUpdater capable of executing the update
         */
        public static CredentialListUpdater Update(string accountSid, string sid, string friendlyName) {
            return new CredentialListUpdater(accountSid, sid, friendlyName);
        }
    
        /**
         * Create a CredentialListUpdater to execute update.
         * 
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @return CredentialListUpdater capable of executing the update
         */
        public static CredentialListUpdater Update(string sid, 
                                                   string friendlyName) {
            return new CredentialListUpdater(sid, friendlyName);
        }
    
        /**
         * Remove a credential from a CredentialList
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique credential Sid
         * @return CredentialListDeleter capable of executing the delete
         */
        public static CredentialListDeleter Delete(string accountSid, string sid) {
            return new CredentialListDeleter(accountSid, sid);
        }
    
        /**
         * Create a CredentialListDeleter to execute delete.
         * 
         * @param sid Delete by unique credential Sid
         * @return CredentialListDeleter capable of executing the delete
         */
        public static CredentialListDeleter Delete(string sid) {
            return new CredentialListDeleter(sid);
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
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public CredentialList() {
        
        }
    
        private CredentialList([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("friendly_name")]
                               string friendlyName, 
                               [JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("subresource_uris")]
                               Dictionary<string, string> subresourceUris, 
                               [JsonProperty("uri")]
                               string uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.subresourceUris = subresourceUris;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return A string that uniquely identifies this credential
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The subresource_uris
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}