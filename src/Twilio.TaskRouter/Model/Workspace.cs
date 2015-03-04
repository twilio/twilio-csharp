using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// A workspace is a container for your Tasks, Workers, TaskQueues and Workflows. Each of these items exists within a single Workspace and will not be shared across Workspaces.
    /// </summary>
    public class Workspace : TwilioBase
    {
        /// <summary>
        /// The unique ID of the Workspace.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// A human-readable description of this workspace.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The ID of the account that owns this Workspace.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// An optional URL where the Workspace will publish events.
        /// </summary>
        public string EventCallbackUrl { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Activity" /> that will
        /// be used when new Workers are created in this Workspace.
        /// </summary>
        public string DefaultActivitySid { get; set; }
        /// <summary>
        /// The human-readable name of the default Activity.
        /// </summary>
        public string DefaultActivityName { get; set; }
        /// <summary>
        /// The ID of the Activity that will be assigned to a <see
        /// cref="Twilio.TaskRouter.Worker" /> when a
        /// <see cref="Twilio.TaskRouter.Task" /> times out without a response.
        /// </summary>
        public string TimeoutActivitySid { get; set; }
        /// <summary>
        /// The human-readable name of the timeout activity.
        /// </summary>
        public string TimeoutActivityName { get; set; }
        /// <summary>
        /// The time the workspace was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The time the workspace was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

