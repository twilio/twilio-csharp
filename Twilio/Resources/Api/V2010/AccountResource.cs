using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010;
using Twilio.Http;
using Twilio.Readers.Api.V2010;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010;

namespace Twilio.Resources.Api.V2010 {

    public class AccountResource : SidResource {
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
        public static AccountFetcher fetch(string sid) {
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
        public static AccountUpdater update(string sid) {
            return new AccountUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a AccountResource object
         * 
         * @param json Raw JSON string
         * @return AccountResource object represented by the provided JSON
         */
        public static AccountResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AccountResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("auth_token")]
        private readonly string authToken;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("owner_account_sid")]
        private readonly string ownerAccountSid;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        private readonly AccountResource.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("type")]
        private readonly AccountResource.Type type;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private AccountResource([JsonProperty("auth_token")]
                                string authToken, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("owner_account_sid")]
                                string ownerAccountSid, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("status")]
                                AccountResource.Status status, 
                                [JsonProperty("subresource_uris")]
                                Dictionary<string, string> subresourceUris, 
                                [JsonProperty("type")]
                                AccountResource.Type type, 
                                [JsonProperty("uri")]
                                string uri) {
            this.authToken = authToken;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
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
        public string GetAuthToken() {
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
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The unique 34 character id representing the parent of this account
         */
        public string GetOwnerAccountSid() {
            return this.ownerAccountSid;
        }
    
        /**
         * @return A 34 character string that uniquely identifies this resource.
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of this account
         */
        public AccountResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return Account Instance Subresources
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The type of this account
         */
        public AccountResource.Type GetAccountType() {
            return this.type;
        }
    
        /**
         * @return The URI for this resource, relative to `https://api.twilio.com`
         */
        public string GetUri() {
            return this.uri;
        }
    }
}