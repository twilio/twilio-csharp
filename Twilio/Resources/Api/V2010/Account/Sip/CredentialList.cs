using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip {

    public class CredentialList : SidResource {
        /**
         * Retrieve a list of Credentials belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return CredentialListReader capable of executing the read
         */
        public static CredentialListReader read(String accountSid) {
            return new CredentialListReader(accountSid);
        }
    
        /**
         * Add a Credential to the list
         * 
         * @param accountSid The account_sid
         * @param friendlyName The friendly_name
         * @return CredentialListCreator capable of executing the create
         */
        public static CredentialListCreator create(String accountSid, String friendlyName) {
            return new CredentialListCreator(accountSid, friendlyName);
        }
    
        /**
         * Retrieve a specific Credential in a list
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique credential Sid
         * @return CredentialListFetcher capable of executing the fetch
         */
        public static CredentialListFetcher fetch(String accountSid, String sid) {
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
        public static CredentialListUpdater update(String accountSid, String sid, String friendlyName) {
            return new CredentialListUpdater(accountSid, sid, friendlyName);
        }
    
        /**
         * Remove a credential from a CredentialList
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique credential Sid
         * @return CredentialListDeleter capable of executing the delete
         */
        public static CredentialListDeleter delete(String accountSid, String sid) {
            return new CredentialListDeleter(accountSid, sid);
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
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private CredentialList([JsonProperty("account_sid")]
                               String accountSid, 
                               [JsonProperty("date_created")]
                               String dateCreated, 
                               [JsonProperty("date_updated")]
                               String dateUpdated, 
                               [JsonProperty("friendly_name")]
                               String friendlyName, 
                               [JsonProperty("sid")]
                               String sid, 
                               [JsonProperty("subresource_uris")]
                               Map<String, String> subresourceUris, 
                               [JsonProperty("uri")]
                               String uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.subresourceUris = subresourceUris;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
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
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return A string that uniquely identifies this credential
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The subresource_uris
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}