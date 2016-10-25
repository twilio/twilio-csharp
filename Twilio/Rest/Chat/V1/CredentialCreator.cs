using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Chat.V1 
{

    public class CredentialCreator : Creator<CredentialResource> 
    {
        public CredentialResource.PushService type { get; }
        public string friendlyName { get; set; }
        public string certificate { get; set; }
        public string privateKey { get; set; }
        public bool? sandbox { get; set; }
        public string apiKey { get; set; }
    
        /// <summary>
        /// Construct a new CredentialCreator
        /// </summary>
        ///
        /// <param name="type"> The type </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="certificate"> The certificate </param>
        /// <param name="privateKey"> The private_key </param>
        /// <param name="sandbox"> The sandbox </param>
        /// <param name="apiKey"> The api_key </param>
        public CredentialCreator(CredentialResource.PushService type, string friendlyName=null, string certificate=null, string privateKey=null, bool? sandbox=null, string apiKey=null)
        {
            this.type = type;
            this.privateKey = privateKey;
            this.certificate = certificate;
            this.sandbox = sandbox;
            this.apiKey = apiKey;
            this.friendlyName = friendlyName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CredentialResource </returns> 
        public override async Task<CredentialResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.CHAT,
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
                HttpMethod.POST,
                Domains.CHAT,
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
            if (type != null)
            {
                request.AddPostParam("Type", type.ToString());
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (certificate != null)
            {
                request.AddPostParam("Certificate", certificate);
            }
            
            if (privateKey != null)
            {
                request.AddPostParam("PrivateKey", privateKey);
            }
            
            if (sandbox != null)
            {
                request.AddPostParam("Sandbox", sandbox.ToString());
            }
            
            if (apiKey != null)
            {
                request.AddPostParam("ApiKey", apiKey);
            }
        }
    }
}