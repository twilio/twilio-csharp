using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

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
        public override async Task<ResourceSet<MessageResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages.json"
            );
            
            AddQueryParams(request);
            
            Page<MessageResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<MessageResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<MessageResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of MessageResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<MessageResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MessageResource read failed: Unable to connect to server");
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
            
            Page<MessageResource> result = new Page<MessageResource>();
            result.deserialize("messages", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (to != null) {
                request.AddQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddQueryParam("From", from.ToString());
            }
            
            if (dateSent != null) {
                request.AddQueryParam("DateSent", dateSent);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}