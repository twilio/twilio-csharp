using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

    public class ConnectApp : SidResource {
        public enum Permission {
            GET_ALL="get-all",
            POST_ALL="post-all"
        };
    
        /**
         * Fetch an instance of a connect-app
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique connect-app Sid
         * @return ConnectAppFetcher capable of executing the fetch
         */
        public static ConnectAppFetcher fetch(string accountSid, string sid) {
            return new ConnectAppFetcher(accountSid, sid);
        }
    
        /**
         * Update a connect-app with the specified parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ConnectAppUpdater capable of executing the update
         */
        public static ConnectAppUpdater update(string accountSid, string sid) {
            return new ConnectAppUpdater(accountSid, sid);
        }
    
        /**
         * Retrieve a list of connect-apps belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ConnectAppReader capable of executing the read
         */
        public static ConnectAppReader read(string accountSid) {
            return new ConnectAppReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a ConnectApp object
         * 
         * @param json Raw JSON string
         * @return ConnectApp object represented by the provided JSON
         */
        public static ConnectApp fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConnectApp>(json);
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
        private readonly HttpMethod deauthorizeCallbackMethod;
        [JsonProperty("deauthorize_callback_url")]
        private readonly Uri deauthorizeCallbackUrl;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("homepage_url")]
        private readonly Uri homepageUrl;
        [JsonProperty("permissions")]
        private readonly List<ConnectApp.Permission> permissions;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private ConnectApp([JsonProperty("account_sid")]
                           string accountSid, 
                           [JsonProperty("authorize_redirect_url")]
                           Uri authorizeRedirectUrl, 
                           [JsonProperty("company_name")]
                           string companyName, 
                           [JsonProperty("deauthorize_callback_method")]
                           HttpMethod deauthorizeCallbackMethod, 
                           [JsonProperty("deauthorize_callback_url")]
                           Uri deauthorizeCallbackUrl, 
                           [JsonProperty("description")]
                           string description, 
                           [JsonProperty("friendly_name")]
                           string friendlyName, 
                           [JsonProperty("homepage_url")]
                           Uri homepageUrl, 
                           [JsonProperty("permissions")]
                           List<ConnectApp.Permission> permissions, 
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
        public HttpMethod GetDeauthorizeCallbackMethod() {
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
        public List<ConnectApp.Permission> GetPermissions() {
            return this.permissions;
        }
    
        /**
         * @return A string that uniquely identifies this connect-apps
         */
        public string GetSid() {
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