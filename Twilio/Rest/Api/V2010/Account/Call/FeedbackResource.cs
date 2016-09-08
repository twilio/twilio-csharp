using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class FeedbackResource : Resource {
        public sealed class Issues : IStringEnum {
            public const string AUDIO_LATENCY="audio-latency";
            public const string DIGITS_NOT_CAPTURED="digits-not-captured";
            public const string DROPPED_CALL="dropped-call";
            public const string IMPERFECT_AUDIO="imperfect-audio";
            public const string INCORRECT_CALLER_ID="incorrect-caller-id";
            public const string ONE_WAY_AUDIO="one-way-audio";
            public const string POST_DIAL_DELAY="post-dial-delay";
            public const string UNSOLICITED_CALL="unsolicited-call";
        
            private string value;
            
            public Issues() { }
            
            public Issues(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Issues(string value) {
                return new Issues(value);
            }
            
            public static implicit operator string(Issues value) {
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
         * @param callSid The call_sid
         * @param qualityScore The quality_score
         * @return FeedbackCreator capable of executing the create
         */
        public static FeedbackCreator Create(string accountSid, string callSid, int? qualityScore) {
            return new FeedbackCreator(accountSid, callSid, qualityScore);
        }
    
        /**
         * Create a FeedbackCreator to execute create.
         * 
         * @param callSid The call_sid
         * @param qualityScore The quality_score
         * @return FeedbackCreator capable of executing the create
         */
        public static FeedbackCreator Create(string callSid, 
                                             int? qualityScore) {
            return new FeedbackCreator(callSid, qualityScore);
        }
    
        /**
         * Fetch an instance of a feedback entry for a call
         * 
         * @param accountSid The account_sid
         * @param callSid The call sid that uniquely identifies the call
         * @return FeedbackFetcher capable of executing the fetch
         */
        public static FeedbackFetcher Fetch(string accountSid, string callSid) {
            return new FeedbackFetcher(accountSid, callSid);
        }
    
        /**
         * Create a FeedbackFetcher to execute fetch.
         * 
         * @param callSid The call sid that uniquely identifies the call
         * @return FeedbackFetcher capable of executing the fetch
         */
        public static FeedbackFetcher Fetch(string callSid) {
            return new FeedbackFetcher(callSid);
        }
    
        /**
         * Create or update a feedback entry for a call
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore An integer from 1 to 5
         * @return FeedbackUpdater capable of executing the update
         */
        public static FeedbackUpdater Update(string accountSid, string callSid, int? qualityScore) {
            return new FeedbackUpdater(accountSid, callSid, qualityScore);
        }
    
        /**
         * Create a FeedbackUpdater to execute update.
         * 
         * @param callSid The call_sid
         * @param qualityScore An integer from 1 to 5
         * @return FeedbackUpdater capable of executing the update
         */
        public static FeedbackUpdater Update(string callSid, 
                                             int? qualityScore) {
            return new FeedbackUpdater(callSid, qualityScore);
        }
    
        /**
         * Converts a JSON string into a FeedbackResource object
         * 
         * @param json Raw JSON string
         * @return FeedbackResource object represented by the provided JSON
         */
        public static FeedbackResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("issues")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly List<FeedbackResource.Issues> issues;
        [JsonProperty("quality_score")]
        private readonly int? qualityScore;
        [JsonProperty("sid")]
        private readonly string sid;
    
        public FeedbackResource() {
        
        }
    
        private FeedbackResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("issues")]
                                 List<FeedbackResource.Issues> issues, 
                                 [JsonProperty("quality_score")]
                                 int? qualityScore, 
                                 [JsonProperty("sid")]
                                 string sid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.issues = issues;
            this.qualityScore = qualityScore;
            this.sid = sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
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
         * @return The issues
         */
        public List<FeedbackResource.Issues> GetIssues() {
            return this.issues;
        }
    
        /**
         * @return 1 to 5 quality score
         */
        public int? GetQualityScore() {
            return this.qualityScore;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    }
}