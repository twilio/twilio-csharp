/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// ExecutionContextResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Studio.V1.Flow.Execution
{

  public class ExecutionContextResource : Resource
  {
    private static Request BuildFetchRequest(FetchExecutionContextOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Studio,
          "/v1/Flows/" + options.PathFlowSid + "/Executions/" + options.PathExecutionSid + "/Context",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Retrieve the most recent context for an Execution.
    /// </summary>
    /// <param name="options"> Fetch ExecutionContext parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of ExecutionContext </returns>
    public static ExecutionContextResource Fetch(FetchExecutionContextOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Retrieve the most recent context for an Execution.
    /// </summary>
    /// <param name="options"> Fetch ExecutionContext parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of ExecutionContext </returns>
    public static async System.Threading.Tasks.Task<ExecutionContextResource> FetchAsync(FetchExecutionContextOptions options,
                                                                                         ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Retrieve the most recent context for an Execution.
    /// </summary>
    /// <param name="pathFlowSid"> The SID of the Flow </param>
    /// <param name="pathExecutionSid"> The SID of the Execution </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of ExecutionContext </returns>
    public static ExecutionContextResource Fetch(string pathFlowSid,
                                                 string pathExecutionSid,
                                                 ITwilioRestClient client = null)
    {
      var options = new FetchExecutionContextOptions(pathFlowSid, pathExecutionSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve the most recent context for an Execution.
    /// </summary>
    /// <param name="pathFlowSid"> The SID of the Flow </param>
    /// <param name="pathExecutionSid"> The SID of the Execution </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of ExecutionContext </returns>
    public static async System.Threading.Tasks.Task<ExecutionContextResource> FetchAsync(string pathFlowSid,
                                                                                         string pathExecutionSid,
                                                                                         ITwilioRestClient client = null)
    {
      var options = new FetchExecutionContextOptions(pathFlowSid, pathExecutionSid);
      return await FetchAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a ExecutionContextResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> ExecutionContextResource object represented by the provided JSON </returns>
    public static ExecutionContextResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<ExecutionContextResource>(json);
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
    /// The current state of the flow
    /// </summary>
    [JsonProperty("context")]
    public object Context { get; private set; }
    /// <summary>
    /// The SID of the Flow
    /// </summary>
    [JsonProperty("flow_sid")]
    public string FlowSid { get; private set; }
    /// <summary>
    /// The SID of the Execution
    /// </summary>
    [JsonProperty("execution_sid")]
    public string ExecutionSid { get; private set; }
    /// <summary>
    /// The absolute URL of the resource
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }

    private ExecutionContextResource()
    {

    }
  }

}