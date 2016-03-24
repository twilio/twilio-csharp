using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class AddressReader : Reader<AddressResource> {
        private string accountSid;
        private string customerName;
        private string friendlyName;
        private string isoCountry;
    
        /**
         * Construct a new AddressReader
         * 
         * @param accountSid The account_sid
         */
        public AddressReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * The customer_name
         * 
         * @param customerName The customer_name
         * @return this
         */
        public AddressReader byCustomerName(string customerName) {
            this.customerName = customerName;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public AddressReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The iso_country
         * 
         * @param isoCountry The iso_country
         * @return this
         */
        public AddressReader byIsoCountry(string isoCountry) {
            this.isoCountry = isoCountry;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return AddressResource ResourceSet
         */
        public override ResourceSet<AddressResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Addresses.json"
            );
            
            AddQueryParams(request);
            
            Page<AddressResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public Page<AddressResource> nextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of AddressResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<AddressResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AddressResource read failed: Unable to connect to server");
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
            
            Page<AddressResource> result = new Page<>();
            result.deserialize("addresses", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (customerName != null) {
                request.AddQueryParam("CustomerName", customerName);
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (isoCountry != null) {
                request.AddQueryParam("IsoCountry", isoCountry);
            }
            
            request.AddQueryParam("PageSize", getPageSize().ToString());
        }
    }
}