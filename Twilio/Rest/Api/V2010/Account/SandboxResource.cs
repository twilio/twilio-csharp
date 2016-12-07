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

    public class SandboxResource : Resource 
    {
        private static Request BuildFetchRequest(FetchSandboxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Sandbox.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static SandboxResource Fetch(FetchSandboxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SandboxResource> FetchAsync(FetchSandboxOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static SandboxResource Fetch(string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchSandboxOptions{AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SandboxResource> FetchAsync(string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchSandboxOptions{AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateSandboxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Sandbox.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static SandboxResource Update(UpdateSandboxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SandboxResource> UpdateAsync(UpdateSandboxOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static SandboxResource Update(string accountSid = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateSandboxOptions{AccountSid = accountSid, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, SmsUrl = smsUrl, SmsMethod = smsMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SandboxResource> UpdateAsync(string accountSid = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateSandboxOptions{AccountSid = accountSid, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, SmsUrl = smsUrl, SmsMethod = smsMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
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
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("pin")]
        public int? Pin { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        [JsonProperty("application_sid")]
        public string ApplicationSid { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; private set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; private set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; private set; }
        [JsonProperty("uri")]
        public Uri Uri { get; private set; }
    
        private SandboxResource()
        {
        
        }
    }

}