using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Fetchers.Trunking.V1.Trunk {

    public class IpAccessControlListFetcher : Fetcher<IpAccessControlListResource> {
        private string trunkSid;
        private string sid;
    
        /**
         * Construct a new IpAccessControlListFetcher
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public IpAccessControlListFetcher(string trunkSid, string sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched IpAccessControlListResource
         */
        public override async Task<IpAccessControlListResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists/" + this.sid + ""
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return IpAccessControlListResource.FromJson(response.GetContent());
        }
    }
}