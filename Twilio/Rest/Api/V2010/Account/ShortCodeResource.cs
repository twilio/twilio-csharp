using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ShortCodeResource : SidResource {
        /// <summary>
        /// Fetch an instance of a short code
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique short-code Sid </param>
        /// <returns> ShortCodeFetcher capable of executing the fetch </returns> 
        public static ShortCodeFetcher Fetcher(string accountSid, string sid) {
            return new ShortCodeFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ShortCodeFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique short-code Sid </param>
        /// <returns> ShortCodeFetcher capable of executing the fetch </returns> 
        public static ShortCodeFetcher Fetcher(string sid) {
            return new ShortCodeFetcher(sid);
        }
    
        /// <summary>
        /// Update a short code with the following parameters
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ShortCodeUpdater capable of executing the update </returns> 
        public static ShortCodeUpdater Updater(string accountSid, string sid) {
            return new ShortCodeUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ShortCodeUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ShortCodeUpdater capable of executing the update </returns> 
        public static ShortCodeUpdater Updater(string sid) {
            return new ShortCodeUpdater(sid);
        }
    
        /// <summary>
        /// Retrieve a list of short-codes belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ShortCodeReader capable of executing the read </returns> 
        public static ShortCodeReader Reader(string accountSid) {
            return new ShortCodeReader(accountSid);
        }
    
        /// <summary>
        /// Create a ShortCodeReader to execute read.
        /// </summary>
        ///
        /// <returns> ShortCodeReader capable of executing the read </returns> 
        public static ShortCodeReader Reader() {
            return new ShortCodeReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a ShortCodeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ShortCodeResource object represented by the provided JSON </returns> 
        public static ShortCodeResource FromJson(string json) {
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
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("short_code")]
        private readonly string shortCode;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly Uri smsFallbackUrl;
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsMethod;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public ShortCodeResource() {
        
        }
    
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
                                  Twilio.Http.HttpMethod smsFallbackMethod, 
                                  [JsonProperty("sms_fallback_url")]
                                  Uri smsFallbackUrl, 
                                  [JsonProperty("sms_method")]
                                  Twilio.Http.HttpMethod smsMethod, 
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The API version to use </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A human readable description of this resource </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The short code. e.g., 894546. </returns> 
        public string GetShortCode() {
            return this.shortCode;
        }
    
        /// <returns> A string that uniquely identifies this short-codes </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> HTTP method Twilio will use with sms fallback url </returns> 
        public Twilio.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /// <returns> URL Twilio will request if an error occurs in executing TwiML </returns> 
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /// <returns> HTTP method to use when requesting the sms url </returns> 
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /// <returns> URL Twilio will request when receiving an SMS </returns> 
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}