using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class FeedbackSummary : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The first date for which feedback entries are included in this Feedback Summary, formatted as YYYY-MM-DD. All dates are in UTC
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The last date for which feedback entries are included in this Feedback Summary, formatted as YYYY-MM-DD. All dates are in UTC.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The Account that reported the feedback entry.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// true if the feedback summary includes subaccounts, false otherwise
        /// </summary>
        public bool IncludesSubaccounts { get; set; }
        /// <summary>
        /// The status of the feedback summary can be queued, in-progress, completed, or failed
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The total number of calls
        /// </summary>
        public int CallCount { get; set; }
        /// <summary>
        /// The total number of calls with a feedback entry
        /// </summary>
        public int CallFeedbackCount { get; set; }
        /// <summary>
        /// The average QualityScore of the feedback entries
        /// </summary>
        public double QualityScoreAverage { get; set; }
        /// <summary>
        /// The median QualityScore of the feedback entries
        /// </summary>
        public double QualityScoreMedian { get; set; }
        /// <summary>
        /// The standard deviation of the quality scores
        /// </summary>
        public double QualityScoreStandardDeviation { get; set; }
        /// <summary>
        /// A list of all the issues experienced. The list includes the issue name, the number of occurrences and percentage of calls that experienced this issue
        /// </summary>
        public List<Issue> Issues { get; set; }
        /// <summary>
        /// The date that this resource was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated, given as GMT 
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}
