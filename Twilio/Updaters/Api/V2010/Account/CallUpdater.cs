using System;
using Twilio.Clients;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account {

    public class CallUpdater : Updater<CallResource> {
        private string accountSid;
        private string sid;
        private Uri url;
        private HttpMethod method;
        private CallResource.Status status;
        private Uri fallbackUrl;
        private HttpMethod fallbackMethod;
        private Uri statusCallback;
        private HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new CallUpdater
         * 
         * @param accountSid The account_sid
         * @param sid Call Sid that uniquely identifies the Call to update
         */
        public CallUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * A valid URL that returns TwiML. Twilio will immediately redirect the call to
         * the new TwiML upon execution.
         * 
         * @param url URL that returns TwiML
         * @return this
         */
        public CallUpdater setUrl(Uri url) {
            this.url = url;
            return this;
        }
    
        /**
         * A valid URL that returns TwiML. Twilio will immediately redirect the call to
         * the new TwiML upon execution.
         * 
         * @param url URL that returns TwiML
         * @return this
         */
        public CallUpdater setUrl(string url) {
            return setUrl(Promoter.UriFromString(url));
        }
    
        /**
         * The HTTP method Twilio should use when requesting the URL. Defaults to
         * `POST`.
         * 
         * @param method HTTP method to use to fetch TwiML
         * @return this
         */
        public CallUpdater setMethod(HttpMethod method) {
            this.method = method;
            return this;
        }
    
        /**
         * Either `canceled` or `completed`. Specifying `canceled` will attempt to
         * hangup calls that are queued or ringing but not affect calls already in
         * progress. Specifying `completed` will attempt to hang up a call even if it's
         * already in progress.
         * 
         * @param status Status to update the Call with
         * @return this
         */
        public CallUpdater setStatus(CallResource.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * A URL that Twilio will request if an error occurs requesting or executing the
         * TwiML at `Url`.
         * 
         * @param fallbackUrl Fallback URL in case of error
         * @return this
         */
        public CallUpdater setFallbackUrl(Uri fallbackUrl) {
            this.fallbackUrl = fallbackUrl;
            return this;
        }
    
        /**
         * A URL that Twilio will request if an error occurs requesting or executing the
         * TwiML at `Url`.
         * 
         * @param fallbackUrl Fallback URL in case of error
         * @return this
         */
        public CallUpdater setFallbackUrl(string fallbackUrl) {
            return setFallbackUrl(Promoter.UriFromString(fallbackUrl));
        }
    
        /**
         * The HTTP method that Twilio should use to request the `FallbackUrl`. Must be
         * either `GET` or `POST`. Defaults to `POST`.
         * 
         * @param fallbackMethod HTTP Method to use with FallbackUrl
         * @return this
         */
        public CallUpdater setFallbackMethod(HttpMethod fallbackMethod) {
            this.fallbackMethod = fallbackMethod;
            return this;
        }
    
        /**
         * A URL that Twilio will request when the call ends to notify your app.
         * 
         * @param statusCallback Status Callback URL
         * @return this
         */
        public CallUpdater setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * A URL that Twilio will request when the call ends to notify your app.
         * 
         * @param statusCallback Status Callback URL
         * @return this
         */
        public CallUpdater setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The HTTP method that Twilio should use to request the `StatusCallback`.
         * Defaults to `POST`.
         * 
         * @param statusCallbackMethod HTTP Method to use with StatusCallback
         * @return this
         */
        public CallUpdater setStatusCallbackMethod(HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated CallResource
         */
        public override CallResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
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
            
            return CallResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (url != null) {
                request.addPostParam("Url", url.ToString());
            }
            
            if (method != null) {
                request.addPostParam("Method", method.ToString());
            }
            
            if (status != null) {
                request.addPostParam("Status", status.ToString());
            }
            
            if (fallbackUrl != null) {
                request.addPostParam("FallbackUrl", fallbackUrl.ToString());
            }
            
            if (fallbackMethod != null) {
                request.addPostParam("FallbackMethod", fallbackMethod.ToString());
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