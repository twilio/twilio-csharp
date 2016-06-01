using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Conversations.V1.Conversation;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Conversations.V1.Conversation {

    public class ParticipantReader : Reader<ParticipantResource> {
        private string conversationSid;
    
        /**
         * Construct a new ParticipantReader
         * 
         * @param conversationSid The conversation_sid
         */
        public ParticipantReader(string conversationSid) {
            this.conversationSid = conversationSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ParticipantResource ResourceSet
         */
        public override Task<ResourceSet<ParticipantResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.CONVERSATIONS,
                "/v1/Conversations/" + this.conversationSid + "/Participants"
            );
            
            AddQueryParams(request);
            
            Page<ParticipantResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<ParticipantResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ParticipantResource ResourceSet
         */
        public override ResourceSet<ParticipantResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.CONVERSATIONS,
                "/v1/Conversations/" + this.conversationSid + "/Participants"
            );
            
            AddQueryParams(request);
            
            Page<ParticipantResource> page = PageForRequest(client, request);
            
            return new ResourceSet<ParticipantResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ParticipantResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of ParticipantResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ParticipantResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource read failed: Unable to connect to server");
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
            
            Page<ParticipantResource> result = new Page<ParticipantResource>();
            result.deserialize("participants", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}