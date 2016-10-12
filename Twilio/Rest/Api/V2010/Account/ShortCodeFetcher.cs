using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ShortCodeFetcher : Fetcher<ShortCodeResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new ShortCodeFetcher.
         * 
         * @param sid Fetch by unique short-code Sid
         */
        public ShortCodeFetcher(string sid) {
            this.sid = sid;
        }
    
        /**
         * Construct a new ShortCodeFetcher
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique short-code Sid
         */
        public ShortCodeFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched ShortCodeResource
         */
        public override async Task<ShortCodeResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SMS/ShortCodes/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ShortCodeResource fetch failed: Unable to connect to server");
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
            
            return ShortCodeResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched ShortCodeResource
         */
        public override ShortCodeResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SMS/ShortCodes/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ShortCodeResource fetch failed: Unable to connect to server");
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
            
            return ShortCodeResource.FromJson(response.GetContent());
        }
    }
}