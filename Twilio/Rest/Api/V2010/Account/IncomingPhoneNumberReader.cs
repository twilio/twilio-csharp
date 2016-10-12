using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class IncomingPhoneNumberReader : Reader<IncomingPhoneNumberResource> {
        private string ownerAccountSid;
        private bool? beta;
        private string friendlyName;
        private Twilio.Types.PhoneNumber phoneNumber;
    
        /**
         * Construct a new IncomingPhoneNumberReader.
         */
        public IncomingPhoneNumberReader() {
        }
    
        /**
         * Construct a new IncomingPhoneNumberReader
         * 
         * @param ownerAccountSid The owner_account_sid
         */
        public IncomingPhoneNumberReader(string ownerAccountSid) {
            this.ownerAccountSid = ownerAccountSid;
        }
    
        /**
         * Include phone numbers new to the Twilio platform
         * 
         * @param beta Include new phone numbers
         * @return this
         */
        public IncomingPhoneNumberReader ByBeta(bool? beta) {
            this.beta = beta;
            return this;
        }
    
        /**
         * Only show the incoming phone number resources with friendly names that
         * exactly match this name
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public IncomingPhoneNumberReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Only show the incoming phone number resources that match this pattern
         * 
         * @param phoneNumber Filter by incoming phone number
         * @return this
         */
        public IncomingPhoneNumberReader ByPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return IncomingPhoneNumberResource ResourceSet
         */
        public override Task<ResourceSet<IncomingPhoneNumberResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.ownerAccountSid != null ? this.ownerAccountSid : client.GetAccountSid()) + "/IncomingPhoneNumbers.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<IncomingPhoneNumberResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return IncomingPhoneNumberResource ResourceSet
         */
        public override ResourceSet<IncomingPhoneNumberResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.ownerAccountSid != null ? this.ownerAccountSid : client.GetAccountSid()) + "/IncomingPhoneNumbers.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<IncomingPhoneNumberResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<IncomingPhoneNumberResource> NextPage(Page<IncomingPhoneNumberResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of IncomingPhoneNumberResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<IncomingPhoneNumberResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource read failed: Unable to connect to server");
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
            
            return Page<IncomingPhoneNumberResource>.FromJson("incoming_phone_numbers", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (beta != null) {
                request.AddQueryParam("Beta", beta.ToString());
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (phoneNumber != null) {
                request.AddQueryParam("PhoneNumber", phoneNumber.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}