using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Workflow statistics.
    /// </summary>
    public class WorkflowStatistics : TwilioBase
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
        /// Gets or sets the workflow sid.
        /// </summary>
        public string WorkflowSid { get; set; }
        /// <summary>
        /// Gets or sets the realtime.
        /// </summary>
        public RealtimeStatistics Realtime { get; set; }
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
            /// Gets or sets the tasks entered.
            /// </summary>
            public int? TasksEntered { get; set; }
            /// <summary>
            /// Gets or sets the tasks canceled.
            /// </summary>
            public int? TasksCanceled { get; set; }
            /// <summary>
            /// Gets or sets the tasks moved.
            /// </summary>
            public int? TasksMoved { get; set; }
            /// <summary>
            /// Gets or sets the tasks timed out in workflow.
            /// </summary>
            public int? TasksTimedOutInWorkflow { get; set; }
            /// <summary>
            /// Gets or sets the avg task acceptance time.
            /// </summary>
            public decimal? AvgTaskAcceptanceTime { get; set; }

        }

        /// <summary>
        /// Realtime statistics.
        /// </summary>
        public class RealtimeStatistics
        {
            /// <summary>
            /// Gets or sets the longest task waiting sid.
            /// </summary>
            public string LongestTaskWaitingSid { get; set; }
            /// <summary>
            /// Gets or sets the longest task waiting age.
            /// </summary>
            public int? LongestTaskWaitingAge { get; set; }
            /// <summary>
            /// Gets or sets the total tasks.
            /// </summary>
            public int? TotalTasks { get; set; }
            /// <summary>
            /// Gets or sets the tasks by status.
            /// </summary>
            public TasksByStatus TasksByStatus { get; set; }
        }

        /// <summary>
        /// Tasks by status.
        /// </summary>
        public class TasksByStatus
        {
            /// <summary>
            /// Gets or sets the pending.
            /// </summary>
            public int? Pending { get; set; }
            /// <summary>
            /// Gets or sets the assigned.
            /// </summary>
            public int? Assigned { get; set; }
            /// <summary>
            /// Gets or sets the reserved.
            /// </summary>
            public int? Reserved { get; set; }
        }
    }
}

