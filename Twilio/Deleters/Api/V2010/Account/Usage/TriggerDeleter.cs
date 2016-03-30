using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Usage;

namespace Twilio.Deleters.Api.V2010.Account.Usage {

    public class TriggerDeleter : Deleter<TriggerResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new TriggerDeleter
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public TriggerDeleter(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        public override async void ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers/" + this.sid + ".json"
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TriggerResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
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
        }
    }
}