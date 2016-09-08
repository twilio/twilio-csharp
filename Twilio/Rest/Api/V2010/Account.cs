using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010 {

    public class Account : SidResource {
        public sealed class Status : IStringEnum {
            public const string ACTIVE="active";
            public const string SUSPENDED="suspended";
            public const string CLOSED="closed";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class Type : IStringEnum {
            public const string TRIAL="Trial";
            public const string FULL="Full";
        
            private string value;
            
            public Type() { }
            
            public Type(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Type(string value) {
                return new Type(value);
            }
            
            public static implicit operator string(Type value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * Create a new Twilio Subaccount from the account making the request
         * 
         * @return AccountCreator capable of executing the create
         */
        public static AccountCreator Create() {
            return new AccountCreator();
        }
    
        /**
         * Fetch the account specified by the provided Account Sid
         * 
         * @param sid Fetch by unique Account Sid
         * @return AccountFetcher capable of executing the fetch
         */
        public static AccountFetcher Fetch(string sid) {
            return new AccountFetcher(sid);
        }
    
        /**
         * Create a AccountFetcher to execute fetch.
         * 
         * @return AccountFetcher capable of executing the fetch
         */
        public static AccountFetcher Fetch() {
            return new AccountFetcher();
        }
    
        /**
         * Retrieves a collection of Accounts belonging to the account used to make the
         * request
         * 
         * @return AccountReader capable of executing the read
         */
        public static AccountReader Read() {
            return new AccountReader();
        }
    
        /**
         * Modify the properties of a given Account
         * 
         * @param sid The sid
         * @return AccountUpdater capable of executing the update
         */
        public static AccountUpdater Update(string sid) {
            return new AccountUpdater(sid);
        }
    
        /**
         * Create a AccountUpdater to execute update.
         * 
         * @return AccountUpdater capable of executing the update
         */
        public static AccountUpdater Update() {
            return new AccountUpdater();
        }
    
        /**
         * Converts a JSON string into a Account object
         * 
         * @param json Raw JSON string
         * @return Account object represented by the provided JSON
         */
        public static Account FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Account>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("auth_token")]
        private readonly string authToken;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("owner_account_sid")]
        private readonly string ownerAccountSid;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly Account.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly Account.Type type;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public Account() {
        
        }
    
        private Account([JsonProperty("auth_token")]
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
                        Account.Status status, 
                        [JsonProperty("subresource_uris")]
                        Dictionary<string, string> subresourceUris, 
                        [JsonProperty("type")]
                        Account.Type type, 
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
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this account was last updated
         */
        public DateTime? GetDateUpdated() {
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
        public override string GetSid() {
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
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The type of this account
         */
        public Account.Type GetAccountType() {
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