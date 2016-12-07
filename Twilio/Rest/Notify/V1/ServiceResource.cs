using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 
{

    public class ServiceResource : Resource 
    {
        private static Request BuildCreateRequest(CreateServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
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
        public static ServiceResource Create(string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions{FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions{FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Notify,
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
    
        private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Notify,
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
    
        private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Notify,
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
        public static ResourceSet<ServiceResource> Read(string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions{FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions{FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<ServiceResource> NextPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Notify,
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
                Rest.Domain.Notify,
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
        public static ServiceResource Update(string sid, string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(sid){FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(string sid, string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(sid){FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion};
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
        [JsonProperty("apn_credential_sid")]
        public string ApnCredentialSid { get; private set; }
        [JsonProperty("gcm_credential_sid")]
        public string GcmCredentialSid { get; private set; }
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }
        [JsonProperty("facebook_messenger_page_id")]
        public string FacebookMessengerPageId { get; private set; }
        [JsonProperty("default_apn_notification_protocol_version")]
        public string DefaultApnNotificationProtocolVersion { get; private set; }
        [JsonProperty("default_gcm_notification_protocol_version")]
        public string DefaultGcmNotificationProtocolVersion { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private ServiceResource()
        {
        
        }
    }

}