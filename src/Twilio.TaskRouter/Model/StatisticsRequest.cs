using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Common time-interval options for TaskRouter Statistics requests.
    /// </summary>
    public class StatisticsRequest
    {
        /// <summary>
        /// Sets the length of the window over which statistics should be computed.
        /// Defaults to 15 minutes.
        /// </summary>
        /// <value>Interval length for statistics computation.</value>
        public int? Minutes { get; set; }

        /// <summary>
        /// Sets the starting point in time for statistics collection. Can be used
        /// in conjunction with either EndDate or Minutes to define an interval.
        /// </summary>
        /// <value>Statistics interval start date/time.</value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Sets the ending point in time for statistics collection. Can be used
        /// in conjunction with either StartDate or Minutes to define an interval.
        /// </summary>
        /// <value>Statistics interval end date/time</value>
        public DateTime? EndDate { get; set; }
    }
}

