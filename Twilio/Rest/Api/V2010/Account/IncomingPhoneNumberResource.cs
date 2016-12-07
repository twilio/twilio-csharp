using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class IncomingPhoneNumberResource : Resource 
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
    
        public sealed class EmergencyStatusEnum : StringEnum 
        {
            private EmergencyStatusEnum(string value) : base(value) {}
            public EmergencyStatusEnum() {}
        
            public static readonly EmergencyStatusEnum Active = new EmergencyStatusEnum("Active");
            public static readonly EmergencyStatusEnum Inactive = new EmergencyStatusEnum("Inactive");
        }
    
        private static Request BuildUpdateRequest(UpdateIncomingPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update an incoming-phone-number instance
        /// </summary>
        public static IncomingPhoneNumberResource Update(UpdateIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IncomingPhoneNumberResource> UpdateAsync(UpdateIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Update an incoming-phone-number instance
        /// </summary>
        public static IncomingPhoneNumberResource Update(string sid, string ownerAccountSid = null, string accountSid = null, string apiVersion = null, string friendlyName = null, string smsApplicationSid = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsUrl = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string trunkSid = null, string voiceApplicationSid = null, bool? voiceCallerIdLookup = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceUrl = null, IncomingPhoneNumberResource.EmergencyStatusEnum emergencyStatus = null, string emergencyAddressSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateIncomingPhoneNumberOptions(sid){OwnerAccountSid = ownerAccountSid, AccountSid = accountSid, ApiVersion = apiVersion, FriendlyName = friendlyName, SmsApplicationSid = smsApplicationSid, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, TrunkSid = trunkSid, VoiceApplicationSid = voiceApplicationSid, VoiceCallerIdLookup = voiceCallerIdLookup, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl, EmergencyStatus = emergencyStatus, EmergencyAddressSid = emergencyAddressSid};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IncomingPhoneNumberResource> UpdateAsync(string sid, string ownerAccountSid = null, string accountSid = null, string apiVersion = null, string friendlyName = null, string smsApplicationSid = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsUrl = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string trunkSid = null, string voiceApplicationSid = null, bool? voiceCallerIdLookup = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceUrl = null, IncomingPhoneNumberResource.EmergencyStatusEnum emergencyStatus = null, string emergencyAddressSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateIncomingPhoneNumberOptions(sid){OwnerAccountSid = ownerAccountSid, AccountSid = accountSid, ApiVersion = apiVersion, FriendlyName = friendlyName, SmsApplicationSid = smsApplicationSid, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, TrunkSid = trunkSid, VoiceApplicationSid = voiceApplicationSid, VoiceCallerIdLookup = voiceCallerIdLookup, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl, EmergencyStatus = emergencyStatus, EmergencyAddressSid = emergencyAddressSid};
            return await UpdateAsync(options, client);
        }
        #endif
    
        private static Request BuildFetchRequest(FetchIncomingPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an incoming-phone-number belonging to the account used to make the request
        /// </summary>
        public static IncomingPhoneNumberResource Fetch(FetchIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IncomingPhoneNumberResource> FetchAsync(FetchIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch an incoming-phone-number belonging to the account used to make the request
        /// </summary>
        public static IncomingPhoneNumberResource Fetch(string sid, string ownerAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchIncomingPhoneNumberOptions(sid){OwnerAccountSid = ownerAccountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IncomingPhoneNumberResource> FetchAsync(string sid, string ownerAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchIncomingPhoneNumberOptions(sid){OwnerAccountSid = ownerAccountSid};
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteIncomingPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete a phone-numbers belonging to the account used to make the request
        /// </summary>
        public static bool Delete(DeleteIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// Delete a phone-numbers belonging to the account used to make the request
        /// </summary>
        public static bool Delete(string sid, string ownerAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteIncomingPhoneNumberOptions(sid){OwnerAccountSid = ownerAccountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string ownerAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteIncomingPhoneNumberOptions(sid){OwnerAccountSid = ownerAccountSid};
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadIncomingPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of incoming-phone-numbers belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<IncomingPhoneNumberResource> Read(ReadIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<IncomingPhoneNumberResource>.FromJson("incoming_phone_numbers", response.Content);
            return new ResourceSet<IncomingPhoneNumberResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<IncomingPhoneNumberResource>> ReadAsync(ReadIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<IncomingPhoneNumberResource>.FromJson("incoming_phone_numbers", response.Content);
            return new ResourceSet<IncomingPhoneNumberResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of incoming-phone-numbers belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<IncomingPhoneNumberResource> Read(string ownerAccountSid = null, bool? beta = null, string friendlyName = null, Types.PhoneNumber phoneNumber = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadIncomingPhoneNumberOptions{OwnerAccountSid = ownerAccountSid, Beta = beta, FriendlyName = friendlyName, PhoneNumber = phoneNumber, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<IncomingPhoneNumberResource>> ReadAsync(string ownerAccountSid = null, bool? beta = null, string friendlyName = null, Types.PhoneNumber phoneNumber = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadIncomingPhoneNumberOptions{OwnerAccountSid = ownerAccountSid, Beta = beta, FriendlyName = friendlyName, PhoneNumber = phoneNumber, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<IncomingPhoneNumberResource> NextPage(Page<IncomingPhoneNumberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<IncomingPhoneNumberResource>.FromJson("incoming_phone_numbers", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateIncomingPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.OwnerAccountSid ?? client.AccountSid) + "/IncomingPhoneNumbers.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        public static IncomingPhoneNumberResource Create(CreateIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IncomingPhoneNumberResource> CreateAsync(CreateIncomingPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        public static IncomingPhoneNumberResource Create(string ownerAccountSid = null, Types.PhoneNumber phoneNumber = null, string areaCode = null, string apiVersion = null, string friendlyName = null, string smsApplicationSid = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsUrl = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string trunkSid = null, string voiceApplicationSid = null, bool? voiceCallerIdLookup = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceUrl = null, IncomingPhoneNumberResource.EmergencyStatusEnum emergencyStatus = null, string emergencyAddressSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateIncomingPhoneNumberOptions{OwnerAccountSid = ownerAccountSid, PhoneNumber = phoneNumber, AreaCode = areaCode, ApiVersion = apiVersion, FriendlyName = friendlyName, SmsApplicationSid = smsApplicationSid, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, TrunkSid = trunkSid, VoiceApplicationSid = voiceApplicationSid, VoiceCallerIdLookup = voiceCallerIdLookup, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl, EmergencyStatus = emergencyStatus, EmergencyAddressSid = emergencyAddressSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IncomingPhoneNumberResource> CreateAsync(string ownerAccountSid = null, Types.PhoneNumber phoneNumber = null, string areaCode = null, string apiVersion = null, string friendlyName = null, string smsApplicationSid = null, Twilio.Http.HttpMethod smsFallbackMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsUrl = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string trunkSid = null, string voiceApplicationSid = null, bool? voiceCallerIdLookup = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceUrl = null, IncomingPhoneNumberResource.EmergencyStatusEnum emergencyStatus = null, string emergencyAddressSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateIncomingPhoneNumberOptions{OwnerAccountSid = ownerAccountSid, PhoneNumber = phoneNumber, AreaCode = areaCode, ApiVersion = apiVersion, FriendlyName = friendlyName, SmsApplicationSid = smsApplicationSid, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, TrunkSid = trunkSid, VoiceApplicationSid = voiceApplicationSid, VoiceCallerIdLookup = voiceCallerIdLookup, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl, EmergencyStatus = emergencyStatus, EmergencyAddressSid = emergencyAddressSid};
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a IncomingPhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IncomingPhoneNumberResource object represented by the provided JSON </returns> 
        public static IncomingPhoneNumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IncomingPhoneNumberResource>(json);
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
        public IncomingPhoneNumberResource.AddressRequirementEnum AddressRequirements { get; private set; }
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
        [JsonProperty("emergency_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IncomingPhoneNumberResource.EmergencyStatusEnum EmergencyStatus { get; private set; }
        [JsonProperty("emergency_address_sid")]
        public string EmergencyAddressSid { get; private set; }
    
        private IncomingPhoneNumberResource()
        {
        
        }
    }

}