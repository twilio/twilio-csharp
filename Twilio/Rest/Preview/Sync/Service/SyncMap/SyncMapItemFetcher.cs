using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    public class SyncMapItemFetcher : Fetcher<SyncMapItemResource> 
    {
        public string serviceSid { get; }
        public string mapSid { get; }
        public string key { get; }
    
        /// <summary>
        /// Construct a new SyncMapItemFetcher
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        public SyncMapItemFetcher(string serviceSid, string mapSid, string key)
        {
            this.serviceSid = serviceSid;
            this.mapSid = mapSid;
            this.key = key;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched SyncMapItemResource </returns> 
        public override async Task<SyncMapItemResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Maps/" + this.mapSid + "/Items/" + this.key + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncMapItemResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return SyncMapItemResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched SyncMapItemResource </returns> 
        public override SyncMapItemResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Maps/" + this.mapSid + "/Items/" + this.key + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncMapItemResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return SyncMapItemResource.FromJson(response.Content);
        }
    }
}