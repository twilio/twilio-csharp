using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service {

    public class BindingCreator : Creator<BindingResource> {
        public string serviceSid { get; }
        public string endpoint { get; }
        public string identity { get; }
        public BindingResource.BindingType bindingType { get; }
        public string address { get; }
        public List<string> tag { get; set; }
        public string notificationProtocolVersion { get; set; }
        public string credentialSid { get; set; }
    
        /// <summary>
        /// Construct a new BindingCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="endpoint"> The endpoint </param>
        /// <param name="identity"> The identity </param>
        /// <param name="bindingType"> The binding_type </param>
        /// <param name="address"> The address </param>
        /// <param name="tag"> The tag </param>
        /// <param name="notificationProtocolVersion"> The notification_protocol_version </param>
        /// <param name="credentialSid"> The credential_sid </param>
        public BindingCreator(string serviceSid, string endpoint, string identity, BindingResource.BindingType bindingType, string address, List<string> tag=null, string notificationProtocolVersion=null, string credentialSid=null) {
            this.serviceSid = serviceSid;
            this.endpoint = endpoint;
            this.bindingType = bindingType;
            this.credentialSid = credentialSid;
            this.identity = identity;
            this.notificationProtocolVersion = notificationProtocolVersion;
            this.address = address;
            this.tag = tag;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created BindingResource </returns> 
        public override async Task<BindingResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("BindingResource creation failed: Unable to connect to server");
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
            
            return BindingResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created BindingResource </returns> 
        public override BindingResource Create(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("BindingResource creation failed: Unable to connect to server");
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
            
            return BindingResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (endpoint != null) {
                request.AddPostParam("Endpoint", endpoint);
            }
            
            if (identity != null) {
                request.AddPostParam("Identity", identity);
            }
            
            if (bindingType != null) {
                request.AddPostParam("BindingType", bindingType.ToString());
            }
            
            if (address != null) {
                request.AddPostParam("Address", address);
            }
            
            if (tag != null) {
                request.AddPostParam("Tag", tag.ToString());
            }
            
            if (notificationProtocolVersion != null) {
                request.AddPostParam("NotificationProtocolVersion", notificationProtocolVersion);
            }
            
            if (credentialSid != null) {
                request.AddPostParam("CredentialSid", credentialSid);
            }
        }
    }
}