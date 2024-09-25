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
    public class AnnotationResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ConnectivityIssueEnum : StringEnum
        {
            private ConnectivityIssueEnum(string value) : base(value) {}
            public ConnectivityIssueEnum() {}
            public static implicit operator ConnectivityIssueEnum(string value)
            {
                return new ConnectivityIssueEnum(value);
            }
            public static readonly ConnectivityIssueEnum UnknownConnectivityIssue = new ConnectivityIssueEnum("unknown_connectivity_issue");
            public static readonly ConnectivityIssueEnum NoConnectivityIssue = new ConnectivityIssueEnum("no_connectivity_issue");
            public static readonly ConnectivityIssueEnum InvalidNumber = new ConnectivityIssueEnum("invalid_number");
            public static readonly ConnectivityIssueEnum CallerId = new ConnectivityIssueEnum("caller_id");
            public static readonly ConnectivityIssueEnum DroppedCall = new ConnectivityIssueEnum("dropped_call");
            public static readonly ConnectivityIssueEnum NumberReachability = new ConnectivityIssueEnum("number_reachability");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class AnsweredByEnum : StringEnum
        {
            private AnsweredByEnum(string value) : base(value) {}
            public AnsweredByEnum() {}
            public static implicit operator AnsweredByEnum(string value)
            {
                return new AnsweredByEnum(value);
            }
            public static readonly AnsweredByEnum UnknownAnsweredBy = new AnsweredByEnum("unknown_answered_by");
            public static readonly AnsweredByEnum Human = new AnsweredByEnum("human");
            public static readonly AnsweredByEnum Machine = new AnsweredByEnum("machine");

        }

        
        private static Request BuildFetchRequest(FetchAnnotationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Voice/{CallSid}/Annotation";

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

        /// <summary> Get the Annotation for a specific Call. </summary>
        /// <param name="options"> Fetch Annotation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Annotation </returns>
        public static AnnotationResource Fetch(FetchAnnotationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Get the Annotation for a specific Call. </summary>
        /// <param name="options"> Fetch Annotation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Annotation </returns>
        public static async System.Threading.Tasks.Task<AnnotationResource> FetchAsync(FetchAnnotationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Get the Annotation for a specific Call. </summary>
        /// <param name="pathCallSid"> The unique SID identifier of the Call. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Annotation </returns>
        public static AnnotationResource Fetch(
                                         string pathCallSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchAnnotationOptions(pathCallSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Get the Annotation for a specific Call. </summary>
        /// <param name="pathCallSid"> The unique SID identifier of the Call. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Annotation </returns>
        public static async System.Threading.Tasks.Task<AnnotationResource> FetchAsync(string pathCallSid, ITwilioRestClient client = null)
        {
            var options = new FetchAnnotationOptions(pathCallSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateAnnotationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Voice/{CallSid}/Annotation";

            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Insights,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update an Annotation for a specific Call. </summary>
        /// <param name="options"> Update Annotation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Annotation </returns>
        public static AnnotationResource Update(UpdateAnnotationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update an Annotation for a specific Call. </summary>
        /// <param name="options"> Update Annotation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Annotation </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<AnnotationResource> UpdateAsync(UpdateAnnotationOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update an Annotation for a specific Call. </summary>
        /// <param name="pathCallSid"> The unique string that Twilio created to identify this Call resource. It always starts with a CA. </param>
        /// <param name="answeredBy">  </param>
        /// <param name="connectivityIssue">  </param>
        /// <param name="qualityIssues"> Specify if the call had any subjective quality issues. Possible values, one or more of `no_quality_issue`, `low_volume`, `choppy_robotic`, `echo`, `dtmf`, `latency`, `owa`, `static_noise`. Use comma separated values to indicate multiple quality issues for the same call. </param>
        /// <param name="spam"> A boolean flag to indicate if the call was a spam call. Use this to provide feedback on whether calls placed from your account were marked as spam, or if inbound calls received by your account were unwanted spam. Use `true` if the call was a spam call. </param>
        /// <param name="callScore"> Specify the call score. This is of type integer. Use a range of 1-5 to indicate the call experience score, with the following mapping as a reference for rating the call [5: Excellent, 4: Good, 3 : Fair, 2 : Poor, 1: Bad]. </param>
        /// <param name="comment"> Specify any comments pertaining to the call. `comment` has a maximum character limit of 100. Twilio does not treat this field as PII, so no PII should be included in the `comment`. </param>
        /// <param name="incident"> Associate this call with an incident or support ticket. The `incident` parameter is of type string with a maximum character limit of 100. Twilio does not treat this field as PII, so no PII should be included in `incident`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Annotation </returns>
        public static AnnotationResource Update(
                                          string pathCallSid,
                                          AnnotationResource.AnsweredByEnum answeredBy = null,
                                          AnnotationResource.ConnectivityIssueEnum connectivityIssue = null,
                                          string qualityIssues = null,
                                          bool? spam = null,
                                          int? callScore = null,
                                          string comment = null,
                                          string incident = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateAnnotationOptions(pathCallSid){ AnsweredBy = answeredBy, ConnectivityIssue = connectivityIssue, QualityIssues = qualityIssues, Spam = spam, CallScore = callScore, Comment = comment, Incident = incident };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update an Annotation for a specific Call. </summary>
        /// <param name="pathCallSid"> The unique string that Twilio created to identify this Call resource. It always starts with a CA. </param>
        /// <param name="answeredBy">  </param>
        /// <param name="connectivityIssue">  </param>
        /// <param name="qualityIssues"> Specify if the call had any subjective quality issues. Possible values, one or more of `no_quality_issue`, `low_volume`, `choppy_robotic`, `echo`, `dtmf`, `latency`, `owa`, `static_noise`. Use comma separated values to indicate multiple quality issues for the same call. </param>
        /// <param name="spam"> A boolean flag to indicate if the call was a spam call. Use this to provide feedback on whether calls placed from your account were marked as spam, or if inbound calls received by your account were unwanted spam. Use `true` if the call was a spam call. </param>
        /// <param name="callScore"> Specify the call score. This is of type integer. Use a range of 1-5 to indicate the call experience score, with the following mapping as a reference for rating the call [5: Excellent, 4: Good, 3 : Fair, 2 : Poor, 1: Bad]. </param>
        /// <param name="comment"> Specify any comments pertaining to the call. `comment` has a maximum character limit of 100. Twilio does not treat this field as PII, so no PII should be included in the `comment`. </param>
        /// <param name="incident"> Associate this call with an incident or support ticket. The `incident` parameter is of type string with a maximum character limit of 100. Twilio does not treat this field as PII, so no PII should be included in `incident`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Annotation </returns>
        public static async System.Threading.Tasks.Task<AnnotationResource> UpdateAsync(
                                                                              string pathCallSid,
                                                                              AnnotationResource.AnsweredByEnum answeredBy = null,
                                                                              AnnotationResource.ConnectivityIssueEnum connectivityIssue = null,
                                                                              string qualityIssues = null,
                                                                              bool? spam = null,
                                                                              int? callScore = null,
                                                                              string comment = null,
                                                                              string incident = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateAnnotationOptions(pathCallSid){ AnsweredBy = answeredBy, ConnectivityIssue = connectivityIssue, QualityIssues = qualityIssues, Spam = spam, CallScore = callScore, Comment = comment, Incident = incident };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AnnotationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AnnotationResource object represented by the provided JSON </returns>
        public static AnnotationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AnnotationResource>(json);
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

    
        ///<summary> The unique SID identifier of the Call. </summary> 
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        
        [JsonProperty("answered_by")]
        public AnnotationResource.AnsweredByEnum AnsweredBy { get; private set; }

        
        [JsonProperty("connectivity_issue")]
        public AnnotationResource.ConnectivityIssueEnum ConnectivityIssue { get; private set; }

        ///<summary> Specifies if the call had any subjective quality issues. Possible values are one or more of `no_quality_issue`, `low_volume`, `choppy_robotic`, `echo`, `dtmf`, `latency`, `owa`, or `static_noise`. </summary> 
        [JsonProperty("quality_issues")]
        public List<string> QualityIssues { get; private set; }

        ///<summary> Specifies if the call was a spam call. Use this to provide feedback on whether calls placed from your account were marked as spam, or if inbound calls received by your account were unwanted spam. Is of type Boolean: true, false. Use true if the call was a spam call. </summary> 
        [JsonProperty("spam")]
        public bool? Spam { get; private set; }

        ///<summary> Specifies the Call Score, if available. This is of type integer. Use a range of 1-5 to indicate the call experience score, with the following mapping as a reference for rating the call [5: Excellent, 4: Good, 3 : Fair, 2 : Poor, 1: Bad]. </summary> 
        [JsonProperty("call_score")]
        public int? CallScore { get; private set; }

        ///<summary> Specifies any comments pertaining to the call. Twilio does not treat this field as PII, so no PII should be included in comments. </summary> 
        [JsonProperty("comment")]
        public string Comment { get; private set; }

        ///<summary> Incident or support ticket associated with this call. The `incident` property is of type string with a maximum character limit of 100. Twilio does not treat this field as PII, so no PII should be included in `incident`. </summary> 
        [JsonProperty("incident")]
        public string Incident { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private AnnotationResource() {

        }
    }
}

