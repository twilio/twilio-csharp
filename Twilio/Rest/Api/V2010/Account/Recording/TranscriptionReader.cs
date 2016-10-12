using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Recording {

    public class TranscriptionReader : Reader<TranscriptionResource> {
        private string accountSid;
        private string recordingSid;
    
        /**
         * Construct a new TranscriptionReader.
         * 
         * @param recordingSid The recording_sid
         */
        public TranscriptionReader(string recordingSid) {
            this.recordingSid = recordingSid;
        }
    
        /**
         * Construct a new TranscriptionReader
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         */
        public TranscriptionReader(string accountSid, string recordingSid) {
            this.accountSid = accountSid;
            this.recordingSid = recordingSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TranscriptionResource ResourceSet
         */
        public override Task<ResourceSet<TranscriptionResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Recordings/" + this.recordingSid + "/Transcriptions.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<TranscriptionResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TranscriptionResource ResourceSet
         */
        public override ResourceSet<TranscriptionResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Recordings/" + this.recordingSid + "/Transcriptions.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<TranscriptionResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TranscriptionResource> NextPage(Page<TranscriptionResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of TranscriptionResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TranscriptionResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TranscriptionResource read failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to read records, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return Page<TranscriptionResource>.FromJson("transcriptions", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}