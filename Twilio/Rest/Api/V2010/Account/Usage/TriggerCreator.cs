using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Usage 
{

    public class TriggerCreator : Creator<TriggerResource> 
    {
        public string AccountSid { get; set; }
        public Uri CallbackUrl { get; }
        public string TriggerValue { get; }
        public TriggerResource.UsageCategoryEnum UsageCategory { get; }
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }
        public string FriendlyName { get; set; }
        public TriggerResource.RecurringEnum Recurring { get; set; }
        public TriggerResource.TriggerFieldEnum TriggerBy { get; set; }
    
        /// <summary>
        /// Construct a new TriggerCreator
        /// </summary>
        ///
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        public TriggerCreator(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategoryEnum usageCategory)
        {
            CallbackUrl = callbackUrl;
            TriggerValue = triggerValue;
            UsageCategory = usageCategory;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TriggerResource </returns> 
        public override async System.Threading.Tasks.Task<TriggerResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Usage/Triggers.json"
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
        public override TriggerResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Usage/Triggers.json"
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
        private void AddPostParams(Request request)
        {
            if (CallbackUrl != null)
            {
                request.AddPostParam("CallbackUrl", CallbackUrl.ToString());
            }
            
            if (TriggerValue != null)
            {
                request.AddPostParam("TriggerValue", TriggerValue);
            }
            
            if (UsageCategory != null)
            {
                request.AddPostParam("UsageCategory", UsageCategory.ToString());
            }
            
            if (CallbackMethod != null)
            {
                request.AddPostParam("CallbackMethod", CallbackMethod.ToString());
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (Recurring != null)
            {
                request.AddPostParam("Recurring", Recurring.ToString());
            }
            
            if (TriggerBy != null)
            {
                request.AddPostParam("TriggerBy", TriggerBy.ToString());
            }
        }
    }
}