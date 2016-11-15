using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 
{

    public class ServiceCreator : Creator<ServiceResource> 
    {
        public string FriendlyName { get; set; }
        public string ApnCredentialSid { get; set; }
        public string GcmCredentialSid { get; set; }
        public string MessagingServiceSid { get; set; }
        public string FacebookMessengerPageId { get; set; }
        public string DefaultApnNotificationProtocolVersion { get; set; }
        public string DefaultGcmNotificationProtocolVersion { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ServiceResource </returns> 
        public override async System.Threading.Tasks.Task<ServiceResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Notify,
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
        public override ServiceResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Notify,
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
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (ApnCredentialSid != null)
            {
                request.AddPostParam("ApnCredentialSid", ApnCredentialSid);
            }
            
            if (GcmCredentialSid != null)
            {
                request.AddPostParam("GcmCredentialSid", GcmCredentialSid);
            }
            
            if (MessagingServiceSid != null)
            {
                request.AddPostParam("MessagingServiceSid", MessagingServiceSid);
            }
            
            if (FacebookMessengerPageId != null)
            {
                request.AddPostParam("FacebookMessengerPageId", FacebookMessengerPageId);
            }
            
            if (DefaultApnNotificationProtocolVersion != null)
            {
                request.AddPostParam("DefaultApnNotificationProtocolVersion", DefaultApnNotificationProtocolVersion);
            }
            
            if (DefaultGcmNotificationProtocolVersion != null)
            {
                request.AddPostParam("DefaultGcmNotificationProtocolVersion", DefaultGcmNotificationProtocolVersion);
            }
        }
    }
}