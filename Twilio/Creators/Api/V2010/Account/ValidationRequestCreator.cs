using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Creators.Api.V2010.Account {

    public class ValidationRequestCreator : Creator<ValidationRequestResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string friendlyName;
        private int? callDelay;
        private string extension;
        private Uri statusCallback;
        private System.Net.Http.HttpMethod statusCallbackMethod;
    
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
        public ValidationRequestCreator setCallDelay(int? callDelay) {
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
        public ValidationRequestCreator setStatusCallbackMethod(System.Net.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ValidationRequestResource
         */
        public override async Task<ValidationRequestResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ValidationRequestResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return ValidationRequestResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ValidationRequestResource
         */
        public override ValidationRequestResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ValidationRequestResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return ValidationRequestResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumber != null) {
                request.AddPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (callDelay != null) {
                request.AddPostParam("CallDelay", callDelay.ToString());
            }
            
            if (extension != "") {
                request.AddPostParam("Extension", extension);
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}