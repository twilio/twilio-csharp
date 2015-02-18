using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// TaskQueues are the resource you use to categorize Tasks and describe which Workers are eligible to handle those Tasks. As your workflows process tasks, those tasks will pass through one or more TaskQueues until the task is assigned and accepted by an eligible worker.
    /// </summary>
    public class TaskQueue : TwilioBase
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
        /// Gets or sets the workspace sid.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Gets or sets the target workers.
        /// </summary>
        public string TargetWorkers { get; set; }
        /// <summary>
        /// Gets or sets the reservation activity sid.
        /// </summary>
        public string ReservationActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the name of the reservation activity.
        /// </summary>
        public string ReservationActivityName { get; set; }
        /// <summary>
        /// Gets or sets the assignment activity sid.
        /// </summary>
        public string AssignmentActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the name of the assignment activity.
        /// </summary>
        public string AssignmentActivityName { get; set; }
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

