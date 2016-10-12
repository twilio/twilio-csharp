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
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> The quality_score </param>
        /// <returns> FeedbackCreator capable of executing the create </returns> 
        public static FeedbackCreator Creator(string accountSid, string callSid, int? qualityScore) {
            return new FeedbackCreator(accountSid, callSid, qualityScore);
        }
    
        /// <summary>
        /// Create a FeedbackCreator to execute create.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> The quality_score </param>
        /// <returns> FeedbackCreator capable of executing the create </returns> 
        public static FeedbackCreator Creator(string callSid, 
                                              int? qualityScore) {
            return new FeedbackCreator(callSid, qualityScore);
        }
    
        /// <summary>
        /// Fetch an instance of a feedback entry for a call
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call sid that uniquely identifies the call </param>
        /// <returns> FeedbackFetcher capable of executing the fetch </returns> 
        public static FeedbackFetcher Fetcher(string accountSid, string callSid) {
            return new FeedbackFetcher(accountSid, callSid);
        }
    
        /// <summary>
        /// Create a FeedbackFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="callSid"> The call sid that uniquely identifies the call </param>
        /// <returns> FeedbackFetcher capable of executing the fetch </returns> 
        public static FeedbackFetcher Fetcher(string callSid) {
            return new FeedbackFetcher(callSid);
        }
    
        /// <summary>
        /// Create or update a feedback entry for a call
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> An integer from 1 to 5 </param>
        /// <returns> FeedbackUpdater capable of executing the update </returns> 
        public static FeedbackUpdater Updater(string accountSid, string callSid, int? qualityScore) {
            return new FeedbackUpdater(accountSid, callSid, qualityScore);
        }
    
        /// <summary>
        /// Create a FeedbackUpdater to execute update.
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> An integer from 1 to 5 </param>
        /// <returns> FeedbackUpdater capable of executing the update </returns> 
        public static FeedbackUpdater Updater(string callSid, 
                                              int? qualityScore) {
            return new FeedbackUpdater(callSid, qualityScore);
        }
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The issues </returns> 
        public List<FeedbackResource.Issues> GetIssues() {
            return this.issues;
        }
    
        /// <returns> 1 to 5 quality score </returns> 
        public int? GetQualityScore() {
            return this.qualityScore;
        }
    
        /// <returns> The sid </returns> 
        public string GetSid() {
            return this.sid;
        }
    }
}