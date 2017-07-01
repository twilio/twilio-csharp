using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync 
{

    /// <summary>
    /// FetchServiceOptions
    /// </summary>
    public class FetchServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
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

    /// <summary>
    /// DeleteServiceOptions
    /// </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
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

    /// <summary>
    /// CreateServiceOptions
    /// </summary>
    public class CreateServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The webhook_url
        /// </summary>
        public Uri WebhookUrl { get; set; }
        /// <summary>
        /// The reachability_webhooks_enabled
        /// </summary>
        public bool? ReachabilityWebhooksEnabled { get; set; }
        /// <summary>
        /// The acl_enabled
        /// </summary>
        public bool? AclEnabled { get; set; }

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
                p.Add(new KeyValuePair<string, string>("WebhookUrl", WebhookUrl.AbsoluteUri));
            }

            if (ReachabilityWebhooksEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityWebhooksEnabled", ReachabilityWebhooksEnabled.Value.ToString()));
            }

            if (AclEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("AclEnabled", AclEnabled.Value.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// ReadServiceOptions
    /// </summary>
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

    /// <summary>
    /// UpdateServiceOptions
    /// </summary>
    public class UpdateServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The webhook_url
        /// </summary>
        public Uri WebhookUrl { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The reachability_webhooks_enabled
        /// </summary>
        public bool? ReachabilityWebhooksEnabled { get; set; }
        /// <summary>
        /// The acl_enabled
        /// </summary>
        public bool? AclEnabled { get; set; }

        /// <summary>
        /// Construct a new UpdateServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (WebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookUrl", WebhookUrl.AbsoluteUri));
            }

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (ReachabilityWebhooksEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityWebhooksEnabled", ReachabilityWebhooksEnabled.Value.ToString()));
            }

            if (AclEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("AclEnabled", AclEnabled.Value.ToString()));
            }

            return p;
        }
    }

}