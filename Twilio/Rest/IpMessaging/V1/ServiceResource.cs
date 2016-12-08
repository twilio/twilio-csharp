using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1 
{

    public class ServiceResource : Resource 
    {
        private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static ServiceResource Fetch(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static ServiceResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static ServiceResource Create(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static ServiceResource Create(string friendlyName, ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions(friendlyName);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(string friendlyName, ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions(friendlyName);
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<ServiceResource> Read(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<ServiceResource> Read(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions{PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions{PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<ServiceResource> NextPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.IpMessaging,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static ServiceResource Update(UpdateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(UpdateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static ServiceResource Update(string sid, string friendlyName = null, string defaultServiceRoleSid = null, string defaultChannelRoleSid = null, string defaultChannelCreatorRoleSid = null, bool? readStatusEnabled = null, bool? reachabilityEnabled = null, int? typingIndicatorTimeout = null, int? consumptionReportInterval = null, bool? notificationsNewMessageEnabled = null, string notificationsNewMessageTemplate = null, bool? notificationsAddedToChannelEnabled = null, string notificationsAddedToChannelTemplate = null, bool? notificationsRemovedFromChannelEnabled = null, string notificationsRemovedFromChannelTemplate = null, bool? notificationsInvitedToChannelEnabled = null, string notificationsInvitedToChannelTemplate = null, Uri preWebhookUrl = null, Uri postWebhookUrl = null, Twilio.Http.HttpMethod webhookMethod = null, List<string> webhookFilters = null, Uri webhooksOnMessageSendUrl = null, Twilio.Http.HttpMethod webhooksOnMessageSendMethod = null, string webhooksOnMessageSendFormat = null, Uri webhooksOnMessageUpdateUrl = null, Twilio.Http.HttpMethod webhooksOnMessageUpdateMethod = null, string webhooksOnMessageUpdateFormat = null, Uri webhooksOnMessageRemoveUrl = null, Twilio.Http.HttpMethod webhooksOnMessageRemoveMethod = null, string webhooksOnMessageRemoveFormat = null, Uri webhooksOnChannelAddUrl = null, Twilio.Http.HttpMethod webhooksOnChannelAddMethod = null, string webhooksOnChannelAddFormat = null, Uri webhooksOnChannelDestroyUrl = null, Twilio.Http.HttpMethod webhooksOnChannelDestroyMethod = null, string webhooksOnChannelDestroyFormat = null, Uri webhooksOnChannelUpdateUrl = null, Twilio.Http.HttpMethod webhooksOnChannelUpdateMethod = null, string webhooksOnChannelUpdateFormat = null, Uri webhooksOnMemberAddUrl = null, Twilio.Http.HttpMethod webhooksOnMemberAddMethod = null, string webhooksOnMemberAddFormat = null, Uri webhooksOnMemberRemoveUrl = null, Twilio.Http.HttpMethod webhooksOnMemberRemoveMethod = null, string webhooksOnMemberRemoveFormat = null, Uri webhooksOnMessageSentUrl = null, Twilio.Http.HttpMethod webhooksOnMessageSentMethod = null, string webhooksOnMessageSentFormat = null, Uri webhooksOnMessageUpdatedUrl = null, Twilio.Http.HttpMethod webhooksOnMessageUpdatedMethod = null, string webhooksOnMessageUpdatedFormat = null, Uri webhooksOnMessageRemovedUrl = null, Twilio.Http.HttpMethod webhooksOnMessageRemovedMethod = null, string webhooksOnMessageRemovedFormat = null, Uri webhooksOnChannelAddedUrl = null, Twilio.Http.HttpMethod webhooksOnChannelAddedMethod = null, string webhooksOnChannelAddedFormat = null, Uri webhooksOnChannelDestroyedUrl = null, Twilio.Http.HttpMethod webhooksOnChannelDestroyedMethod = null, string webhooksOnChannelDestroyedFormat = null, Uri webhooksOnChannelUpdatedUrl = null, Twilio.Http.HttpMethod webhooksOnChannelUpdatedMethod = null, string webhooksOnChannelUpdatedFormat = null, Uri webhooksOnMemberAddedUrl = null, Twilio.Http.HttpMethod webhooksOnMemberAddedMethod = null, string webhooksOnMemberAddedFormat = null, Uri webhooksOnMemberRemovedUrl = null, Twilio.Http.HttpMethod webhooksOnMemberRemovedMethod = null, string webhooksOnMemberRemovedFormat = null, ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(sid){FriendlyName = friendlyName, DefaultServiceRoleSid = defaultServiceRoleSid, DefaultChannelRoleSid = defaultChannelRoleSid, DefaultChannelCreatorRoleSid = defaultChannelCreatorRoleSid, ReadStatusEnabled = readStatusEnabled, ReachabilityEnabled = reachabilityEnabled, TypingIndicatorTimeout = typingIndicatorTimeout, ConsumptionReportInterval = consumptionReportInterval, NotificationsNewMessageEnabled = notificationsNewMessageEnabled, NotificationsNewMessageTemplate = notificationsNewMessageTemplate, NotificationsAddedToChannelEnabled = notificationsAddedToChannelEnabled, NotificationsAddedToChannelTemplate = notificationsAddedToChannelTemplate, NotificationsRemovedFromChannelEnabled = notificationsRemovedFromChannelEnabled, NotificationsRemovedFromChannelTemplate = notificationsRemovedFromChannelTemplate, NotificationsInvitedToChannelEnabled = notificationsInvitedToChannelEnabled, NotificationsInvitedToChannelTemplate = notificationsInvitedToChannelTemplate, PreWebhookUrl = preWebhookUrl, PostWebhookUrl = postWebhookUrl, WebhookMethod = webhookMethod, WebhookFilters = webhookFilters, WebhooksOnMessageSendUrl = webhooksOnMessageSendUrl, WebhooksOnMessageSendMethod = webhooksOnMessageSendMethod, WebhooksOnMessageSendFormat = webhooksOnMessageSendFormat, WebhooksOnMessageUpdateUrl = webhooksOnMessageUpdateUrl, WebhooksOnMessageUpdateMethod = webhooksOnMessageUpdateMethod, WebhooksOnMessageUpdateFormat = webhooksOnMessageUpdateFormat, WebhooksOnMessageRemoveUrl = webhooksOnMessageRemoveUrl, WebhooksOnMessageRemoveMethod = webhooksOnMessageRemoveMethod, WebhooksOnMessageRemoveFormat = webhooksOnMessageRemoveFormat, WebhooksOnChannelAddUrl = webhooksOnChannelAddUrl, WebhooksOnChannelAddMethod = webhooksOnChannelAddMethod, WebhooksOnChannelAddFormat = webhooksOnChannelAddFormat, WebhooksOnChannelDestroyUrl = webhooksOnChannelDestroyUrl, WebhooksOnChannelDestroyMethod = webhooksOnChannelDestroyMethod, WebhooksOnChannelDestroyFormat = webhooksOnChannelDestroyFormat, WebhooksOnChannelUpdateUrl = webhooksOnChannelUpdateUrl, WebhooksOnChannelUpdateMethod = webhooksOnChannelUpdateMethod, WebhooksOnChannelUpdateFormat = webhooksOnChannelUpdateFormat, WebhooksOnMemberAddUrl = webhooksOnMemberAddUrl, WebhooksOnMemberAddMethod = webhooksOnMemberAddMethod, WebhooksOnMemberAddFormat = webhooksOnMemberAddFormat, WebhooksOnMemberRemoveUrl = webhooksOnMemberRemoveUrl, WebhooksOnMemberRemoveMethod = webhooksOnMemberRemoveMethod, WebhooksOnMemberRemoveFormat = webhooksOnMemberRemoveFormat, WebhooksOnMessageSentUrl = webhooksOnMessageSentUrl, WebhooksOnMessageSentMethod = webhooksOnMessageSentMethod, WebhooksOnMessageSentFormat = webhooksOnMessageSentFormat, WebhooksOnMessageUpdatedUrl = webhooksOnMessageUpdatedUrl, WebhooksOnMessageUpdatedMethod = webhooksOnMessageUpdatedMethod, WebhooksOnMessageUpdatedFormat = webhooksOnMessageUpdatedFormat, WebhooksOnMessageRemovedUrl = webhooksOnMessageRemovedUrl, WebhooksOnMessageRemovedMethod = webhooksOnMessageRemovedMethod, WebhooksOnMessageRemovedFormat = webhooksOnMessageRemovedFormat, WebhooksOnChannelAddedUrl = webhooksOnChannelAddedUrl, WebhooksOnChannelAddedMethod = webhooksOnChannelAddedMethod, WebhooksOnChannelAddedFormat = webhooksOnChannelAddedFormat, WebhooksOnChannelDestroyedUrl = webhooksOnChannelDestroyedUrl, WebhooksOnChannelDestroyedMethod = webhooksOnChannelDestroyedMethod, WebhooksOnChannelDestroyedFormat = webhooksOnChannelDestroyedFormat, WebhooksOnChannelUpdatedUrl = webhooksOnChannelUpdatedUrl, WebhooksOnChannelUpdatedMethod = webhooksOnChannelUpdatedMethod, WebhooksOnChannelUpdatedFormat = webhooksOnChannelUpdatedFormat, WebhooksOnMemberAddedUrl = webhooksOnMemberAddedUrl, WebhooksOnMemberAddedMethod = webhooksOnMemberAddedMethod, WebhooksOnMemberAddedFormat = webhooksOnMemberAddedFormat, WebhooksOnMemberRemovedUrl = webhooksOnMemberRemovedUrl, WebhooksOnMemberRemovedMethod = webhooksOnMemberRemovedMethod, WebhooksOnMemberRemovedFormat = webhooksOnMemberRemovedFormat};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(string sid, string friendlyName = null, string defaultServiceRoleSid = null, string defaultChannelRoleSid = null, string defaultChannelCreatorRoleSid = null, bool? readStatusEnabled = null, bool? reachabilityEnabled = null, int? typingIndicatorTimeout = null, int? consumptionReportInterval = null, bool? notificationsNewMessageEnabled = null, string notificationsNewMessageTemplate = null, bool? notificationsAddedToChannelEnabled = null, string notificationsAddedToChannelTemplate = null, bool? notificationsRemovedFromChannelEnabled = null, string notificationsRemovedFromChannelTemplate = null, bool? notificationsInvitedToChannelEnabled = null, string notificationsInvitedToChannelTemplate = null, Uri preWebhookUrl = null, Uri postWebhookUrl = null, Twilio.Http.HttpMethod webhookMethod = null, List<string> webhookFilters = null, Uri webhooksOnMessageSendUrl = null, Twilio.Http.HttpMethod webhooksOnMessageSendMethod = null, string webhooksOnMessageSendFormat = null, Uri webhooksOnMessageUpdateUrl = null, Twilio.Http.HttpMethod webhooksOnMessageUpdateMethod = null, string webhooksOnMessageUpdateFormat = null, Uri webhooksOnMessageRemoveUrl = null, Twilio.Http.HttpMethod webhooksOnMessageRemoveMethod = null, string webhooksOnMessageRemoveFormat = null, Uri webhooksOnChannelAddUrl = null, Twilio.Http.HttpMethod webhooksOnChannelAddMethod = null, string webhooksOnChannelAddFormat = null, Uri webhooksOnChannelDestroyUrl = null, Twilio.Http.HttpMethod webhooksOnChannelDestroyMethod = null, string webhooksOnChannelDestroyFormat = null, Uri webhooksOnChannelUpdateUrl = null, Twilio.Http.HttpMethod webhooksOnChannelUpdateMethod = null, string webhooksOnChannelUpdateFormat = null, Uri webhooksOnMemberAddUrl = null, Twilio.Http.HttpMethod webhooksOnMemberAddMethod = null, string webhooksOnMemberAddFormat = null, Uri webhooksOnMemberRemoveUrl = null, Twilio.Http.HttpMethod webhooksOnMemberRemoveMethod = null, string webhooksOnMemberRemoveFormat = null, Uri webhooksOnMessageSentUrl = null, Twilio.Http.HttpMethod webhooksOnMessageSentMethod = null, string webhooksOnMessageSentFormat = null, Uri webhooksOnMessageUpdatedUrl = null, Twilio.Http.HttpMethod webhooksOnMessageUpdatedMethod = null, string webhooksOnMessageUpdatedFormat = null, Uri webhooksOnMessageRemovedUrl = null, Twilio.Http.HttpMethod webhooksOnMessageRemovedMethod = null, string webhooksOnMessageRemovedFormat = null, Uri webhooksOnChannelAddedUrl = null, Twilio.Http.HttpMethod webhooksOnChannelAddedMethod = null, string webhooksOnChannelAddedFormat = null, Uri webhooksOnChannelDestroyedUrl = null, Twilio.Http.HttpMethod webhooksOnChannelDestroyedMethod = null, string webhooksOnChannelDestroyedFormat = null, Uri webhooksOnChannelUpdatedUrl = null, Twilio.Http.HttpMethod webhooksOnChannelUpdatedMethod = null, string webhooksOnChannelUpdatedFormat = null, Uri webhooksOnMemberAddedUrl = null, Twilio.Http.HttpMethod webhooksOnMemberAddedMethod = null, string webhooksOnMemberAddedFormat = null, Uri webhooksOnMemberRemovedUrl = null, Twilio.Http.HttpMethod webhooksOnMemberRemovedMethod = null, string webhooksOnMemberRemovedFormat = null, ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(sid){FriendlyName = friendlyName, DefaultServiceRoleSid = defaultServiceRoleSid, DefaultChannelRoleSid = defaultChannelRoleSid, DefaultChannelCreatorRoleSid = defaultChannelCreatorRoleSid, ReadStatusEnabled = readStatusEnabled, ReachabilityEnabled = reachabilityEnabled, TypingIndicatorTimeout = typingIndicatorTimeout, ConsumptionReportInterval = consumptionReportInterval, NotificationsNewMessageEnabled = notificationsNewMessageEnabled, NotificationsNewMessageTemplate = notificationsNewMessageTemplate, NotificationsAddedToChannelEnabled = notificationsAddedToChannelEnabled, NotificationsAddedToChannelTemplate = notificationsAddedToChannelTemplate, NotificationsRemovedFromChannelEnabled = notificationsRemovedFromChannelEnabled, NotificationsRemovedFromChannelTemplate = notificationsRemovedFromChannelTemplate, NotificationsInvitedToChannelEnabled = notificationsInvitedToChannelEnabled, NotificationsInvitedToChannelTemplate = notificationsInvitedToChannelTemplate, PreWebhookUrl = preWebhookUrl, PostWebhookUrl = postWebhookUrl, WebhookMethod = webhookMethod, WebhookFilters = webhookFilters, WebhooksOnMessageSendUrl = webhooksOnMessageSendUrl, WebhooksOnMessageSendMethod = webhooksOnMessageSendMethod, WebhooksOnMessageSendFormat = webhooksOnMessageSendFormat, WebhooksOnMessageUpdateUrl = webhooksOnMessageUpdateUrl, WebhooksOnMessageUpdateMethod = webhooksOnMessageUpdateMethod, WebhooksOnMessageUpdateFormat = webhooksOnMessageUpdateFormat, WebhooksOnMessageRemoveUrl = webhooksOnMessageRemoveUrl, WebhooksOnMessageRemoveMethod = webhooksOnMessageRemoveMethod, WebhooksOnMessageRemoveFormat = webhooksOnMessageRemoveFormat, WebhooksOnChannelAddUrl = webhooksOnChannelAddUrl, WebhooksOnChannelAddMethod = webhooksOnChannelAddMethod, WebhooksOnChannelAddFormat = webhooksOnChannelAddFormat, WebhooksOnChannelDestroyUrl = webhooksOnChannelDestroyUrl, WebhooksOnChannelDestroyMethod = webhooksOnChannelDestroyMethod, WebhooksOnChannelDestroyFormat = webhooksOnChannelDestroyFormat, WebhooksOnChannelUpdateUrl = webhooksOnChannelUpdateUrl, WebhooksOnChannelUpdateMethod = webhooksOnChannelUpdateMethod, WebhooksOnChannelUpdateFormat = webhooksOnChannelUpdateFormat, WebhooksOnMemberAddUrl = webhooksOnMemberAddUrl, WebhooksOnMemberAddMethod = webhooksOnMemberAddMethod, WebhooksOnMemberAddFormat = webhooksOnMemberAddFormat, WebhooksOnMemberRemoveUrl = webhooksOnMemberRemoveUrl, WebhooksOnMemberRemoveMethod = webhooksOnMemberRemoveMethod, WebhooksOnMemberRemoveFormat = webhooksOnMemberRemoveFormat, WebhooksOnMessageSentUrl = webhooksOnMessageSentUrl, WebhooksOnMessageSentMethod = webhooksOnMessageSentMethod, WebhooksOnMessageSentFormat = webhooksOnMessageSentFormat, WebhooksOnMessageUpdatedUrl = webhooksOnMessageUpdatedUrl, WebhooksOnMessageUpdatedMethod = webhooksOnMessageUpdatedMethod, WebhooksOnMessageUpdatedFormat = webhooksOnMessageUpdatedFormat, WebhooksOnMessageRemovedUrl = webhooksOnMessageRemovedUrl, WebhooksOnMessageRemovedMethod = webhooksOnMessageRemovedMethod, WebhooksOnMessageRemovedFormat = webhooksOnMessageRemovedFormat, WebhooksOnChannelAddedUrl = webhooksOnChannelAddedUrl, WebhooksOnChannelAddedMethod = webhooksOnChannelAddedMethod, WebhooksOnChannelAddedFormat = webhooksOnChannelAddedFormat, WebhooksOnChannelDestroyedUrl = webhooksOnChannelDestroyedUrl, WebhooksOnChannelDestroyedMethod = webhooksOnChannelDestroyedMethod, WebhooksOnChannelDestroyedFormat = webhooksOnChannelDestroyedFormat, WebhooksOnChannelUpdatedUrl = webhooksOnChannelUpdatedUrl, WebhooksOnChannelUpdatedMethod = webhooksOnChannelUpdatedMethod, WebhooksOnChannelUpdatedFormat = webhooksOnChannelUpdatedFormat, WebhooksOnMemberAddedUrl = webhooksOnMemberAddedUrl, WebhooksOnMemberAddedMethod = webhooksOnMemberAddedMethod, WebhooksOnMemberAddedFormat = webhooksOnMemberAddedFormat, WebhooksOnMemberRemovedUrl = webhooksOnMemberRemovedUrl, WebhooksOnMemberRemovedMethod = webhooksOnMemberRemovedMethod, WebhooksOnMemberRemovedFormat = webhooksOnMemberRemovedFormat};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns> 
        public static ServiceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("default_service_role_sid")]
        public string DefaultServiceRoleSid { get; private set; }
        [JsonProperty("default_channel_role_sid")]
        public string DefaultChannelRoleSid { get; private set; }
        [JsonProperty("default_channel_creator_role_sid")]
        public string DefaultChannelCreatorRoleSid { get; private set; }
        [JsonProperty("read_status_enabled")]
        public bool? ReadStatusEnabled { get; private set; }
        [JsonProperty("reachability_enabled")]
        public bool? ReachabilityEnabled { get; private set; }
        [JsonProperty("typing_indicator_timeout")]
        public int? TypingIndicatorTimeout { get; private set; }
        [JsonProperty("consumption_report_interval")]
        public int? ConsumptionReportInterval { get; private set; }
        [JsonProperty("webhooks")]
        public object Webhooks { get; private set; }
        [JsonProperty("pre_webhook_url")]
        public string PreWebhookUrl { get; private set; }
        [JsonProperty("post_webhook_url")]
        public string PostWebhookUrl { get; private set; }
        [JsonProperty("webhook_method")]
        public string WebhookMethod { get; private set; }
        [JsonProperty("webhook_filters")]
        public List<string> WebhookFilters { get; private set; }
        [JsonProperty("notifications")]
        public object Notifications { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private ServiceResource()
        {
        
        }
    }

}