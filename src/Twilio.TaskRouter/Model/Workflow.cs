using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Workflows allow you to configure rules about how tasks will be prioritized and routed into TaskQueues, and how Tasks should escalate in priority or move across queues over time.
    /// </summary>
    public class Workflow : TwilioBase
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
        /// Gets or sets the account sid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets the workspace sid.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Gets or sets the assignment callback URL.
        /// </summary>
        public string AssignmentCallbackUrl { get; set; }
        /// <summary>
        /// Gets or sets the fallback assignment callback URL.
        /// </summary>
        public string FallbackAssignmentCallbackUrl { get; set; }
        /// <summary>
        /// Gets or sets the type of the document content.
        /// </summary>
        public string DocumentContentType { get; set; }
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public string Configuration { set; get; }
        /// <summary>
        /// Gets or sets the task reservation timeout.
        /// </summary>
        public string TaskReservationTimeout { set; get; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

