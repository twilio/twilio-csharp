using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sms;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Sms {

    public class SmsMessageUpdater : Updater<SmsMessageResource> {
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
         * @return Updated SmsMessageResource
         */
        public override SmsMessageResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessageResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return SmsMessageResource.fromJson(response.GetContent());
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