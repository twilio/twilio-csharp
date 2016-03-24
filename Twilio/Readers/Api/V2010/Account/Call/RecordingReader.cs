using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account.Call;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

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
        public RecordingReader byDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return RecordingResource ResourceSet
         */
        public override ResourceSet<RecordingResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Recordings.json"
            );
            
            addQueryParams(request);
            
            Page<RecordingResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RecordingResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of RecordingResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<RecordingResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordingResource read failed: Unable to connect to server");
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
            
            Page<RecordingResource> result = new Page<>();
            result.deserialize("recordings", response.GetContent(), RecordingResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (dateCreated != null) {
                request.addQueryParam("DateCreated", dateCreated);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}