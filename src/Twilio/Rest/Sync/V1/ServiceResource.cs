/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Sync
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Sync.V1
{
    public class ServiceResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Create(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="friendlyName"> A string that you assign to describe the resource. </param>
        /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated. </param>
        /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call `webhook_url` when client endpoints connect to Sync. The default is `false`. </param>
        /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using the [Permissions](https://www.twilio.com/docs/sync/api/sync-permissions) resource. </param>
        /// <param name="reachabilityDebouncingEnabled"> Whether every `endpoint_disconnected` event should occur after a configurable delay. The default is `false`, where the `endpoint_disconnected` event occurs immediately after disconnection. When `true`, intervening reconnections can prevent the `endpoint_disconnected` event. </param>
        /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds if `reachability_debouncing_enabled` = `true`.  Must be between 1,000 and 30,000 and defaults to 5,000. This is the number of milliseconds after the last running client disconnects, and a Sync identity is declared offline, before the `webhook_url` is called if all endpoints remain offline. A reconnection from the same identity by any endpoint during this interval prevents the call to `webhook_url`. </param>
        /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call `webhook_url` when the REST API is used to update Sync objects. The default is `false`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Create(
                                          string friendlyName = null,
                                          Uri webhookUrl = null,
                                          bool? reachabilityWebhooksEnabled = null,
                                          bool? aclEnabled = null,
                                          bool? reachabilityDebouncingEnabled = null,
                                          int? reachabilityDebouncingWindow = null,
                                          bool? webhooksFromRestEnabled = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions(){  FriendlyName = friendlyName, WebhookUrl = webhookUrl, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="friendlyName"> A string that you assign to describe the resource. </param>
        /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated. </param>
        /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call `webhook_url` when client endpoints connect to Sync. The default is `false`. </param>
        /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using the [Permissions](https://www.twilio.com/docs/sync/api/sync-permissions) resource. </param>
        /// <param name="reachabilityDebouncingEnabled"> Whether every `endpoint_disconnected` event should occur after a configurable delay. The default is `false`, where the `endpoint_disconnected` event occurs immediately after disconnection. When `true`, intervening reconnections can prevent the `endpoint_disconnected` event. </param>
        /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds if `reachability_debouncing_enabled` = `true`.  Must be between 1,000 and 30,000 and defaults to 5,000. This is the number of milliseconds after the last running client disconnects, and a Sync identity is declared offline, before the `webhook_url` is called if all endpoints remain offline. A reconnection from the same identity by any endpoint during this interval prevents the call to `webhook_url`. </param>
        /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call `webhook_url` when the REST API is used to update Sync objects. The default is `false`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(
                                                                                  string friendlyName = null,
                                                                                  Uri webhookUrl = null,
                                                                                  bool? reachabilityWebhooksEnabled = null,
                                                                                  bool? aclEnabled = null,
                                                                                  bool? reachabilityDebouncingEnabled = null,
                                                                                  int? reachabilityDebouncingWindow = null,
                                                                                  bool? webhooksFromRestEnabled = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateServiceOptions(){  FriendlyName = friendlyName, WebhookUrl = webhookUrl, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        private static Request BuildDeleteRequest(DeleteServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static bool Delete(DeleteServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteServiceOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathSid"> The SID of the Service resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathSid"> The SID of the Service resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Fetch(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the Service resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the Service resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ResourceSet<ServiceResource> Read(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 100. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ResourceSet<ServiceResource> Read(
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 100. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ServiceResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ServiceResource> NextPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ServiceResource> PreviousPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Update(UpdateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(UpdateServiceOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the Service resource to update. </param>
        /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated. </param>
        /// <param name="friendlyName"> A string that you assign to describe the resource. </param>
        /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call `webhook_url` when client endpoints connect to Sync. The default is `false`. </param>
        /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using the [Permissions](https://www.twilio.com/docs/sync/api/sync-permissions) resource. </param>
        /// <param name="reachabilityDebouncingEnabled"> Whether every `endpoint_disconnected` event should occur after a configurable delay. The default is `false`, where the `endpoint_disconnected` event occurs immediately after disconnection. When `true`, intervening reconnections can prevent the `endpoint_disconnected` event. </param>
        /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds if `reachability_debouncing_enabled` = `true`.  Must be between 1,000 and 30,000 and defaults to 5,000. This is the number of milliseconds after the last running client disconnects, and a Sync identity is declared offline, before the webhook is called if all endpoints remain offline. A reconnection from the same identity by any endpoint during this interval prevents the webhook from being called. </param>
        /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call `webhook_url` when the REST API is used to update Sync objects. The default is `false`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Update(
                                          string pathSid,
                                          Uri webhookUrl = null,
                                          string friendlyName = null,
                                          bool? reachabilityWebhooksEnabled = null,
                                          bool? aclEnabled = null,
                                          bool? reachabilityDebouncingEnabled = null,
                                          int? reachabilityDebouncingWindow = null,
                                          bool? webhooksFromRestEnabled = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(pathSid){ WebhookUrl = webhookUrl, FriendlyName = friendlyName, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the Service resource to update. </param>
        /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated. </param>
        /// <param name="friendlyName"> A string that you assign to describe the resource. </param>
        /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call `webhook_url` when client endpoints connect to Sync. The default is `false`. </param>
        /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using the [Permissions](https://www.twilio.com/docs/sync/api/sync-permissions) resource. </param>
        /// <param name="reachabilityDebouncingEnabled"> Whether every `endpoint_disconnected` event should occur after a configurable delay. The default is `false`, where the `endpoint_disconnected` event occurs immediately after disconnection. When `true`, intervening reconnections can prevent the `endpoint_disconnected` event. </param>
        /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds if `reachability_debouncing_enabled` = `true`.  Must be between 1,000 and 30,000 and defaults to 5,000. This is the number of milliseconds after the last running client disconnects, and a Sync identity is declared offline, before the webhook is called if all endpoints remain offline. A reconnection from the same identity by any endpoint during this interval prevents the webhook from being called. </param>
        /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call `webhook_url` when the REST API is used to update Sync objects. The default is `false`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(
                                                                              string pathSid,
                                                                              Uri webhookUrl = null,
                                                                              string friendlyName = null,
                                                                              bool? reachabilityWebhooksEnabled = null,
                                                                              bool? aclEnabled = null,
                                                                              bool? reachabilityDebouncingEnabled = null,
                                                                              int? reachabilityDebouncingWindow = null,
                                                                              bool? webhooksFromRestEnabled = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(pathSid){ WebhookUrl = webhookUrl, FriendlyName = friendlyName, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns>
        public static ServiceResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The unique string that we created to identify the Service resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. It is a read-only property, it cannot be assigned using REST API. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Service resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the Service resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URL we call when Sync objects are manipulated. </summary> 
        [JsonProperty("webhook_url")]
        public Uri WebhookUrl { get; private set; }

        ///<summary> Whether the Service instance should call `webhook_url` when the REST API is used to update Sync objects. The default is `false`. </summary> 
        [JsonProperty("webhooks_from_rest_enabled")]
        public bool? WebhooksFromRestEnabled { get; private set; }

        ///<summary> Whether the service instance calls `webhook_url` when client endpoints connect to Sync. The default is `false`. </summary> 
        [JsonProperty("reachability_webhooks_enabled")]
        public bool? ReachabilityWebhooksEnabled { get; private set; }

        ///<summary> Whether token identities in the Service must be granted access to Sync objects by using the [Permissions](https://www.twilio.com/docs/sync/api/sync-permissions) resource. It is disabled (false) by default. </summary> 
        [JsonProperty("acl_enabled")]
        public bool? AclEnabled { get; private set; }

        ///<summary> Whether every `endpoint_disconnected` event should occur after a configurable delay. The default is `false`, where the `endpoint_disconnected` event occurs immediately after disconnection. When `true`, intervening reconnections can prevent the `endpoint_disconnected` event. </summary> 
        [JsonProperty("reachability_debouncing_enabled")]
        public bool? ReachabilityDebouncingEnabled { get; private set; }

        ///<summary> The reachability event delay in milliseconds if `reachability_debouncing_enabled` = `true`.  Must be between 1,000 and 30,000 and defaults to 5,000. This is the number of milliseconds after the last running client disconnects, and a Sync identity is declared offline, before `webhook_url` is called, if all endpoints remain offline. A reconnection from the same identity by any endpoint during this interval prevents the reachability event from occurring. </summary> 
        [JsonProperty("reachability_debouncing_window")]
        public int? ReachabilityDebouncingWindow { get; private set; }

        ///<summary> The URLs of related resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ServiceResource() {

        }
    }
}

