using System;
using System.Collections.Generic;

namespace Twilio
{
    /// <summary>
    /// An FeedbackSummary instance resource represents a single Twilio call FeedbackSummary.
    /// </summary>
    public class FeedbackSummary : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this feedback summary.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The feedback summary start date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The feedback summary start date.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The feedback summary AccountSid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Twilio.FeedbackSummary"/> include subaccounts.
        /// </summary>
        /// <value><c>true</c> if include subaccounts; otherwise, <c>false</c>.</value>
        public bool IncludeSubaccounts { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the call count.
        /// </summary>
        /// <value>The call count.</value>
        public int? CallCount { get; set; }
        /// <summary>
        /// Gets or sets the call feedback count.
        /// </summary>
        /// <value>The call feedback count.</value>
        public int? CallFeedbackCount { get; set; }
        /// <summary>
        /// Gets or sets the quality score average.
        /// </summary>
        /// <value>The quality score average.</value>
        public double? QualityScoreAverage { get; set; }
        /// <summary>
        /// Gets or sets the quality score median.
        /// </summary>
        /// <value>The quality score median.</value>
        public double? QualityScoreMedian { get; set; }
        /// <summary>
        /// Gets or sets the quality score standard deviation.
        /// </summary>
        /// <value>The quality score standard deviation.</value>
        public double? QualityScoreStandardDeviation { get; set; }
        /// <summary>
        /// List of issues present in this feedback summary.
        /// </summary>
        public List<Issue> Issues { get; set; }
        /// <summary>
        /// The date that this feedback summary was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this feedback summary was last updated, given as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

    }
}

