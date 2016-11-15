using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Lookups.V1 
{

    public class PhoneNumberFetcher : Fetcher<PhoneNumberResource> 
    {
        public Types.PhoneNumber PhoneNumber { get; }
        public string CountryCode { get; set; }
        public List<string> Type { get; set; }
        public List<string> AddOns { get; set; }
        public Dictionary<string, object> AddOnsData { get; set; }
    
        /// <summary>
        /// Construct a new PhoneNumberFetcher
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public PhoneNumberFetcher(Types.PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched PhoneNumberResource </returns> 
        public override async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + PhoneNumber + ""
            );
            
                AddQueryParams(request);
            
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("PhoneNumberResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return PhoneNumberResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched PhoneNumberResource </returns> 
        public override PhoneNumberResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + PhoneNumber + ""
            );
            
                AddQueryParams(request);
            
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("PhoneNumberResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return PhoneNumberResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (CountryCode != null)
            {
                request.AddQueryParam("CountryCode", CountryCode);
            }
            
            if (Type != null)
            {
                foreach (object prop in Type)
                {
                    request.AddQueryParam("Type", prop.ToString());
                }
            }
            
            if (AddOns != null)
            {
                foreach (object prop in AddOns)
                {
                    request.AddQueryParam("AddOns", prop.ToString());
                }
            }
            
            if (AddOnsData != null)
            {
                Dictionary<string, string> dictParams = PrefixedCollapsibleMap.Serialize(AddOnsData, "AddOns");
                foreach (KeyValuePair<string, string> entry in dictParams) {
                    request.AddQueryParam(entry.Key, entry.Value);
                }
            }
        }
    }
}