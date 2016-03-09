using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sip.domain.IpAccessControlListMapping;

namespace Twilio.Creators.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMappingCreator : Creator<IpAccessControlListMapping> {
        private string accountSid;
        private string domainSid;
        private string ipAccessControlListSid;
    
        /**
         * Construct a new IpAccessControlListMappingCreator
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         */
        public IpAccessControlListMappingCreator(string accountSid, string domainSid, string ipAccessControlListSid) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
            this.ipAccessControlListSid = ipAccessControlListSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created IpAccessControlListMapping
         */
        [Override]
        public IpAccessControlListMapping execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/IpAccessControlListMappings.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListMapping creation failed: Unable to connect to server");
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
            
            return IpAccessControlListMapping.fromJson(response.getStream(), client.getObjectMapper());
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