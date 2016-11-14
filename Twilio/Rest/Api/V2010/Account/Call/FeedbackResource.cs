using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FeedbackResource : Resource 
    {
        public sealed class FeedbackIssues : IStringEnum 
        {
            public const string AudioLatency = "audio-latency";
            public const string DigitsNotCaptured = "digits-not-captured";
            public const string DroppedCall = "dropped-call";
            public const string ImperfectAudio = "imperfect-audio";
            public const string IncorrectCallerId = "incorrect-caller-id";
            public const string OneWayAudio = "one-way-audio";
            public const string PostDialDelay = "post-dial-delay";
            public const string UnsolicitedCall = "unsolicited-call";
        
            private string _value;
            
            public FeedbackIssues() {}
            
            public FeedbackIssues(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator FeedbackIssues(string value)
            {
                return new FeedbackIssues(value);
            }
            
            public static implicit operator string(FeedbackIssues value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
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
        public string accountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("issues")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<FeedbackResource.FeedbackIssues> issues { get; set; }
        [JsonProperty("quality_score")]
        public int? qualityScore { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
    
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
                                 List<FeedbackResource.FeedbackIssues> issues, 
                                 [JsonProperty("quality_score")]
                                 int? qualityScore, 
                                 [JsonProperty("sid")]
                                 string sid)
                                 {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.issues = issues;
            this.qualityScore = qualityScore;
            this.sid = sid;
        }
    }
}