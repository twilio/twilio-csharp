using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class FeedbackSummaryResource : Resource {
        public sealed class Status : IStringEnum {
            public const string QUEUED="queued";
            public const string IN_PROGRESS="in-progress";
            public const string COMPLETED="completed";
            public const string FAILED="failed";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="includeSubaccounts"> The include_subaccounts </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <returns> FeedbackSummaryCreator capable of executing the create </returns> 
        public static FeedbackSummaryCreator Creator(DateTime? startDate, DateTime? endDate, string accountSid=null, bool? includeSubaccounts=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null) {
            return new FeedbackSummaryCreator(startDate, endDate, accountSid:accountSid, includeSubaccounts:includeSubaccounts, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> FeedbackSummaryFetcher capable of executing the fetch </returns> 
        public static FeedbackSummaryFetcher Fetcher(string sid, string accountSid=null) {
            return new FeedbackSummaryFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> FeedbackSummaryDeleter capable of executing the delete </returns> 
        public static FeedbackSummaryDeleter Deleter(string sid, string accountSid=null) {
            return new FeedbackSummaryDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a FeedbackSummaryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackSummaryResource object represented by the provided JSON </returns> 
        public static FeedbackSummaryResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<FeedbackSummaryResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("call_count")]
        public int? callCount { get; }
        [JsonProperty("call_feedback_count")]
        public int? callFeedbackCount { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("end_date")]
        public DateTime? endDate { get; }
        [JsonProperty("include_subaccounts")]
        public bool? includeSubaccounts { get; }
        [JsonProperty("issues")]
        public List<FeedbackIssue> issues { get; }
        [JsonProperty("quality_score_average")]
        public decimal? qualityScoreAverage { get; }
        [JsonProperty("quality_score_median")]
        public decimal? qualityScoreMedian { get; }
        [JsonProperty("quality_score_standard_deviation")]
        public decimal? qualityScoreStandardDeviation { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("start_date")]
        public DateTime? startDate { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedbackSummaryResource.Status status { get; }
    
        public FeedbackSummaryResource() {
        
        }
    
        private FeedbackSummaryResource([JsonProperty("account_sid")]
                                        string accountSid, 
                                        [JsonProperty("call_count")]
                                        int? callCount, 
                                        [JsonProperty("call_feedback_count")]
                                        int? callFeedbackCount, 
                                        [JsonProperty("date_created")]
                                        string dateCreated, 
                                        [JsonProperty("date_updated")]
                                        string dateUpdated, 
                                        [JsonProperty("end_date")]
                                        string endDate, 
                                        [JsonProperty("include_subaccounts")]
                                        bool? includeSubaccounts, 
                                        [JsonProperty("issues")]
                                        List<FeedbackIssue> issues, 
                                        [JsonProperty("quality_score_average")]
                                        decimal? qualityScoreAverage, 
                                        [JsonProperty("quality_score_median")]
                                        decimal? qualityScoreMedian, 
                                        [JsonProperty("quality_score_standard_deviation")]
                                        decimal? qualityScoreStandardDeviation, 
                                        [JsonProperty("sid")]
                                        string sid, 
                                        [JsonProperty("start_date")]
                                        string startDate, 
                                        [JsonProperty("status")]
                                        FeedbackSummaryResource.Status status) {
            this.accountSid = accountSid;
            this.callCount = callCount;
            this.callFeedbackCount = callFeedbackCount;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.endDate = MarshalConverter.DateTimeFromString(endDate);
            this.includeSubaccounts = includeSubaccounts;
            this.issues = issues;
            this.qualityScoreAverage = qualityScoreAverage;
            this.qualityScoreMedian = qualityScoreMedian;
            this.qualityScoreStandardDeviation = qualityScoreStandardDeviation;
            this.sid = sid;
            this.startDate = MarshalConverter.DateTimeFromString(startDate);
            this.status = status;
        }
    }
}