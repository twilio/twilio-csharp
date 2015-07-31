using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// A Task instance resource represents a single item of work waiting to be processed.
    /// </summary>
    public class Task : TwilioBase
    {
        /// <summary>
        /// The unique ID of the Task.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The ID of the account that owns this Task.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// A string representing the assignment state of the task. One of "pending",
        /// "reserved", "assigned", or "canceled".
        /// </summary>
        public string AssignmentStatus { get; set; }
        /// <summary>
        /// The user-defined JSON string describing the custom attributes of this Task.
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// A dictionary representing the user-defined JSON string describing the custom attributes of this Task.
        /// </summary>
        public Dictionary<string, string> ParseAttributes() {
            return TaskRouterClient.FromJsonToDictionary(Attributes);
        }
        /// <summary>
        /// The date this Task was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date this Task was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// The current priority score of the task, as assigned by the workflow.
        /// Tasks with higher values will be assigned before tasks with lower values.
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// The number of seconds since this task was created.
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// The reason the task was canceled (if applicable).
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// The unique ID of the <see cref="Twilio.TaskRouter.Workspace"/> containing this task.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Workflow"/> responsible for routing this task.
        /// </summary>
        public string WorkflowSid { get; set; }
        /// <summary>
        /// The human-readable name of the Workflow responsible for routing this task.
        /// </summary>
        public string WorkflowFriendlyName { get; set; }
        /// <summary>
        /// The ID of the current TaskQueue this Task is occupying.
        /// </summary>
        public string TaskQueueSid { get; set; }
        /// <summary>
        /// The human-readable name of the current TaskQueue.
        /// </summary>
        public string TaskQueueFriendlyName { get; set; }
    }
}

