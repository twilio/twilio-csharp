/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// RecordingResource
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

namespace Twilio.Rest.Api.V2010.Account.Conference
{

  public class RecordingResource : Resource
  {
    public sealed class StatusEnum : StringEnum
    {
      private StatusEnum(string value) : base(value) { }
      public StatusEnum() { }
      public static implicit operator StatusEnum(string value)
      {
        return new StatusEnum(value);
      }

      public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
      public static readonly StatusEnum Paused = new StatusEnum("paused");
      public static readonly StatusEnum Stopped = new StatusEnum("stopped");
      public static readonly StatusEnum Processing = new StatusEnum("processing");
      public static readonly StatusEnum Completed = new StatusEnum("completed");
      public static readonly StatusEnum Absent = new StatusEnum("absent");
    }

    public sealed class SourceEnum : StringEnum
    {
      private SourceEnum(string value) : base(value) { }
      public SourceEnum() { }
      public static implicit operator SourceEnum(string value)
      {
        return new SourceEnum(value);
      }

      public static readonly SourceEnum Dialverb = new SourceEnum("DialVerb");
      public static readonly SourceEnum Conference = new SourceEnum("Conference");
      public static readonly SourceEnum Outboundapi = new SourceEnum("OutboundAPI");
      public static readonly SourceEnum Trunking = new SourceEnum("Trunking");
      public static readonly SourceEnum Recordverb = new SourceEnum("RecordVerb");
      public static readonly SourceEnum Startcallrecordingapi = new SourceEnum("StartCallRecordingAPI");
      public static readonly SourceEnum Startconferencerecordingapi = new SourceEnum("StartConferenceRecordingAPI");
    }

    private static Request BuildUpdateRequest(UpdateRecordingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Conferences/" + options.PathConferenceSid + "/Recordings/" + options.PathSid + ".json",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Changes the status of the recording to paused, stopped, or in-progress. Note: To use `Twilio.CURRENT`, pass it as
    /// recording sid.
    /// </summary>
    /// <param name="options"> Update Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static RecordingResource Update(UpdateRecordingOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Changes the status of the recording to paused, stopped, or in-progress. Note: To use `Twilio.CURRENT`, pass it as
    /// recording sid.
    /// </summary>
    /// <param name="options"> Update Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<RecordingResource> UpdateAsync(UpdateRecordingOptions options,
                                                                                   ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Changes the status of the recording to paused, stopped, or in-progress. Note: To use `Twilio.CURRENT`, pass it as
    /// recording sid.
    /// </summary>
    /// <param name="pathConferenceSid"> Update by unique Conference SID for the recording </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="status"> The new status of the recording </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resource to update </param>
    /// <param name="pauseBehavior"> Whether to record during a pause </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static RecordingResource Update(string pathConferenceSid,
                                           string pathSid,
                                           RecordingResource.StatusEnum status,
                                           string pathAccountSid = null,
                                           string pauseBehavior = null,
                                           ITwilioRestClient client = null)
    {
      var options = new UpdateRecordingOptions(pathConferenceSid, pathSid, status) { PathAccountSid = pathAccountSid, PauseBehavior = pauseBehavior };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// Changes the status of the recording to paused, stopped, or in-progress. Note: To use `Twilio.CURRENT`, pass it as
    /// recording sid.
    /// </summary>
    /// <param name="pathConferenceSid"> Update by unique Conference SID for the recording </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="status"> The new status of the recording </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resource to update </param>
    /// <param name="pauseBehavior"> Whether to record during a pause </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<RecordingResource> UpdateAsync(string pathConferenceSid,
                                                                                   string pathSid,
                                                                                   RecordingResource.StatusEnum status,
                                                                                   string pathAccountSid = null,
                                                                                   string pauseBehavior = null,
                                                                                   ITwilioRestClient client = null)
    {
      var options = new UpdateRecordingOptions(pathConferenceSid, pathSid, status) { PathAccountSid = pathAccountSid, PauseBehavior = pauseBehavior };
      return await UpdateAsync(options, client);
    }
#endif

