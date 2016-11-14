using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class SandboxResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <returns> SandboxFetcher capable of executing the fetch </returns> 
        public static SandboxFetcher Fetcher()
        {
            return new SandboxFetcher();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <returns> SandboxUpdater capable of executing the update </returns> 
        public static SandboxUpdater Updater()
        {
            return new SandboxUpdater();
        }
    
        /// <summary>
        /// Converts a JSON string into a SandboxResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SandboxResource object represented by the provided JSON </returns> 
        public static SandboxResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SandboxResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("pin")]
        public int? Pin { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber PhoneNumber { get; set; }
        [JsonProperty("application_sid")]
        public string ApplicationSid { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        [JsonProperty("uri")]
        public Uri Uri { get; set; }
    
        public SandboxResource()
        {
        
        }
    
        private SandboxResource([JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("pin")]
                                int? pin, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("phone_number")]
                                Twilio.Types.PhoneNumber phoneNumber, 
                                [JsonProperty("application_sid")]
                                string applicationSid, 
                                [JsonProperty("api_version")]
                                string apiVersion, 
                                [JsonProperty("voice_url")]
                                Uri voiceUrl, 
                                [JsonProperty("voice_method")]
                                Twilio.Http.HttpMethod voiceMethod, 
                                [JsonProperty("sms_url")]
                                Uri smsUrl, 
                                [JsonProperty("sms_method")]
                                Twilio.Http.HttpMethod smsMethod, 
                                [JsonProperty("status_callback")]
                                Uri statusCallback, 
                                [JsonProperty("status_callback_method")]
                                Twilio.Http.HttpMethod statusCallbackMethod, 
                                [JsonProperty("uri")]
                                Uri uri)
                                {
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Pin = pin;
            AccountSid = accountSid;
            PhoneNumber = phoneNumber;
            ApplicationSid = applicationSid;
            ApiVersion = apiVersion;
            VoiceUrl = voiceUrl;
            VoiceMethod = voiceMethod;
            SmsUrl = smsUrl;
            SmsMethod = smsMethod;
            StatusCallback = statusCallback;
            StatusCallbackMethod = statusCallbackMethod;
            Uri = uri;
        }
    }
}