/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;


namespace Twilio.Rest.Api.V2010.Account.Call
{
    public class FeedbackResource : Resource
    {
    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class IssuesEnum : StringEnum
        {
            private IssuesEnum(string value) : base(value) {}
            public IssuesEnum() {}
            public static implicit operator IssuesEnum(string value)
            {
                return new IssuesEnum(value);
            }

            public static readonly IssuesEnum AudioLatency = new IssuesEnum("audio-latency");
            public static readonly IssuesEnum DigitsNotCaptured = new IssuesEnum("digits-not-captured");
            public static readonly IssuesEnum DroppedCall = new IssuesEnum("dropped-call");
            public static readonly IssuesEnum ImperfectAudio = new IssuesEnum("imperfect-audio");
            public static readonly IssuesEnum IncorrectCallerId = new IssuesEnum("incorrect-caller-id");
            public static readonly IssuesEnum OneWayAudio = new IssuesEnum("one-way-audio");
            public static readonly IssuesEnum PostDialDelay = new IssuesEnum("post-dial-delay");
            public static readonly IssuesEnum UnsolicitedCall = new IssuesEnum("unsolicited-call");
        }

        
        private static Request BuildFetchRequest(FetchFeedbackOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a Feedback resource from a call </summary>
        /// <param name="options"> Fetch Feedback parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Feedback </returns>
        public static FeedbackResource Fetch(FetchFeedbackOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a Feedback resource from a call </summary>
        /// <param name="options"> Fetch Feedback parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Feedback </returns>
        public static async System.Threading.Tasks.Task<FeedbackResource> FetchAsync(FetchFeedbackOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a Feedback resource from a call </summary>
        /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Feedback </returns>
        public static FeedbackResource Fetch(
                                         string pathCallSid, 
                                         string pathAccountSid = null, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchFeedbackOptions(pathCallSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a Feedback resource from a call </summary>
        /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Feedback </returns>
        public static async System.Threading.Tasks.Task<FeedbackResource> FetchAsync(string pathCallSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchFeedbackOptions(pathCallSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateFeedbackOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a Feedback resource for a call </summary>
        /// <param name="options"> Update Feedback parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Feedback </returns>
        public static FeedbackResource Update(UpdateFeedbackOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a Feedback resource for a call </summary>
        /// <param name="options"> Update Feedback parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Feedback </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<FeedbackResource> UpdateAsync(UpdateFeedbackOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a Feedback resource for a call </summary>
        /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="qualityScore"> The call quality expressed as an integer from `1` to `5` where `1` represents very poor call quality and `5` represents a perfect call. </param>
        /// <param name="issue"> One or more issues experienced during the call. The issues can be: `imperfect-audio`, `dropped-call`, `incorrect-caller-id`, `post-dial-delay`, `digits-not-captured`, `audio-latency`, `unsolicited-call`, or `one-way-audio`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Feedback </returns>
        public static FeedbackResource Update(
                                          string pathCallSid,
                                          string pathAccountSid = null,
                                          int? qualityScore = null,
                                          List<FeedbackResource.IssuesEnum> issue = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateFeedbackOptions(pathCallSid){ PathAccountSid = pathAccountSid, QualityScore = qualityScore, Issue = issue };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a Feedback resource for a call </summary>
        /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="qualityScore"> The call quality expressed as an integer from `1` to `5` where `1` represents very poor call quality and `5` represents a perfect call. </param>
        /// <param name="issue"> One or more issues experienced during the call. The issues can be: `imperfect-audio`, `dropped-call`, `incorrect-caller-id`, `post-dial-delay`, `digits-not-captured`, `audio-latency`, `unsolicited-call`, or `one-way-audio`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Feedback </returns>
        public static async System.Threading.Tasks.Task<FeedbackResource> UpdateAsync(
                                                                              string pathCallSid,
                                                                              string pathAccountSid = null,
                                                                              int? qualityScore = null,
                                                                              List<FeedbackResource.IssuesEnum> issue = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateFeedbackOptions(pathCallSid){ PathAccountSid = pathAccountSid, QualityScore = qualityScore, Issue = issue };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns>
        public static FeedbackResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique sid that identifies this account </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The date this resource was created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date this resource was last updated </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> Issues experienced during the call </summary> 
        [JsonProperty("issues")]
        public List<FeedbackResource.IssuesEnum> Issues { get; private set; }

        ///<summary> 1 to 5 quality score </summary> 
        [JsonProperty("quality_score")]
        public int? QualityScore { get; private set; }

        ///<summary> A string that uniquely identifies this feedback resource </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }



        private FeedbackResource() {

        }
    }
}

