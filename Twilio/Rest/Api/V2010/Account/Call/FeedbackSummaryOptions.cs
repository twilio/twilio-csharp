using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class CreateFeedbackSummaryOptions : IOptions<FeedbackSummaryResource> 
    {
        public string AccountSid { get; set; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public bool? IncludeSubaccounts { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new CreateFeedbackSummaryOptions
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        public CreateFeedbackSummaryOptions(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }
            
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }
            
            if (IncludeSubaccounts != null)
            {
                p.Add(new KeyValuePair<string, string>("IncludeSubaccounts", IncludeSubaccounts.Value.ToString()));
            }
            
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }
            
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            
            return p;
        }
    }

    public class FetchFeedbackSummaryOptions : IOptions<FeedbackSummaryResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchFeedbackSummaryOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchFeedbackSummaryOptions(string sid)
        {
            Sid = sid;
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

    public class DeleteFeedbackSummaryOptions : IOptions<FeedbackSummaryResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteFeedbackSummaryOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteFeedbackSummaryOptions(string sid)
        {
            Sid = sid;
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

}