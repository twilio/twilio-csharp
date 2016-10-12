using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList {

    public class CredentialFetcher : Fetcher<CredentialResource> {
        private string accountSid;
        private string credentialListSid;
        private string sid;
    
        /// <summary>
        /// Construct a new CredentialFetcher.
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        public CredentialFetcher(string credentialListSid, string sid) {
            this.credentialListSid = credentialListSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new CredentialFetcher
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        public CredentialFetcher(string accountSid, string credentialListSid, string sid) {
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched CredentialResource </returns> 
        public override async Task<CredentialResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched CredentialResource </returns> 
        public override CredentialResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
    }
}