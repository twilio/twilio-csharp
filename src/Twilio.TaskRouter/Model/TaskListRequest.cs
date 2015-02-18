using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Search filter options for a list of Task 
    /// </summary>
    public class TaskListRequest
    {
        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// Gets or sets the assignment status.
        /// </summary>
        public string AssignmentStatus { get; set; }
        /// <summary>
        /// Gets or sets the workflow sid.
        /// </summary>
        public string WorkflowSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the workflow.
        /// </summary>
        public string WorkflowName { get; set; }
        /// <summary>
        /// Gets or sets the task queue sid.
        /// </summary>
        public string TaskQueueSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the task queue.
        /// </summary>
        public string TaskQueueName { get; set; }
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

