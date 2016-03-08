using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.usage.Trigger;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.sdk.updaters.Updater;
using java.net.URI;

namespace Twilio.Updaters.Api.V2010.Account.Usage {

    public class TriggerUpdater : Updater<Trigger> {
        private String accountSid;
        private String sid;
        private HttpMethod callbackMethod;
        private URI callbackUrl;
        private String friendlyName;
    
        /**
         * Construct a new TriggerUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public TriggerUpdater(String accountSid, String sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The HTTP method Twilio will use when making a request to the CallbackUrl. 
         * GET or POST.
         * 
         * @param callbackMethod HTTP method to use with callback_url
         * @return this
         */
        public TriggerUpdater setCallbackMethod(HttpMethod callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /**
         * Twilio will make a request to this url when the trigger fires.
         * 
         * @param callbackUrl URL Twilio will request when the trigger fires
         * @return this
         */
        public TriggerUpdater setCallbackUrl(URI callbackUrl) {
            this.callbackUrl = callbackUrl;
            return this;
        }
    
        /**
         * Twilio will make a request to this url when the trigger fires.
         * 
         * @param callbackUrl URL Twilio will request when the trigger fires
         * @return this
         */
        public TriggerUpdater setCallbackUrl(String callbackUrl) {
            return setCallbackUrl(Promoter.uriFromString(callbackUrl));
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public TriggerUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Trigger
         */
        [Override]
        public Trigger execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Trigger update failed: Unable to connect to server");
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
            
            return Trigger.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (callbackMethod != null) {
                request.addPostParam("CallbackMethod", callbackMethod.toString());
            }
            
            if (callbackUrl != null) {
                request.addPostParam("CallbackUrl", callbackUrl.toString());
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
        }
    }
}