using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sms.SmsMessage;
using java.net.URI;
using java.util.List;

namespace Twilio.Creators.Api.V2010.Account.Sms {

    public class SmsMessageCreator : Creator<SmsMessage> {
        private String accountSid;
        private com.twilio.types.PhoneNumber to;
        private com.twilio.types.PhoneNumber from;
        private String body;
        private List<URI> mediaUrl;
        private URI statusCallback;
        private String applicationSid;
    
        /**
         * Construct a new SmsMessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param body The body
         */
        public SmsMessageCreator(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, String body) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.body = body;
        }
    
        /**
         * Construct a new SmsMessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param mediaUrl The media_url
         */
        public SmsMessageCreator(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, List<URI> mediaUrl) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.mediaUrl = mediaUrl;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public SmsMessageCreator setStatusCallback(URI statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public SmsMessageCreator setStatusCallback(String statusCallback) {
            return setStatusCallback(Promoter.uriFromString(statusCallback));
        }
    
        /**
         * The application_sid
         * 
         * @param applicationSid The application_sid
         * @return this
         */
        public SmsMessageCreator setApplicationSid(String applicationSid) {
            this.applicationSid = applicationSid;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created SmsMessage
         */
        [Override]
        public SmsMessage execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessage creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            if (to != null) {
                request.addPostParam("To", to.toString());
            }
            
            if (from != null) {
                request.addPostParam("From", from.toString());
            }
            
            if (body != null) {
                request.addPostParam("Body", body);
            }
            
            if (mediaUrl != null) {
                request.addPostParam("MediaUrl", mediaUrl.toString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.toString());
            }
            
            if (applicationSid != null) {
                request.addPostParam("ApplicationSid", applicationSid);
            }
        }
    }
}