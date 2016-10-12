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
    
        /// <summary>
        /// Construct a new IncomingPhoneNumberReader.
        /// </summary>
        public IncomingPhoneNumberReader() {
        }
    
        /// <summary>
        /// Construct a new IncomingPhoneNumberReader
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        public IncomingPhoneNumberReader(string ownerAccountSid) {
            this.ownerAccountSid = ownerAccountSid;
        }
    
        /// <summary>
        /// Include phone numbers new to the Twilio platform
        /// </summary>
        ///
        /// <param name="beta"> Include new phone numbers </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberReader ByBeta(bool? beta) {
            this.beta = beta;
            return this;
        }
    
        /// <summary>
        /// Only show the incoming phone number resources with friendly names that exactly match this name
        /// </summary>
        ///
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// Only show the incoming phone number resources that match this pattern
        /// </summary>
        ///
        /// <param name="phoneNumber"> Filter by incoming phone number </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberReader ByPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> IncomingPhoneNumberResource ResourceSet </returns> 
        public override Task<ResourceSet<IncomingPhoneNumberResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<IncomingPhoneNumberResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> IncomingPhoneNumberResource ResourceSet </returns> 
        public override ResourceSet<IncomingPhoneNumberResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<IncomingPhoneNumberResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<IncomingPhoneNumberResource> NextPage(Page<IncomingPhoneNumberResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of IncomingPhoneNumberResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<IncomingPhoneNumberResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource read failed: Unable to connect to server");
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
            
            return Page<IncomingPhoneNumberResource>.FromJson("incoming_phone_numbers", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
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