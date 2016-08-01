using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Message;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Fetchers.Api.V2010.Account.Message {

    public class MediaFetcher : Fetcher<MediaResource> {
        private string accountSid;
        private string messageSid;
        private string sid;
    
        /**
         * Construct a new MediaFetcher.
         * 
         * @param messageSid The message_sid
         * @param sid Fetch by unique media Sid
         */
        public MediaFetcher(string messageSid, string sid) {
            this.messageSid = messageSid;
            this.sid = sid;
        }
    
        /**
         * Construct a new MediaFetcher
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @param sid Fetch by unique media Sid
         */
        public MediaFetcher(string accountSid, string messageSid, string sid) {
            this.accountSid = accountSid;
            this.messageSid = messageSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched MediaResource
         */
        public override async Task<MediaResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages/" + this.messageSid + "/Media/" + this.sid + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("MediaResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return MediaResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched MediaResource
         */
        public override MediaResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages/" + this.messageSid + "/Media/" + this.sid + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MediaResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return MediaResource.FromJson(response.GetContent());
        }
    }
}