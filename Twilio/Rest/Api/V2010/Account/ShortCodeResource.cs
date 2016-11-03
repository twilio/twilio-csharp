using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ShortCodeResource : Resource 
    {
        /// <summary>
        /// Fetch an instance of a short code
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique short-code Sid </param>
        /// <returns> ShortCodeFetcher capable of executing the fetch </returns> 
        public static ShortCodeFetcher Fetcher(string sid)
        {
            return new ShortCodeFetcher(sid);
        }
    
        /// <summary>
        /// Update a short code with the following parameters
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ShortCodeUpdater capable of executing the update </returns> 
        public static ShortCodeUpdater Updater(string sid)
        {
            return new ShortCodeUpdater(sid);
        }
    
        /// <summary>
        /// Retrieve a list of short-codes belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> ShortCodeReader capable of executing the read </returns> 
        public static ShortCodeReader Reader()
        {
            return new ShortCodeReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a ShortCodeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ShortCodeResource object represented by the provided JSON </returns> 
        public static ShortCodeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ShortCodeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("short_code")]
        public string shortCode { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
        [JsonProperty("sms_fallback_url")]
        public Uri smsFallbackUrl { get; set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        [JsonProperty("sms_url")]
        public Uri smsUrl { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public ShortCodeResource()
        {
        
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
                                  string uri)
                                  {
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