using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sms;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sms;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sms;

namespace Twilio.Resources.Api.V2010.Account.Sms {

    public class ShortCodeResource : SidResource {
        /**
         * Fetch an instance of a short code
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique short-code Sid
         * @return ShortCodeFetcher capable of executing the fetch
         */
        public static ShortCodeFetcher fetch(string accountSid, string sid) {
            return new ShortCodeFetcher(accountSid, sid);
        }
    
        /**
         * Update a short code with the following parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ShortCodeUpdater capable of executing the update
         */
        public static ShortCodeUpdater update(string accountSid, string sid) {
            return new ShortCodeUpdater(accountSid, sid);
        }
    
        /**
         * Retrieve a list of short-codes belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ShortCodeReader capable of executing the read
         */
        public static ShortCodeReader read(string accountSid) {
            return new ShortCodeReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a ShortCodeResource object
         * 
         * @param json Raw JSON string
         * @return ShortCodeResource object represented by the provided JSON
         */
        public static ShortCodeResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ShortCodeResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("short_code")]
        private readonly string shortCode;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("sms_fallback_method")]
        private readonly System.Net.Http.HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly Uri smsFallbackUrl;
        [JsonProperty("sms_method")]
        private readonly System.Net.Http.HttpMethod smsMethod;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private ShortCodeResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("api_version")]
                                  string apiVersion, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("short_code")]
                                  string shortCode, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("sms_fallback_method")]
                                  System.Net.Http.HttpMethod smsFallbackMethod, 
                                  [JsonProperty("sms_fallback_url")]
                                  Uri smsFallbackUrl, 
                                  [JsonProperty("sms_method")]
                                  System.Net.Http.HttpMethod smsMethod, 
                                  [JsonProperty("sms_url")]
                                  Uri smsUrl, 
                                  [JsonProperty("uri")]
                                  string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.shortCode = shortCode;
            this.sid = sid;
            this.smsFallbackMethod = smsFallbackMethod;
            this.smsFallbackUrl = smsFallbackUrl;
            this.smsMethod = smsMethod;
            this.smsUrl = smsUrl;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The API version to use
         */
        public string GetApiVersion() {
            return this.apiVersion;
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
         * @return A human readable description of this resource
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The short code. e.g., 894546.
         */
        public string GetShortCode() {
            return this.shortCode;
        }
    
        /**
         * @return A string that uniquely identifies this short-codes
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return HTTP method Twilio will use with sms fallback url
         */
        public System.Net.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /**
         * @return URL Twilio will request if an error occurs in executing TwiML
         */
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /**
         * @return HTTP method to use when requesting the sms url
         */
        public System.Net.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return URL Twilio will request when receiving an SMS
         */
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}