using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class IncomingPhoneNumberFetcher : Fetcher<IncomingPhoneNumberResource> {
        private string ownerAccountSid;
        private string sid;
    
        /**
         * Construct a new IncomingPhoneNumberFetcher.
         * 
         * @param sid Fetch by unique incoming-phone-number Sid
         */
        public IncomingPhoneNumberFetcher(string sid) {
            this.sid = sid;
        }
    
        /**
         * Construct a new IncomingPhoneNumberFetcher
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param sid Fetch by unique incoming-phone-number Sid
         */
        public IncomingPhoneNumberFetcher(string ownerAccountSid, string sid) {
            this.ownerAccountSid = ownerAccountSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched IncomingPhoneNumberResource
         */
        public override async Task<IncomingPhoneNumberResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.ownerAccountSid != null ? this.ownerAccountSid : client.GetAccountSid()) + "/IncomingPhoneNumbers/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource fetch failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched IncomingPhoneNumberResource
         */
        public override IncomingPhoneNumberResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.ownerAccountSid != null ? this.ownerAccountSid : client.GetAccountSid()) + "/IncomingPhoneNumbers/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource fetch failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.GetContent());
        }
    }
}