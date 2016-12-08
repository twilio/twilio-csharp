using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Lookups.V1 
{

    public class PhoneNumberResource : Resource 
    {
        public sealed class TypeEnum : StringEnum 
        {
            private TypeEnum(string value) : base(value) {}
            public TypeEnum() {}
        
            public static readonly TypeEnum Landline = new TypeEnum("landline");
            public static readonly TypeEnum Mobile = new TypeEnum("mobile");
            public static readonly TypeEnum Voip = new TypeEnum("voip");
        }
    
        private static Request BuildFetchRequest(FetchPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Lookups,
                "/v1/PhoneNumbers/" + options.PhoneNumber + "",
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
        public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(FetchPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static PhoneNumberResource Fetch(Types.PhoneNumber phoneNumber, string countryCode = null, List<string> type = null, List<string> addOns = null, Dictionary<string, object> addOnsData = null, ITwilioRestClient client = null)
        {
            var options = new FetchPhoneNumberOptions(phoneNumber){CountryCode = countryCode, Type = type, AddOns = addOns, AddOnsData = addOnsData};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(Types.PhoneNumber phoneNumber, string countryCode = null, List<string> type = null, List<string> addOns = null, Dictionary<string, object> addOnsData = null, ITwilioRestClient client = null)
        {
            var options = new FetchPhoneNumberOptions(phoneNumber){CountryCode = countryCode, Type = type, AddOns = addOns, AddOnsData = addOnsData};
            return await FetchAsync(options, client);
        }
        #endif
    
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
    
        [JsonProperty("caller_name")]
        public Dictionary<string, string> CallerName { get; private set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        [JsonProperty("national_format")]
        public string NationalFormat { get; private set; }
        [JsonProperty("carrier")]
        public Dictionary<string, string> Carrier { get; private set; }
        [JsonProperty("add_ons")]
        public object AddOns { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private PhoneNumberResource()
        {
        
        }
    }

}