using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// TaskQueues are the resource you use to categorize Tasks and describe which Workers are eligible to handle those Tasks. As your workflows process tasks, those tasks will pass through one or more TaskQueues until the task is assigned and accepted by an eligible worker.
    /// </summary>
    public class TaskQueue : TwilioBase
    {
        /// <summary>
        /// The unique ID of the TaskQueue.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The ID of the Account that owns this TaskQueue.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Workspace"/> that owns this TaskQueue.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Human-readable description of this TaskQueue.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The worker selection expressions associated with this TaskQueue.
        /// </summary>
        public string TargetWorkers { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Activity"/> to assign a <see cref="Twilio.TaskRouter.Worker"/>
        /// when they are reserved for a <see cref="Twilio.TaskRouter.Task"/> from
        /// this TaskQueue.
        /// </summary>
        public string ReservationActivitySid { get; set; }
        /// <summary>
        /// The human-readable description of the ReservationActivity.
        /// </summary>
        public string ReservationActivityName { get; set; }
        /// <summary>
        /// The ID of the Activity to assign a Worker when they accept a Task from this TaskQueue.
        /// </summary>
        public string AssignmentActivitySid { get; set; }
        /// <summary>
        /// The human-readable description of the Activity to assign a Worker when they accept a Task from this TaskQueue.
        /// </summary>
        public string AssignmentActivityName { get; set; }
        /// <summary>
        /// The date this TaskQueue was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date this TaskQueue was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

