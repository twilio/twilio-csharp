using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ApplicationResource : Resource 
    {
        private static Request BuildCreateRequest(CreateApplicationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Applications.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Create a new application within your account
        /// </summary>
        public static ApplicationResource Create(CreateApplicationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ApplicationResource> CreateAsync(CreateApplicationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Create a new application within your account
        /// </summary>
        public static ApplicationResource Create(string friendlyName, string accountSid = null, string apiVersion = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, bool? voiceCallerIdLookup = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsStatusCallback = null, Uri messageStatusCallback = null, ITwilioRestClient client = null)
        {
            var options = new CreateApplicationOptions(friendlyName){AccountSid = accountSid, ApiVersion = apiVersion, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceFallbackMethod = voiceFallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, VoiceCallerIdLookup = voiceCallerIdLookup, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod, SmsStatusCallback = smsStatusCallback, MessageStatusCallback = messageStatusCallback};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ApplicationResource> CreateAsync(string friendlyName, string accountSid = null, string apiVersion = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, bool? voiceCallerIdLookup = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsStatusCallback = null, Uri messageStatusCallback = null, ITwilioRestClient client = null)
        {
            var options = new CreateApplicationOptions(friendlyName){AccountSid = accountSid, ApiVersion = apiVersion, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceFallbackMethod = voiceFallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, VoiceCallerIdLookup = voiceCallerIdLookup, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod, SmsStatusCallback = smsStatusCallback, MessageStatusCallback = messageStatusCallback};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteApplicationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Applications/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete the application by the specified application sid
        /// </summary>
        public static bool Delete(DeleteApplicationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteApplicationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Delete the application by the specified application sid
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteApplicationOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteApplicationOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchApplicationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Applications/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch the application specified by the provided sid
        /// </summary>
        public static ApplicationResource Fetch(FetchApplicationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ApplicationResource> FetchAsync(FetchApplicationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch the application specified by the provided sid
        /// </summary>
        public static ApplicationResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchApplicationOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ApplicationResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchApplicationOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadApplicationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Applications.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of applications representing an application within the requesting account
        /// </summary>
        public static ResourceSet<ApplicationResource> Read(ReadApplicationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ApplicationResource>.FromJson("applications", response.Content);
            return new ResourceSet<ApplicationResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ApplicationResource>> ReadAsync(ReadApplicationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of applications representing an application within the requesting account
        /// </summary>
        public static ResourceSet<ApplicationResource> Read(string accountSid = null, string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadApplicationOptions{AccountSid = accountSid, FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ApplicationResource>> ReadAsync(string accountSid = null, string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadApplicationOptions{AccountSid = accountSid, FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<ApplicationResource> NextPage(Page<ApplicationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ApplicationResource>.FromJson("applications", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateApplicationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Applications/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Updates the application's properties
        /// </summary>
        public static ApplicationResource Update(UpdateApplicationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ApplicationResource> UpdateAsync(UpdateApplicationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Updates the application's properties
        /// </summary>
        public static ApplicationResource Update(string sid, string accountSid = null, string friendlyName = null, string apiVersion = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, bool? voiceCallerIdLookup = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsStatusCallback = null, Uri messageStatusCallback = null, ITwilioRestClient client = null)
        {
            var options = new UpdateApplicationOptions(sid){AccountSid = accountSid, FriendlyName = friendlyName, ApiVersion = apiVersion, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceFallbackMethod = voiceFallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, VoiceCallerIdLookup = voiceCallerIdLookup, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod, SmsStatusCallback = smsStatusCallback, MessageStatusCallback = messageStatusCallback};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ApplicationResource> UpdateAsync(string sid, string accountSid = null, string friendlyName = null, string apiVersion = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, bool? voiceCallerIdLookup = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsStatusCallback = null, Uri messageStatusCallback = null, ITwilioRestClient client = null)
        {
            var options = new UpdateApplicationOptions(sid){AccountSid = accountSid, FriendlyName = friendlyName, ApiVersion = apiVersion, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceFallbackMethod = voiceFallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, VoiceCallerIdLookup = voiceCallerIdLookup, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod, SmsStatusCallback = smsStatusCallback, MessageStatusCallback = messageStatusCallback};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
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
        public string AccountSid { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("message_status_callback")]
        public Uri MessageStatusCallback { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; private set; }
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; private set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }
        [JsonProperty("sms_status_callback")]
        public Uri SmsStatusCallback { get; private set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
        [JsonProperty("voice_caller_id_lookup")]
        public bool? VoiceCallerIdLookup { get; private set; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; private set; }
        [JsonProperty("voice_fallback_url")]
        public Uri VoiceFallbackUrl { get; private set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; private set; }
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; private set; }
    
        private ApplicationResource()
        {
        
        }
    }

}