using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service {

    public class ChannelCreator : Creator<ChannelResource> {
        private string serviceSid;
        private string friendlyName;
        private string uniqueName;
        private string attributes;
        private ChannelResource.ChannelType type;
    
        /**
         * Construct a new ChannelCreator
         * 
         * @param serviceSid The service_sid
         */
        public ChannelCreator(string serviceSid) {
            this.serviceSid = serviceSid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ChannelCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The unique_name
         * 
         * @param uniqueName The unique_name
         * @return this
         */
        public ChannelCreator setUniqueName(string uniqueName) {
            this.uniqueName = uniqueName;
            return this;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public ChannelCreator setAttributes(string attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * The type
         * 
         * @param type The type
         * @return this
         */
        public ChannelCreator setType(ChannelResource.ChannelType type) {
            this.type = type;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ChannelResource
         */
        public override async Task<ChannelResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ChannelResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return ChannelResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ChannelResource
         */
        public override ChannelResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ChannelResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return ChannelResource.FromJson(response.GetContent());
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
            
            if (uniqueName != null) {
                request.AddPostParam("UniqueName", uniqueName);
            }
            
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (type != null) {
                request.AddPostParam("Type", type.ToString());
            }
        }
    }
}