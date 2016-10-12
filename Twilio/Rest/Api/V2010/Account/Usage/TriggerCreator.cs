using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Usage {

    public class TriggerCreator : Creator<TriggerResource> {
        private string accountSid;
        private Uri callbackUrl;
        private string triggerValue;
        private TriggerResource.UsageCategory usageCategory;
        private Twilio.Http.HttpMethod callbackMethod;
        private string friendlyName;
        private TriggerResource.Recurring recurring;
        private TriggerResource.TriggerField triggerBy;
    
        /// <summary>
        /// Construct a new TriggerCreator.
        /// </summary>
        ///
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        public TriggerCreator(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory) {
            this.callbackUrl = callbackUrl;
            this.triggerValue = triggerValue;
            this.usageCategory = usageCategory;
        }
    
        /// <summary>
        /// Construct a new TriggerCreator
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        public TriggerCreator(string accountSid, Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory) {
            this.accountSid = accountSid;
            this.callbackUrl = callbackUrl;
            this.triggerValue = triggerValue;
            this.usageCategory = usageCategory;
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when making a request to the CallbackUrl.  GET or POST.
        /// </summary>
        ///
        /// <param name="callbackMethod"> HTTP method to use with callback_url </param>
        /// <returns> this </returns> 
        public TriggerCreator setCallbackMethod(Twilio.Http.HttpMethod callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /// <summary>
        /// A user-specified, human-readable name for the trigger.
        /// </summary>
        ///
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <returns> this </returns> 
        public TriggerCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// How this trigger recurs. Empty for non-recurring triggers. One of `daily`, `monthly`, or `yearly` for recurring
        /// triggers.  A trigger will only fire once during each recurring period.  Recurring periods are in GMT.
        /// </summary>
        ///
        /// <param name="recurring"> How this trigger recurs </param>
        /// <returns> this </returns> 
        public TriggerCreator setRecurring(TriggerResource.Recurring recurring) {
            this.recurring = recurring;
            return this;
        }
    
        /// <summary>
        /// The field in the UsageRecord that fires the trigger. One of `count`, `usage`, or `price`
        /// </summary>
        ///
        /// <param name="triggerBy"> The field in the UsageRecord that fires the trigger </param>
        /// <returns> this </returns> 
        public TriggerCreator setTriggerBy(TriggerResource.TriggerField triggerBy) {
            this.triggerBy = triggerBy;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TriggerResource </returns> 
        public override async Task<TriggerResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Usage/Triggers.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TriggerResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TriggerResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TriggerResource </returns> 
        public override TriggerResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Usage/Triggers.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TriggerResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TriggerResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (callbackUrl != null) {
                request.AddPostParam("CallbackUrl", callbackUrl.ToString());
            }
            
            if (triggerValue != null) {
                request.AddPostParam("TriggerValue", triggerValue);
            }
            
            if (usageCategory != null) {
                request.AddPostParam("UsageCategory", usageCategory.ToString());
            }
            
            if (callbackMethod != null) {
                request.AddPostParam("CallbackMethod", callbackMethod.ToString());
            }
            
            if (friendlyName != null) {
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