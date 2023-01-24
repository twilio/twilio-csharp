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
    public class FeedbackSummaryResource : Resource
    {
    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum Failed = new StatusEnum("failed");

        }

        
        private static Request BuildCreateRequest(CreateFeedbackSummaryOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/FeedbackSummary.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a FeedbackSummary resource for a call </summary>
        /// <param name="options"> Create FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        public static FeedbackSummaryResource Create(CreateFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a FeedbackSummary resource for a call </summary>
        /// <param name="options"> Create FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns>
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> CreateAsync(CreateFeedbackSummaryOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a FeedbackSummary resource for a call </summary>
        /// <param name="startDate"> Only include feedback given on or after this date. Format is `YYYY-MM-DD` and specified in UTC. </param>
        /// <param name="endDate"> Only include feedback given on or before this date. Format is `YYYY-MM-DD` and specified in UTC. </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="includeSubaccounts"> Whether to also include Feedback resources from all subaccounts. `true` includes feedback from all subaccounts and `false`, the default, includes feedback from only the specified account. </param>
        /// <param name="statusCallback"> The URL that we will request when the feedback summary is complete. </param>
        /// <param name="statusCallbackMethod"> The HTTP method (`GET` or `POST`) we use to make the request to the `StatusCallback` URL. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        public static FeedbackSummaryResource Create(
                                          DateTime? startDate,
                                          DateTime? endDate,
                                          string pathAccountSid = null,
                                          bool? includeSubaccounts = null,
                                          Uri statusCallback = null,
                                          Twilio.Http.HttpMethod statusCallbackMethod = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateFeedbackSummaryOptions(startDate, endDate){  PathAccountSid = pathAccountSid, IncludeSubaccounts = includeSubaccounts, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a FeedbackSummary resource for a call </summary>
        /// <param name="startDate"> Only include feedback given on or after this date. Format is `YYYY-MM-DD` and specified in UTC. </param>
        /// <param name="endDate"> Only include feedback given on or before this date. Format is `YYYY-MM-DD` and specified in UTC. </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="includeSubaccounts"> Whether to also include Feedback resources from all subaccounts. `true` includes feedback from all subaccounts and `false`, the default, includes feedback from only the specified account. </param>
        /// <param name="statusCallback"> The URL that we will request when the feedback summary is complete. </param>
        /// <param name="statusCallbackMethod"> The HTTP method (`GET` or `POST`) we use to make the request to the `StatusCallback` URL. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns>
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> CreateAsync(
                                                                                  DateTime? startDate,
                                                                                  DateTime? endDate,
                                                                                  string pathAccountSid = null,
                                                                                  bool? includeSubaccounts = null,
                                                                                  Uri statusCallback = null,
                                                                                  Twilio.Http.HttpMethod statusCallbackMethod = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateFeedbackSummaryOptions(startDate, endDate){  PathAccountSid = pathAccountSid, IncludeSubaccounts = includeSubaccounts, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a FeedbackSummary resource from a call </summary>
        /// <param name="options"> Delete FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        private static Request BuildDeleteRequest(DeleteFeedbackSummaryOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/FeedbackSummary/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a FeedbackSummary resource from a call </summary>
        /// <param name="options"> Delete FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        public static bool Delete(DeleteFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a FeedbackSummary resource from a call </summary>
        /// <param name="options"> Delete FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteFeedbackSummaryOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a FeedbackSummary resource from a call </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        public static bool Delete(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteFeedbackSummaryOptions(pathSid)      { PathAccountSid = pathAccountSid }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a FeedbackSummary resource from a call </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteFeedbackSummaryOptions(pathSid)  { PathAccountSid = pathAccountSid };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchFeedbackSummaryOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/FeedbackSummary/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a FeedbackSummary resource from a call </summary>
        /// <param name="options"> Fetch FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        public static FeedbackSummaryResource Fetch(FetchFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a FeedbackSummary resource from a call </summary>
        /// <param name="options"> Fetch FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns>
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> FetchAsync(FetchFeedbackSummaryOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a FeedbackSummary resource from a call </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns>
        public static FeedbackSummaryResource Fetch(
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchFeedbackSummaryOptions(pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a FeedbackSummary resource from a call </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="pathAccountSid"> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns>
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchFeedbackSummaryOptions(pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a FeedbackSummaryResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackSummaryResource object represented by the provided JSON </returns>
        public static FeedbackSummaryResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<FeedbackSummaryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The total number of calls. </summary> 
        [JsonProperty("call_count")]
        public int? CallCount { get; private set; }

        ///<summary> The total number of calls with a feedback entry. </summary> 
        [JsonProperty("call_feedback_count")]
        public int? CallFeedbackCount { get; private set; }

        ///<summary> The date that this resource was created, given in [RFC 2822](https://www.php.net/manual/en/class.datetime.php#datetime.constants.rfc2822) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated, given in [RFC 2822](https://www.php.net/manual/en/class.datetime.php#datetime.constants.rfc2822) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The last date for which feedback entries are included in this Feedback Summary, formatted as `YYYY-MM-DD` and specified in UTC. </summary> 
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; private set; }

        ///<summary> Whether the feedback summary includes subaccounts; `true` if it does, otherwise `false`. </summary> 
        [JsonProperty("include_subaccounts")]
        public bool? IncludeSubaccounts { get; private set; }

        ///<summary> A list of issues experienced during the call. The issues can be: `imperfect-audio`, `dropped-call`, `incorrect-caller-id`, `post-dial-delay`, `digits-not-captured`, `audio-latency`, or `one-way-audio`. </summary> 
        [JsonProperty("issues")]
        public List<object> Issues { get; private set; }

        ///<summary> The average QualityScore of the feedback entries. </summary> 
        [JsonProperty("quality_score_average")]
        public decimal? QualityScoreAverage { get; private set; }

        ///<summary> The median QualityScore of the feedback entries. </summary> 
        [JsonProperty("quality_score_median")]
        public decimal? QualityScoreMedian { get; private set; }

        ///<summary> The standard deviation of the quality scores. </summary> 
        [JsonProperty("quality_score_standard_deviation")]
        public decimal? QualityScoreStandardDeviation { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The first date for which feedback entries are included in this feedback summary, formatted as `YYYY-MM-DD` and specified in UTC. </summary> 
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; private set; }

        
        [JsonProperty("status")]
        public FeedbackSummaryResource.StatusEnum Status { get; private set; }



        private FeedbackSummaryResource() {

        }
    }
}

