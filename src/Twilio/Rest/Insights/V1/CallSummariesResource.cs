/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// CallSummariesResource
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

namespace Twilio.Rest.Insights.V1
{

  public class CallSummariesResource : Resource
  {
    public sealed class CallTypeEnum : StringEnum
    {
      private CallTypeEnum(string value) : base(value) { }
      public CallTypeEnum() { }
      public static implicit operator CallTypeEnum(string value)
      {
        return new CallTypeEnum(value);
      }

      public static readonly CallTypeEnum Carrier = new CallTypeEnum("carrier");
      public static readonly CallTypeEnum Sip = new CallTypeEnum("sip");
      public static readonly CallTypeEnum Trunking = new CallTypeEnum("trunking");
      public static readonly CallTypeEnum Client = new CallTypeEnum("client");
    }

    public sealed class CallStateEnum : StringEnum
    {
      private CallStateEnum(string value) : base(value) { }
      public CallStateEnum() { }
      public static implicit operator CallStateEnum(string value)
      {
        return new CallStateEnum(value);
      }

      public static readonly CallStateEnum Ringing = new CallStateEnum("ringing");
      public static readonly CallStateEnum Completed = new CallStateEnum("completed");
      public static readonly CallStateEnum Busy = new CallStateEnum("busy");
      public static readonly CallStateEnum Fail = new CallStateEnum("fail");
      public static readonly CallStateEnum Noanswer = new CallStateEnum("noanswer");
      public static readonly CallStateEnum Canceled = new CallStateEnum("canceled");
      public static readonly CallStateEnum Answered = new CallStateEnum("answered");
      public static readonly CallStateEnum Undialed = new CallStateEnum("undialed");
    }

    public sealed class ProcessingStateEnum : StringEnum
    {
      private ProcessingStateEnum(string value) : base(value) { }
      public ProcessingStateEnum() { }
      public static implicit operator ProcessingStateEnum(string value)
      {
        return new ProcessingStateEnum(value);
      }

      public static readonly ProcessingStateEnum Complete = new ProcessingStateEnum("complete");
      public static readonly ProcessingStateEnum Partial = new ProcessingStateEnum("partial");
    }

    public sealed class CallDirectionEnum : StringEnum
    {
      private CallDirectionEnum(string value) : base(value) { }
      public CallDirectionEnum() { }
      public static implicit operator CallDirectionEnum(string value)
      {
        return new CallDirectionEnum(value);
      }

      public static readonly CallDirectionEnum OutboundApi = new CallDirectionEnum("outbound_api");
      public static readonly CallDirectionEnum OutboundDial = new CallDirectionEnum("outbound_dial");
      public static readonly CallDirectionEnum Inbound = new CallDirectionEnum("inbound");
      public static readonly CallDirectionEnum TrunkingOriginating = new CallDirectionEnum("trunking_originating");
      public static readonly CallDirectionEnum TrunkingTerminating = new CallDirectionEnum("trunking_terminating");
    }

    public sealed class SortByEnum : StringEnum
    {
      private SortByEnum(string value) : base(value) { }
      public SortByEnum() { }
      public static implicit operator SortByEnum(string value)
      {
        return new SortByEnum(value);
      }

      public static readonly SortByEnum StartTime = new SortByEnum("start_time");
      public static readonly SortByEnum EndTime = new SortByEnum("end_time");
    }

    public sealed class ProcessingStateRequestEnum : StringEnum
    {
      private ProcessingStateRequestEnum(string value) : base(value) { }
      public ProcessingStateRequestEnum() { }
      public static implicit operator ProcessingStateRequestEnum(string value)
      {
        return new ProcessingStateRequestEnum(value);
      }

      public static readonly ProcessingStateRequestEnum Completed = new ProcessingStateRequestEnum("completed");
      public static readonly ProcessingStateRequestEnum Started = new ProcessingStateRequestEnum("started");
      public static readonly ProcessingStateRequestEnum Partial = new ProcessingStateRequestEnum("partial");
      public static readonly ProcessingStateRequestEnum All = new ProcessingStateRequestEnum("all");
    }

