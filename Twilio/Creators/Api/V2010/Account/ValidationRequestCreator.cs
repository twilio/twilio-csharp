using System;
using Twilio.Clients;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.ValidationRequest;

namespace Twilio.Creators.Api.V2010.Account {

    public class ValidationRequestCreator : Creator<ValidationRequest> {
        private string accountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string friendlyName;
        private int callDelay;
        private string extension;
        private Uri statusCallback;
        private HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new ValidationRequestCreator
         * 
         * @param accountSid The account_sid
         * @param phoneNumber The phone_number
         */
        public ValidationRequestCreator(string accountSid, Twilio.Types.PhoneNumber phoneNumber) {
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ValidationRequestCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The call_delay
         * 
         * @param callDelay The call_delay
         * @return this
         */
        public ValidationRequestCreator setCallDelay(int callDelay) {
            this.callDelay = callDelay;
            return this;
        }
    
        /**
         * The extension
         * 
         * @param extension The extension
         * @return this
         */
        public ValidationRequestCreator setExtension(string extension) {
            this.extension = extension;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public ValidationRequestCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public ValidationRequestCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
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
                request.addPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (callDelay != null) {
                request.addPostParam("CallDelay", callDelay.ToString());
            }
            
            if (extension != null) {
                request.addPostParam("Extension", extension);
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}