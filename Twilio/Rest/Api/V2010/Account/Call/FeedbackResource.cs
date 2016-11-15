using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FeedbackResource : Resource 
    {
        public sealed class IssuesEnum : StringEnum 
        {
            private IssuesEnum(string value) : base(value) {}
            public IssuesEnum() {}
        
            public static IssuesEnum AudioLatency = new IssuesEnum("audio-latency");
            public static IssuesEnum DigitsNotCaptured = new IssuesEnum("digits-not-captured");
            public static IssuesEnum DroppedCall = new IssuesEnum("dropped-call");
            public static IssuesEnum ImperfectAudio = new IssuesEnum("imperfect-audio");
            public static IssuesEnum IncorrectCallerId = new IssuesEnum("incorrect-caller-id");
            public static IssuesEnum OneWayAudio = new IssuesEnum("one-way-audio");
            public static IssuesEnum PostDialDelay = new IssuesEnum("post-dial-delay");
            public static IssuesEnum UnsolicitedCall = new IssuesEnum("unsolicited-call");
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> The quality_score </param>
        /// <returns> FeedbackCreator capable of executing the create </returns> 
        public static FeedbackCreator Creator(string callSid, int? qualityScore)
        {
            return new FeedbackCreator(callSid, qualityScore);
        }
    
        /// <summary>
        /// Fetch an instance of a feedback entry for a call
        /// </summary>
        ///
        /// <param name="callSid"> The call sid that uniquely identifies the call </param>
        /// <returns> FeedbackFetcher capable of executing the fetch </returns> 
        public static FeedbackFetcher Fetcher(string callSid)
        {
            return new FeedbackFetcher(callSid);
        }
    
        /// <summary>
        /// Create or update a feedback entry for a call
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> An integer from 1 to 5 </param>
        /// <returns> FeedbackUpdater capable of executing the update </returns> 
        public static FeedbackUpdater Updater(string callSid, int? qualityScore)
        {
            return new FeedbackUpdater(callSid, qualityScore);
        }
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns> 
        public static FeedbackResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("issues")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<FeedbackResource.IssuesEnum> Issues { get; set; }
        [JsonProperty("quality_score")]
        public int? QualityScore { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
    
        public FeedbackResource()
        {
        
        }
    
        private FeedbackResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("issues")]
                                 List<FeedbackResource.IssuesEnum> issues, 
                                 [JsonProperty("quality_score")]
                                 int? qualityScore, 
                                 [JsonProperty("sid")]
                                 string sid)
                                 {
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Issues = issues;
            QualityScore = qualityScore;
            Sid = sid;
        }
    }
}