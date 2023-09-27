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


namespace Twilio.Rest.Insights.V1.Room
{
    public class ParticipantResource : Resource
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
        }

        
        private static Request BuildFetchRequest(FetchParticipantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Video/Rooms/{RoomSid}/Participants/{ParticipantSid}";

            string PathRoomSid = options.PathRoomSid;
            path = path.Replace("{"+"RoomSid"+"}", PathRoomSid);
            string PathParticipantSid = options.PathParticipantSid;
            path = path.Replace("{"+"ParticipantSid"+"}", PathParticipantSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Insights,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Get Video Log Analyzer data for a Room Participant. </summary>
        /// <param name="options"> Fetch Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ParticipantResource Fetch(FetchParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Get Video Log Analyzer data for a Room Participant. </summary>
        /// <param name="options"> Fetch Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(FetchParticipantOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Get Video Log Analyzer data for a Room Participant. </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="pathParticipantSid"> The SID of the Participant resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ParticipantResource Fetch(
                                         string pathRoomSid, 
                                         string pathParticipantSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(pathRoomSid, pathParticipantSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Get Video Log Analyzer data for a Room Participant. </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="pathParticipantSid"> The SID of the Participant resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(string pathRoomSid, string pathParticipantSid, ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(pathRoomSid, pathParticipantSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadParticipantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Video/Rooms/{RoomSid}/Participants";

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
        /// <summary> Get a list of room participants. </summary>
        /// <param name="options"> Read Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ResourceSet<ParticipantResource> Read(ReadParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Get a list of room participants. </summary>
        /// <param name="options"> Read Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(ReadParticipantOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }
        #endif
        /// <summary> Get a list of room participants. </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ResourceSet<ParticipantResource> Read(
                                                     string pathRoomSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(pathRoomSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Get a list of room participants. </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(
                                                                                             string pathRoomSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(pathRoomSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ParticipantResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ParticipantResource> PreviousPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a ParticipantResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ParticipantResource object represented by the provided JSON </returns>
        public static ParticipantResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
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

    
        ///<summary> Unique identifier for the participant. </summary> 
        [JsonProperty("participant_sid")]
        public string ParticipantSid { get; private set; }

        ///<summary> The application-defined string that uniquely identifies the participant within a Room. </summary> 
        [JsonProperty("participant_identity")]
        public string ParticipantIdentity { get; private set; }

        ///<summary> When the participant joined the room. </summary> 
        [JsonProperty("join_time")]
        public DateTime? JoinTime { get; private set; }

        ///<summary> When the participant left the room. </summary> 
        [JsonProperty("leave_time")]
        public DateTime? LeaveTime { get; private set; }

        ///<summary> Amount of time in seconds the participant was in the room. </summary> 
        [JsonProperty("duration_sec")]
        public long? DurationSec { get; private set; }

        ///<summary> Account SID associated with the room. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Unique identifier for the room. </summary> 
        [JsonProperty("room_sid")]
        public string RoomSid { get; private set; }

        
        [JsonProperty("status")]
        public ParticipantResource.RoomStatusEnum Status { get; private set; }

        ///<summary> Codecs detected from the participant. Can be `VP8`, `H264`, or `VP9`. </summary> 
        [JsonProperty("codecs")]
        public List<ParticipantResource.CodecEnum> Codecs { get; private set; }

        ///<summary> Reason the participant left the room. See [the list of possible values here](https://www.twilio.com/docs/video/troubleshooting/video-log-analyzer-api#end_reason). </summary> 
        [JsonProperty("end_reason")]
        public string EndReason { get; private set; }

        ///<summary> Errors encountered by the participant. </summary> 
        [JsonProperty("error_code")]
        public int? ErrorCode { get; private set; }

        ///<summary> Twilio error code dictionary link. </summary> 
        [JsonProperty("error_code_url")]
        public string ErrorCodeUrl { get; private set; }

        
        [JsonProperty("media_region")]
        public ParticipantResource.TwilioRealmEnum MediaRegion { get; private set; }

        ///<summary> Object containing information about the participant's data from the room. See [below](https://www.twilio.com/docs/video/troubleshooting/video-log-analyzer-api#properties) for more information. </summary> 
        [JsonProperty("properties")]
        public object Properties { get; private set; }

        
        [JsonProperty("edge_location")]
        public ParticipantResource.EdgeLocationEnum EdgeLocation { get; private set; }

        ///<summary> Object containing information about the SDK name and version. See [below](https://www.twilio.com/docs/video/troubleshooting/video-log-analyzer-api#publisher_info) for more information. </summary> 
        [JsonProperty("publisher_info")]
        public object PublisherInfo { get; private set; }

        ///<summary> URL of the participant resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private ParticipantResource() {

        }
    }
}

