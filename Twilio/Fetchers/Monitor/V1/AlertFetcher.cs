using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Monitor.V1;

namespace Twilio.Fetchers.Monitor.V1 {

    public class AlertFetcher : Fetcher<AlertResource> {
        private string sid;
    
        /**
         * Construct a new AlertFetcher
         * 
         * @param sid The sid
         */
        public AlertFetcher(string sid) {
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched AlertResource
         */
        public override AlertResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.MONITOR,
                "/v1/Alerts/" + this.sid + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AlertResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return AlertResource.fromJson(response.GetContent());
        }
    }
}