using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010 {

    public class AccountResource : Resource {
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
        /// <param name="friendlyName"> A human readable description of the account </param>
        /// <returns> AccountCreator capable of executing the create </returns> 
        public static AccountCreator Creator(string friendlyName=null) {
            return new AccountCreator(friendlyName:friendlyName);
        }
    
        /// <summary>
        /// Fetch the account specified by the provided Account Sid
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Account Sid </param>
        /// <returns> AccountFetcher capable of executing the fetch </returns> 
        public static AccountFetcher Fetcher(string sid=null) {
            return new AccountFetcher(sid:sid);
        }
    
        /// <summary>
        /// Retrieves a collection of Accounts belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="friendlyName"> FriendlyName to filter on </param>
        /// <param name="status"> Status to filter on </param>
        /// <returns> AccountReader capable of executing the read </returns> 
        public static AccountReader Reader(string friendlyName=null, AccountResource.Status status=null) {
            return new AccountReader(friendlyName:friendlyName, status:status);
        }
    
        /// <summary>
        /// Modify the properties of a given Account
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> FriendlyName to update </param>
        /// <param name="status"> Status to update the Account with </param>
        /// <returns> AccountUpdater capable of executing the update </returns> 
        public static AccountUpdater Updater(string sid=null, string friendlyName=null, AccountResource.Status status=null) {
            return new AccountUpdater(sid:sid, friendlyName:friendlyName, status:status);
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
        public string authToken { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("owner_account_sid")]
        public string ownerAccountSid { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.Status status { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.Type type { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
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
    }
}