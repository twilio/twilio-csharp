using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip;

namespace Twilio.Resources.Api.V2010.Account.Sip {

    public class CredentialListResource : SidResource {
        /**
         * Retrieve a list of Credentials belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return CredentialListReader capable of executing the read
         */
        public static CredentialListReader read(string accountSid) {
            return new CredentialListReader(accountSid);
        }
    
        /**
         * Add a Credential to the list
         * 
         * @param accountSid The account_sid
         * @param friendlyName The friendly_name
         * @return CredentialListCreator capable of executing the create
         */
        public static CredentialListCreator create(string accountSid, string friendlyName) {
            return new CredentialListCreator(accountSid, friendlyName);
        }
    
        /**
         * Retrieve a specific Credential in a list
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique credential Sid
         * @return CredentialListFetcher capable of executing the fetch
         */
        public static CredentialListFetcher fetch(string accountSid, string sid) {
            return new CredentialListFetcher(accountSid, sid);
        }
    
        /**
         * Change the password of a Credential record
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @return CredentialListUpdater capable of executing the update
         */
        public static CredentialListUpdater update(string accountSid, string sid, string friendlyName) {
            return new CredentialListUpdater(accountSid, sid, friendlyName);
        }
    
        /**
         * Remove a credential from a CredentialList
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique credential Sid
         * @return CredentialListDeleter capable of executing the delete
         */
        public static CredentialListDeleter delete(string accountSid, string sid) {
            return new CredentialListDeleter(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a CredentialListResource object
         * 
         * @param json Raw JSON string
         * @return CredentialListResource object represented by the provided JSON
         */
        public static CredentialListResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialListResource>(json);
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
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private CredentialListResource([JsonProperty("account_sid")]
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
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
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