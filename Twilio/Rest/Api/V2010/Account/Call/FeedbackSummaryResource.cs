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

    public class FeedbackSummaryResource : SidResource {
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
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <returns> FeedbackSummaryCreator capable of executing the create </returns> 
        public static FeedbackSummaryCreator Creator(string accountSid, DateTime? startDate, DateTime? endDate) {
            return new FeedbackSummaryCreator(accountSid, startDate, endDate);
        }
    
        /// <summary>
        /// Create a FeedbackSummaryCreator to execute create.
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <returns> FeedbackSummaryCreator capable of executing the create </returns> 
        public static FeedbackSummaryCreator Creator(DateTime? startDate, 
                                                     DateTime? endDate) {
            return new FeedbackSummaryCreator(startDate, endDate);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> FeedbackSummaryFetcher capable of executing the fetch </returns> 
        public static FeedbackSummaryFetcher Fetcher(string accountSid, string sid) {
            return new FeedbackSummaryFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a FeedbackSummaryFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> FeedbackSummaryFetcher capable of executing the fetch </returns> 
        public static FeedbackSummaryFetcher Fetcher(string sid) {
            return new FeedbackSummaryFetcher(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> FeedbackSummaryDeleter capable of executing the delete </returns> 
        public static FeedbackSummaryDeleter Deleter(string accountSid, string sid) {
            return new FeedbackSummaryDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a FeedbackSummaryDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> FeedbackSummaryDeleter capable of executing the delete </returns> 
        public static FeedbackSummaryDeleter Deleter(string sid) {
            return new FeedbackSummaryDeleter(sid);
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
        private readonly string accountSid;
        [JsonProperty("call_count")]
        private readonly int? callCount;
        [JsonProperty("call_feedback_count")]
        private readonly int? callFeedbackCount;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("end_date")]
        private readonly DateTime? endDate;
        [JsonProperty("include_subaccounts")]
        private readonly bool? includeSubaccounts;
        [JsonProperty("issues")]
        private readonly List<FeedbackIssue> issues;
        [JsonProperty("quality_score_average")]
        private readonly decimal? qualityScoreAverage;
        [JsonProperty("quality_score_median")]
        private readonly decimal? qualityScoreMedian;
        [JsonProperty("quality_score_standard_deviation")]
        private readonly decimal? qualityScoreStandardDeviation;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("start_date")]
        private readonly DateTime? startDate;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly FeedbackSummaryResource.Status status;
    
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The call_count </returns> 
        public int? GetCallCount() {
            return this.callCount;
        }
    
        /// <returns> The call_feedback_count </returns> 
        public int? GetCallFeedbackCount() {
            return this.callFeedbackCount;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The end_date </returns> 
        public DateTime? GetEndDate() {
            return this.endDate;
        }
    
        /// <returns> The include_subaccounts </returns> 
        public bool? GetIncludeSubaccounts() {
            return this.includeSubaccounts;
        }
    
        /// <returns> The issues </returns> 
        public List<FeedbackIssue> GetIssues() {
            return this.issues;
        }
    
        /// <returns> The quality_score_average </returns> 
        public decimal? GetQualityScoreAverage() {
            return this.qualityScoreAverage;
        }
    
        /// <returns> The quality_score_median </returns> 
        public decimal? GetQualityScoreMedian() {
            return this.qualityScoreMedian;
        }
    
        /// <returns> The quality_score_standard_deviation </returns> 
        public decimal? GetQualityScoreStandardDeviation() {
            return this.qualityScoreStandardDeviation;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The start_date </returns> 
        public DateTime? GetStartDate() {
            return this.startDate;
        }
    
        /// <returns> The status </returns> 
        public FeedbackSummaryResource.Status GetStatus() {
            return this.status;
        }
    }
}