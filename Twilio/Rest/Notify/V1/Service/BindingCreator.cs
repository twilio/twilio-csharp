using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class BindingCreator : Creator<BindingResource> 
    {
        public string ServiceSid { get; }
        public string Endpoint { get; }
        public string Identity { get; }
        public BindingResource.BindingTypeEnum BindingType { get; }
        public string Address { get; }
        public List<string> Tag { get; set; }
        public string NotificationProtocolVersion { get; set; }
        public string CredentialSid { get; set; }
    
        /// <summary>
        /// Construct a new BindingCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="endpoint"> The endpoint </param>
        /// <param name="identity"> The identity </param>
        /// <param name="bindingType"> The binding_type </param>
        /// <param name="address"> The address </param>
        public BindingCreator(string serviceSid, string endpoint, string identity, BindingResource.BindingTypeEnum bindingType, string address)
        {
            ServiceSid = serviceSid;
            Endpoint = endpoint;
            Identity = identity;
            BindingType = bindingType;
            Address = address;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created BindingResource </returns> 
        public override async System.Threading.Tasks.Task<BindingResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Notify,
                "/v1/Services/" + ServiceSid + "/Bindings"
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
        public override BindingResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Notify,
                "/v1/Services/" + ServiceSid + "/Bindings"
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
        private void AddPostParams(Request request)
        {
            if (Endpoint != null)
            {
                request.AddPostParam("Endpoint", Endpoint);
            }
            
            if (Identity != null)
            {
                request.AddPostParam("Identity", Identity);
            }
            
            if (BindingType != null)
            {
                request.AddPostParam("BindingType", BindingType.ToString());
            }
            
            if (Address != null)
            {
                request.AddPostParam("Address", Address);
            }
            
            if (Tag != null)
            {
                request.AddPostParam("Tag", Tag.ToString());
            }
            
            if (NotificationProtocolVersion != null)
            {
                request.AddPostParam("NotificationProtocolVersion", NotificationProtocolVersion);
            }
            
            if (CredentialSid != null)
            {
                request.AddPostParam("CredentialSid", CredentialSid);
            }
        }
    }
}