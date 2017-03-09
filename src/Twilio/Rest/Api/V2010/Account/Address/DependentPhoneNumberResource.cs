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

    /// <summary>
    /// DependentPhoneNumberResource
    /// </summary>
    public class DependentPhoneNumberResource : Resource 
    {
        private static Request BuildReadRequest(ReadDependentPhoneNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Addresses/" + options.PathAddressSid + "/DependentPhoneNumbers.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read DependentPhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DependentPhoneNumber </returns> 
        public static ResourceSet<DependentPhoneNumberResource> Read(ReadDependentPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<DependentPhoneNumberResource>.FromJson("dependent_phone_numbers", response.Content);
            return new ResourceSet<DependentPhoneNumberResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read DependentPhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DependentPhoneNumber </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DependentPhoneNumberResource>> ReadAsync(ReadDependentPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DependentPhoneNumberResource>.FromJson("dependent_phone_numbers", response.Content);
            return new ResourceSet<DependentPhoneNumberResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathAddressSid"> The address_sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DependentPhoneNumber </returns> 
        public static ResourceSet<DependentPhoneNumberResource> Read(string pathAddressSid, string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDependentPhoneNumberOptions(pathAddressSid){PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathAddressSid"> The address_sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DependentPhoneNumber </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DependentPhoneNumberResource>> ReadAsync(string pathAddressSid, string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDependentPhoneNumberOptions(pathAddressSid){PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
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

        /// <summary>
        /// The friendly_name
        /// </summary>
        [JsonProperty("friendly_name")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber FriendlyName { get; private set; }
        /// <summary>
        /// The phone_number
        /// </summary>
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        /// <summary>
        /// The lata
        /// </summary>
        [JsonProperty("lata")]
        public string Lata { get; private set; }
        /// <summary>
        /// The rate_center
        /// </summary>
        [JsonProperty("rate_center")]
        public string RateCenter { get; private set; }
        /// <summary>
        /// The latitude
        /// </summary>
        [JsonProperty("latitude")]
        public decimal? Latitude { get; private set; }
        /// <summary>
        /// The longitude
        /// </summary>
        [JsonProperty("longitude")]
        public decimal? Longitude { get; private set; }
        /// <summary>
        /// The region
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; private set; }
        /// <summary>
        /// The postal_code
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; private set; }
        /// <summary>
        /// The iso_country
        /// </summary>
        [JsonProperty("iso_country")]
        public string IsoCountry { get; private set; }
        /// <summary>
        /// The address_requirements
        /// </summary>
        [JsonProperty("address_requirements")]
        public string AddressRequirements { get; private set; }
        /// <summary>
        /// The capabilities
        /// </summary>
        [JsonProperty("capabilities")]
        public Dictionary<string, string> Capabilities { get; private set; }

        private DependentPhoneNumberResource()
        {

        }
    }

}