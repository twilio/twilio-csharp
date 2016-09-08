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
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param startDate The start_date
         * @param endDate The end_date
         * @return FeedbackSummaryCreator capable of executing the create
         */
        public static FeedbackSummaryCreator Create(string accountSid, DateTime? startDate, DateTime? endDate) {
            return new FeedbackSummaryCreator(accountSid, startDate, endDate);
        }
    
        /**
         * Create a FeedbackSummaryCreator to execute create.
         * 
         * @param startDate The start_date
         * @param endDate The end_date
         * @return FeedbackSummaryCreator capable of executing the create
         */
        public static FeedbackSummaryCreator Create(DateTime? startDate, 
                                                    DateTime? endDate) {
            return new FeedbackSummaryCreator(startDate, endDate);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return FeedbackSummaryFetcher capable of executing the fetch
         */
        public static FeedbackSummaryFetcher Fetch(string accountSid, string sid) {
            return new FeedbackSummaryFetcher(accountSid, sid);
        }
    
        /**
         * Create a FeedbackSummaryFetcher to execute fetch.
         * 
         * @param sid The sid
         * @return FeedbackSummaryFetcher capable of executing the fetch
         */
        public static FeedbackSummaryFetcher Fetch(string sid) {
            return new FeedbackSummaryFetcher(sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return FeedbackSummaryDeleter capable of executing the delete
         */
        public static FeedbackSummaryDeleter Delete(string accountSid, string sid) {
            return new FeedbackSummaryDeleter(accountSid, sid);
        }
    
        /**
         * Create a FeedbackSummaryDeleter to execute delete.
         * 
         * @param sid The sid
         * @return FeedbackSummaryDeleter capable of executing the delete
         */
        public static FeedbackSummaryDeleter Delete(string sid) {
            return new FeedbackSummaryDeleter(sid);
        }
    
        /**
         * Converts a JSON string into a FeedbackSummaryResource object
         * 
         * @param json Raw JSON string
         * @return FeedbackSummaryResource object represented by the provided JSON
         */
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The call_count
         */
        public int? GetCallCount() {
            return this.callCount;
        }
    
        /**
         * @return The call_feedback_count
         */
        public int? GetCallFeedbackCount() {
            return this.callFeedbackCount;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The end_date
         */
        public DateTime? GetEndDate() {
            return this.endDate;
        }
    
        /**
         * @return The include_subaccounts
         */
        public bool? GetIncludeSubaccounts() {
            return this.includeSubaccounts;
        }
    
        /**
         * @return The issues
         */
        public List<FeedbackIssue> GetIssues() {
            return this.issues;
        }
    
        /**
         * @return The quality_score_average
         */
        public decimal? GetQualityScoreAverage() {
            return this.qualityScoreAverage;
        }
    
        /**
         * @return The quality_score_median
         */
        public decimal? GetQualityScoreMedian() {
            return this.qualityScoreMedian;
        }
    
        /**
         * @return The quality_score_standard_deviation
         */
        public decimal? GetQualityScoreStandardDeviation() {
            return this.qualityScoreStandardDeviation;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The start_date
         */
        public DateTime? GetStartDate() {
            return this.startDate;
        }
    
        /**
         * @return The status
         */
        public FeedbackSummaryResource.Status GetStatus() {
            return this.status;
        }
    }
}