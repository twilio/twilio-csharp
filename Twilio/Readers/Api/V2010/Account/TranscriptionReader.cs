using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class TranscriptionReader : Reader<TranscriptionResource> {
        private string accountSid;
    
        /**
         * Construct a new TranscriptionReader
         * 
         * @param accountSid The account_sid
         */
        public TranscriptionReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TranscriptionResource ResourceSet
         */
        public override Task<ResourceSet<TranscriptionResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Transcriptions.json"
            );
            
            AddQueryParams(request);
            
            Page<TranscriptionResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<TranscriptionResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TranscriptionResource ResourceSet
         */
        public override ResourceSet<TranscriptionResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Transcriptions.json"
            );
            
            AddQueryParams(request);
            
            Page<TranscriptionResource> page = PageForRequest(client, request);
            
            return new ResourceSet<TranscriptionResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TranscriptionResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of TranscriptionResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TranscriptionResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TranscriptionResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            Page<TranscriptionResource> result = new Page<TranscriptionResource>();
            result.deserialize("transcriptions", response.GetContent());
            
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