using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 
{

    public class CredentialCreator : Creator<CredentialResource> 
    {
        public CredentialResource.PushServiceEnum Type { get; }
        public string FriendlyName { get; set; }
        public string Certificate { get; set; }
        public string PrivateKey { get; set; }
        public bool? Sandbox { get; set; }
        public string ApiKey { get; set; }
    
        /// <summary>
        /// Construct a new CredentialCreator
        /// </summary>
        ///
        /// <param name="type"> The type </param>
        public CredentialCreator(CredentialResource.PushServiceEnum type)
        {
            Type = type;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CredentialResource </returns> 
        public override async System.Threading.Tasks.Task<CredentialResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
                "/v1/Credentials"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource creation failed: Unable to connect to server");
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
            
            return CredentialResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CredentialResource </returns> 
        public override CredentialResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
                "/v1/Credentials"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource creation failed: Unable to connect to server");
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
            
            return CredentialResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Type != null)
            {
                request.AddPostParam("Type", Type.ToString());
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (Certificate != null)
            {
                request.AddPostParam("Certificate", Certificate);
            }
            
            if (PrivateKey != null)
            {
                request.AddPostParam("PrivateKey", PrivateKey);
            }
            
            if (Sandbox != null)
            {
                request.AddPostParam("Sandbox", Sandbox.ToString());
            }
            
            if (ApiKey != null)
            {
                request.AddPostParam("ApiKey", ApiKey);
            }
        }
    }
}