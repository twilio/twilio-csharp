using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Search filter options for a list of Task 
    /// </summary>
    public class WorkerListRequest
    {
        /// <summary>
        /// Gets or sets the task queue sid.
        /// </summary>
        public string TaskQueueSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the task queue.
        /// </summary>
        public string TaskQueueName { get; set; }
        /// <summary>
        /// Gets or sets the activity sid.
        /// </summary>
        public string ActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Gets or sets the target workers expression.
        /// </summary>
        public string TargetWorkersExpression { get; set; }
        /// <summary>
        /// Gets or sets the after sid.
        /// </summary>
        public string AfterSid { get; set; }
        /// <summary>
        /// Gets or sets the before sid.
        /// </summary>
        public string BeforeSid { get; set; }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int? Count { get; set; }
    }
}

