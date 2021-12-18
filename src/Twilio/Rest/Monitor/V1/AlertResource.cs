/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// AlertResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Monitor.V1
{

  public class AlertResource : Resource
  {
    private static Request BuildFetchRequest(FetchAlertOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Monitor,
          "/v1/Alerts/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Alert parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Alert </returns>
    public static AlertResource Fetch(FetchAlertOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="options"> Fetch Alert parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Alert </returns>
    public static async System.Threading.Tasks.Task<AlertResource> FetchAsync(FetchAlertOptions options,
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
    /// <param name="pathSid"> The SID that identifies the resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Alert </returns>
    public static AlertResource Fetch(string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchAlertOptions(pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// fetch
    /// </summary>
    /// <param name="pathSid"> The SID that identifies the resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Alert </returns>
    public static async System.Threading.Tasks.Task<AlertResource> FetchAsync(string pathSid,
                                                                              ITwilioRestClient client = null)
    {
      var options = new FetchAlertOptions(pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadAlertOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Monitor,
          "/v1/Alerts",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Alert parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Alert </returns>
    public static ResourceSet<AlertResource> Read(ReadAlertOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<AlertResource>.FromJson("alerts", response.Content);
      return new ResourceSet<AlertResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read Alert parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Alert </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<AlertResource>> ReadAsync(ReadAlertOptions options,
                                                                                          ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<AlertResource>.FromJson("alerts", response.Content);
      return new ResourceSet<AlertResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="logLevel"> Only show alerts for this log-level </param>
    /// <param name="startDate"> Only include alerts that occurred on or after this date and time </param>
    /// <param name="endDate"> Only include alerts that occurred on or before this date and time </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Alert </returns>
    public static ResourceSet<AlertResource> Read(string logLevel = null,
                                                  DateTime? startDate = null,
                                                  DateTime? endDate = null,
                                                  int? pageSize = null,
                                                  long? limit = null,
                                                  ITwilioRestClient client = null)
    {
      var options = new ReadAlertOptions() { LogLevel = logLevel, StartDate = startDate, EndDate = endDate, PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="logLevel"> Only show alerts for this log-level </param>
    /// <param name="startDate"> Only include alerts that occurred on or after this date and time </param>
    /// <param name="endDate"> Only include alerts that occurred on or before this date and time </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Alert </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<AlertResource>> ReadAsync(string logLevel = null,
                                                                                          DateTime? startDate = null,
                                                                                          DateTime? endDate = null,
                                                                                          int? pageSize = null,
                                                                                          long? limit = null,
                                                                                          ITwilioRestClient client = null)
    {
      var options = new ReadAlertOptions() { LogLevel = logLevel, StartDate = startDate, EndDate = endDate, PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<AlertResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<AlertResource>.FromJson("alerts", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<AlertResource> NextPage(Page<AlertResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Monitor)
      );

      var response = client.Request(request);
      return Page<AlertResource>.FromJson("alerts", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<AlertResource> PreviousPage(Page<AlertResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Monitor)
      );

      var response = client.Request(request);
      return Page<AlertResource>.FromJson("alerts", response.Content);
    }

    /// <summary>
    /// Converts a JSON string into a AlertResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> AlertResource object represented by the provided JSON </returns>
    public static AlertResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<AlertResource>(json);
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
    /// The text of the alert
    /// </summary>
    [JsonProperty("alert_text")]
    public string AlertText { get; private set; }
    /// <summary>
    /// The API version used when the alert was generated
    /// </summary>
    [JsonProperty("api_version")]
    public string ApiVersion { get; private set; }
    /// <summary>
    /// The ISO 8601 date and time in GMT when the resource was created
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The date and time when the alert was generated specified in ISO 8601 format
    /// </summary>
    [JsonProperty("date_generated")]
    public DateTime? DateGenerated { get; private set; }
    /// <summary>
    /// The ISO 8601 date and time in GMT when the resource was last updated
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The error code for the condition that generated the alert
    /// </summary>
    [JsonProperty("error_code")]
    public string ErrorCode { get; private set; }
    /// <summary>
    /// The log level
    /// </summary>
    [JsonProperty("log_level")]
    public string LogLevel { get; private set; }
    /// <summary>
    /// The URL of the page in our Error Dictionary with more information about the error condition
    /// </summary>
    [JsonProperty("more_info")]
    public string MoreInfo { get; private set; }
    /// <summary>
    /// The method used by the request that generated the alert
    /// </summary>
    [JsonProperty("request_method")]
    [JsonConverter(typeof(HttpMethodConverter))]
    public Twilio.Http.HttpMethod RequestMethod { get; private set; }
    /// <summary>
    /// The URL of the request that generated the alert
    /// </summary>
    [JsonProperty("request_url")]
    public string RequestUrl { get; private set; }
    /// <summary>
    /// The variables passed in the request that generated the alert
    /// </summary>
    [JsonProperty("request_variables")]
    public string RequestVariables { get; private set; }
    /// <summary>
    /// The SID of the resource for which the alert was generated
    /// </summary>
    [JsonProperty("resource_sid")]
    public string ResourceSid { get; private set; }
    /// <summary>
    /// The response body of the request that generated the alert
    /// </summary>
    [JsonProperty("response_body")]
    public string ResponseBody { get; private set; }
    /// <summary>
    /// The response headers of the request that generated the alert
    /// </summary>
    [JsonProperty("response_headers")]
    public string ResponseHeaders { get; private set; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The absolute URL of the Alert resource
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// The request headers of the request that generated the alert
    /// </summary>
    [JsonProperty("request_headers")]
    public string RequestHeaders { get; private set; }
    /// <summary>
    /// The SID of the service or resource that generated the alert
    /// </summary>
    [JsonProperty("service_sid")]
    public string ServiceSid { get; private set; }

    private AlertResource()
    {

    }
  }

}