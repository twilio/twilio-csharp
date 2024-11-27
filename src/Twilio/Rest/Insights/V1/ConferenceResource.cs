/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Insights
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;


namespace Twilio.Rest.Insights.V1
{
    public class ConferenceResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class RegionEnum : StringEnum
        {
            private RegionEnum(string value) : base(value) {}
            public RegionEnum() {}
            public static implicit operator RegionEnum(string value)
            {
                return new RegionEnum(value);
            }
            public static readonly RegionEnum Us1 = new RegionEnum("us1");
            public static readonly RegionEnum Au1 = new RegionEnum("au1");
            public static readonly RegionEnum Br1 = new RegionEnum("br1");
            public static readonly RegionEnum Ie1 = new RegionEnum("ie1");
            public static readonly RegionEnum Jp1 = new RegionEnum("jp1");
            public static readonly RegionEnum Sg1 = new RegionEnum("sg1");
            public static readonly RegionEnum De1 = new RegionEnum("de1");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ConferenceEndReasonEnum : StringEnum
        {
            private ConferenceEndReasonEnum(string value) : base(value) {}
            public ConferenceEndReasonEnum() {}
            public static implicit operator ConferenceEndReasonEnum(string value)
            {
                return new ConferenceEndReasonEnum(value);
            }
            public static readonly ConferenceEndReasonEnum LastParticipantLeft = new ConferenceEndReasonEnum("last_participant_left");
            public static readonly ConferenceEndReasonEnum ConferenceEndedViaApi = new ConferenceEndReasonEnum("conference_ended_via_api");
            public static readonly ConferenceEndReasonEnum ParticipantWithEndConferenceOnExitLeft = new ConferenceEndReasonEnum("participant_with_end_conference_on_exit_left");
            public static readonly ConferenceEndReasonEnum LastParticipantKicked = new ConferenceEndReasonEnum("last_participant_kicked");
            public static readonly ConferenceEndReasonEnum ParticipantWithEndConferenceOnExitKicked = new ConferenceEndReasonEnum("participant_with_end_conference_on_exit_kicked");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class TagEnum : StringEnum
        {
            private TagEnum(string value) : base(value) {}
            public TagEnum() {}
            public static implicit operator TagEnum(string value)
            {
                return new TagEnum(value);
            }

            public static readonly TagEnum InvalidRequestedRegion = new TagEnum("invalid_requested_region");
            public static readonly TagEnum DuplicateIdentity = new TagEnum("duplicate_identity");
            public static readonly TagEnum StartFailure = new TagEnum("start_failure");
            public static readonly TagEnum RegionConfigurationIssues = new TagEnum("region_configuration_issues");
            public static readonly TagEnum QualityWarnings = new TagEnum("quality_warnings");
            public static readonly TagEnum ParticipantBehaviorIssues = new TagEnum("participant_behavior_issues");
            public static readonly TagEnum HighPacketLoss = new TagEnum("high_packet_loss");
            public static readonly TagEnum HighJitter = new TagEnum("high_jitter");
            public static readonly TagEnum HighLatency = new TagEnum("high_latency");
            public static readonly TagEnum LowMos = new TagEnum("low_mos");
            public static readonly TagEnum DetectedSilence = new TagEnum("detected_silence");
            public static readonly TagEnum NoConcurrentParticipants = new TagEnum("no_concurrent_participants");
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ConferenceStatusEnum : StringEnum
        {
            private ConferenceStatusEnum(string value) : base(value) {}
            public ConferenceStatusEnum() {}
            public static implicit operator ConferenceStatusEnum(string value)
            {
                return new ConferenceStatusEnum(value);
            }
            public static readonly ConferenceStatusEnum InProgress = new ConferenceStatusEnum("in_progress");
            public static readonly ConferenceStatusEnum NotStarted = new ConferenceStatusEnum("not_started");
            public static readonly ConferenceStatusEnum Completed = new ConferenceStatusEnum("completed");
            public static readonly ConferenceStatusEnum SummaryTimeout = new ConferenceStatusEnum("summary_timeout");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ProcessingStateEnum : StringEnum
        {
            private ProcessingStateEnum(string value) : base(value) {}
            public ProcessingStateEnum() {}
            public static implicit operator ProcessingStateEnum(string value)
            {
                return new ProcessingStateEnum(value);
            }
            public static readonly ProcessingStateEnum Complete = new ProcessingStateEnum("complete");
            public static readonly ProcessingStateEnum InProgress = new ProcessingStateEnum("in_progress");
            public static readonly ProcessingStateEnum Timeout = new ProcessingStateEnum("timeout");

        }

        
        private static Request BuildFetchRequest(FetchConferenceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conferences/{ConferenceSid}";

            string PathConferenceSid = options.PathConferenceSid;
            path = path.Replace("{"+"ConferenceSid"+"}", PathConferenceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Insights,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Get a specific Conference Summary. </summary>
        /// <param name="options"> Fetch Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ConferenceResource Fetch(FetchConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Get a specific Conference Summary. </summary>
        /// <param name="options"> Fetch Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ConferenceResource> FetchAsync(FetchConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Get a specific Conference Summary. </summary>
        /// <param name="pathConferenceSid"> The unique SID identifier of the Conference. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ConferenceResource Fetch(
                                         string pathConferenceSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchConferenceOptions(pathConferenceSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Get a specific Conference Summary. </summary>
        /// <param name="pathConferenceSid"> The unique SID identifier of the Conference. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ConferenceResource> FetchAsync(string pathConferenceSid, ITwilioRestClient client = null)
        {
            var options = new FetchConferenceOptions(pathConferenceSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadConferenceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conferences";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Insights,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Get a list of Conference Summaries. </summary>
        /// <param name="options"> Read Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ResourceSet<ConferenceResource> Read(ReadConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ConferenceResource>.FromJson("conferences", response.Content);
            return new ResourceSet<ConferenceResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Get a list of Conference Summaries. </summary>
        /// <param name="options"> Read Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConferenceResource>> ReadAsync(ReadConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ConferenceResource>.FromJson("conferences", response.Content);
            return new ResourceSet<ConferenceResource>(page, options, client);
        }
        #endif
        /// <summary> Get a list of Conference Summaries. </summary>
        /// <param name="conferenceSid"> The SID of the conference. </param>
        /// <param name="friendlyName"> Custom label for the conference resource, up to 64 characters. </param>
        /// <param name="status"> Conference status. </param>
        /// <param name="createdAfter"> Conferences created after the provided timestamp specified in ISO 8601 format </param>
        /// <param name="createdBefore"> Conferences created before the provided timestamp specified in ISO 8601 format. </param>
        /// <param name="mixerRegion"> Twilio region where the conference media was mixed. </param>
        /// <param name="tags"> Tags applied by Twilio for common potential configuration, quality, or performance issues. </param>
        /// <param name="subaccount"> Account SID for the subaccount whose resources you wish to retrieve. </param>
        /// <param name="detectedIssues"> Potential configuration, behavior, or performance issues detected during the conference. </param>
        /// <param name="endReason"> Conference end reason; e.g. last participant left, modified by API, etc. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ResourceSet<ConferenceResource> Read(
                                                     string conferenceSid = null,
                                                     string friendlyName = null,
                                                     string status = null,
                                                     string createdAfter = null,
                                                     string createdBefore = null,
                                                     string mixerRegion = null,
                                                     string tags = null,
                                                     string subaccount = null,
                                                     string detectedIssues = null,
                                                     string endReason = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadConferenceOptions(){ ConferenceSid = conferenceSid, FriendlyName = friendlyName, Status = status, CreatedAfter = createdAfter, CreatedBefore = createdBefore, MixerRegion = mixerRegion, Tags = tags, Subaccount = subaccount, DetectedIssues = detectedIssues, EndReason = endReason, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Get a list of Conference Summaries. </summary>
        /// <param name="conferenceSid"> The SID of the conference. </param>
        /// <param name="friendlyName"> Custom label for the conference resource, up to 64 characters. </param>
        /// <param name="status"> Conference status. </param>
        /// <param name="createdAfter"> Conferences created after the provided timestamp specified in ISO 8601 format </param>
        /// <param name="createdBefore"> Conferences created before the provided timestamp specified in ISO 8601 format. </param>
        /// <param name="mixerRegion"> Twilio region where the conference media was mixed. </param>
        /// <param name="tags"> Tags applied by Twilio for common potential configuration, quality, or performance issues. </param>
        /// <param name="subaccount"> Account SID for the subaccount whose resources you wish to retrieve. </param>
        /// <param name="detectedIssues"> Potential configuration, behavior, or performance issues detected during the conference. </param>
        /// <param name="endReason"> Conference end reason; e.g. last participant left, modified by API, etc. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConferenceResource>> ReadAsync(
                                                                                             string conferenceSid = null,
                                                                                             string friendlyName = null,
                                                                                             string status = null,
                                                                                             string createdAfter = null,
                                                                                             string createdBefore = null,
                                                                                             string mixerRegion = null,
                                                                                             string tags = null,
                                                                                             string subaccount = null,
                                                                                             string detectedIssues = null,
                                                                                             string endReason = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadConferenceOptions(){ ConferenceSid = conferenceSid, FriendlyName = friendlyName, Status = status, CreatedAfter = createdAfter, CreatedBefore = createdBefore, MixerRegion = mixerRegion, Tags = tags, Subaccount = subaccount, DetectedIssues = detectedIssues, EndReason = endReason, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ConferenceResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ConferenceResource> NextPage(Page<ConferenceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ConferenceResource> PreviousPage(Page<ConferenceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a ConferenceResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConferenceResource object represented by the provided JSON </returns>
        public static ConferenceResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ConferenceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The unique SID identifier of the Conference. </summary> 
        [JsonProperty("conference_sid")]
        public string ConferenceSid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Custom label for the conference resource, up to 64 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> Conference creation date and time in ISO 8601 format. </summary> 
        [JsonProperty("create_time")]
        public DateTime? CreateTime { get; private set; }

        ///<summary> Timestamp in ISO 8601 format when the conference started. Conferences do not start until at least two participants join, at least one of whom has startConferenceOnEnter=true. </summary> 
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; private set; }

        ///<summary> Conference end date and time in ISO 8601 format. </summary> 
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }

        ///<summary> Conference duration in seconds. </summary> 
        [JsonProperty("duration_seconds")]
        public int? DurationSeconds { get; private set; }

        ///<summary> Duration of the between conference start event and conference end event in seconds. </summary> 
        [JsonProperty("connect_duration_seconds")]
        public int? ConnectDurationSeconds { get; private set; }

        
        [JsonProperty("status")]
        public ConferenceResource.ConferenceStatusEnum Status { get; private set; }

        ///<summary> Maximum number of concurrent participants as specified by the configuration. </summary> 
        [JsonProperty("max_participants")]
        public int? MaxParticipants { get; private set; }

        ///<summary> Actual maximum number of concurrent participants in the conference. </summary> 
        [JsonProperty("max_concurrent_participants")]
        public int? MaxConcurrentParticipants { get; private set; }

        ///<summary> Unique conference participants based on caller ID. </summary> 
        [JsonProperty("unique_participants")]
        public int? UniqueParticipants { get; private set; }

        
        [JsonProperty("end_reason")]
        public ConferenceResource.ConferenceEndReasonEnum EndReason { get; private set; }

        ///<summary> Call SID of the participant whose actions ended the conference. </summary> 
        [JsonProperty("ended_by")]
        public string EndedBy { get; private set; }

        
        [JsonProperty("mixer_region")]
        public ConferenceResource.RegionEnum MixerRegion { get; private set; }

        
        [JsonProperty("mixer_region_requested")]
        public ConferenceResource.RegionEnum MixerRegionRequested { get; private set; }

        ///<summary> Boolean. Indicates whether recording was enabled at the conference mixer. </summary> 
        [JsonProperty("recording_enabled")]
        public bool? RecordingEnabled { get; private set; }

        ///<summary> Potential issues detected by Twilio during the conference. </summary> 
        [JsonProperty("detected_issues")]
        public object DetectedIssues { get; private set; }

        ///<summary> Tags for detected conference conditions and participant behaviors which may be of interest. </summary> 
        [JsonProperty("tags")]
        public List<ConferenceResource.TagEnum> Tags { get; private set; }

        ///<summary> Object. Contains details about conference tags including severity. </summary> 
        [JsonProperty("tag_info")]
        public object TagInfo { get; private set; }

        
        [JsonProperty("processing_state")]
        public ConferenceResource.ProcessingStateEnum ProcessingState { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains a dictionary of URL links to nested resources of this Conference. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ConferenceResource() {

        }
    }
}

