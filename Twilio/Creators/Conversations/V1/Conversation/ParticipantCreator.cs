using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Conversations.V1.Conversation;

namespace Twilio.Creators.Conversations.V1.Conversation {

    public class ParticipantCreator : Creator<ParticipantResource> {
        private string conversationSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
    
        /**
         * Construct a new ParticipantCreator
         * 
         * @param conversationSid The conversation_sid
         * @param to The to
         * @param from The from
         */
        public ParticipantCreator(string conversationSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from) {
            this.conversationSid = conversationSid;
            this.to = to;
            this.from = from;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created ParticipantResource
         */
        public override ParticipantResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.CONVERSATIONS,
                "/v1/Conversations/" + this.conversationSid + "/Participants"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (to != null) {
                request.addPostParam("To", to.ToString());
            }
            
            if (from != null) {
                request.addPostParam("From", from.ToString());
            }
        }
    }
}