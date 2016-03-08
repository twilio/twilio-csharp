using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010;
using Twilio.Http;
using Twilio.Readers.Api.V2010;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010 {

    public class Account : SidResource {
        public enum Status {
            ACTIVE="active",
            SUSPENDED="suspended",
            CLOSED="closed"
        };
    
        public enum Type {
            TRIAL="Trial",
            FULL="Full"
        };
    
        /**
         * Create a new Twilio Subaccount from the account making the request
         * 
         * @return AccountCreator capable of executing the create
         */
        public static AccountCreator create() {
            return new AccountCreator();
        }
    
        /**
         * Fetch the account specified by the provided Account Sid
         * 
         * @param sid Fetch by unique Account Sid
         * @return AccountFetcher capable of executing the fetch
         */
        public static AccountFetcher fetch(String sid) {
            return new AccountFetcher(sid);
        }
    
        /**
         * Retrieves a collection of Accounts belonging to the account used to make the
         * request
         * 
         * @return AccountReader capable of executing the read
         */
        public static AccountReader read() {
            return new AccountReader();
        }
    
        /**
         * Modify the properties of a given Account
         * 
         * @param sid The sid
         * @return AccountUpdater capable of executing the update
         */
        public static AccountUpdater update(String sid) {
            return new AccountUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a Account object
         * 
         * @param json Raw JSON string
         * @return Account object represented by the provided JSON
         */
        public static Account fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Account>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("auth_token")]
        private readonly String authToken;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("owner_account_sid")]
        private readonly String ownerAccountSid;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly Account.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
        [JsonProperty("type")]
        private readonly Account.Type type;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Account([JsonProperty("auth_token")]
                        String authToken, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("friendly_name")]
                        String friendlyName, 
                        [JsonProperty("owner_account_sid")]
                        String ownerAccountSid, 
                        [JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("status")]
                        Account.Status status, 
                        [JsonProperty("subresource_uris")]
                        Map<String, String> subresourceUris, 
                        [JsonProperty("type")]
                        Account.Type type, 
                        [JsonProperty("uri")]
                        String uri) {
            this.authToken = authToken;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.ownerAccountSid = ownerAccountSid;
            this.sid = sid;
            this.status = status;
            this.subresourceUris = subresourceUris;
            this.type = type;
            this.uri = uri;
        }
    
        /**
         * @return The authorization token for this account
         */
        public String GetAuthToken() {
            return this.authToken;
        }
    
        /**
         * @return The date this account was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this account was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A human readable description of this account
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The unique 34 character id representing the parent of this account
         */
        public String GetOwnerAccountSid() {
            return this.ownerAccountSid;
        }
    
        /**
         * @return A 34 character string that uniquely identifies this resource.
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of this account
         */
        public Account.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return Account Instance Subresources
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The type of this account
         */
        public Account.Type GetType() {
            return this.type;
        }
    
        /**
         * @return The URI for this resource, relative to `https://api.twilio.com`
         */
        public String GetUri() {
            return this.uri;
        }
    }
}