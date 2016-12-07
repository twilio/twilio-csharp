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

    public class AvailablePhoneNumberCountryResource : Resource 
    {
        private static Request BuildReadRequest(ReadAvailablePhoneNumberCountryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/AvailablePhoneNumbers.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<AvailablePhoneNumberCountryResource> Read(ReadAvailablePhoneNumberCountryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
            return new ResourceSet<AvailablePhoneNumberCountryResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AvailablePhoneNumberCountryResource>> ReadAsync(ReadAvailablePhoneNumberCountryOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<AvailablePhoneNumberCountryResource> Read(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAvailablePhoneNumberCountryOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AvailablePhoneNumberCountryResource>> ReadAsync(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAvailablePhoneNumberCountryOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<AvailablePhoneNumberCountryResource> NextPage(Page<AvailablePhoneNumberCountryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<AvailablePhoneNumberCountryResource>.FromJson("countries", response.Content);
        }
    
        private static Request BuildFetchRequest(FetchAvailablePhoneNumberCountryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/AvailablePhoneNumbers/" + options.CountryCode + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static AvailablePhoneNumberCountryResource Fetch(FetchAvailablePhoneNumberCountryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AvailablePhoneNumberCountryResource> FetchAsync(FetchAvailablePhoneNumberCountryOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static AvailablePhoneNumberCountryResource Fetch(string countryCode, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAvailablePhoneNumberCountryOptions(countryCode){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AvailablePhoneNumberCountryResource> FetchAsync(string countryCode, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAvailablePhoneNumberCountryOptions(countryCode){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AvailablePhoneNumberCountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AvailablePhoneNumberCountryResource object represented by the provided JSON </returns> 
        public static AvailablePhoneNumberCountryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AvailablePhoneNumberCountryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }
        [JsonProperty("country")]
        public string Country { get; private set; }
        [JsonProperty("uri")]
        public Uri Uri { get; private set; }
        [JsonProperty("beta")]
        public bool? Beta { get; private set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
    
        private AvailablePhoneNumberCountryResource()
        {
        
        }
    }

}