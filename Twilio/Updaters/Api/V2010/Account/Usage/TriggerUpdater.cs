using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Usage;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Usage {

    public class TriggerUpdater : Updater<TriggerResource> {
        private string accountSid;
        private string sid;
        private System.Net.Http.HttpMethod callbackMethod;
        private Uri callbackUrl;
        private string friendlyName;
    
        /**
         * Construct a new TriggerUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public TriggerUpdater(string accountSid, string sid) {
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
        public TriggerUpdater setCallbackMethod(System.Net.Http.HttpMethod callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /**
         * Twilio will make a request to this url when the trigger fires.
         * 
         * @param callbackUrl URL Twilio will request when the trigger fires
         * @return this
         */
        public TriggerUpdater setCallbackUrl(Uri callbackUrl) {
            this.callbackUrl = callbackUrl;
            return this;
        }
    
        /**
         * Twilio will make a request to this url when the trigger fires.
         * 
         * @param callbackUrl URL Twilio will request when the trigger fires
         * @return this
         */
        public TriggerUpdater setCallbackUrl(string callbackUrl) {
            return setCallbackUrl(Promoter.UriFromString(callbackUrl));
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public TriggerUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated TriggerResource
         */
        public override async Task<TriggerResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TriggerResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            return TriggerResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (callbackMethod != null) {
                request.AddPostParam("CallbackMethod", callbackMethod.ToString());
            }
            
            if (callbackUrl != null) {
                request.AddPostParam("CallbackUrl", callbackUrl.ToString());
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}