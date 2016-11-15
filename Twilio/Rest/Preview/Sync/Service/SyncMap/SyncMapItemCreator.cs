using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    public class SyncMapItemCreator : Creator<SyncMapItemResource> 
    {
        public string ServiceSid { get; }
        public string MapSid { get; }
        public string Key { get; }
        public Object Data { get; }
    
        /// <summary>
        /// Construct a new SyncMapItemCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <param name="data"> The data </param>
        public SyncMapItemCreator(string serviceSid, string mapSid, string key, Object data)
        {
            ServiceSid = serviceSid;
            MapSid = mapSid;
            Key = key;
            Data = data;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created SyncMapItemResource </returns> 
        public override async System.Threading.Tasks.Task<SyncMapItemResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Preview,
                "/Sync/Services/" + ServiceSid + "/Maps/" + MapSid + "/Items"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncMapItemResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return SyncMapItemResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created SyncMapItemResource </returns> 
        public override SyncMapItemResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Preview,
                "/Sync/Services/" + ServiceSid + "/Maps/" + MapSid + "/Items"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SyncMapItemResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return SyncMapItemResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Key != null)
            {
                request.AddPostParam("Key", Key);
            }
            
            if (Data != null)
            {
                request.AddPostParam("Data", Data.ToString());
            }
        }
    }
}