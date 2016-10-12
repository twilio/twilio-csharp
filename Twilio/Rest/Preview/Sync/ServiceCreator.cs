using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync {

    public class ServiceCreator : Creator<ServiceResource> {
        private string friendlyName;
        private Uri webhookUrl;
        private bool? reachabilityWebhooksEnabled;
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ServiceCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The webhook_url
         * 
         * @param webhookUrl The webhook_url
         * @return this
         */
        public ServiceCreator setWebhookUrl(Uri webhookUrl) {
            this.webhookUrl = webhookUrl;
            return this;
        }
    
        /**
         * The webhook_url
         * 
         * @param webhookUrl The webhook_url
         * @return this
         */
        public ServiceCreator setWebhookUrl(string webhookUrl) {
            return setWebhookUrl(Promoter.UriFromString(webhookUrl));
        }
    
        /**
         * The reachability_webhooks_enabled
         * 
         * @param reachabilityWebhooksEnabled The reachability_webhooks_enabled
         * @return this
         */
        public ServiceCreator setReachabilityWebhooksEnabled(bool? reachabilityWebhooksEnabled) {
            this.reachabilityWebhooksEnabled = reachabilityWebhooksEnabled;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ServiceResource
         */
        public override async Task<ServiceResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services"
            );
            
            addPostParams(request);
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
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ServiceResource
         */
        public override ServiceResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/Sync/Services"
            );
            
            addPostParams(request);
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (webhookUrl != null) {
                request.AddPostParam("WebhookUrl", webhookUrl.ToString());
            }
            
            if (reachabilityWebhooksEnabled != null) {
                request.AddPostParam("ReachabilityWebhooksEnabled", reachabilityWebhooksEnabled.ToString());
            }
        }
    }
}