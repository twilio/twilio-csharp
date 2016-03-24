using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class MessageReader : Reader<MessageResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string dateSent;
    
        /**
         * Construct a new MessageReader
         * 
         * @param accountSid The account_sid
         */
        public MessageReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Filter by messages to this number
         * 
         * @param to Filter by messages to this number
         * @return this
         */
        public MessageReader byTo(Twilio.Types.PhoneNumber to) {
            this.to = to;
            return this;
        }
    
        /**
         * Only show messages from this phone number
         * 
         * @param from Filter by from number
         * @return this
         */
        public MessageReader byFrom(Twilio.Types.PhoneNumber from) {
            this.from = from;
            return this;
        }
    
        /**
         * Filter messages sent by this date
         * 
         * @param dateSent Filter by date sent
         * @return this
         */
        public MessageReader byDateSent(string dateSent) {
            this.dateSent = dateSent;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return MessageResource ResourceSet
         */
        public override ResourceSet<MessageResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages.json"
            );
            
            addQueryParams(request);
            
            Page<MessageResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<MessageResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of MessageResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<MessageResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MessageResource read failed: Unable to connect to server");
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
            
            Page<MessageResource> result = new Page<>();
            result.deserialize("messages", response.GetContent(), MessageResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (to != null) {
                request.addQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.addQueryParam("From", from.ToString());
            }
            
            if (dateSent != null) {
                request.addQueryParam("DateSent", dateSent);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}