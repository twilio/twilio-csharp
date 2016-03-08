using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Call;
using Twilio.Deleters.Api.V2010.Account.Call;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Call;
using Twilio.Http;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.types.FeedbackIssue;
using java.math.BigDecimal;
using java.util.List;
using org.joda.time.DateTime;
using org.joda.time.LocalDate;

namespace Twilio.Resources.Api.V2010.Account.Call {

    public class FeedbackSummary : SidResource {
        public enum Status {
            QUEUED="queued",
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            FAILED="failed"
        };
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param startDate The start_date
         * @param endDate The end_date
         * @return FeedbackSummaryCreator capable of executing the create
         */
        public static FeedbackSummaryCreator create(String accountSid, LocalDate startDate, LocalDate endDate) {
            return new FeedbackSummaryCreator(accountSid, startDate, endDate);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return FeedbackSummaryFetcher capable of executing the fetch
         */
        public static FeedbackSummaryFetcher fetch(String accountSid, String sid) {
            return new FeedbackSummaryFetcher(accountSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return FeedbackSummaryDeleter capable of executing the delete
         */
        public static FeedbackSummaryDeleter delete(String accountSid, String sid) {
            return new FeedbackSummaryDeleter(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a FeedbackSummary object
         * 
         * @param json Raw JSON string
         * @return FeedbackSummary object represented by the provided JSON
         */
        public static FeedbackSummary fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<FeedbackSummary>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("call_count")]
        private readonly Integer callCount;
        [JsonProperty("call_feedback_count")]
        private readonly Integer callFeedbackCount;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("end_date")]
        private readonly DateTime endDate;
        [JsonProperty("include_subaccounts")]
        private readonly Boolean includeSubaccounts;
        [JsonProperty("issues")]
        private readonly List<FeedbackIssue> issues;
        [JsonProperty("quality_score_average")]
        private readonly BigDecimal qualityScoreAverage;
        [JsonProperty("quality_score_median")]
        private readonly BigDecimal qualityScoreMedian;
        [JsonProperty("quality_score_standard_deviation")]
        private readonly BigDecimal qualityScoreStandardDeviation;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("start_date")]
        private readonly DateTime startDate;
        [JsonProperty("status")]
        private readonly FeedbackSummary.Status status;
    
        private FeedbackSummary([JsonProperty("account_sid")]
                                String accountSid, 
                                [JsonProperty("call_count")]
                                Integer callCount, 
                                [JsonProperty("call_feedback_count")]
                                Integer callFeedbackCount, 
                                [JsonProperty("date_created")]
                                String dateCreated, 
                                [JsonProperty("date_updated")]
                                String dateUpdated, 
                                [JsonProperty("end_date")]
                                String endDate, 
                                [JsonProperty("include_subaccounts")]
                                Boolean includeSubaccounts, 
                                [JsonProperty("issues")]
                                List<FeedbackIssue> issues, 
                                [JsonProperty("quality_score_average")]
                                BigDecimal qualityScoreAverage, 
                                [JsonProperty("quality_score_median")]
                                BigDecimal qualityScoreMedian, 
                                [JsonProperty("quality_score_standard_deviation")]
                                BigDecimal qualityScoreStandardDeviation, 
                                [JsonProperty("sid")]
                                String sid, 
                                [JsonProperty("start_date")]
                                String startDate, 
                                [JsonProperty("status")]
                                FeedbackSummary.Status status) {
            this.accountSid = accountSid;
            this.callCount = callCount;
            this.callFeedbackCount = callFeedbackCount;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.endDate = MarshalConverter.dateTimeFromString(endDate);
            this.includeSubaccounts = includeSubaccounts;
            this.issues = issues;
            this.qualityScoreAverage = qualityScoreAverage;
            this.qualityScoreMedian = qualityScoreMedian;
            this.qualityScoreStandardDeviation = qualityScoreStandardDeviation;
            this.sid = sid;
            this.startDate = MarshalConverter.dateTimeFromString(startDate);
            this.status = status;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The call_count
         */
        public Integer GetCallCount() {
            return this.callCount;
        }
    
        /**
         * @return The call_feedback_count
         */
        public Integer GetCallFeedbackCount() {
            return this.callFeedbackCount;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The end_date
         */
        public DateTime GetEndDate() {
            return this.endDate;
        }
    
        /**
         * @return The include_subaccounts
         */
        public Boolean GetIncludeSubaccounts() {
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
        public BigDecimal GetQualityScoreAverage() {
            return this.qualityScoreAverage;
        }
    
        /**
         * @return The quality_score_median
         */
        public BigDecimal GetQualityScoreMedian() {
            return this.qualityScoreMedian;
        }
    
        /**
         * @return The quality_score_standard_deviation
         */
        public BigDecimal GetQualityScoreStandardDeviation() {
            return this.qualityScoreStandardDeviation;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The start_date
         */
        public DateTime GetStartDate() {
            return this.startDate;
        }
    
        /**
         * @return The status
         */
        public FeedbackSummary.Status GetStatus() {
            return this.status;
        }
    }
}