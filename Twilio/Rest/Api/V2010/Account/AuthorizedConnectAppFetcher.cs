using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class AuthorizedConnectAppFetcher : Fetcher<AuthorizedConnectAppResource> {
        private string accountSid;
        private string connectAppSid;
    
        /**
         * Construct a new AuthorizedConnectAppFetcher.
         * 
         * @param connectAppSid The connect_app_sid
         */
        public AuthorizedConnectAppFetcher(string connectAppSid) {
            this.connectAppSid = connectAppSid;
        }
    
        /**
         * Construct a new AuthorizedConnectAppFetcher
         * 
         * @param accountSid The account_sid
         * @param connectAppSid The connect_app_sid
         */
        public AuthorizedConnectAppFetcher(string accountSid, string connectAppSid) {
            this.accountSid = accountSid;
            this.connectAppSid = connectAppSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched AuthorizedConnectAppResource
         */
        public override async Task<AuthorizedConnectAppResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AuthorizedConnectApps/" + this.connectAppSid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("AuthorizedConnectAppResource fetch failed: Unable to connect to server");
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
            
            return AuthorizedConnectAppResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched AuthorizedConnectAppResource
         */
        public override AuthorizedConnectAppResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AuthorizedConnectApps/" + this.connectAppSid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("AuthorizedConnectAppResource fetch failed: Unable to connect to server");
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
            
            return AuthorizedConnectAppResource.FromJson(response.GetContent());
        }
    }
}