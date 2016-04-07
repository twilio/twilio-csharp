using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Creators.Trunking.V1.Trunk {

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
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAccessControlListResource
         */
        public override async Task<IpAccessControlListResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
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