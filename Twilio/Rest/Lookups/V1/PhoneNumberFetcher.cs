using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Lookups.V1 {

    public class PhoneNumberFetcher : Fetcher<PhoneNumberResource> {
        private Twilio.Types.PhoneNumber phoneNumber;
        private string countryCode;
        private List<string> type;
        private List<string> addOns;
        private Dictionary<string, object> addOnsData;
    
        /// <summary>
        /// Construct a new PhoneNumberFetcher
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public PhoneNumberFetcher(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// The country_code
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <returns> this </returns> 
        public PhoneNumberFetcher setCountryCode(string countryCode) {
            this.countryCode = countryCode;
            return this;
        }
    
        /// <summary>
        /// The type
        /// </summary>
        ///
        /// <param name="type"> The type </param>
        /// <returns> this </returns> 
        public PhoneNumberFetcher setType(List<string> type) {
            this.type = type;
            return this;
        }
    
        /// <summary>
        /// The type
        /// </summary>
        ///
        /// <param name="type"> The type </param>
        /// <returns> this </returns> 
        public PhoneNumberFetcher setType(string type) {
            return setType(Promoter.ListOfOne(type));
        }
    
        /// <summary>
        /// The add_ons
        /// </summary>
        ///
        /// <param name="addOns"> The add_ons </param>
        /// <returns> this </returns> 
        public PhoneNumberFetcher setAddOns(List<string> addOns) {
            this.addOns = addOns;
            return this;
        }
    
        /// <summary>
        /// The add_ons
        /// </summary>
        ///
        /// <param name="addOns"> The add_ons </param>
        /// <returns> this </returns> 
        public PhoneNumberFetcher setAddOns(string addOns) {
            return setAddOns(Promoter.ListOfOne(addOns));
        }
    
        /// <summary>
        /// The add_ons_data
        /// </summary>
        ///
        /// <param name="addOnsData"> The add_ons_data </param>
        /// <returns> this </returns> 
        public PhoneNumberFetcher setAddOnsData(Dictionary<string, object> addOnsData) {
            this.addOnsData = addOnsData;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched PhoneNumberResource </returns> 
        public override async Task<PhoneNumberResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + this.phoneNumber + ""
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
        public override PhoneNumberResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + this.phoneNumber + ""
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
        private void AddQueryParams(Request request) {
            if (countryCode != null) {
                request.AddQueryParam("CountryCode", countryCode);
            }
            
            if (type != null) {
                foreach (object prop in type) {
                    request.AddQueryParam("Type", prop.ToString());
                }
            }
            
            if (addOns != null) {
                foreach (object prop in addOns) {
                    request.AddQueryParam("AddOns", prop.ToString());
                }
            }
            
            if (addOnsData != null) {
                Dictionary<string, string> dictParams = PrefixedCollapsibleMap.Serialize(addOnsData, "AddOns");
                foreach (KeyValuePair<string, string> entry in dictParams) {
                    request.AddQueryParam(entry.Key, entry.Value);
                }
            }
        }
    }
}