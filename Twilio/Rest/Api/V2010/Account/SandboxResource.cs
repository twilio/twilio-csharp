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
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SandboxFetcher capable of executing the fetch </returns> 
        public static SandboxFetcher Fetcher(string accountSid=null)
        {
            return new SandboxFetcher(accountSid:accountSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="voiceUrl"> The voice_url </param>
        /// <param name="voiceMethod"> The voice_method </param>
        /// <param name="smsUrl"> The sms_url </param>
        /// <param name="smsMethod"> The sms_method </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <returns> SandboxUpdater capable of executing the update </returns> 
        public static SandboxUpdater Updater(string accountSid=null, Uri voiceUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri smsUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null)
        {
            return new SandboxUpdater(accountSid:accountSid, voiceUrl:voiceUrl, voiceMethod:voiceMethod, smsUrl:smsUrl, smsMethod:smsMethod, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod);
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
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("pin")]
        public int? pin { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        [JsonProperty("application_sid")]
        public string applicationSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("voice_url")]
        public Uri voiceUrl { get; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceMethod { get; }
        [JsonProperty("sms_url")]
        public Uri smsUrl { get; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsMethod { get; }
        [JsonProperty("status_callback")]
        public Uri statusCallback { get; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod statusCallbackMethod { get; }
        [JsonProperty("uri")]
        public Uri uri { get; }
    
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
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.pin = pin;
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.applicationSid = applicationSid;
            this.apiVersion = apiVersion;
            this.voiceUrl = voiceUrl;
            this.voiceMethod = voiceMethod;
            this.smsUrl = smsUrl;
            this.smsMethod = smsMethod;
            this.statusCallback = statusCallback;
            this.statusCallbackMethod = statusCallbackMethod;
            this.uri = uri;
        }
    }
}