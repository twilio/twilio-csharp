using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// A Task Reservation is created whenever a <see cref="Twilio.TaskRouter.Task"/> is assigned to a Worker.
    /// </summary>
    public class Reservation : TwilioBase
    {
        /// <summary>
        /// The unique ID of this Reservation.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The ID of the Account that owns this Reservation.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Workspace"/> containing this Task.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// The ID of the reserved Task.
        /// </summary>
        public string TaskSid { get; set; }
        /// <summary>
        /// The ID of the reserved <see cref="Twilio.TaskRouter.Worker"/>.
        /// </summary>
        public string WorkerSid { get; set; }
        /// <summary>
        /// Human-readable description of the reserved Worker.
        /// </summary>
        public string WorkerName { get; set; }
        /// <summary>
        /// The ID of the Activity the Worker is in.
        /// </summary>
        public string WorkerActivitySid { get; set; }
        /// <summary>
        /// The current status of the reservation. One of "pending", "accepted", "rejected", or "timeout".
        /// </summary>
        public string ReservationStatus { get; set; }
        /// <summary>
        /// The date and time this reservation was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The dat and time this reservation was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

