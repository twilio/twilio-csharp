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
    public class RoomResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class TwilioRealmEnum : StringEnum
        {
            private TwilioRealmEnum(string value) : base(value) {}
            public TwilioRealmEnum() {}
            public static implicit operator TwilioRealmEnum(string value)
            {
                return new TwilioRealmEnum(value);
            }
            public static readonly TwilioRealmEnum Us1 = new TwilioRealmEnum("us1");
            public static readonly TwilioRealmEnum Us2 = new TwilioRealmEnum("us2");
            public static readonly TwilioRealmEnum Au1 = new TwilioRealmEnum("au1");
            public static readonly TwilioRealmEnum Br1 = new TwilioRealmEnum("br1");
            public static readonly TwilioRealmEnum Ie1 = new TwilioRealmEnum("ie1");
            public static readonly TwilioRealmEnum Jp1 = new TwilioRealmEnum("jp1");
            public static readonly TwilioRealmEnum Sg1 = new TwilioRealmEnum("sg1");
            public static readonly TwilioRealmEnum In1 = new TwilioRealmEnum("in1");
            public static readonly TwilioRealmEnum De1 = new TwilioRealmEnum("de1");
            public static readonly TwilioRealmEnum Gll = new TwilioRealmEnum("gll");
            public static readonly TwilioRealmEnum StageUs1 = new TwilioRealmEnum("stage_us1");
            public static readonly TwilioRealmEnum DevUs1 = new TwilioRealmEnum("dev_us1");

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

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class CreatedMethodEnum : StringEnum
        {
            private CreatedMethodEnum(string value) : base(value) {}
            public CreatedMethodEnum() {}
            public static implicit operator CreatedMethodEnum(string value)
            {
                return new CreatedMethodEnum(value);
            }
            public static readonly CreatedMethodEnum Sdk = new CreatedMethodEnum("sdk");
            public static readonly CreatedMethodEnum AdHoc = new CreatedMethodEnum("ad_hoc");
            public static readonly CreatedMethodEnum Api = new CreatedMethodEnum("api");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class RoomTypeEnum : StringEnum
        {
            private RoomTypeEnum(string value) : base(value) {}
            public RoomTypeEnum() {}
            public static implicit operator RoomTypeEnum(string value)
            {
                return new RoomTypeEnum(value);
            }
            public static readonly RoomTypeEnum Go = new RoomTypeEnum("go");
            public static readonly RoomTypeEnum PeerToPeer = new RoomTypeEnum("peer_to_peer");
            public static readonly RoomTypeEnum Group = new RoomTypeEnum("group");
            public static readonly RoomTypeEnum GroupSmall = new RoomTypeEnum("group_small");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class EndReasonEnum : StringEnum
        {
            private EndReasonEnum(string value) : base(value) {}
            public EndReasonEnum() {}
            public static implicit operator EndReasonEnum(string value)
            {
                return new EndReasonEnum(value);
            }
            public static readonly EndReasonEnum RoomEndedViaApi = new EndReasonEnum("room_ended_via_api");
            public static readonly EndReasonEnum Timeout = new EndReasonEnum("timeout");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class RoomStatusEnum : StringEnum
        {
            private RoomStatusEnum(string value) : base(value) {}
            public RoomStatusEnum() {}
            public static implicit operator RoomStatusEnum(string value)
            {
                return new RoomStatusEnum(value);
            }
            public static readonly RoomStatusEnum InProgress = new RoomStatusEnum("in_progress");
            public static readonly RoomStatusEnum Completed = new RoomStatusEnum("completed");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class EdgeLocationEnum : StringEnum
        {
            private EdgeLocationEnum(string value) : base(value) {}
            public EdgeLocationEnum() {}
            public static implicit operator EdgeLocationEnum(string value)
            {
                return new EdgeLocationEnum(value);
            }
            public static readonly EdgeLocationEnum Ashburn = new EdgeLocationEnum("ashburn");
            public static readonly EdgeLocationEnum Dublin = new EdgeLocationEnum("dublin");
            public static readonly EdgeLocationEnum Frankfurt = new EdgeLocationEnum("frankfurt");
            public static readonly EdgeLocationEnum Singapore = new EdgeLocationEnum("singapore");
            public static readonly EdgeLocationEnum Sydney = new EdgeLocationEnum("sydney");
            public static readonly EdgeLocationEnum SaoPaulo = new EdgeLocationEnum("sao_paulo");
            public static readonly EdgeLocationEnum Roaming = new EdgeLocationEnum("roaming");
            public static readonly EdgeLocationEnum Umatilla = new EdgeLocationEnum("umatilla");
            public static readonly EdgeLocationEnum Tokyo = new EdgeLocationEnum("tokyo");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class CodecEnum : StringEnum
        {
            private CodecEnum(string value) : base(value) {}
            public CodecEnum() {}
            public static implicit operator CodecEnum(string value)
            {
                return new CodecEnum(value);
            }

            public static readonly CodecEnum Vp8 = new CodecEnum("VP8");
            public static readonly CodecEnum H264 = new CodecEnum("H264");
            public static readonly CodecEnum Vp9 = new CodecEnum("VP9");
            public static readonly CodecEnum Opus = new CodecEnum("opus");
        }

        
        private static Request BuildFetchRequest(FetchRoomOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Video/Rooms/{RoomSid}";

            string PathRoomSid = options.PathRoomSid;
            path = path.Replace("{"+"RoomSid"+"}", PathRoomSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Insights,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Get Video Log Analyzer data for a Room. </summary>
        /// <param name="options"> Fetch Room parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Room </returns>
        public static RoomResource Fetch(FetchRoomOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Get Video Log Analyzer data for a Room. </summary>
        /// <param name="options"> Fetch Room parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Room </returns>
        public static async System.Threading.Tasks.Task<RoomResource> FetchAsync(FetchRoomOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Get Video Log Analyzer data for a Room. </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Room </returns>
        public static RoomResource Fetch(
                                         string pathRoomSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchRoomOptions(pathRoomSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Get Video Log Analyzer data for a Room. </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Room </returns>
        public static async System.Threading.Tasks.Task<RoomResource> FetchAsync(string pathRoomSid, ITwilioRestClient client = null)
        {
            var options = new FetchRoomOptions(pathRoomSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadRoomOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Video/Rooms";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Insights,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Get a list of Programmable Video Rooms. </summary>
        /// <param name="options"> Read Room parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Room </returns>
        public static ResourceSet<RoomResource> Read(ReadRoomOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<RoomResource>.FromJson("rooms", response.Content);
            return new ResourceSet<RoomResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Get a list of Programmable Video Rooms. </summary>
        /// <param name="options"> Read Room parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Room </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RoomResource>> ReadAsync(ReadRoomOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<RoomResource>.FromJson("rooms", response.Content);
            return new ResourceSet<RoomResource>(page, options, client);
        }
        #endif
        /// <summary> Get a list of Programmable Video Rooms. </summary>
        /// <param name="roomType"> Type of room. Can be `go`, `peer_to_peer`, `group`, or `group_small`. </param>
        /// <param name="codec"> Codecs used by participants in the room. Can be `VP8`, `H264`, or `VP9`. </param>
        /// <param name="roomName"> Room friendly name. </param>
        /// <param name="createdAfter"> Only read rooms that started on or after this ISO 8601 timestamp. </param>
        /// <param name="createdBefore"> Only read rooms that started before this ISO 8601 timestamp. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Room </returns>
        public static ResourceSet<RoomResource> Read(
                                                     List<RoomResource.RoomTypeEnum> roomType = null,
                                                     List<RoomResource.CodecEnum> codec = null,
                                                     string roomName = null,
                                                     DateTime? createdAfter = null,
                                                     DateTime? createdBefore = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadRoomOptions(){ RoomType = roomType, Codec = codec, RoomName = roomName, CreatedAfter = createdAfter, CreatedBefore = createdBefore, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Get a list of Programmable Video Rooms. </summary>
        /// <param name="roomType"> Type of room. Can be `go`, `peer_to_peer`, `group`, or `group_small`. </param>
        /// <param name="codec"> Codecs used by participants in the room. Can be `VP8`, `H264`, or `VP9`. </param>
        /// <param name="roomName"> Room friendly name. </param>
        /// <param name="createdAfter"> Only read rooms that started on or after this ISO 8601 timestamp. </param>
        /// <param name="createdBefore"> Only read rooms that started before this ISO 8601 timestamp. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Room </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RoomResource>> ReadAsync(
                                                                                             List<RoomResource.RoomTypeEnum> roomType = null,
                                                                                             List<RoomResource.CodecEnum> codec = null,
                                                                                             string roomName = null,
                                                                                             DateTime? createdAfter = null,
                                                                                             DateTime? createdBefore = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadRoomOptions(){ RoomType = roomType, Codec = codec, RoomName = roomName, CreatedAfter = createdAfter, CreatedBefore = createdBefore, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<RoomResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<RoomResource>.FromJson("rooms", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<RoomResource> NextPage(Page<RoomResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RoomResource>.FromJson("rooms", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<RoomResource> PreviousPage(Page<RoomResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RoomResource>.FromJson("rooms", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a RoomResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RoomResource object represented by the provided JSON </returns>
        public static RoomResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<RoomResource>(json);
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

    
        ///<summary> Account SID associated with this room. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Unique identifier for the room. </summary> 
        [JsonProperty("room_sid")]
        public string RoomSid { get; private set; }

        ///<summary> Room friendly name. </summary> 
        [JsonProperty("room_name")]
        public string RoomName { get; private set; }

        ///<summary> Creation time of the room. </summary> 
        [JsonProperty("create_time")]
        public DateTime? CreateTime { get; private set; }

        ///<summary> End time for the room. </summary> 
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }

        
        [JsonProperty("room_type")]
        public RoomResource.RoomTypeEnum RoomType { get; private set; }

        
        [JsonProperty("room_status")]
        public RoomResource.RoomStatusEnum RoomStatus { get; private set; }

        ///<summary> Webhook provided for status callbacks. </summary> 
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }

        ///<summary> HTTP method provided for status callback URL. </summary> 
        [JsonProperty("status_callback_method")]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; private set; }

        
        [JsonProperty("created_method")]
        public RoomResource.CreatedMethodEnum CreatedMethod { get; private set; }

        
        [JsonProperty("end_reason")]
        public RoomResource.EndReasonEnum EndReason { get; private set; }

        ///<summary> Max number of total participants allowed by the application settings. </summary> 
        [JsonProperty("max_participants")]
        public int? MaxParticipants { get; private set; }

        ///<summary> Number of participants. May include duplicate identities for participants who left and rejoined. </summary> 
        [JsonProperty("unique_participants")]
        public int? UniqueParticipants { get; private set; }

        ///<summary> Unique number of participant identities. </summary> 
        [JsonProperty("unique_participant_identities")]
        public int? UniqueParticipantIdentities { get; private set; }

        ///<summary> Actual number of concurrent participants. </summary> 
        [JsonProperty("concurrent_participants")]
        public int? ConcurrentParticipants { get; private set; }

        ///<summary> Maximum number of participants allowed in the room at the same time allowed by the application settings. </summary> 
        [JsonProperty("max_concurrent_participants")]
        public int? MaxConcurrentParticipants { get; private set; }

        ///<summary> Codecs used by participants in the room. Can be `VP8`, `H264`, or `VP9`. </summary> 
        [JsonProperty("codecs")]
        public List<RoomResource.CodecEnum> Codecs { get; private set; }

        
        [JsonProperty("media_region")]
        public RoomResource.TwilioRealmEnum MediaRegion { get; private set; }

        ///<summary> Total room duration from create time to end time. </summary> 
        [JsonProperty("duration_sec")]
        public long? DurationSec { get; private set; }

        ///<summary> Combined amount of participant time in the room. </summary> 
        [JsonProperty("total_participant_duration_sec")]
        public long? TotalParticipantDurationSec { get; private set; }

        ///<summary> Combined amount of recorded seconds for participants in the room. </summary> 
        [JsonProperty("total_recording_duration_sec")]
        public long? TotalRecordingDurationSec { get; private set; }

        
        [JsonProperty("processing_state")]
        public RoomResource.ProcessingStateEnum ProcessingState { get; private set; }

        ///<summary> Boolean indicating if recording is enabled for the room. </summary> 
        [JsonProperty("recording_enabled")]
        public bool? RecordingEnabled { get; private set; }

        
        [JsonProperty("edge_location")]
        public RoomResource.EdgeLocationEnum EdgeLocation { get; private set; }

        ///<summary> URL for the room resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Room subresources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private RoomResource() {

        }
    }
}

