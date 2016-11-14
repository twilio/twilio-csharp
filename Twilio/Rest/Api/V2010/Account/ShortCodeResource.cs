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
        public string AccountSid { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("short_code")]
        public string ShortCode { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
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
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            ShortCode = shortCode;
            Sid = sid;
            SmsFallbackMethod = smsFallbackMethod;
            SmsFallbackUrl = smsFallbackUrl;
            SmsMethod = smsMethod;
            SmsUrl = smsUrl;
            Uri = uri;
        }
    }
}