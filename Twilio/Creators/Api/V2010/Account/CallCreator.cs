using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account {

    public class CallCreator : Creator<CallResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private Uri url;
        private string applicationSid;
        private Twilio.Http.HttpMethod method;
        private Uri fallbackUrl;
        private Twilio.Http.HttpMethod fallbackMethod;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
        private string sendDigits;
        private string ifMachine;
        private int? timeout;
        private bool? record;
    
        /**
         * Construct a new CallCreator
         * 
         * @param accountSid The account_sid
         * @param to Phone number, SIP address or client identifier to call
         * @param from Twilio number from which to originate the call
         * @param url Url from which to fetch TwiML
         */
        public CallCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, Uri url) {
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
        public CallCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string applicationSid) {
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
        public CallCreator setMethod(Twilio.Http.HttpMethod method) {
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
        public CallCreator setFallbackUrl(Uri fallbackUrl) {
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
        public CallCreator setFallbackUrl(string fallbackUrl) {
            return setFallbackUrl(Promoter.UriFromString(fallbackUrl));
        }
    
        /**
         * The HTTP method that Twilio should use to request the `FallbackUrl`. Must be
         * either `GET` or `POST`. Defaults to `POST`. If an `ApplicationSid` was
         * provided, this parameter is ignored.
         * 
         * @param fallbackMethod HTTP Method to use with FallbackUrl
         * @return this
         */
        public CallCreator setFallbackMethod(Twilio.Http.HttpMethod fallbackMethod) {
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
        public CallCreator setStatusCallback(Uri statusCallback) {
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
        public CallCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The HTTP method that Twilio should use to request the `StatusCallback`.
         * Defaults to `POST`. If an `ApplicationSid` was provided, this parameter is
         * ignored.
         * 
         * @param statusCallbackMethod HTTP Method to use with StatusCallback
         * @return this
         */
        public CallCreator setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
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
        public CallCreator setSendDigits(string sendDigits) {
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
        public CallCreator setIfMachine(string ifMachine) {
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
        public CallCreator setTimeout(int? timeout) {
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
        public CallCreator setRecord(bool? record) {
            this.record = record;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CallResource
         */
        public override async Task<CallResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return CallResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CallResource
         */
        public override CallResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return CallResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (to != null) {
                request.AddPostParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddPostParam("From", from.ToString());
            }
            
            if (url != null) {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (applicationSid != "") {
                request.AddPostParam("ApplicationSid", applicationSid);
            }
            
            if (method != null) {
                request.AddPostParam("Method", method.ToString());
            }
            
            if (fallbackUrl != null) {
                request.AddPostParam("FallbackUrl", fallbackUrl.ToString());
            }
            
            if (fallbackMethod != null) {
                request.AddPostParam("FallbackMethod", fallbackMethod.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (sendDigits != "") {
                request.AddPostParam("SendDigits", sendDigits);
            }
            
            if (ifMachine != "") {
                request.AddPostParam("IfMachine", ifMachine);
            }
            
            if (timeout != null) {
                request.AddPostParam("Timeout", timeout.ToString());
            }
            
            if (record != null) {
                request.AddPostParam("Record", record.ToString());
            }
        }
    }
}