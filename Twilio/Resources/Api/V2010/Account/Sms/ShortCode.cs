using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sms;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sms;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sms;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sms {

    public class ShortCode : SidResource {
        /**
         * Fetch an instance of a short code
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique short-code Sid
         * @return ShortCodeFetcher capable of executing the fetch
         */
        public static ShortCodeFetcher fetch(String accountSid, String sid) {
            return new ShortCodeFetcher(accountSid, sid);
        }
    
        /**
         * Update a short code with the following parameters
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ShortCodeUpdater capable of executing the update
         */
        public static ShortCodeUpdater update(String accountSid, String sid) {
            return new ShortCodeUpdater(accountSid, sid);
        }
    
        /**
         * Retrieve a list of short-codes belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ShortCodeReader capable of executing the read
         */
        public static ShortCodeReader read(String accountSid) {
            return new ShortCodeReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a ShortCode object
         * 
         * @param json Raw JSON string
         * @return ShortCode object represented by the provided JSON
         */
        public static ShortCode fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ShortCode>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("short_code")]
        private readonly String shortCode;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("sms_fallback_method")]
        private readonly HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly URI smsFallbackUrl;
        [JsonProperty("sms_method")]
        private readonly HttpMethod smsMethod;
        [JsonProperty("sms_url")]
        private readonly URI smsUrl;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private ShortCode([JsonProperty("account_sid")]
                          String accountSid, 
                          [JsonProperty("api_version")]
                          String apiVersion, 
                          [JsonProperty("date_created")]
                          String dateCreated, 
                          [JsonProperty("date_updated")]
                          String dateUpdated, 
                          [JsonProperty("friendly_name")]
                          String friendlyName, 
                          [JsonProperty("short_code")]
                          String shortCode, 
                          [JsonProperty("sid")]
                          String sid, 
                          [JsonProperty("sms_fallback_method")]
                          HttpMethod smsFallbackMethod, 
                          [JsonProperty("sms_fallback_url")]
                          URI smsFallbackUrl, 
                          [JsonProperty("sms_method")]
                          HttpMethod smsMethod, 
                          [JsonProperty("sms_url")]
                          URI smsUrl, 
                          [JsonProperty("uri")]
                          String uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The API version to use
         */
        public String GetApiVersion() {
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
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The short code. e.g., 894546.
         */
        public String GetShortCode() {
            return this.shortCode;
        }
    
        /**
         * @return A string that uniquely identifies this short-codes
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return HTTP method Twilio will use with sms fallback url
         */
        public HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /**
         * @return URL Twilio will request if an error occurs in executing TwiML
         */
        public URI GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /**
         * @return HTTP method to use when requesting the sms url
         */
        public HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return URL Twilio will request when receiving an SMS
         */
        public URI GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}