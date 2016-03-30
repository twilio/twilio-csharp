using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class OutgoingCallerIdReader : Reader<OutgoingCallerIdResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string friendlyName;
    
        /**
         * Construct a new OutgoingCallerIdReader
         * 
         * @param accountSid The account_sid
         */
        public OutgoingCallerIdReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show the caller id resource that exactly matches this phone number
         * 
         * @param phoneNumber Filter by phone number
         * @return this
         */
        public OutgoingCallerIdReader byPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /**
         * Only show the caller id resource that exactly matches this name
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public OutgoingCallerIdReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return OutgoingCallerIdResource ResourceSet
         */
        public override async Task<ResourceSet<OutgoingCallerIdResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json"
            );
            
            AddQueryParams(request);
            
            Page<OutgoingCallerIdResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<OutgoingCallerIdResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<OutgoingCallerIdResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of OutgoingCallerIdResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<OutgoingCallerIdResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource read failed: Unable to connect to server");
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
            
            Page<OutgoingCallerIdResource> result = new Page<OutgoingCallerIdResource>();
            result.deserialize("outgoing_caller_ids", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (phoneNumber != null) {
                request.AddQueryParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}