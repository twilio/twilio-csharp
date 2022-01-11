/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// UsageRecordResource
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

namespace Twilio.Rest.Wireless.V1.Sim
{

  public class UsageRecordResource : Resource
  {
    public sealed class GranularityEnum : StringEnum
    {
      private GranularityEnum(string value) : base(value) { }
      public GranularityEnum() { }
      public static implicit operator GranularityEnum(string value)
      {
        return new GranularityEnum(value);
      }

      public static readonly GranularityEnum Hourly = new GranularityEnum("hourly");
      public static readonly GranularityEnum Daily = new GranularityEnum("daily");
      public static readonly GranularityEnum All = new GranularityEnum("all");
    }

    private static Request BuildReadRequest(ReadUsageRecordOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Wireless,
          "/v1/Sims/" + options.PathSimSid + "/UsageRecords",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read UsageRecord parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of UsageRecord </returns>
    public static ResourceSet<UsageRecordResource> Read(ReadUsageRecordOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<UsageRecordResource>.FromJson("usage_records", response.Content);
      return new ResourceSet<UsageRecordResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read UsageRecord parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of UsageRecord </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<UsageRecordResource>> ReadAsync(ReadUsageRecordOptions options,
                                                                                                ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<UsageRecordResource>.FromJson("usage_records", response.Content);
      return new ResourceSet<UsageRecordResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathSimSid"> The SID of the Sim resource to read the usage from </param>
    /// <param name="end"> Only include usage that occurred on or before this date </param>
    /// <param name="start"> Only include usage that has occurred on or after this date </param>
    /// <param name="granularity"> The time-based grouping that results are aggregated by </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of UsageRecord </returns>
    public static ResourceSet<UsageRecordResource> Read(string pathSimSid,
                                                        DateTime? end = null,
                                                        DateTime? start = null,
                                                        UsageRecordResource.GranularityEnum granularity = null,
                                                        int? pageSize = null,
                                                        long? limit = null,
                                                        ITwilioRestClient client = null)
    {
      var options = new ReadUsageRecordOptions(pathSimSid) { End = end, Start = start, Granularity = granularity, PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathSimSid"> The SID of the Sim resource to read the usage from </param>
    /// <param name="end"> Only include usage that occurred on or before this date </param>
    /// <param name="start"> Only include usage that has occurred on or after this date </param>
    /// <param name="granularity"> The time-based grouping that results are aggregated by </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of UsageRecord </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<UsageRecordResource>> ReadAsync(string pathSimSid,
                                                                                                DateTime? end = null,
                                                                                                DateTime? start = null,
                                                                                                UsageRecordResource.GranularityEnum granularity = null,
                                                                                                int? pageSize = null,
                                                                                                long? limit = null,
                                                                                                ITwilioRestClient client = null)
    {
      var options = new ReadUsageRecordOptions(pathSimSid) { End = end, Start = start, Granularity = granularity, PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<UsageRecordResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<UsageRecordResource>.FromJson("usage_records", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<UsageRecordResource> NextPage(Page<UsageRecordResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Wireless)
      );

      var response = client.Request(request);
      return Page<UsageRecordResource>.FromJson("usage_records", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<UsageRecordResource> PreviousPage(Page<UsageRecordResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Wireless)
      );

      var response = client.Request(request);
      return Page<UsageRecordResource>.FromJson("usage_records", response.Content);
    }

    /// <summary>
    /// Converts a JSON string into a UsageRecordResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> UsageRecordResource object represented by the provided JSON </returns>
    public static UsageRecordResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<UsageRecordResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// The SID of the Sim resource that this Usage Record is for
    /// </summary>
    [JsonProperty("sim_sid")]
    public string SimSid { get; private set; }
    /// <summary>
    /// The SID of the Account that created the resource
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The time period for which the usage is reported
    /// </summary>
    [JsonProperty("period")]
    public object Period { get; private set; }
    /// <summary>
    /// An object that describes the SIM's usage of Commands during the specified period
    /// </summary>
    [JsonProperty("commands")]
    public object Commands { get; private set; }
    /// <summary>
    /// An object that describes the SIM's data usage during the specified period
    /// </summary>
    [JsonProperty("data")]
    public object Data { get; private set; }

    private UsageRecordResource()
    {

    }
  }

}