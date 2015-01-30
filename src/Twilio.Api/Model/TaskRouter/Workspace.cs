using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// A workspace is a container for your Tasks, Workers, TaskQueues and Workflows. Each of these items exists within a single Workspace and will not be shared across Workspaces.
    /// </summary>
    public class Workspace : TwilioBase
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
        /// Gets or sets the event callback URL.
        /// </summary>
        public string EventCallbackUrl { get; set; }
        /// <summary>
        /// Gets or sets the default activity sid.
        /// </summary>
        public string DefaultActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the default name of the activity.
        /// </summary>
        public string DefaultActivityName { get; set; }
        /// <summary>
        /// Gets or sets the timeout activity sid.
        /// </summary>
        public string TimeoutActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the name of the timeout activity.
        /// </summary>
        public string TimeoutActivityName { get; set; }
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

