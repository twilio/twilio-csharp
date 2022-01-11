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

namespace Twilio.Rest.Conversations.V1.Conversation
{

  public class WebhookResource : Resource
  {
    public sealed class TargetEnum : StringEnum
    {
      private TargetEnum(string value) : base(value) { }
      public TargetEnum() { }
      public static implicit operator TargetEnum(string value)
      {
        return new TargetEnum(value);
      }

      public static readonly TargetEnum Webhook = new TargetEnum("webhook");
      public static readonly TargetEnum Trigger = new TargetEnum("trigger");
      public static readonly TargetEnum Studio = new TargetEnum("studio");
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
          Rest.Domain.Conversations,
          "/v1/Conversations/" + options.PathConversationSid + "/Webhooks",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Retrieve a list of all webhooks scoped to the conversation
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
    /// Retrieve a list of all webhooks scoped to the conversation
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
    /// Retrieve a list of all webhooks scoped to the conversation
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static ResourceSet<WebhookResource> Read(string pathConversationSid,
                                                    int? pageSize = null,
                                                    long? limit = null,
                                                    ITwilioRestClient client = null)
    {
      var options = new ReadWebhookOptions(pathConversationSid) { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of all webhooks scoped to the conversation
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<WebhookResource>> ReadAsync(string pathConversationSid,
                                                                                            int? pageSize = null,
                                                                                            long? limit = null,
                                                                                            ITwilioRestClient client = null)
    {
      var options = new ReadWebhookOptions(pathConversationSid) { PageSize = pageSize, Limit = limit };
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
          page.GetNextPageUrl(Rest.Domain.Conversations)
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
          page.GetPreviousPageUrl(Rest.Domain.Conversations)
      );

      var response = client.Request(request);
      return Page<WebhookResource>.FromJson("webhooks", response.Content);
    }

    private static Request BuildFetchRequest(FetchWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Conversations,
          "/v1/Conversations/" + options.PathConversationSid + "/Webhooks/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Fetch the configuration of a conversation-scoped webhook
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
    /// Fetch the configuration of a conversation-scoped webhook
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
    /// Fetch the configuration of a conversation-scoped webhook
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Fetch(string pathConversationSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchWebhookOptions(pathConversationSid, pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// Fetch the configuration of a conversation-scoped webhook
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> FetchAsync(string pathConversationSid,
                                                                                string pathSid,
                                                                                ITwilioRestClient client = null)
    {
      var options = new FetchWebhookOptions(pathConversationSid, pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildCreateRequest(CreateWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Conversations,
          "/v1/Conversations/" + options.PathConversationSid + "/Webhooks",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Create a new webhook scoped to the conversation
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
    /// Create a new webhook scoped to the conversation
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
    /// Create a new webhook scoped to the conversation
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="target"> The target of this webhook. </param>
    /// <param name="configurationUrl"> The absolute url the webhook request should be sent to. </param>
    /// <param name="configurationMethod"> The HTTP method to be used when sending a webhook request. </param>
    /// <param name="configurationFilters"> The list of events, firing webhook event for this Conversation. </param>
    /// <param name="configurationTriggers"> The list of keywords, firing webhook event for this Conversation. </param>
    /// <param name="configurationFlowSid"> The studio flow SID, where the webhook should be sent to. </param>
    /// <param name="configurationReplayAfter"> The message index for which and it's successors the webhook will be
    ///                                replayed. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Create(string pathConversationSid,
                                         WebhookResource.TargetEnum target,
                                         string configurationUrl = null,
                                         WebhookResource.MethodEnum configurationMethod = null,
                                         List<string> configurationFilters = null,
                                         List<string> configurationTriggers = null,
                                         string configurationFlowSid = null,
                                         int? configurationReplayAfter = null,
                                         ITwilioRestClient client = null)
    {
      var options = new CreateWebhookOptions(pathConversationSid, target) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid, ConfigurationReplayAfter = configurationReplayAfter };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// Create a new webhook scoped to the conversation
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="target"> The target of this webhook. </param>
    /// <param name="configurationUrl"> The absolute url the webhook request should be sent to. </param>
    /// <param name="configurationMethod"> The HTTP method to be used when sending a webhook request. </param>
    /// <param name="configurationFilters"> The list of events, firing webhook event for this Conversation. </param>
    /// <param name="configurationTriggers"> The list of keywords, firing webhook event for this Conversation. </param>
    /// <param name="configurationFlowSid"> The studio flow SID, where the webhook should be sent to. </param>
    /// <param name="configurationReplayAfter"> The message index for which and it's successors the webhook will be
    ///                                replayed. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> CreateAsync(string pathConversationSid,
                                                                                 WebhookResource.TargetEnum target,
                                                                                 string configurationUrl = null,
                                                                                 WebhookResource.MethodEnum configurationMethod = null,
                                                                                 List<string> configurationFilters = null,
                                                                                 List<string> configurationTriggers = null,
                                                                                 string configurationFlowSid = null,
                                                                                 int? configurationReplayAfter = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new CreateWebhookOptions(pathConversationSid, target) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid, ConfigurationReplayAfter = configurationReplayAfter };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildUpdateRequest(UpdateWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Conversations,
          "/v1/Conversations/" + options.PathConversationSid + "/Webhooks/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Update an existing conversation-scoped webhook
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
    /// Update an existing conversation-scoped webhook
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
    /// Update an existing conversation-scoped webhook
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    /// <param name="configurationUrl"> The absolute url the webhook request should be sent to. </param>
    /// <param name="configurationMethod"> The HTTP method to be used when sending a webhook request. </param>
    /// <param name="configurationFilters"> The list of events, firing webhook event for this Conversation. </param>
    /// <param name="configurationTriggers"> The list of keywords, firing webhook event for this Conversation. </param>
    /// <param name="configurationFlowSid"> The studio flow SID, where the webhook should be sent to. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static WebhookResource Update(string pathConversationSid,
                                         string pathSid,
                                         string configurationUrl = null,
                                         WebhookResource.MethodEnum configurationMethod = null,
                                         List<string> configurationFilters = null,
                                         List<string> configurationTriggers = null,
                                         string configurationFlowSid = null,
                                         ITwilioRestClient client = null)
    {
      var options = new UpdateWebhookOptions(pathConversationSid, pathSid) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// Update an existing conversation-scoped webhook
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    /// <param name="configurationUrl"> The absolute url the webhook request should be sent to. </param>
    /// <param name="configurationMethod"> The HTTP method to be used when sending a webhook request. </param>
    /// <param name="configurationFilters"> The list of events, firing webhook event for this Conversation. </param>
    /// <param name="configurationTriggers"> The list of keywords, firing webhook event for this Conversation. </param>
    /// <param name="configurationFlowSid"> The studio flow SID, where the webhook should be sent to. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<WebhookResource> UpdateAsync(string pathConversationSid,
                                                                                 string pathSid,
                                                                                 string configurationUrl = null,
                                                                                 WebhookResource.MethodEnum configurationMethod = null,
                                                                                 List<string> configurationFilters = null,
                                                                                 List<string> configurationTriggers = null,
                                                                                 string configurationFlowSid = null,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new UpdateWebhookOptions(pathConversationSid, pathSid) { ConfigurationUrl = configurationUrl, ConfigurationMethod = configurationMethod, ConfigurationFilters = configurationFilters, ConfigurationTriggers = configurationTriggers, ConfigurationFlowSid = configurationFlowSid };
      return await UpdateAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteWebhookOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Conversations,
          "/v1/Conversations/" + options.PathConversationSid + "/Webhooks/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Remove an existing webhook scoped to the conversation
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
    /// Remove an existing webhook scoped to the conversation
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
    /// Remove an existing webhook scoped to the conversation
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Webhook </returns>
    public static bool Delete(string pathConversationSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeleteWebhookOptions(pathConversationSid, pathSid);
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// Remove an existing webhook scoped to the conversation
    /// </summary>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this webhook. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Webhook </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathConversationSid,
                                                                      string pathSid,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeleteWebhookOptions(pathConversationSid, pathSid);
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
    /// A 34 character string that uniquely identifies this resource.
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The unique ID of the Account responsible for this conversation.
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The unique ID of the Conversation for this webhook.
    /// </summary>
    [JsonProperty("conversation_sid")]
    public string ConversationSid { get; private set; }
    /// <summary>
    /// The target of this webhook.
    /// </summary>
    [JsonProperty("target")]
    public string Target { get; private set; }
    /// <summary>
    /// An absolute URL for this webhook.
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The configuration of this webhook.
    /// </summary>
    [JsonProperty("configuration")]
    public object Configuration { get; private set; }
    /// <summary>
    /// The date that this resource was created.
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The date that this resource was last updated.
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }

    private WebhookResource()
    {

    }
  }

}