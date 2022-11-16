/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Conversations
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using System.Linq;



namespace Twilio.Rest.Conversations.V1.Service.Configuration
{
    /// <summary> Fetch a specific service webhook configuration. </summary>
    public class FetchWebhookOptions : IOptions<WebhookResource>
    {
    
        ///<summary> The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to. </summary> 
        public string PathChatServiceSid { get; }



        /// <summary> Construct a new FetchServiceWebhookConfigurationOptions </summary>
        /// <param name="pathChatServiceSid"> The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to. </param>

        public FetchWebhookOptions(string pathChatServiceSid)
        {
            PathChatServiceSid = pathChatServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Update a specific Webhook. </summary>
    public class UpdateWebhookOptions : IOptions<WebhookResource>
    {
    
        ///<summary> The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The absolute url the pre-event webhook request should be sent to. </summary> 
        public Uri PreWebhookUrl { get; set; }

        ///<summary> The absolute url the post-event webhook request should be sent to. </summary> 
        public Uri PostWebhookUrl { get; set; }

        ///<summary> The list of events that your configured webhook targets will receive. Events not configured here will not fire. Possible values are `onParticipantAdd`, `onParticipantAdded`, `onDeliveryUpdated`, `onConversationUpdated`, `onConversationRemove`, `onParticipantRemove`, `onConversationUpdate`, `onMessageAdd`, `onMessageRemoved`, `onParticipantUpdated`, `onConversationAdded`, `onMessageAdded`, `onConversationAdd`, `onConversationRemoved`, `onParticipantUpdate`, `onMessageRemove`, `onMessageUpdated`, `onParticipantRemoved`, `onMessageUpdate` or `onConversationStateUpdated`. </summary> 
        public List<string> Filters { get; set; }

        ///<summary> The HTTP method to be used when sending a webhook request. One of `GET` or `POST`. </summary> 
        public string Method { get; set; }



        /// <summary> Construct a new UpdateServiceWebhookConfigurationOptions </summary>
        /// <param name="pathChatServiceSid"> The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to. </param>

        public UpdateWebhookOptions(string pathChatServiceSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            Filters = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
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
                p.AddRange(Filters.Select(Filters => new KeyValuePair<string, string>("Filters", Filters)));
            }
            if (Method != null)
            {
                p.Add(new KeyValuePair<string, string>("Method", Method));
            }
            return p;
        }
        

    }


}

