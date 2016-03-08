using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using java.util.List;

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
        public static ConnectAppFetcher fetch(String accountSid, String sid) {
            return new ConnectAppFetcher(accountSid, sid);
        }
    
        /**
         * Update a connect-app with the specified parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ConnectAppUpdater capable of executing the update
         */
        public static ConnectAppUpdater update(String accountSid, String sid) {
            return new ConnectAppUpdater(accountSid, sid);
        }
    
        /**
         * Retrieve a list of connect-apps belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ConnectAppReader capable of executing the read
         */
        public static ConnectAppReader read(String accountSid) {
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
        private readonly String accountSid;
        [JsonProperty("authorize_redirect_url")]
        private readonly URI authorizeRedirectUrl;
        [JsonProperty("company_name")]
        private readonly String companyName;
        [JsonProperty("deauthorize_callback_method")]
        private readonly HttpMethod deauthorizeCallbackMethod;
        [JsonProperty("deauthorize_callback_url")]
        private readonly URI deauthorizeCallbackUrl;
        [JsonProperty("description")]
        private readonly String description;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("homepage_url")]
        private readonly URI homepageUrl;
        [JsonProperty("permissions")]
        private readonly List<ConnectApp.Permission> permissions;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private ConnectApp([JsonProperty("account_sid")]
                           String accountSid, 
                           [JsonProperty("authorize_redirect_url")]
                           URI authorizeRedirectUrl, 
                           [JsonProperty("company_name")]
                           String companyName, 
                           [JsonProperty("deauthorize_callback_method")]
                           HttpMethod deauthorizeCallbackMethod, 
                           [JsonProperty("deauthorize_callback_url")]
                           URI deauthorizeCallbackUrl, 
                           [JsonProperty("description")]
                           String description, 
                           [JsonProperty("friendly_name")]
                           String friendlyName, 
                           [JsonProperty("homepage_url")]
                           URI homepageUrl, 
                           [JsonProperty("permissions")]
                           List<ConnectApp.Permission> permissions, 
                           [JsonProperty("sid")]
                           String sid, 
                           [JsonProperty("uri")]
                           String uri) {
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return URIL Twilio sends requests when users authorize
         */
        public URI GetAuthorizeRedirectUrl() {
            return this.authorizeRedirectUrl;
        }
    
        /**
         * @return The company name set for this Connect App.
         */
        public String GetCompanyName() {
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
        public URI GetDeauthorizeCallbackUrl() {
            return this.deauthorizeCallbackUrl;
        }
    
        /**
         * @return A more detailed human readable description
         */
        public String GetDescription() {
            return this.description;
        }
    
        /**
         * @return A human readable name for the Connect App.
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The URL users can obtain more information
         */
        public URI GetHomepageUrl() {
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
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}