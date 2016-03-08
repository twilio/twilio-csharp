using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Call;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;

namespace Twilio.Creators.Api.V2010.Account {

    public class CallCreator : Creator<Call> {
        private String accountSid;
        private com.twilio.types.PhoneNumber to;
        private com.twilio.types.PhoneNumber from;
        private URI url;
        private String applicationSid;
        private HttpMethod method;
        private URI fallbackUrl;
        private HttpMethod fallbackMethod;
        private URI statusCallback;
        private HttpMethod statusCallbackMethod;
        private String sendDigits;
        private String ifMachine;
        private Integer timeout;
        private Boolean record;
    
        /**
         * Construct a new CallCreator
         * 
         * @param accountSid The account_sid
         * @param to Phone number, SIP address or client identifier to call
         * @param from Twilio number from which to originate the call
         * @param url Url from which to fetch TwiML
         */
        public CallCreator(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, URI url) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.url = url;
        }
    
        /**
         * Construct a new CallCreator
         * 
         * @param accountSid The account_sid
         * @param to Phone number, SIP address or client identifier to call
         * @param from Twilio number from which to originate the call
         * @param applicationSid ApplicationSid that configures from where to fetch
         *                       TwiML
         */
        public CallCreator(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, String applicationSid) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.applicationSid = applicationSid;
        }
    
        /**
         * The HTTP method Twilio should use when requesting the URL. Defaults to
         * `POST`. If an `ApplicationSid` was provided, this parameter is ignored.
         * 
         * @param method HTTP method to use to fetch TwiML
         * @return this
         */
        public CallCreator setMethod(HttpMethod method) {
            this.method = method;
            return this;
        }
    
        /**
         * A URL that Twilio will request if an error occurs requesting or executing the
         * TwiML at `Url`. If an `ApplicationSid` was provided, this parameter is
         * ignored.
         * 
         * @param fallbackUrl Fallback URL in case of error
         * @return this
         */
        public CallCreator setFallbackUrl(URI fallbackUrl) {
            this.fallbackUrl = fallbackUrl;
            return this;
        }
    
        /**
         * A URL that Twilio will request if an error occurs requesting or executing the
         * TwiML at `Url`. If an `ApplicationSid` was provided, this parameter is
         * ignored.
         * 
         * @param fallbackUrl Fallback URL in case of error
         * @return this
         */
        public CallCreator setFallbackUrl(String fallbackUrl) {
            return setFallbackUrl(Promoter.uriFromString(fallbackUrl));
        }
    
        /**
         * The HTTP method that Twilio should use to request the `FallbackUrl`. Must be
         * either `GET` or `POST`. Defaults to `POST`. If an `ApplicationSid` was
         * provided, this parameter is ignored.
         * 
         * @param fallbackMethod HTTP Method to use with FallbackUrl
         * @return this
         */
        public CallCreator setFallbackMethod(HttpMethod fallbackMethod) {
            this.fallbackMethod = fallbackMethod;
            return this;
        }
    
        /**
         * A URL that Twilio will request when the call ends to notify your app. If an
         * `ApplicationSid` was provided, this parameter is ignored.
         * 
         * @param statusCallback Status Callback URL
         * @return this
         */
        public CallCreator setStatusCallback(URI statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * A URL that Twilio will request when the call ends to notify your app. If an
         * `ApplicationSid` was provided, this parameter is ignored.
         * 
         * @param statusCallback Status Callback URL
         * @return this
         */
        public CallCreator setStatusCallback(String statusCallback) {
            return setStatusCallback(Promoter.uriFromString(statusCallback));
        }
    
        /**
         * The HTTP method that Twilio should use to request the `StatusCallback`.
         * Defaults to `POST`. If an `ApplicationSid` was provided, this parameter is
         * ignored.
         * 
         * @param statusCallbackMethod HTTP Method to use with StatusCallback
         * @return this
         */
        public CallCreator setStatusCallbackMethod(HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * A string of keys to dial after connecting to the number. Valid digits in the
         * string include: any digit (`0`-`9`), '`#`', '`*`' and '`w`' (to insert a half
         * second pause). For example, if you connected to a company phone number, and
         * wanted to pause for one second, dial extension 1234 and then the pound key,
         * use `ww1234#`.
         * 
         * @param sendDigits Digits to send
         * @return this
         */
        public CallCreator setSendDigits(String sendDigits) {
            this.sendDigits = sendDigits;
            return this;
        }
    
        /**
         * Tell Twilio to try and determine if a machine (like voicemail) or a human has
         * answered the call. Possible value are `Continue` and `Hangup`.
         * 
         * @param ifMachine Action to take if a machine has answered the call
         * @return this
         */
        public CallCreator setIfMachine(String ifMachine) {
            this.ifMachine = ifMachine;
            return this;
        }
    
        /**
         * The integer number of seconds that Twilio should allow the phone to ring
         * before assuming there is no answer. Default is `60` seconds, the maximum is
         * `999` seconds. Note, you could set this to a low value, such as `15`, to
         * hangup before reaching an answering machine or voicemail.
         * 
         * @param timeout Number of seconds to wait for an answer
         * @return this
         */
        public CallCreator setTimeout(Integer timeout) {
            this.timeout = timeout;
            return this;
        }
    
        /**
         * Set this parameter to true to record the entirety of a phone call. The
         * RecordingUrl will be sent to the StatusCallback URL. Defaults to false.
         * 
         * @param record Whether or not to record the Call
         * @return this
         */
        public CallCreator setRecord(Boolean record) {
            this.record = record;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Call
         */
        [Override]
        public Call execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Call creation failed: Unable to connect to server");
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
            
            return Call.fromJson(response.getStream(), client.getObjectMapper());
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
            
            if (url != null) {
                request.addPostParam("Url", url.toString());
            }
            
            if (applicationSid != null) {
                request.addPostParam("ApplicationSid", applicationSid);
            }
            
            if (method != null) {
                request.addPostParam("Method", method.toString());
            }
            
            if (fallbackUrl != null) {
                request.addPostParam("FallbackUrl", fallbackUrl.toString());
            }
            
            if (fallbackMethod != null) {
                request.addPostParam("FallbackMethod", fallbackMethod.toString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.toString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.toString());
            }
            
            if (sendDigits != null) {
                request.addPostParam("SendDigits", sendDigits);
            }
            
            if (ifMachine != null) {
                request.addPostParam("IfMachine", ifMachine);
            }
            
            if (timeout != null) {
                request.addPostParam("Timeout", timeout.toString());
            }
            
            if (record != null) {
                request.addPostParam("Record", record.toString());
            }
        }
    }
}