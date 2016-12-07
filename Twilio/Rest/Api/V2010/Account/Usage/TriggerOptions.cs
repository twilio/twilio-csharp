using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Usage 
{

    public class FetchTriggerOptions : IOptions<TriggerResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchTriggerOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique usage-trigger Sid </param>
        public FetchTriggerOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class UpdateTriggerOptions : IOptions<TriggerResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }
        public Uri CallbackUrl { get; set; }
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateTriggerOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateTriggerOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod.ToString()));
            }
            
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", CallbackUrl.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

    public class DeleteTriggerOptions : IOptions<TriggerResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteTriggerOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteTriggerOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class CreateTriggerOptions : IOptions<TriggerResource> 
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
        /// Construct a new CreateTriggerOptions
        /// </summary>
        ///
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        public CreateTriggerOptions(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategoryEnum usageCategory)
        {
            CallbackUrl = callbackUrl;
            TriggerValue = triggerValue;
            UsageCategory = usageCategory;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", CallbackUrl.ToString()));
            }
            
            if (TriggerValue != null)
            {
                p.Add(new KeyValuePair<string, string>("TriggerValue", TriggerValue));
            }
            
            if (UsageCategory != null)
            {
                p.Add(new KeyValuePair<string, string>("UsageCategory", UsageCategory.ToString()));
            }
            
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (Recurring != null)
            {
                p.Add(new KeyValuePair<string, string>("Recurring", Recurring.ToString()));
            }
            
            if (TriggerBy != null)
            {
                p.Add(new KeyValuePair<string, string>("TriggerBy", TriggerBy.ToString()));
            }
            
            return p;
        }
    }

    public class ReadTriggerOptions : ReadOptions<TriggerResource> 
    {
        public string AccountSid { get; set; }
        public TriggerResource.RecurringEnum Recurring { get; set; }
        public TriggerResource.TriggerFieldEnum TriggerBy { get; set; }
        public TriggerResource.UsageCategoryEnum UsageCategory { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Recurring != null)
            {
                p.Add(new KeyValuePair<string, string>("Recurring", Recurring.ToString()));
            }
            
            if (TriggerBy != null)
            {
                p.Add(new KeyValuePair<string, string>("TriggerBy", TriggerBy.ToString()));
            }
            
            if (UsageCategory != null)
            {
                p.Add(new KeyValuePair<string, string>("UsageCategory", UsageCategory.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}