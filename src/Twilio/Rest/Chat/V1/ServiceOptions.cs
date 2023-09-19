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



namespace Twilio.Rest.Chat.V1
{

    /// <summary> create </summary>
    public class CreateServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; }


        /// <summary> Construct a new CreateServiceOptions </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
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
        
        ///<summary> The Twilio-provided string that uniquely identifies the Service resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteServiceOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Service resource to delete. </param>
        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> fetch </summary>
    public class FetchServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Service resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Service resource to fetch. </param>
        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadServiceOptions : ReadOptions<ServiceResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
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
    
        ///<summary> The Twilio-provided string that uniquely identifies the Service resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The service role assigned to users when they are added to the service. See the [Roles endpoint](https://www.twilio.com/docs/chat/api/roles) for more details. </summary> 
        public string DefaultServiceRoleSid { get; set; }

        ///<summary> The channel role assigned to users when they are added to a channel. See the [Roles endpoint](https://www.twilio.com/docs/chat/api/roles) for more details. </summary> 
        public string DefaultChannelRoleSid { get; set; }

        ///<summary> The channel role assigned to a channel creator when they join a new channel. See the [Roles endpoint](https://www.twilio.com/docs/chat/api/roles) for more details. </summary> 
        public string DefaultChannelCreatorRoleSid { get; set; }

        ///<summary> Whether to enable the [Message Consumption Horizon](https://www.twilio.com/docs/chat/consumption-horizon) feature. The default is `true`. </summary> 
        public bool? ReadStatusEnabled { get; set; }

        ///<summary> Whether to enable the [Reachability Indicator](https://www.twilio.com/docs/chat/reachability-indicator) for this Service instance. The default is `false`. </summary> 
        public bool? ReachabilityEnabled { get; set; }

        ///<summary> How long in seconds after a `started typing` event until clients should assume that user is no longer typing, even if no `ended typing` message was received.  The default is 5 seconds. </summary> 
        public int? TypingIndicatorTimeout { get; set; }

        ///<summary> DEPRECATED. The interval in seconds between consumption reports submission batches from client endpoints. </summary> 
        public int? ConsumptionReportInterval { get; set; }

        ///<summary> Whether to send a notification when a new message is added to a channel. Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? NotificationsNewMessageEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed when a new message is added to a channel and `notifications.new_message.enabled` is `true`. </summary> 
        public string NotificationsNewMessageTemplate { get; set; }

        ///<summary> Whether to send a notification when a member is added to a channel. Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? NotificationsAddedToChannelEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed when a member is added to a channel and `notifications.added_to_channel.enabled` is `true`. </summary> 
        public string NotificationsAddedToChannelTemplate { get; set; }

        ///<summary> Whether to send a notification to a user when they are removed from a channel. Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? NotificationsRemovedFromChannelEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed to a user when they are removed from a channel and `notifications.removed_from_channel.enabled` is `true`. </summary> 
        public string NotificationsRemovedFromChannelTemplate { get; set; }

        ///<summary> Whether to send a notification when a user is invited to a channel. Can be: `true` or `false` and the default is `false`. </summary> 
        public bool? NotificationsInvitedToChannelEnabled { get; set; }

        ///<summary> The template to use to create the notification text displayed when a user is invited to a channel and `notifications.invited_to_channel.enabled` is `true`. </summary> 
        public string NotificationsInvitedToChannelTemplate { get; set; }

        ///<summary> The URL for pre-event webhooks, which are called by using the `webhook_method`. See [Webhook Events](https://www.twilio.com/docs/api/chat/webhooks) for more details. </summary> 
        public Uri PreWebhookUrl { get; set; }

        ///<summary> The URL for post-event webhooks, which are called by using the `webhook_method`. See [Webhook Events](https://www.twilio.com/docs/api/chat/webhooks) for more details. </summary> 
        public Uri PostWebhookUrl { get; set; }

        ///<summary> The HTTP method to use for calls to the `pre_webhook_url` and `post_webhook_url` webhooks.  Can be: `POST` or `GET` and the default is `POST`. See [Webhook Events](https://www.twilio.com/docs/chat/webhook-events) for more details. </summary> 
        public Twilio.Http.HttpMethod WebhookMethod { get; set; }

        ///<summary> The list of WebHook events that are enabled for this Service instance. See [Webhook Events](https://www.twilio.com/docs/chat/webhook-events) for more details. </summary> 
        public List<string> WebhookFilters { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_send` event using the `webhooks.on_message_send.method` HTTP method. </summary> 
        public Uri WebhooksOnMessageSendUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_message_send.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMessageSendMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_update` event using the `webhooks.on_message_update.method` HTTP method. </summary> 
        public Uri WebhooksOnMessageUpdateUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_message_update.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMessageUpdateMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_remove` event using the `webhooks.on_message_remove.method` HTTP method. </summary> 
        public Uri WebhooksOnMessageRemoveUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_message_remove.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMessageRemoveMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_add` event using the `webhooks.on_channel_add.method` HTTP method. </summary> 
        public Uri WebhooksOnChannelAddUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_channel_add.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnChannelAddMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_destroy` event using the `webhooks.on_channel_destroy.method` HTTP method. </summary> 
        public Uri WebhooksOnChannelDestroyUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_channel_destroy.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnChannelDestroyMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_update` event using the `webhooks.on_channel_update.method` HTTP method. </summary> 
        public Uri WebhooksOnChannelUpdateUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_channel_update.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnChannelUpdateMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_member_add` event using the `webhooks.on_member_add.method` HTTP method. </summary> 
        public Uri WebhooksOnMemberAddUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_member_add.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMemberAddMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_member_remove` event using the `webhooks.on_member_remove.method` HTTP method. </summary> 
        public Uri WebhooksOnMemberRemoveUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_member_remove.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMemberRemoveMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_sent` event using the `webhooks.on_message_sent.method` HTTP method. </summary> 
        public Uri WebhooksOnMessageSentUrl { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_sent` event`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMessageSentMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_updated` event using the `webhooks.on_message_updated.method` HTTP method. </summary> 
        public Uri WebhooksOnMessageUpdatedUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_message_updated.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMessageUpdatedMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_message_removed` event using the `webhooks.on_message_removed.method` HTTP method. </summary> 
        public Uri WebhooksOnMessageRemovedUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_message_removed.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMessageRemovedMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_added` event using the `webhooks.on_channel_added.method` HTTP method. </summary> 
        public Uri WebhooksOnChannelAddedUrl { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_added` event`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnChannelAddedMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_added` event using the `webhooks.on_channel_destroyed.method` HTTP method. </summary> 
        public Uri WebhooksOnChannelDestroyedUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_channel_destroyed.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnChannelDestroyedMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_updated` event using the `webhooks.on_channel_updated.method` HTTP method. </summary> 
        public Uri WebhooksOnChannelUpdatedUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_channel_updated.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnChannelUpdatedMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_channel_updated` event using the `webhooks.on_channel_updated.method` HTTP method. </summary> 
        public Uri WebhooksOnMemberAddedUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_channel_updated.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMemberAddedMethod { get; set; }

        ///<summary> The URL of the webhook to call in response to the `on_member_removed` event using the `webhooks.on_member_removed.method` HTTP method. </summary> 
        public Uri WebhooksOnMemberRemovedUrl { get; set; }

        ///<summary> The HTTP method to use when calling the `webhooks.on_member_removed.url`. </summary> 
        public Twilio.Http.HttpMethod WebhooksOnMemberRemovedMethod { get; set; }

        ///<summary> The maximum number of Members that can be added to Channels within this Service. Can be up to 1,000. </summary> 
        public int? LimitsChannelMembers { get; set; }

        ///<summary> The maximum number of Channels Users can be a Member of within this Service. Can be up to 1,000. </summary> 
        public int? LimitsUserChannels { get; set; }



        /// <summary> Construct a new UpdateServiceOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Service resource to update. </param>
        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
            WebhookFilters = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
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
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Enabled", NotificationsNewMessageEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsNewMessageTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Template", NotificationsNewMessageTemplate));
            }
            if (NotificationsAddedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Enabled", NotificationsAddedToChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsAddedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Template", NotificationsAddedToChannelTemplate));
            }
            if (NotificationsRemovedFromChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Enabled", NotificationsRemovedFromChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsRemovedFromChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Template", NotificationsRemovedFromChannelTemplate));
            }
            if (NotificationsInvitedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Enabled", NotificationsInvitedToChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsInvitedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Template", NotificationsInvitedToChannelTemplate));
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
            if (WebhooksOnMessageSendUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSend.Url", Serializers.Url(WebhooksOnMessageSendUrl)));
            }
            if (WebhooksOnMessageSendMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSend.Method", WebhooksOnMessageSendMethod.ToString()));
            }
            if (WebhooksOnMessageUpdateUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdate.Url", Serializers.Url(WebhooksOnMessageUpdateUrl)));
            }
            if (WebhooksOnMessageUpdateMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdate.Method", WebhooksOnMessageUpdateMethod.ToString()));
            }
            if (WebhooksOnMessageRemoveUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemove.Url", Serializers.Url(WebhooksOnMessageRemoveUrl)));
            }
            if (WebhooksOnMessageRemoveMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemove.Method", WebhooksOnMessageRemoveMethod.ToString()));
            }
            if (WebhooksOnChannelAddUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdd.Url", Serializers.Url(WebhooksOnChannelAddUrl)));
            }
            if (WebhooksOnChannelAddMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdd.Method", WebhooksOnChannelAddMethod.ToString()));
            }
            if (WebhooksOnChannelDestroyUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroy.Url", Serializers.Url(WebhooksOnChannelDestroyUrl)));
            }
            if (WebhooksOnChannelDestroyMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroy.Method", WebhooksOnChannelDestroyMethod.ToString()));
            }
            if (WebhooksOnChannelUpdateUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdate.Url", Serializers.Url(WebhooksOnChannelUpdateUrl)));
            }
            if (WebhooksOnChannelUpdateMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdate.Method", WebhooksOnChannelUpdateMethod.ToString()));
            }
            if (WebhooksOnMemberAddUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdd.Url", Serializers.Url(WebhooksOnMemberAddUrl)));
            }
            if (WebhooksOnMemberAddMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdd.Method", WebhooksOnMemberAddMethod.ToString()));
            }
            if (WebhooksOnMemberRemoveUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemove.Url", Serializers.Url(WebhooksOnMemberRemoveUrl)));
            }
            if (WebhooksOnMemberRemoveMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemove.Method", WebhooksOnMemberRemoveMethod.ToString()));
            }
            if (WebhooksOnMessageSentUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSent.Url", Serializers.Url(WebhooksOnMessageSentUrl)));
            }
            if (WebhooksOnMessageSentMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSent.Method", WebhooksOnMessageSentMethod.ToString()));
            }
            if (WebhooksOnMessageUpdatedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdated.Url", Serializers.Url(WebhooksOnMessageUpdatedUrl)));
            }
            if (WebhooksOnMessageUpdatedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdated.Method", WebhooksOnMessageUpdatedMethod.ToString()));
            }
            if (WebhooksOnMessageRemovedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemoved.Url", Serializers.Url(WebhooksOnMessageRemovedUrl)));
            }
            if (WebhooksOnMessageRemovedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemoved.Method", WebhooksOnMessageRemovedMethod.ToString()));
            }
            if (WebhooksOnChannelAddedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdded.Url", Serializers.Url(WebhooksOnChannelAddedUrl)));
            }
            if (WebhooksOnChannelAddedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdded.Method", WebhooksOnChannelAddedMethod.ToString()));
            }
            if (WebhooksOnChannelDestroyedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroyed.Url", Serializers.Url(WebhooksOnChannelDestroyedUrl)));
            }
            if (WebhooksOnChannelDestroyedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroyed.Method", WebhooksOnChannelDestroyedMethod.ToString()));
            }
            if (WebhooksOnChannelUpdatedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdated.Url", Serializers.Url(WebhooksOnChannelUpdatedUrl)));
            }
            if (WebhooksOnChannelUpdatedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdated.Method", WebhooksOnChannelUpdatedMethod.ToString()));
            }
            if (WebhooksOnMemberAddedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdded.Url", Serializers.Url(WebhooksOnMemberAddedUrl)));
            }
            if (WebhooksOnMemberAddedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdded.Method", WebhooksOnMemberAddedMethod.ToString()));
            }
            if (WebhooksOnMemberRemovedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemoved.Url", Serializers.Url(WebhooksOnMemberRemovedUrl)));
            }
            if (WebhooksOnMemberRemovedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemoved.Method", WebhooksOnMemberRemovedMethod.ToString()));
            }
            if (LimitsChannelMembers != null)
            {
                p.Add(new KeyValuePair<string, string>("Limits.ChannelMembers", LimitsChannelMembers.ToString()));
            }
            if (LimitsUserChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("Limits.UserChannels", LimitsUserChannels.ToString()));
            }
            return p;
        }
        

    }


}

