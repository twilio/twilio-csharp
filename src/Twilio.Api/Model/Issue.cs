using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Feedback summary issue.
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// The issue name
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The number of occurrences of this issue
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// The percentage of calls that experienced this issue
        /// </summary>
        public double PercentageOfTotalCalls { get; set; }
    }
}