    private static Request BuildFetchRequest(FetchRecordingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Conferences/" + options.PathConferenceSid + "/Recordings/" + options.PathSid + ".json",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Fetch an instance of a recording for a call
    /// </summary>
    /// <param name="options"> Fetch Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static RecordingResource Fetch(FetchRecordingOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Fetch an instance of a recording for a call
    /// </summary>
    /// <param name="options"> Fetch Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<RecordingResource> FetchAsync(FetchRecordingOptions options,
                                                                                  ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Fetch an instance of a recording for a call
    /// </summary>
    /// <param name="pathConferenceSid"> Fetch by unique Conference SID for the recording </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static RecordingResource Fetch(string pathConferenceSid,
                                          string pathSid,
                                          string pathAccountSid = null,
                                          ITwilioRestClient client = null)
    {
      var options = new FetchRecordingOptions(pathConferenceSid, pathSid) { PathAccountSid = pathAccountSid };
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// Fetch an instance of a recording for a call
    /// </summary>
    /// <param name="pathConferenceSid"> Fetch by unique Conference SID for the recording </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<RecordingResource> FetchAsync(string pathConferenceSid,
                                                                                  string pathSid,
                                                                                  string pathAccountSid = null,
                                                                                  ITwilioRestClient client = null)
    {
      var options = new FetchRecordingOptions(pathConferenceSid, pathSid) { PathAccountSid = pathAccountSid };
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteRecordingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Conferences/" + options.PathConferenceSid + "/Recordings/" + options.PathSid + ".json",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Delete a recording from your account
    /// </summary>
    /// <param name="options"> Delete Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static bool Delete(DeleteRecordingOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// Delete a recording from your account
    /// </summary>
    /// <param name="options"> Delete Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRecordingOptions options,
                                                                      ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }
#endif

    /// <summary>
    /// Delete a recording from your account
    /// </summary>
    /// <param name="pathConferenceSid"> Delete by the recording's conference SID </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resources to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static bool Delete(string pathConferenceSid,
                              string pathSid,
                              string pathAccountSid = null,
                              ITwilioRestClient client = null)
    {
      var options = new DeleteRecordingOptions(pathConferenceSid, pathSid) { PathAccountSid = pathAccountSid };
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// Delete a recording from your account
    /// </summary>
    /// <param name="pathConferenceSid"> Delete by the recording's conference SID </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resources to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathConferenceSid,
                                                                      string pathSid,
                                                                      string pathAccountSid = null,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeleteRecordingOptions(pathConferenceSid, pathSid) { PathAccountSid = pathAccountSid };
      return await DeleteAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadRecordingOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Api,
          "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Conferences/" + options.PathConferenceSid + "/Recordings.json",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Retrieve a list of recordings belonging to the call used to make the request
    /// </summary>
    /// <param name="options"> Read Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static ResourceSet<RecordingResource> Read(ReadRecordingOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<RecordingResource>.FromJson("recordings", response.Content);
      return new ResourceSet<RecordingResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of recordings belonging to the call used to make the request
    /// </summary>
    /// <param name="options"> Read Recording parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<RecordingResource>> ReadAsync(ReadRecordingOptions options,
                                                                                              ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<RecordingResource>.FromJson("recordings", response.Content);
      return new ResourceSet<RecordingResource>(page, options, client);
    }
#endif

