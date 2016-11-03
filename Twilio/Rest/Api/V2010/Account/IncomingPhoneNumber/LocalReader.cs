using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class LocalReader : Reader<LocalResource> 
    {
        public string ownerAccountSid { get; set; }
        public bool? beta { get; set; }
        public string friendlyName { get; set; }
        public Twilio.Types.PhoneNumber phoneNumber { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> LocalResource ResourceSet </returns> 
        public override Task<ResourceSet<LocalResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/Local.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<LocalResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> LocalResource ResourceSet </returns> 
        public override ResourceSet<LocalResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/Local.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<LocalResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<LocalResource> NextPage(Page<LocalResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of LocalResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<LocalResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("LocalResource read failed: Unable to connect to server");
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
            
            return Page<LocalResource>.FromJson("incoming_phone_numbers", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (beta != null)
            {
                request.AddQueryParam("Beta", beta.ToString());
            }
            
            if (friendlyName != null)
            {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (phoneNumber != null)
            {
                request.AddQueryParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}