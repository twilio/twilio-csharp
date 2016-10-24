using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1 {

    public class ServiceCreator : Creator<ServiceResource> {
        public string friendlyName { get; set; }
        public string apnCredentialSid { get; set; }
        public string gcmCredentialSid { get; set; }
        public string messagingServiceSid { get; set; }
        public string facebookMessengerPageId { get; set; }
        public string defaultApnNotificationProtocolVersion { get; set; }
        public string defaultGcmNotificationProtocolVersion { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ServiceResource </returns> 
        public override async Task<ServiceResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services"
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
        public override ServiceResource Create(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services"
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
        private void AddPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apnCredentialSid != null) {
                request.AddPostParam("ApnCredentialSid", apnCredentialSid);
            }
            
            if (gcmCredentialSid != null) {
                request.AddPostParam("GcmCredentialSid", gcmCredentialSid);
            }
            
            if (messagingServiceSid != null) {
                request.AddPostParam("MessagingServiceSid", messagingServiceSid);
            }
            
            if (facebookMessengerPageId != null) {
                request.AddPostParam("FacebookMessengerPageId", facebookMessengerPageId);
            }
            
            if (defaultApnNotificationProtocolVersion != null) {
                request.AddPostParam("DefaultApnNotificationProtocolVersion", defaultApnNotificationProtocolVersion);
            }
            
            if (defaultGcmNotificationProtocolVersion != null) {
                request.AddPostParam("DefaultGcmNotificationProtocolVersion", defaultGcmNotificationProtocolVersion);
            }
        }
    }
}