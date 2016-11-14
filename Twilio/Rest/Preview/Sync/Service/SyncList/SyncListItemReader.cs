using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service.SyncList 
{

    public class SyncListItemReader : Reader<SyncListItemResource> 
    {
        public string serviceSid { get; }
        public string listSid { get; }
        public SyncListItemResource.SyncListItemQueryResultOrder order { get; set; }
        public string from { get; set; }
        public SyncListItemResource.SyncListItemQueryFromBoundType bounds { get; set; }
    
        /// <summary>
        /// Construct a new SyncListItemReader
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        public SyncListItemReader(string serviceSid, string listSid)
        {
            this.serviceSid = serviceSid;
            this.listSid = listSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> SyncListItemResource ResourceSet </returns> 
        public override Task<ResourceSet<SyncListItemResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Lists/" + this.listSid + "/Items"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<SyncListItemResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> SyncListItemResource ResourceSet </returns> 
        public override ResourceSet<SyncListItemResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Lists/" + this.listSid + "/Items"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<SyncListItemResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<SyncListItemResource> NextPage(Page<SyncListItemResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.PREVIEW
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of SyncListItemResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<SyncListItemResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncListItemResource read failed: Unable to connect to server");
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
            
            return Page<SyncListItemResource>.FromJson("items", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (order != null)
            {
                request.AddQueryParam("Order", order.ToString());
            }
            
            if (from != null)
            {
                request.AddQueryParam("From", from);
            }
            
            if (bounds != null)
            {
                request.AddQueryParam("Bounds", bounds.ToString());
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}