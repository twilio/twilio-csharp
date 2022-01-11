/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
/// currently do not have developer preview access, please contact help@twilio.com.
///
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

namespace Twilio.Rest.Preview.Sync
{

  public class ServiceResource : Resource
  {
    private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Preview,
          "/Sync/Services/" + options.PathSid + "",
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
    /// <param name="pathSid"> The sid </param>
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
    /// <param name="pathSid"> The sid </param>
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
          Rest.Domain.Preview,
          "/Sync/Services/" + options.PathSid + "",
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
    /// <param name="pathSid"> The sid </param>
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
    /// <param name="pathSid"> The sid </param>
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
          Rest.Domain.Preview,
          "/Sync/Services",
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
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="webhookUrl"> The webhook_url </param>
    /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
    /// <param name="aclEnabled"> The acl_enabled </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ServiceResource Create(string friendlyName = null,
                                         Uri webhookUrl = null,
                                         bool? reachabilityWebhooksEnabled = null,
                                         bool? aclEnabled = null,
                                         ITwilioRestClient client = null)
    {
      var options = new CreateServiceOptions() { FriendlyName = friendlyName, WebhookUrl = webhookUrl, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="webhookUrl"> The webhook_url </param>
    /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
    /// <param name="aclEnabled"> The acl_enabled </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(string friendlyName = null,
                                                                                 Uri webhookUrl = null,
                                                                                 bool? reachabilityWebhooksEnabled = null,
                                                                                 bool? aclEnabled = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new CreateServiceOptions() { FriendlyName = friendlyName, WebhookUrl = webhookUrl, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Preview,
          "/Sync/Services",
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
          page.GetNextPageUrl(Rest.Domain.Preview)
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
          page.GetPreviousPageUrl(Rest.Domain.Preview)
      );

      var response = client.Request(request);
      return Page<ServiceResource>.FromJson("services", response.Content);
    }

    private static Request BuildUpdateRequest(UpdateServiceOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Preview,
          "/Sync/Services/" + options.PathSid + "",
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
    /// <param name="pathSid"> The sid </param>
    /// <param name="webhookUrl"> The webhook_url </param>
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
    /// <param name="aclEnabled"> The acl_enabled </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Service </returns>
    public static ServiceResource Update(string pathSid,
                                         Uri webhookUrl = null,
                                         string friendlyName = null,
                                         bool? reachabilityWebhooksEnabled = null,
                                         bool? aclEnabled = null,
                                         ITwilioRestClient client = null)
    {
      var options = new UpdateServiceOptions(pathSid) { WebhookUrl = webhookUrl, FriendlyName = friendlyName, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathSid"> The sid </param>
    /// <param name="webhookUrl"> The webhook_url </param>
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="reachabilityWebhooksEnabled"> The reachability_webhooks_enabled </param>
    /// <param name="aclEnabled"> The acl_enabled </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Service </returns>
    public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(string pathSid,
                                                                                 Uri webhookUrl = null,
                                                                                 string friendlyName = null,
                                                                                 bool? reachabilityWebhooksEnabled = null,
                                                                                 bool? aclEnabled = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new UpdateServiceOptions(pathSid) { WebhookUrl = webhookUrl, FriendlyName = friendlyName, ReachabilityWebhooksEnabled = reachabilityWebhooksEnabled, AclEnabled = aclEnabled };
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
    /// The sid
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The account_sid
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The friendly_name
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The date_created
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The date_updated
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The url
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The webhook_url
    /// </summary>
    [JsonProperty("webhook_url")]
    public Uri WebhookUrl { get; private set; }
    /// <summary>
    /// The reachability_webhooks_enabled
    /// </summary>
    [JsonProperty("reachability_webhooks_enabled")]
    public bool? ReachabilityWebhooksEnabled { get; private set; }
    /// <summary>
    /// The acl_enabled
    /// </summary>
    [JsonProperty("acl_enabled")]
    public bool? AclEnabled { get; private set; }
    /// <summary>
    /// The links
    /// </summary>
    [JsonProperty("links")]
    public Dictionary<string, string> Links { get; private set; }

    private ServiceResource()
    {

    }
  }

}