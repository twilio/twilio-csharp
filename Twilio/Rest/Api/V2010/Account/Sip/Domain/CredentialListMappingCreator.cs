using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingCreator : Creator<CredentialListMappingResource> {
        private string accountSid;
        private string domainSid;
        private string credentialListSid;
    
        /**
         * Construct a new CredentialListMappingCreator.
         * 
         * @param domainSid The domain_sid
         * @param credentialListSid The credential_list_sid
         */
        public CredentialListMappingCreator(string domainSid, string credentialListSid) {
            this.domainSid = domainSid;
            this.credentialListSid = credentialListSid;
        }
    
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
        public override async Task<CredentialListMappingResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialListMappingResource creation failed: Unable to connect to server");
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
            
            return CredentialListMappingResource.FromJson(response.Content);
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CredentialListMappingResource
         */
        public override CredentialListMappingResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialListMappingResource creation failed: Unable to connect to server");
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
            
            return CredentialListMappingResource.FromJson(response.Content);
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (credentialListSid != null) {
                request.AddPostParam("CredentialListSid", credentialListSid);
            }
        }
    }
}