    /// <summary>
    /// Retrieve a list of recordings belonging to the call used to make the request
    /// </summary>
    /// <param name="pathConferenceSid"> Read by unique Conference SID for the recording </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resources to read </param>
    /// <param name="dateCreatedBefore"> The `YYYY-MM-DD` value of the resources to read </param>
    /// <param name="dateCreated"> The `YYYY-MM-DD` value of the resources to read </param>
    /// <param name="dateCreatedAfter"> The `YYYY-MM-DD` value of the resources to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Recording </returns>
    public static ResourceSet<RecordingResource> Read(string pathConferenceSid,
                                                      string pathAccountSid = null,
                                                      DateTime? dateCreatedBefore = null,
                                                      DateTime? dateCreated = null,
                                                      DateTime? dateCreatedAfter = null,
                                                      int? pageSize = null,
                                                      long? limit = null,
                                                      ITwilioRestClient client = null)
    {
      var options = new ReadRecordingOptions(pathConferenceSid) { PathAccountSid = pathAccountSid, DateCreatedBefore = dateCreatedBefore, DateCreated = dateCreated, DateCreatedAfter = dateCreatedAfter, PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of recordings belonging to the call used to make the request
    /// </summary>
    /// <param name="pathConferenceSid"> Read by unique Conference SID for the recording </param>
    /// <param name="pathAccountSid"> The SID of the Account that created the resources to read </param>
    /// <param name="dateCreatedBefore"> The `YYYY-MM-DD` value of the resources to read </param>
    /// <param name="dateCreated"> The `YYYY-MM-DD` value of the resources to read </param>
    /// <param name="dateCreatedAfter"> The `YYYY-MM-DD` value of the resources to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Recording </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<RecordingResource>> ReadAsync(string pathConferenceSid,
                                                                                              string pathAccountSid = null,
                                                                                              DateTime? dateCreatedBefore = null,
                                                                                              DateTime? dateCreated = null,
                                                                                              DateTime? dateCreatedAfter = null,
                                                                                              int? pageSize = null,
                                                                                              long? limit = null,
                                                                                              ITwilioRestClient client = null)
    {
      var options = new ReadRecordingOptions(pathConferenceSid) { PathAccountSid = pathAccountSid, DateCreatedBefore = dateCreatedBefore, DateCreated = dateCreated, DateCreatedAfter = dateCreatedAfter, PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<RecordingResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<RecordingResource>.FromJson("recordings", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<RecordingResource> NextPage(Page<RecordingResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Api)
      );

      var response = client.Request(request);
      return Page<RecordingResource>.FromJson("recordings", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<RecordingResource> PreviousPage(Page<RecordingResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Api)
      );

      var response = client.Request(request);
      return Page<RecordingResource>.FromJson("recordings", response.Content);
    }

    /// <summary>
    /// Converts a JSON string into a RecordingResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> RecordingResource object represented by the provided JSON </returns>
    public static RecordingResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<RecordingResource>(json);
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
    /// The API version used to create the recording
    /// </summary>
    [JsonProperty("api_version")]
    public string ApiVersion { get; private set; }
    /// <summary>
    /// The SID of the Call the resource is associated with
    /// </summary>
    [JsonProperty("call_sid")]
    public string CallSid { get; private set; }
    /// <summary>
    /// The Conference SID that identifies the conference associated with the recording
    /// </summary>
    [JsonProperty("conference_sid")]
    public string ConferenceSid { get; private set; }
    /// <summary>
    /// The RFC 2822 date and time in GMT that the resource was created
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The RFC 2822 date and time in GMT that the resource was last updated
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The start time of the recording, given in RFC 2822 format
    /// </summary>
    [JsonProperty("start_time")]
    public DateTime? StartTime { get; private set; }
    /// <summary>
    /// The length of the recording in seconds
    /// </summary>
    [JsonProperty("duration")]
    public string Duration { get; private set; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The one-time cost of creating the recording.
    /// </summary>
    [JsonProperty("price")]
    public string Price { get; private set; }
    /// <summary>
    /// The currency used in the price property.
    /// </summary>
    [JsonProperty("price_unit")]
    public string PriceUnit { get; private set; }
    /// <summary>
    /// The status of the recording
    /// </summary>
    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public RecordingResource.StatusEnum Status { get; private set; }
    /// <summary>
    /// The number of channels in the final recording file as an integer
    /// </summary>
    [JsonProperty("channels")]
    public int? Channels { get; private set; }
    /// <summary>
    /// How the recording was created
    /// </summary>
    [JsonProperty("source")]
    [JsonConverter(typeof(StringEnumConverter))]
    public RecordingResource.SourceEnum Source { get; private set; }
    /// <summary>
    /// More information about why the recording is missing, if status is `absent`.
    /// </summary>
    [JsonProperty("error_code")]
    public int? ErrorCode { get; private set; }
    /// <summary>
    /// How to decrypt the recording.
    /// </summary>
    [JsonProperty("encryption_details")]
    public object EncryptionDetails { get; private set; }
    /// <summary>
    /// The URI of the resource, relative to `https://api.twilio.com`
    /// </summary>
    [JsonProperty("uri")]
    public string Uri { get; private set; }

    private RecordingResource()
    {

    }
  }

}