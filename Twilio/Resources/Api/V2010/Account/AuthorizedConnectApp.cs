using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using java.util.List;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class AuthorizedConnectApp : SidResource {
        public enum Permission {
            GET_ALL="get-all",
            POST_ALL="post-all"
        };
    
        /**
         * Fetch an instance of an authorized-connect-app
         * 
         * @param accountSid The account_sid
         * @param connectAppSid The connect_app_sid
         * @return AuthorizedConnectAppFetcher capable of executing the fetch
         */
        public static AuthorizedConnectAppFetcher fetch(String accountSid, String connectAppSid) {
            return new AuthorizedConnectAppFetcher(accountSid, connectAppSid);
        }
    
        /**
         * Retrieve a list of authorized-connect-apps belonging to the account used to
         * make the request
         * 
         * @param accountSid The account_sid
         * @return AuthorizedConnectAppReader capable of executing the read
         */
        public static AuthorizedConnectAppReader read(String accountSid) {
            return new AuthorizedConnectAppReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a AuthorizedConnectApp object
         * 
         * @param json Raw JSON string
         * @return AuthorizedConnectApp object represented by the provided JSON
         */
        public static AuthorizedConnectApp fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AuthorizedConnectApp>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("connect_app_company_name")]
        private readonly String connectAppCompanyName;
        [JsonProperty("connect_app_description")]
        private readonly String connectAppDescription;
        [JsonProperty("connect_app_friendly_name")]
        private readonly String connectAppFriendlyName;
        [JsonProperty("connect_app_homepage_url")]
        private readonly URI connectAppHomepageUrl;
        [JsonProperty("connect_app_sid")]
        private readonly String connectAppSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("permissions")]
        private readonly List<AuthorizedConnectApp.Permission> permissions;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private AuthorizedConnectApp([JsonProperty("account_sid")]
                                     String accountSid, 
                                     [JsonProperty("connect_app_company_name")]
                                     String connectAppCompanyName, 
                                     [JsonProperty("connect_app_description")]
                                     String connectAppDescription, 
                                     [JsonProperty("connect_app_friendly_name")]
                                     String connectAppFriendlyName, 
                                     [JsonProperty("connect_app_homepage_url")]
                                     URI connectAppHomepageUrl, 
                                     [JsonProperty("connect_app_sid")]
                                     String connectAppSid, 
                                     [JsonProperty("date_created")]
                                     String dateCreated, 
                                     [JsonProperty("date_updated")]
                                     String dateUpdated, 
                                     [JsonProperty("permissions")]
                                     List<AuthorizedConnectApp.Permission> permissions, 
                                     [JsonProperty("uri")]
                                     String uri) {
            this.accountSid = accountSid;
            this.connectAppCompanyName = connectAppCompanyName;
            this.connectAppDescription = connectAppDescription;
            this.connectAppFriendlyName = connectAppFriendlyName;
            this.connectAppHomepageUrl = connectAppHomepageUrl;
            this.connectAppSid = connectAppSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.permissions = permissions;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this app
         */
        public String getSid() {
            return this.getConnectAppSid();
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The company name set for this Connect App.
         */
        public String GetConnectAppCompanyName() {
            return this.connectAppCompanyName;
        }
    
        /**
         * @return Human readable description of the app
         */
        public String GetConnectAppDescription() {
            return this.connectAppDescription;
        }
    
        /**
         * @return A human readable name for the Connect App.
         */
        public String GetConnectAppFriendlyName() {
            return this.connectAppFriendlyName;
        }
    
        /**
         * @return The public URL for this Connect App.
         */
        public URI GetConnectAppHomepageUrl() {
            return this.connectAppHomepageUrl;
        }
    
        /**
         * @return A string that uniquely identifies this app
         */
        public String GetConnectAppSid() {
            return this.connectAppSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return Permissions authorized to this app
         */
        public List<AuthorizedConnectApp.Permission> GetPermissions() {
            return this.permissions;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}