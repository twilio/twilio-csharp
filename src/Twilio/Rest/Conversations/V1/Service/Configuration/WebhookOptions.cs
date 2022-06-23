/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Conversations.V1.Service.Configuration
{

    /// <summary>
    /// Update a specific Webhook.
    /// </summary>
    public class UpdateWebhookOptions : IOptions<WebhookResource>
    {
        /// <summary>
        /// The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to.
        /// </summary>
        public string PathChatServiceSid { get; }
        /// <summary>
        /// The absolute url the pre-event webhook request should be sent to.
        /// </summary>
        public Uri PreWebhookUrl { get; set; }
        /// <summary>
        /// The absolute url the post-event webhook request should be sent to.
        /// </summary>
        public Uri PostWebhookUrl { get; set; }
        /// <summary>
        /// The list of events that your configured webhook targets will receive. Events not configured here will not fire.
        /// </summary>
        public List<string> Filters { get; set; }
        /// <summary>
        /// The HTTP method to be used when sending a webhook request
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Construct a new UpdateWebhookOptions
        /// </summary>
        /// <param name="pathChatServiceSid"> The unique ID of the [Conversation
        ///                          Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation
        ///                          belongs to. </param>
        public UpdateWebhookOptions(string pathChatServiceSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            Filters = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PreWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookUrl", Serializers.Url(PreWebhookUrl)));
            }

            if (PostWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookUrl", Serializers.Url(PostWebhookUrl)));
            }

            if (Filters != null)
            {
                p.AddRange(Filters.Select(prop => new KeyValuePair<string, string>("Filters", prop)));
            }

            if (Method != null)
            {
                p.Add(new KeyValuePair<string, string>("Method", Method));
            }

            return p;
        }
    }

    /// <summary>
    /// Fetch a specific service webhook configuration.
    /// </summary>
    public class FetchWebhookOptions : IOptions<WebhookResource>
    {
        /// <summary>
        /// The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to.
        /// </summary>
        public string PathChatServiceSid { get; }

        /// <summary>
        /// Construct a new FetchWebhookOptions
        /// </summary>
        /// <param name="pathChatServiceSid"> The unique ID of the [Conversation
        ///                          Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation
        ///                          belongs to. </param>
        public FetchWebhookOptions(string pathChatServiceSid)
        {
            PathChatServiceSid = pathChatServiceSid;
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

}