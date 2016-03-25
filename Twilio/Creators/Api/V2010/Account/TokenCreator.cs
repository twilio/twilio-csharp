using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Creators.Api.V2010.Account {

    public class TokenCreator : Creator<TokenResource> {
        private string accountSid;
        private int ttl;
    
        /**
         * Construct a new TokenCreator
         * 
         * @param accountSid The account_sid
         */
        public TokenCreator(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * The duration in seconds for which the generated credentials are valid
         * 
         * @param ttl The duration in seconds the credentials are valid
         * @return this
         */
        public TokenCreator setTtl(int ttl) {
            this.ttl = ttl;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created TokenResource
         */
        public TokenResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Tokens.json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TokenResource creation failed: Unable to connect to server");
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
            
            return TokenResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (ttl != null) {
                request.addPostParam("Ttl", ttl.ToString());
            }
        }
    }
}