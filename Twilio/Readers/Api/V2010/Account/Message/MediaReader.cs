using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Message;

namespace Twilio.Readers.Api.V2010.Account.Message {

    public class MediaReader : Reader<MediaResource> {
        private string accountSid;
        private string messageSid;
        private string dateCreated;
    
        /**
         * Construct a new MediaReader
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         */
        public MediaReader(string accountSid, string messageSid) {
            this.accountSid = accountSid;
            this.messageSid = messageSid;
        }
    
        /**
         * Only show media created on the given date, or before/after using date
         * inequalities.
         * 
         * @param dateCreated Filter by date created
         * @return this
         */
        public MediaReader byDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return MediaResource ResourceSet
         */
        public override Task<ResourceSet<MediaResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages/" + this.messageSid + "/Media.json"
            );
            
            AddQueryParams(request);
            
            Page<MediaResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<MediaResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return MediaResource ResourceSet
         */
        public override ResourceSet<MediaResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages/" + this.messageSid + "/Media.json"
            );
            
            AddQueryParams(request);
            
            Page<MediaResource> page = PageForRequest(client, request);
            
            return new ResourceSet<MediaResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<MediaResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of MediaResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<MediaResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MediaResource read failed: Unable to connect to server");
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
            
            Page<MediaResource> result = new Page<MediaResource>();
            result.deserialize("media_list", response.GetContent());
            
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