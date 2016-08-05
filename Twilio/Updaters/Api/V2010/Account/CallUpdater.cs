using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Updaters.Api.V2010.Account {

    public class CallUpdater : Updater<CallResource> {
        private string accountSid;
        private string sid;
        private Uri url;
        private Twilio.Http.HttpMethod method;
        private CallResource.Status status;
        private Uri fallbackUrl;
        private Twilio.Http.HttpMethod fallbackMethod;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new CallUpdater.
         * 
         * @param sid Call Sid that uniquely identifies the Call to update
         */
        public CallUpdater(string sid) {
            this.sid = sid;
        }
    
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
        public CallUpdater setMethod(Twilio.Http.HttpMethod method) {
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
        public CallUpdater setFallbackMethod(Twilio.Http.HttpMethod fallbackMethod) {
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
        public CallUpdater setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CallResource
         */
        public override async Task<CallResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return CallResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CallResource
         */
        public override CallResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
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
            if (url != null) {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (method != null) {
                request.AddPostParam("Method", method.ToString());
            }
            
            if (status != null) {
                request.AddPostParam("Status", status.ToString());
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
        }
    }
}