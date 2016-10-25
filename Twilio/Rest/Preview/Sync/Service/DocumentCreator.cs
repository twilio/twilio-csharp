using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class DocumentCreator : Creator<DocumentResource> 
    {
        public string serviceSid { get; }
        public string uniqueName { get; set; }
        public Object data { get; set; }
    
        /// <summary>
        /// Construct a new DocumentCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="uniqueName"> The unique_name </param>
        /// <param name="data"> The data </param>
        public DocumentCreator(string serviceSid, string uniqueName=null, Object data=null)
        {
            this.uniqueName = uniqueName;
            this.serviceSid = serviceSid;
            this.data = data;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DocumentResource </returns> 
        public override async Task<DocumentResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Documents"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DocumentResource creation failed: Unable to connect to server");
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
            
            return DocumentResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DocumentResource </returns> 
        public override DocumentResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Documents"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DocumentResource creation failed: Unable to connect to server");
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
            
            return DocumentResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (uniqueName != null)
            {
                request.AddPostParam("UniqueName", uniqueName);
            }
            
            if (data != null)
            {
                request.AddPostParam("Data", data.ToString());
            }
        }
    }
}