using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync 
{

    public class ServiceCreator : Creator<ServiceResource> 
    {
        public string friendlyName { get; set; }
        public Uri webhookUrl { get; set; }
        public bool? reachabilityWebhooksEnabled { get; set; }
    
        /// <summary>
        /// Construct a new ServiceCreator
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="webhookUrl"> The webhook_url </param>
        /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
        public ServiceCreator(string friendlyName=null, Uri webhookUrl=null, bool? reachabilityWebhooksEnabled=null)
        {
            this.friendlyName = friendlyName;
            this.reachabilityWebhooksEnabled = reachabilityWebhooksEnabled;
            this.webhookUrl = webhookUrl;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ServiceResource </returns> 
        public override async Task<ServiceResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
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
            
            return ServiceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ServiceResource </returns> 
        public override ServiceResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
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
            
            return ServiceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (webhookUrl != null)
            {
                request.AddPostParam("WebhookUrl", webhookUrl.ToString());
            }
            
            if (reachabilityWebhooksEnabled != null)
            {
                request.AddPostParam("ReachabilityWebhooksEnabled", reachabilityWebhooksEnabled.ToString());
            }
        }
    }
}