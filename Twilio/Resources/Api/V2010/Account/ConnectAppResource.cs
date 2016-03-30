using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

    public class ConnectAppResource : SidResource {
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
         * Fetch an instance of a connect-app
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique connect-app Sid
         * @return ConnectAppFetcher capable of executing the fetch
         */
        public static ConnectAppFetcher Fetch(string accountSid, string sid) {
            return new ConnectAppFetcher(accountSid, sid);
        }
    
        /**
         * Update a connect-app with the specified parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ConnectAppUpdater capable of executing the update
         */
        public static ConnectAppUpdater Update(string accountSid, string sid) {
            return new ConnectAppUpdater(accountSid, sid);
        }
    
        /**
         * Retrieve a list of connect-apps belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ConnectAppReader capable of executing the read
         */
        public static ConnectAppReader Read(string accountSid) {
            return new ConnectAppReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a ConnectAppResource object
         * 
         * @param json Raw JSON string
         * @return ConnectAppResource object represented by the provided JSON
         */
        public static ConnectAppResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConnectAppResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("authorize_redirect_url")]
        private readonly Uri authorizeRedirectUrl;
        [JsonProperty("company_name")]
        private readonly string companyName;
        [JsonProperty("deauthorize_callback_method")]
        private readonly System.Net.Http.HttpMethod deauthorizeCallbackMethod;
        [JsonProperty("deauthorize_callback_url")]
        private readonly Uri deauthorizeCallbackUrl;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("homepage_url")]
        private readonly Uri homepageUrl;
        [JsonProperty("permissions")]
        private readonly List<ConnectAppResource.Permission> permissions;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private ConnectAppResource([JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("authorize_redirect_url")]
                                   Uri authorizeRedirectUrl, 
                                   [JsonProperty("company_name")]
                                   string companyName, 
                                   [JsonProperty("deauthorize_callback_method")]
                                   System.Net.Http.HttpMethod deauthorizeCallbackMethod, 
                                   [JsonProperty("deauthorize_callback_url")]
                                   Uri deauthorizeCallbackUrl, 
                                   [JsonProperty("description")]
                                   string description, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("homepage_url")]
                                   Uri homepageUrl, 
                                   [JsonProperty("permissions")]
                                   List<ConnectAppResource.Permission> permissions, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("uri")]
                                   string uri) {
            this.accountSid = accountSid;
            this.authorizeRedirectUrl = authorizeRedirectUrl;
            this.companyName = companyName;
            this.deauthorizeCallbackMethod = deauthorizeCallbackMethod;
            this.deauthorizeCallbackUrl = deauthorizeCallbackUrl;
            this.description = description;
            this.friendlyName = friendlyName;
            this.homepageUrl = homepageUrl;
            this.permissions = permissions;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return URIL Twilio sends requests when users authorize
         */
        public Uri GetAuthorizeRedirectUrl() {
            return this.authorizeRedirectUrl;
        }
    
        /**
         * @return The company name set for this Connect App.
         */
        public string GetCompanyName() {
            return this.companyName;
        }
    
        /**
         * @return HTTP method Twilio WIll use making requests to the url
         */
        public System.Net.Http.HttpMethod GetDeauthorizeCallbackMethod() {
            return this.deauthorizeCallbackMethod;
        }
    
        /**
         * @return URL Twilio will send a request when a user de-authorizes this app
         */
        public Uri GetDeauthorizeCallbackUrl() {
            return this.deauthorizeCallbackUrl;
        }
    
        /**
         * @return A more detailed human readable description
         */
        public string GetDescription() {
            return this.description;
        }
    
        /**
         * @return A human readable name for the Connect App.
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The URL users can obtain more information
         */
        public Uri GetHomepageUrl() {
            return this.homepageUrl;
        }
    
        /**
         * @return The set of permissions that your ConnectApp requests.
         */
        public List<ConnectAppResource.Permission> GetPermissions() {
            return this.permissions;
        }
    
        /**
         * @return A string that uniquely identifies this connect-apps
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}