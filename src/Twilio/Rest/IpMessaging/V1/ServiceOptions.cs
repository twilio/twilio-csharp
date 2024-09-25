/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Ip_messaging
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



namespace Twilio.Rest.IpMessaging.V1
{

    /// <summary> create </summary>
    public class CreateServiceOptions : IOptions<ServiceResource>
    {
        
        
        public string FriendlyName { get; }


        /// <summary> Construct a new CreateServiceOptions </summary>
        /// <param name="friendlyName">  </param>
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
        
        
        public string PathSid { get; }



        /// <summary> Construct a new DeleteServiceOptions </summary>
        /// <param name="pathSid">  </param>
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
    
        
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceOptions </summary>
        /// <param name="pathSid">  </param>
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
    
        
        public string PathSid { get; }

        
        public string FriendlyName { get; set; }

        
        public string DefaultServiceRoleSid { get; set; }

        
        public string DefaultChannelRoleSid { get; set; }

        
        public string DefaultChannelCreatorRoleSid { get; set; }

        
        public bool? ReadStatusEnabled { get; set; }

        
        public bool? ReachabilityEnabled { get; set; }

        
        public int? TypingIndicatorTimeout { get; set; }

        
        public int? ConsumptionReportInterval { get; set; }

        
        public bool? NotificationsNewMessageEnabled { get; set; }

        
        public string NotificationsNewMessageTemplate { get; set; }

        
        public bool? NotificationsAddedToChannelEnabled { get; set; }

        
        public string NotificationsAddedToChannelTemplate { get; set; }

        
        public bool? NotificationsRemovedFromChannelEnabled { get; set; }

        
        public string NotificationsRemovedFromChannelTemplate { get; set; }

        
        public bool? NotificationsInvitedToChannelEnabled { get; set; }

        
        public string NotificationsInvitedToChannelTemplate { get; set; }

        
        public Uri PreWebhookUrl { get; set; }

        
        public Uri PostWebhookUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhookMethod { get; set; }

        
        public List<string> WebhookFilters { get; set; }

        
        public Uri WebhooksOnMessageSendUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMessageSendMethod { get; set; }

        
        public Uri WebhooksOnMessageUpdateUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMessageUpdateMethod { get; set; }

        
        public Uri WebhooksOnMessageRemoveUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMessageRemoveMethod { get; set; }

        
        public Uri WebhooksOnChannelAddUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnChannelAddMethod { get; set; }

        
        public Uri WebhooksOnChannelDestroyUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnChannelDestroyMethod { get; set; }

        
        public Uri WebhooksOnChannelUpdateUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnChannelUpdateMethod { get; set; }

        
        public Uri WebhooksOnMemberAddUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMemberAddMethod { get; set; }

        
        public Uri WebhooksOnMemberRemoveUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMemberRemoveMethod { get; set; }

        
        public Uri WebhooksOnMessageSentUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMessageSentMethod { get; set; }

        
        public Uri WebhooksOnMessageUpdatedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMessageUpdatedMethod { get; set; }

        
        public Uri WebhooksOnMessageRemovedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMessageRemovedMethod { get; set; }

        
        public Uri WebhooksOnChannelAddedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnChannelAddedMethod { get; set; }

        
        public Uri WebhooksOnChannelDestroyedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnChannelDestroyedMethod { get; set; }

        
        public Uri WebhooksOnChannelUpdatedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnChannelUpdatedMethod { get; set; }

        
        public Uri WebhooksOnMemberAddedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMemberAddedMethod { get; set; }

        
        public Uri WebhooksOnMemberRemovedUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhooksOnMemberRemovedMethod { get; set; }

        
        public int? LimitsChannelMembers { get; set; }

        
        public int? LimitsUserChannels { get; set; }



        /// <summary> Construct a new UpdateServiceOptions </summary>
        /// <param name="pathSid">  </param>
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

