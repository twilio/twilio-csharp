using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class TollFreeResource : Resource 
    {
        public sealed class AddressRequirementEnum : StringEnum 
        {
            private AddressRequirementEnum(string value) : base(value) {}
            public AddressRequirementEnum() {}
        
            public static readonly AddressRequirementEnum None = new AddressRequirementEnum("none");
            public static readonly AddressRequirementEnum Any = new AddressRequirementEnum("any");
            public static readonly AddressRequirementEnum Local = new AddressRequirementEnum("local");
            public static readonly AddressRequirementEnum Foreign = new AddressRequirementEnum("foreign");
        }
    
        private static Request BuildReadRequest(ReadTollFreeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers/TollFree.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TollFreeResource> Read(ReadTollFreeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TollFreeResource>.FromJson("incoming_phone_numbers", response.Content);
            return new ResourceSet<TollFreeResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TollFreeResource>> ReadAsync(ReadTollFreeOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TollFreeResource> Read(string ownerAccountSid = null, bool? beta = null, string friendlyName = null, Types.PhoneNumber phoneNumber = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTollFreeOptions{OwnerAccountSid = ownerAccountSid, Beta = beta, FriendlyName = friendlyName, PhoneNumber = phoneNumber, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TollFreeResource>> ReadAsync(string ownerAccountSid = null, bool? beta = null, string friendlyName = null, Types.PhoneNumber phoneNumber = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTollFreeOptions{OwnerAccountSid = ownerAccountSid, Beta = beta, FriendlyName = friendlyName, PhoneNumber = phoneNumber, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<TollFreeResource> NextPage(Page<TollFreeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TollFreeResource>.FromJson("incoming_phone_numbers", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateTollFreeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers/TollFree.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static TollFreeResource Create(CreateTollFreeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TollFreeResource> CreateAsync(CreateTollFreeOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static TollFreeResource Create(Types.PhoneNumber phoneNumber, string ownerAccountSid = null, string apiVersion = null, string friendlyName = null, string smsApplicationSid = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsUrl = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string voiceApplicationSid = null, bool? voiceCallerIdLookup = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceUrl = null, ITwilioRestClient client = null)
        {
            var options = new CreateTollFreeOptions(phoneNumber){OwnerAccountSid = ownerAccountSid, ApiVersion = apiVersion, FriendlyName = friendlyName, SmsApplicationSid = smsApplicationSid, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, VoiceApplicationSid = voiceApplicationSid, VoiceCallerIdLookup = voiceCallerIdLookup, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TollFreeResource> CreateAsync(Types.PhoneNumber phoneNumber, string ownerAccountSid = null, string apiVersion = null, string friendlyName = null, string smsApplicationSid = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsUrl = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string voiceApplicationSid = null, bool? voiceCallerIdLookup = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceUrl = null, ITwilioRestClient client = null)
        {
            var options = new CreateTollFreeOptions(phoneNumber){OwnerAccountSid = ownerAccountSid, ApiVersion = apiVersion, FriendlyName = friendlyName, SmsApplicationSid = smsApplicationSid, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, VoiceApplicationSid = voiceApplicationSid, VoiceCallerIdLookup = voiceCallerIdLookup, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TollFreeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TollFreeResource object represented by the provided JSON </returns> 
        public static TollFreeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TollFreeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TollFreeResource.AddressRequirementEnum AddressRequirements { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("beta")]
        public bool? Beta { get; private set; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities Capabilities { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("sms_application_sid")]
        public string SmsApplicationSid { get; private set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; private set; }
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; private set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; private set; }
        [JsonProperty("trunk_sid")]
        public string TrunkSid { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
        [JsonProperty("voice_application_sid")]
        public string VoiceApplicationSid { get; private set; }
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
    
        private TollFreeResource()
        {
        
        }
    }

}