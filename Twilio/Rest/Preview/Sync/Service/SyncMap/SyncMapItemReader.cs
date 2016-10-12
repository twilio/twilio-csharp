using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service.SyncMap {

    public class SyncMapItemReader : Reader<SyncMapItemResource> {
        private string serviceSid;
        private string mapSid;
        private SyncMapItemResource.QueryResultOrder order;
        private string from;
        private SyncMapItemResource.QueryFromBoundType bounds;
    
        /// <summary>
        /// Construct a new SyncMapItemReader
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        public SyncMapItemReader(string serviceSid, string mapSid) {
            this.serviceSid = serviceSid;
            this.mapSid = mapSid;
        }
    
        /// <summary>
        /// The order
        /// </summary>
        ///
        /// <param name="order"> The order </param>
        /// <returns> this </returns> 
        public SyncMapItemReader ByOrder(SyncMapItemResource.QueryResultOrder order) {
            this.order = order;
            return this;
        }
    
        /// <summary>
        /// The from
        /// </summary>
        ///
        /// <param name="from"> The from </param>
        /// <returns> this </returns> 
        public SyncMapItemReader ByFrom(string from) {
            this.from = from;
            return this;
        }
    
        /// <summary>
        /// The bounds
        /// </summary>
        ///
        /// <param name="bounds"> The bounds </param>
        /// <returns> this </returns> 
        public SyncMapItemReader ByBounds(SyncMapItemResource.QueryFromBoundType bounds) {
            this.bounds = bounds;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> SyncMapItemResource ResourceSet </returns> 
        public override Task<ResourceSet<SyncMapItemResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Maps/" + this.mapSid + "/Items"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<SyncMapItemResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> SyncMapItemResource ResourceSet </returns> 
        public override ResourceSet<SyncMapItemResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Maps/" + this.mapSid + "/Items"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<SyncMapItemResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<SyncMapItemResource> NextPage(Page<SyncMapItemResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.PREVIEW
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of SyncMapItemResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<SyncMapItemResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncMapItemResource read failed: Unable to connect to server");
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
            
            return Page<SyncMapItemResource>.FromJson("items", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (order != null) {
                request.AddQueryParam("Order", order.ToString());
            }
            
            if (from != null) {
                request.AddQueryParam("From", from);
            }
            
            if (bounds != null) {
                request.AddQueryParam("Bounds", bounds.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}