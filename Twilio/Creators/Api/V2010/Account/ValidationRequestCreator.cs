using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.ValidationRequest;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;

namespace Twilio.Creators.Api.V2010.Account {

    public class ValidationRequestCreator : Creator<ValidationRequest> {
        private String accountSid;
        private com.twilio.types.PhoneNumber phoneNumber;
        private String friendlyName;
        private Integer callDelay;
        private String extension;
        private URI statusCallback;
        private HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new ValidationRequestCreator
         * 
         * @param accountSid The account_sid
         * @param phoneNumber The phone_number
         */
        public ValidationRequestCreator(String accountSid, com.twilio.types.PhoneNumber phoneNumber) {
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ValidationRequestCreator setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The call_delay
         * 
         * @param callDelay The call_delay
         * @return this
         */
        public ValidationRequestCreator setCallDelay(Integer callDelay) {
            this.callDelay = callDelay;
            return this;
        }
    
        /**
         * The extension
         * 
         * @param extension The extension
         * @return this
         */
        public ValidationRequestCreator setExtension(String extension) {
            this.extension = extension;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public ValidationRequestCreator setStatusCallback(URI statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public ValidationRequestCreator setStatusCallback(String statusCallback) {
            return setStatusCallback(Promoter.uriFromString(statusCallback));
        }
    
        /**
         * The status_callback_method
         * 
         * @param statusCallbackMethod The status_callback_method
         * @return this
         */
        public ValidationRequestCreator setStatusCallbackMethod(HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created ValidationRequest
         */
        [Override]
        public ValidationRequest execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ValidationRequest creation failed: Unable to connect to server");
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
            
            return ValidationRequest.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumber != null) {
                request.addPostParam("PhoneNumber", phoneNumber.toString());
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (callDelay != null) {
                request.addPostParam("CallDelay", callDelay.toString());
            }
            
            if (extension != null) {
                request.addPostParam("Extension", extension);
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.toString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.toString());
            }
        }
    }
}