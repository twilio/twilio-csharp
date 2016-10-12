using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingFetcher : Fetcher<CredentialListMappingResource> {
        private string accountSid;
        private string domainSid;
        private string sid;
    
        /**
         * Construct a new CredentialListMappingFetcher.
         * 
         * @param domainSid The domain_sid
         * @param sid The sid
         */
        public CredentialListMappingFetcher(string domainSid, string sid) {
            this.domainSid = domainSid;
            this.sid = sid;
        }
    
        /**
         * Construct a new CredentialListMappingFetcher
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         */
        public CredentialListMappingFetcher(string accountSid, string domainSid, string sid) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched CredentialListMappingResource
         */
        public override async Task<CredentialListMappingResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialListMappingResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return CredentialListMappingResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched CredentialListMappingResource
         */
        public override CredentialListMappingResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialListMappingResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return CredentialListMappingResource.FromJson(response.GetContent());
        }
    }
}