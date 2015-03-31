using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Activities describe the current status of your Workers, which determines whether they are
    /// eligible to receive task assignments. Workers are always set to a single Activity.
    /// </summary>
    public class Activity : TwilioBase
    {
        /// <summary>
        /// The unique ID for this Activity.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The unique ID of the Account that owns this Activity.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The unique ID of the <see cref="Twilio.TaskRouter.Workspace"/> that contains this Activity.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// A human-readable name for this Activity, such as "on-call" or "break".
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Indicates whether a <see cref="Twilio.TaskRouter.Worker"/> should be eligible to receive
        /// a new <see cref="Twilio.TaskRouter.Task"/> while occupying this Activity.
        /// </summary>
        public bool Available { get; set; }
        /// <summary>
        /// The date and time this Activity was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date and time this Activity was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

