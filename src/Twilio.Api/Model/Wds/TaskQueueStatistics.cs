using System;

namespace Twilio.Wds
{
    public class TaskQueueStatistics
    {
        public string AccountSid { get; set; }
        public string WorkspaceSid { get; set; }
        public string TaskQueueSid { get; set; }

        class TaskQueueRealtimeStatistics
        {
            public string LongestTaskWaitingSid { get; set; }
            public int? LongestTaskWaitingAge { get; set; }
            public int? TotalTasks { get; set; }
            // #TODO TasksByStatus
            // #TODO ActivityStatistics
            public int? TotalEligibleWorkers { get; set; }
            public int? TotalAvailableWorkers { get; set; }
        }
    }
}

