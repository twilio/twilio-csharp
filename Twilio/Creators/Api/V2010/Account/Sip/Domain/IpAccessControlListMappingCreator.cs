using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.Domain;

namespace Twilio.Creators.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMappingCreator : Creator<IpAccessControlListMappingResource> {
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
         * @return Created IpAccessControlListMappingResource
         */
        public override async Task<IpAccessControlListMappingResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/IpAccessControlListMappings.json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListMappingResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return IpAccessControlListMappingResource.FromJson(response.GetContent());
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