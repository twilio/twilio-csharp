using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.IpMessaging.V1 
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
        public string FriendlyName { get; }
    
        /// <summary>
        /// Construct a new CreateServiceOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }
    
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
        public string WebhooksOnMessageSendFormat { get; set; }
        public Uri WebhooksOnMessageUpdateUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMessageUpdateMethod { get; set; }
        public string WebhooksOnMessageUpdateFormat { get; set; }
        public Uri WebhooksOnMessageRemoveUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMessageRemoveMethod { get; set; }
        public string WebhooksOnMessageRemoveFormat { get; set; }
        public Uri WebhooksOnChannelAddUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnChannelAddMethod { get; set; }
        public string WebhooksOnChannelAddFormat { get; set; }
        public Uri WebhooksOnChannelDestroyUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnChannelDestroyMethod { get; set; }
        public string WebhooksOnChannelDestroyFormat { get; set; }
        public Uri WebhooksOnChannelUpdateUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnChannelUpdateMethod { get; set; }
        public string WebhooksOnChannelUpdateFormat { get; set; }
        public Uri WebhooksOnMemberAddUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMemberAddMethod { get; set; }
        public string WebhooksOnMemberAddFormat { get; set; }
        public Uri WebhooksOnMemberRemoveUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMemberRemoveMethod { get; set; }
        public string WebhooksOnMemberRemoveFormat { get; set; }
        public Uri WebhooksOnMessageSentUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMessageSentMethod { get; set; }
        public string WebhooksOnMessageSentFormat { get; set; }
        public Uri WebhooksOnMessageUpdatedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMessageUpdatedMethod { get; set; }
        public string WebhooksOnMessageUpdatedFormat { get; set; }
        public Uri WebhooksOnMessageRemovedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMessageRemovedMethod { get; set; }
        public string WebhooksOnMessageRemovedFormat { get; set; }
        public Uri WebhooksOnChannelAddedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnChannelAddedMethod { get; set; }
        public string WebhooksOnChannelAddedFormat { get; set; }
        public Uri WebhooksOnChannelDestroyedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnChannelDestroyedMethod { get; set; }
        public string WebhooksOnChannelDestroyedFormat { get; set; }
        public Uri WebhooksOnChannelUpdatedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnChannelUpdatedMethod { get; set; }
        public string WebhooksOnChannelUpdatedFormat { get; set; }
        public Uri WebhooksOnMemberAddedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMemberAddedMethod { get; set; }
        public string WebhooksOnMemberAddedFormat { get; set; }
        public Uri WebhooksOnMemberRemovedUrl { get; set; }
        public Twilio.Http.HttpMethod WebhooksOnMemberRemovedMethod { get; set; }
        public string WebhooksOnMemberRemovedFormat { get; set; }
    
        /// <summary>
        /// Construct a new UpdateServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateServiceOptions(string sid)
        {
            Sid = sid;
            WebhookFilters = new List<string>();
        }
    
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
                p.Add(new KeyValuePair<string, string>("ReadStatusEnabled", ReadStatusEnabled.ToString()));
            }
            
            if (ReachabilityEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityEnabled", ReachabilityEnabled.ToString()));
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
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Enabled", NotificationsNewMessageEnabled.ToString()));
            }
            
            if (NotificationsNewMessageTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Template", NotificationsNewMessageTemplate));
            }
            
            if (NotificationsAddedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Enabled", NotificationsAddedToChannelEnabled.ToString()));
            }
            
            if (NotificationsAddedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Template", NotificationsAddedToChannelTemplate));
            }
            
            if (NotificationsRemovedFromChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Enabled", NotificationsRemovedFromChannelEnabled.ToString()));
            }
            
            if (NotificationsRemovedFromChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Template", NotificationsRemovedFromChannelTemplate));
            }
            
            if (NotificationsInvitedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Enabled", NotificationsInvitedToChannelEnabled.ToString()));
            }
            
            if (NotificationsInvitedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Template", NotificationsInvitedToChannelTemplate));
            }
            
            if (PreWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookUrl", PreWebhookUrl.ToString()));
            }
            
            if (PostWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookUrl", PostWebhookUrl.ToString()));
            }
            
            if (WebhookMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookMethod", WebhookMethod.ToString()));
            }
            
            if (WebhookFilters != null)
            {
                p.AddRange(WebhookFilters.Select(prop => new KeyValuePair<string, string>("WebhookFilters", prop.ToString())));
            }
            
            if (WebhooksOnMessageSendUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSend.Url", WebhooksOnMessageSendUrl.ToString()));
            }
            
            if (WebhooksOnMessageSendMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSend.Method", WebhooksOnMessageSendMethod.ToString()));
            }
            
            if (WebhooksOnMessageSendFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSend.Format", WebhooksOnMessageSendFormat));
            }
            
            if (WebhooksOnMessageUpdateUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdate.Url", WebhooksOnMessageUpdateUrl.ToString()));
            }
            
            if (WebhooksOnMessageUpdateMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdate.Method", WebhooksOnMessageUpdateMethod.ToString()));
            }
            
            if (WebhooksOnMessageUpdateFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdate.Format", WebhooksOnMessageUpdateFormat));
            }
            
            if (WebhooksOnMessageRemoveUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemove.Url", WebhooksOnMessageRemoveUrl.ToString()));
            }
            
            if (WebhooksOnMessageRemoveMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemove.Method", WebhooksOnMessageRemoveMethod.ToString()));
            }
            
            if (WebhooksOnMessageRemoveFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemove.Format", WebhooksOnMessageRemoveFormat));
            }
            
            if (WebhooksOnChannelAddUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdd.Url", WebhooksOnChannelAddUrl.ToString()));
            }
            
            if (WebhooksOnChannelAddMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdd.Method", WebhooksOnChannelAddMethod.ToString()));
            }
            
            if (WebhooksOnChannelAddFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdd.Format", WebhooksOnChannelAddFormat));
            }
            
            if (WebhooksOnChannelDestroyUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroy.Url", WebhooksOnChannelDestroyUrl.ToString()));
            }
            
            if (WebhooksOnChannelDestroyMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroy.Method", WebhooksOnChannelDestroyMethod.ToString()));
            }
            
            if (WebhooksOnChannelDestroyFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroy.Format", WebhooksOnChannelDestroyFormat));
            }
            
            if (WebhooksOnChannelUpdateUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdate.Url", WebhooksOnChannelUpdateUrl.ToString()));
            }
            
            if (WebhooksOnChannelUpdateMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdate.Method", WebhooksOnChannelUpdateMethod.ToString()));
            }
            
            if (WebhooksOnChannelUpdateFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdate.Format", WebhooksOnChannelUpdateFormat));
            }
            
            if (WebhooksOnMemberAddUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdd.Url", WebhooksOnMemberAddUrl.ToString()));
            }
            
            if (WebhooksOnMemberAddMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdd.Method", WebhooksOnMemberAddMethod.ToString()));
            }
            
            if (WebhooksOnMemberAddFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdd.Format", WebhooksOnMemberAddFormat));
            }
            
            if (WebhooksOnMemberRemoveUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemove.Url", WebhooksOnMemberRemoveUrl.ToString()));
            }
            
            if (WebhooksOnMemberRemoveMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemove.Method", WebhooksOnMemberRemoveMethod.ToString()));
            }
            
            if (WebhooksOnMemberRemoveFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemove.Format", WebhooksOnMemberRemoveFormat));
            }
            
            if (WebhooksOnMessageSentUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSent.Url", WebhooksOnMessageSentUrl.ToString()));
            }
            
            if (WebhooksOnMessageSentMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSent.Method", WebhooksOnMessageSentMethod.ToString()));
            }
            
            if (WebhooksOnMessageSentFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageSent.Format", WebhooksOnMessageSentFormat));
            }
            
            if (WebhooksOnMessageUpdatedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdated.Url", WebhooksOnMessageUpdatedUrl.ToString()));
            }
            
            if (WebhooksOnMessageUpdatedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdated.Method", WebhooksOnMessageUpdatedMethod.ToString()));
            }
            
            if (WebhooksOnMessageUpdatedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageUpdated.Format", WebhooksOnMessageUpdatedFormat));
            }
            
            if (WebhooksOnMessageRemovedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemoved.Url", WebhooksOnMessageRemovedUrl.ToString()));
            }
            
            if (WebhooksOnMessageRemovedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemoved.Method", WebhooksOnMessageRemovedMethod.ToString()));
            }
            
            if (WebhooksOnMessageRemovedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMessageRemoved.Format", WebhooksOnMessageRemovedFormat));
            }
            
            if (WebhooksOnChannelAddedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdded.Url", WebhooksOnChannelAddedUrl.ToString()));
            }
            
            if (WebhooksOnChannelAddedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdded.Method", WebhooksOnChannelAddedMethod.ToString()));
            }
            
            if (WebhooksOnChannelAddedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelAdded.Format", WebhooksOnChannelAddedFormat));
            }
            
            if (WebhooksOnChannelDestroyedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroyed.Url", WebhooksOnChannelDestroyedUrl.ToString()));
            }
            
            if (WebhooksOnChannelDestroyedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroyed.Method", WebhooksOnChannelDestroyedMethod.ToString()));
            }
            
            if (WebhooksOnChannelDestroyedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelDestroyed.Format", WebhooksOnChannelDestroyedFormat));
            }
            
            if (WebhooksOnChannelUpdatedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdated.Url", WebhooksOnChannelUpdatedUrl.ToString()));
            }
            
            if (WebhooksOnChannelUpdatedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdated.Method", WebhooksOnChannelUpdatedMethod.ToString()));
            }
            
            if (WebhooksOnChannelUpdatedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnChannelUpdated.Format", WebhooksOnChannelUpdatedFormat));
            }
            
            if (WebhooksOnMemberAddedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdded.Url", WebhooksOnMemberAddedUrl.ToString()));
            }
            
            if (WebhooksOnMemberAddedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdded.Method", WebhooksOnMemberAddedMethod.ToString()));
            }
            
            if (WebhooksOnMemberAddedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberAdded.Format", WebhooksOnMemberAddedFormat));
            }
            
            if (WebhooksOnMemberRemovedUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemoved.Url", WebhooksOnMemberRemovedUrl.ToString()));
            }
            
            if (WebhooksOnMemberRemovedMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemoved.Method", WebhooksOnMemberRemovedMethod.ToString()));
            }
            
            if (WebhooksOnMemberRemovedFormat != null)
            {
                p.Add(new KeyValuePair<string, string>("Webhooks.OnMemberRemoved.Format", WebhooksOnMemberRemovedFormat));
            }
            
            return p;
        }
    }

}