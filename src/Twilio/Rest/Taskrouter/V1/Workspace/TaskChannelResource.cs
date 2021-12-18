/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// TaskChannelResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace
{

  public class TaskChannelResource : Resource
  {
    private static Request BuildFetchRequest(FetchTaskChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/TaskChannels/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static TaskChannelResource Fetch(FetchTaskChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<TaskChannelResource> FetchAsync(FetchTaskChannelOptions options,
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
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to fetch </param>
    /// <param name="pathSid"> The SID of the Task Channel resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static TaskChannelResource Fetch(string pathWorkspaceSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchTaskChannelOptions(pathWorkspaceSid, pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to fetch </param>
    /// <param name="pathSid"> The SID of the Task Channel resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<TaskChannelResource> FetchAsync(string pathWorkspaceSid,
                                                                                    string pathSid,
                                                                                    ITwilioRestClient client = null)
    {
      var options = new FetchTaskChannelOptions(pathWorkspaceSid, pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadTaskChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/TaskChannels",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static ResourceSet<TaskChannelResource> Read(ReadTaskChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<TaskChannelResource>.FromJson("channels", response.Content);
      return new ResourceSet<TaskChannelResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<TaskChannelResource>> ReadAsync(ReadTaskChannelOptions options,
                                                                                                ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<TaskChannelResource>.FromJson("channels", response.Content);
      return new ResourceSet<TaskChannelResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static ResourceSet<TaskChannelResource> Read(string pathWorkspaceSid,
                                                        int? pageSize = null,
                                                        long? limit = null,
                                                        ITwilioRestClient client = null)
    {
      var options = new ReadTaskChannelOptions(pathWorkspaceSid) { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<TaskChannelResource>> ReadAsync(string pathWorkspaceSid,
                                                                                                int? pageSize = null,
                                                                                                long? limit = null,
                                                                                                ITwilioRestClient client = null)
    {
      var options = new ReadTaskChannelOptions(pathWorkspaceSid) { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<TaskChannelResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<TaskChannelResource>.FromJson("channels", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<TaskChannelResource> NextPage(Page<TaskChannelResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Taskrouter)
      );

      var response = client.Request(request);
      return Page<TaskChannelResource>.FromJson("channels", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<TaskChannelResource> PreviousPage(Page<TaskChannelResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Taskrouter)
      );

      var response = client.Request(request);
      return Page<TaskChannelResource>.FromJson("channels", response.Content);
    }

    private static Request BuildUpdateRequest(UpdateTaskChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/TaskChannels/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static TaskChannelResource Update(UpdateTaskChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<TaskChannelResource> UpdateAsync(UpdateTaskChannelOptions options,
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
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to update </param>
    /// <param name="pathSid"> The SID of the Task Channel resource to update </param>
    /// <param name="friendlyName"> A string to describe the Task Channel resource </param>
    /// <param name="channelOptimizedRouting"> Whether the TaskChannel should prioritize Workers that have been idle
    ///                               </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static TaskChannelResource Update(string pathWorkspaceSid,
                                             string pathSid,
                                             string friendlyName = null,
                                             bool? channelOptimizedRouting = null,
                                             ITwilioRestClient client = null)
    {
      var options = new UpdateTaskChannelOptions(pathWorkspaceSid, pathSid) { FriendlyName = friendlyName, ChannelOptimizedRouting = channelOptimizedRouting };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to update </param>
    /// <param name="pathSid"> The SID of the Task Channel resource to update </param>
    /// <param name="friendlyName"> A string to describe the Task Channel resource </param>
    /// <param name="channelOptimizedRouting"> Whether the TaskChannel should prioritize Workers that have been idle
    ///                               </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<TaskChannelResource> UpdateAsync(string pathWorkspaceSid,
                                                                                     string pathSid,
                                                                                     string friendlyName = null,
                                                                                     bool? channelOptimizedRouting = null,
                                                                                     ITwilioRestClient client = null)
    {
      var options = new UpdateTaskChannelOptions(pathWorkspaceSid, pathSid) { FriendlyName = friendlyName, ChannelOptimizedRouting = channelOptimizedRouting };
      return await UpdateAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteTaskChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/TaskChannels/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// delete
    /// </summary>
    /// <param name="options"> Delete TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static bool Delete(DeleteTaskChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="options"> Delete TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteTaskChannelOptions options,
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
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to delete </param>
    /// <param name="pathSid"> The SID of the Task Channel resource to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static bool Delete(string pathWorkspaceSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeleteTaskChannelOptions(pathWorkspaceSid, pathSid);
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Task Channel to delete </param>
    /// <param name="pathSid"> The SID of the Task Channel resource to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathWorkspaceSid,
                                                                      string pathSid,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeleteTaskChannelOptions(pathWorkspaceSid, pathSid);
      return await DeleteAsync(options, client);
    }
#endif

    private static Request BuildCreateRequest(CreateTaskChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/TaskChannels",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static TaskChannelResource Create(CreateTaskChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create TaskChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<TaskChannelResource> CreateAsync(CreateTaskChannelOptions options,
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
    /// <param name="pathWorkspaceSid"> The SID of the Workspace that the new Task Channel belongs to </param>
    /// <param name="friendlyName"> A string to describe the Task Channel resource </param>
    /// <param name="uniqueName"> An application-defined string that uniquely identifies the Task Channel </param>
    /// <param name="channelOptimizedRouting"> Whether the Task Channel should prioritize Workers that have been idle
    ///                               </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of TaskChannel </returns>
    public static TaskChannelResource Create(string pathWorkspaceSid,
                                             string friendlyName,
                                             string uniqueName,
                                             bool? channelOptimizedRouting = null,
                                             ITwilioRestClient client = null)
    {
      var options = new CreateTaskChannelOptions(pathWorkspaceSid, friendlyName, uniqueName) { ChannelOptimizedRouting = channelOptimizedRouting };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace that the new Task Channel belongs to </param>
    /// <param name="friendlyName"> A string to describe the Task Channel resource </param>
    /// <param name="uniqueName"> An application-defined string that uniquely identifies the Task Channel </param>
    /// <param name="channelOptimizedRouting"> Whether the Task Channel should prioritize Workers that have been idle
    ///                               </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of TaskChannel </returns>
    public static async System.Threading.Tasks.Task<TaskChannelResource> CreateAsync(string pathWorkspaceSid,
                                                                                     string friendlyName,
                                                                                     string uniqueName,
                                                                                     bool? channelOptimizedRouting = null,
                                                                                     ITwilioRestClient client = null)
    {
      var options = new CreateTaskChannelOptions(pathWorkspaceSid, friendlyName, uniqueName) { ChannelOptimizedRouting = channelOptimizedRouting };
      return await CreateAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a TaskChannelResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> TaskChannelResource object represented by the provided JSON </returns>
    public static TaskChannelResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<TaskChannelResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// The SID of the Account that created the resource
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
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
    /// The string that you assigned to describe the resource
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// An application-defined string that uniquely identifies the Task Channel
    /// </summary>
    [JsonProperty("unique_name")]
    public string UniqueName { get; private set; }
    /// <summary>
    /// The SID of the Workspace that contains the Task Channel
    /// </summary>
    [JsonProperty("workspace_sid")]
    public string WorkspaceSid { get; private set; }
    /// <summary>
    /// Whether the Task Channel will prioritize Workers that have been idle
    /// </summary>
    [JsonProperty("channel_optimized_routing")]
    public bool? ChannelOptimizedRouting { get; private set; }
    /// <summary>
    /// The absolute URL of the Task Channel resource
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The URLs of related resources
    /// </summary>
    [JsonProperty("links")]
    public Dictionary<string, string> Links { get; private set; }

    private TaskChannelResource()
    {

    }
  }

}