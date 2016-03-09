using Twilio.Clients;
using Twilio.Deleters.Deleter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.call.Recording;

namespace Twilio.Deleters.Api.V2010.Account.Call {

    public class RecordingDeleter : Deleter<Recording> {
        private string accountSid;
        private string callSid;
        private string sid;
    
        /**
         * Construct a new RecordingDeleter
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         */
        public RecordingDeleter(string accountSid, string callSid, string sid) {
            this.accountSid = accountSid;
            this.callSid = callSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        [Override]
        public void execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.DELETE,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Recordings/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Recording delete failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
        }
    }
}