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

    /// <summary>
    /// SandboxResource
    /// </summary>
    public class SandboxResource : Resource 
    {
        private static Request BuildFetchRequest(FetchSandboxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Sandbox.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Sandbox parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sandbox </returns> 
        public static SandboxResource Fetch(FetchSandboxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Sandbox parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sandbox </returns> 
        public static async System.Threading.Tasks.Task<SandboxResource> FetchAsync(FetchSandboxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sandbox </returns> 
        public static SandboxResource Fetch(string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchSandboxOptions{PathAccountSid = pathAccountSid};
            return Fetch(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sandbox </returns> 
        public static async System.Threading.Tasks.Task<SandboxResource> FetchAsync(string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchSandboxOptions{PathAccountSid = pathAccountSid};
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateSandboxOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Sandbox.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Sandbox parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sandbox </returns> 
        public static SandboxResource Update(UpdateSandboxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Sandbox parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sandbox </returns> 
        public static async System.Threading.Tasks.Task<SandboxResource> UpdateAsync(UpdateSandboxOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="voiceUrl"> The voice_url </param>
        /// <param name="voiceMethod"> The voice_method </param>
        /// <param name="smsUrl"> The sms_url </param>
        /// <param name="smsMethod"> The sms_method </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sandbox </returns> 
        public static SandboxResource Update(string pathAccountSid = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateSandboxOptions{PathAccountSid = pathAccountSid, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, SmsUrl = smsUrl, SmsMethod = smsMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Update(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="voiceUrl"> The voice_url </param>
        /// <param name="voiceMethod"> The voice_method </param>
        /// <param name="smsUrl"> The sms_url </param>
        /// <param name="smsMethod"> The sms_method </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sandbox </returns> 
        public static async System.Threading.Tasks.Task<SandboxResource> UpdateAsync(string pathAccountSid = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateSandboxOptions{PathAccountSid = pathAccountSid, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, SmsUrl = smsUrl, SmsMethod = smsMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return await UpdateAsync(options, client);
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
    
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The pin
        /// </summary>
        [JsonProperty("pin")]
        public int? Pin { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The phone_number
        /// </summary>
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        /// <summary>
        /// The application_sid
        /// </summary>
        [JsonProperty("application_sid")]
        public string ApplicationSid { get; private set; }
        /// <summary>
        /// The api_version
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        /// <summary>
        /// The voice_url
        /// </summary>
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; private set; }
        /// <summary>
        /// The voice_method
        /// </summary>
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; private set; }
        /// <summary>
        /// The sms_url
        /// </summary>
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }
        /// <summary>
        /// The sms_method
        /// </summary>
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }
        /// <summary>
        /// The status_callback
        /// </summary>
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }
        /// <summary>
        /// The status_callback_method
        /// </summary>
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; private set; }
        /// <summary>
        /// The uri
        /// </summary>
        [JsonProperty("uri")]
        public Uri Uri { get; private set; }
    
        private SandboxResource()
        {
        
        }
    }

}