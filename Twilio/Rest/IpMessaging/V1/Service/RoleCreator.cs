using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class RoleCreator : Creator<RoleResource> 
    {
        public string ServiceSid { get; }
        public string FriendlyName { get; }
        public RoleResource.RoleTypeEnum Type { get; }
        public List<string> Permission { get; }
    
        /// <summary>
        /// Construct a new RoleCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="type"> The type </param>
        /// <param name="permission"> The permission </param>
        public RoleCreator(string serviceSid, string friendlyName, RoleResource.RoleTypeEnum type, List<string> permission)
        {
            ServiceSid = serviceSid;
            FriendlyName = friendlyName;
            Type = type;
            Permission = permission;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created RoleResource </returns> 
        public override async Task<RoleResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.ServiceSid + "/Roles"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("RoleResource creation failed: Unable to connect to server");
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
            
            return RoleResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created RoleResource </returns> 
        public override RoleResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.ServiceSid + "/Roles"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("RoleResource creation failed: Unable to connect to server");
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
            
            return RoleResource.FromJson(response.Content);
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
            
            if (Type != null)
            {
                request.AddPostParam("Type", Type.ToString());
            }
            
            if (Permission != null)
            {
                request.AddPostParam("Permission", Permission.ToString());
            }
        }
    }
}