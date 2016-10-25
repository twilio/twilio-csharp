using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class UserCreator : Creator<UserResource> 
    {
        public string serviceSid { get; }
        public string identity { get; }
        public string roleSid { get; set; }
        public string attributes { get; set; }
        public string friendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UserCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="roleSid"> The role_sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <param name="friendlyName"> The friendly_name </param>
        public UserCreator(string serviceSid, string identity, string roleSid=null, string attributes=null, string friendlyName=null)
        {
            this.serviceSid = serviceSid;
            this.identity = identity;
            this.attributes = attributes;
            this.roleSid = roleSid;
            this.friendlyName = friendlyName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created UserResource </returns> 
        public override async Task<UserResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("UserResource creation failed: Unable to connect to server");
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
            
            return UserResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created UserResource </returns> 
        public override UserResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("UserResource creation failed: Unable to connect to server");
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
            
            return UserResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (identity != null)
            {
                request.AddPostParam("Identity", identity);
            }
            
            if (roleSid != null)
            {
                request.AddPostParam("RoleSid", roleSid);
            }
            
            if (attributes != null)
            {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}