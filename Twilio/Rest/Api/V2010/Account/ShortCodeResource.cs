using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ShortCodeResource : Resource {
        /// <summary>
        /// Fetch an instance of a short code
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique short-code Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ShortCodeFetcher capable of executing the fetch </returns> 
        public static ShortCodeFetcher Fetcher(string sid, string accountSid=null) {
            return new ShortCodeFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Update a short code with the following parameters
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="apiVersion"> The API version to use </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="smsMethod"> HTTP method to use when requesting the sms url </param>
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="smsFallbackMethod"> HTTP method Twilio will use with sms fallback url </param>
        /// <returns> ShortCodeUpdater capable of executing the update </returns> 
        public static ShortCodeUpdater Updater(string sid, string accountSid=null, string friendlyName=null, string apiVersion=null, Uri smsUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsFallbackMethod=null) {
            return new ShortCodeUpdater(sid, accountSid:accountSid, friendlyName:friendlyName, apiVersion:apiVersion, smsUrl:smsUrl, smsMethod:smsMethod, smsFallbackUrl:smsFallbackUrl, smsFallbackMethod:smsFallbackMethod);
        }
    
        /// <summary>
        /// Retrieve a list of short-codes belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <param name="shortCode"> Filter by ShortCode </param>
        /// <returns> ShortCodeReader capable of executing the read </returns> 
        public static ShortCodeReader Reader(string accountSid=null, string friendlyName=null, string shortCode=null) {
            return new ShortCodeReader(accountSid:accountSid, friendlyName:friendlyName, shortCode:shortCode);
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
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("short_code")]
        public string shortCode { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsFallbackMethod { get; }
        [JsonProperty("sms_fallback_url")]
        public Uri smsFallbackUrl { get; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsMethod { get; }
        [JsonProperty("sms_url")]
        public Uri smsUrl { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
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
    }
}