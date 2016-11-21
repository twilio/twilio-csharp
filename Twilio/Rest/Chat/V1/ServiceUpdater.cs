using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1 
{

    public class ServiceUpdater : Updater<ServiceResource> 
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
        /// Construct a new ServiceUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ServiceUpdater(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ServiceResource </returns> 
        public override async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + Sid + "",
                client.Region
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ServiceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ServiceResource </returns> 
        public override ServiceResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + Sid + "",
                client.Region
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ServiceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (DefaultServiceRoleSid != null)
            {
                request.AddPostParam("DefaultServiceRoleSid", DefaultServiceRoleSid);
            }
            
            if (DefaultChannelRoleSid != null)
            {
                request.AddPostParam("DefaultChannelRoleSid", DefaultChannelRoleSid);
            }
            
            if (DefaultChannelCreatorRoleSid != null)
            {
                request.AddPostParam("DefaultChannelCreatorRoleSid", DefaultChannelCreatorRoleSid);
            }
            
            if (ReadStatusEnabled != null)
            {
                request.AddPostParam("ReadStatusEnabled", ReadStatusEnabled.ToString());
            }
            
            if (ReachabilityEnabled != null)
            {
                request.AddPostParam("ReachabilityEnabled", ReachabilityEnabled.ToString());
            }
            
            if (TypingIndicatorTimeout != null)
            {
                request.AddPostParam("TypingIndicatorTimeout", TypingIndicatorTimeout.ToString());
            }
            
            if (ConsumptionReportInterval != null)
            {
                request.AddPostParam("ConsumptionReportInterval", ConsumptionReportInterval.ToString());
            }
            
            if (NotificationsNewMessageEnabled != null)
            {
                request.AddPostParam("Notifications.NewMessage.Enabled", NotificationsNewMessageEnabled.ToString());
            }
            
            if (NotificationsNewMessageTemplate != null)
            {
                request.AddPostParam("Notifications.NewMessage.Template", NotificationsNewMessageTemplate);
            }
            
            if (NotificationsAddedToChannelEnabled != null)
            {
                request.AddPostParam("Notifications.AddedToChannel.Enabled", NotificationsAddedToChannelEnabled.ToString());
            }
            
            if (NotificationsAddedToChannelTemplate != null)
            {
                request.AddPostParam("Notifications.AddedToChannel.Template", NotificationsAddedToChannelTemplate);
            }
            
            if (NotificationsRemovedFromChannelEnabled != null)
            {
                request.AddPostParam("Notifications.RemovedFromChannel.Enabled", NotificationsRemovedFromChannelEnabled.ToString());
            }
            
            if (NotificationsRemovedFromChannelTemplate != null)
            {
                request.AddPostParam("Notifications.RemovedFromChannel.Template", NotificationsRemovedFromChannelTemplate);
            }
            
            if (NotificationsInvitedToChannelEnabled != null)
            {
                request.AddPostParam("Notifications.InvitedToChannel.Enabled", NotificationsInvitedToChannelEnabled.ToString());
            }
            
            if (NotificationsInvitedToChannelTemplate != null)
            {
                request.AddPostParam("Notifications.InvitedToChannel.Template", NotificationsInvitedToChannelTemplate);
            }
            
            if (PreWebhookUrl != null)
            {
                request.AddPostParam("PreWebhookUrl", PreWebhookUrl.ToString());
            }
            
            if (PostWebhookUrl != null)
            {
                request.AddPostParam("PostWebhookUrl", PostWebhookUrl.ToString());
            }
            
            if (WebhookMethod != null)
            {
                request.AddPostParam("WebhookMethod", WebhookMethod.ToString());
            }
            
            if (WebhookFilters != null)
            {
                request.AddPostParam("WebhookFilters", WebhookFilters.ToString());
            }
            
            if (WebhooksOnMessageSendUrl != null)
            {
                request.AddPostParam("Webhooks.OnMessageSend.Url", WebhooksOnMessageSendUrl.ToString());
            }
            
            if (WebhooksOnMessageSendMethod != null)
            {
                request.AddPostParam("Webhooks.OnMessageSend.Method", WebhooksOnMessageSendMethod.ToString());
            }
            
            if (WebhooksOnMessageSendFormat != null)
            {
                request.AddPostParam("Webhooks.OnMessageSend.Format", WebhooksOnMessageSendFormat);
            }
            
            if (WebhooksOnMessageUpdateUrl != null)
            {
                request.AddPostParam("Webhooks.OnMessageUpdate.Url", WebhooksOnMessageUpdateUrl.ToString());
            }
            
            if (WebhooksOnMessageUpdateMethod != null)
            {
                request.AddPostParam("Webhooks.OnMessageUpdate.Method", WebhooksOnMessageUpdateMethod.ToString());
            }
            
            if (WebhooksOnMessageUpdateFormat != null)
            {
                request.AddPostParam("Webhooks.OnMessageUpdate.Format", WebhooksOnMessageUpdateFormat);
            }
            
            if (WebhooksOnMessageRemoveUrl != null)
            {
                request.AddPostParam("Webhooks.OnMessageRemove.Url", WebhooksOnMessageRemoveUrl.ToString());
            }
            
            if (WebhooksOnMessageRemoveMethod != null)
            {
                request.AddPostParam("Webhooks.OnMessageRemove.Method", WebhooksOnMessageRemoveMethod.ToString());
            }
            
            if (WebhooksOnMessageRemoveFormat != null)
            {
                request.AddPostParam("Webhooks.OnMessageRemove.Format", WebhooksOnMessageRemoveFormat);
            }
            
            if (WebhooksOnChannelAddUrl != null)
            {
                request.AddPostParam("Webhooks.OnChannelAdd.Url", WebhooksOnChannelAddUrl.ToString());
            }
            
            if (WebhooksOnChannelAddMethod != null)
            {
                request.AddPostParam("Webhooks.OnChannelAdd.Method", WebhooksOnChannelAddMethod.ToString());
            }
            
            if (WebhooksOnChannelAddFormat != null)
            {
                request.AddPostParam("Webhooks.OnChannelAdd.Format", WebhooksOnChannelAddFormat);
            }
            
            if (WebhooksOnChannelDestroyUrl != null)
            {
                request.AddPostParam("Webhooks.OnChannelDestroy.Url", WebhooksOnChannelDestroyUrl.ToString());
            }
            
            if (WebhooksOnChannelDestroyMethod != null)
            {
                request.AddPostParam("Webhooks.OnChannelDestroy.Method", WebhooksOnChannelDestroyMethod.ToString());
            }
            
            if (WebhooksOnChannelDestroyFormat != null)
            {
                request.AddPostParam("Webhooks.OnChannelDestroy.Format", WebhooksOnChannelDestroyFormat);
            }
            
            if (WebhooksOnChannelUpdateUrl != null)
            {
                request.AddPostParam("Webhooks.OnChannelUpdate.Url", WebhooksOnChannelUpdateUrl.ToString());
            }
            
            if (WebhooksOnChannelUpdateMethod != null)
            {
                request.AddPostParam("Webhooks.OnChannelUpdate.Method", WebhooksOnChannelUpdateMethod.ToString());
            }
            
            if (WebhooksOnChannelUpdateFormat != null)
            {
                request.AddPostParam("Webhooks.OnChannelUpdate.Format", WebhooksOnChannelUpdateFormat);
            }
            
            if (WebhooksOnMemberAddUrl != null)
            {
                request.AddPostParam("Webhooks.OnMemberAdd.Url", WebhooksOnMemberAddUrl.ToString());
            }
            
            if (WebhooksOnMemberAddMethod != null)
            {
                request.AddPostParam("Webhooks.OnMemberAdd.Method", WebhooksOnMemberAddMethod.ToString());
            }
            
            if (WebhooksOnMemberAddFormat != null)
            {
                request.AddPostParam("Webhooks.OnMemberAdd.Format", WebhooksOnMemberAddFormat);
            }
            
            if (WebhooksOnMemberRemoveUrl != null)
            {
                request.AddPostParam("Webhooks.OnMemberRemove.Url", WebhooksOnMemberRemoveUrl.ToString());
            }
            
            if (WebhooksOnMemberRemoveMethod != null)
            {
                request.AddPostParam("Webhooks.OnMemberRemove.Method", WebhooksOnMemberRemoveMethod.ToString());
            }
            
            if (WebhooksOnMemberRemoveFormat != null)
            {
                request.AddPostParam("Webhooks.OnMemberRemove.Format", WebhooksOnMemberRemoveFormat);
            }
            
            if (WebhooksOnMessageSentUrl != null)
            {
                request.AddPostParam("Webhooks.OnMessageSent.Url", WebhooksOnMessageSentUrl.ToString());
            }
            
            if (WebhooksOnMessageSentMethod != null)
            {
                request.AddPostParam("Webhooks.OnMessageSent.Method", WebhooksOnMessageSentMethod.ToString());
            }
            
            if (WebhooksOnMessageSentFormat != null)
            {
                request.AddPostParam("Webhooks.OnMessageSent.Format", WebhooksOnMessageSentFormat);
            }
            
            if (WebhooksOnMessageUpdatedUrl != null)
            {
                request.AddPostParam("Webhooks.OnMessageUpdated.Url", WebhooksOnMessageUpdatedUrl.ToString());
            }
            
            if (WebhooksOnMessageUpdatedMethod != null)
            {
                request.AddPostParam("Webhooks.OnMessageUpdated.Method", WebhooksOnMessageUpdatedMethod.ToString());
            }
            
            if (WebhooksOnMessageUpdatedFormat != null)
            {
                request.AddPostParam("Webhooks.OnMessageUpdated.Format", WebhooksOnMessageUpdatedFormat);
            }
            
            if (WebhooksOnMessageRemovedUrl != null)
            {
                request.AddPostParam("Webhooks.OnMessageRemoved.Url", WebhooksOnMessageRemovedUrl.ToString());
            }
            
            if (WebhooksOnMessageRemovedMethod != null)
            {
                request.AddPostParam("Webhooks.OnMessageRemoved.Method", WebhooksOnMessageRemovedMethod.ToString());
            }
            
            if (WebhooksOnMessageRemovedFormat != null)
            {
                request.AddPostParam("Webhooks.OnMessageRemoved.Format", WebhooksOnMessageRemovedFormat);
            }
            
            if (WebhooksOnChannelAddedUrl != null)
            {
                request.AddPostParam("Webhooks.OnChannelAdded.Url", WebhooksOnChannelAddedUrl.ToString());
            }
            
            if (WebhooksOnChannelAddedMethod != null)
            {
                request.AddPostParam("Webhooks.OnChannelAdded.Method", WebhooksOnChannelAddedMethod.ToString());
            }
            
            if (WebhooksOnChannelAddedFormat != null)
            {
                request.AddPostParam("Webhooks.OnChannelAdded.Format", WebhooksOnChannelAddedFormat);
            }
            
            if (WebhooksOnChannelDestroyedUrl != null)
            {
                request.AddPostParam("Webhooks.OnChannelDestroyed.Url", WebhooksOnChannelDestroyedUrl.ToString());
            }
            
            if (WebhooksOnChannelDestroyedMethod != null)
            {
                request.AddPostParam("Webhooks.OnChannelDestroyed.Method", WebhooksOnChannelDestroyedMethod.ToString());
            }
            
            if (WebhooksOnChannelDestroyedFormat != null)
            {
                request.AddPostParam("Webhooks.OnChannelDestroyed.Format", WebhooksOnChannelDestroyedFormat);
            }
            
            if (WebhooksOnChannelUpdatedUrl != null)
            {
                request.AddPostParam("Webhooks.OnChannelUpdated.Url", WebhooksOnChannelUpdatedUrl.ToString());
            }
            
            if (WebhooksOnChannelUpdatedMethod != null)
            {
                request.AddPostParam("Webhooks.OnChannelUpdated.Method", WebhooksOnChannelUpdatedMethod.ToString());
            }
            
            if (WebhooksOnChannelUpdatedFormat != null)
            {
                request.AddPostParam("Webhooks.OnChannelUpdated.Format", WebhooksOnChannelUpdatedFormat);
            }
            
            if (WebhooksOnMemberAddedUrl != null)
            {
                request.AddPostParam("Webhooks.OnMemberAdded.Url", WebhooksOnMemberAddedUrl.ToString());
            }
            
            if (WebhooksOnMemberAddedMethod != null)
            {
                request.AddPostParam("Webhooks.OnMemberAdded.Method", WebhooksOnMemberAddedMethod.ToString());
            }
            
            if (WebhooksOnMemberAddedFormat != null)
            {
                request.AddPostParam("Webhooks.OnMemberAdded.Format", WebhooksOnMemberAddedFormat);
            }
            
            if (WebhooksOnMemberRemovedUrl != null)
            {
                request.AddPostParam("Webhooks.OnMemberRemoved.Url", WebhooksOnMemberRemovedUrl.ToString());
            }
            
            if (WebhooksOnMemberRemovedMethod != null)
            {
                request.AddPostParam("Webhooks.OnMemberRemoved.Method", WebhooksOnMemberRemovedMethod.ToString());
            }
            
            if (WebhooksOnMemberRemovedFormat != null)
            {
                request.AddPostParam("Webhooks.OnMemberRemoved.Format", WebhooksOnMemberRemovedFormat);
            }
        }
    }
}