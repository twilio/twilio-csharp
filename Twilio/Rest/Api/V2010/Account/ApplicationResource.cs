using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ApplicationResource : Resource 
    {
        /// <summary>
        /// Create a new application within your account
        /// </summary>
        ///
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="apiVersion"> The API version to use </param>
        /// <param name="voiceUrl"> URL Twilio will make requests to when relieving a call </param>
        /// <param name="voiceMethod"> HTTP method to use with the URL </param>
        /// <param name="voiceFallbackUrl"> Fallback URL </param>
        /// <param name="voiceFallbackMethod"> HTTP method to use with the fallback url </param>
        /// <param name="statusCallback"> URL to hit with status updates </param>
        /// <param name="statusCallbackMethod"> HTTP method to use with the status callback </param>
        /// <param name="voiceCallerIdLookup"> True or False </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="smsMethod"> HTTP method to use with sms_url </param>
        /// <param name="smsFallbackUrl"> Fallback URL if there's an error parsing TwiML </param>
        /// <param name="smsFallbackMethod"> HTTP method to use with sms_fallback_method </param>
        /// <param name="smsStatusCallback"> URL Twilio with request with status updates </param>
        /// <param name="messageStatusCallback"> URL to make requests to with status updates </param>
        /// <returns> ApplicationCreator capable of executing the create </returns> 
        public static ApplicationCreator Creator(string friendlyName, string accountSid=null, string apiVersion=null, Uri voiceUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, bool? voiceCallerIdLookup=null, Uri smsUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsStatusCallback=null, Uri messageStatusCallback=null)
        {
            return new ApplicationCreator(friendlyName, accountSid:accountSid, apiVersion:apiVersion, voiceUrl:voiceUrl, voiceMethod:voiceMethod, voiceFallbackUrl:voiceFallbackUrl, voiceFallbackMethod:voiceFallbackMethod, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod, voiceCallerIdLookup:voiceCallerIdLookup, smsUrl:smsUrl, smsMethod:smsMethod, smsFallbackUrl:smsFallbackUrl, smsFallbackMethod:smsFallbackMethod, smsStatusCallback:smsStatusCallback, messageStatusCallback:messageStatusCallback);
        }
    
        /// <summary>
        /// Delete the application by the specified application sid
        /// </summary>
        ///
        /// <param name="sid"> The application sid to delete </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ApplicationDeleter capable of executing the delete </returns> 
        public static ApplicationDeleter Deleter(string sid, string accountSid=null)
        {
            return new ApplicationDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Fetch the application specified by the provided sid
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Application Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ApplicationFetcher capable of executing the fetch </returns> 
        public static ApplicationFetcher Fetcher(string sid, string accountSid=null)
        {
            return new ApplicationFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieve a list of applications representing an application within the requesting account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <returns> ApplicationReader capable of executing the read </returns> 
        public static ApplicationReader Reader(string accountSid=null, string friendlyName=null)
        {
            return new ApplicationReader(accountSid:accountSid, friendlyName:friendlyName);
        }
    
        /// <summary>
        /// Updates the application's properties
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <param name="apiVersion"> The API version to use </param>
        /// <param name="voiceUrl"> URL Twilio will make requests to when relieving a call </param>
        /// <param name="voiceMethod"> HTTP method to use with the URL </param>
        /// <param name="voiceFallbackUrl"> Fallback URL </param>
        /// <param name="voiceFallbackMethod"> HTTP method to use with the fallback url </param>
        /// <param name="statusCallback"> URL to hit with status updates </param>
        /// <param name="statusCallbackMethod"> HTTP method to use with the status callback </param>
        /// <param name="voiceCallerIdLookup"> True or False </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="smsMethod"> HTTP method to use with sms_url </param>
        /// <param name="smsFallbackUrl"> Fallback URL if there's an error parsing TwiML </param>
        /// <param name="smsFallbackMethod"> HTTP method to use with sms_fallback_method </param>
        /// <param name="smsStatusCallback"> URL Twilio with request with status updates </param>
        /// <param name="messageStatusCallback"> URL to make requests to with status updates </param>
        /// <returns> ApplicationUpdater capable of executing the update </returns> 
        public static ApplicationUpdater Updater(string sid, string accountSid=null, string friendlyName=null, string apiVersion=null, Uri voiceUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, bool? voiceCallerIdLookup=null, Uri smsUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsStatusCallback=null, Uri messageStatusCallback=null)
        {
            return new ApplicationUpdater(sid, accountSid:accountSid, friendlyName:friendlyName, apiVersion:apiVersion, voiceUrl:voiceUrl, voiceMethod:voiceMethod, voiceFallbackUrl:voiceFallbackUrl, voiceFallbackMethod:voiceFallbackMethod, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod, voiceCallerIdLookup:voiceCallerIdLookup, smsUrl:smsUrl, smsMethod:smsMethod, smsFallbackUrl:smsFallbackUrl, smsFallbackMethod:smsFallbackMethod, smsStatusCallback:smsStatusCallback, messageStatusCallback:messageStatusCallback);
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
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("message_status_callback")]
        public Uri messageStatusCallback { get; }
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
        [JsonProperty("sms_status_callback")]
        public Uri smsStatusCallback { get; }
        [JsonProperty("sms_url")]
        public Uri smsUrl { get; }
        [JsonProperty("status_callback")]
        public Uri statusCallback { get; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod statusCallbackMethod { get; }
        [JsonProperty("uri")]
        public string uri { get; }
        [JsonProperty("voice_caller_id_lookup")]
        public bool? voiceCallerIdLookup { get; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; }
        [JsonProperty("voice_fallback_url")]
        public Uri voiceFallbackUrl { get; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceMethod { get; }
        [JsonProperty("voice_url")]
        public Uri voiceUrl { get; }
    
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
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.messageStatusCallback = messageStatusCallback;
            this.sid = sid;
            this.smsFallbackMethod = smsFallbackMethod;
            this.smsFallbackUrl = smsFallbackUrl;
            this.smsMethod = smsMethod;
            this.smsStatusCallback = smsStatusCallback;
            this.smsUrl = smsUrl;
            this.statusCallback = statusCallback;
            this.statusCallbackMethod = statusCallbackMethod;
            this.uri = uri;
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.voiceMethod = voiceMethod;
            this.voiceUrl = voiceUrl;
        }
    }
}