using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class PhoneNumberResource : Resource 
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
    
        private static Request BuildFetchRequest(FetchPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/PhoneNumbers/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static PhoneNumberResource Fetch(FetchPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(FetchPhoneNumberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static PhoneNumberResource Fetch(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchPhoneNumberOptions(trunkSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchPhoneNumberOptions(trunkSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeletePhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/PhoneNumbers/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeletePhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePhoneNumberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeletePhoneNumberOptions(trunkSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeletePhoneNumberOptions(trunkSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreatePhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/PhoneNumbers",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static PhoneNumberResource Create(CreatePhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PhoneNumberResource> CreateAsync(CreatePhoneNumberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static PhoneNumberResource Create(string trunkSid, string phoneNumberSid, ITwilioRestClient client = null)
        {
            var options = new CreatePhoneNumberOptions(trunkSid, phoneNumberSid);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PhoneNumberResource> CreateAsync(string trunkSid, string phoneNumberSid, ITwilioRestClient client = null)
        {
            var options = new CreatePhoneNumberOptions(trunkSid, phoneNumberSid);
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/PhoneNumbers",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<PhoneNumberResource> Read(ReadPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
            return new ResourceSet<PhoneNumberResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<PhoneNumberResource>> ReadAsync(ReadPhoneNumberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<PhoneNumberResource> Read(string trunkSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPhoneNumberOptions(trunkSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<PhoneNumberResource>> ReadAsync(string trunkSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPhoneNumberOptions(trunkSid){PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<PhoneNumberResource> NextPage(Page<PhoneNumberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Trunking,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a PhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PhoneNumberResource object represented by the provided JSON </returns> 
        public static PhoneNumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
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
        public PhoneNumberResource.AddressRequirementEnum AddressRequirements { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("beta")]
        public bool? Beta { get; private set; }
        [JsonProperty("capabilities")]
        public Dictionary<string, string> Capabilities { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
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
        [JsonProperty("url")]
        public Uri Url { get; private set; }
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
    
        private PhoneNumberResource()
        {
        
        }
    }

}