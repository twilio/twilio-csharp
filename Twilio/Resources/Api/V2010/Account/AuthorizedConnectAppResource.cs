using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class AuthorizedConnectAppResource : SidResource {
        public sealed class Permission {
            public const string GET_ALL="get-all";
            public const string POST_ALL="post-all";
        
            private readonly string value;
            
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
        }
    
        /**
         * Fetch an instance of an authorized-connect-app
         * 
         * @param accountSid The account_sid
         * @param connectAppSid The connect_app_sid
         * @return AuthorizedConnectAppFetcher capable of executing the fetch
         */
        public static AuthorizedConnectAppFetcher Fetch(string accountSid, string connectAppSid) {
            return new AuthorizedConnectAppFetcher(accountSid, connectAppSid);
        }
    
        /**
         * Retrieve a list of authorized-connect-apps belonging to the account used to
         * make the request
         * 
         * @param accountSid The account_sid
         * @return AuthorizedConnectAppReader capable of executing the read
         */
        public static AuthorizedConnectAppReader Read(string accountSid) {
            return new AuthorizedConnectAppReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a AuthorizedConnectAppResource object
         * 
         * @param json Raw JSON string
         * @return AuthorizedConnectAppResource object represented by the provided JSON
         */
        public static AuthorizedConnectAppResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AuthorizedConnectAppResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("connect_app_company_name")]
        private readonly string connectAppCompanyName;
        [JsonProperty("connect_app_description")]
        private readonly string connectAppDescription;
        [JsonProperty("connect_app_friendly_name")]
        private readonly string connectAppFriendlyName;
        [JsonProperty("connect_app_homepage_url")]
        private readonly Uri connectAppHomepageUrl;
        [JsonProperty("connect_app_sid")]
        private readonly string connectAppSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("permissions")]
        private readonly List<AuthorizedConnectAppResource.Permission> permissions;
        [JsonProperty("uri")]
        private readonly string uri;
    
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
    
        /**
         * @return A string that uniquely identifies this app
         */
        public override string GetSid() {
            return this.GetConnectAppSid();
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The company name set for this Connect App.
         */
        public string GetConnectAppCompanyName() {
            return this.connectAppCompanyName;
        }
    
        /**
         * @return Human readable description of the app
         */
        public string GetConnectAppDescription() {
            return this.connectAppDescription;
        }
    
        /**
         * @return A human readable name for the Connect App.
         */
        public string GetConnectAppFriendlyName() {
            return this.connectAppFriendlyName;
        }
    
        /**
         * @return The public URL for this Connect App.
         */
        public Uri GetConnectAppHomepageUrl() {
            return this.connectAppHomepageUrl;
        }
    
        /**
         * @return A string that uniquely identifies this app
         */
        public string GetConnectAppSid() {
            return this.connectAppSid;
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
         * @return Permissions authorized to this app
         */
        public List<AuthorizedConnectAppResource.Permission> GetPermissions() {
            return this.permissions;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}