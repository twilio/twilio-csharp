/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Chat
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



namespace Twilio.Rest.Chat.V2
{

    /// <summary> create </summary>
    public class CreateServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> A descriptive string that you create to describe the new resource. </summary> 
        public string FriendlyName { get; }


        /// <summary> Construct a new CreateServiceOptions </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. </param>

        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> The SID of the Service resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteServiceOptions </summary>
        /// <param name="pathSid"> The SID of the Service resource to delete. </param>

        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> fetch </summary>
    public class FetchServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The SID of the Service resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceOptions </summary>
        /// <param name="pathSid"> The SID of the Service resource to fetch. </param>

        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadServiceOptions : ReadOptions<ServiceResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> update </summary>
    public class UpdateServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The SID of the Service resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The service role assigned to users when they are added to the service. See the [Role resource](https://www.twilio.com/docs/chat/rest/role-resource) for more info about roles. </summary> 
        public string DefaultServiceRoleSid { get; set; }

        ///<summary> The channel role assigned to users when they are added to a channel. See the [Role resource](https://www.twilio.com/docs/chat/rest/role-resource) for more info about roles. </summary> 
        public string DefaultChannelRoleSid { get; set; }

        ///<summary> The channel role assigned to a channel creator when they join a new channel. See the [Role resource](https://www.twilio.com/docs/chat/rest/role-resource) for more info about roles. </summary> 
        public string DefaultChannelCreatorRoleSid { get; set; }

        ///<summary> Whether to enable the [Message Consumption Horizon](https://www.twilio.com/docs/chat/consumption-horizon) feature. The default is `true`. </summary> 
        public bool? ReadStatusEnabled { get; set; }

        ///<summary> Whether to enable the [Reachability Indicator](https://www.twilio.com/docs/chat/reachability-indicator) for this Service instance. The default is `false`. </summary> 
        public bool? ReachabilityEnabled { get; set; }

        ///<summary> How long in seconds after a `started typing` event until clients should assume that user is no longer typing, even if no `ended typing` message was received.  The default is 5 seconds. </summary> 
        public int? TypingIndicatorTimeout { get; set; }

        ///<summary> DEPRECATED. The interval in seconds between consumption reports submission batches from client endpoints. </summary> 
        public int? ConsumptionReportInterval { get; set; }

        ///<summary> Whether to send a notification when a new message is added to a channel. The default is `false`. </summary> 
        public bool? NotificationsNewMessageEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed when a new message is added to a channel and `notifications.new_message.enabled` is `true`. </summary> 
        public string NotificationsNewMessageTemplate { get; set; }

        ///<summary> The name of the sound to play when a new message is added to a channel and `notifications.new_message.enabled` is `true`. </summary> 
        public string NotificationsNewMessageSound { get; set; }

        ///<summary> Whether the new message badge is enabled. The default is `false`. </summary> 
        public bool? NotificationsNewMessageBadgeCountEnabled { get; set; }

        ///<summary> Whether to send a notification when a member is added to a channel. The default is `false`. </summary> 
        public bool? NotificationsAddedToChannelEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed when a member is added to a channel and `notifications.added_to_channel.enabled` is `true`. </summary> 
        public string NotificationsAddedToChannelTemplate { get; set; }

        ///<summary> The name of the sound to play when a member is added to a channel and `notifications.added_to_channel.enabled` is `true`. </summary> 
        public string NotificationsAddedToChannelSound { get; set; }

        ///<summary> Whether to send a notification to a user when they are removed from a channel. The default is `false`. </summary> 
        public bool? NotificationsRemovedFromChannelEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed to a user when they are removed from a channel and `notifications.removed_from_channel.enabled` is `true`. </summary> 
        public string NotificationsRemovedFromChannelTemplate { get; set; }

        ///<summary> The name of the sound to play to a user when they are removed from a channel and `notifications.removed_from_channel.enabled` is `true`. </summary> 
        public string NotificationsRemovedFromChannelSound { get; set; }

        ///<summary> Whether to send a notification when a user is invited to a channel. The default is `false`. </summary> 
        public bool? NotificationsInvitedToChannelEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed when a user is invited to a channel and `notifications.invited_to_channel.enabled` is `true`. </summary> 
        public string NotificationsInvitedToChannelTemplate { get; set; }

        ///<summary> The name of the sound to play when a user is invited to a channel and `notifications.invited_to_channel.enabled` is `true`. </summary> 
        public string NotificationsInvitedToChannelSound { get; set; }

        ///<summary> The URL for pre-event webhooks, which are called by using the `webhook_method`. See [Webhook Events](https://www.twilio.com/docs/chat/webhook-events) for more details. </summary> 
        public Uri PreWebhookUrl { get; set; }

        ///<summary> The URL for post-event webhooks, which are called by using the `webhook_method`. See [Webhook Events](https://www.twilio.com/docs/chat/webhook-events) for more details. </summary> 
        public Uri PostWebhookUrl { get; set; }

        ///<summary> The HTTP method to use for calls to the `pre_webhook_url` and `post_webhook_url` webhooks.  Can be: `POST` or `GET` and the default is `POST`. See [Webhook Events](https://www.twilio.com/docs/chat/webhook-events) for more details. </summary> 
        public Twilio.Http.HttpMethod WebhookMethod { get; set; }

        ///<summary> The list of webhook events that are enabled for this Service instance. See [Webhook Events](https://www.twilio.com/docs/chat/webhook-events) for more details. </summary> 
        public List<string> WebhookFilters { get; set; }

        ///<summary> The maximum number of Members that can be added to Channels within this Service. Can be up to 1,000. </summary> 
        public int? LimitsChannelMembers { get; set; }

        ///<summary> The maximum number of Channels Users can be a Member of within this Service. Can be up to 1,000. </summary> 
        public int? LimitsUserChannels { get; set; }

        ///<summary> The message to send when a media message has no text. Can be used as placeholder message. </summary> 
        public string MediaCompatibilityMessage { get; set; }

        ///<summary> The number of times to retry a call to the `pre_webhook_url` if the request times out (after 5 seconds) or it receives a 429, 503, or 504 HTTP response. Default retry count is 0 times, which means the call won't be retried. </summary> 
        public int? PreWebhookRetryCount { get; set; }

        ///<summary> The number of times to retry a call to the `post_webhook_url` if the request times out (after 5 seconds) or it receives a 429, 503, or 504 HTTP response. The default is 0, which means the call won't be retried. </summary> 
        public int? PostWebhookRetryCount { get; set; }

        ///<summary> Whether to log notifications. The default is `false`. </summary> 
        public bool? NotificationsLogEnabled { get; set; }



        /// <summary> Construct a new UpdateServiceOptions </summary>
        /// <param name="pathSid"> The SID of the Service resource to update. </param>

        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
            WebhookFilters = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (DefaultServiceRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultServiceRoleSid", DefaultServiceRoleSid));
            }
            if (DefaultChannelRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChannelRoleSid", DefaultChannelRoleSid));
            }
            if (DefaultChannelCreatorRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChannelCreatorRoleSid", DefaultChannelCreatorRoleSid));
            }
            if (ReadStatusEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReadStatusEnabled", ReadStatusEnabled.Value.ToString().ToLower()));
            }
            if (ReachabilityEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityEnabled", ReachabilityEnabled.Value.ToString().ToLower()));
            }
            if (TypingIndicatorTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("TypingIndicatorTimeout", TypingIndicatorTimeout.ToString()));
            }
            if (ConsumptionReportInterval != null)
            {
                p.Add(new KeyValuePair<string, string>("ConsumptionReportInterval", ConsumptionReportInterval.ToString()));
            }
            if (NotificationsNewMessageEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageEnabled", NotificationsNewMessageEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsNewMessageTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageTemplate", NotificationsNewMessageTemplate));
            }
            if (NotificationsNewMessageSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageSound", NotificationsNewMessageSound));
            }
            if (NotificationsNewMessageBadgeCountEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageBadgeCountEnabled", NotificationsNewMessageBadgeCountEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsAddedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsAddedToChannelEnabled", NotificationsAddedToChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsAddedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsAddedToChannelTemplate", NotificationsAddedToChannelTemplate));
            }
            if (NotificationsAddedToChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsAddedToChannelSound", NotificationsAddedToChannelSound));
            }
            if (NotificationsRemovedFromChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsRemovedFromChannelEnabled", NotificationsRemovedFromChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsRemovedFromChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsRemovedFromChannelTemplate", NotificationsRemovedFromChannelTemplate));
            }
            if (NotificationsRemovedFromChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsRemovedFromChannelSound", NotificationsRemovedFromChannelSound));
            }
            if (NotificationsInvitedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsInvitedToChannelEnabled", NotificationsInvitedToChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsInvitedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsInvitedToChannelTemplate", NotificationsInvitedToChannelTemplate));
            }
            if (NotificationsInvitedToChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsInvitedToChannelSound", NotificationsInvitedToChannelSound));
            }
            if (PreWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookUrl", Serializers.Url(PreWebhookUrl)));
            }
            if (PostWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookUrl", Serializers.Url(PostWebhookUrl)));
            }
            if (WebhookMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookMethod", WebhookMethod.ToString()));
            }
            if (WebhookFilters != null)
            {
                p.AddRange(WebhookFilters.Select(WebhookFilters => new KeyValuePair<string, string>("WebhookFilters", WebhookFilters)));
            }
            if (LimitsChannelMembers != null)
            {
                p.Add(new KeyValuePair<string, string>("LimitsChannelMembers", LimitsChannelMembers.ToString()));
            }
            if (LimitsUserChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("LimitsUserChannels", LimitsUserChannels.ToString()));
            }
            if (MediaCompatibilityMessage != null)
            {
                p.Add(new KeyValuePair<string, string>("MediaCompatibilityMessage", MediaCompatibilityMessage));
            }
            if (PreWebhookRetryCount != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookRetryCount", PreWebhookRetryCount.ToString()));
            }
            if (PostWebhookRetryCount != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookRetryCount", PostWebhookRetryCount.ToString()));
            }
            if (NotificationsLogEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsLogEnabled", NotificationsLogEnabled.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


}

