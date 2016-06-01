using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Address;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account.Address {

    public class DependentPhoneNumberReader : Reader<DependentPhoneNumberResource> {
        private string accountSid;
        private string addressSid;
    
        /**
         * Construct a new DependentPhoneNumberReader
         * 
         * @param accountSid The account_sid
         * @param addressSid The address_sid
         */
        public DependentPhoneNumberReader(string accountSid, string addressSid) {
            this.accountSid = accountSid;
            this.addressSid = addressSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return DependentPhoneNumberResource ResourceSet
         */
        public override Task<ResourceSet<DependentPhoneNumberResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Addresses/" + this.addressSid + "/DependentPhoneNumbers.json"
            );
            
            AddQueryParams(request);
            
            Page<DependentPhoneNumberResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<DependentPhoneNumberResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return DependentPhoneNumberResource ResourceSet
         */
        public override ResourceSet<DependentPhoneNumberResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Addresses/" + this.addressSid + "/DependentPhoneNumbers.json"
            );
            
            AddQueryParams(request);
            
            Page<DependentPhoneNumberResource> page = PageForRequest(client, request);
            
            return new ResourceSet<DependentPhoneNumberResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<DependentPhoneNumberResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of DependentPhoneNumberResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<DependentPhoneNumberResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("DependentPhoneNumberResource read failed: Unable to connect to server");
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
            
            Page<DependentPhoneNumberResource> result = new Page<DependentPhoneNumberResource>();
            result.deserialize("dependent_phone_numbers", response.GetContent());
            
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