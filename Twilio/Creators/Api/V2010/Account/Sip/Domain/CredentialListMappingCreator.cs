using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.Domain;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingCreator : Creator<CredentialListMappingResource> {
        private string accountSid;
        private string domainSid;
        private string credentialListSid;
    
        /**
         * Construct a new CredentialListMappingCreator
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param credentialListSid The credential_list_sid
         */
        public CredentialListMappingCreator(string accountSid, string domainSid, string credentialListSid) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
            this.credentialListSid = credentialListSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CredentialListMappingResource
         */
        public override async Task<CredentialListMappingResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListMappingResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.Created) {
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
            
            return CredentialListMappingResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CredentialListMappingResource
         */
        public override CredentialListMappingResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListMappingResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.Created) {
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
            
            return CredentialListMappingResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (credentialListSid != "") {
                request.AddPostParam("CredentialListSid", credentialListSid);
            }
        }
    }
}