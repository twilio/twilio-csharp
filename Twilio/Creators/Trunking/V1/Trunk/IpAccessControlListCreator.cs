using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.IpAccessControlList;

namespace Twilio.Creators.Trunking.V1.Trunk {

    public class IpAccessControlListCreator : Creator<IpAccessControlList> {
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
         * @param client TwilioRestClient with which to make the request
         * @return Created IpAccessControlList
         */
        [Override]
        public IpAccessControlList execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlList creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return IpAccessControlList.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (ipAccessControlListSid != null) {
                request.addPostParam("IpAccessControlListSid", ipAccessControlListSid);
            }
        }
    }
}