    private static Request BuildReadRequest(ReadCallSummariesOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Insights,
          "/v1/Voice/Summaries",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read CallSummaries parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CallSummaries </returns>
    public static ResourceSet<CallSummariesResource> Read(ReadCallSummariesOptions options,
                                                          ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<CallSummariesResource>.FromJson("call_summaries", response.Content);
      return new ResourceSet<CallSummariesResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read CallSummaries parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CallSummaries </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<CallSummariesResource>> ReadAsync(ReadCallSummariesOptions options,
                                                                                                  ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<CallSummariesResource>.FromJson("call_summaries", response.Content);
      return new ResourceSet<CallSummariesResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="from"> The from </param>
    /// <param name="to"> The to </param>
    /// <param name="fromCarrier"> The from_carrier </param>
    /// <param name="toCarrier"> The to_carrier </param>
    /// <param name="fromCountryCode"> The from_country_code </param>
    /// <param name="toCountryCode"> The to_country_code </param>
    /// <param name="branded"> The branded </param>
    /// <param name="verifiedCaller"> The verified_caller </param>
    /// <param name="hasTag"> The has_tag </param>
    /// <param name="startTime"> The start_time </param>
    /// <param name="endTime"> The end_time </param>
    /// <param name="callType"> The call_type </param>
    /// <param name="callState"> The call_state </param>
    /// <param name="direction"> The direction </param>
    /// <param name="processingState"> The processing_state </param>
    /// <param name="sortBy"> The sort_by </param>
    /// <param name="subaccount"> The subaccount </param>
    /// <param name="abnormalSession"> The abnormal_session </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of CallSummaries </returns>
    public static ResourceSet<CallSummariesResource> Read(string from = null,
                                                          string to = null,
                                                          string fromCarrier = null,
                                                          string toCarrier = null,
                                                          string fromCountryCode = null,
                                                          string toCountryCode = null,
                                                          bool? branded = null,
                                                          bool? verifiedCaller = null,
                                                          bool? hasTag = null,
                                                          string startTime = null,
                                                          string endTime = null,
                                                          string callType = null,
                                                          string callState = null,
                                                          string direction = null,
                                                          CallSummariesResource.ProcessingStateRequestEnum processingState = null,
                                                          CallSummariesResource.SortByEnum sortBy = null,
                                                          string subaccount = null,
                                                          bool? abnormalSession = null,
                                                          int? pageSize = null,
                                                          long? limit = null,
                                                          ITwilioRestClient client = null)
    {
      var options = new ReadCallSummariesOptions() { From = from, To = to, FromCarrier = fromCarrier, ToCarrier = toCarrier, FromCountryCode = fromCountryCode, ToCountryCode = toCountryCode, Branded = branded, VerifiedCaller = verifiedCaller, HasTag = hasTag, StartTime = startTime, EndTime = endTime, CallType = callType, CallState = callState, Direction = direction, ProcessingState = processingState, SortBy = sortBy, Subaccount = subaccount, AbnormalSession = abnormalSession, PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="from"> The from </param>
    /// <param name="to"> The to </param>
    /// <param name="fromCarrier"> The from_carrier </param>
    /// <param name="toCarrier"> The to_carrier </param>
    /// <param name="fromCountryCode"> The from_country_code </param>
    /// <param name="toCountryCode"> The to_country_code </param>
    /// <param name="branded"> The branded </param>
    /// <param name="verifiedCaller"> The verified_caller </param>
    /// <param name="hasTag"> The has_tag </param>
    /// <param name="startTime"> The start_time </param>
    /// <param name="endTime"> The end_time </param>
    /// <param name="callType"> The call_type </param>
    /// <param name="callState"> The call_state </param>
    /// <param name="direction"> The direction </param>
    /// <param name="processingState"> The processing_state </param>
    /// <param name="sortBy"> The sort_by </param>
    /// <param name="subaccount"> The subaccount </param>
    /// <param name="abnormalSession"> The abnormal_session </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of CallSummaries </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<CallSummariesResource>> ReadAsync(string from = null,
                                                                                                  string to = null,
                                                                                                  string fromCarrier = null,
                                                                                                  string toCarrier = null,
                                                                                                  string fromCountryCode = null,
                                                                                                  string toCountryCode = null,
                                                                                                  bool? branded = null,
                                                                                                  bool? verifiedCaller = null,
                                                                                                  bool? hasTag = null,
                                                                                                  string startTime = null,
                                                                                                  string endTime = null,
                                                                                                  string callType = null,
                                                                                                  string callState = null,
                                                                                                  string direction = null,
                                                                                                  CallSummariesResource.ProcessingStateRequestEnum processingState = null,
                                                                                                  CallSummariesResource.SortByEnum sortBy = null,
                                                                                                  string subaccount = null,
                                                                                                  bool? abnormalSession = null,
                                                                                                  int? pageSize = null,
                                                                                                  long? limit = null,
                                                                                                  ITwilioRestClient client = null)
    {
      var options = new ReadCallSummariesOptions() { From = from, To = to, FromCarrier = fromCarrier, ToCarrier = toCarrier, FromCountryCode = fromCountryCode, ToCountryCode = toCountryCode, Branded = branded, VerifiedCaller = verifiedCaller, HasTag = hasTag, StartTime = startTime, EndTime = endTime, CallType = callType, CallState = callState, Direction = direction, ProcessingState = processingState, SortBy = sortBy, Subaccount = subaccount, AbnormalSession = abnormalSession, PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<CallSummariesResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<CallSummariesResource>.FromJson("call_summaries", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<CallSummariesResource> NextPage(Page<CallSummariesResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Insights)
      );

      var response = client.Request(request);
      return Page<CallSummariesResource>.FromJson("call_summaries", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<CallSummariesResource> PreviousPage(Page<CallSummariesResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Insights)
      );

      var response = client.Request(request);
      return Page<CallSummariesResource>.FromJson("call_summaries", response.Content);
    }

    /// <summary>
    /// Converts a JSON string into a CallSummariesResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> CallSummariesResource object represented by the provided JSON </returns>
    public static CallSummariesResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<CallSummariesResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// The account_sid
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The call_sid
    /// </summary>
    [JsonProperty("call_sid")]
    public string CallSid { get; private set; }
    /// <summary>
    /// The call_type
    /// </summary>
    [JsonProperty("call_type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CallSummariesResource.CallTypeEnum CallType { get; private set; }
    /// <summary>
    /// The call_state
    /// </summary>
    [JsonProperty("call_state")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CallSummariesResource.CallStateEnum CallState { get; private set; }
    /// <summary>
    /// The processing_state
    /// </summary>
    [JsonProperty("processing_state")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CallSummariesResource.ProcessingStateEnum ProcessingState { get; private set; }
    /// <summary>
    /// The created_time
    /// </summary>
    [JsonProperty("created_time")]
    public DateTime? CreatedTime { get; private set; }
    /// <summary>
    /// The start_time
    /// </summary>
    [JsonProperty("start_time")]
    public DateTime? StartTime { get; private set; }
    /// <summary>
    /// The end_time
    /// </summary>
    [JsonProperty("end_time")]
    public DateTime? EndTime { get; private set; }
    /// <summary>
    /// The duration
    /// </summary>
    [JsonProperty("duration")]
    public int? Duration { get; private set; }
    /// <summary>
    /// The connect_duration
    /// </summary>
    [JsonProperty("connect_duration")]
    public int? ConnectDuration { get; private set; }
    /// <summary>
    /// The from
    /// </summary>
    [JsonProperty("from")]
    public object From { get; private set; }
    /// <summary>
    /// The to
    /// </summary>
    [JsonProperty("to")]
    public object To { get; private set; }
    /// <summary>
    /// The carrier_edge
    /// </summary>
    [JsonProperty("carrier_edge")]
    public object CarrierEdge { get; private set; }
    /// <summary>
    /// The client_edge
    /// </summary>
    [JsonProperty("client_edge")]
    public object ClientEdge { get; private set; }
    /// <summary>
    /// The sdk_edge
    /// </summary>
    [JsonProperty("sdk_edge")]
    public object SdkEdge { get; private set; }
    /// <summary>
    /// The sip_edge
    /// </summary>
    [JsonProperty("sip_edge")]
    public object SipEdge { get; private set; }
    /// <summary>
    /// The tags
    /// </summary>
    [JsonProperty("tags")]
    public List<string> Tags { get; private set; }
    /// <summary>
    /// The url
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The attributes
    /// </summary>
    [JsonProperty("attributes")]
    public object Attributes { get; private set; }
    /// <summary>
    /// The properties
    /// </summary>
    [JsonProperty("properties")]
    public object Properties { get; private set; }
    /// <summary>
    /// The trust
    /// </summary>
    [JsonProperty("trust")]
    public object Trust { get; private set; }

    private CallSummariesResource()
    {

    }
  }

}