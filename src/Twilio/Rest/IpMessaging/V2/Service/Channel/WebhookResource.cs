/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// WebhookResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.IpMessaging.V2.Service.Channel
{

  public class WebhookResource : Resource
  {
    public sealed class TypeEnum : StringEnum
    {
      private TypeEnum(string value) : base(value) { }
      public TypeEnum() { }
      public static implicit operator TypeEnum(string value)
      {
        return new TypeEnum(value);
      }

      public static readonly TypeEnum Webhook = new TypeEnum("webhook");
      public static readonly TypeEnum Trigger = new TypeEnum("trigger");
      public static readonly TypeEnum Studio = new TypeEnum("studio");
    }

    public sealed class MethodEnum : StringEnum
    {
      private MethodEnum(string value) : base(value) { }
      public MethodEnum() { }
      public static implicit operator MethodEnum(string value)
      {
        return new MethodEnum(value);
      }

      public static readonly MethodEnum Get = new MethodEnum("GET");
      public static readonly MethodEnum Post = new MethodEnum("POST");
    }

    private static Request BuildReadRequest(ReadWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Webhooks",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static ResourceSet<WebhookResource> Read(ReadWebhookOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<WebhookResource>.FromJson("webhooks", response.Content);
      return new ResourceSet<WebhookResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<WebhookResource>> ReadAsync(ReadWebhookOptions options,
                                                                                            ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<WebhookResource>.FromJson("webhooks", response.Content);
      return new ResourceSet<WebhookResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static ResourceSet<WebhookResource> Read(string pathServiceSid,
                                                    string pathChannelSid,
                                                    int? pageSize = null,
                                                    long? limit = null,
                                                    ITwilioRestClient client = null)
    {
      var options = new ReadWebhookOptions(pathServiceSid, pathChannelSid) { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<WebhookResource>> ReadAsync(string pathServiceSid,
                                                                                            string pathChannelSid,
                                                                                            int? pageSize = null,
                                                                                            long? limit = null,
                                                                                            ITwilioRestClient client = null)
    {
      var options = new ReadWebhookOptions(pathServiceSid, pathChannelSid) { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<WebhookResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<WebhookResource>.FromJson("webhooks", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<WebhookResource> NextPage(Page<WebhookResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.IpMessaging)
      );

      var response = client.Request(request);
      return Page<WebhookResource>.FromJson("webhooks", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<WebhookResource> PreviousPage(Page<WebhookResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.IpMessaging)
      );

      var response = client.Request(request);
      return Page<WebhookResource>.FromJson("webhooks", response.Content);
    }

    private static Request BuildFetchRequest(FetchWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Webhooks/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Fetch(FetchWebhookOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> FetchAsync(FetchWebhookOptions options,
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
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Fetch(string pathServiceSid,
                                        string pathChannelSid,
                                        string pathSid,
                                        ITwilioRestClient client = null)
    {
      var options = new FetchWebhookOptions(pathServiceSid, pathChannelSid, pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> FetchAsync(string pathServiceSid,
                                                                                string pathChannelSid,
                                                                                string pathSid,
                                                                                ITwilioRestClient client = null)
    {
      var options = new FetchWebhookOptions(pathServiceSid, pathChannelSid, pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildCreateRequest(CreateWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Webhooks",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Create(CreateWebhookOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> CreateAsync(CreateWebhookOptions options,
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
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="type"> The type </param>
    /// <param name="configurationUrl"> The configuration.url </param>
    /// <param name="configurationMethod"> The configuration.method </param>
    /// <param name="configurationFilters"> The configuration.filters </param>
    /// <param name="configurationTriggers"> The configuration.triggers </param>
    /// <param name="configurationFlowSid"> The configuration.flow_sid </param>
    /// <param name="configurationRetryCount"> The configuration.retry_count </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Create(string pathServiceSid,
                                         string pathChannelSid,
                                         WebhookResource.TypeEnum type,
                                         string configurationUrl = null,
                                         WebhookResource.MethodEnum configurationMethod = null,
                                         List<string> configurationFilters = null,
                                         List<string> configurationTriggers = null,
                                         string configurationFlowSid = null,
                                         int? configurationRetryCount = null,
                                         ITwilioRestClient client = null)
    {
      var options = new CreateWebhookOptions(pathServiceSid, pathChannelSid, type) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid, ConfigurationRetryCount = configurationRetryCount };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="type"> The type </param>
    /// <param name="configurationUrl"> The configuration.url </param>
    /// <param name="configurationMethod"> The configuration.method </param>
    /// <param name="configurationFilters"> The configuration.filters </param>
    /// <param name="configurationTriggers"> The configuration.triggers </param>
    /// <param name="configurationFlowSid"> The configuration.flow_sid </param>
    /// <param name="configurationRetryCount"> The configuration.retry_count </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> CreateAsync(string pathServiceSid,
                                                                                 string pathChannelSid,
                                                                                 WebhookResource.TypeEnum type,
                                                                                 string configurationUrl = null,
                                                                                 WebhookResource.MethodEnum configurationMethod = null,
                                                                                 List<string> configurationFilters = null,
                                                                                 List<string> configurationTriggers = null,
                                                                                 string configurationFlowSid = null,
                                                                                 int? configurationRetryCount = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new CreateWebhookOptions(pathServiceSid, pathChannelSid, type) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid, ConfigurationRetryCount = configurationRetryCount };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildUpdateRequest(UpdateWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Webhooks/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Update(UpdateWebhookOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> UpdateAsync(UpdateWebhookOptions options,
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
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="configurationUrl"> The configuration.url </param>
    /// <param name="configurationMethod"> The configuration.method </param>
    /// <param name="configurationFilters"> The configuration.filters </param>
    /// <param name="configurationTriggers"> The configuration.triggers </param>
    /// <param name="configurationFlowSid"> The configuration.flow_sid </param>
    /// <param name="configurationRetryCount"> The configuration.retry_count </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Update(string pathServiceSid,
                                         string pathChannelSid,
                                         string pathSid,
                                         string configurationUrl = null,
                                         WebhookResource.MethodEnum configurationMethod = null,
                                         List<string> configurationFilters = null,
                                         List<string> configurationTriggers = null,
                                         string configurationFlowSid = null,
                                         int? configurationRetryCount = null,
                                         ITwilioRestClient client = null)
    {
      var options = new UpdateWebhookOptions(pathServiceSid, pathChannelSid, pathSid) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid, ConfigurationRetryCount = configurationRetryCount };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="configurationUrl"> The configuration.url </param>
    /// <param name="configurationMethod"> The configuration.method </param>
    /// <param name="configurationFilters"> The configuration.filters </param>
    /// <param name="configurationTriggers"> The configuration.triggers </param>
    /// <param name="configurationFlowSid"> The configuration.flow_sid </param>
    /// <param name="configurationRetryCount"> The configuration.retry_count </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> UpdateAsync(string pathServiceSid,
                                                                                 string pathChannelSid,
                                                                                 string pathSid,
                                                                                 string configurationUrl = null,
                                                                                 WebhookResource.MethodEnum configurationMethod = null,
                                                                                 List<string> configurationFilters = null,
                                                                                 List<string> configurationTriggers = null,
                                                                                 string configurationFlowSid = null,
                                                                                 int? configurationRetryCount = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new UpdateWebhookOptions(pathServiceSid, pathChannelSid, pathSid) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid, ConfigurationRetryCount = configurationRetryCount };
      return await UpdateAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathChannelSid + "/Webhooks/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// delete
    /// </summary>
    /// <param name="options"> Delete Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static bool Delete(DeleteWebhookOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="options"> Delete Webhook parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteWebhookOptions options,
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
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static bool Delete(string pathServiceSid,
                              string pathChannelSid,
                              string pathSid,
                              ITwilioRestClient client = null)
    {
      var options = new DeleteWebhookOptions(pathServiceSid, pathChannelSid, pathSid);
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid,
                                                                      string pathChannelSid,
                                                                      string pathSid,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeleteWebhookOptions(pathServiceSid, pathChannelSid, pathSid);
      return await DeleteAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a WebhookResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> WebhookResource object represented by the provided JSON </returns>
    public static WebhookResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<WebhookResource>(json);
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
    /// The service_sid
    /// </summary>
    [JsonProperty("service_sid")]
    public string ServiceSid { get; private set; }
    /// <summary>
    /// The channel_sid
    /// </summary>
    [JsonProperty("channel_sid")]
    public string ChannelSid { get; private set; }
    /// <summary>
    /// The type
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; private set; }
    /// <summary>
    /// The url
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The configuration
    /// </summary>
    [JsonProperty("configuration")]
    public object Configuration { get; private set; }
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

    private WebhookResource()
    {

    }
  }

}