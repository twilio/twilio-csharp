using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sms.SmsMessage;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account.Sms {

    public class SmsMessageUpdater : Updater<SmsMessage> {
        private string accountSid;
        private string sid;
        private string body;
    
        /**
         * Construct a new SmsMessageUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public SmsMessageUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The body
         * 
         * @param body The body
         * @return this
         */
        public SmsMessageUpdater setBody(string body) {
            this.body = body;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated SmsMessage
         */
        [Override]
        public SmsMessage execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessage update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return SmsMessage.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (body != null) {
                request.addPostParam("Body", body);
            }
        }
    }
}