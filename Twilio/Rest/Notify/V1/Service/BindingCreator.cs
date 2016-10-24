using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service {

    public class BindingCreator : Creator<BindingResource> {
        private string serviceSid;
        private string endpoint;
        private string identity;
        private BindingResource.BindingType bindingType;
        private string address;
        private List<string> tag;
        private string notificationProtocolVersion;
        private string credentialSid;
    
        /// <summary>
        /// Construct a new BindingCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="endpoint"> The endpoint </param>
        /// <param name="identity"> The identity </param>
        /// <param name="bindingType"> The binding_type </param>
        /// <param name="address"> The address </param>
        public BindingCreator(string serviceSid, string endpoint, string identity, BindingResource.BindingType bindingType, string address) {
            this.serviceSid = serviceSid;
            this.endpoint = endpoint;
            this.identity = identity;
            this.bindingType = bindingType;
            this.address = address;
        }
    
        /// <summary>
        /// The tag
        /// </summary>
        ///
        /// <param name="tag"> The tag </param>
        /// <returns> this </returns> 
        public BindingCreator setTag(List<string> tag) {
            this.tag = tag;
            return this;
        }
    
        /// <summary>
        /// The tag
        /// </summary>
        ///
        /// <param name="tag"> The tag </param>
        /// <returns> this </returns> 
        public BindingCreator setTag(string tag) {
            return setTag(Promoter.ListOfOne(tag));
        }
    
        /// <summary>
        /// The notification_protocol_version
        /// </summary>
        ///
        /// <param name="notificationProtocolVersion"> The notification_protocol_version </param>
        /// <returns> this </returns> 
        public BindingCreator setNotificationProtocolVersion(string notificationProtocolVersion) {
            this.notificationProtocolVersion = notificationProtocolVersion;
            return this;
        }
    
        /// <summary>
        /// The credential_sid
        /// </summary>
        ///
        /// <param name="credentialSid"> The credential_sid </param>
        /// <returns> this </returns> 
        public BindingCreator setCredentialSid(string credentialSid) {
            this.credentialSid = credentialSid;
            return this;
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
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            addPostParams(request);
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
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            addPostParams(request);
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
        private void addPostParams(Request request) {
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