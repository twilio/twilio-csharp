using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Pricing.V1.Voice;

namespace Twilio.Fetchers.Pricing.V1.Voice {

    public class NumberFetcher : Fetcher<NumberResource> {
        private Twilio.Types.PhoneNumber number;
    
        /**
         * Construct a new NumberFetcher
         * 
         * @param number The number
         */
        public NumberFetcher(Twilio.Types.PhoneNumber number) {
            this.number = number;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched NumberResource
         */
        public override async Task<NumberResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.PRICING,
                "/v1/Voice/Numbers/" + this.number + ""
            );
            
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("NumberResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return NumberResource.FromJson(response.GetContent());
        }
    }
}