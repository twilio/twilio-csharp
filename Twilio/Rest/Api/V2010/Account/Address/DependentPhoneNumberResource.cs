using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Address 
{

    public class DependentPhoneNumberResource : Resource 
    {
        private static Request BuildReadRequest(ReadDependentPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Addresses/" + options.AddressSid + "/DependentPhoneNumbers.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<DependentPhoneNumberResource> Read(ReadDependentPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<DependentPhoneNumberResource>.FromJson("dependent_phone_numbers", response.Content);
            return new ResourceSet<DependentPhoneNumberResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<DependentPhoneNumberResource>> ReadAsync(ReadDependentPhoneNumberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<DependentPhoneNumberResource> Read(string addressSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDependentPhoneNumberOptions(addressSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<DependentPhoneNumberResource>> ReadAsync(string addressSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDependentPhoneNumberOptions(addressSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<DependentPhoneNumberResource> NextPage(Page<DependentPhoneNumberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<DependentPhoneNumberResource>.FromJson("dependent_phone_numbers", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a DependentPhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DependentPhoneNumberResource object represented by the provided JSON </returns> 
        public static DependentPhoneNumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DependentPhoneNumberResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("friendly_name")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber FriendlyName { get; private set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        [JsonProperty("lata")]
        public string Lata { get; private set; }
        [JsonProperty("rate_center")]
        public string RateCenter { get; private set; }
        [JsonProperty("latitude")]
        public decimal? Latitude { get; private set; }
        [JsonProperty("longitude")]
        public decimal? Longitude { get; private set; }
        [JsonProperty("region")]
        public string Region { get; private set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; private set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; private set; }
        [JsonProperty("address_requirements")]
        public string AddressRequirements { get; private set; }
        [JsonProperty("capabilities")]
        public Dictionary<string, string> Capabilities { get; private set; }
    
        private DependentPhoneNumberResource()
        {
        
        }
    }

}