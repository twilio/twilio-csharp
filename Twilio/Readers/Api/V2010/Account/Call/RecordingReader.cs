using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Call;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account.Call {

    public class RecordingReader : Reader<RecordingResource> {
        private string accountSid;
        private string callSid;
        private string dateCreated;
    
        /**
         * Construct a new RecordingReader
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         */
        public RecordingReader(string accountSid, string callSid) {
            this.accountSid = accountSid;
            this.callSid = callSid;
        }
    
        /**
         * The date_created
         * 
         * @param dateCreated The date_created
         * @return this
         */
        public RecordingReader ByDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RecordingResource ResourceSet
         */
        public override Task<ResourceSet<RecordingResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Recordings.json"
            );
            
            AddQueryParams(request);
            
            Page<RecordingResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<RecordingResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RecordingResource ResourceSet
         */
        public override ResourceSet<RecordingResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Recordings.json"
            );
            
            AddQueryParams(request);
            
            Page<RecordingResource> page = PageForRequest(client, request);
            
            return new ResourceSet<RecordingResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RecordingResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of RecordingResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<RecordingResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordingResource read failed: Unable to connect to server");
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
            
            Page<RecordingResource> result = new Page<RecordingResource>();
            result.deserialize("recordings", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (dateCreated != null) {
                request.AddQueryParam("DateCreated", dateCreated);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}