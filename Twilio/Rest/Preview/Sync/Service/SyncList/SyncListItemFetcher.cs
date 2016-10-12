using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service.SyncList {

    public class SyncListItemFetcher : Fetcher<SyncListItemResource> {
        private string serviceSid;
        private string listSid;
        private int? index;
    
        /**
         * Construct a new SyncListItemFetcher
         * 
         * @param serviceSid The service_sid
         * @param listSid The list_sid
         * @param index The index
         */
        public SyncListItemFetcher(string serviceSid, string listSid, int? index) {
            this.serviceSid = serviceSid;
            this.listSid = listSid;
            this.index = index;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched SyncListItemResource
         */
        public override async Task<SyncListItemResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Lists/" + this.listSid + "/Items/" + this.index + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncListItemResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return SyncListItemResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched SyncListItemResource
         */
        public override SyncListItemResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Lists/" + this.listSid + "/Items/" + this.index + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncListItemResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return SyncListItemResource.FromJson(response.GetContent());
        }
    }
}