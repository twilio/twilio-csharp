using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sms.SmsMessage;

namespace Twilio.Fetchers.Api.V2010.Account.Sms {

    public class SmsMessageFetcher : Fetcher<SmsMessage> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new SmsMessageFetcher
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public SmsMessageFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched SmsMessage
         */
        [Override]
        public SmsMessage execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessage fetch failed: Unable to connect to server");
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
    }
}