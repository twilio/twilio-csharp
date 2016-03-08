using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Conversations.V1.conversation.Participant;

namespace Twilio.Fetchers.Conversations.V1.Conversation {

    public class ParticipantFetcher : Fetcher<Participant> {
        private String conversationSid;
        private String sid;
    
        /**
         * Construct a new ParticipantFetcher
         * 
         * @param conversationSid The conversation_sid
         * @param sid The sid
         */
        public ParticipantFetcher(String conversationSid, String sid) {
            this.conversationSid = conversationSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched Participant
         */
        [Override]
        public Participant execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.CONVERSATIONS,
                "/v1/Conversations/" + this.conversationSid + "/Participants/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Participant fetch failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Participant.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}