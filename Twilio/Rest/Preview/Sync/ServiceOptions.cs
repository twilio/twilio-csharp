using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync 
{

    public class FetchServiceOptions : IOptions<ServiceResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchServiceOptions(string sid)
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

    public class DeleteServiceOptions : IOptions<ServiceResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteServiceOptions(string sid)
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

    public class CreateServiceOptions : IOptions<ServiceResource> 
    {
        public string FriendlyName { get; set; }
        public Uri WebhookUrl { get; set; }
        public bool? ReachabilityWebhooksEnabled { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (WebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookUrl", WebhookUrl.ToString()));
            }
            
            if (ReachabilityWebhooksEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityWebhooksEnabled", ReachabilityWebhooksEnabled.ToString()));
            }
            
            return p;
        }
    }

    public class ReadServiceOptions : ReadOptions<ServiceResource> 
    {
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateServiceOptions : IOptions<ServiceResource> 
    {
        public string Sid { get; }
        public Uri WebhookUrl { get; set; }
        public string FriendlyName { get; set; }
        public bool? ReachabilityWebhooksEnabled { get; set; }
    
        /// <summary>
        /// Construct a new UpdateServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateServiceOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (WebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookUrl", WebhookUrl.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (ReachabilityWebhooksEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityWebhooksEnabled", ReachabilityWebhooksEnabled.ToString()));
            }
            
            return p;
        }
    }

}