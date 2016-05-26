using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Usage;

namespace Twilio.Creators.Api.V2010.Account.Usage {

    public class TriggerCreator : Creator<TriggerResource> {
        private string accountSid;
        private Uri callbackUrl;
        private string triggerValue;
        private TriggerResource.UsageCategory usageCategory;
        private System.Net.Http.HttpMethod callbackMethod;
        private string friendlyName;
        private TriggerResource.Recurring recurring;
        private TriggerResource.TriggerField triggerBy;
    
        /**
         * Construct a new TriggerCreator
         * 
         * @param accountSid The account_sid
         * @param callbackUrl URL Twilio will request when the trigger fires
         * @param triggerValue the value at which the trigger will fire
         * @param usageCategory The usage category the trigger watches
         */
        public TriggerCreator(string accountSid, Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory) {
            this.accountSid = accountSid;
            this.callbackUrl = callbackUrl;
            this.triggerValue = triggerValue;
            this.usageCategory = usageCategory;
        }
    
        /**
         * The HTTP method Twilio will use when making a request to the CallbackUrl. 
         * GET or POST.
         * 
         * @param callbackMethod HTTP method to use with callback_url
         * @return this
         */
        public TriggerCreator setCallbackMethod(System.Net.Http.HttpMethod callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public TriggerCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * How this trigger recurs. Empty for non-recurring triggers. One of `daily`,
         * `monthly`, or `yearly` for recurring triggers.  A trigger will only fire once
         * during each recurring period.  Recurring periods are in GMT.
         * 
         * @param recurring How this trigger recurs
         * @return this
         */
        public TriggerCreator setRecurring(TriggerResource.Recurring recurring) {
            this.recurring = recurring;
            return this;
        }
    
        /**
         * The field in the UsageRecord that fires the trigger. One of `count`, `usage`,
         * or `price`
         * 
         * @param triggerBy The field in the UsageRecord that fires the trigger
         * @return this
         */
        public TriggerCreator setTriggerBy(TriggerResource.TriggerField triggerBy) {
            this.triggerBy = triggerBy;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created TriggerResource
         */
        public override async Task<TriggerResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("TriggerResource creation failed: Unable to connect to server");
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
            
            return TriggerResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created TriggerResource
         */
        public override TriggerResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TriggerResource creation failed: Unable to connect to server");
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
            
            return TriggerResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (callbackUrl != null) {
                request.AddPostParam("CallbackUrl", callbackUrl.ToString());
            }
            
            if (triggerValue != "") {
                request.AddPostParam("TriggerValue", triggerValue);
            }
            
            if (usageCategory != null) {
                request.AddPostParam("UsageCategory", usageCategory.ToString());
            }
            
            if (callbackMethod != null) {
                request.AddPostParam("CallbackMethod", callbackMethod.ToString());
            }
            
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (recurring != null) {
                request.AddPostParam("Recurring", recurring.ToString());
            }
            
            if (triggerBy != null) {
                request.AddPostParam("TriggerBy", triggerBy.ToString());
            }
        }
    }
}