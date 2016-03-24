using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Conference;

namespace Twilio.Fetchers.Api.V2010.Account.Conference {

    public class ParticipantFetcher : Fetcher<ParticipantResource> {
        private string accountSid;
        private string conferenceSid;
        private string callSid;
    
        /**
         * Construct a new ParticipantFetcher
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         */
        public ParticipantFetcher(string accountSid, string conferenceSid, string callSid) {
            this.accountSid = accountSid;
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched ParticipantResource
         */
        public override ParticipantResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource fetch failed: Unable to connect to server");
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
            
            return ParticipantResource.fromJson(response.GetContent());
        }
    }
}