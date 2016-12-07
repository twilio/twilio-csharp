using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class CreateFeedbackOptions : IOptions<FeedbackResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public int? QualityScore { get; }
        public List<FeedbackResource.IssuesEnum> Issue { get; set; }
    
        /// <summary>
        /// Construct a new CreateFeedbackOptions
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> The quality_score </param>
        public CreateFeedbackOptions(string callSid, int? qualityScore)
        {
            CallSid = callSid;
            QualityScore = qualityScore;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (QualityScore != null)
            {
                p.Add(new KeyValuePair<string, string>("QualityScore", QualityScore.ToString()));
            }
            
            if (Issue != null)
            {
                p.Add(new KeyValuePair<string, string>("Issue", Issue.ToString()));
            }
            
            return p;
        }
    }

    public class FetchFeedbackOptions : IOptions<FeedbackResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
    
        /// <summary>
        /// Construct a new FetchFeedbackOptions
        /// </summary>
        ///
        /// <param name="callSid"> The call sid that uniquely identifies the call </param>
        public FetchFeedbackOptions(string callSid)
        {
            CallSid = callSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class UpdateFeedbackOptions : IOptions<FeedbackResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public int? QualityScore { get; }
        public List<FeedbackResource.IssuesEnum> Issue { get; set; }
    
        /// <summary>
        /// Construct a new UpdateFeedbackOptions
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> An integer from 1 to 5 </param>
        public UpdateFeedbackOptions(string callSid, int? qualityScore)
        {
            CallSid = callSid;
            QualityScore = qualityScore;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (QualityScore != null)
            {
                p.Add(new KeyValuePair<string, string>("QualityScore", QualityScore.ToString()));
            }
            
            if (Issue != null)
            {
                p.Add(new KeyValuePair<string, string>("Issue", Issue.ToString()));
            }
            
            return p;
        }
    }

}