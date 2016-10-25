using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service.SyncList 
{

    public class SyncListItemUpdater : Updater<SyncListItemResource> 
    {
        public string serviceSid { get; }
        public string listSid { get; }
        public int? index { get; }
        public Object data { get; }
    
        /// <summary>
        /// Construct a new SyncListItemUpdater
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        /// <param name="data"> The data </param>
        public SyncListItemUpdater(string serviceSid, string listSid, int? index, Object data)
        {
            this.serviceSid = serviceSid;
            this.data = data;
            this.listSid = listSid;
            this.index = index;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated SyncListItemResource </returns> 
        public override async Task<SyncListItemResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Lists/" + this.listSid + "/Items/" + this.index + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncListItemResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return SyncListItemResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated SyncListItemResource </returns> 
        public override SyncListItemResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Lists/" + this.listSid + "/Items/" + this.index + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncListItemResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return SyncListItemResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (data != null)
            {
                request.AddPostParam("Data", data.ToString());
            }
        }
    }
}