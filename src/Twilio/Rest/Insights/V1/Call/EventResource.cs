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




namespace Twilio.Rest.Insights.V1.Call
{
    public class EventResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class LevelEnum : StringEnum
        {
            private LevelEnum(string value) : base(value) {}
            public LevelEnum() {}
            public static implicit operator LevelEnum(string value)
            {
                return new LevelEnum(value);
            }
            public static readonly LevelEnum Unknown = new LevelEnum("UNKNOWN");
            public static readonly LevelEnum Debug = new LevelEnum("DEBUG");
            public static readonly LevelEnum Info = new LevelEnum("INFO");
            public static readonly LevelEnum Warning = new LevelEnum("WARNING");
            public static readonly LevelEnum Error = new LevelEnum("ERROR");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class TwilioEdgeEnum : StringEnum
        {
            private TwilioEdgeEnum(string value) : base(value) {}
            public TwilioEdgeEnum() {}
            public static implicit operator TwilioEdgeEnum(string value)
            {
                return new TwilioEdgeEnum(value);
            }
            public static readonly TwilioEdgeEnum UnknownEdge = new TwilioEdgeEnum("unknown_edge");
            public static readonly TwilioEdgeEnum CarrierEdge = new TwilioEdgeEnum("carrier_edge");
            public static readonly TwilioEdgeEnum SipEdge = new TwilioEdgeEnum("sip_edge");
            public static readonly TwilioEdgeEnum SdkEdge = new TwilioEdgeEnum("sdk_edge");
            public static readonly TwilioEdgeEnum ClientEdge = new TwilioEdgeEnum("client_edge");

        }

        
        private static Request BuildReadRequest(ReadEventOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Voice/{CallSid}/Events";

            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Insights,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Get a list of Call Insight Events for a Call. </summary>
        /// <param name="options"> Read Event parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Event </returns>
        public static ResourceSet<EventResource> Read(ReadEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<EventResource>.FromJson("events", response.Content);
            return new ResourceSet<EventResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Get a list of Call Insight Events for a Call. </summary>
        /// <param name="options"> Read Event parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Event </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(ReadEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<EventResource>.FromJson("events", response.Content);
            return new ResourceSet<EventResource>(page, options, client);
        }
        #endif
        /// <summary> Get a list of Call Insight Events for a Call. </summary>
        /// <param name="pathCallSid"> The unique SID identifier of the Call. </param>
        /// <param name="edge"> The Edge of this Event. One of `unknown_edge`, `carrier_edge`, `sip_edge`, `sdk_edge` or `client_edge`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Event </returns>
        public static ResourceSet<EventResource> Read(
                                                     string pathCallSid,
                                                     EventResource.TwilioEdgeEnum edge = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions(pathCallSid){ Edge = edge, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Get a list of Call Insight Events for a Call. </summary>
        /// <param name="pathCallSid"> The unique SID identifier of the Call. </param>
        /// <param name="edge"> The Edge of this Event. One of `unknown_edge`, `carrier_edge`, `sip_edge`, `sdk_edge` or `client_edge`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Event </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(
                                                                                             string pathCallSid,
                                                                                             EventResource.TwilioEdgeEnum edge = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions(pathCallSid){ Edge = edge, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<EventResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<EventResource> PreviousPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a EventResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EventResource object represented by the provided JSON </returns>
        public static EventResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<EventResource>(json);
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

    
        ///<summary> Event time. </summary> 
        [JsonProperty("timestamp")]
        public string Timestamp { get; private set; }

        ///<summary> The unique SID identifier of the Call. </summary> 
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        
        [JsonProperty("edge")]
        public EventResource.TwilioEdgeEnum Edge { get; private set; }

        ///<summary> Event group. </summary> 
        [JsonProperty("group")]
        public string Group { get; private set; }

        
        [JsonProperty("level")]
        public EventResource.LevelEnum Level { get; private set; }

        ///<summary> Event name. </summary> 
        [JsonProperty("name")]
        public string Name { get; private set; }

        ///<summary> Represents the connection between Twilio and our immediate carrier partners. The events here describe the call lifecycle as reported by Twilio's carrier media gateways. </summary> 
        [JsonProperty("carrier_edge")]
        public object CarrierEdge { get; private set; }

        ///<summary> Represents the Twilio media gateway for SIP interface and SIP trunking calls. The events here describe the call lifecycle as reported by Twilio's public media gateways. </summary> 
        [JsonProperty("sip_edge")]
        public object SipEdge { get; private set; }

        ///<summary> Represents the Voice SDK running locally in the browser or in the Android/iOS application. The events here are emitted by the Voice SDK in response to certain call progress events, network changes, or call quality conditions. </summary> 
        [JsonProperty("sdk_edge")]
        public object SdkEdge { get; private set; }

        ///<summary> Represents the Twilio media gateway for Client calls. The events here describe the call lifecycle as reported by Twilio's Voice SDK media gateways. </summary> 
        [JsonProperty("client_edge")]
        public object ClientEdge { get; private set; }



        private EventResource() {

        }
    }
}

