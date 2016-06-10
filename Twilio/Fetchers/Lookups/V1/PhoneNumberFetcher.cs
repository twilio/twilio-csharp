using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Lookups.V1;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Fetchers.Lookups.V1 {

    public class PhoneNumberFetcher : Fetcher<PhoneNumberResource> {
        private Twilio.Types.PhoneNumber phoneNumber;
        private string countryCode;
        private string type;
        private List<string> addOns;
        private Dictionary<string, object> addOnsData;
    
        /**
         * Construct a new PhoneNumberFetcher
         * 
         * @param phoneNumber The phone_number
         */
        public PhoneNumberFetcher(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * The country_code
         * 
         * @param countryCode The country_code
         * @return this
         */
        public PhoneNumberFetcher setCountryCode(string countryCode) {
            this.countryCode = countryCode;
            return this;
        }
    
        /**
         * The type
         * 
         * @param type The type
         * @return this
         */
        public PhoneNumberFetcher setType(string type) {
            this.type = type;
            return this;
        }
    
        /**
         * The add_ons
         * 
         * @param addOns The add_ons
         * @return this
         */
        public PhoneNumberFetcher setAddOns(List<string> addOns) {
            this.addOns = addOns;
            return this;
        }
    
        /**
         * The add_ons
         * 
         * @param addOns The add_ons
         * @return this
         */
        public PhoneNumberFetcher setAddOns(string addOns) {
            return setAddOns(Promoter.ListOfOne(addOns));
        }
    
        /**
         * The add_ons_data
         * 
         * @param addOnsData The add_ons_data
         * @return this
         */
        public PhoneNumberFetcher setAddOnsData(Dictionary<string, object> addOnsData) {
            this.addOnsData = addOnsData;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched PhoneNumberResource
         */
        public override async Task<PhoneNumberResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + this.phoneNumber + ""
            );
            
                AddQueryParams(request);
            
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumberResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return PhoneNumberResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched PhoneNumberResource
         */
        public override PhoneNumberResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + this.phoneNumber + ""
            );
            
                AddQueryParams(request);
            
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumberResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return PhoneNumberResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (countryCode != null) {
                request.AddQueryParam("CountryCode", countryCode);
            }
            
            if (type != null) {
                request.AddQueryParam("Type", type);
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