using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010 {

    public class AccountResource : SidResource {
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
    
        /// <summary>
        /// Create a new Twilio Subaccount from the account making the request
        /// </summary>
        ///
        /// <returns> AccountCreator capable of executing the create </returns> 
        public static AccountCreator Creator() {
            return new AccountCreator();
        }
    
        /// <summary>
        /// Fetch the account specified by the provided Account Sid
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Account Sid </param>
        /// <returns> AccountFetcher capable of executing the fetch </returns> 
        public static AccountFetcher Fetcher(string sid) {
            return new AccountFetcher(sid);
        }
    
        /// <summary>
        /// Create a AccountFetcher to execute fetch.
        /// </summary>
        ///
        /// <returns> AccountFetcher capable of executing the fetch </returns> 
        public static AccountFetcher Fetcher() {
            return new AccountFetcher();
        }
    
        /// <summary>
        /// Retrieves a collection of Accounts belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> AccountReader capable of executing the read </returns> 
        public static AccountReader Reader() {
            return new AccountReader();
        }
    
        /// <summary>
        /// Modify the properties of a given Account
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AccountUpdater capable of executing the update </returns> 
        public static AccountUpdater Updater(string sid) {
            return new AccountUpdater(sid);
        }
    
        /// <summary>
        /// Create a AccountUpdater to execute update.
        /// </summary>
        ///
        /// <returns> AccountUpdater capable of executing the update </returns> 
        public static AccountUpdater Updater() {
            return new AccountUpdater();
        }
    
        /// <summary>
        /// Converts a JSON string into a AccountResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AccountResource object represented by the provided JSON </returns> 
        public static AccountResource FromJson(string json) {
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
        private readonly AccountResource.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly AccountResource.Type type;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public AccountResource() {
        
        }
    
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
    
        /// <returns> The authorization token for this account </returns> 
        public string GetAuthToken() {
            return this.authToken;
        }
    
        /// <returns> The date this account was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this account was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A human readable description of this account </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The unique 34 character id representing the parent of this account </returns> 
        public string GetOwnerAccountSid() {
            return this.ownerAccountSid;
        }
    
        /// <returns> A 34 character string that uniquely identifies this resource. </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The status of this account </returns> 
        public AccountResource.Status GetStatus() {
            return this.status;
        }
    
        /// <returns> Account Instance Subresources </returns> 
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /// <returns> The type of this account </returns> 
        public AccountResource.Type GetAccountType() {
            return this.type;
        }
    
        /// <returns> The URI for this resource, relative to `https://api.twilio.com` </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}