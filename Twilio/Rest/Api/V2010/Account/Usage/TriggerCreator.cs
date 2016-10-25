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
        public string accountSid { get; }
        public Uri callbackUrl { get; }
        public string triggerValue { get; }
        public TriggerResource.UsageCategory usageCategory { get; }
        public Twilio.Http.HttpMethod callbackMethod { get; set; }
        public string friendlyName { get; set; }
        public TriggerResource.Recurring recurring { get; set; }
        public TriggerResource.TriggerField triggerBy { get; set; }
    
        /// <summary>
        /// Construct a new TriggerCreator
        /// </summary>
        ///
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callbackMethod"> HTTP method to use with callback_url </param>
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <param name="recurring"> How this trigger recurs </param>
        /// <param name="triggerBy"> The field in the UsageRecord that fires the trigger </param>
        public TriggerCreator(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory, string accountSid=null, Twilio.Http.HttpMethod callbackMethod=null, string friendlyName=null, TriggerResource.Recurring recurring=null, TriggerResource.TriggerField triggerBy=null) {
            this.callbackMethod = callbackMethod;
            this.triggerValue = triggerValue;
            this.callbackUrl = callbackUrl;
            this.triggerBy = triggerBy;
            this.accountSid = accountSid;
            this.recurring = recurring;
            this.friendlyName = friendlyName;
            this.usageCategory = usageCategory;
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
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Usage/Triggers.json"
            );
            
            AddPostParams(request);
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
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Usage/Triggers.json"
            );
            
            AddPostParams(request);
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
        private void AddPostParams(Request request) {
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