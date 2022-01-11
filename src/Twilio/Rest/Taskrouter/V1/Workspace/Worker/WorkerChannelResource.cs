/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// WorkerChannelResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker
{

  public class WorkerChannelResource : Resource
  {
    private static Request BuildReadRequest(ReadWorkerChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/" + options.PathWorkerSid + "/Channels",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read WorkerChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of WorkerChannel </returns>
    public static ResourceSet<WorkerChannelResource> Read(ReadWorkerChannelOptions options,
                                                          ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<WorkerChannelResource>.FromJson("channels", response.Content);
      return new ResourceSet<WorkerChannelResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read WorkerChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of WorkerChannel </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<WorkerChannelResource>> ReadAsync(ReadWorkerChannelOptions options,
                                                                                                  ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<WorkerChannelResource>.FromJson("channels", response.Content);
      return new ResourceSet<WorkerChannelResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the WorkerChannels to read </param>
    /// <param name="pathWorkerSid"> The SID of the Worker with the WorkerChannels to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of WorkerChannel </returns>
    public static ResourceSet<WorkerChannelResource> Read(string pathWorkspaceSid,
                                                          string pathWorkerSid,
                                                          int? pageSize = null,
                                                          long? limit = null,
                                                          ITwilioRestClient client = null)
    {
      var options = new ReadWorkerChannelOptions(pathWorkspaceSid, pathWorkerSid) { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the WorkerChannels to read </param>
    /// <param name="pathWorkerSid"> The SID of the Worker with the WorkerChannels to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of WorkerChannel </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<WorkerChannelResource>> ReadAsync(string pathWorkspaceSid,
                                                                                                  string pathWorkerSid,
                                                                                                  int? pageSize = null,
                                                                                                  long? limit = null,
                                                                                                  ITwilioRestClient client = null)
    {
      var options = new ReadWorkerChannelOptions(pathWorkspaceSid, pathWorkerSid) { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<WorkerChannelResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<WorkerChannelResource>.FromJson("channels", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<WorkerChannelResource> NextPage(Page<WorkerChannelResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Taskrouter)
      );

      var response = client.Request(request);
      return Page<WorkerChannelResource>.FromJson("channels", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<WorkerChannelResource> PreviousPage(Page<WorkerChannelResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Taskrouter)
      );

      var response = client.Request(request);
      return Page<WorkerChannelResource>.FromJson("channels", response.Content);
    }

    private static Request BuildFetchRequest(FetchWorkerChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/" + options.PathWorkerSid + "/Channels/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch WorkerChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of WorkerChannel </returns>
    public static WorkerChannelResource Fetch(FetchWorkerChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch WorkerChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of WorkerChannel </returns>
    public static async System.Threading.Tasks.Task<WorkerChannelResource> FetchAsync(FetchWorkerChannelOptions options,
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
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the WorkerChannel to fetch </param>
    /// <param name="pathWorkerSid"> The SID of the Worker with the WorkerChannel to fetch </param>
    /// <param name="pathSid"> The SID of the to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of WorkerChannel </returns>
    public static WorkerChannelResource Fetch(string pathWorkspaceSid,
                                              string pathWorkerSid,
                                              string pathSid,
                                              ITwilioRestClient client = null)
    {
      var options = new FetchWorkerChannelOptions(pathWorkspaceSid, pathWorkerSid, pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the WorkerChannel to fetch </param>
    /// <param name="pathWorkerSid"> The SID of the Worker with the WorkerChannel to fetch </param>
    /// <param name="pathSid"> The SID of the to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of WorkerChannel </returns>
    public static async System.Threading.Tasks.Task<WorkerChannelResource> FetchAsync(string pathWorkspaceSid,
                                                                                      string pathWorkerSid,
                                                                                      string pathSid,
                                                                                      ITwilioRestClient client = null)
    {
      var options = new FetchWorkerChannelOptions(pathWorkspaceSid, pathWorkerSid, pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildUpdateRequest(UpdateWorkerChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Taskrouter,
          "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/" + options.PathWorkerSid + "/Channels/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update WorkerChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of WorkerChannel </returns>
    public static WorkerChannelResource Update(UpdateWorkerChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="options"> Update WorkerChannel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of WorkerChannel </returns>
    public static async System.Threading.Tasks.Task<WorkerChannelResource> UpdateAsync(UpdateWorkerChannelOptions options,
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
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the WorkerChannel to update </param>
    /// <param name="pathWorkerSid"> The SID of the Worker with the WorkerChannel to update </param>
    /// <param name="pathSid"> The SID of the WorkerChannel to update </param>
    /// <param name="capacity"> The total number of Tasks that the Worker should handle for the TaskChannel type </param>
    /// <param name="available"> Whether the WorkerChannel is available </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of WorkerChannel </returns>
    public static WorkerChannelResource Update(string pathWorkspaceSid,
                                               string pathWorkerSid,
                                               string pathSid,
                                               int? capacity = null,
                                               bool? available = null,
                                               ITwilioRestClient client = null)
    {
      var options = new UpdateWorkerChannelOptions(pathWorkspaceSid, pathWorkerSid, pathSid) { Capacity = capacity, Available = available };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// update
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the WorkerChannel to update </param>
    /// <param name="pathWorkerSid"> The SID of the Worker with the WorkerChannel to update </param>
    /// <param name="pathSid"> The SID of the WorkerChannel to update </param>
    /// <param name="capacity"> The total number of Tasks that the Worker should handle for the TaskChannel type </param>
    /// <param name="available"> Whether the WorkerChannel is available </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of WorkerChannel </returns>
    public static async System.Threading.Tasks.Task<WorkerChannelResource> UpdateAsync(string pathWorkspaceSid,
                                                                                       string pathWorkerSid,
                                                                                       string pathSid,
                                                                                       int? capacity = null,
                                                                                       bool? available = null,
                                                                                       ITwilioRestClient client = null)
    {
      var options = new UpdateWorkerChannelOptions(pathWorkspaceSid, pathWorkerSid, pathSid) { Capacity = capacity, Available = available };
      return await UpdateAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a WorkerChannelResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> WorkerChannelResource object represented by the provided JSON </returns>
    public static WorkerChannelResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<WorkerChannelResource>(json);
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
    /// The total number of Tasks assigned to Worker for the TaskChannel type
    /// </summary>
    [JsonProperty("assigned_tasks")]
    public int? AssignedTasks { get; private set; }
    /// <summary>
    /// Whether the Worker should receive Tasks of the TaskChannel type
    /// </summary>
    [JsonProperty("available")]
    public bool? Available { get; private set; }
    /// <summary>
    /// The current available capacity between 0 to 100 for the TaskChannel
    /// </summary>
    [JsonProperty("available_capacity_percentage")]
    public int? AvailableCapacityPercentage { get; private set; }
    /// <summary>
    /// The current configured capacity for the WorkerChannel
    /// </summary>
    [JsonProperty("configured_capacity")]
    public int? ConfiguredCapacity { get; private set; }
    /// <summary>
    /// The RFC 2822 date and time in GMT when the resource was created
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The RFC 2822 date and time in GMT when the resource was last updated
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The SID of the TaskChannel
    /// </summary>
    [JsonProperty("task_channel_sid")]
    public string TaskChannelSid { get; private set; }
    /// <summary>
    /// The unique name of the TaskChannel, such as 'voice' or 'sms'
    /// </summary>
    [JsonProperty("task_channel_unique_name")]
    public string TaskChannelUniqueName { get; private set; }
    /// <summary>
    /// The SID of the Worker that contains the WorkerChannel
    /// </summary>
    [JsonProperty("worker_sid")]
    public string WorkerSid { get; private set; }
    /// <summary>
    /// The SID of the Workspace that contains the WorkerChannel
    /// </summary>
    [JsonProperty("workspace_sid")]
    public string WorkspaceSid { get; private set; }
    /// <summary>
    /// The absolute URL of the WorkerChannel resource
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }

    private WorkerChannelResource()
    {

    }
  }

}