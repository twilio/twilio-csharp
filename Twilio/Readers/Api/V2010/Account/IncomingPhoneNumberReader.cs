using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class IncomingPhoneNumberReader : Reader<IncomingPhoneNumberResource> {
        private string ownerAccountSid;
        private bool? beta;
        private string friendlyName;
        private Twilio.Types.PhoneNumber phoneNumber;
    
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
        public IncomingPhoneNumberReader byBeta(bool? beta) {
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
        public IncomingPhoneNumberReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Only show the incoming phone number resources that match this pattern
         * 
         * @param phoneNumber Filter by incoming phone number
         * @return this
         */
        public IncomingPhoneNumberReader byPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return IncomingPhoneNumberResource ResourceSet
         */
        public override async Task<ResourceSet<IncomingPhoneNumberResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers.json"
            );
            
            AddQueryParams(request);
            
            Page<IncomingPhoneNumberResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<IncomingPhoneNumberResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<IncomingPhoneNumberResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of IncomingPhoneNumberResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<IncomingPhoneNumberResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IncomingPhoneNumberResource read failed: Unable to connect to server");
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
            
            Page<IncomingPhoneNumberResource> result = new Page<IncomingPhoneNumberResource>();
            result.deserialize("incoming_phone_numbers", response.GetContent());
            
            return result;
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
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}