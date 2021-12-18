/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// ServiceResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Sync.V1
{

  public class ServiceResource : Resource
  {
    private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Sync,
          "/v1/Services/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// fetch
    /// </summary>
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
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Service parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(FetchServiceOptions options,
                                                                                ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathSid"> The SID of the Service resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ServiceResource Fetch(string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchServiceOptions(pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathSid"> The SID of the Service resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(string pathSid,
                                                                                ITwilioRestClient client = null)
    {
      var options = new FetchServiceOptions(pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Sync,
          "/v1/Services/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// delete
    /// </summary>
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
    /// <summary>
    /// delete
    /// </summary>
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

    /// <summary>
    /// delete
    /// </summary>
    /// <param name="pathSid"> The SID of the Service resource to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static bool Delete(string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeleteServiceOptions(pathSid);
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="pathSid"> The SID of the Service resource to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeleteServiceOptions(pathSid);
      return await DeleteAsync(options, client);
    }
#endif

    private static Request BuildCreateRequest(CreateServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Sync,
          "/v1/Services",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// create
    /// </summary>
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
    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create Service parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(CreateServiceOptions options,
                                                                                 ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// create
    /// </summary>
    /// <param name="friendlyName"> A string that you assign to describe the resource </param>
    /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated </param>
    /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call webhook_url when client
    ///                                   endpoints connect to Sync </param>
    /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using
    ///                  the Permissions resource </param>
    /// <param name="reachabilityDebouncingEnabled"> Whether every endpoint_disconnected event occurs after a configurable
    ///                                     delay </param>
    /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds </param>
    /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call webhook_url when the REST API is
    ///                               used to update Sync objects </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ServiceResource Create(string friendlyName = null,
                                         Uri webhookUrl = null,
                                         bool? reachabilityWebhooksEnabled = null,
                                         bool? aclEnabled = null,
                                         bool? reachabilityDebouncingEnabled = null,
                                         int? reachabilityDebouncingWindow = null,
                                         bool? webhooksFromRestEnabled = null,
                                         ITwilioRestClient client = null)
    {
      var options = new CreateServiceOptions() { FriendlyName = friendlyName, WebhookUrl = webhookUrl, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="friendlyName"> A string that you assign to describe the resource </param>
    /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated </param>
    /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call webhook_url when client
    ///                                   endpoints connect to Sync </param>
    /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using
    ///                  the Permissions resource </param>
    /// <param name="reachabilityDebouncingEnabled"> Whether every endpoint_disconnected event occurs after a configurable
    ///                                     delay </param>
    /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds </param>
    /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call webhook_url when the REST API is
    ///                               used to update Sync objects </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(string friendlyName = null,
                                                                                 Uri webhookUrl = null,
                                                                                 bool? reachabilityWebhooksEnabled = null,
                                                                                 bool? aclEnabled = null,
                                                                                 bool? reachabilityDebouncingEnabled = null,
                                                                                 int? reachabilityDebouncingWindow = null,
                                                                                 bool? webhooksFromRestEnabled = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new CreateServiceOptions() { FriendlyName = friendlyName, WebhookUrl = webhookUrl, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Sync,
          "/v1/Services",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
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
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Service parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(ReadServiceOptions options,
                                                                                            ITwilioRestClient client = null)
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
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ResourceSet<ServiceResource> Read(int? pageSize = null,
                                                    long? limit = null,
                                                    ITwilioRestClient client = null)
    {
      var options = new ReadServiceOptions() { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(int? pageSize = null,
                                                                                            long? limit = null,
                                                                                            ITwilioRestClient client = null)
    {
      var options = new ReadServiceOptions() { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
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

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<ServiceResource> NextPage(Page<ServiceResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Sync)
      );

      var response = client.Request(request);
      return Page<ServiceResource>.FromJson("services", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<ServiceResource> PreviousPage(Page<ServiceResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Sync)
      );

      var response = client.Request(request);
      return Page<ServiceResource>.FromJson("services", response.Content);
    }

    private static Request BuildUpdateRequest(UpdateServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Sync,
          "/v1/Services/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update Service parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ServiceResource Update(UpdateServiceOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update Service parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(UpdateServiceOptions options,
                                                                                 ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathSid"> The SID of the Service resource to update </param>
    /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated </param>
    /// <param name="friendlyName"> A string that you assign to describe the resource </param>
    /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call webhook_url when client
    ///                                   endpoints connect to Sync </param>
    /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using
    ///                  the Permissions resource </param>
    /// <param name="reachabilityDebouncingEnabled"> Whether every endpoint_disconnected event occurs after a configurable
    ///                                     delay </param>
    /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds </param>
    /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call webhook_url when the REST API is
    ///                               used to update Sync objects </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ServiceResource Update(string pathSid,
                                         Uri webhookUrl = null,
                                         string friendlyName = null,
                                         bool? reachabilityWebhooksEnabled = null,
                                         bool? aclEnabled = null,
                                         bool? reachabilityDebouncingEnabled = null,
                                         int? reachabilityDebouncingWindow = null,
                                         bool? webhooksFromRestEnabled = null,
                                         ITwilioRestClient client = null)
    {
      var options = new UpdateServiceOptions(pathSid) { WebhookUrl = webhookUrl, FriendlyName = friendlyName, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathSid"> The SID of the Service resource to update </param>
    /// <param name="webhookUrl"> The URL we should call when Sync objects are manipulated </param>
    /// <param name="friendlyName"> A string that you assign to describe the resource </param>
    /// <param name="reachabilityWebhooksEnabled"> Whether the service instance should call webhook_url when client
    ///                                   endpoints connect to Sync </param>
    /// <param name="aclEnabled"> Whether token identities in the Service must be granted access to Sync objects by using
    ///                  the Permissions resource </param>
    /// <param name="reachabilityDebouncingEnabled"> Whether every endpoint_disconnected event occurs after a configurable
    ///                                     delay </param>
    /// <param name="reachabilityDebouncingWindow"> The reachability event delay in milliseconds </param>
    /// <param name="webhooksFromRestEnabled"> Whether the Service instance should call webhook_url when the REST API is
    ///                               used to update Sync objects </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(string pathSid,
                                                                                 Uri webhookUrl = null,
                                                                                 string friendlyName = null,
                                                                                 bool? reachabilityWebhooksEnabled = null,
                                                                                 bool? aclEnabled = null,
                                                                                 bool? reachabilityDebouncingEnabled = null,
                                                                                 int? reachabilityDebouncingWindow = null,
                                                                                 bool? webhooksFromRestEnabled = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new UpdateServiceOptions(pathSid) { WebhookUrl = webhookUrl, FriendlyName = friendlyName, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled, ReachabilityDebouncingEnabled = reachabilityDebouncingEnabled, ReachabilityDebouncingWindow = reachabilityDebouncingWindow, WebhooksFromRestEnabled = webhooksFromRestEnabled };
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

    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// An application-defined string that uniquely identifies the resource
    /// </summary>
    [JsonProperty("unique_name")]
    public string UniqueName { get; private set; }
    /// <summary>
    /// The SID of the Account that created the resource
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The string that you assigned to describe the resource
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The ISO 8601 date and time in GMT when the resource was created
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The ISO 8601 date and time in GMT when the resource was last updated
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The absolute URL of the Service resource
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The URL we call when Sync objects are manipulated
    /// </summary>
    [JsonProperty("webhook_url")]
    public Uri WebhookUrl { get; private set; }
    /// <summary>
    /// Whether the Service instance should call webhook_url when the REST API is used to update Sync objects
    /// </summary>
    [JsonProperty("webhooks_from_rest_enabled")]
    public bool? WebhooksFromRestEnabled { get; private set; }
    /// <summary>
    /// Whether the service instance calls webhook_url when client endpoints connect to Sync
    /// </summary>
    [JsonProperty("reachability_webhooks_enabled")]
    public bool? ReachabilityWebhooksEnabled { get; private set; }
    /// <summary>
    /// Whether token identities in the Service must be granted access to Sync objects by using the Permissions resource
    /// </summary>
    [JsonProperty("acl_enabled")]
    public bool? AclEnabled { get; private set; }
    /// <summary>
    /// Whether every endpoint_disconnected event occurs after a configurable delay
    /// </summary>
    [JsonProperty("reachability_debouncing_enabled")]
    public bool? ReachabilityDebouncingEnabled { get; private set; }
    /// <summary>
    /// The reachability event delay in milliseconds
    /// </summary>
    [JsonProperty("reachability_debouncing_window")]
    public int? ReachabilityDebouncingWindow { get; private set; }
    /// <summary>
    /// The URLs of related resources
    /// </summary>
    [JsonProperty("links")]
    public Dictionary<string, string> Links { get; private set; }

    private ServiceResource()
    {

    }
  }

}