/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// ChannelResource
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

namespace Twilio.Rest.IpMessaging.V2.Service
{

  public class ChannelResource : Resource
  {
    public sealed class ChannelTypeEnum : StringEnum
    {
      private ChannelTypeEnum(string value) : base(value) { }
      public ChannelTypeEnum() { }
      public static implicit operator ChannelTypeEnum(string value)
      {
        return new ChannelTypeEnum(value);
      }

      public static readonly ChannelTypeEnum Public = new ChannelTypeEnum("public");
      public static readonly ChannelTypeEnum Private = new ChannelTypeEnum("private");
    }

    public sealed class WebhookEnabledTypeEnum : StringEnum
    {
      private WebhookEnabledTypeEnum(string value) : base(value) { }
      public WebhookEnabledTypeEnum() { }
      public static implicit operator WebhookEnabledTypeEnum(string value)
      {
        return new WebhookEnabledTypeEnum(value);
      }

      public static readonly WebhookEnabledTypeEnum True = new WebhookEnabledTypeEnum("true");
      public static readonly WebhookEnabledTypeEnum False = new WebhookEnabledTypeEnum("false");
    }

    private static Request BuildFetchRequest(FetchChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Fetch(FetchChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> FetchAsync(FetchChannelOptions options,
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
    /// <param name="pathSid"> The sid </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchChannelOptions(pathServiceSid, pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> FetchAsync(string pathServiceSid,
                                                                                string pathSid,
                                                                                ITwilioRestClient client = null)
    {
      var options = new FetchChannelOptions(pathServiceSid, pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: options.GetHeaderParams()
      );
    }

    /// <summary>
    /// delete
    /// </summary>
    /// <param name="options"> Delete Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static bool Delete(DeleteChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="options"> Delete Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteChannelOptions options,
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
    /// <param name="pathSid"> The sid </param>
    /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static bool Delete(string pathServiceSid,
                              string pathSid,
                              ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                              ITwilioRestClient client = null)
    {
      var options = new DeleteChannelOptions(pathServiceSid, pathSid) { XTwilioWebhookEnabled = xTwilioWebhookEnabled };
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid,
                                                                      string pathSid,
                                                                      ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeleteChannelOptions(pathServiceSid, pathSid) { XTwilioWebhookEnabled = xTwilioWebhookEnabled };
      return await DeleteAsync(options, client);
    }
#endif

    private static Request BuildCreateRequest(CreateChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels",
          postParams: options.GetParams(),
          headerParams: options.GetHeaderParams()
      );
    }

    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Create(CreateChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(CreateChannelOptions options,
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
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="uniqueName"> The unique_name </param>
    /// <param name="attributes"> The attributes </param>
    /// <param name="type"> The type </param>
    /// <param name="dateCreated"> The date_created </param>
    /// <param name="dateUpdated"> The date_updated </param>
    /// <param name="createdBy"> The created_by </param>
    /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Create(string pathServiceSid,
                                         string friendlyName = null,
                                         string uniqueName = null,
                                         string attributes = null,
                                         ChannelResource.ChannelTypeEnum type = null,
                                         DateTime? dateCreated = null,
                                         DateTime? dateUpdated = null,
                                         string createdBy = null,
                                         ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                         ITwilioRestClient client = null)
    {
      var options = new CreateChannelOptions(pathServiceSid) { FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, Type = type, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="uniqueName"> The unique_name </param>
    /// <param name="attributes"> The attributes </param>
    /// <param name="type"> The type </param>
    /// <param name="dateCreated"> The date_created </param>
    /// <param name="dateUpdated"> The date_updated </param>
    /// <param name="createdBy"> The created_by </param>
    /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(string pathServiceSid,
                                                                                 string friendlyName = null,
                                                                                 string uniqueName = null,
                                                                                 string attributes = null,
                                                                                 ChannelResource.ChannelTypeEnum type = null,
                                                                                 DateTime? dateCreated = null,
                                                                                 DateTime? dateUpdated = null,
                                                                                 string createdBy = null,
                                                                                 ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new CreateChannelOptions(pathServiceSid) { FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, Type = type, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ResourceSet<ChannelResource> Read(ReadChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<ChannelResource>.FromJson("channels", response.Content);
      return new ResourceSet<ChannelResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<ChannelResource>> ReadAsync(ReadChannelOptions options,
                                                                                            ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<ChannelResource>.FromJson("channels", response.Content);
      return new ResourceSet<ChannelResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="type"> The type </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ResourceSet<ChannelResource> Read(string pathServiceSid,
                                                    List<ChannelResource.ChannelTypeEnum> type = null,
                                                    int? pageSize = null,
                                                    long? limit = null,
                                                    ITwilioRestClient client = null)
    {
      var options = new ReadChannelOptions(pathServiceSid) { Type = type, PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="type"> The type </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<ChannelResource>> ReadAsync(string pathServiceSid,
                                                                                            List<ChannelResource.ChannelTypeEnum> type = null,
                                                                                            int? pageSize = null,
                                                                                            long? limit = null,
                                                                                            ITwilioRestClient client = null)
    {
      var options = new ReadChannelOptions(pathServiceSid) { Type = type, PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<ChannelResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<ChannelResource>.FromJson("channels", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<ChannelResource> NextPage(Page<ChannelResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.IpMessaging)
      );

      var response = client.Request(request);
      return Page<ChannelResource>.FromJson("channels", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<ChannelResource> PreviousPage(Page<ChannelResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.IpMessaging)
      );

      var response = client.Request(request);
      return Page<ChannelResource>.FromJson("channels", response.Content);
    }

    private static Request BuildUpdateRequest(UpdateChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.IpMessaging,
          "/v2/Services/" + options.PathServiceSid + "/Channels/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: options.GetHeaderParams()
      );
    }

    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Update(UpdateChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> UpdateAsync(UpdateChannelOptions options,
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
    /// <param name="pathSid"> The sid </param>
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="uniqueName"> The unique_name </param>
    /// <param name="attributes"> The attributes </param>
    /// <param name="dateCreated"> The date_created </param>
    /// <param name="dateUpdated"> The date_updated </param>
    /// <param name="createdBy"> The created_by </param>
    /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Update(string pathServiceSid,
                                         string pathSid,
                                         string friendlyName = null,
                                         string uniqueName = null,
                                         string attributes = null,
                                         DateTime? dateCreated = null,
                                         DateTime? dateUpdated = null,
                                         string createdBy = null,
                                         ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                         ITwilioRestClient client = null)
    {
      var options = new UpdateChannelOptions(pathServiceSid, pathSid) { FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathSid"> The sid </param>
    /// <param name="friendlyName"> The friendly_name </param>
    /// <param name="uniqueName"> The unique_name </param>
    /// <param name="attributes"> The attributes </param>
    /// <param name="dateCreated"> The date_created </param>
    /// <param name="dateUpdated"> The date_updated </param>
    /// <param name="createdBy"> The created_by </param>
    /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> UpdateAsync(string pathServiceSid,
                                                                                 string pathSid,
                                                                                 string friendlyName = null,
                                                                                 string uniqueName = null,
                                                                                 string attributes = null,
                                                                                 DateTime? dateCreated = null,
                                                                                 DateTime? dateUpdated = null,
                                                                                 string createdBy = null,
                                                                                 ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new UpdateChannelOptions(pathServiceSid, pathSid) { FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
      return await UpdateAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a ChannelResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> ChannelResource object represented by the provided JSON </returns>
    public static ChannelResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<ChannelResource>(json);
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
    /// The friendly_name
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The unique_name
    /// </summary>
    [JsonProperty("unique_name")]
    public string UniqueName { get; private set; }
    /// <summary>
    /// The attributes
    /// </summary>
    [JsonProperty("attributes")]
    public string Attributes { get; private set; }
    /// <summary>
    /// The type
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ChannelResource.ChannelTypeEnum Type { get; private set; }
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
    /// The created_by
    /// </summary>
    [JsonProperty("created_by")]
    public string CreatedBy { get; private set; }
    /// <summary>
    /// The members_count
    /// </summary>
    [JsonProperty("members_count")]
    public int? MembersCount { get; private set; }
    /// <summary>
    /// The messages_count
    /// </summary>
    [JsonProperty("messages_count")]
    public int? MessagesCount { get; private set; }
    /// <summary>
    /// The url
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The links
    /// </summary>
    [JsonProperty("links")]
    public Dictionary<string, string> Links { get; private set; }

    private ChannelResource()
    {

    }
  }

}