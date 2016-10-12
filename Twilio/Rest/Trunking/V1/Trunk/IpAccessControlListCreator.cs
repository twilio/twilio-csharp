using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1.Trunk {

    public class IpAccessControlListCreator : Creator<IpAccessControlListResource> {
        private string trunkSid;
        private string ipAccessControlListSid;
    
        /**
         * Construct a new IpAccessControlListCreator
         * 
         * @param trunkSid The trunk_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         */
        public IpAccessControlListCreator(string trunkSid, string ipAccessControlListSid) {
            this.trunkSid = trunkSid;
            this.ipAccessControlListSid = ipAccessControlListSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAccessControlListResource
         */
        public override async Task<IpAccessControlListResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAccessControlListResource creation failed: Unable to connect to server");
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
            
            return IpAccessControlListResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAccessControlListResource
         */
        public override IpAccessControlListResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAccessControlListResource creation failed: Unable to connect to server");
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
            
            return IpAccessControlListResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (ipAccessControlListSid != null) {
                request.AddPostParam("IpAccessControlListSid", ipAccessControlListSid);
            }
        }
    }
}