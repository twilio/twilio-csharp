/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// ExportCustomJobResource
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

namespace Twilio.Rest.Bulkexports.V1.Export
{

  public class ExportCustomJobResource : Resource
  {
    public sealed class StatusEnum : StringEnum
    {
      private StatusEnum(string value) : base(value) { }
      public StatusEnum() { }
      public static implicit operator StatusEnum(string value)
      {
        return new StatusEnum(value);
      }

      public static readonly StatusEnum Errorduringrun = new StatusEnum("ErrorDuringRun");
      public static readonly StatusEnum Submitted = new StatusEnum("Submitted");
      public static readonly StatusEnum Running = new StatusEnum("Running");
      public static readonly StatusEnum Completedemptyrecords = new StatusEnum("CompletedEmptyRecords");
      public static readonly StatusEnum Completed = new StatusEnum("Completed");
      public static readonly StatusEnum Failed = new StatusEnum("Failed");
      public static readonly StatusEnum Runningtobedeleted = new StatusEnum("RunningToBeDeleted");
      public static readonly StatusEnum Deletedbyuserrequest = new StatusEnum("DeletedByUserRequest");
    }

    private static Request BuildReadRequest(ReadExportCustomJobOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Bulkexports,
          "/v1/Exports/" + options.PathResourceType + "/Jobs",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read ExportCustomJob parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of ExportCustomJob </returns>
    public static ResourceSet<ExportCustomJobResource> Read(ReadExportCustomJobOptions options,
                                                            ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
      return new ResourceSet<ExportCustomJobResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="options"> Read ExportCustomJob parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<ExportCustomJobResource>> ReadAsync(ReadExportCustomJobOptions options,
                                                                                                    ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
      return new ResourceSet<ExportCustomJobResource>(page, options, client);
    }
#endif

    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of ExportCustomJob </returns>
    public static ResourceSet<ExportCustomJobResource> Read(string pathResourceType,
                                                            int? pageSize = null,
                                                            long? limit = null,
                                                            ITwilioRestClient client = null)
    {
      var options = new ReadExportCustomJobOptions(pathResourceType) { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// read
    /// </summary>
    /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<ExportCustomJobResource>> ReadAsync(string pathResourceType,
                                                                                                    int? pageSize = null,
                                                                                                    long? limit = null,
                                                                                                    ITwilioRestClient client = null)
    {
      var options = new ReadExportCustomJobOptions(pathResourceType) { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<ExportCustomJobResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<ExportCustomJobResource> NextPage(Page<ExportCustomJobResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Bulkexports)
      );

      var response = client.Request(request);
      return Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<ExportCustomJobResource> PreviousPage(Page<ExportCustomJobResource> page,
                                                             ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Bulkexports)
      );

      var response = client.Request(request);
      return Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
    }

    private static Request BuildCreateRequest(CreateExportCustomJobOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Bulkexports,
          "/v1/Exports/" + options.PathResourceType + "/Jobs",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create ExportCustomJob parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of ExportCustomJob </returns>
    public static ExportCustomJobResource Create(CreateExportCustomJobOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="options"> Create ExportCustomJob parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
    public static async System.Threading.Tasks.Task<ExportCustomJobResource> CreateAsync(CreateExportCustomJobOptions options,
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
    /// <param name="pathResourceType"> The type of communication – Messages or Calls, Conferences, and Participants
    ///                        </param>
    /// <param name="startDay"> The start day for the custom export specified as a string in the format of yyyy-mm-dd
    ///                </param>
    /// <param name="endDay"> The end day for the custom export specified as a string in the format of yyyy-mm-dd. End day
    ///              is inclusive and must be 2 days earlier than the current UTC day. </param>
    /// <param name="friendlyName"> The friendly name specified when creating the job </param>
    /// <param name="webhookUrl"> The optional webhook url called on completion of the job. If this is supplied,
    ///                  `WebhookMethod` must also be supplied. </param>
    /// <param name="webhookMethod"> This is the method used to call the webhook on completion of the job. If this is
    ///                     supplied, `WebhookUrl` must also be supplied. </param>
    /// <param name="email"> The optional email to send the completion notification to </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of ExportCustomJob </returns>
    public static ExportCustomJobResource Create(string pathResourceType,
                                                 string startDay,
                                                 string endDay,
                                                 string friendlyName,
                                                 string webhookUrl = null,
                                                 string webhookMethod = null,
                                                 string email = null,
                                                 ITwilioRestClient client = null)
    {
      var options = new CreateExportCustomJobOptions(pathResourceType, startDay, endDay, friendlyName) { WebhookUrl = webhookUrl, WebhookMethod = webhookMethod, Email = email };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// create
    /// </summary>
    /// <param name="pathResourceType"> The type of communication – Messages or Calls, Conferences, and Participants
    ///                        </param>
    /// <param name="startDay"> The start day for the custom export specified as a string in the format of yyyy-mm-dd
    ///                </param>
    /// <param name="endDay"> The end day for the custom export specified as a string in the format of yyyy-mm-dd. End day
    ///              is inclusive and must be 2 days earlier than the current UTC day. </param>
    /// <param name="friendlyName"> The friendly name specified when creating the job </param>
    /// <param name="webhookUrl"> The optional webhook url called on completion of the job. If this is supplied,
    ///                  `WebhookMethod` must also be supplied. </param>
    /// <param name="webhookMethod"> This is the method used to call the webhook on completion of the job. If this is
    ///                     supplied, `WebhookUrl` must also be supplied. </param>
    /// <param name="email"> The optional email to send the completion notification to </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
    public static async System.Threading.Tasks.Task<ExportCustomJobResource> CreateAsync(string pathResourceType,
                                                                                         string startDay,
                                                                                         string endDay,
                                                                                         string friendlyName,
                                                                                         string webhookUrl = null,
                                                                                         string webhookMethod = null,
                                                                                         string email = null,
                                                                                         ITwilioRestClient client = null)
    {
      var options = new CreateExportCustomJobOptions(pathResourceType, startDay, endDay, friendlyName) { WebhookUrl = webhookUrl, WebhookMethod = webhookMethod, Email = email };
      return await CreateAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a ExportCustomJobResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> ExportCustomJobResource object represented by the provided JSON </returns>
    public static ExportCustomJobResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<ExportCustomJobResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// The friendly name specified when creating the job
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The type of communication – Messages, Calls, Conferences, and Participants
    /// </summary>
    [JsonProperty("resource_type")]
    public string ResourceType { get; private set; }
    /// <summary>
    /// The start day for the custom export specified as a string in the format of yyyy-MM-dd
    /// </summary>
    [JsonProperty("start_day")]
    public string StartDay { get; private set; }
    /// <summary>
    /// The end day for the custom export specified as a string in the format of yyyy-MM-dd. This will be the last day exported. For instance, to export a single day, choose the same day for start and end day. To export the first 4 days of July, you would set the start date to 2020-07-01 and the end date to 2020-07-04. The end date must be the UTC day before yesterday.
    /// </summary>
    [JsonProperty("end_day")]
    public string EndDay { get; private set; }
    /// <summary>
    /// The optional webhook url called on completion
    /// </summary>
    [JsonProperty("webhook_url")]
    public string WebhookUrl { get; private set; }
    /// <summary>
    /// This is the method used to call the webhook
    /// </summary>
    [JsonProperty("webhook_method")]
    public string WebhookMethod { get; private set; }
    /// <summary>
    /// The optional email to send the completion notification to
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; private set; }
    /// <summary>
    /// The unique job_sid returned when the custom export was created. This can be used to look up the status of the job.
    /// </summary>
    [JsonProperty("job_sid")]
    public string JobSid { get; private set; }
    /// <summary>
    /// The details of a job state which is an object that contains a `status` string, a day count integer, and list of days in the job
    /// </summary>
    [JsonProperty("details")]
    public object Details { get; private set; }
    /// <summary>
    /// This is the job position from the 1st in line. Your queue position will never increase. As jobs ahead of yours in the queue are processed, the queue position number will decrease
    /// </summary>
    [JsonProperty("job_queue_position")]
    public string JobQueuePosition { get; private set; }
    /// <summary>
    /// this is the time estimated until your job is complete. This is calculated each time you request the job list. The time is calculated based on the current rate of job completion (which may vary) and your job queue position
    /// </summary>
    [JsonProperty("estimated_completion_time")]
    public string EstimatedCompletionTime { get; private set; }

    private ExportCustomJobResource()
    {

    }
  }

}