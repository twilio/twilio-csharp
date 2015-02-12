using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Workers statistics.
    /// </summary>
    public class WorkersStatistics : TwilioBase
    {
        /// <summary>
        /// Gets or sets the account sid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets the workspace sid.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Gets or sets the cumulative.
        /// </summary>
        public CumulativeStatistics Cumulative { get; set; }

        /// <summary>
        /// Cumulative statistics.
        /// </summary>
        public class CumulativeStatistics
        {
            /// <summary>
            /// Gets or sets the start time.
            /// </summary>
            public DateTimeOffset? StartTime { get; set; }
            /// <summary>
            /// Gets or sets the end time.
            /// </summary>
            public DateTimeOffset? EndTime { get; set; }
            /// <summary>
            /// Gets or sets the reservations accepted.
            /// </summary>
            public int? ReservationsAccepted { get; set; }
            /// <summary>
            /// Gets or sets the reservations rejected.
            /// </summary>
            public int? ReservationsRejected { get; set; }
            /// <summary>
            /// Gets or sets the reservations timed out.
            /// </summary>
            public int? ReservationsTimedOut { get; set; }
            /// <summary>
            /// Gets or sets the tasks assigned.
            /// </summary>
            public int? TasksAssigned { get; set; }
            /// <summary>
            /// Gets or sets the activity durations.
            /// </summary>
            public List<ActivityDuration> ActivityDurations { get; set; }
        }

        /// <summary>
        /// Activity duration.
        /// </summary>
        public class ActivityDuration
        {
            /// <summary>
            /// Gets or sets the sid.
            /// </summary>
            public string Sid { get; set; }
            /// <summary>
            /// Gets or sets the name of the friendly.
            /// </summary>
            public string FriendlyName { get; set; }
            /// <summary>
            /// Gets or sets the minimum.
            /// </summary>
            public int? Min { get; set; }
            /// <summary>
            /// Gets or sets the max.
            /// </summary>
            public int? Max { get; set; }
            /// <summary>
            /// Gets or sets the avg.
            /// </summary>
            public decimal? Avg { get; set; }
        }

        /// <summary>
        /// Activity statistics.
        /// </summary>
        public class ActivityStatistics
        {
            /// <summary>
            /// Gets or sets the sid.
            /// </summary>
            public string Sid { get; set; }
            /// <summary>
            /// Gets or sets the name of the friendly.
            /// </summary>
            public string FriendlyName { get; set; }
            /// <summary>
            /// Gets or sets the workers.
            /// </summary>
            public int? Workers { get; set; }
        }

        /// <summary>
        /// Realtime statistics.
        /// </summary>
        public class RealtimeStatistics
        {
            /// <summary>
            /// Gets or sets the total workers.
            /// </summary>
            public int? TotalWorkers { get; set; }
            /// <summary>
            /// Gets or sets the activity statistics.
            /// </summary>
            public List<ActivityStatistics> ActivityStatistics { get; set; }
        }
    }
}

