using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Conversations.V1.conversation.Participant;

namespace Twilio.Creators.Conversations.V1.Conversation {

    public class ParticipantCreator : Creator<Participant> {
        private String conversationSid;
        private com.twilio.types.PhoneNumber to;
        private com.twilio.types.PhoneNumber from;
    
        /**
         * Construct a new ParticipantCreator
         * 
         * @param conversationSid The conversation_sid
         * @param to The to
         * @param from The from
         */
        public ParticipantCreator(String conversationSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from) {
            this.conversationSid = conversationSid;
            this.to = to;
            this.from = from;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Participant
         */
        [Override]
        public Participant execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.CONVERSATIONS,
                "/v1/Conversations/" + this.conversationSid + "/Participants",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Participant creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (to != null) {
                request.addPostParam("To", to.toString());
            }
            
            if (from != null) {
                request.addPostParam("From", from.toString());
            }
        }
    }
}