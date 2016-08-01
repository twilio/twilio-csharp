using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account {

    public class AvailablePhoneNumberCountryReader : Reader<AvailablePhoneNumberCountryResource> {
        private string accountSid;
    
        /**
         * Construct a new AvailablePhoneNumberCountryReader.
         */
        public AvailablePhoneNumberCountryReader() {
        }
    
        /**
         * Construct a new AvailablePhoneNumberCountryReader
         * 
         * @param accountSid The account_sid
         */
        public AvailablePhoneNumberCountryReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return AvailablePhoneNumberCountryResource ResourceSet
         */
        public override Task<ResourceSet<AvailablePhoneNumberCountryResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AvailablePhoneNumbers.json"
            );
            
            AddQueryParams(request);
            
            Page<AvailablePhoneNumberCountryResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<AvailablePhoneNumberCountryResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return AvailablePhoneNumberCountryResource ResourceSet
         */
        public override ResourceSet<AvailablePhoneNumberCountryResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AvailablePhoneNumbers.json"
            );
            
            AddQueryParams(request);
            
            Page<AvailablePhoneNumberCountryResource> page = PageForRequest(client, request);
            
            return new ResourceSet<AvailablePhoneNumberCountryResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<AvailablePhoneNumberCountryResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of AvailablePhoneNumberCountryResource Resources for a given
         * request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<AvailablePhoneNumberCountryResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AvailablePhoneNumberCountryResource read failed: Unable to connect to server");
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
            
            Page<AvailablePhoneNumberCountryResource> result = new Page<AvailablePhoneNumberCountryResource>();
            result.deserialize("countries", response.GetContent());
            
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