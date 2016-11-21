using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ApplicationResource : Resource 
    {
        /// <summary>
        /// Create a new application within your account
        /// </summary>
        ///
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <returns> ApplicationCreator capable of executing the create </returns> 
        public static ApplicationCreator Creator(string friendlyName)
        {
            return new ApplicationCreator(friendlyName);
        }
    
        /// <summary>
        /// Delete the application by the specified application sid
        /// </summary>
        ///
        /// <param name="sid"> The application sid to delete </param>
        /// <returns> ApplicationDeleter capable of executing the delete </returns> 
        public static ApplicationDeleter Deleter(string sid)
        {
            return new ApplicationDeleter(sid);
        }
    
        /// <summary>
        /// Fetch the application specified by the provided sid
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Application Sid </param>
        /// <returns> ApplicationFetcher capable of executing the fetch </returns> 
        public static ApplicationFetcher Fetcher(string sid)
        {
            return new ApplicationFetcher(sid);
        }
    
        /// <summary>
        /// Retrieve a list of applications representing an application within the requesting account
        /// </summary>
        ///
        /// <returns> ApplicationReader capable of executing the read </returns> 
        public static ApplicationReader Reader()
        {
            return new ApplicationReader();
        }
    
        /// <summary>
        /// Updates the application's properties
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ApplicationUpdater capable of executing the update </returns> 
        public static ApplicationUpdater Updater(string sid)
        {
            return new ApplicationUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ApplicationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ApplicationResource object represented by the provided JSON </returns> 
        public static ApplicationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResource>(json);
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
        [JsonProperty("message_status_callback")]
        public Uri MessageStatusCallback { get; set; }
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
        [JsonProperty("sms_status_callback")]
        public Uri SmsStatusCallback { get; set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; set; }
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("voice_caller_id_lookup")]
        public bool? VoiceCallerIdLookup { get; set; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        [JsonProperty("voice_fallback_url")]
        public Uri VoiceFallbackUrl { get; set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; set; }
    
        public ApplicationResource()
        {
        
        }
    
        private ApplicationResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("api_version")]
                                    string apiVersion, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("friendly_name")]
                                    string friendlyName, 
                                    [JsonProperty("message_status_callback")]
                                    Uri messageStatusCallback, 
                                    [JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("sms_fallback_method")]
                                    Twilio.Http.HttpMethod smsFallbackMethod, 
                                    [JsonProperty("sms_fallback_url")]
                                    Uri smsFallbackUrl, 
                                    [JsonProperty("sms_method")]
                                    Twilio.Http.HttpMethod smsMethod, 
                                    [JsonProperty("sms_status_callback")]
                                    Uri smsStatusCallback, 
                                    [JsonProperty("sms_url")]
                                    Uri smsUrl, 
                                    [JsonProperty("status_callback")]
                                    Uri statusCallback, 
                                    [JsonProperty("status_callback_method")]
                                    Twilio.Http.HttpMethod statusCallbackMethod, 
                                    [JsonProperty("uri")]
                                    string uri, 
                                    [JsonProperty("voice_caller_id_lookup")]
                                    bool? voiceCallerIdLookup, 
                                    [JsonProperty("voice_fallback_method")]
                                    Twilio.Http.HttpMethod voiceFallbackMethod, 
                                    [JsonProperty("voice_fallback_url")]
                                    Uri voiceFallbackUrl, 
                                    [JsonProperty("voice_method")]
                                    Twilio.Http.HttpMethod voiceMethod, 
                                    [JsonProperty("voice_url")]
                                    Uri voiceUrl)
                                    {
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            MessageStatusCallback = messageStatusCallback;
            Sid = sid;
            SmsFallbackMethod = smsFallbackMethod;
            SmsFallbackUrl = smsFallbackUrl;
            SmsMethod = smsMethod;
            SmsStatusCallback = smsStatusCallback;
            SmsUrl = smsUrl;
            StatusCallback = statusCallback;
            StatusCallbackMethod = statusCallbackMethod;
            Uri = uri;
            VoiceCallerIdLookup = voiceCallerIdLookup;
            VoiceFallbackMethod = voiceFallbackMethod;
            VoiceFallbackUrl = voiceFallbackUrl;
            VoiceMethod = voiceMethod;
            VoiceUrl = voiceUrl;
        }
    }
}