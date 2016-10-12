using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class AddressReader : Reader<AddressResource> {
        private string accountSid;
        private string customerName;
        private string friendlyName;
        private string isoCountry;
    
        /// <summary>
        /// Construct a new AddressReader.
        /// </summary>
        public AddressReader() {
        }
    
        /// <summary>
        /// Construct a new AddressReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public AddressReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// The customer_name
        /// </summary>
        ///
        /// <param name="customerName"> The customer_name </param>
        /// <returns> this </returns> 
        public AddressReader ByCustomerName(string customerName) {
            this.customerName = customerName;
            return this;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public AddressReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The iso_country
        /// </summary>
        ///
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> this </returns> 
        public AddressReader ByIsoCountry(string isoCountry) {
            this.isoCountry = isoCountry;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> AddressResource ResourceSet </returns> 
        public override Task<ResourceSet<AddressResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Addresses.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<AddressResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> AddressResource ResourceSet </returns> 
        public override ResourceSet<AddressResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Addresses.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<AddressResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<AddressResource> NextPage(Page<AddressResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of AddressResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<AddressResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("AddressResource read failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<AddressResource>.FromJson("addresses", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
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
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}