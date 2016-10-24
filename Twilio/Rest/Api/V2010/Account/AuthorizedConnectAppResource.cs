using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class AuthorizedConnectAppResource : Resource {
        public sealed class Permission : IStringEnum {
            public const string GET_ALL="get-all";
            public const string POST_ALL="post-all";
        
            private string value;
            
            public Permission() { }
            
            public Permission(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Permission(string value) {
                return new Permission(value);
            }
            
            public static implicit operator string(Permission value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of an authorized-connect-app
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="connectAppSid"> The connect_app_sid </param>
        /// <returns> AuthorizedConnectAppFetcher capable of executing the fetch </returns> 
        public static AuthorizedConnectAppFetcher Fetcher(string accountSid, string connectAppSid) {
            return new AuthorizedConnectAppFetcher(accountSid, connectAppSid);
        }
    
        /// <summary>
        /// Create a AuthorizedConnectAppFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="connectAppSid"> The connect_app_sid </param>
        /// <returns> AuthorizedConnectAppFetcher capable of executing the fetch </returns> 
        public static AuthorizedConnectAppFetcher Fetcher(string connectAppSid) {
            return new AuthorizedConnectAppFetcher(connectAppSid);
        }
    
        /// <summary>
        /// Retrieve a list of authorized-connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> AuthorizedConnectAppReader capable of executing the read </returns> 
        public static AuthorizedConnectAppReader Reader(string accountSid) {
            return new AuthorizedConnectAppReader(accountSid);
        }
    
        /// <summary>
        /// Create a AuthorizedConnectAppReader to execute read.
        /// </summary>
        ///
        /// <returns> AuthorizedConnectAppReader capable of executing the read </returns> 
        public static AuthorizedConnectAppReader Reader() {
            return new AuthorizedConnectAppReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a AuthorizedConnectAppResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AuthorizedConnectAppResource object represented by the provided JSON </returns> 
        public static AuthorizedConnectAppResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AuthorizedConnectAppResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("connect_app_company_name")]
        public string connectAppCompanyName { get; }
        [JsonProperty("connect_app_description")]
        public string connectAppDescription { get; }
        [JsonProperty("connect_app_friendly_name")]
        public string connectAppFriendlyName { get; }
        [JsonProperty("connect_app_homepage_url")]
        public Uri connectAppHomepageUrl { get; }
        [JsonProperty("connect_app_sid")]
        public string connectAppSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<AuthorizedConnectAppResource.Permission> permissions { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public AuthorizedConnectAppResource() {
        
        }
    
        private AuthorizedConnectAppResource([JsonProperty("account_sid")]
                                             string accountSid, 
                                             [JsonProperty("connect_app_company_name")]
                                             string connectAppCompanyName, 
                                             [JsonProperty("connect_app_description")]
                                             string connectAppDescription, 
                                             [JsonProperty("connect_app_friendly_name")]
                                             string connectAppFriendlyName, 
                                             [JsonProperty("connect_app_homepage_url")]
                                             Uri connectAppHomepageUrl, 
                                             [JsonProperty("connect_app_sid")]
                                             string connectAppSid, 
                                             [JsonProperty("date_created")]
                                             string dateCreated, 
                                             [JsonProperty("date_updated")]
                                             string dateUpdated, 
                                             [JsonProperty("permissions")]
                                             List<AuthorizedConnectAppResource.Permission> permissions, 
                                             [JsonProperty("uri")]
                                             string uri) {
            this.accountSid = accountSid;
            this.connectAppCompanyName = connectAppCompanyName;
            this.connectAppDescription = connectAppDescription;
            this.connectAppFriendlyName = connectAppFriendlyName;
            this.connectAppHomepageUrl = connectAppHomepageUrl;
            this.connectAppSid = connectAppSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.permissions = permissions;
            this.uri = uri;
        }
    }
}