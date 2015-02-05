using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// A Task instance resource represents a single item of work waiting to be processed.
    /// </summary>
    public class Task : TwilioBase
    {
        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// Gets or sets the account sid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets the assignment status.
        /// </summary>
        public string AssignmentStatus { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Gets or sets the workspace sid.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Gets or sets the workflow sid.
        /// </summary>
        public string WorkflowSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the workflow friendly.
        /// </summary>
        public string WorkflowFriendlyName { get; set; }
        /// <summary>
        /// Gets or sets the task queue sid.
        /// </summary>
        public string TaskQueueSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the task queue friendly.
        /// </summary>
        public string TaskQueueFriendlyName { get; set; }
    }
}

